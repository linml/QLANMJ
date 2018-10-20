/***************************************************************************
 * 
 * 创建时间：   2017/12/21 17:41:50
 * 创建人员：   沈瑞
 * CLR版本号：  4.0.30319.42000
 * 备注信息：   未填写备注信息
 * 
 * *************************************************************************/




using System;
using QL.Extension;
using QL.Tools;
using QL.RedisTools;
using System.Linq;
using GameIF;
using QL.Common;
using QL.Net.DataPacket;
using System.Threading.Tasks;
#if WEB_API
using QLGameRESTAPI.Core;
#endif

namespace QL.Server.RedisOP
{
    /// <summary>
    /// 提供Redis操作类
    /// </summary>
    public static class RedisOperation
    {


        static RedisOperation()
        {
#if WEB_API
            redisClient = RedisClientProvider.Connect(Global.Instance.ConfigManager.RedisConstr, Global.Instance.ConfigManager.RedisDbId);
#else
            var config = SystemCommonConfig.Instance;
            redisClient = RedisClientProvider.Connect(config.RedisConstr, config.RedisDbId);
#endif
            redisClient.ConnectInitCompleted += RedisClient_ConnectInitCompleted;
            _redisReceiveMessageQueue.MessageComing = _redisReceiveMessageQueue_MessageComing;
            redisClient.Satrt();

        }





        //PR  --  场地信息注册
        //PL  --  玩家在登录服务器的位置 
        //PO  --  玩家的断线房间位置
        //PT  --  房间信息
        //PUT  --  玩家创建房间列表
        //PGT  --  群组创建的房间列表

        const string LinkStr = "#";
#if WEB_API
        static string _RegionHost => Global.Instance.ConfigManager.RegionHost;

#else
        static string _RegionHost => SystemCommonConfig.Instance.RegionHost;
#endif
        static string _ServerPublis => _RegionHost + LinkStr;


        static string _ServerData => _RegionHost + LinkStr;

        static readonly string _PublisAll = _ServerPublis + "ALL";
        static string _PublisGS = _ServerPublis + "GS";             //游戏服务器订阅
        static string _PublisLS = _ServerPublis + "LS";             //登录服务器订阅
        static string _PublisCS = _ServerPublis + "CS";             //中心服务器订阅
        static string _PublisAPI = _ServerPublis + "API";         //网站接口订阅

        static string _UserLoc = _ServerData + "UL" + LinkStr;
        static string _UserOfflineLoc = _ServerData + "OL" + LinkStr;
        static string _TableInfo = _ServerData + "TI" + LinkStr;
        static string _UserCreateTable = _ServerData + "UT" + LinkStr;
        static string _GroupCreateTable = _ServerData + "GT" + LinkStr;
        static string _RegisterRoom = _ServerData + "PR" + LinkStr;

        static ServerType _serverType = ServerType.Unknown;
        static bool _isRedisInit = false;
        static bool _serverTypeChange = false;

        /// <summary>
        /// 
        /// </summary>
        public static ServerType ServerType
        {
            get { return _serverType; }
            set
            { 
                if (_serverType == ServerType.Unknown)
                {
                    _serverType = value;
                    OnServerTypeChange();
                } 
            }
        }


        private static IRedisOperation redisClient;
        private static IO.NetworkStream netStream = new IO.NetworkStream();

        static readonly Guid _serverUuid = Guid.NewGuid();
        /// <summary>
        /// 当前服务器的服务器编号
        /// </summary>
        public static Guid ServerUuid => _serverUuid;
        /// <summary>
        /// 
        /// </summary>
        public static readonly string ServerUuidStr = ServerUuid.ToString("n");
        //redis 接收的消息队列
        private static IMessageQueue<RedisChanelMessage> _redisReceiveMessageQueue = new MessageQueue<RedisChanelMessage>();


        private static void OnServerTypeChange()
        {
            _serverTypeChange = true;
            DoSubscribeRegister();
        }
        /// <summary>
        /// 
        /// </summary>
        public static event QLEventHandle<RedisMessage> RedisMessageComing;
        /// <summary>
        ///        
        ///</summary>
        public static event QLEventHandle ConnectInitCompleted;



        private static void _redisReceiveMessageQueue_MessageComing(IMessageQueue<RedisChanelMessage> sender, MessageEventArgs<RedisChanelMessage> e)
        {
            byte[] m = e.Message.Message;
            if (m == null || m.Length == 0) return;

            netStream.Write(m);
            ProcessAnalysis();

        }
        private static void RedisClient_ConnectInitCompleted(object sender, object e)
        {
            _isRedisInit = true;
            DoSubscribeRegister();
        }
        private static void DoSubscribeRegister()
        {
            if (_isRedisInit && _serverTypeChange)
            {

                Task task1 = redisClient.SubscribeAsync(_PublisAll, SubscribeAsyncCallback);
                Task task2 = null;
                switch (_serverType)
                {
                    case ServerType.GameServer:
                        task2 = redisClient.SubscribeAsync(_PublisGS, SubscribeAsyncCallback);
                        break;
                    case ServerType.LogonServer:
                        task2 = redisClient.SubscribeAsync(_PublisLS, SubscribeAsyncCallback);
                        break;
                    case ServerType.WebApiServer:
                        task2 = redisClient.SubscribeAsync(_PublisLS, SubscribeAsyncCallback);
                        break;
                }
                Task task3 = redisClient.SubscribeAsync(ServerUuidStr, SubscribeAsyncCallback);
                if (task2 == null)
                {
                    Task.WaitAll(task1, task3);
                }
                else
                {
                    Task.WaitAll(task1, task2, task3);
                }

                QLSystemErrorProvide.OnQLSystemLogHandle("Redis 服务已重新连接");
                ConnectInitCompleted?.Invoke(null, null);
            }
        }
        private static void SubscribeAsyncCallback(RedisChanelMessage obj)
        {
            if (obj.Type == ChanelMessageType.Success)
                _redisReceiveMessageQueue.Enqueue(obj);
        }
        private static void ProcessAnalysis()
        {
            //执行消息的拆装和反序列化
            try
            {

                TransferPacket data;
                while (Net.Analysis.PacketCodecHandlerInternal.ParsePacketInternal(ref netStream, out data, false))
                {
                    switch (data.Code)
                    {
                        case TransferPacketType.Binnary: break;
                        default: return;
                    }
                    var msg = (TransferMessage)data;

                    var m = msg.Result as RedisMessage;
                    if (m == null) continue;

                    m.wMainCmdID = msg.wMainCmdID;
                    m.wSubCmdID = msg.wSubCmdID;
                    OnRedisMessageComing(m);
                }
            }
            catch (Exception)
            {
            }
        }
        private static void OnRedisMessageComing(RedisMessage message)
        {
            message.IsFromRedis = true;
            RedisMessageComing?.Invoke(null, message);
        }

#if !WEB_API
        /// <summary>
        /// 游戏服务器配置
        /// </summary>
        public static ServerInfo CGServer
        {
            get
            {
                var config = SystemCommonConfig.Instance.PlatfromConfig;
                return new ServerInfo()
                {
                    Uuid = ServerUuid,
                    Adress = config.GServerIp,
                    Port = config.GsPort
                };
            }
        }
        /// <summary>
        /// 登陆服务器配置
        /// </summary>
        public static ServerInfo CLServer
        {
            get
            {
                var config = SystemCommonConfig.Instance.PlatfromConfig;
                return new ServerInfo()
                {
                    Uuid = ServerUuid,
                    Adress = config.GServerIp,
                    Port = config.LsPort
                };
            }
        } 
#endif

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serverUuid"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendDataToServer(Guid serverUuid, RedisMessage message)
        {
            if (message == null) return true;
            message.ServerUUID = ServerUuid; 
            if (serverUuid == ServerUuid)
            {
                if (message.IsFromRedis)
                    return false;
                OnRedisMessageComing(message);
                return true;
            } 
            redisClient.PublisMessage(serverUuid.ToString("n"), message.Serialize());
            return true;
        }
        /// <summary>
        /// 
        /// </summary> 
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendDataToAllServer(RedisMessage message)
        {
            if (message == null) return true;
            message.ServerUUID = ServerUuid;
            redisClient.PublisMessage(_PublisAll, message.Serialize());
            return true;
        }
        /// <summary>
        /// 
        /// </summary> 
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendDataToGameServer(RedisMessage message)
        {
            if (message == null) return true;
            message.ServerUUID = ServerUuid;
            redisClient.PublisMessage(_PublisGS, message.Serialize());
            return true;
        }
        /// <summary>
        /// 
        /// </summary> 
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool SendDataToLogonServer(RedisMessage message)
        {
            if (message == null) return true;
            message.ServerUUID = ServerUuid;
            redisClient.PublisMessage(_PublisLS, message.Serialize());
            return true;
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="message"></param>
        public static void SendMessageToUserServer(uint userId, RedisMessage message)
        {
            GetUserLsLoc(userId, loc =>
            {
                if (loc == null) return;
                SendDataToServer(loc.ServerUUID, message);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="message"></param>
        public static void SendMessageToUser(uint userId, CustomMessage message)
        {
            if (message == null) return;
            if (userId == 0)
            {
                SendDataToLogonServer(new ServerMessage.GS2LS.SendDataToPlayer()
                {
                    UserId = userId,
                    SendData = message.Serialize()
                });
                return;
            }
            GetUserLsLoc(userId, loc =>
            {
                if (loc == null) return;
                SendDataToServer(loc.ServerUUID, new ServerMessage.GS2LS.SendDataToPlayer()
                {
                    UserId = userId,
                    SendData = message.Serialize()
                });
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="loc"></param>
        /// <param name="call"></param>
        public static void SetUserLsLoc(uint UserId, UserLSLocation loc, Action<UserLSLocation> call)
        {
            var key = _UserLoc + UserId;
            redisClient.GetSetAsync(key, loc, 1 * 75 * 60, call);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param> 
        /// <param name="call"></param>
        public static void GetUserLsLoc(uint UserId, Action<UserLSLocation> call)
        {
            var key = _UserLoc + UserId;
            redisClient.KeyObjReadAsync(key, call);
        }
#if !WEB_API
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="loc"></param>
        /// <param name="call"></param>
        public static void SetUserOfflineLoc(uint UserId, R2GsInfo loc, Func<R2GsInfo, bool> call)
        {
            if (loc != null)
            {
                loc.SInfo = CGServer;
            }
            var key = _UserOfflineLoc + UserId;
            GetUserOfflineLoc(UserId, old =>
            {
                if (call != null && !call(old)) return;
                if (old == null && loc == null) return;

                redisClient.KeyObjSaveAsync(key, loc, 2 * 60 * 60);
            });
        }
#endif
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param> 
        /// <param name="call"></param>
        public static void GetUserOfflineLoc(uint UserId, Action<R2GsInfo> call)
        {
            var key = _UserOfflineLoc + UserId;
            redisClient.KeyObjReadAsync(key, call);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="RoomId"></param>
        public static void RemoveUserOfflineLoc(uint UserId, uint RoomId)
        {
            GetUserOfflineLoc(UserId, f =>
            {
                if (f == null) return;
                if (f.RoomId == RoomId)
                {
                    var key = _UserOfflineLoc + UserId;
                    redisClient.TryKeyDeleteAsync(key, f);
                }
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="func"></param>
        public static void RemoveUserloc(uint UserId, Func<UserLSLocation, bool> func = null)
        {
            GetUserLsLoc(UserId, loc =>
            {
                if (loc == null) return;
                if (func != null && !func(loc)) return;
                redisClient.TryKeyDeleteAsync(_UserLoc + UserId, loc);
            });
        }

        #region 玩家自建桌子的游戏

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cr"></param>
        /// <param name="isUpdate"></param>
        /// <returns></returns>
        public static bool CreateOrUpdateTableInfo(UserCRoomInfo cr, bool isUpdate = false)
        {
            var tableid = cr.TableId;
            var tkey = _TableInfo + tableid;
            //创建房间缓存最长65分钟
            var expire = 65 * 60;
            if (!isUpdate)
            {
                var putResult = redisClient.KeyObjSaveIfNotExists(tkey, cr, expire);
                if (!putResult) return false;
            }
            else
            {
                redisClient.KeyObjSaveAsync(tkey, cr, expire);
            }
            var strTableId = cr.TableId.ToString();
            if (cr.RoomOwner > 0)
                redisClient.HashSetAsync(_UserCreateTable + cr.RoomOwner, strTableId, DateTime.Now.GetTimestamp(), expire);
            if (cr.GroupId > 0)
                redisClient.HashSetAsync(_GroupCreateTable + cr.GroupId, strTableId, DateTime.Now.GetTimestamp(), expire);
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cr"></param>
        /// <param name="oldOwnerId"></param>
        public static void SetTableOwnerInfo(UserCRoomInfo cr, uint oldOwnerId)
        {
            CreateOrUpdateTableInfo(cr, true);
            var strTableId = cr.TableId.ToString();
            if (oldOwnerId > 0)
            {
                redisClient.HashDelete(_UserCreateTable + oldOwnerId, strTableId);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="cr"></param>
        public static void RemoveTableInfo(UserCRoomInfo cr)
        {
            if (cr == null) return;
            var tableid = cr.TableId;
            var tkey = _TableInfo + tableid;

            redisClient.KeyDelete(tkey);
            var strTableId = cr.TableId.ToString();

            if (cr.RoomOwner > 0)
            {
                NoticeUserCTableOver(cr.TableId, cr.RoomOwner, cr.GroupId);
                redisClient.HashDeleteAsync(_UserCreateTable + cr.RoomOwner, strTableId);
            }
            if (cr.GroupId > 0)
                redisClient.HashDeleteAsync(_GroupCreateTable + cr.GroupId, strTableId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isMaintain"></param>
        /// <param name="MaintainR"></param>
        public static void SetServerMaintain(bool isMaintain, string MaintainR)
        {
            SendDataToAllServer(new ServerMessage.BaseGeneral.ServerMaintain()
            {
                MaintainR = MaintainR,
                IsMaintain = isMaintain
            });
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="ownerId"></param>
        public static void RemoveTableInfoByUserId(uint tableId, uint ownerId = 0)
        {
            GetCreateTableInfo(tableId, cr =>
            {
                if (cr == null)
                {
                    if (ownerId > 0)
                    {
                        NoticeUserCTableOver(tableId, ownerId);
                        return;
                    }
                }
                else if (ownerId != 0 && cr.RoomOwner != ownerId)
                {
                    NoticeUserCTableOver(tableId, ownerId);
                    return;
                }
                RemoveTableInfo(cr);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="roomId"></param>
        public static void RemoveTableInfoByRoomId(uint tableId, uint roomId = 0)
        {
            GetCreateTableInfo(tableId, cr =>
            {
                if (cr == null) return;
                if (roomId != 0 && cr.RoomId != roomId) return;
                RemoveTableInfo(cr);
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="call"></param>
        public static void GetCreateTableInfo(uint tableId, Action<UserCRoomInfo> call)
        {
            if (call == null) return;

            var tkey = _TableInfo + tableId;
            redisClient.KeyObjReadAsync(tkey, call);
        }
        /// <summary>
        /// 获取玩家创建的房间列表
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="call"></param>
        public static void GetUserCreateTables(uint userId, Action<UserCRoomInfo[]> call)
        {
            if (call == null) return;

            redisClient.HashGetAllKeysAsync(_UserCreateTable + userId, keys =>
            {
                var allkeys = keys.Select(tableid => (HRedisKey)(_TableInfo + tableid)).ToArray();

                redisClient.KeyObjReadAsync<UserCRoomInfo>(allkeys, tary =>
                {
                    QLDictionary<string, UserCRoomInfo> t = new QLDictionary<string, UserCRoomInfo>();
                    foreach (var tableInfo in tary)
                    {
                        if (tableInfo == null) continue;
                        if (tableInfo.RoomOwner != userId) continue;

                        t[tableInfo.TableId + ""] = tableInfo;
                    }

                    //获取已经被删除的房间信息
                    var allOverTableId = keys.Where(key => t[key] == null).Select(p => (string)p).ToArray();
                    if (allOverTableId.Length > 0)
                        redisClient.HashDeleteAsync(_UserCreateTable + userId, allOverTableId);
                    call(t.Select(p => p.Value).ToArray());


                });
            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="tableId"></param>
        /// <param name="userId"></param>
        /// <param name="groupId"></param>
        public static void NoticeUserCTableOver(uint tableId, uint userId, uint groupId = 0)
        {
            SendMessageToUserServer(userId, new ServerMessage.GS2LS.UserCreateTableNotice()
            {
                Status = UserCreateTableNoticeStatus.TableGameOver,
                UserId = userId,
                TableInfo = new UserCreateTableInfo()
                {
                    GroupId = groupId,
                    RoomOwner = userId,
                    status = UserCreateTableNoticeStatus.TableGameOver,
                    TableId = tableId,
                }
            });

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="groupId"></param>
        /// <param name="call"></param>
        public static void GetGroupTableInfo(uint groupId, Action<UserCRoomInfo[]> call)
        {
            if (call == null) return;

            redisClient.HashGetAllKeysAsync(_GroupCreateTable + groupId, keys =>
            {
                var allkeys = keys.Select(tableid => (HRedisKey)(_TableInfo + tableid)).ToArray();

                redisClient.KeyObjReadAsync<UserCRoomInfo>(allkeys, tary =>
                {
                    QLDictionary<string, UserCRoomInfo> t = new QLDictionary<string, UserCRoomInfo>();
                    foreach (var tableInfo in tary)
                    {
                        if (tableInfo == null) continue;
                        if (tableInfo.GroupId != groupId) continue;

                        t[tableInfo.TableId + ""] = tableInfo;
                    }

                    //获取已经被删除的房间信息
                    var allOverTableId = keys.Where(key => t[key] == null).Select(p => (string)p).ToArray();
                    if (allOverTableId.Length > 0)
                        redisClient.HashDeleteAsync(_GroupCreateTable + groupId, allOverTableId);
                    call(t.Select(p => p.Value).ToArray());


                });
            });

        }
        #endregion

    }


}
