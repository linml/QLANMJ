using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahjongAlgorithmForMGMJ;
using M_MGMJ_GameMessage;
using GameIF;
using QL.Common;
using GameIF.Common;
namespace M_MGMJ
{
    /// <summary>
    /// 桌子
    /// </summary>
    public class GameServer : GameIF.GamePlugBaseClass
    {
        ///<summary>
        /// 玩家每杠一张牌 统计抓牌数量(正常摸牌)
        /// <summary>
        public byte gangNum = 0;
        ///<summary>
        /// 玩家每抓一张牌 统计抓牌数量(正常摸牌)
        /// <summary>
        public byte mopaiCount = 0;
        ///<summary>
        /// 胡牌人数(一炮多响 多人抢杠胡)
        /// </summary>>
        public int hu_number = 0;
        ///<summary>
        ///是否一炮两响
        /// <summary>
        public bool _yipaoliangxiang = false;
        ///<summary>
        ///是否一炮三响
        /// <summary>
        public bool _yipaosanxiang = false;
        /// 吃牌类型
        /// </summary>
        public byte _chiType;
        /// <summary>
        /// 当前操作玩家椅子号
        /// </summary>
        public byte _opPlayerChar;
        ///<summary>
        ///连庄数
        ///</summary>
        public byte lianzhuang = 0;
        /// <summary>
        /// 游戏是否已经开始
        /// </summary>
        public bool AlreadyStart = false;
        /// <summary>
        /// 检查可以投胡票的人数
        /// </summary>
        public byte CanHuNum = 0;
        /// <summary>
        /// 是否是流局
        /// </summary>
        public bool isliuju = false;
        ///<summary>
        ///判断是否能自摸
        ///</summary>
        public byte CanZiMo;
        ///<summary>
        ///设置杠总数
        ///</summary>
        public int liuju = 0;
        ///<summary>
        ///设置明杠总数
        ///</summary>
        public int MG = 0;
        ///<summary>
        ///设置暗杠总数
        ///</summary>
        public int AG = 0;
        /// <summary>
        /// 本局庄家椅子号 
        /// </summary>
        public byte _bankerChar;
        /// <summary>
        ///圈主ID
        /// </summary>
        public string quanZhuID;
        /// <summary>
        /// 本局是否有AI参与 
        /// </summary>
        public bool _isHaveAIPlayer;
        /// <summary>
        /// 当前阶段 
        /// </summary>
        public enGamePhase _gamePhase;
        ///<summary>
        ///统计玩家出牌数量 用于豹听
        /// </summary>
        private int[] outMj = new int[4];
        ///<summary>
        ///发牌结束后 玩家的听牌情况
        /// </summary>
        private bool[] tingMj = new bool[4];
        ///<summary>
        /// 是否有人离开
        /// </summary>
        private bool _someOneLeave;
        ///<summary>
        /// 上局庄
        /// </summary>
        private byte _lastBanker;
        ///<summary>
        /// 上局庄赢没赢
        /// </summary>
        private bool _lastBankerWin;
        ///<summary>
        /// 流局
        /// </summary>
        private bool _noOneWin;
        /// <summary>
        /// //客户端在线人数 
        /// </summary>
        public int _onlinePlayerCount;
        /// <summary>
        ///  //结束人数 
        /// </summary>
        public int _completeCount;
        /// <summary>
        ///  //是否出分  
        /// </summary>
        private bool _bOutScore;
        /// <summary>
        /// //是否控制
        /// </summary>
        private bool _bCtl;
        /// <summary>
        /// 是否游戏中
        /// </summary>
        private bool _isGameing;
        /// <summary>
        /// 是否保留桌子
        /// </summary>
        private bool _isSaveTable;
        private bool _isSavingTable;
        /// <summary>
        /// 桌子保留时间,分钟
        /// </summary>
        private int _saveTableTime;
        /// <summary>
        /// 保留桌子，预扣信息
        /// </summary>
        private uint _payId;
        private byte _hunPiCard;
        /// <summary>
        /// 打牌玩家信息
        /// </summary>
        public clsChairCardWrapper _outCardInfo = new clsChairCardWrapper();
        /// <summary>
        /// 抢杠信息
        /// </summary>
        public clsChairCardWrapper _qiangGangInfo = new clsChairCardWrapper();
        /// <summary>
        ///  //近几次的打牌记录 
        /// </summary>
        public List<byte> _outCardRecord = new List<byte>();
        ///// <summary>
        ///// 游戏流水
        ///// </summary>
        //public List<clsGameFlow> _gameFlow = new List<clsGameFlow>();
        /// <summary>
        /// 等待抢杠的玩家
        /// </summary>
        public List<ushort> _waitQiangGangPlayer = new List<ushort>();
        /// <summary>
        /// 强退次数
        /// </summary>
        public List<int> _gameForceLeftNum = new List<int>();
        /// <summary>
        /// 本局四个玩家ID
        /// </summary>
        public List<uint> _curGameUserID = new List<uint>();
        ///<summary>
        ///胡牌 杠牌次数
        ///<summary>
        public byte[][] huGangCount = new byte[4][];
        /// <summary>
        ///  牌包 
        /// </summary>
        public CCardPackage _cardPackage = new CCardPackage();
        /// <summary>
        /// 桌子规则配置
        /// </summary>
        public clsTableRule _tableConfig = new clsTableRule();
        /// <summary>
        /// //特殊属性 
        /// </summary>
        public clsSpecialAttri _specialAttri = new clsSpecialAttri();
        /// <summary>
        ///  //计牌器 
        /// </summary>
        public clsRememberCard _rememberCard = new clsRememberCard();
        /// <summary>
        ///  //玩家信数组
        /// </summary>
        public List<CPlayerInfo> _playerAry;
        /// <summary>
        /// 解散房间
        /// </summary>
        public clsDissTable _dissTable = new clsDissTable();
        /// <summary>
        /// 用于记录当前时间来判断解散房间超时
        /// </summary>
        public DateTime _RefuseDissTableTime { get; set; }
        /// <summary>
        /// 用于记录解散房间时剩余时间
        /// </summary>
        private DateTime _ApplyDissTableTime { get; set; }
        /// <summary>
        /// 用于同步玩家断线重连的计时器
        /// </summary>
        private DateTime _ORCTime { get; set; }
        /// <summary>
        /// 判断玩家是否断线重连开关
        /// </summary>
        private bool isORC = false;
        ///<summary>
        ///玩家是否豹听
        ///</summary>
        private bool[] _baoTing = new bool[4];
        /// <summary>
        /// 局号
        /// </summary>
        private string _gameID;

        #region 获取相对庄家各方位的椅子号

        /// <summary>
        /// 庄家椅子号
        /// </summary>
        public byte BankerChair
        {
            get { return _bankerChar; }
        }
        /// <summary>
        /// 庄家下家或是庄家右手边玩家的椅子号
        /// </summary>
        public byte BankerDownChair
        {
            get
            {
                return (byte)((_bankerChar + 1) % MGMJConstants.GAME_PLAYER);
            }
        }
        /// <summary>
        /// 庄家对家玩家的椅子号
        /// </summary>
        public byte BankerOppoChair
        {
            get
            {
                return (byte)((_bankerChar + 2) % MGMJConstants.GAME_PLAYER);
            }
        }
        /// <summary>
        /// 庄家上家或是左手边玩家的椅子号
        /// </summary>
        public byte BankerUpChair
        {
            get
            {
                return (byte)((_bankerChar + 3) % MGMJConstants.GAME_PLAYER);
            }
        }

        #endregion

        #region 属性

        /// <summary>
        /// 当前操作玩家
        /// </summary>
        public CPlayerInfo CurPlayer
        {
            get { return _playerAry[_opPlayerChar]; }
        }

        /// <summary>
        /// 剩余可游戏的玩家数:未胡牌的玩家数
        /// </summary>
        public int LeftGamePlayerNum
        {
            get
            {
                int playerNum = 0;

                foreach (var player in _playerAry)
                {
                    playerNum += (player.IsAlreadyHu ? 0 : 1);
                }

                return playerNum;
            }
        }

        /// <summary>
        /// 是否需要结束游戏
        /// </summary>
        public bool NeedOverGame
        {
            get
            {
                if (!_cardPackage.haveCard || _cardPackage.leftCardNum < 0 || LeftGamePlayerNum < 4)//
                {
                    isliuju = true;
                    return true;
                }
                return false;
            }
        }

        #endregion


        #region IGamePlug 成员

        /// <summary>
        /// 是否支持断线重连
        /// </summary>
        public override bool CanOffline { get { return true; } }

        /// <summary>
        /// 游戏宿主
        /// </summary>
        public override GameIF.IGameHost GameHost { get; set; }

        /// <summary>
        /// 游戏ID
        /// </summary>
        public override int GameID { get { return MGMJConstants.WHMJ_GAMEID; } }

        /// <summary>
        /// 游戏名称
        /// </summary>
        public override string GameName { get { return MGMJConstants.GAME_NAME; } }

        /// <summary>
        /// 游戏版本号
        /// </summary>
        public override string GameVersion { get { return MGMJConstants.GAME_VERSION; } }

        /// <summary>
        ///  摘要:
        ///  --------------------------------------------------------------------------------------------------------------------------
        ///  1、宿主通知游戏插件初始化，这个是游戏插件创建完毕并准备完毕后的初始化通知函数
        ///  2、当宿主调用该方法之后游戏插件即可调用宿主的接口处理相关逻辑，游戏插件请按照需要重写该方法
        ///  3、这个方法的调用时期是不同于 GameStart 方法的，游戏插件的开发者请务必不要在这个函数中处理与游戏开始相关的逻辑
        ///  --------------------------------------------------------------------------------------------------------------------------
        /// </summary>
        /// <returns></returns>
        public override int GameInitialize()
        {
            return 0;
        }

        #endregion

        #region gamevideo

        /// <summary>
        /// 录像json数据
        /// </summary>
        private JsonData _jsonData = null;
        /// <summary>
        /// 录像时间
        /// </summary>
        private int _videoTime = 0;

        #endregion

        /// <summary>
        /// 构造
        /// </summary>
        public GameServer()
        {
            _noOneWin = true;
            _someOneLeave = true;
            _isGameing = false;
            _isSavingTable = false;
            _lastBankerWin = false;
            _playerAry = new List<CPlayerInfo>();
            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                _playerAry.Add(new CPlayerInfo(this));
                this._gameForceLeftNum.Add(0);
                this._curGameUserID.Add(0);
            }
            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                _playerAry[i].LaNum = 0; _playerAry[i].PaoNum = 0;
            }
            _isSaveTable = false;
            _saveTableTime = 30;
        }

        /// <summary>
        /// 大厅解散房间通道
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="handle">此字段需与大厅约定，相当于switch条件，目前无用</param>
        /// <param name="param"></param>
        public override void OnHallMessage(uint UserId, string handle, string param)
        {
            if (UserId == this._tableConfig.TableCreatorID)
            {
                if (!_isGameing && this._tableConfig.GameNum < 1)
                {
                    if (_isSaveTable) //踢人退钱
                    {
                        //this.GameHost.HostSettlementService.WithHoldRoomCostBack(_payId, 3, p1 =>
                        //{
                        //    if (p1.IsSuccess)
                        //    {
                        //        GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_SaveTable);
                        //        this.UpdateClientPlayerMoney();
                        //        _isSaveTable = false;

                        //        //this.SaveTableForceAll();
                        //        this.TableOwnerDeleteTable();
                        //        GameHost.SetTableOwner(0);
                        //        this._tableConfig.clear();
                        //        _bankerChar = MahjongDef.gInvalidChar;

                        //    }
                        //});
                    }
                    else
                    {

                        //this.SaveTableForceAll();
                        this.TableOwnerDeleteTable();
                        GameHost.SetTableOwner(0);
                        this._tableConfig.clear();
                        _bankerChar = MahjongDef.gInvalidChar;
                    }
                }
            }
            
        }

        public override int OnBeforGetPlayerTableSeat(TablePlayer player, byte selectChairId, out string errorMsg)
        {
            GameHost.WriteMessage("_tableConfig.IfCanSameIp:" + _tableConfig.IfCanSameIp.ToString());

            if (_tableConfig.IfCanSameIp)
            {

                errorMsg = "";
                return 0;
            }

            foreach (var item in GameHost.PlayerInfoOnTable)
            {
                if (player.PlayerID != item.PlayerID)
                {
                    if (player.UserIP != item.UserIP)
                    {
                        continue;
                    }
                    errorMsg = "已经有此IP玩家,不能进入此游戏";
                    return 1;
                }

            }

            errorMsg = "";
            return 0;


        }

        /// <summary>
        /// 游戏开始
        /// </summary>
        /// <returns></returns>
        public override int GameStart()
        {
            GameHost.GameSceneStatus = 1;
            for(var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    this.huGangCount[i] = new byte[4];
                }
            }

            _dissTable.clear();
            CanHuNum = 0;
            if (_isSaveTable)
            {
                GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_SaveTable);
            }
            RealGameStart();
            return 0;
        }
        
        //内部游戏开始
        private void RealGameStart()
        {
            //复位桌子
            RepositTableFrameSink();

            this._jsonData = new JsonData();
            this._videoTime = 0;
            this.RecordContext();
            _isGameing = true;
            CanHuNum = 0;
            isliuju = false;
            //设置游戏状态
            //GameHost.GetTableInfo.bPlayStatus = WHMJConstants.GS_MJ_PLAY;

            //自动匹配
            if (!this._tableConfig.isValid)
            {
                this._tableConfig.createNewGUID(GameHost.HostRandomService.GetNewGuidString());
                _tableConfig.CellScore = (int)GameHost.GetRoomInfo.BaseMoney;
            }

            //检查是否新的开始
            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                if (this._curGameUserID[i] != this.GameHost.PlayerDataService.GetPlayerByChairID(i).UserID)
                {
                    this._tableConfig.createNewGUID(GameHost.HostRandomService.GetNewGuidString());
                    break;
                }
            }
            ////新一底开始
            this._tableConfig.newGameStart();


            //通知游戏开始
            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_Start()
            {
                gameNum = this._tableConfig.GameNum,
                totalGameNum = this._tableConfig.SetGameNum,
            });

            if (this._tableConfig.isValid && (1 == this._tableConfig.GameNum))// && (1 == _tableConfig.RealGameNum))
            {
                this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_NewGameRound(), false);
            }

            //发送桌子规则
            this.SendTableRule2Client(MahjongDef.gInvalidChar);

            if (this._tableConfig.isValid)
            {
                this.SendTableCreator2Client(MahjongDef.gInvalidChar);
            }

            //本局编号:场地id+桌子id+
            _gameID = GameHost.LogFileName.Substring(0, 13);// string.Format("{0}-{1}-{2}", GameHost.GetRoomInfo.ServerID, 0, Guid.NewGuid().ToString().Substring(0, 8));

            //洗牌
            _cardPackage.WashCard();
            if (_tableConfig.BuKaoJia)
            {
                delCard();
            }

            liuju = 0;
            GameHost.SaveLog("**************************游戏开始************************\n");
            GameHost.SaveLog("游戏初始化信息");

            //骰子信息
            SetSZInfo();
            _noOneWin = true;
            AddLogTitle("玩家信息");
            for (ushort i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                var player = GameHost.PlayerDataService.GetPlayerByChairID(i);
                this._curGameUserID[i] = 0;

                if (null != player)
                {
                    ++_onlinePlayerCount;
                    _isHaveAIPlayer = player.UserID < MGMJConstants.AIPlayerID ? true : _isHaveAIPlayer;

                    this._curGameUserID[i] = player.UserID;
                    //设置昵称
                    _playerAry[i].NickName = player.NickName;
                    //是否庄家
                    _playerAry[i].IsBanker = i == _bankerChar;

                    //玩家椅子号
                    _playerAry[i].PlayerChair = i;
                    //玩家ID
                    _playerAry[i].PlayerID = player.UserID;
                    //是否AI用户
                    _playerAry[i].IsAIPlayer = player.UserID < MGMJConstants.AIPlayerID;
                    //玩家断线状态
                    if ((null != GameHost.PlayerInfoOnTableSeat[i]) && (GameHost.PlayerInfoOnTableSeat[i].PlayerState == GState.OfflineInGame))
                    {
                        _playerAry[i].Status = enUserStatus.userStatus_offLine;
                    }
                    //打印日志
                    string PlayType = player.UserID < MGMJConstants.AIPlayerID ? "<AI>" : "<真人>";

                    GameHost.SaveLog(i.ToString() + "号位置玩家:" + player.NickName + PlayType);
                }
            }
            //游戏开始了，离开标记重置
            _someOneLeave = false;

            //加载游戏特殊属性
            LoadSpecialAttribute();

            //如果全是真人或全是AI就不做控制
            int temp = 0;
            foreach (var player in _playerAry)
            {
                temp += player.IsAIPlayer ? 0 : 1;
            }
            _bCtl = (0 == (temp % MGMJConstants.GAME_PLAYER) ? false : true);
            if (this._bOutScore)
            {
                _bCtl = false;
            }
            //确定本局策略
            SetPolicy();

            //发送游戏编号
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_GameID()
            {
                gameid = _gameID
            });
            //清理玩家分数
            playerScoreChange(MahjongDef.gInvalidChar);

            if (_tableConfig.LaPaoZuo)
            {
                // 记录游戏阶段
                _gamePhase = enGamePhase.GamePhase_Pao;
                // 通知客户端开始跑点
                this.HandlePao();
            }
            else
            {
                //初始化玩家牌
                InitPlayerCard();
                //记录游戏阶段
                _gamePhase = enGamePhase.GamePhase_SendCard;

                //注册一个计时器
                foreach (var player in _playerAry)
                {
                    player.IfCanOp = true;
                    player.WaitSeconds = 0;
                }

                //通知客户端开始发牌
                SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_StartSendCard());
                //发牌超时计时
                //startOutTimer();
                GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_OutTime, 100, () =>
                {
                    playerOutTime();
                });
                //注册AI动作计时器
                GameHost.HostTimerService.RegTimerHandle(CommonDef.TimerID_AIOP, 1, () =>
                {
                    this.HandleTimeMessage(CommonDef.TimerID_AIOP);
                });
                //通知断线玩家
                for (int m = 0; m < MGMJConstants.GAME_PLAYER; m++)
                {
                    if (_playerAry[m].IsOffline)
                    {
                        //通知其他玩家有人断线了
                        this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerOffline()
                        {
                            chair = (byte)m
                        });
                    }
                }
                AddLogTitle("等待玩家抓牌结束");

            }

        }

        /// <summary>
        /// 复位桌子
        /// </summary>
        private void RepositTableFrameSink()
        {
            if (_someOneLeave)
            {
                _bankerChar = MahjongDef.gInvalidChar;
                //_someOneLeave = false;
            }
            _isHaveAIPlayer = false;
            _bOutScore = false;
            _bCtl = false;
            //_lastBanker = MahjongDef.gInvalidChar;
            _opPlayerChar = MahjongDef.gInvalidChar;
            _gamePhase = enGamePhase.GamePhase_Unknown;

            _onlinePlayerCount = 0;
            _completeCount = 0;

            _outCardInfo.Clear();
            _outCardRecord.Clear();
            //_gameFlow.Clear();
            _specialAttri.Clear();
            _rememberCard.Clear();
            _qiangGangInfo.Clear();
            _waitQiangGangPlayer.Clear();
            _gameID = "";
            for (short i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                _playerAry[i].Clear();
                //每局强退重置
                _gameForceLeftNum[i] = 0;
                
            }

        }

        /// <summary>
        /// 记录上下文
        /// </summary>
        private void RecordContext()
        {
            //记录场地数据
            _jsonData = new JsonData();
            this._jsonData.room.ID = this.GameHost.GetRoomInfo.ID;
            this._jsonData.room.GameID = this.GameHost.GetRoomInfo.GameID;
            //  this._jsonData.room.AgentID = this.GameHost.GetRoomInfo.AgentID;
            this._jsonData.room.RoomType = (int)this.GameHost.GetRoomInfo.RoomType;
            //  this._jsonData.room.GameType = (int)this.GameHost.GetRoomInfo.GameType;
            this._jsonData.room.BaseMoney = this.GameHost.GetRoomInfo.BaseMoney;
            this._jsonData.room.JoinMultiNum = this.GameHost.GetRoomInfo.JoinMultiNum;
            this._jsonData.room.MaxCount = this.GameHost.GetRoomInfo.MaxCount;
            this._jsonData.room.RoomLV = this.GameHost.GetRoomInfo.RoomLV;
            this._jsonData.room.CheckMoneyType = (int)this.GameHost.GetRoomInfo.CheckMoneyType;
            //  this._jsonData.room.DisplayOrder = this.GameHost.GetRoomInfo.DisplayOrder;
            this._jsonData.room.TableCost = this.GameHost.GetRoomInfo.TableCost;
            this._jsonData.room.Name = this.GameHost.GetRoomInfo.Name;
            this._jsonData.room.TableCostMoneyType = (int)this.GameHost.GetRoomInfo.TableCostMoneyType;

            //记录桌子玩家数据
            for (ushort i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                var player = GameHost.PlayerDataService.GetPlayerByChairID(i);
                PlayerData playerData = new PlayerData();

                if (null != player)
                {
                    playerData.PlayerID = player.UserID;
                    playerData.NickName = player.NickName;
                    playerData.FaceID = player.Header;
                    playerData.PlayerLV = player.LV;
                    playerData.VIPLV = player.VipLV;
                    playerData.GoldNum = 0;
                    playerData.GoldCardNum = player.MoneyBag.QiDouNum;
                    playerData.DiamondsNum = player.MoneyBag.DiamondNum;
                    playerData.Gender = player.Gender;
                }
                else
                {
                    playerData.PlayerID = 0;
                }

                this._jsonData.tableplayer.Add(playerData);
            }

        }

        /// <summary>
        /// 108张牌 去除 东南西北 中发白
        /// </summary>
        private void delCard()
        {
            _cardPackage.m_cPackage.Remove(0x31);
            _cardPackage.m_cPackage.Remove(0x31);
            _cardPackage.m_cPackage.Remove(0x31);
            _cardPackage.m_cPackage.Remove(0x31);

            _cardPackage.m_cPackage.Remove(0x32);
            _cardPackage.m_cPackage.Remove(0x32);
            _cardPackage.m_cPackage.Remove(0x32);
            _cardPackage.m_cPackage.Remove(0x32);

            _cardPackage.m_cPackage.Remove(0x33);
            _cardPackage.m_cPackage.Remove(0x33);
            _cardPackage.m_cPackage.Remove(0x33);
            _cardPackage.m_cPackage.Remove(0x33);

            _cardPackage.m_cPackage.Remove(0x34);
            _cardPackage.m_cPackage.Remove(0x34);
            _cardPackage.m_cPackage.Remove(0x34);
            _cardPackage.m_cPackage.Remove(0x34);

            _cardPackage.m_cPackage.Remove(0x35);
            _cardPackage.m_cPackage.Remove(0x35);
            _cardPackage.m_cPackage.Remove(0x35);
            _cardPackage.m_cPackage.Remove(0x35);

            _cardPackage.m_cPackage.Remove(0x36);
            _cardPackage.m_cPackage.Remove(0x36);
            _cardPackage.m_cPackage.Remove(0x36);
            _cardPackage.m_cPackage.Remove(0x36);

            _cardPackage.m_cPackage.Remove(0x37);
            _cardPackage.m_cPackage.Remove(0x37);
            _cardPackage.m_cPackage.Remove(0x37);
            _cardPackage.m_cPackage.Remove(0x37);

        }



        /// <summary>
        /// 游戏维护处理，主要是房费返回
        /// </summary>
        public override int OnServerMaintain(int status, string MaintainText)
        {
            if (status == 1 && _isSaveTable && GameHost.GameSceneStatus != 1)
            {
                _isSaveTable = false;
            }
            return 0;
        }

        /// <summary>
        /// 桌子发生异常
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public override bool OnTableError(Exception ex)
        {
            _isSaveTable = false;
            _isGameing = false;
            _tableConfig.clear();
            GameHost.SetTableOwner(0);
            return true;
        }

        /// <summary>
        /// 分析指令，进行相应的处理
        /// </summary>
        /// <param name="chairID"></param>
        /// <param name="cm"></param>
        /// <returns></returns>
        public override int ReceiveMsg(ushort chairID, GameMessage cm)
        {
            //首先判断主命令码，如果是128就是麻将的，然后在看副命令码

            this.GameHost.WriteMessage("霍邱麻将消息:" + cm.wMainCmdID.ToString() + " | " + cm.wSubCmdID.ToString());

            if (cm.wMainCmdID == MGMJConstants.WHMJ_GAMEID)
            {
                switch (cm.wSubCmdID)
                {
                    //抓牌结束
                    case MGMJMsgID_c2s.CMD_C_HoldCardComplete:
                        {
                            HandleMsg_CMD_C_HoldCardComplete(chairID);
                            break;
                        }
                    //玩家打出牌
                    case MGMJMsgID_c2s.CMD_C_OutCard:
                        {
                            CMD_C_OutCard pOutCard = cm as CMD_C_OutCard;
                            HandleMsg_CMD_C_OutCard(chairID, pOutCard.outCard);
                            break;
                        }
                    //玩家杠
                    case MGMJMsgID_c2s.CMD_C_Gang:
                        {
                            CMD_C_Gang pGang = cm as CMD_C_Gang;
                            HandleMsg_CMD_C_Gang(chairID, pGang.gangCard);
                            break;
                        }
                    //玩家吃
                    case MGMJMsgID_c2s.CMD_C_Chi:
                        {
                            CMD_C_Chi pChi = cm as CMD_C_Chi;
                            HandleMsg_CMD_C_Chi(chairID, pChi.chiCard, pChi.chiType);
                            break;
                        }
                    //玩家自摸
                    case MGMJMsgID_c2s.CMD_C_ZiMo:
                        {
                            HandleMsg_CMD_C_ZiMo(chairID);
                            break;
                        }
                    //玩家投票
                    case MGMJMsgID_c2s.CMD_C_Vote:
                        {
                            CMD_C_Vote pVote = cm as CMD_C_Vote;
                            HandleMsg_CMD_C_Vote(chairID, pVote.voteResult);
                            break;
                        }
                    //玩家抢杠
                    case MGMJMsgID_c2s.CMD_C_QiangGang:
                        {
                            CMD_C_QiangGang qiangGang = cm as CMD_C_QiangGang;
                            HandleMsg_CMD_C_QiangGang(chairID, qiangGang.qiangGang);
                            break;
                        }
                    //请求强退
                    case MGMJMsgID_c2s.CMD_C_ForceLeft:
                        {
                            CMD_C_ForceLeft forceLeft = cm as CMD_C_ForceLeft;
                            this.HandleMsg_CMD_C_ForceLeft(chairID, forceLeft.PlayerID);
                            break;
                        }
                    //创建桌子
                    case MGMJMsgID_c2s.CMD_C_CreateTable:
                        {
                            this.HandleMsg_CMD_C_CreateTable(chairID, cm as CMD_C_CreateTable);
                            break;
                        }
                    //向好友求助
                    case MGMJMsgID_c2s.CMD_C_FriendHelp:
                        {
                            this.HandleMsg_CMD_C_FriendHelp(chairID, cm as CMD_C_FriendHelp);
                            break;
                        }
                    //拒绝帮助好友
                    case MGMJMsgID_c2s.CMD_C_RejectHelp:
                        {
                            this.HandleMsg_CMD_C_RejectHelp(chairID, cm as CMD_C_RejectHelp);
                            break;
                        }
                    //确认帮助好友
                    case MGMJMsgID_c2s.CMD_C_HelpFriend:
                        {
                            this.HandleMsg_CMD_C_HelpFriend(chairID, cm as CMD_C_HelpFriend);
                            break;
                        }
                    //查询记录
                    case MGMJMsgID_c2s.CMD_C_QueryGameRecord:
                        {
                            this.HandleMsg_CMD_C_QueryGameRecord(chairID, cm as CMD_C_QueryGameRecord);
                            break;
                        }
                    //玩家请求解散房间
                    case MGMJMsgID_c2s.CMD_C_OfferDissTable:
                        {
                            this.HandleMsg_CMD_C_OfferDissTable(chairID, cm as CMD_C_OfferDissTable);
                            break;
                        }
                    //玩家对解散房间进行投票
                    case MGMJMsgID_c2s.CMD_C_VoteDissTable:
                        {
                            this.HandleMsg_CMD_C_VoteDissTable(chairID, cm as CMD_C_VoteDissTable);
                            break;
                        }
                    //玩家准备下一局
                    case MGMJMsgID_c2s.CMD_C_NextGame:
                        {
                            this.HandleMsg_CMD_C_NextGame(chairID, cm as CMD_C_NextGame);
                            break;
                        }
                    //玩家准备下一局
                    case MGMJMsgID_c2s.CMD_C_ReSetScene:
                        {
                            this.HandleMsg_CMD_C_ReSetScene(chairID);
                            break;
                        }
                    //测试客户端保留桌子
                    case MGMJMsgID_c2s.CMD_C_SaveTable:
                        {
                            this.HandleMsg_CMD_C_SaveTable(chairID);
                            break;
                        }
                    case MGMJMsgID_c2s.CMD_C_Pao:
                        {
                            CMD_C_Pao pao = cm as CMD_C_Pao;
                            this.HandleMsg_CMD_C_Pao(chairID, pao.point);
                            break;
                        }
                    case MGMJMsgID_c2s.CMD_C_La:
                        {
                            CMD_C_La la = cm as CMD_C_La;
                            this.HandleMsg_CMD_C_La(chairID, la.point);
                            break;
                        }
                    case MGMJMsgID_c2s.CMD_C_BaoTing:
                        {
                            CMD_C_BaoTing bao = cm as CMD_C_BaoTing;
                            this.HandleMsg_CMD_C_BaoTing(chairID, bao.point);
                            break;
                        }
                    case MGMJMsgID_c2s.CMD_C_GiveUpBaoTing:
                        {
                            CMD_C_GiveUpBaoTing giveUpbao = cm as CMD_C_GiveUpBaoTing;
                            this.HandleMsg_CMD_C_GiveUpBaoTing(chairID, giveUpbao.point);
                            break;
                        }
                }
            }
            return 0;
        }

        /// <summary>
        /// 玩家进入
        /// </summary>
        /// <param name="chairID"></param>
        /// <param name="userInfo"></param>
        /// <param name="userState"></param>
        /// <returns></returns>
        public override int OnUserComeIn(ushort chairID, QL.Common.TablePlayer userInfo, byte userState)
        {


            this.SendGameMsg(chairID, new CMD_S_Version()
            {
                Version = MGMJConstants.GAME_VERSION,
            });
            //朋友圈游戏,创建桌子场
            if (GameHost.GetRoomInfo.RoomType == RoomType.MomentsGame)
            {
                if (null == this.GameHost.TableOnwer || this._tableConfig.isValid)
                {
                    //如果桌子规则有效,将规则发给客户端玩家
                    if (this._tableConfig.isValid)
                    {
                        if (userInfo.PlayerID == _tableConfig.TableCreatorID)
                        {
                            _tableConfig.TableCreatorChair = chairID;
                            this.SendTableCreator2Client(MahjongDef.gInvalidChar);

                            this.GameHost.WriteMessage(userInfo.NickName + "(" + userInfo.PlayerID + ")进入,此时桌子规则有效,无需创建桌子规则");

                            //发送规则
                            this.SendTableRule2Client(chairID);
                            //发送房主
                            this.SendTableCreator2Client(chairID);
                            //发送玩家余额
                            this.UpdateClientPlayerMoney();
                        }
                        else
                        {
                            if (_tableConfig.TableCreatorPay  > 1 && userInfo.DiamondsNum < _tableConfig.TableCost && _tableConfig.GameNum == 0)
                                NoMoneyForce(chairID);
                            else
                            {
                                this.GameHost.WriteMessage(userInfo.NickName + "(" + userInfo.PlayerID + ")进入,此时桌子规则有效,无需创建桌子规则");

                                //发送规则
                                this.SendTableRule2Client(chairID);
                                //发送房主
                                this.SendTableCreator2Client(chairID);
                                //发送玩家余额
                                this.UpdateClientPlayerMoney();
                            }
                        }
                    }

                    //通知玩家开始创建桌子
                    if (!this._tableConfig.isValid) // && (this.GameHost.TableOnwer.PlayerID == userInfo.PlayerID))
                    {
                        //新桌子创建,清空所有强退计数器
                        for (int i = 0; i < _gameForceLeftNum.Count; i++)
                        {
                            _gameForceLeftNum[i] = 0;
                        }

                        //1、自创房间，房卡档次（具体有几档看游戏设计，例：4档，4局，8局，16局， 4-1:8-2:16-3）
                        string[] str = GameHost.GetRoomInfo.SpareAttrib.Attribute1.Split(',');
                        byte temp = 0;

                        for (int i = 0; i < str.Length; i++)
                        {
                            if (string.IsNullOrEmpty(str[i]))
                            {
                                continue;
                            }
                            string[] oneStr = str[i].Split('_');


                            if (oneStr.Length == _specialAttri.JuShu.Length)
                            {
                                for (int k = 0; k < oneStr.Length - 1; k++)
                                {
                                    string[] str2 = oneStr[k].Split('|');
                                    if (str2.Length == 3)
                                    {
                                        if (byte.TryParse(str2[0], out temp))
                                        {
                                            _specialAttri.JuShu[k] = temp;
                                        }
                                        if (byte.TryParse(str2[1], out temp))
                                        {
                                            _specialAttri.PayKa[k] = temp;//AA制房卡
                                        }
                                        if (byte.TryParse(str2[2], out temp))
                                        {
                                            _specialAttri.PayKa[k + _specialAttri.JuShu.Length] = temp;//房主一人付房卡
                                        }
                                    }
                                }
                            }

                            if (!byte.TryParse(oneStr[oneStr.Length - 1], out temp))
                            {
                                temp = _specialAttri.JuShu[0];
                            }
                            //通知客户端开始创建房间
                        }
                            this.SendGameMsg(chairID, new CMD_S_StartCreateTable()
                            {
                                payKa = _specialAttri.PayKa,
                                juShu = _specialAttri.JuShu,
                                defaultJuShu = temp,
                                Version = MGMJConstants.GAME_VERSION

                            });
                    }
                }
            }
            else
            {
                //发送规则,自由匹配也要发，为了出发自动准备。
                this.SendTableRule2Client(chairID);
            }
            //设置此位置玩家是否强退中为:false
            _playerAry[chairID].isForceLefting = false;
            //如果此位置坐下的是之前的离开的玩家,强退计数器不变,否则,即换人了,强退计数器清空
            _gameForceLeftNum[chairID] = userInfo.PlayerID == this._curGameUserID[chairID] ? _gameForceLeftNum[chairID] : 0;

            //玩家断线重连进入
            if (1 == userState)
            {
                PrintLog("\n\n*********************玩家断线重连***********************\n\n");
                PrintLog(chairID.ToString() + "号玩家断线重连进入");

                GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_WaitDissTable);

                //设置玩家为有效状态
                _playerAry[chairID].Status = enUserStatus.userStatus_normal;

                //通知其他玩家有人断线重连了
                this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerOfflineCome()
                {
                    chair = (byte)chairID
                });

                //处理玩家断线后的逻辑
                HandlerPlayerOfflineCome((byte)chairID);
            }
            else
            {
                _someOneLeave = true;
            }
            return 1;
        }

        /// <summary>
        /// 玩家离开
        /// </summary>
        /// <param name="chairID"></param>
        /// <param name="userInfo"></param>
        /// <param name="userState">0正常离开，1强退; 对于不支持断线重连的游戏插件，该值永远是0</param>
        /// <returns></returns>
        public override int OnUserLeft(ushort chairID, QL.Common.TablePlayer userInfo, byte userState)
        {
            //如果桌子上已经没有玩家了,清理规则配置
            var playerInfoOnTable = this.GameHost.PlayerInfoOnTable;
            if ((null == playerInfoOnTable) || (0 == playerInfoOnTable.Length))
            {
                //销毁游戏定时器

                GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_WaitDissTable);

                for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                {
                    _gameForceLeftNum[i] = 0;
                    _curGameUserID[i] = 0;
                }
                //保留房间
                if (!_isSaveTable)
                {
                    this._tableConfig.clear();
                    _bankerChar = MahjongDef.gInvalidChar;
                    GameHost.SetTableOwner(0);
                }
                else
                {
                    //GameHost.SetTableOwner(_tableConfig.TableCreatorID);
                    _tableConfig.TableCreatorChair = MahjongDef.gInvalidChar;
                }
            }
            else
            {
                //如果离开的这位就是房主,就需要换房主了
                if (_tableConfig.isValid && (_tableConfig.TableCreatorID == userInfo.PlayerID))
                {
                    if (_tableConfig.isCreateed)
                    {
                        //房主买单模式
                        if (0 == userState)//正常离开,通知其他玩家,房主离开
                        {
                            //需要新的消息体，来传递保不保存房间标记
                            if (_isSaveTable)
                            {
                                _tableConfig.TableCreatorChair = MahjongDef.gInvalidChar;
                            }
                            else
                            {
                                if (_tableConfig.TableCreatorChair != MahjongDef.gInvalidChar)
                                {

                                    this.TableOwnerExitAndForceAll();
                                    GameHost.SetTableOwner(0);
                                }
                            }
                        }
                    }
                    else
                    {
                        this.TableOwnerExitAndForceAll();
                    }
                }
            }

            if (1 == userState)//玩家强退
            {
                PrintLog("\n\n*********************玩家断线***********************\n\n");
                PrintLog(chairID.ToString() + "号玩家断线");

                _playerAry[chairID].Status = enUserStatus.userStatus_offLine;

                //通知其他玩家有人断线了
                this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerOffline()
                {
                    chair = (byte)chairID
                });
                if (_tableConfig.GameNum > 0)
                {
                    //如果所有玩家都断线了
                    bool haveNormalPlayer = false;
                    foreach (var player in _playerAry)
                    {
                        if (enUserStatus.userStatus_normal == player.Status)
                        {
                            haveNormalPlayer = true;
                        }
                    }
                    //所有玩家都断线,5分钟后自动解散该房间
                    if (this._tableConfig.isValid && !haveNormalPlayer)
                    {
                        //int temp = _specialAttri.OffLineOutTime > 0 ? _specialAttri.OffLineOutTime : 30;
                        ////30分钟后断线玩家自动同意
                        //GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitDissTable, temp * 60 * 10, () =>
                        //{
                        //    this.OnEventGameEnd(MahjongDef.gInvalidChar, true);
                        //    //foreach (var player in GameHost.PlayerInfoOnTable)
                        //    //{
                        //    //    GameHost.PlayerDataService.PostUserExitMessage(player);
                        //    //}
                        //});
                    }
                }
                //处理玩家断线后的逻辑
                HandlerPlayerOffline((byte)chairID);
            }

            return 1;
        }

        #region 客户端消息处理

        #region 开始跑
        /// <summary> 处理跑点 </summary>
        private void HandlePao()
        {
            AddLogTitle("进入跑阶段,通知玩家开始跑");

            // 设置当前游戏阶段
            _gamePhase = enGamePhase.GamePhase_Pao;
            _completeCount = 0;

            // 进入跑点阶段
            Random randObj = MahjongGeneralAlgorithm.GetRandomObject();
            foreach (var player in _playerAry)
            {
                player.IfCanOp = true;
                player.WaitSeconds = player.IsAIPlayer ? randObj.Next(1, 7) : MahjongDef.gTrueManWaitSecond;
                // AI默认不跑点
                if (player.IsAIPlayer)
                {
                    int random = randObj.Next(0, 99);
                    if (random < 40)
                        player.PaoNum = 0;
                    else if (random < 80)
                    {
                        player.PaoNum = 1;
                    }
                    else
                    {
                        player.PaoNum = 2;
                    }
                }
            }
            bool aaa = _tableConfig.LaPaoZuo;

            // 通知玩家开始跑点
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_StartPao()
            {
                pao = aaa,

            });
            startOutTimer();
        }

        private void HandleMsg_CMD_C_Pao(ushort chair, byte point)
        {
            // 触发消息的玩家不可操作 或 游戏阶段不是跑点阶段，则不进行处理
            if (!_playerAry[chair].IfCanOp || (_gamePhase != enGamePhase.GamePhase_Pao))
            {
                return;
            }
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            if (point < 0 || point > 2)
            {
                _playerAry[chair].PaoNum = 0;
            }
            else
            {
                _playerAry[chair].PaoNum = point;
            }

            this.SendGameMsg(chair, new CMD_S_SelfPao()
            {
                point = point
            });

            PrintLog(chair.ToString() + "号玩家跑点:" + point + ",已经结束人数:" + (_completeCount + 1));

            if (++_completeCount == MGMJConstants.GAME_PLAYER)
            {
                /* Added for 操作超时处理 below */
                closeOutTimer();
                /* Added for 操作超时处理 above */
                PrintLog("所有玩家跑点结束,亮出所有跑点数");
                List<byte> playerRunPoint = new List<byte>();
                foreach (var player in _playerAry)
                {
                    playerRunPoint.Add((byte)player.PaoNum);

                    // 将玩家最新手牌数据发给玩家
                    // this.SendGameMsg(player.PlayerChair, new CMD_S_HandCardData()
                    //{
                    //    handCardData = player.PlayerCard.activeCard.handCard.ToArray()
                    //});
                }
                SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerPaoInfo()
                {
                    points = playerRunPoint.ToArray()
                });

                _completeCount = 0;
                //初始化玩家牌
                InitPlayerCard();
                //记录游戏阶段
                _gamePhase = enGamePhase.GamePhase_SendCard;

                //注册一个计时器
                foreach (var player in _playerAry)
                {
                    player.IfCanOp = true;
                    player.WaitSeconds = 4;
                }

                //通知客户端开始发牌
                SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_StartSendCard());
                //发牌超时计时
                //startOutTimer();
                GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_OutTime, 100, () =>
                {
                    playerOutTime();
                });
                //注册AI动作计时器
                GameHost.HostTimerService.RegTimerHandle(CommonDef.TimerID_AIOP, 1, () =>
                {
                    this.HandleTimeMessage(CommonDef.TimerID_AIOP);
                });
                //通知断线玩家
                for (int m = 0; m < MGMJConstants.GAME_PLAYER; m++)
                {
                    if (_playerAry[m].IsOffline)
                    {
                        //通知其他玩家有人断线了
                        this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerOffline()
                        {
                            chair = (byte)m
                        });
                    }
                }
                AddLogTitle("等待玩家抓牌结束");

            }
        }
        #endregion

        #region 开始拉
        /// <summary> 处理跑点 </summary>
        private void HandleLa()
        {
            AddLogTitle("进入拉阶段,通知玩家开始拉");

            // 设置当前游戏阶段
            _gamePhase = enGamePhase.GamePhase_La;
            _completeCount = 0;

            // 进入拉阶段
            Random randObj = MahjongGeneralAlgorithm.GetRandomObject();
            foreach (var player in _playerAry)
            {
                player.IfCanOp = true;
                player.WaitSeconds = player.IsAIPlayer ? randObj.Next(1, 7) : MahjongDef.gTrueManWaitSecond;
                // AI默认不跑点
                if (player.IsAIPlayer)
                {
                    int random = randObj.Next(0, 99);
                    if (random < 40)
                        player.LaNum = 0;
                    else if (random < 80)
                    {
                        player.LaNum = 1;
                    }
                    else
                    {
                        player.LaNum = 2;
                    }
                }
            }

            // 通知玩家开始跑点
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_StartLa());
            startOutTimer();
        }
        /// <summary>
        /// 玩家选择 豹听
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="point"></param>
        private void HandleMsg_CMD_C_BaoTing(ushort chair, byte point)
        {
            tingMj[chair] = false;
            _baoTing[chair] = true;
            _playerAry[chair]._isBaoTing = true;
            SendCardToPlayer();

            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerBao()
            {
                chair = (byte)chair,
            });
        }  
        /// <summary>
        /// 玩家选择 放弃豹听
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="point"></param>
        private void HandleMsg_CMD_C_GiveUpBaoTing(ushort chair, byte point)
        {
            _playerAry[chair]._isBaoTing = false;
            if (tingMj[chair])
            {
                tingMj[chair] = false;
                SendCardToPlayer();
            }
        }

        private void HandleMsg_CMD_C_La(ushort chair, byte point)
        {
            // 触发消息的玩家不可操作 或 游戏阶段不是跑点阶段，则不进行处理
            if (!_playerAry[chair].IfCanOp || (_gamePhase != enGamePhase.GamePhase_La))
            {
                return;
            }
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            if (point < 0 || point > 2)
            {
                _playerAry[chair].LaNum = 0;
            }
            else
            {
                _playerAry[chair].LaNum = point;
            }

            this.SendGameMsg(chair, new CMD_S_SelfLa()
            {
                point = point
            });

            PrintLog(chair.ToString() + "号玩家跑点:" + point + ",已经结束人数:" + (_completeCount + 1));

            if (++_completeCount == MGMJConstants.GAME_PLAYER)
            {
                /* Added for 操作超时处理 below */
                closeOutTimer();
                /* Added for 操作超时处理 above */
                PrintLog("所有玩家拉结束,亮出所有拉数");
                List<byte> playerRunPoint = new List<byte>();
                foreach (var player in _playerAry)
                {
                    playerRunPoint.Add((byte)player.LaNum);
                }
                SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerLaInfo()
                {
                    points = playerRunPoint.ToArray()
                });
                playerRunPoint.Clear();
                foreach (var player in _playerAry)
                {
                    playerRunPoint.Add((byte)player.PaoNum);
                }
                SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerPaoInfo()
                {
                    points = playerRunPoint.ToArray()
                });
                
                //// 重置完成标志
                _completeCount = 0;
                //初始化玩家牌
                InitPlayerCard();
                //记录游戏阶段
                _gamePhase = enGamePhase.GamePhase_SendCard;

                //注册一个计时器
                foreach (var player in _playerAry)
                {
                    player.IfCanOp = true;
                    player.WaitSeconds = 4;
                }

                //通知客户端开始发牌
                SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_StartSendCard());
                //发牌超时计时
                //startOutTimer();
                GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_OutTime, 100, () =>
                {
                    playerOutTime();
                });
                //注册AI动作计时器
                GameHost.HostTimerService.RegTimerHandle(CommonDef.TimerID_AIOP, 1, () =>
                {
                    this.HandleTimeMessage(CommonDef.TimerID_AIOP);
                });
                //通知断线玩家
                for (int m = 0; m < MGMJConstants.GAME_PLAYER; m++)
                {
                    if (_playerAry[m].IsOffline)
                    {
                        //通知其他玩家有人断线了
                        this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerOffline()
                        {
                            chair = (byte)m
                        });
                    }
                }
                AddLogTitle("等待玩家抓牌结束");
            }
        }
        #endregion

        #region 保留桌子
        private void HandleMsg_CMD_C_SaveTable(ushort chair)
        {

            //取房间保留时间
            int temp = 0;
            string s = GameHost.HostSystemConfigManger["Table_Time"];
            if (int.TryParse(s, out temp))
            {
                if (temp > 0)
                    _saveTableTime = temp;
            }
            if (!_isSavingTable && !_isSaveTable)//
            {
                _isSavingTable = true;
            }

        }
        #endregion

        #region 场景重置
        /// <summary>
        /// 场景重置
        /// </summary>
        /// <param name="chair"></param>
        private void HandleMsg_CMD_C_ReSetScene(ushort chair)
        {
            if (_isGameing)
                HandlerPlayerOfflineCome((byte)chair);
        }
        #endregion

        /// <summary>
        /// 玩家准备
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="dissTableVote"></param>
        private void HandleMsg_CMD_C_NextGame(ushort chair, CMD_C_NextGame readyUser)
        {
            UpdateClientPlayerMoney();

            if (!this._isGameing && _playerAry[chair].IfCanOp)
            {
                _playerAry[chair].IfCanOp = false;
                _playerAry[chair].IsReady = true;
                CMD_S_UseReady alaredy = new CMD_S_UseReady();
                alaredy.chair = (byte)chair;
                if (++_completeCount >= MGMJConstants.GAME_PLAYER)//如果所有玩家可以投票
                {
                    AddLogTitle("开始游戏");
                    RealGameStart();
                }
                else
                {
                    this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_UseReady() { chair = alaredy.chair }, false);
                }
            }
        }
        #region 玩家准备检查
        /// <summary>
        /// 玩家准备检查
        /// </summary>
        private void HandlePlayerReady()
        {
            AddLogTitle("开始检查玩家准备");

            _completeCount = 0;

            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                if (_playerAry[i].IsReady)
                {
                    ++_completeCount;
                }
            }

            if (_completeCount == MGMJConstants.GAME_PLAYER)//如果所有玩家可以投票
            {
                AddLogTitle("开始游戏");
                GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_Ready);
                _completeCount = 0;
                RealGameStart();
            }

        }

        #endregion

        #region 抓牌结束处理

        /// <summary>
        /// 发牌结束:开始发牌打牌
        /// </summary>
        /// <param name="wCharID"></param>
        private void HandleMsg_CMD_C_HoldCardComplete(ushort chair)
        {
            CMD_S_Ting ting = new CMD_S_Ting();
            if (!_playerAry[chair].IfCanOp || (_gamePhase != enGamePhase.GamePhase_SendCard))
            {
                return;
            }
            PrintLog(chair.ToString() + "号玩家抓牌结束,已经结束人数:" + (_completeCount + 1));
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            if (++_completeCount == MGMJConstants.GAME_PLAYER)
            {
                //关闭超时计时
                closeOutTimer();
                foreach (var player in _playerAry)
                {
                    //做一次听牌检查
                    if (player.TingCheck())
                    {
                        ting.TingNum = chair;
                        SendGameMsg(MahjongDef.gInvalidChar, ting);
                    }

                    //将玩家最新手牌数据发给玩家
                    this.SendGameMsg(player.PlayerChair, new CMD_S_HandCardData()
                    {
                        handCardData = player.PlayerCard.activeCard.handCard.ToArray()
                    });
                }
                AlreadyStart = true;
                PrintLog("所有人都已经抓牌结束,进入发牌打牌阶段");
                _opPlayerChar = _bankerChar;
                _completeCount = 0;
                SendCardToPlayer();
            }
        }
        #endregion


        #region 玩家打出牌

        /// <summary>
        /// 玩家打出牌
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void HandleMsg_CMD_C_OutCard(ushort chair, byte card)
        {
            if (!_playerAry[chair].IfCanOp || (_opPlayerChar != chair) || (_gamePhase != enGamePhase.GamePhase_PlayerOP) || !_playerAry[chair].CheckIfCanOutACard(card))
            {
                return;
            }

            PrintLog(chair.ToString() + "号玩家打出:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)]);
            //关闭玩家操作超时
            closeOutTimer();
            //设置玩家不可操作
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            //通知客户端玩家打出一张牌
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerOutCard()
            {
                chair = (byte)chair,
                card = card
            });

            //玩家出牌的数量
            outMj[chair]++;

            //记录本次打牌信息
            PrintLog("打牌前玩家活动牌");
            PrintPlayerHandCard((byte)chair);

            _playerAry[chair].HandleByAfterOutCard(card);

            //记录当前打牌玩家信息
            _outCardInfo.chair = chair;
            _outCardInfo.card = card;

            PrintLog("打牌后玩家活动牌");
            PrintPlayerHandCard((byte)chair);

            //做一次听牌检查
            if (_playerAry[chair].PlayerCard.tingCard.Count > 0)
            {
                CMD_S_Ting ting = new CMD_S_Ting();
                _playerAry[chair].IsTing = true;
                PrintLog("打完牌之后玩家听的牌:");
                PrintCardList(_playerAry[chair].PlayerCard.tingCard);
                ting.TingNum = chair;
                SendGameMsg(MahjongDef.gInvalidChar, ting);
            }

            this._gamePhase = enGamePhase.GamePhase_Unknown;
            this.HandleTimeMessage(CommonDef.TimerID_WaitVote);
        
        }

        /// <summary>
        /// 处理玩家能否投票
        /// </summary>
        private void HandlePlayerVote()
        {
            AddLogTitle("开始检查玩家投票权限");

            _completeCount = 0;
            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                _playerAry[i].IfCanOp = false;
                _playerAry[i].ClearVote();

                if (_playerAry[i].IsAlreadyHu || (i == _outCardInfo.chair))
                {
                    continue;
                }
                if (_playerAry[i].CheckIfCanVote(_outCardInfo.card, enHuCardType.HuCardType_PingHu, _outCardInfo.chair, _tableConfig.canChi == 0, _baoTing[i],_tableConfig.DianPao==1))
                {
                    _playerAry[i].IfCanOp = true;
                    ++_completeCount;

                    if (_playerAry[i].IsAIPlayer)//如果是AI
                    {
                        PrintLog(i.ToString() + "号AI玩家可以进行投票");
                        _playerAry[i].CheckAIVoteResult(_outCardInfo.card, (byte)_outCardInfo.chair, (byte)i);

                        if (MahjongDef.gVoteResult_Null == _playerAry[i].VoteResult)
                        {
                            _playerAry[i].VoteResult = MahjongDef.gVoteResult_GiveUp;
                        }

                        //根据投票结果来确定AI思考时间
                        switch (_playerAry[i].VoteResult)
                        {
                            //投票吃
                            case MahjongDef.gVoteResult_Chi:
                                {
                                    _playerAry[i].WaitSeconds = rand.Next(1, 2);
                                    break;
                                }
                            //投票碰
                            case MahjongDef.gVoteResult_Peng:
                                {
                                    _playerAry[i].WaitSeconds = rand.Next(1, 2);
                                    break;
                                }
                            //投票杠
                            case MahjongDef.gVoteResult_Gang:
                                {
                                    _playerAry[i].WaitSeconds = rand.Next(1, 2);
                                    break;
                                }
                            //投票胡
                            case MahjongDef.gVoteResult_Hu:
                                {
                                    _playerAry[i].WaitSeconds = rand.Next(1, 2);
                                    break;
                                }
                            //投票弃
                            case MahjongDef.gVoteResult_GiveUp:
                                {
                                    _playerAry[i].WaitSeconds = rand.Next(1, 2);
                                    break;
                                }
                        }
                    }
                    else
                    {
                        PrintLog(i.ToString() + "号真人玩家可以进行投票");
                        _playerAry[i].WaitSeconds = MahjongDef.gTrueManWaitSecond;
                        //  _playerAry[i].WaitSeconds = rand.Next(1, 2);
                        if (_playerAry[i].Status == enUserStatus.userStatus_normal)
                        {
                            this.SendGameMsg(i, new CMD_S_VoteRight()
                            {
                                voteCard = _outCardInfo.card,
                                voteRight = _playerAry[i].VoteRight,

                            });
                        }
                    }
                }
            }


            if (_completeCount > 0)//如果有玩家可以投票
            {
                //投票超时计时
                startOutTimer();
                AddLogTitle("进入投票阶段");
                _gamePhase = enGamePhase.GamePhase_Vote;
            }
            else
            {
                AddLogTitle("没有玩家可以投票的，进入下个抓牌打牌循环");
                //没有玩家投票，再将打出的这张牌，放入打牌玩家牌池
                _playerAry[_outCardInfo.chair].PlayerCard.poolCard.Add(_outCardInfo.card);
                _rememberCard.OutCard(_outCardInfo.card);
                //添加打牌记录
                _outCardRecord.Add(_outCardInfo.card);

                //取下一个操作玩家椅子号
                GetNextOpPlayer((byte)_outCardInfo.chair);
                PrintLog("本次轮到" + _opPlayerChar.ToString() + "号玩家操作");
                //给当前玩家发牌
                SendCardToPlayer();
            }
        }
        #endregion

        #region 玩家杠处理

        /// <summary>
        /// 处理玩家吃牌
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void HandleMsg_CMD_C_Chi(ushort chair, byte card, byte chiType)
        {
            //if (!_playerAry[chair].IfCanOp || (_opPlayerChar != chair) || (_gamePhase != enGamePhase.GamePhase_PlayerOP))
            //{
            //    return;
            //}
            //List<byte> chiCard = new List<byte>();
            //if (!_playerAry[chair].FindChiCard(chiCard) || !chiCard.Contains(card))
            //{
            //    return;
            //}
            //杠操作
            //closeOutTimer();
            //设置玩家不可操作
            //_playerAry[chair].IfCanOp = false;
            //_playerAry[chair].IfOutOp = false;
            //liuju++;
            //this.PlayerChi(chair, card, chiType);
            _chiType = chiType;

        }

        /// <summary>
        /// 处理玩家杠牌
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void HandleMsg_CMD_C_Gang(ushort chair, byte card)
        {
            if (!_playerAry[chair].IfCanOp || (_opPlayerChar != chair) || (_gamePhase != enGamePhase.GamePhase_PlayerOP))
            {
                return;
            }
            List<byte> gangCard = new List<byte>();
            if (!_playerAry[chair].FindGangCard(gangCard) || !gangCard.Contains(card))
            {
                return;
            }
            //统计玩家暗杠次数
            this.huGangCount[chair][3]++;

            //杠操作
            closeOutTimer();
            //设置玩家不可操作
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            //1、确定杠类型
            enGangType gangType = _playerAry[chair].CheckGangType(card);
            liuju++;
            switch (gangType)
            {
                case enGangType.AnGang:
                    {
                        _playerAry[chair].PlayerScore.AnGang++;
                        this.HandlePlayerAnGang(chair, card);
                        break;
                    }
                case enGangType.BuGang:
                    {
                        //不管有没有被抢，补杠都算
                        _playerAry[chair].PlayerScore.BuGang++;
                        if (!this.CheckQiangGang(chair, card))
                        {
                            this.HandlePlayerBuGang(chair, card);
                        }
                        break;
                    }
                default:
                    {
                        //通知当前操作的玩家
                        InformCustomOpPlayer((byte)chair);
                        break;
                    }
            }
        }

        /// <summary>
        /// 处理玩家暗杠
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void HandlePlayerAnGang(ushort chair, byte card)
        {
            PrintLog(chair.ToString() + "号玩家暗杠:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)]);
            _playerAry[chair].HandleByAfterAGang(card);
            _rememberCard.GangCard(card);
            _playerAry[chair].DianGangPlayer = (byte)chair;

            clsSingleGangRecord gangRecord = new clsSingleGangRecord();
            gangRecord.GangType = enGangType.AnGang;

            clsGameFlow gameFlow = new clsGameFlow()
            {
                PlayerChair = chair,
                PlayerID = _playerAry[chair].PlayerID,
                FlowType = enGameFlowType.GameFlow_AnGang
            };

            if (_playerAry[chair].PlayerCard.tingCard.Count > 0)
            {
                PrintLog("暗杠后玩家听的牌:");
                PrintCardList(_playerAry[chair].PlayerCard.tingCard);
            }

            //通知客户端有玩家暗杠牌了
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerAnGangCard()
            {
                chair = (byte)chair,
                card = card
            });
            _opPlayerChar = (byte)chair;

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行投票处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                //杠牌玩家继续抓牌打牌
                SendCardToPlayer(false);
            });
            //杠牌玩家继续抓牌打牌
            //SendCardToPlayer();
        }

        /// <summary>
        /// 检查抢杠
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        private bool CheckQiangGang(ushort chair, byte card)
        {
            _waitQiangGangPlayer.Clear();
            _qiangGangInfo.Clear();

            foreach (var player in _playerAry)
            {
                player.IsVoteQiangGang = false;

                if (player.IsAlreadyHu || (player.PlayerChair == chair))
                {
                    continue;
                }

                if (player.CheckQiangGang(card, enHuCardType.HuCardType_QiangGangHu))
                {
                    _waitQiangGangPlayer.Add(player.PlayerChair);
                    PrintLog(player.PlayerChair + "号玩家可以抢杠");
                    break;
                }
            }

            if (_waitQiangGangPlayer.Count > 0 && _tableConfig.QiangGangHu == 1)//有抢杠玩家,进入抢杠阶段
            {
                _gamePhase = enGamePhase.GamePhase_QiangGang;
                _completeCount = 0;
                _qiangGangInfo.chair = chair;
                _qiangGangInfo.card = card;

                Random rand = MahjongGeneralAlgorithm.GetRandomObject();

                //通知玩家抢杠
                foreach (var playerChair in _waitQiangGangPlayer)
                {
                    _playerAry[playerChair].IfCanOp = true;
                    _playerAry[playerChair].WaitSeconds = _playerAry[playerChair].IsAIPlayer ? rand.Next(1, 3) : MahjongDef.gTrueManWaitSecond;
                    SendGameMsg((int)playerChair, new CMD_S_QiangGang()
                    {
                        chair = (byte)chair,
                        card = card
                    });
                }
                //抢杠超时计时
                startOutTimer();
                return true;
            }
            return false;
        }

        /// <summary>
        /// 处理玩家补杠
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void HandlePlayerBuGang(ushort chair, byte card)
        {
            PrintLog(chair.ToString() + "号玩家补杠:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)]);
            _playerAry[chair].HandleByAfterBGang(card);
            _rememberCard.GangCard(card);

            //统计玩家明杠次数
            this.huGangCount[chair][2]++;

            _playerAry[chair].DianGangPlayer = (byte)chair;
            if (_playerAry[chair].fangpeng1 != null && _playerAry[chair].fangpeng1.Contains(card))
            {
                _playerAry[chair].fanggang1++;
            }
            else if (_playerAry[chair].fangpeng2 != null && _playerAry[chair].fangpeng2.Contains(card))
            {
                _playerAry[chair].fanggang2++;
            }
            else if (_playerAry[chair].fangpeng3 != null && _playerAry[chair].fangpeng3.Contains(card))
            {
                _playerAry[chair].fanggang3++;
            }
            else if (_playerAry[chair].fangpeng4 != null && _playerAry[chair].fangpeng4.Contains(card))
            {
                _playerAry[chair].fanggang4++;
            }

            if (_playerAry[chair].PlayerCard.tingCard.Count > 0)
            {
                PrintLog("补杠后玩家听的牌:");
                PrintCardList(_playerAry[chair].PlayerCard.tingCard);
            }

            clsSingleGangRecord gangRecord = new clsSingleGangRecord();
            gangRecord.GangType = enGangType.BuGang;

            clsGameFlow gameFlow = new clsGameFlow()
            {
                PlayerChair = chair,
                PlayerID = _playerAry[chair].PlayerID,
                FlowType = enGameFlowType.GameFlow_BuGang
            };
            //通知客户端有玩家补杠牌了
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerBuGangCard()
            {
                chair = (byte)chair,
                card = card
            });
           
            _opPlayerChar = (byte)chair;

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行投票处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                //杠牌玩家继续抓牌打牌
                SendCardToPlayer(false);
            });
            //杠牌玩家继续抓牌打牌
            //SendCardToPlayer();
        }
        #endregion


        #region 玩家自摸处理

        /// <summary>
        /// 处理玩家自摸
        /// </summary>
        /// <param name="chair"></param>
        private void HandleMsg_CMD_C_ZiMo(ushort chair)
        {
            if (!_playerAry[chair].IfCanOp || (_opPlayerChar != chair) || (_gamePhase != enGamePhase.GamePhase_PlayerOP) || !_playerAry[chair].CheckIfCanHuACard(_playerAry[chair].HoldCard))
            {
                return;
            }
            String _vecHuType = "";
            _lastBankerWin = _playerAry[chair].IsBanker;
            //统计自摸次数
            this.huGangCount[chair][0]++;

            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            //GameHost.WriteMessage("zimo1");
            //自摸操作
            closeOutTimer();
            byte cbHuCard = CurPlayer.HoldCard; //抓到的牌
            int[] multiple = CurPlayer.HandleByHu((byte)chair, cbHuCard, CurPlayer.IsJustGang ? enHuCardType.HuCardType_GangShangHua : enHuCardType.HuCardType_ZiMo, _playerAry[chair].PlayerCard.activeCard.handCard,outMj[chair]);
            //GameHost.WriteMessage("总：" + multiple);
            _noOneWin = false;
            //加番
            //int tempjia = 2;
            //if (_baoTing[chair])
            //{
            //    tempjia *= 2;
            //}
          
            //if (CurPlayer.IsJustGang)
            //{
            //    tempjia *= 2;
            //}

            int anGangs = 0;
            int mingGangs = 0;
            int buGangs = 0;
            if (_tableConfig.gangFen == 1)
            {
                if (_playerAry[chair].PlayerCard.fixedCard.fixedCard.Count > 0)
                {
                    for (int j = 0; j < _playerAry[chair].PlayerCard.fixedCard.fixedCard.Count; j++)
                    {
                        if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_AGang)
                            anGangs++;
                        if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_BGang)
                            buGangs++;
                        if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_MGang) {
                            mingGangs++;
                            
                        }
                    }
                }

                //计算杠分
                if (anGangs != 0)
                {
                    multiple[0] += anGangs * 2;
                    _playerAry[chair].VecType += " 暗杠+" + anGangs * 2;
                }
                if (buGangs != 0)
                {
                   multiple[0] += buGangs;
                    _playerAry[chair].VecType += " 补杠+" + buGangs; 
                }
                if (mingGangs != 0)
                {
                    //multiple[0] += mingGangs * 3;
                    _playerAry[chair].VecType += " 明杠+" + mingGangs * 3;
                }
            }

            //庄分 + 1 
            if (_bankerChar == chair)
            {
                multiple[0] += 1;
                _playerAry[chair].VecType += " 庄+1" ;
                _lastBanker = _bankerChar;
            }

            //检测独一
            if (_playerAry[chair].CheckHuIsSingleOne(_playerAry[chair].HoldCard)) {
                multiple[0] += 2;
                _playerAry[chair].VecType += " 独一+1";
            }
           
            //if (_tableConfig.zhanZhuang == 1)
            //{
            //    multiple[0] += (lianzhuang - 1);
            //    _playerAry[chair].VecType += " 庄分+ " + (lianzhuang - 1);
            //}
            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                if ((i != chair) && !_playerAry[i].IsAlreadyHu)
                {
                    int tempCount = 0;
                    if (mingGangs>0) {
                        for (int j = 0; j < _playerAry[chair].PlayerCard.fixedCard.fixedCard.Count; j++) {
                            if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_MGang &&
                                _playerAry[chair].PlayerCard.fixedCard.fixedCard[j].outChair == i)
                                tempCount += 3;
                        }
                    }
                    _playerAry[i].PlayerScore.huScore -= multiple[0] * _tableConfig.CellScore + tempCount;
                    _playerAry[chair].PlayerScore.huScore += multiple[0]* _tableConfig.CellScore + tempCount;
                }
            }        

            //GameHost.WriteMessage("总：" + multiple);
            PrintLog(_opPlayerChar.ToString() + "号玩家自摸:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(cbHuCard)]);

            //发送自摸玩家
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHuCard()
            {
                chair = (byte)chair,
                card = cbHuCard,
                huType = (byte)(enHuCardType.HuCardType_ZiMo),
                huScore = null,
                vecHuType = _vecHuType
            });
            //设置轮庄
            //_bankerChar = (byte)chair;
            if (_tableConfig.zhanZhuang==0)
                 _bankerChar = (byte)((_bankerChar + 1) % MGMJConstants.GAME_PLAYER);
            //SendPlayerCard2Client(chair, MahjongDef.gInvalidChar);

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行结算处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                this.OnEventGameEnd(MahjongDef.gInvalidChar);
            });
        }

        //游戏结束
        private void OnEventGameEnd(ushort wChairID, bool forceEnd = false, bool isDismissRoom = false)
        {
            AddLogTitle("游戏结束");
            AlreadyStart = false;
            if (_isSaveTable)//保留房间房费已扣
            {
                _isSaveTable = false;
            }
            hu_number = 0;
            mopaiCount = 0;
            gangNum = 0;
            _yipaoliangxiang = false;
            _yipaosanxiang = false;
            //清空outMj数组 _baoting数组
            for (int i = 0; i < outMj.Length; i++)
            {
                outMj[i] = 0;
                _baoTing[i] = false;
                _playerAry[i]._isBaoTing = false;
            }

            //销毁游戏定时器
            GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_AIOP);
            //状态设置
            _gamePhase = enGamePhase.GamePhase_Unknown;

            this._isGameing = false;

            //if (_lastBanker != _bankerChar)
            //{
            //    lianzhuang = 0;
            //}

            int[] anGangs = new int[4];
            int[] mingGangs = new int[4];
            int[] buGangs = new int[4];
            int[] dianGangs = new int[4];

            //1、将所有未胡牌的玩家牌阵亮出 清空 准备状态
            foreach (var player in _playerAry)
            {
                player.IfCanOp = false;
                player.IsReady = false;
                SendPlayerCard2Client((byte)player.PlayerChair, MahjongDef.gInvalidChar);
            }

            #region 发送本局结算结果

            //2、发送结算数据
            List<PlayerCard> playerCard = new List<PlayerCard>();
            foreach (var player in _playerAry)
            {
                List<SingleFixedCard> fixedCards = new List<SingleFixedCard>();
                foreach (var single in player.PlayerCard.fixedCard.fixedCard)
                {
                    fixedCards.Add(new SingleFixedCard()
                    {
                        tokenCard = single.card,
                        type = (byte)single.fixedType,
                        pos = 0,
                        chiType = single.chiSel
                    });
                }
                //player.PlayerCard.activeCard.handCard.Sort();
                playerCard.Add(new PlayerCard()
                {
                    huCard = MahjongDef.gInvalidMahjongValue != player.HoldCard ? player.HoldCard : player.HuCard,
                    handCard = player.PlayerCard.activeCard.handCard.ToArray(),
                    fixedCard = fixedCards.ToArray()
                });
            }
            List<PlayerBalance> playerBalance = new List<PlayerBalance>();
            foreach (var player in _playerAry)
            {
                if (player.JieSuan.Count != 11)
                {
                    player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0);
                    player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0); 
                    player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0);
                }
                player.JieSuan[0] = (byte)(player.IsBanker ? 1 : 0);

                playerBalance.Add(new PlayerBalance()
                {
                    HuType = (int)player.HuCardType,
                    FangPao = player.IsFangPao ? 1 : 0,
                    TotalScore = player.TotalGameScore,
                    JieSuan = player.JieSuan.ToArray(),// player.HuCardType == enHuCardType.HuCardType_Null ? new List<byte>().ToArray() : player.JieSuan.ToArray()
                    vecType = player.VecType
                });
                if (player.TotalGameScore != 0)
                    _noOneWin = false;

            }
            //if (_noOneWin)
            //{
            //    lianzhuang++;//黄庄 连庄加1
            //}
            this.SaveMsg(MahjongDef.gInvalidChar, new CMD_S_Balance()
            {
                playerCard = playerCard.ToArray(),
                playerBalance = playerBalance.ToArray(),
                isPlayEnougnGameNum = (byte)(forceEnd ? 1 : this._tableConfig.isPlayEnoughGameNum ? 1 : 0)
            });

            #endregion

            #region 记分板记录

            //如果是记分场
            if (this._tableConfig.isValid)
            {
                var record = new clsGameUserRecord();
                record.BankerChair = _lastBanker;
                foreach (var player in _playerAry)
                {
                    record.addUserRecord(player.TotalGameScore);
                }
                if (!isDismissRoom)
                    this._tableConfig.PlayerGameRecord.Add(record);
                
            }
           
            #endregion

            #region 录像和结算结果
            SaveRecordData gameRecordData = new SaveRecordData();
            gameRecordData.GameGroupName = this._tableConfig.GameGUID;
            gameRecordData.GameNo = GameHost.HostRandomService.GetNewGuidString();
            if (null != this._jsonData)
            {
                gameRecordData.RecrdData = this._jsonData;
            }
            if (this._tableConfig.isValid)
            {
                if (_tableConfig.IsRecordScoreRoom)
                {
                    gameRecordData.MarkContext = "自主建房记分场录像";
                    gameRecordData.Type = GameRecordType.CreateScoreRoom;
                }
                else
                {
                    gameRecordData.MarkContext = "自主建房金币场录像";
                    gameRecordData.Type = GameRecordType.CreateGlodRoom;
                }
            }
            else
            {
                gameRecordData.MarkContext = "自动匹配金币场录像";
                gameRecordData.Type = GameRecordType.AutoMatch;
            }
            gameRecordData.RoomOwner = this._tableConfig.TableCreatorID;

            List<UserRecordData> userRecordData = new List<UserRecordData>();
            foreach (var player in _playerAry)
            {
                userRecordData.Add(new UserRecordData()
                {
                    NickName = player.NickName,
                    MoneyNum = player.TotalGameScore,
                    UserID = player.PlayerID,
                    MoneyType = GameHost.GetRoomInfo.CheckMoneyType
                });
                //this.PrintLog(player.NickName + " 输赢: " + player.TotalGameScore.ToString());
            }
            gameRecordData.RecordDataArray = userRecordData.ToArray();

            List<UserAuditData> userAuditData = new List<UserAuditData>();
            foreach (var player in _playerAry)
            {
                userAuditData.Add(new UserAuditData()
                {
                    MoneyNum = _tableConfig.IsRecordScoreRoom ? 0 : player.TotalGameScore,
                    UserID = player.PlayerID
                });
            }

            //自建房间中的记分场才建录像
            if (this._tableConfig.isValid)
            {
                uint payRoomCostUserID = 0;
                uint roomCost = 0;
                if (1 == this._tableConfig.GameNum && !forceEnd)// && _tableConfig.RealGameNum == 1)//
                {
                    //payRoomCostUserID = _tableConfig.TableCreatorPay ? this._tableConfig.TableCreatorID : 0;
                    roomCost = (uint)(this._tableConfig.TableCost);
                }
                //计分场
                if (_tableConfig.IsRecordScoreRoom)
                {
                    //保存录像文件
                    this.GameHost.HostGameReplayHelperServices.SaveRecord(gameRecordData, p =>
                    {
                        if (null == p)
                        {
                            throw new Exception("保存录像返回结果为null");
                        }
                        else
                        {
                            if (isDismissRoom || forceEnd || this._tableConfig.isPlayEnoughGameNum)
                            {//桌费
                                int cost = 0;
                                cost = _tableConfig.GameNum;
                                var balance = new PlayerForFeeDataMultiple()
                                {
                                    FeeDataType = ForFeeDataType.多人游戏结算,
                                    FeeUserCount = userAuditData.Count,
                                    Mark = "霍邱麻将记分场结算",
                                    MoneyType = GameHost.GetRoomInfo.CheckMoneyType,
                                    NoCheckUserMoney = 1,
                                    //1AA 2房主 3圈住
                                    RoomCostPayType = (RoomCostPayType)_tableConfig.TableCreatorPay,

                                    //当前局数
                                    GameNum = _tableConfig.GameNum,
                                    //桌费 根据局数计算
                                    RoomCost = (uint)cost,

                                    RoomCostType = this.GameHost.GetRoomInfo.TableCostMoneyType,
                                    RoomID = GameHost.GetRoomInfo.ID,
                                    UserAuditDataArray = userAuditData.ToArray()
                                };
                                this.GameHost.HostSettlementService.PlayerForFeeMultiple(balance, p1 =>
                                {
                                    this.GameHost.WriteMessage("结算成功");

                                });
                            }
        
                            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_Balance()
                            {
                                playerCard = playerCard.ToArray(),
                                playerBalance = playerBalance.ToArray(),
                                isPlayEnougnGameNum = (byte)(forceEnd ? 1 : this._tableConfig.isPlayEnoughGameNum ? 1 : 0),
                                liuju = isliuju
                            });
                            //如果有人一底输光，强推，计分板，然后在下一底开始时清空记录
                            if (!this._tableConfig.isPlayEnoughGameNum)
                                //发送玩家余额
                                this.UpdateClientPlayerMoney();
                            //打满局数,游戏结束
                            if (forceEnd || this._tableConfig.isPlayEnoughGameNum)
                            {
                                this.GameHost.WriteMessage("** 霍邱麻将,记分场，游戏结束 **");
                                //通知平台游戏结束
                                GameEnd();
                            }
                        }
                    });
                }
                
            }
            else
            {
                //自动匹配要加桌费
                this.GameHost.HostGameReplayHelperServices.SaveRecord(gameRecordData, p =>
                {
                    if (null == p)
                    {
                        throw new Exception("保存录像返回结果为null");
                    }
                    else
                    {
                        var balance = new PlayerForFeeDataMultiple()
                        {
                            FeeDataType = ForFeeDataType.多人游戏结算,
                            FeeUserCount = userAuditData.Count,
                            Mark = "颖上麻将结算",
                            MoneyType = this.GameHost.GetRoomInfo.CheckMoneyType,
                            NoCheckUserMoney = 1,
                            //PayRoomCostUserID = 0,
                            RoomCost = this.GameHost.GetRoomInfo.TableCost,
                            RoomCostType = this.GameHost.GetRoomInfo.TableCostMoneyType,
                            RoomID = GameHost.GetRoomInfo.ID,
                            UserAuditDataArray = userAuditData.ToArray()
                        };
                        GameHost.HostSettlementService.PlayerForFeeMultiple(balance, p1 =>
                        {
                            
                            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_Balance()
                            {
                                playerCard = playerCard.ToArray(),
                                playerBalance = playerBalance.ToArray(),
                                isPlayEnougnGameNum = (byte)(forceEnd ? 1 : this._tableConfig.isPlayEnoughGameNum ? 1 : 0)
                            });
                            //发送玩家余额
                            this.UpdateClientPlayerMoney();
                            //通知平台游戏结束
                            GameEnd();
                        });
                    }
                });
            }

            #endregion

            this._jsonData = null;

            #region 换房主检查

           
            _completeCount = 0;
            #endregion

            //自建房间,局数未打完,断线玩家自动准备
            if (this._tableConfig.isValid && !this._tableConfig.isPlayEnoughGameNum && !forceEnd)
            {
                for (ushort i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                {
                    _playerAry[i].IfCanOp = true;
                    if (_playerAry[i].IsOffline)
                    {
                        this.HandleMsg_CMD_C_NextGame(i, new CMD_C_NextGame());
                    }
                }
            }

            AddLogTitle("**********************游戏结束**********************");
        }

        /// <summary>
        /// 调用gamehost.gameend, 
        /// </summary>
        private void GameEnd()
        {
            if (_tableConfig.isValid)
            {
                sendGameRecord();
                _tableConfig.TableCreatorChair = MahjongDef.gInvalidChar;
            }
            if (GameHost.GameSceneStatus == 1)
                GameHost.GameEnd();
            GameHost.SetTableOwner(0);
            _tableConfig.GameNum = 0;

        }

        #endregion

        #region 玩家投票处理

        /// <summary>
        /// 玩家投票处理
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="voteResult"></param>
        private void HandleMsg_CMD_C_Vote(ushort chair, byte voteResult)
        {
            if (!_playerAry[chair].IfCanOp || (_gamePhase != enGamePhase.GamePhase_Vote) || (MahjongDef.gVoteRightMask_Null == _playerAry[chair].VoteRight))
            {
                return;
            }

            --_completeCount;
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            _playerAry[chair].VoteResult = voteResult;

            //弃胡检查
            if ((MahjongDef.gVoteResult_GiveUp == voteResult) && MahjongGeneralAlgorithm.CheckVoteRight_Hu(_playerAry[chair].VoteRight) && _playerAry[chair].CheckIfCanHuACard(_outCardInfo.card))
            {
                _playerAry[chair].checkGiveUpHu(_outCardInfo.card, enHuCardType.HuCardType_PingHu);
                CanHuNum = 0;
            }

            //弃碰检查
            if ((MahjongDef.gVoteResult_GiveUp == voteResult) && MahjongGeneralAlgorithm.CheckVoteRight_Peng(_playerAry[chair].VoteRight))
            {
                _playerAry[chair].checkGiveUpPeng(_outCardInfo.card);
            }
            if (voteResult == MahjongDef.gVoteResult_Hu && CanHuNum == 1)
            {
                for (int i = 1; i < MGMJConstants.GAME_PLAYER; i++) //不带一炮多响，从出牌者的下家开始找起
                {
                    int temp = (i + _outCardInfo.chair) % MGMJConstants.GAME_PLAYER;
                    if (MahjongDef.gVoteResult_Hu == _playerAry[temp].VoteResult)
                    {
                        //   huPlayer.Add(_playerAry[temp].PlayerChair);
                        this.PlayerHuCard(_playerAry[temp].PlayerChair, _outCardInfo.card, _playerAry[temp].PlayerCard.activeCard.handCard,outMj[temp]);
                        break;
                    }
                }
                this._gamePhase = enGamePhase.GamePhase_Unknown;

                //8个时间周期后进行投票处理
                GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
                {
                    if (NeedOverGame)
                    {

                        this.OnEventGameEnd(MahjongDef.gInvalidChar);
                    }

                });
                return;
            }
            else if ((voteResult == MahjongDef.gVoteResult_Gang || voteResult == MahjongDef.gVoteResult_Peng) && CanHuNum == 0)//可碰杠 有吃 没有胡
            {
                foreach (var player in _playerAry)
                {
                    if (MahjongDef.gVoteResult_Gang == player.VoteResult)
                    {
                        _playerAry[_outCardInfo.chair].IsJustGang = false;
                        this.PlayerVoteGang(player.PlayerChair, _outCardInfo.card, _outCardInfo.chair);
                        return;
                    }
                }
                foreach (var player in _playerAry)
                {
                    if (MahjongDef.gVoteResult_Peng == player.VoteResult)
                    {
                        _playerAry[_outCardInfo.chair].IsJustGang = false;
                        this.PlayerPeng(player.PlayerChair, _outCardInfo.card);
                        return;
                    }
                }
            }
            else
                if (0 == _completeCount)//所有可以投票的玩家都已经投完票
            {
                //关闭投票超时
                closeOutTimer();
                //1、找投胡牌票的
                List<ushort> huPlayer = new List<ushort>();

                if (!_tableConfig.YiPaoDuoXiang)
                {

                    for (int i = 1; i < MGMJConstants.GAME_PLAYER; i++) //不带一炮多响，从出牌者的下家开始找起
                    {
                        int temp = (i + _outCardInfo.chair) % MGMJConstants.GAME_PLAYER;
                        if (MahjongDef.gVoteResult_Hu == _playerAry[temp].VoteResult)
                        {
                            huPlayer.Add(_playerAry[temp].PlayerChair);
                            this.PlayerHuCard(_playerAry[temp].PlayerChair, _outCardInfo.card, _playerAry[i].PlayerCard.activeCard.handCard,outMj[_playerAry[temp].PlayerChair]);
                            break;
                        }
                    }
                }
                else
                {   //霍邱麻将默认带一炮多响
                    int huPerson = 0;
                    for(int i = 0; i < 4; i++)
                    {
                        if(MahjongDef.gVoteResult_Hu == _playerAry[i].VoteResult)
                        {
                            huPerson++;
                        }
                    }
                    if(huPerson == 2)
                    {
                        _yipaoliangxiang = true;
                    }
                    if(huPerson == 3)
                    {
                        _yipaosanxiang = true;
                    }
                    for(int i = 1; i < MGMJConstants.GAME_PLAYER; i++)
                    {
                        int temp = (i + _outCardInfo.chair) % MGMJConstants.GAME_PLAYER;
                        if(MahjongDef.gVoteResult_Hu == _playerAry[temp].VoteResult)
                        {
                            huPlayer.Add(_playerAry[temp].PlayerChair);
                            this.PlayerHuCard(_playerAry[temp].PlayerChair,_outCardInfo.card,_playerAry[i].PlayerCard.activeCard.handCard,outMj[_playerAry[temp].PlayerChair]);
                        }
                    }
                    //foreach (var player in _playerAry)
                    //{
                    //    if (MahjongDef.gVoteResult_Hu == player.VoteResult)
                    //    {
                    //        huPlayer.Add(player.PlayerChair);
                    //        this.PlayerHuCard(player.PlayerChair, _outCardInfo.card, _playerAry[player.PlayerChair].PlayerCard.activeCard.handCard,outMj[player.PlayerChair]);
                    //    }
                    //}
                }


                if (huPlayer.Count > 0)
                {

                    this._gamePhase = enGamePhase.GamePhase_Unknown;

                    //8个时间周期后进行投票处理
                    GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
                    {
                        if (NeedOverGame)
                        {

                            this.OnEventGameEnd(MahjongDef.gInvalidChar);
                        }
                        else
                        {
                            GetNextOpPlayer((byte)huPlayer[huPlayer.Count - 1]);
                            SendCardToPlayer();
                        }
                    });

                    return;
                }

                //2、找投杠的
                foreach (var player in _playerAry)
                {
                    if (MahjongDef.gVoteResult_Gang == player.VoteResult)
                    {
                        _playerAry[_outCardInfo.chair].IsJustGang = false;
                        this.PlayerVoteGang(player.PlayerChair, _outCardInfo.card, _outCardInfo.chair);
                        return;
                    }
                }

                //3、找投碰的
                foreach (var player in _playerAry)
                {
                    if (MahjongDef.gVoteResult_Peng == player.VoteResult)
                    {
                        _playerAry[_outCardInfo.chair].IsJustGang = false;
                        this.PlayerPeng(player.PlayerChair, _outCardInfo.card);
                        return;
                    }
                }

                //3、找投吃的
                foreach (var player in _playerAry)
                {
                    if (MahjongDef.gVoteResult_Chi == player.VoteResult)
                    {
                        _playerAry[_outCardInfo.chair].IsJustGang = false;
                        this.PlayerChi(player.PlayerChair, _outCardInfo.card, _chiType);
                        return;
                    }
                }

                //4、玩家都投了放弃票

                //所有玩家都放弃,进入新一轮的抓牌打牌阶段
                AddLogTitle("所有玩家都投了放弃，进入下个抓牌打牌循环");
                //没有玩家投票，再将打出的这张牌，放入打牌玩家牌池
                _playerAry[_outCardInfo.chair].PlayerCard.poolCard.Add(_outCardInfo.card);
                _rememberCard.OutCard(_outCardInfo.card);
                //添加打牌记录
                _outCardRecord.Add(_outCardInfo.card);

                //取下一个操作玩家椅子号
                GetNextOpPlayer((byte)_outCardInfo.chair);
                PrintLog("本次轮到" + _opPlayerChar.ToString() + "号玩家操作");
                //给当前玩家发牌
                SendCardToPlayer();
            }
        }

        ///<summary>
        ///处理玩家投票吃牌
        ///</summary>
        private void PlayerChi(ushort chair, byte card, byte chiType)
        {
            //_chiType = chiType;
            PrintLog(chair.ToString() + "号玩家吃牌:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)]);
            _outCardRecord.Add(card);
            //3、逻辑处理
            PrintLog("吃牌前手中活动牌:");
            PrintPlayerHandCard((byte)chair);

            _playerAry[chair].HandleByAfterChi(card, (byte)_outCardInfo.chair, chiType);
            _rememberCard.ChiCard(card);
            PrintLog("吃牌后手中活动牌:");
            PrintPlayerHandCard((byte)chair);
            //发送删牌池牌

            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_DelPoolCard()
            {
                chair = (byte)_outCardInfo.chair,
                card = card,
                cardnum = (byte)_playerAry[_outCardInfo.chair].PlayerCard.poolCard.Count
            });
            //通知客户端玩家吃牌
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerChiCard()
            {
                chair = (byte)chair,
                outChair = (byte)_outCardInfo.chair,
                card = card,
                chi_type = chiType
            });
            //吃牌玩家继续操作
            _opPlayerChar = (byte)chair;

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行投票处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                //通知当前操作的玩家
                InformCurOpPlayer();

                //设置游戏阶段及AI思考间隔
                ConfirmGamePhase();

                //通知当前操作的玩家
                InformCustomOpPlayer(_opPlayerChar);
            });
        }


        /// <summary>
        /// 处理玩家投票碰牌
        /// </summary>
        /// <param name="wCharID"></param>
        /// <param name="cCard"></param>
        private void PlayerPeng(ushort chair, byte card)
        {
            PrintLog(chair.ToString() + "号玩家碰牌:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)]);
            _outCardRecord.Add(card);
            //3、逻辑处理
            PrintLog("碰牌前手中活动牌:");
            PrintPlayerHandCard((byte)chair);

            _playerAry[chair].HandleByAfterPeng(card, (byte)_outCardInfo.chair);
            _rememberCard.PengCard(card);
            PrintLog("碰牌后手中活动牌:");
            PrintPlayerHandCard((byte)chair);
            //发送删牌池牌
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_DelPoolCard()
            {
                chair = (byte)_outCardInfo.chair,
                card = _outCardInfo.card,
                cardnum = (byte)_playerAry[_outCardInfo.chair].PlayerCard.poolCard.Count
            });
            //通知客户端玩家碰牌
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerPengCard()
            {
                chair = (byte)chair,
                outChair = (byte)_outCardInfo.chair,
                card = card
            });
         
            //碰牌玩家继续操作
            _opPlayerChar = (byte)chair;

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行投票处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                //通知当前操作的玩家
                InformCurOpPlayer();

                //设置游戏阶段及AI思考间隔
                ConfirmGamePhase();

                //通知当前操作的玩家
                InformCustomOpPlayer(_opPlayerChar);
            });
          
        }

        /// <summary>
        /// 处理玩家投票杠
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void PlayerVoteGang(ushort chair, byte card, ushort dianGangPlayer)
        {
            liuju++;
            PrintLog(chair.ToString() + "号玩家明杠:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)]);
            _playerAry[chair].HandleByAfterMGang(card, (byte)_outCardInfo.chair);
            _rememberCard.GangCard(card);
            _playerAry[chair].DianGangPlayer = (byte)dianGangPlayer;

            if (_playerAry[chair].PlayerCard.tingCard.Count > 0)
            {
                PrintLog("明杠后玩家听的牌:");
                PrintCardList(_playerAry[chair].PlayerCard.tingCard);
            }
            //统计明杠次数
            this.huGangCount[chair][2]++;

            _playerAry[chair].PlayerScore.MingGang++;
            _playerAry[dianGangPlayer].PlayerScore.FangGang++;

            //发送删牌池牌
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_DelPoolCard()
            {
                chair = (byte)_outCardInfo.chair,
                card = _outCardInfo.card,
                cardnum = (byte)_playerAry[_outCardInfo.chair].PlayerCard.poolCard.Count
            });
            //通知客户端有玩家明杠牌了
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerMingGang()
            {
                chair = (byte)chair,
                outChair = (byte)_outCardInfo.chair,
                card = card
            });

            _opPlayerChar = (byte)chair;

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行投票处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                //杠牌玩家继续抓牌打牌
                SendCardToPlayer(false);
            });

            //杠牌玩家继续抓牌打牌
            //SendCardToPlayer();
        }

        /// <summary>
        /// 处理玩家投票胡牌
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void PlayerHuCard(ushort chair, byte card, List<byte> list,int countOutMj)
        {
            _playerAry[chair].IfCanOp = false;
            _outCardRecord.Add(card);
            int[] multiple = new int[3];

            String _vecHuType = "";

            multiple = _playerAry[chair].HandleByHu((byte)chair,card, enHuCardType.HuCardType_PingHu, list, countOutMj);

            this.huGangCount[chair][1]++;

            GameHost.WriteMessage("总：" + multiple);
            _noOneWin = false;
            //加番
            int tempjia = 1;
            //豹子胡翻倍
            if (_baoTing[chair])
            {
                tempjia = 2;
            }
            if (_playerAry[_outCardInfo.chair].IsJustGang)
            {
                //tempjia = 1;
                // _playerAry[chair].JieSuan[9] = 1;
            }           
            hu_number++;

            //庄的确定(谁赢谁坐庄 )
            if (!_yipaoliangxiang && !_yipaosanxiang)
            {//只有一个人胡
                if (_bankerChar == chair)
                {
                    lianzhuang++;
                    _lastBanker = (byte)chair;
                }
                else
                {
                    lianzhuang++;
                    _lastBanker = _bankerChar;
                    _bankerChar = (byte)chair;
                }
                //庄分
                if (lianzhuang > 1 && _tableConfig.zhanZhuang == 1)
                {
                    multiple[0] += lianzhuang-1;
                    _playerAry[chair].VecType += "庄分+ " + (lianzhuang - 1);
                }
            }
            else if(_yipaoliangxiang)
            {//一炮两响
                _lastBanker = _bankerChar;
                if (hu_number == 1)
                {
                    lianzhuang++;
                }
                //庄分
                if (lianzhuang > 1 && _tableConfig.zhanZhuang == 1)
                {
                    multiple[0] += lianzhuang-1;
                    _playerAry[chair].VecType += "庄分+ " + (lianzhuang - 1);
                }
                _bankerChar = (byte)_outCardInfo.chair;
            }else if (_yipaosanxiang)
            {//一炮三响
                _lastBanker = _bankerChar;
                if (hu_number == 1) {              
                    lianzhuang++;
                }
                //庄分
                if (lianzhuang > 1 && _tableConfig.zhanZhuang == 1)
                {
                    multiple[0] += lianzhuang - 1;
                    _playerAry[chair].VecType += "庄分+ " + (lianzhuang - 1);
                }
                _bankerChar = (byte)_outCardInfo.chair;
            }

            //建立一个临时数组 存放分数 包分时 方便计算
            int[] tempScore = new int[4];      
            int anGangs = 0;
            int mingGangs = 0;

            if (_tableConfig.gangFen == 1)
            {
                if (_playerAry[chair].PlayerCard.fixedCard.fixedCard.Count > 0)
                {
                    for (int j = 0; j < _playerAry[chair].PlayerCard.fixedCard.fixedCard.Count; j++)
                    {
                        if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_AGang)
                            anGangs++;
                        if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_BGang)
                            mingGangs++;
                        if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_MGang)
                            mingGangs++;
                    }
                }

                //计算杠分
                    if (anGangs != 0)
                    {
                        multiple[0] += anGangs * 2;
                        _playerAry[chair].VecType += " 暗杠+ " + anGangs * 2;
                    }
                    if (mingGangs != 0)
                    {
                        multiple[0] += mingGangs;
                        _playerAry[chair].VecType += " 明杠+ " + mingGangs;
                    }
            }    
            /**
             * 包分问题 清一色包分 multiple数组 第一个值表示分数 第二个表示是否清一色包分 第三个表示是否全幺九包分
            **/
            if (multiple[1] == 1)
            {
                //清一色包分
                //_playerAry[chair].PlayerScore.huScore += multiple[0] * 4 * tempjia;
                //_playerAry[_outCardInfo.chair].PlayerScore.huScore -= multiple[0] * 4 * tempjia;
                for (int i = 0; i < 4; i++)
                {
                    if (i != chair)
                    {
                        if (i == _outCardInfo.chair)
                        {
                            tempScore[i] -= multiple[0] * 2 * tempjia;
                        }
                        else
                        {
                            if (_tableConfig.whoLose == 0 && hu_number <= 1)
                            {//赢倒三家有
                                tempScore[i] -= multiple[0] * tempjia;
                            }
                        }
                    }
                }
                //临时分数赋给最终数组(包分)
                for (int i = 0; i < 4; i++)
                {
                    if (i != chair)
                        _playerAry[chair].PlayerScore.huScore -= tempScore[i];
                    if (i != chair && i != _outCardInfo.chair)
                        _playerAry[i].PlayerScore.huScore -= 0;
                }
                _playerAry[_outCardInfo.chair].PlayerScore.huScore = -_playerAry[chair].PlayerScore.huScore;
                _playerAry[_outCardInfo.chair].VecType += "清一色包分 ";

        }
            else if (multiple[2] == 1)
            {
                //全幺九包分
                //_playerAry[chair].PlayerScore.huScore += multiple[0] * 4 * tempjia;
                //_playerAry[_outCardInfo.chair].PlayerScore.huScore -= multiple[0] * 4 * tempjia;
                for (int i = 0; i < 4; i++)
                {
                    if (i != chair)
                    {
                        if (i == _outCardInfo.chair)
                        {
                            tempScore[i] -= multiple[0] * 2 * tempjia;
                        }
                        else
                        {
                            if (_tableConfig.whoLose == 0 && hu_number <= 1)
                            {//赢倒三家有
                                tempScore[i] -= multiple[0] * tempjia;
                            }
                        }
                    }
                }
                //临时分数赋给最终数组(包分)
                for (int i = 0; i < 4; i++)
                {
                    if (i != chair)
                        _playerAry[chair].PlayerScore.huScore -= tempScore[i];
                    if(i != chair && i != _outCardInfo.chair)
                        _playerAry[i].PlayerScore.huScore -= 0;
                }
                _playerAry[_outCardInfo.chair].PlayerScore.huScore = -_playerAry[chair].PlayerScore.huScore;
                _playerAry[_outCardInfo.chair].VecType += "全幺九包分 ";
            }
            else
            {
                //最终分值(无包分情况 正常算分)
                for (int i = 0; i < 4; i++)
                {
                    if (i != chair)
                    {
                        if (i == _outCardInfo.chair)
                        {
                            tempScore[i] -= multiple[0] * 2 * tempjia;
                            //tempScore[chair] += multiple[0] * 2 * tempjia;
                        }
                        else
                        {
                            if (_tableConfig.whoLose == 0 && hu_number <= 1)
                            {//赢倒三家有
                                tempScore[i] -= multiple[0] * tempjia;
                                //_playerAry[chair].PlayerScore.huScore += multiple[0] * tempjia;
                            }
                        }
                    }
                }
                //加给赢家
                for(int i = 0; i < 4; i++)
                {
                    if(i != chair)
                    {
                        _playerAry[i].PlayerScore.huScore += tempScore[i];
                        _playerAry[chair].PlayerScore.huScore -= tempScore[i];
                    }
                }
            }

            GameHost.WriteMessage("总：" + multiple);

            //胡牌玩家+胡牌分
            //_playerAry[chair].PlayerScore.huScore += multiple * this._tableConfig.CellScore;
            //点炮玩家-胡牌分
            //_playerAry[_outCardInfo.chair].PlayerScore.huScore -= multiple * this._tableConfig.CellScore;

            _playerAry[_outCardInfo.chair].IsFangPao = true;
            //发送删牌池牌
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_DelPoolCard()
            {
                chair = (byte)_outCardInfo.chair,
                card = _outCardInfo.card,
                cardnum = (byte)_playerAry[_outCardInfo.chair].PlayerCard.poolCard.Count
            });
            //发送胡牌玩家
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHuCard()
            {
                chair = (byte)chair,
                card = card,
                huType = (byte)(enHuCardType.HuCardType_PingHu),
                huScore = null,
                vecHuType = _vecHuType
            });
            this._gamePhase = enGamePhase.GamePhase_Unknown;

        }

        #endregion

        #region 抢杠处理
        /// <summary>
        /// 玩家抢杠
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="qiangGang"></param>
        private void HandleMsg_CMD_C_QiangGang(ushort chair, byte qiangGang)
        {
            if (!_playerAry[chair].IfCanOp || (_gamePhase != enGamePhase.GamePhase_QiangGang) || !_waitQiangGangPlayer.Contains(chair))
            {
                return;
            }
            int tempjia = 1;
            if (_baoTing[chair])
            {
                tempjia *= 2;
            }

            ++_completeCount;
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            _playerAry[chair].IsVoteQiangGang = qiangGang > 0;

            if (0 == qiangGang)//检查弃胡
            {
                _playerAry[chair].checkGiveUpHu(_qiangGangInfo.card, enHuCardType.HuCardType_QiangGangHu);
            }

            this.SendGameMsg(chair, new CMD_S_VoteQGResult()
            {
                voteqg = qiangGang
            });

            if (_completeCount == _waitQiangGangPlayer.Count)
            {
                //关闭抢杠超时计时
                closeOutTimer();
                //统计点炮胡次数（抢杠胡算点炮胡统计）
                this.huGangCount[chair][1]++;

                ushort lastHuChair = MahjongDef.gInvalidChar;
                if (_tableConfig.YiPaoDuoXiang)
                {
                    int huPerson = 0;
                    for (int j = 1; j < MGMJConstants.GAME_PLAYER; j++)
                    {
                        int temp = (j + _qiangGangInfo.chair) % MGMJConstants.GAME_PLAYER;
                        {
                            if (_playerAry[temp].IsVoteQiangGang)
                            {
                                huPerson++;
                                lastHuChair = (ushort)temp;
                                _playerAry[_qiangGangInfo.chair].IsFangPao = true;
                                int[] multiple = _playerAry[temp].HandleByHu((byte)temp, _qiangGangInfo.card,
                                    enHuCardType.HuCardType_QiangGangHu, _playerAry[temp].PlayerCard.activeCard.handCard,outMj[temp]);
                                _noOneWin = false;
                                int[] tempScore = new int[4];

                                //庄的确定(谁赢谁坐庄 )
                                if (1 == _completeCount)
                                {//只有一个人胡
                                    if (_bankerChar == temp)
                                    {
                                        lianzhuang++;
                                    }
                                    else
                                    {
                                        lianzhuang++;
                                        _lastBanker = _bankerChar;
                                        _bankerChar = (byte)temp;
                                    }
                                }
                                else
                                {
                                    if (_completeCount == 2)
                                    {//两人抢杠胡
                                        _lastBanker = _bankerChar;
                                        if (huPerson == 1)
                                        {
                                            lianzhuang++;
                                        }
                                    }
                                    if (_completeCount == 3)
                                    {//三人抢杠胡
                                        _lastBanker = _bankerChar;
                                        if (huPerson == 1)
                                        {
                                            lianzhuang++;
                                        }
                                    }
                                    _bankerChar = (byte)_qiangGangInfo.chair;
                                }
                                if(_tableConfig.zhanZhuang == 1 && lianzhuang > 1)
                                {
                                    multiple[0] += (lianzhuang - 1);
                                    _playerAry[temp].VecType += " 庄分+ " + (lianzhuang - 1);
                                }

                                int anGangs = 0;
                                int mingGangs = 0;
                                if (_tableConfig.gangFen == 1)
                                {
                                    if (_playerAry[temp].PlayerCard.fixedCard.fixedCard.Count > 0)
                                    {
                                        for (int a = 0; a < _playerAry[temp].PlayerCard.fixedCard.fixedCard.Count; a++)
                                        {
                                            if (_playerAry[temp].PlayerCard.fixedCard.fixedCard[a].fixedType == enFixedCardType.FixedCardType_AGang)
                                                anGangs++;
                                            if (_playerAry[temp].PlayerCard.fixedCard.fixedCard[a].fixedType == enFixedCardType.FixedCardType_BGang)
                                                mingGangs++;
                                            if (_playerAry[temp].PlayerCard.fixedCard.fixedCard[a].fixedType == enFixedCardType.FixedCardType_MGang)
                                                mingGangs++;
                                        }
                                    }
                                    //计算杠分
                                    if (anGangs != 0)
                                    {
                                        multiple[0] += anGangs * 2;
                                        _playerAry[temp].VecType += " 暗杠+ " + anGangs * 2;
                                    }
                                    if (mingGangs != 0)
                                    {
                                        multiple[0] += mingGangs;
                                        _playerAry[temp].VecType += " 明杠+ " + mingGangs;
                                    }
                                }
                                if (multiple[1] == 1)
                                {//清一色包分
                                    if (huPerson == 1)
                                    {
                                        //_playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= multiple[0] * 4 * tempjia;
                                        //_playerAry[temp].PlayerScore.huScore += multiple[0] * 4 * tempjia;
                                        for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                                        {
                                            if (i == _qiangGangInfo.chair)//被抢杠的人
                                            {
                                                _playerAry[i].PlayerScore.huScore -= multiple[0] * 2 * tempjia;
                                                //_playerAry[temp].PlayerScore.huScore += multiple[0] * 2 * tempjia;
                                            }
                                            else if (i != temp)
                                            {
                                                _playerAry[i].PlayerScore.huScore -= multiple[0] * tempjia;
                                                //_playerAry[temp].PlayerScore.huScore += multiple[0] * tempjia;
                                            }
                                        }
                                        //玩家分数赋值
                                        for(int a = 0; a < 4; a++)
                                        {
                                            if(a != temp)
                                            {
                                                _playerAry[temp].PlayerScore.huScore -= _playerAry[a].PlayerScore.huScore;
                                                if(a != _qiangGangInfo.chair)
                                                {
                                                    _playerAry[_qiangGangInfo.chair].PlayerScore.huScore += _playerAry[a].PlayerScore.huScore;
                                                    _playerAry[a].PlayerScore.huScore = 0;
                                                }
                                            }
                                        }
                                        _playerAry[temp].VecType += "清一色包分 ";
                                    }
                                    else if (huPerson > 1)
                                    {
                                        _playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= multiple[0] * 2 * tempjia;
                                        _playerAry[temp].PlayerScore.huScore += multiple[0] * 2 * tempjia;
                                        _playerAry[temp].VecType += "清一色包分 ";
                                    }
                                }
                                else if (multiple[2] == 2)
                                {//全幺九包分
                                    if (huPerson == 1)
                                    {
                                        for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                                        {
                                            if (i == _qiangGangInfo.chair)//被抢杠的人
                                            {
                                                _playerAry[i].PlayerScore.huScore -= multiple[0] * 2 * tempjia;
                                            }
                                            else if (i != temp)
                                            {
                                                _playerAry[i].PlayerScore.huScore -= multiple[0] * tempjia;
                                            }
                                        }
                                        //玩家分数赋值
                                        for (int a = 0; a < 4; a++)
                                        {
                                            if (a != temp)
                                            {
                                                _playerAry[temp].PlayerScore.huScore -= _playerAry[a].PlayerScore.huScore;
                                                if (a != _qiangGangInfo.chair)
                                                {
                                                    _playerAry[_qiangGangInfo.chair].PlayerScore.huScore += _playerAry[a].PlayerScore.huScore;
                                                    _playerAry[a].PlayerScore.huScore = 0;
                                                }
                                            }
                                        }
                                        _playerAry[temp].VecType += "全幺九包分 ";
                                    }
                                    else if (huPerson > 1)
                                    {
                                        _playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= multiple[0] * 2 * tempjia;
                                        _playerAry[temp].PlayerScore.huScore += multiple[0] * 2 * tempjia;
                                        _playerAry[temp].VecType += "全幺九包分 ";
                                    }
                                }
                                else
                                {
                                 //最终分值(无包分情况 正常算分)
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (i != temp)
                                        {
                                            if (i == _qiangGangInfo.chair)
                                            {
                                                tempScore[i] -= multiple[0] * 4 * tempjia;
                                            }
                                            else
                                            {
                                                if (huPerson <= 1)
                                                {
                                                    tempScore[i] -= multiple[0] * 2 * tempjia;
                                                }
                                            }
                                        }
                                    }
                                    //加给赢家
                                    for (int i = 0; i < 4; i++)
                                    {
                                        if (i != temp)
                                        {
                                            _playerAry[i].PlayerScore.huScore += tempScore[i];
                                            _playerAry[temp].PlayerScore.huScore -= tempScore[i];
                                        }
                                    }
                                }
                                //发送抢杠玩家
                                SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHuCard()
                                {
                                    chair = (byte)temp,
                                    card = _qiangGangInfo.card,
                                    huType = (byte)(enHuCardType.HuCardType_ZiMo),
                                    huScore = null
                                });
                            }
                        }
                    }
                }
                else
                {
                    for (int j = 1; j < MGMJConstants.GAME_PLAYER; j++)//不带一炮多响，从出牌者的下家开始找起
                    {
                        int temp = (j + _qiangGangInfo.chair) % MGMJConstants.GAME_PLAYER;
                        if (_playerAry[temp].IsVoteQiangGang)
                        {
                            lastHuChair = (ushort)temp;
                            _playerAry[_qiangGangInfo.chair].IsFangPao = true;
                            int[] multiple = _playerAry[temp].HandleByHu((byte)_qiangGangInfo.chair, _qiangGangInfo.card, enHuCardType.HuCardType_QiangGangHu, _playerAry[_qiangGangInfo.chair].PlayerCard.activeCard.handCard, outMj[temp]);
                            _noOneWin = false;
                            _playerAry[temp].JieSuan[8]++;

                            //杠分

                            //拉跑
                            int templp = 0;

                            _playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= (multiple[0] + templp - 1) * tempjia *
                                                                                    _tableConfig.CellScore;
                            _playerAry[temp].PlayerScore.huScore += (multiple[0] + templp - 1) *
                                                                           tempjia * _tableConfig.CellScore;
                           
                            //发送抢杠玩家
                            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHuCard()
                            {
                                chair = (byte)temp,
                                card = _qiangGangInfo.card,
                                huType = (byte)(enHuCardType.HuCardType_PingHu),
                                huScore = null
                            });
                            //_bankerChar = (byte)temp;
                            break;
                        }
                    }
                }

                if (MahjongDef.gInvalidChar != lastHuChair)
                {              
                    _playerAry[_qiangGangInfo.chair].HandleByAfterOutCard(_qiangGangInfo.card);

                    //删除别人已经抢杠的牌
                    this.SendGameMsg(_qiangGangInfo.chair, new CMD_S_DelQiangGangCard()
                    {
                        card = _qiangGangInfo.card
                    });
                    this._gamePhase = enGamePhase.GamePhase_Unknown;
                    //8个时间周期后进行投票处理
                    GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
                    {
                        this.OnEventGameEnd(MahjongDef.gInvalidChar);
                    });
                }
                else
                {
                    //抢杠玩家继续补杠
                    this.HandlePlayerBuGang(_qiangGangInfo.chair, _qiangGangInfo.card);
                }
            }
        }

        #endregion

        #region 求助

        /// <summary>
        /// 向好友求助
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="friendHelp"></param>
        private void HandleMsg_CMD_C_FriendHelp(ushort chair, CMD_C_FriendHelp friendHelp)
        {
            var player = this.GameHost.PlayerDataService.GetPlayerByChairID(chair);
            if (null == player)
            {
                return;
            }

            var friend = this.GameHost.PlayerDataService.GetPlayerByChairID(friendHelp.friendChair);
            if (null == friend)
            {
                //通知拒绝
                this.SendGameMsg(chair, new CMD_S_FriendReject()
                {
                    friendChair = friendHelp.friendChair,
                    friendID = friendHelp.friendID
                });
            }
            else
            {
                //通知有人向该玩家求助
                this.SendGameMsg(friendHelp.friendChair, new CMD_S_FriendHelpInfo()
                {
                    friendChair = (byte)chair,
                    friendID = player.UserID,
                    moneyType = friendHelp.moneyType,
                    moneyNum = friendHelp.moneyNum
                });
            }
        }

        /// <summary>
        /// 拒绝帮助好友
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="reject"></param>
        private void HandleMsg_CMD_C_RejectHelp(ushort chair, CMD_C_RejectHelp reject)
        {
            var player = this.GameHost.PlayerDataService.GetPlayerByChairID(chair);
            if (null == player)
            {
                return;
            }
            var friend = this.GameHost.PlayerDataService.GetPlayerByChairID(reject.friendChair);
            if ((null != friend) && (friend.UserID == reject.friendID))
            {
                this.SendGameMsg(reject.friendChair, new CMD_S_FriendReject()
                {
                    friendChair = (byte)chair,
                    friendID = player.UserID
                });
            }
        }

        /// <summary>
        /// 确认帮助好友
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="helpFriend"></param>
        private void HandleMsg_CMD_C_HelpFriend(ushort chair, CMD_C_HelpFriend helpFriend)
        {
            var player = this.GameHost.PlayerDataService.GetPlayerByChairID(chair);
            if (null == player)
            {
                return;
            }
            var friend = this.GameHost.PlayerDataService.GetPlayerByChairID(helpFriend.friendChair);
            if ((null != friend) && (friend.UserID == helpFriend.friendID))
            {
                //    //进行结算
                //    this.GameHost.HostSettlementService.UserTransferGameQiuZhu(new UserTransferGameQiuZhuReq()
                //    {
                //        MarkContext = "颖上麻将求助处理",
                //        MoneyNum = (uint)helpFriend.moneyNum,
                //        MoneyType = helpFriend.moneyType,
                //        MyUserID = player.UserID,
                //        OtherUserID = friend.UserID
                //    }, p =>
                //    {
                //        if (p.IsSuccess)
                //        {
                //            this.SendGameMsg(helpFriend.friendChair, new CMD_S_FriendHelpSuccess()
                //            {
                //                friendChair = (byte)chair,
                //                friendID = player.UserID,
                //                result = (byte)1,
                //            });
                //        }
                //        else
                //        {
                //            this.SendGameMsg(helpFriend.friendChair, new CMD_S_FriendHelpSuccess()
                //            {
                //                friendChair = (byte)chair,
                //                friendID = player.UserID,
                //                result = (byte)0,
                //            });
                //        }
                //    });
            }
        }
        #endregion

        /// <summary>
        /// 请求强退
        /// </summary>
        /// <param name="playerID"></param>
        private void HandleMsg_CMD_C_ForceLeft(ushort chair, uint playerID)
        {
            //#region 强退扣费

            //if (0 == this._gameForceLeftNum[chair])
            //{
            //    var forceMoneyType = CurrencyType.QiDou;
            //    int forceMoneyNum = -1000;

            //    #region 取系统配置表,获取强退惩罚

            //    var forceConfig = (this.GameHost.HostSystemConfigManger["QuitDeduct"] ?? "4|-1000").Split('|');
            //    if (forceConfig.Length >= 2)
            //    {
            //        int moneyType = 0;
            //        if (int.TryParse(forceConfig[0], out moneyType))
            //        {
            //            forceMoneyType = (CurrencyType)moneyType;
            //        }

            //        int moneyNum = 0;
            //        if (int.TryParse(forceConfig[1], out moneyNum))
            //        {
            //            forceMoneyNum = moneyNum;
            //        }
            //    }

            //    #endregion

            //    List<UserAuditData> userAuditData = new List<UserAuditData>();
            //    userAuditData.Add(new UserAuditData()
            //    {
            //        MoneyNum = forceMoneyNum,
            //        UserID = playerID
            //    });

            //    GameHost.HostSettlementService.PlayerForFeeMultiple(new PlayerForFeeDataMultiple()
            //    {
            //        FeeDataType = ForFeeDataType.多人游戏结算,
            //        Mark = "强退扣费",
            //        MoneyType = forceMoneyType,
            //        NoCheckUserMoney = 0,
            //        RoomID = GameHost.GetRoomInfo.ID,
            //        UserAuditDataArray = userAuditData.ToArray()
            //    }, p =>
            //    {

            //    });

            //    ++this._gameForceLeftNum[chair];
            //}

            ////强退影响其他不在家的玩家
            //this.playerForceLeftCheckOtherPlayerForce(chair);
            //_playerAry[chair].isForceLefting = true;

            //#endregion

            //强退成功
            this.SendGameMsg(chair, new CMD_S_ForceLeftSuccess());
        }

        /// <summary>
        /// 创建桌子
        /// </summary>
        /// <param name="tableRule"></param>
        private void HandleMsg_CMD_C_CreateTable(ushort chair, CMD_C_CreateTable tableRule)
        {
            var player = this.GameHost.PlayerDataService.GetPlayerByChairID(chair);
            if (null == player)
            {
                return;
            }
            this._tableConfig.clear();
            //
            if (tableRule.isTableCreatorPay == 3) //圈主买单
            {
                //牌友群-直接预扣房费
                if (GameHost.TableInfo.GroupId > 0)
                {
                    int moneyNum = (tableRule.SetGameNum + 1) * 32;
                    //uint moneyNum = tableInfo.tableCostMoney;
                    GameHost.HostSettlementService.FrozenUserAccount(new GameIF.FrozenUserAccountParam()
                    {

                        //     指定此次预扣的账户Id
                        in_ObjectId = GameHost.TableInfo.GroupId,
                        //
                        // 摘要:
                        //     指定账户类型 1：玩家 2：圈主 3：代理
                        in_ObjectType = (FrozenUserAccountObjectType)2,
                        //
                        // 摘要:
                        //     暂扣的货币道具类型
                        MoneyType = GameHost.GetRoomInfo.TableCostMoneyType,
                        //
                        // 摘要:
                        //     暂扣的数量
                        MoneyNum = moneyNum,
                        //
                        // 摘要:
                        //     备注信息
                        Mark = "霍邱麻将圈住付费房费预扣",

                    }, Rec_PreHoldPay);
                }
            }
            
            //检查余额
            if (player.MoneyBag.DiamondNum < tableRule.TableCost)
                NoMoneyForce(chair);
            else
            {
                this._tableConfig.TableCreatorChair = chair;
                this._tableConfig.TableCreatorID = player.UserID;
                
                GameHost.SetTableOwner(_tableConfig.TableCreatorID);

                _tableConfig.LaPaoZuo = false;
                _tableConfig.CellScore = 1;
                _tableConfig.GangKaiJia = true;//tableRule.GangKaiJia > 0;
                _tableConfig.IfCanSameIp = true;
                _tableConfig.BuKaoJia = false;
                _tableConfig.QiDuiJia = false;
                _tableConfig.IsRecordScoreRoom = true;
                _tableConfig.isCreateed = true;
                _tableConfig.CreatedOutTimeOP = false; // tableRule.isOutTimeOp > 0;
                //_tableConfig.GoldRoomBaseIdx = tableRule.GoldRoomBaseIdx;
                this._tableConfig.PlayerNum = tableRule.PlayerNum;
                this._tableConfig.WaitTimeNum = tableRule.WaitTimeNum;
                _tableConfig.SetPeiZi = tableRule.SetPeiZi==1 ? 0x37 : _cardPackage.getRandomPeiZi() ;
                _tableConfig.DianPao = tableRule.DianPao;
                _tableConfig.QiangGangHu = tableRule.QiangGangHu;
                _tableConfig.canChi = tableRule.canChi;
                _tableConfig.daiDaPai = tableRule.daiDaPai;
                _tableConfig.gangFen = 1;
                _tableConfig.whoLose = tableRule.whoLose;
                _tableConfig.zhanZhuang = tableRule.zhanZhuang;
                _tableConfig.TableCost = tableRule.TableCost;
                //支付方式
                _tableConfig.TableCreatorPay = tableRule.isTableCreatorPay;
                _tableConfig.TableCode = tableRule.TableCode;
                //总局数
                _tableConfig.SetGameNum = tableRule.SetGameNum;//_specialAttri.JuShu[tableRule.SetGameNum+1];//
                //通知桌子规则
                this.SendTableRule2Client(MahjongDef.gInvalidChar);

                //通知房主
                this.SendTableCreator2Client(MahjongDef.gInvalidChar);
                //创建成功
                this.SendGameMsg(chair, new CMD_S_CreateTableSuccess());
            }
        }

         void Rec_PreHoldPay(FrozenUserAccountResult result)
        {
            if (result.IsSuccess)
                this.quanZhuID = result.OrderId;
            else
                this.SendGameMsg(MahjongDef.gInvalidChar,new CMD_S_QuitCreator());
        }

        /// <summary>
        /// 查询游戏记录
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="queryParm"></param>
        private void HandleMsg_CMD_C_QueryGameRecord(ushort chair, CMD_C_QueryGameRecord queryParm)
        {
            List<GameRecordResult> rec = new List<GameRecordResult>();
            foreach (var player in _curGameUserID)
            {
                if (player == queryParm.MessageUserID)
                {
                    if (0 == queryParm.queryNum)//返回所有
                    {
                        for (int i = 0; i < this._tableConfig.PlayerGameRecord.Count; i++)
                        {
                            rec.Add(new GameRecordResult()
                            {
                                PlayerScore = this._tableConfig.PlayerGameRecord[i].playerRecord.ToArray(),
                                ScoreType = _tableConfig.PlayerGameRecord[i].ScoreType,
                                Banker = _tableConfig.PlayerGameRecord[i].BankerChair,
                                huGangCount = this.huGangCount
                            });
                        }
                    }
                    else//返回最后一条
                    {
                        if (this._tableConfig.PlayerGameRecord.Count > 0)
                        {
                            rec.Add(new GameRecordResult()
                            {
                                PlayerScore = this._tableConfig.PlayerGameRecord[this._tableConfig.PlayerGameRecord.Count - 1].playerRecord.ToArray(),
                                ScoreType = _tableConfig.PlayerGameRecord[this._tableConfig.PlayerGameRecord.Count - 1].ScoreType,
                                Banker = _tableConfig.PlayerGameRecord[_tableConfig.PlayerGameRecord.Count - 1].BankerChair,
                                huGangCount = this.huGangCount
                            });
                        }
                    }
                }
            }

            this.SendGameMsg(chair, new CMD_S_GameRecordResult()
            {
                record = rec.ToArray()
            });
        }

        /// <summary>
        /// 推送游戏记录，以防申请未响应
        /// </summary>
        private void sendGameRecord()
        {
            List<GameRecordResult> rec = new List<GameRecordResult>();

            for (int i = 0; i < this._tableConfig.PlayerGameRecord.Count; i++)
            {
                rec.Add(new GameRecordResult()
                {
                    PlayerScore = this._tableConfig.PlayerGameRecord[i].playerRecord.ToArray(),
                    ScoreType = _tableConfig.PlayerGameRecord[i].ScoreType,
                    Banker = _tableConfig.PlayerGameRecord[i].BankerChair,
                    huGangCount = this.huGangCount
                });
            }
            GameHost.WriteMessage("游戏记录个数" + this._tableConfig.PlayerGameRecord.Count);
            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_GameRecordResult()
            {
                record = rec.ToArray()
            });
        }

        /// <summary>
        /// 玩家申请解散房间
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="dissTable"></param>
        private void HandleMsg_CMD_C_OfferDissTable(ushort chair, CMD_C_OfferDissTable dissTable)
        {
            if (this._tableConfig.isValid && !this._dissTable.isValid)
            {
                this._ApplyDissTableTime = DateTime.Now;
                this._dissTable.SponsorChair = (byte)chair;

                this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerDissTable()
                {
                    sponsorChair = (byte)chair
                }, false);
                closeOutTimer();
                GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_OutTime, 630, () =>
                {
                    voteDissOutTime();


                    foreach (var player in _playerAry)
                    {
                        if (player.IsOffline)
                        {
                            this.HandleMsg_CMD_C_VoteDissTable(player.PlayerChair, new CMD_C_VoteDissTable()
                            {
                                voteResult = 1
                            });
                        }
                    }

                });
                ////断线玩家自动同意
                //foreach (var player in _playerAry)
                //{
                //    if (player.IsOffline)
                //    {
                //        this.HandleMsg_CMD_C_VoteDissTable(player.PlayerChair, new CMD_C_VoteDissTable()
                //        {
                //            voteResult = 1
                //        });
                //    }
                //}
            }
        }   

        /// <summary>
        /// 是否能够申请解散房间
        /// 
        private bool ifCanOfferDissTable(ushort chair)
        {
            if (this._RefuseDissTableTime == DateTime.MinValue)
            {
                return true;
            }
            DateTime DTN = DateTime.Now;

            int seconds = MahjongGeneralAlgorithm.GetSecondsInTwoTime(_RefuseDissTableTime, DTN);

            if (seconds >= 60)
            {
                return true;
            }


            this.SendGameMsg(chair, new CMD_S_IsDissolution()
            {
                IsDissolution = true
            }, false);


            return false;
        }

        /// <summary>
        /// 解散房间投票超时
        /// </summary>
        private void voteDissOutTime()
        {
            for (int i = 0; i < _dissTable.PlayerVote.Length; i++)
            {
                if (_dissTable.PlayerVote[i] == 0)
                {
                    CMD_C_VoteDissTable vdt = new CMD_C_VoteDissTable();
                    vdt.voteResult = 1;
                    HandleMsg_CMD_C_VoteDissTable((ushort)i, vdt);
                }
            }
        }

        /// <summary>
        /// 解散房间投票
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="dissTableVote"></param>
        private void HandleMsg_CMD_C_VoteDissTable(ushort chair, CMD_C_VoteDissTable dissTableVote)
        {
            if (this._tableConfig.isValid && this._dissTable.isValid && (chair != this._dissTable.SponsorChair))
            {
                //通知其他玩家有人投票了
                this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerVoteDissTable()
                {
                    chair = (byte)chair,
                    vote = dissTableVote.voteResult
                }, false);

                //任何人投拒绝停止本次投票
                if (2 == dissTableVote.voteResult)
                {
                    this._dissTable.clear();
                    closeOutTimer();
                    this._RefuseDissTableTime = DateTime.Now;

                }
                else
                {
                    //如果所有人都同意,解散本次房间
                    if (this._dissTable.playerVote((byte)chair, dissTableVote.voteResult))
                    {
                        //状态设置
                        _gamePhase = enGamePhase.GamePhase_Unknown;
                        closeOutTimer();
                        var dissTableSuccess = new CMD_S_DissTableSuccess()
                        {
                            gameing = 0
                        };
                        //GameHost.SetTableOwner(0);
                        if (_isGameing)
                        {
                            this.OnEventGameEnd(MahjongDef.gInvalidChar, true, true);
                            this._tableConfig.SetGameNum = 0;
                            dissTableSuccess.gameing = 1;
                        }
                        else
                        {
                            this.OnEventGameEnd(MahjongDef.gInvalidChar, true, true);
                            this._tableConfig.GameNum = 0;
                            //_tableConfig.TableCreatorChair = MahjongDef.gInvalidChar;
                            GameEnd();
                        }
                        //_tableConfig.clear();
                        _tableConfig.TableCreatorChair = MahjongDef.gInvalidChar;
                        this.SendGameMsg(MahjongDef.gInvalidChar, dissTableSuccess, false);
                        //foreach (var player in GameHost.PlayerInfoOnTable)
                        //{
                        //    GameHost.PlayerDataService.PostUserExitMessage(player);
                        //}
                        if (this._tableConfig.TableCreatorPay == 3 && GameHost.TableInfo.GroupId > 0) { 
                            GameHost.HostSettlementService.ThawUserAccount(new ThawUserAccountParam()
                            {
                                OrderId = quanZhuID,
                                MoneyNum = 0,
                            }, Rec_BackPay);
                        }

                }
                }
            }
        }

        private void Rec_BackPay(ThawUserAccountResult obj)
        {
            this.PrintLog("圈主支付 钻石返还成功"); 
        }

        #endregion


        #region 发牌相关方法

        /// <summary>
        /// 处理给玩家发牌
        /// </summary>
        /// <returns></returns>
        private bool SendCardToPlayer(bool isUsual = true)
        {
            if (_outCardInfo.isValid && _opPlayerChar != _outCardInfo.chair)
                _playerAry[_outCardInfo.chair].IsJustGang = false;
            _outCardInfo.Clear();
            //检查该玩家牌池是否满了，如果满了结束游戏 黄庄
            if (NeedOverGame)
            {
                GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 10, () =>
                {
                    this.OnEventGameEnd(MahjongDef.gInvalidChar);
                });
                return false;
            }

            //通知当前操作玩家
            this.InformCurOpPlayer();
            //累计抓牌的数量
            if (isUsual)
                mopaiCount++;
            else
                gangNum++;

            //发牌给当前操作玩家
            byte holdCard = MahjongDef.gInvalidMahjongValue;
            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            #region 输赢控制逻辑

            //AI与真人对战时才去控制
            if (_bCtl)
            {
                if (_bOutScore)//出分,让真人赢
                {
                    //if (CurPlayer.IsAIPlayer)//如果当前抓牌玩家为AI
                    //{
                    //    if (rand.Next(0, 100) < _specialAttri.BadProbability)//如果AI已经听牌
                    //    {
                    //        List<byte> vNeedCard = new List<byte>();
                    //        CurPlayer.GetMeNeedCard(vNeedCard, true);

                    //        holdCard = _cardPackage.HoldCardNotInSrc(vNeedCard);
                    //    }
                    //}
                    //else//当前抓牌玩家为真人
                    //{
                    //    //发玩家紧需的牌
                    //    if (rand.Next(0, 100) < _specialAttri.GoodProbability)
                    //    {
                    //        List<byte> vNeedCard = new List<byte>();
                    //        CurPlayer.GetMeNeedCard(vNeedCard, rand.Next(1, 101) > 80);

                    //        holdCard = _cardPackage.HoldCardInSrc(vNeedCard);
                    //    }
                    //}
                }
                else//入分
                {
                    if (CurPlayer.IsAIPlayer)//如果当前抓牌玩家为AI
                    {
                        if (rand.Next(0, 100) < _specialAttri.BadProbability)//如果AI已经听牌
                        {
                            List<byte> vNeedCard = new List<byte>();
                            CurPlayer.GetMeNeedCard(vNeedCard, rand.Next(1, 101) > 80);

                            holdCard = _cardPackage.HoldCardInSrc(vNeedCard);
                        }
                    }
                    else//当前抓牌玩家为真人
                    {
                        //发玩家紧需的牌
                        if (rand.Next(0, 100) < _specialAttri.GoodProbability)
                        {
                            List<byte> vNeedCard = new List<byte>();
                            CurPlayer.GetMeNeedCard(vNeedCard, true);

                            holdCard = _cardPackage.HoldCardNotInSrc(vNeedCard);
                        }
                    }
                }
            }

            #endregion

            //统一处理，未找到合适牌的情况
            if (MahjongDef.gInvalidMahjongValue == holdCard)
            {
                holdCard = _cardPackage.HoldCard();
                
            }

            PrintLog("=======================轮到 " + _opPlayerChar + "号玩家抓牌 ==========================");
            PrintLog("玩家抓牌前手中的活动牌:");
            PrintPlayerHandCard(_opPlayerChar);

            //测试用
            //   holdCard = 0x14;
            //设置当前玩家抓到的牌
            CurPlayer.HoldCard = holdCard;
            PrintPlayerHandCard(_opPlayerChar);
            this._ORCTime = DateTime.Now;

            //发送抓牌信息到所有真人客户端
            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                //玩家抓牌,除去自己其他玩家刚刚杠标志清除
                //_playerAry[i].IsJustGang = (i == _opPlayerChar ? _playerAry[i].IsJustGang : false);

                if (_playerAry[i].IsAIPlayer || _playerAry[i].IsOffline)
                {
                    continue;
                }
                SendGameMsg(i, new CMD_S_PlayerHoldCard()
                {
                    chair = _opPlayerChar,
                    card = (i == _opPlayerChar ? holdCard : MahjongDef.gInvalidMahjongValue),
                    countPai = mopaiCount,
                    gangNum = gangNum,
                    usual = isUsual
                }, false);
            }
            this.SaveMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHoldCard()
            {
                chair = _opPlayerChar,
                card = holdCard,
                countPai = mopaiCount,
                gangNum = gangNum,
                usual = isUsual
            });

            //设置游戏阶段及AI思考间隔
            ConfirmGamePhase();

            //通知当前操作的玩家 查找暗杠，补杠，自摸
            InformCustomOpPlayer(_opPlayerChar);

            //如果玩家豹听 且抓的牌不能自摸 则系统自动出牌
            if (_baoTing[_opPlayerChar] && !CurPlayer.CheckIfCanHuACard(holdCard)){
                HandleMsg_CMD_C_OutCard(_opPlayerChar, holdCard);
            }


            return true;
        }

        /// <summary>
        /// 通知当前操作的玩家
        /// </summary>
        private void InformCurOpPlayer(byte chair = MahjongDef.gInvalidChar, bool saveVideo = true)
        {
            byte timer1;
            foreach (var player in _playerAry)
            {
                player.IfCanOp = player.PlayerChair == _opPlayerChar;
            }
            if (isORC)
            {
                timer1 = (byte)(10 - MahjongGeneralAlgorithm.GetSecondsInTwoTime(_ORCTime, DateTime.Now));
                if (timer1 < 0 || timer1 > 10)
                {
                    timer1 = 1;
                }

            }
            else
            {
                timer1 = 10;
            }
            isORC = false;
            //通知当前活动玩家
            this.SendGameMsg(chair, new CMD_S_ActivePlayer() { playerChair = _opPlayerChar, timer = timer1 }, saveVideo);
        }

        /// <summary>
        /// 确定当前的游戏阶段
        /// </summary>
        private void ConfirmGamePhase()
        {
            //玩家操作阶段
            _gamePhase = enGamePhase.GamePhase_PlayerOP;

            if (CurPlayer.IsAIPlayer)
            {

                //先获取本次AI的结果,再根据结果来确定思考时间
                CurPlayer.AutoOutCard();

                Random randObj = MahjongGeneralAlgorithm.GetRandomObject();

                switch (CurPlayer.AIOperatorResult.enPlayResult)
                {
                    //自摸,1~2秒
                    case enPlayerOperator.PlayerOperator_ZiMo:
                    //暗杠,1~2秒
                    case enPlayerOperator.PlayerOperator_AGang:
                    //补杠,1~2秒
                    case enPlayerOperator.PlayerOperator_BGang:
                        {
                            CurPlayer.WaitSeconds = randObj.Next(1, 2);
                            break;
                        }
                    //打出牌,1~8秒
                    case enPlayerOperator.PlayerOperator_OutCard:
                        {
                            CurPlayer.WaitSeconds = randObj.Next(1, 3);
                            break;
                        }
                }
            }
            else
            {
                CurPlayer.WaitSeconds = MahjongDef.gTrueManWaitSecond;
            }
        }

        /// <summary>
        /// 通知客户端当前操作玩家,操作权限
        /// </summary>
        private void InformCustomOpPlayer(byte chairId, bool saveVideo = true)
        {

            PrintLog("=========通知客户端玩家操作权限(" + _opPlayerChar.ToString() + ")==========");
            CurPlayer.IfCanOp = true;
            //操作超时计时
            startOutTimer();
            //如果当前操作玩家是真人，再检查该玩家否可以杠听胡
            List<byte> gangCard = new List<byte>();

            CurPlayer.FindGangCard(gangCard);
           
            CanZiMo = (byte)(CurPlayer.CheckIfCanHuACard(CurPlayer.HoldCard) ? 1 : 0);
            
            SendGameMsg(_opPlayerChar, new CMD_S_OpPlayer()
            {

                ifCanZiMo = CanZiMo, //(byte)(CurPlayer.CheckIfCanHuACard(CurPlayer.HoldCard) ? 1 : 0),
                gangCard = gangCard.ToArray()

            }, saveVideo);
        }

        #endregion

        #region 初始化相关方法

        /// <summary>
        /// 设置色子信息并发送色子信息
        /// </summary>
        private void SetSZInfo()
        {
            AddLogTitle("骰子及庄家信息");
            CMD_S_SZInfo szInfo = new CMD_S_SZInfo();
            CMD_S_Start start = new CMD_S_Start();

            //随机数种子
            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            szInfo.sz1 = (byte)rand.Next(1, 7);
            szInfo.sz2 = (byte)rand.Next(1, 7);
            if (_someOneLeave)
            {
                szInfo.bankerChair = (byte)this._tableConfig.TableCreatorChair;
                //确定庄家
                _bankerChar = (byte)this._tableConfig.TableCreatorChair;
                _lastBanker = _bankerChar;
                //tempBanker  = (byte)this._tableConfig.TableCreatorChair;
                start.reMain++;
                //lianzhuang = 0;
                szInfo.lianBanker = lianzhuang;
            }
            else
            {
                szInfo.bankerChair = _bankerChar;
                szInfo.lianBanker = lianzhuang;
                
            }
            //_lastBanker = szInfo.bankerChair;
            //发送信息
            SendGameMsg(MahjongDef.gInvalidChar, szInfo);

            GameHost.SaveLog("庄家的椅子号为:" + _bankerChar.ToString());
            GameHost.SaveLog("骰子点数分别为：" + szInfo.sz1.ToString() + " | " + szInfo.sz2.ToString());
        }

        /// <summary>
        /// 加载游戏特殊属性
        /// </summary>
        private void LoadSpecialAttribute()
        {
            AddLogTitle("获取特殊属性");
            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            _specialAttri.Clear();
            int temp = 0;
            //2、好的控制概率
            if (int.TryParse(GameHost.GetRoomInfo.SpareAttrib.Attribute2, out temp))
            {
                _specialAttri.GoodProbability = temp;
            }
            temp = 0;
            //3、坏的控制概率
            if (int.TryParse(GameHost.GetRoomInfo.SpareAttrib.Attribute3, out temp))
            {
                _specialAttri.BadProbability = temp;
            }
            temp = 0;
            //4、超时时间，大于20s小于60s，默认20s
            if (int.TryParse(GameHost.GetRoomInfo.SpareAttrib.Attribute4, out temp))
            {
                if (temp > 10 && temp <= 60)
                    _specialAttri.OutTime = temp;
            }
            temp = 0;
            //5、自创超时，默认为0，自创房间超时不踢人
            if (int.TryParse(GameHost.GetRoomInfo.SpareAttrib.Attribute5, out temp))
            {
                if (temp > 10 && temp <= 60)
                    _specialAttri.OffLineOutTime = temp;
            }
        }

        /// <summary>
        /// 确定本局策略
        /// </summary>
        private void SetPolicy()
        {
            _bOutScore = GameHost.HostMultiplayerGameService.GetOutScore().OutScore > 0;
        }

        /// <summary>
        /// 初始化玩家牌阵
        /// </summary>
        private void InitPlayerCard()
        {
            AddLogTitle("初始化牌阵");
            
            for (short i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                _cardPackage.HoldCard(_playerAry[i].PlayerCard.activeCard.handCard);

                GameHost.SaveLog(i.ToString() + "号位置玩家抓牌:");

                //#region 测试牌阵

                if (i == 0)//_playerAry[i].IsAIPlayer)
                {
                    _playerAry[i].PlayerCard.activeCard.handCard.Clear();
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x37);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x37);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x37);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x13);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x13);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x13);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x14);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x14);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x14);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x16);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x16);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x16);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x13);
                }
                else
                {
                    _playerAry[i].PlayerCard.activeCard.handCard.Clear();
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x37);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x37);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x37);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x04);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x04);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x05);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x05);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x06);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x06);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x21);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x21);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x21);
                    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x11);
                }

                //#endregion

                PrintCardList(_playerAry[i].PlayerCard.activeCard.handCard);

                SendGameMsg(i, new CMD_S_InitCard()
                {
                    cardAry = _playerAry[i].PlayerCard.activeCard.handCard.ToArray()
                });

                //做一次听牌检查
                if (_playerAry[i].TingCheck())
                {
                    CMD_S_Ting ting = new CMD_S_Ting();
                    tingMj[i] = true;
                    ting.TingNum = (ushort)i;
                    SendGameMsg(MahjongDef.gInvalidChar, ting);
                }

            }

            //AddLogTitle("初始化牌阵");

            //for (short i = 0; i < WHMJConstants.GAME_PLAYER; i++)
            //{
            //    byte[,] cards = new byte[4, 13] {

            //    { 0x01, 0x02, 0x03, 0x03, 0x03, 0x04, 0x05, 0x05, 0x05, 0x06, 0x07, 0x08, 0x09 },
            //    { 0x01, 0x01, 0x01, 0x04, 0x04, 0x04, 0x13, 0x14, 0x14, 0x14, 0x14, 0x15, 0x17 },
            //    { 0x21, 0x21, 0x21, 0x21, 0x22, 0x22, 0x22, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27 },
            //    { 0x11, 0x11, 0x11, 0x11, 0x15, 0x16, 0x17, 0x18, 0x19, 0x26, 0x26, 0x27, 0x28 }};

            //    for (int j = 0; j < 13; j++)
            //    {
            //        _playerAry[i].PlayerCard.activeCard.handCard.Add(_cardPackage.HoldCard(cards[i, j]));
            //    }

            //    GameHost.SaveLog(i.ToString() + "号位置玩家抓牌:");

            //    PrintCardList(_playerAry[i].PlayerCard.activeCard.handCard);

            //    SendGameMsg(i, new CMD_S_InitCard()
            //    {
            //        cardAry = _playerAry[i].PlayerCard.activeCard.handCard.ToArray()
            //    });
            //}
        }

        #endregion

        #region 辅助方法

        /// <summary>
        /// 将混皮牌发送到客户端
        /// </summary>
        private void SendHunPiToCustomer(byte chair)
        {
            this.SendGameMsg(chair, new CMD_S_FanKaiHun()
            {
                card = _hunPiCard,
                //  card = 0x07,
            });
        }

        /// <summary>
        /// 取下一个操作的玩家
        /// </summary>
        /// <param name="checkChair"></param>
        private void GetNextOpPlayer(byte checkChair)
        {
            if (0 == LeftGamePlayerNum)
            {
                _opPlayerChar = MahjongDef.gInvalidChar;
                return;
            }

            //找下一个未胡牌的玩家
            do
            {
                checkChair = (byte)((checkChair + 1) % MGMJConstants.GAME_PLAYER);
            } while (_playerAry[checkChair].IsAlreadyHu);

            _opPlayerChar = checkChair;
        }

        /// <summary>
        /// 房主离开,强退所有玩家
        /// </summary>
        private void TableOwnerExitAndForceAll()
        {
            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_ForceUserLeft()
            {
                msg = "房主已经解散房间！"
            }, false);
            foreach (var player in GameHost.PlayerInfoOnTable)
            {
                GameHost.PlayerDataService.PostUserExitMessage(player);
            }

            //this._tableConfig.clear();
        }

        /// <summary>
        /// 房主解散房间,强退所有玩家
        /// </summary>
        private void TableOwnerDeleteTable()
        {
            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_ForceUserLeft()
            {
                msg = "房主已经解散房间！"
            }, false);
            foreach (var player in GameHost.PlayerInfoOnTable)
            {
                GameHost.PlayerDataService.PostUserExitMessage(player);
            }

        }

        /// <summary>
        /// 保留房间,强退所有玩家
        /// </summary>
        private void SaveTableForceAll()
        {
            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_ForceUserLeft()
            {
                msg = "保留房间，因为到时间未开始游戏，房间被解散，退回房费"
            }, false);
            foreach (var player in GameHost.PlayerInfoOnTable)
            {
                GameHost.PlayerDataService.PostUserExitMessage(player);
            }

        }

        /// <summary>
        /// 玩家余额不足,强退玩家
        /// </summary>
        private void NoMoneyForce(ushort chairID)
        {
            //this.SendGameMsg(chairID, new CMD_S_ForceUserLeft()
            //{
            //    msg = s
            //}, false);
            //if (GameHost.PlayerInfoOnTable[chairID].PlayerState == GState.OfflineInGame)
            //    GameHost.PlayerDataService.PostUserExitMessage(GameHost.PlayerInfoOnTable[chairID]);
            GameHost.PlayerDataService.PostUserExitMessage(GameHost.PlayerInfoOnTableSeat[chairID], string.Format("抱歉，您的房卡不足！进入此房间需要{0}张房卡。", _tableConfig.TableCost));

        }

        /// <summary>
        /// 创房数据错误,强退玩家
        /// </summary>
        private void BadCreateForce(ushort chairID)
        {
            //this.SendGameMsg(chairID, new CMD_S_ForceUserLeft()
            //{
            //    msg = "参数错误！"
            //}, false);
            //if (GameHost.PlayerInfoOnTable[chairID].PlayerState == GState.OfflineInGame)
            GameHost.PlayerDataService.PostUserExitMessage(GameHost.PlayerInfoOnTableSeat[chairID], "参数错误！");
        }

        /// <summary>
        /// 玩家强退,其他其他强退玩家
        /// </summary>
        private void playerForceLeftCheckOtherPlayerForce(ushort chair)
        {
            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                if (i == chair)
                {
                    continue;
                }
                if (_playerAry[i].isForceLefting)
                {
                    _gameForceLeftNum[i] = 0;
                }
            }
        }

        /// <summary>
        /// 换房主
        /// </summary>
        private bool changeTableCreator()
        {
            var playerInfoOnTable = this.GameHost.PlayerInfoOnTable;
            if ((null == playerInfoOnTable) || (0 == playerInfoOnTable.Length))
            {
                for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                {
                    _gameForceLeftNum[i] = 0;
                    _curGameUserID[i] = 0;
                }
                this.TableOwnerExitAndForceAll();
                return false;
            }

            byte tableCreator = (byte)this._tableConfig.TableCreatorChair;
            do
            {
                tableCreator = (byte)((tableCreator + 1) % MGMJConstants.GAME_PLAYER);
            } while (null == this.GameHost.PlayerDataService.GetPlayerByChairID(tableCreator) ||
                    _playerAry[tableCreator].IsOffline);

            this._tableConfig.TableCreatorChair = tableCreator;
            this._tableConfig.TableCreatorID = this.GameHost.PlayerDataService.GetPlayerByChairID(tableCreator).UserID;

            //通知宿主换桌主
            this.GameHost.SetTableOwner(this.GameHost.PlayerDataService.GetPlayerByChairID(tableCreator).UserID);

            //通知新的房主
            this.SendTableCreator2Client(MahjongDef.gInvalidChar);

            //房主改变提示
            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_ShowMsg()
            {
                msg = "房主离开游戏,玩家【" + this.GameHost.PlayerDataService.GetPlayerByChairID(tableCreator).NickName + "】成为房主",
                tipType = 1
            });
            return true;
        }

        /// <summary>
        /// 处理玩家断线
        /// </summary>
        /// <param name="chairID"></param>
        private void HandlerPlayerOffline(byte chairID)
        {
            switch (_gamePhase)
            {
                //发牌阶段
                case enGamePhase.GamePhase_SendCard:
                    {
                        PrintLog("<<<" + chairID + "号玩家发牌阶段玩家断线>>>");
                        HandleMsg_CMD_C_HoldCardComplete(chairID);
                        break;
                    }
            }
            if (_tableConfig.isValid && !this._tableConfig.isPlayEnoughGameNum && !this._isGameing)
            {
                this.HandleMsg_CMD_C_NextGame(chairID, new CMD_C_NextGame());
            }
        }

        /// <summary>
        /// 处理玩家断线重连,to do
        /// </summary>
        /// <param name="chairID"></param>
        private void HandlerPlayerOfflineCome(byte chairID)
        {
            isORC = true;
            //断线重连正常处理
            switch (_gamePhase)
            {
                //发牌阶段
                case enGamePhase.GamePhase_SendCard:
                    {
                        PrintLog("<<<" + chairID + "号玩家发牌阶段玩家断线>>>");
                        HandleMsg_CMD_C_HoldCardComplete(chairID);
                        break;
                    }
            }
            //断线重连自主建房,局数没打满处理
            if (_tableConfig.isValid && !this._isGameing) //&& !_playerAry[chairID].IsReady)
            {
                this.SendGameMsg(chairID, new CMD_S_ORC_TableFree()
                {
                    //lianbank = lianzhuang
                }, false);
                foreach (var player in _playerAry)
                {
                    if (player.IsReady)
                    {
                        this.SendGameMsg(MahjongDef.gInvalidChar,
                            new CMD_S_UseReady() { chair = (byte)player.PlayerChair }, false);
                    }
                }
                //如果正在解散房间状态
                if (this._dissTable.isValid)
                {
                    this.SendGameMsg(chairID, new CMD_S_ORC_DissTable()
                    {
                        sponsor = this._dissTable.SponsorChair,
                        playerVote = new List<byte>(this._dissTable.PlayerVote).ToArray(),
                        leftTime = (byte)(60 - MahjongGeneralAlgorithm.GetSecondsInTwoTime(_ApplyDissTableTime, DateTime.Now)),

                    }, false);
                }
                return;
            }



            //1、恢复游戏信息
            this.SendGameMsg(chairID, new CMD_S_ORC_GameInfo()
            {
                bankerChair = this._bankerChar,
                lianBanker = lianzhuang,  // (byte)_playerAry[this._bankerChar].LianBanker,
                gameid = this._gameID,
                gamePhase = (byte)this._gamePhase,
                selfIsAlreadyHu = (byte)(_playerAry[chairID].IsAlreadyHu ? 1 : 0)
            }, false);
            //       SendHunPiToCustomer(chairID);
            //2、恢复牌阵信息
            if (this._gamePhase != enGamePhase.GamePhase_La && this._gamePhase != enGamePhase.GamePhase_Pao)
            {
                var selfCard = new ORCSelfCard();
                selfCard.holdCard = _playerAry[chairID].HoldCard;
                selfCard.handCard = _playerAry[chairID].PlayerCard.activeCard.handCard.ToArray();
                selfCard.poolCard = _playerAry[chairID].PlayerCard.poolCard.ToArray();
                var selfFixed = new List<ORCFixedCard>();
                foreach (var fixedCard in _playerAry[chairID].PlayerCard.fixedCard.fixedCard)
                {
                    selfFixed.Add(new ORCFixedCard()
                    {
                        fixedType = (byte)fixedCard.fixedType,
                        fixedCard = fixedCard.card,
                        outChair = fixedCard.outChair,
                        chiType = fixedCard.chiSel
                    });
                }
                selfCard.fixedCard = selfFixed.ToArray();

                var otherCard = new List<ORCOtherPlayerCard>();
                for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                {
                    if (i == chairID)
                    {
                        continue;
                    }
                    var otherPlayerCard = new ORCOtherPlayerCard();

                    otherPlayerCard.chair = (byte)i;
                    otherPlayerCard.handCardNum = (byte)_playerAry[i].PlayerCard.activeCard.handCard.Count;
                    otherPlayerCard.poolCard = _playerAry[i].PlayerCard.poolCard.ToArray();
                    otherPlayerCard.IsTing = _playerAry[i].IsTing;

                    var otherFixed = new List<ORCFixedCard>();
                    foreach (var fixedCard in _playerAry[i].PlayerCard.fixedCard.fixedCard)
                    {
                        otherFixed.Add(new ORCFixedCard()
                        {
                            fixedType = (byte)fixedCard.fixedType,
                            fixedCard = fixedCard.card,
                            outChair = fixedCard.outChair,
                            chiType = fixedCard.chiSel
                        });
                    }
                    otherPlayerCard.fixedCard = otherFixed.ToArray();

                    otherCard.Add(otherPlayerCard);
                }

                //牌墙数据
                var paiWall = new PaiWalls();
                paiWall.banker = this._bankerChar;
                paiWall.paiCount = mopaiCount;
                paiWall.houPai = gangNum;
                this.SendGameMsg(chairID, new CMD_S_ORC_PlayerCard()
                {
                    selfCard = selfCard,
                    otherPlayerCard = otherCard.ToArray(),
                    paiWall = paiWall
                }, false);

                if (_tableConfig.LaPaoZuo)
                {
                    //List<byte> players1 = new List<byte>();
                    List<byte> players2 = new List<byte>();
                    foreach (var player in _playerAry)
                    {
                        // players1.Add((byte)player.LaNum);
                        players2.Add((byte)player.PaoNum);
                    }
                    //SendGameMsg(chairID, new CMD_S_PlayerLaInfo()
                    //{
                    //    points = players1.ToArray()
                    //}, false);
                    SendGameMsg(chairID, new CMD_S_PlayerPaoInfo()
                    {
                        points = players2.ToArray()
                    }, false);
                }
            }



            //3、恢复阶段信息
            switch (this._gamePhase)
            {
                case enGamePhase.GamePhase_Pao:
                    {
                        if (_playerAry[chairID].IfCanOp)
                        {
                            SendGameMsg(chairID, new CMD_S_StartPao()
                            {
                            }, false);
                        }
                        break;
                    }
                case enGamePhase.GamePhase_La:
                    {
                        if (_tableConfig.LaPaoZuo)
                        {
                            List<byte> players2 = new List<byte>();
                            foreach (var player in _playerAry)
                            {

                                players2.Add((byte)player.PaoNum);
                            }
                            SendGameMsg(chairID, new CMD_S_PlayerPaoInfo()
                            {
                                points = players2.ToArray()
                            }, false);
                        }
                        if (_playerAry[chairID].IfCanOp)
                        {
                            SendGameMsg(chairID, new CMD_S_StartLa()
                            {
                            }, false);
                        }
                        break;
                    }
                //玩家操作
                case enGamePhase.GamePhase_PlayerOP:
                    {
                        //通知当前操作玩家
                        this.InformCurOpPlayer(chairID, false);
                        //通知玩家抓牌与否
                        if ((MahjongDef.gInvalidMahjongValue != _playerAry[_opPlayerChar].HoldCard) &&
                            (chairID != _opPlayerChar))
                        {
                            SendGameMsg(chairID, new CMD_S_PlayerHoldCard()
                            {
                                chair = _opPlayerChar,
                                card = MahjongDef.gInvalidMahjongValue
                            }, false);
                        }
                        //如果是自己操作,通知自己
                        if (chairID == _opPlayerChar)
                        {
                            this.InformCustomOpPlayer(chairID, false);
                        }
                        break;
                    }
                case enGamePhase.GamePhase_QiangGang:
                    {
                        //如果自己可以抢杠,通知自己抢杠
                        if (_waitQiangGangPlayer.Contains(chairID) && _playerAry[chairID].IfCanOp &&
                            _qiangGangInfo.isValid)
                        {
                            SendGameMsg(chairID, new CMD_S_QiangGang()
                            {
                                chair = (byte)_qiangGangInfo.chair,
                                card = _qiangGangInfo.card
                            }, false);
                        }
                        break;
                    }
                //投票
                case enGamePhase.GamePhase_Vote:
                    {
                        this.SendGameMsg(chairID, new CMD_S_ORC_Vote()
                        {
                            chair = (byte)_outCardInfo.chair,
                            card = _outCardInfo.card
                        }, false);

                        if ((MahjongDef.gVoteRightMask_Null != _playerAry[chairID].VoteRight) &&
                            (MahjongDef.gVoteResult_Null == _playerAry[chairID].VoteResult))
                        {
                            this.SendGameMsg(chairID, new CMD_S_VoteRight()
                            {
                                voteCard = _outCardInfo.card,
                                voteRight = _playerAry[chairID].VoteRight
                            }, false);
                        }

                        break;
                    }
                default:///时间极短的unknown阶段
                    {
                        if (_isGameing && _outCardInfo.isValid)
                        {
                            this.SendGameMsg(chairID, new CMD_S_ORC_Vote()
                            {
                                chair = (byte)_outCardInfo.chair,
                                card = _outCardInfo.card
                            }, false);
                        }
                        break;
                    }
            }

            //发送玩家分数变化
            playerScoreChange(chairID);
            //断线重连结束
            if (AlreadyStart)
            {
                this.SendGameMsg(chairID, new CMD_S_ORC_Over()
                {
                    leftCardNum = (byte)_cardPackage.leftCardNum
                }, false);
            }
            else
            {
                this.SendGameMsg(chairID, new CMD_S_ORC_Over()
                {
                    leftCardNum = (byte)_cardPackage.leftCardNum
                }, false);
            }

            //如果正在解散房间状态
            if (this._dissTable.isValid)
            {
                this.SendGameMsg(chairID, new CMD_S_ORC_DissTable()
                {
                    sponsor = this._dissTable.SponsorChair,
                    playerVote = new List<byte>(this._dissTable.PlayerVote).ToArray(),
                    leftTime = (byte)(60 - MahjongGeneralAlgorithm.GetSecondsInTwoTime(_ApplyDissTableTime, DateTime.Now)),

                }, false);
            }

        }

        /// <summary>
        /// 发送玩家分数变化,,颖上麻将发送的当前底的玩家底注
        /// </summary>
        /// <param name="chairID"></param>
        private void playerScoreChange(byte chairID)
        {
            //玩家分数
            List<int> playerScores = new List<int>();
            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                playerScores.Add(0);
            }
            if (_tableConfig.isValid)
            {
                foreach (var pgRecord in _tableConfig.PlayerGameRecord)
                {
                    if (pgRecord.playerRecord.Count == MGMJConstants.GAME_PLAYER)
                    {
                        for (int i = 0; i < pgRecord.playerRecord.Count; i++)
                        {
                            playerScores[i] += pgRecord.playerRecord[i];
                        }
                    }
                }
            }
            for (int i = 0; i < _playerAry.Count; i++)
            {
                playerScores[i] += _playerAry[i].TotalGameScore;
            }
            //玩家分数变化
            this.SendGameMsg(chairID, new CMD_S_ORC_GameScoreChange()
            {
                PlayerScoreChange = playerScores.ToArray()
            }, false);

        }

        /// <summary>
        /// 发送消息至客户端
        /// </summary>
        /// <param name="chairID"></param>
        /// <param name="message"></param>
        /// <param name="saveVideo"></param>
        private void SendGameMsg(int chairID, CustomMessage message, bool saveVideo = true)
        {
            if (null == GameHost)
            {
                GameHost.SaveLog("GameHost is null");
                return;
            }

            //AI或是断线用户不发
            //if ((chairID != MahjongDef.gInvalidChar) && (_playerAry[chairID].IsOffline || _playerAry[chairID].IsAIPlayer))
            //{
            //    return;
            //}

            //记录消息
            GameHost.SendMsgByChairID(chairID == MahjongDef.gInvalidChar ? -1 : chairID, message);

            if (saveVideo)
            {
                this.SaveMsg(chairID, message);
            }

        }

        /// <summary>
        /// 保存录像消息
        /// </summary>
        /// <param name="chairID"></param>
        /// <param name="message"></param>
        /// <param name="saveVideo"></param>
        private void SaveMsg(int chairID, CustomMessage message, bool saveVideo = true)
        {
            if ((null == GameHost) || (null == this._jsonData))
            {
                return;
            }

            //记录消息
            var sendBuffer = GameHost.HostGameReplayHelperServices.Serialzier(message);

            VMessage msg = new VMessage();
            msg.time = this._videoTime;
            msg.chair = chairID;

            foreach (var data in sendBuffer)
            {
                msg.data.Add((int)data);
            }

            this._jsonData.gamemessage.Add(msg);
        }

        /// <summary>
        /// 发送玩家牌阵到客户端
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="sendChair"></param>
        private void SendPlayerCard2Client(ushort chair, byte sendChair)
        {
            List<byte> reaList = new List<byte>(_playerAry[chair].PlayerCard.activeCard.handCard);
            if (_playerAry[chair].HoldCard != MahjongDef.gInvalidMahjongValue && _playerAry[chair].HuCardType != enHuCardType.HuCardType_ZiMo && _playerAry[chair].HuCardType != enHuCardType.HuCardType_GangShangHua)
                reaList.Add(_playerAry[chair].HoldCard);
            this.SendGameMsg(sendChair, new CMD_S_PlayerCardData()
            {
                chair = (byte)chair,
                huCard = _playerAry[chair].HuCard,
                handCard = reaList.ToArray(),
            });
        }

        /// <summary>
        /// 发送牌桌规则到客户端
        /// </summary>
        /// <param name="chair"></param>
        private void SendTableRule2Client(ushort chair)
        {
            //取房间保留时间
            int temp = 0;
            string s = GameHost.HostSystemConfigManger["Table_Time"];
            if (int.TryParse(s, out temp))
            {
                if (temp > 0)
                    _saveTableTime = temp;
            }
            //通知该玩家桌子配置
            this.SendGameMsg(chair, new CMD_S_TableConfig()
            {
                LaPaoZuo = 0,//(byte)(_tableConfig.LaPaoZuo ? 1 : 0),
                //qiduijia = (byte)(_tableConfig.QiDuiJia ? 1 : 0),
                CellScore = 1,//this._tableConfig.CellScore,
                gangkaijia = 1,//(byte)(_tableConfig.GangKaiJia ? 1 : 0),
                bukaojia = (byte)(_tableConfig.BuKaoJia ? 1 : 0),
                GoldCardBaseIdx = _tableConfig.GoldRoomBaseIdx,
                IsRecordScoreRoom = (byte)(this._tableConfig.IsRecordScoreRoom ? 1 : 0),
                TableCreatorID = this._tableConfig.TableCreatorID,
                TableCreatorChair = (byte)this._tableConfig.TableCreatorChair,
                TableCode = this._tableConfig.TableCode,
                SetGameNum = this._tableConfig.SetGameNum,
                GameNum = this._tableConfig.GameNum,

                // GameNum = _dissTable.isValid ? 0 : _tableConfig.GameNum,
                RealGameNum = 0,
                isOutTimeOp = (byte)(_tableConfig.CreatedOutTimeOP ? 1 : 0),
                isSaveTable = (byte)(_isSaveTable ? 1 : 0),
                saveTableTime = _saveTableTime,
                tableCreatorPay = _tableConfig.TableCreatorPay,
                tableCost = _tableConfig.TableCost,

                IfCanSameIP = 1,//不需要
                zhanZhuang = _tableConfig.zhanZhuang,
                gangFen = _tableConfig.gangFen,
                canChi = _tableConfig.canChi,
                daiDaPai = _tableConfig.daiDaPai,
                whoLose = _tableConfig.whoLose,
                PlayerNum = _tableConfig.PlayerNum,
                WaitTimeNum = _tableConfig.WaitTimeNum,
                SetPeiZi = _tableConfig.SetPeiZi,
                DianPao = _tableConfig.DianPao,
                QiangGangHu = _tableConfig.QiangGangHu
            });
        }

        /// <summary>
        /// 更新客户端玩家余额
        /// </summary>
        /// <param name="chairID"></param>
        private void UpdateClientPlayerMoney()
        {
            for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
            {
                this.SendPlayerMoney2Client(GameHost.PlayerDataService.GetPlayerByChairID(i), i, MahjongDef.gInvalidChar);
            }
        }

        /// <summary>
        /// 将player发送给chair玩家
        /// </summary>
        /// <param name="player"></param>
        /// <param name="sendChair"></param>
        private void SendPlayerMoney2Client(PlayerBase player, int chairID, ushort sendChair)
        {
            if (null == player)
            {
                return;
            }
            foreach (var playerInfo in GameHost.PlayerInfoOnTable)
            {
                if (playerInfo.PlayerID == player.UserID)
                {
                    this.SendGameMsg(sendChair, new CMD_S_PlayerMoney()
                    {
                        chair = (byte)chairID,
                        userID = player.UserID,
                        gold = playerInfo.GoldNum,
                        goldCard = playerInfo.QiDouNum,
                        diamond = playerInfo.DiamondsNum
                    }, false);
                }
            }
        }

        /// <summary>
        /// 发送房主信息至客户端
        /// </summary>
        /// <param name="chair"></param>
        private void SendTableCreator2Client(ushort chair)
        {
            this.SendGameMsg(chair, new CMD_S_TableCreatorInfo()
            {
                plyaerID = this._tableConfig.TableCreatorID,
                chair = (byte)this._tableConfig.TableCreatorChair
            });
        }

        #endregion


     

        #region 计时器相关

        /// <summary>
        /// 处理计时器
        /// </summary>
        /// <param name="m_TimeID"></param>
        /// <returns></returns>
        private int HandleTimeMessage(int m_TimeID)
        {
            switch (m_TimeID)
            {
                //AI操作
                case CommonDef.TimerID_AIOP:
                    {
                        ++_videoTime;
                        OnPerformAIGameAction();
                        break;
                    }
                //等待投票
                case CommonDef.TimerID_WaitVote:
                    {
                        HandlePlayerVote();
                        break;
                    }
                //等待准备
                case CommonDef.TimerID_Ready:
                    {
                        HandlePlayerReady();
                        break;
                    }
            }
            return 1;
        }

        /// <summary>
        /// AI操作
        /// </summary>
        /// <returns></returns>
        private bool OnPerformAIGameAction()
        {
            switch (_gamePhase)
            {
                #region 跑阶段
                case enGamePhase.GamePhase_Pao:
                    {
                        for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                        {
                            if (_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && (_playerAry[i].WaitSeconds == 0))
                            {
                                PrintLog(">>" + i.ToString() + "号AI跑结束通知<<");
                                this.HandleMsg_CMD_C_Pao((ushort)i, (byte)_playerAry[i].PaoNum);
                            }
                            else if (!this._tableConfig.isValid && !_playerAry[i].IsAIPlayer && _playerAry[i].IsOffline && _playerAry[i].IfCanOp)
                            {
                                if (_playerAry[i].WaitSeconds == 0)
                                {
                                    PrintLog("| 断线玩家跑结束指令 |");
                                    this.HandleMsg_CMD_C_Pao((ushort)i, 0);
                                }
                                continue;
                            }
                            else if (!_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && _playerAry[i].IfOutOp)
                            {
                                PrintLog("| 断线玩家跑结束指令 |");
                                this.HandleMsg_CMD_C_Pao((ushort)i, 0);
                            }
                        }
                        break;
                    }
                #endregion
                #region 拉阶段
                case enGamePhase.GamePhase_La:
                    {
                        for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                        {
                            if (_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && (_playerAry[i].WaitSeconds == 0))
                            {
                                PrintLog(">>" + i.ToString() + "号AI拉结束通知<<");
                                this.HandleMsg_CMD_C_La((ushort)i, (byte)_playerAry[i].LaNum);
                            }
                            else if (!this._tableConfig.isValid && !_playerAry[i].IsAIPlayer && _playerAry[i].IsOffline && _playerAry[i].IfCanOp)
                            {
                                if (_playerAry[i].WaitSeconds == 0)
                                {
                                    PrintLog("| 断线玩家拉结束指令 |");
                                    this.HandleMsg_CMD_C_La((ushort)i, 0);
                                }
                                continue;
                            }
                            else if (!_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && _playerAry[i].IfOutOp)
                            {
                                PrintLog("| 断线玩家拉结束指令 |");
                                this.HandleMsg_CMD_C_La((ushort)i, 0);
                            }
                        }
                        break;
                    }
                #endregion
                #region 发牌阶段

                case enGamePhase.GamePhase_SendCard:
                    {
                        for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                        {
                            if (_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && (_playerAry[i].WaitSeconds == 0))
                            {
                                PrintLog(">>" + i.ToString() + "号AI抓牌结束通知<<");
                                this.HandleMsg_CMD_C_HoldCardComplete((ushort)i);
                            }
                            else if (!_playerAry[i].IsAIPlayer && _playerAry[i].IsOffline && _playerAry[i].IfCanOp)
                            {
                                if (_playerAry[i].WaitSeconds == 0)
                                {
                                    PrintLog("| 断线玩家发送抓牌结束指令 |");
                                    this.HandleMsg_CMD_C_HoldCardComplete((ushort)i);
                                }
                                continue;
                            }
                            else if (!_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && _playerAry[i].IfOutOp)
                            {
                                PrintLog("| 断线玩家发送抓牌结束指令 |");
                                this.HandleMsg_CMD_C_HoldCardComplete((ushort)i);
                            }
                        }
                        break;
                    }

                #endregion

                #region 玩家操作

                case enGamePhase.GamePhase_PlayerOP:
                    {
                        if (CurPlayer.IsAIPlayer && CurPlayer.IfCanOp && (CurPlayer.WaitSeconds == 0))
                        {
                            PrintLog(_opPlayerChar + "号AI玩家准备开始操作了,操作前他手中的牌如下:");
                            PrintPlayerHandCard(_opPlayerChar);

                            switch (CurPlayer.AIOperatorResult.enPlayResult)
                            {
                                case enPlayerOperator.PlayerOperator_BGang:
                                case enPlayerOperator.PlayerOperator_AGang:        //AI选择暗杠
                                    {
                                        PrintLog(">>AI杠牌操作通知<<");
                                        this.HandleMsg_CMD_C_Gang(_opPlayerChar, CurPlayer.AIOperatorResult.cOpCard);
                                        break;
                                    }
                                case enPlayerOperator.PlayerOperator_OutCard:      //AI选择打出牌
                                    {
                                        PrintLog(">>AI打牌操作通知<<");
                                        this.HandleMsg_CMD_C_OutCard(_opPlayerChar, CurPlayer.AIOperatorResult.cOpCard);
                                        break;
                                    }
                                case enPlayerOperator.PlayerOperator_ZiMo:           //AI选择自摸
                                    {
                                        PrintLog(">>AI自摸操作通知<<");
                                        this.HandleMsg_CMD_C_ZiMo(_opPlayerChar);
                                        break;
                                    }
                            }
                        }
                        else if (!this._tableConfig.isValid && !CurPlayer.IsAIPlayer && CurPlayer.IsOffline && CurPlayer.IfCanOp)
                        {
                            //GameHost.WriteMessage("@@@操作阶段:检查断线玩家");
                            if (CurPlayer.WaitSeconds == 0)
                            {
                                //GameHost.WriteMessage("@@@操作阶段:断线玩家操作");
                                //获取本次AI要进行的操作:杠，自摸，报听
                                clsAIPlay aiPlay = new clsAIPlay();
                                CurPlayer.TMAutoOutCard(ref aiPlay);

                                switch (aiPlay.enPlayResult)
                                {
                                    case enPlayerOperator.PlayerOperator_BGang:
                                    case enPlayerOperator.PlayerOperator_AGang:        //AI选择暗杠
                                        {
                                            PrintLog(">>AI杠牌操作通知<<");
                                            this.HandleMsg_CMD_C_Gang(_opPlayerChar, aiPlay.cOpCard);
                                            break;
                                        }
                                    case enPlayerOperator.PlayerOperator_OutCard:      //AI选择打出牌
                                        {
                                            PrintLog(">>AI打牌操作通知<<");
                                            this.HandleMsg_CMD_C_OutCard(_opPlayerChar, aiPlay.cOpCard);
                                            break;
                                        }
                                    case enPlayerOperator.PlayerOperator_ZiMo:           //AI选择自摸
                                        {
                                            PrintLog(">>AI自摸操作通知<<");
                                            this.HandleMsg_CMD_C_ZiMo(_opPlayerChar);
                                            break;
                                        }
                                }
                            }
                        }
                        else if (!CurPlayer.IsAIPlayer && CurPlayer.IfCanOp && CurPlayer.IfOutOp)
                        {
                            //GameHost.WriteMessage("@@@操作阶段:检查断线玩家");
                            //GameHost.WriteMessage("@@@操作阶段:断线玩家操作");
                            //获取本次AI要进行的操作:杠，自摸，报听
                            clsAIPlay aiPlay = new clsAIPlay();
                            CurPlayer.TMAutoOutCard(ref aiPlay);

                            switch (aiPlay.enPlayResult)
                            {
                                case enPlayerOperator.PlayerOperator_BGang:
                                case enPlayerOperator.PlayerOperator_AGang:        //AI选择暗杠
                                    {
                                        PrintLog(">>AI杠牌操作通知<<");
                                        this.HandleMsg_CMD_C_Gang(_opPlayerChar, aiPlay.cOpCard);
                                        break;
                                    }
                                case enPlayerOperator.PlayerOperator_OutCard:      //AI选择打出牌
                                    {
                                        PrintLog(">>AI打牌操作通知<<");
                                        this.HandleMsg_CMD_C_OutCard(_opPlayerChar, aiPlay.cOpCard);
                                        break;
                                    }
                                case enPlayerOperator.PlayerOperator_ZiMo:           //AI选择自摸
                                    {
                                        PrintLog(">>AI自摸操作通知<<");
                                        this.HandleMsg_CMD_C_ZiMo(_opPlayerChar);
                                        break;
                                    }
                            }

                        }
                        break;
                    }

                #endregion

                #region 投票阶段

                case enGamePhase.GamePhase_Vote:
                    {
                        for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                        {
                            if (_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && (_playerAry[i].VoteResult != MahjongDef.gVoteResult_Null) && (MahjongDef.gVoteRightMask_Null != _playerAry[i].VoteRight) && (CurPlayer.WaitSeconds == 0))
                            {
                                //AI投票
                                PrintLog(">>AI投票操作通知<<");
                                this.HandleMsg_CMD_C_Vote((ushort)i, _playerAry[i].VoteResult);
                            }
                            else if (!this._tableConfig.isValid && !_playerAry[i].IsAIPlayer && _playerAry[i].IsOffline && _playerAry[i].IfCanOp && (_playerAry[i].VoteRight != MahjongDef.gVoteRightMask_Null))
                            {
                                //GameHost.WriteMessage("###投票阶段:检查断线玩家");
                                if (_playerAry[i].WaitSeconds == 0)
                                {
                                    //GameHost.WriteMessage("###投票阶段:断线玩家自动投票");
                                    //能胡就胡,其他全部放弃
                                    if (MahjongGeneralAlgorithm.CheckVoteRight_Hu(_playerAry[i].VoteRight))
                                    {
                                        PrintLog("| 断线玩家投胡票 |");
                                        this.HandleMsg_CMD_C_Vote((ushort)i, MahjongDef.gVoteResult_Hu);
                                    }

                                    else
                                    {
                                        PrintLog("| 断线玩家投放弃票 |");
                                        this.HandleMsg_CMD_C_Vote((ushort)i, MahjongDef.gVoteResult_GiveUp);
                                    }
                                }
                                continue;
                            }
                            else if (!_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && _playerAry[i].IfOutOp && (_playerAry[i].VoteRight != MahjongDef.gVoteRightMask_Null))
                            {
                                //GameHost.WriteMessage("###投票阶段:检查断线玩家");
                                //GameHost.WriteMessage("###投票阶段:断线玩家自动投票");
                                //能胡就胡,其他全部放弃
                                if (MahjongGeneralAlgorithm.CheckVoteRight_Hu(_playerAry[i].VoteRight))
                                {
                                    PrintLog("| 断线玩家投胡票 |");
                                    this.HandleMsg_CMD_C_Vote((ushort)i, MahjongDef.gVoteResult_Hu);
                                }

                                else
                                {
                                    PrintLog("| 断线玩家投放弃票 |");
                                    this.HandleMsg_CMD_C_Vote((ushort)i, MahjongDef.gVoteResult_GiveUp);
                                }
                            }
                        }
                        break;
                    }

                #endregion

                #region 抢杠阶段

                case enGamePhase.GamePhase_QiangGang:
                    {
                        for (int i = 0; i < MGMJConstants.GAME_PLAYER; i++)
                        {
                            if (_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && _waitQiangGangPlayer.Contains((ushort)i) && _playerAry[i].CheckIfCanHuACard(_qiangGangInfo.card) && (_playerAry[i].WaitSeconds == 0))
                            {
                                PrintLog(">>" + i.ToString() + "号AI抢杠通知<<");
                                this.HandleMsg_CMD_C_QiangGang((ushort)i, 1);
                            }
                            else if (!this._tableConfig.isValid && !_playerAry[i].IsAIPlayer && _playerAry[i].IsOffline && _playerAry[i].IfCanOp && _waitQiangGangPlayer.Contains((ushort)i) && _playerAry[i].CheckIfCanHuACard(_qiangGangInfo.card))
                            {
                                //GameHost.WriteMessage("***抢杠阶段:检查断线玩家");
                                if (_playerAry[i].WaitSeconds == 0)
                                {
                                    //GameHost.WriteMessage("***抢杠阶段:断线玩家自动抢杠");
                                    PrintLog("| 断线玩家抢杠 |");
                                    this.HandleMsg_CMD_C_QiangGang((ushort)i, 1);
                                }
                                continue;
                            }
                            else if (!_playerAry[i].IsAIPlayer && _playerAry[i].IfCanOp && _playerAry[i].IfOutOp && _waitQiangGangPlayer.Contains((ushort)i) && _playerAry[i].CheckIfCanHuACard(_qiangGangInfo.card))
                            {
                                //GameHost.WriteMessage("***抢杠阶段:检查断线玩家");
                                //GameHost.WriteMessage("***抢杠阶段:断线玩家自动抢杠");
                                PrintLog("| 断线玩家抢杠 |");
                                this.HandleMsg_CMD_C_QiangGang((ushort)i, 1);
                            }
                        }
                        break;
                    }

                    #endregion
            }
            return true;
        }

        /// <summary>
        /// 开启超时计时
        /// </summary>
        /// <returns></returns>
        private bool startOutTimer()
        {
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_OutTime, _specialAttri.OutTime * 10, () =>
            {
                playerOutTime();
            });
            return true;
        }

        /// <summary>
        /// 关闭超时计时
        /// </summary>
        /// <returns></returns>
        private bool closeOutTimer()
        {
            GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_OutTime);
            return true;
        }

        /// <summary>
        /// 玩家超时
        /// </summary>
        private void playerOutTime()
        {
            foreach (var player in _playerAry)
            {
                if (player.IfCanOp && !_tableConfig.isValid)
                {
                    PrintLog("" + player.PlayerChair + "超时");
                    //this.SendGameMsg(player.PlayerChair, new CMD_S_ForceUserLeft()
                    //{
                    //    msg = "因为你太长时间没有操作,被系统请出房间！"
                    //}, false);
                    player.IfOutOp = true;
                }
                else if (player.IfCanOp && _tableConfig.isValid)
                {
                    if (_gamePhase == enGamePhase.GamePhase_SendCard)
                    {
                        player.IfOutOp = true;
                    }
                    if (_tableConfig.CreatedOutTimeOP)
                    {
                        player.IfOutOp = true;
                    }
                }
                else if (!player.IfCanOp && _tableConfig.isValid)
                {
                    //if (!_tableConfig.CreatedOutTimeOP)
                    //{
                    //    this.SendGameMsg(player.PlayerChair, new CMD_S_ShowMsg()
                    //    {
                    //        msg = "有玩家暂离，请耐心等待！",
                    //        tipType = 1
                    //    }, false);
                    //}
                }
            }

        }

        #endregion

        #region 日志处理

        /// <summary>
        /// 添加一个日志标题
        /// </summary>
        /// <param name="szTitle"></param>
        private void AddLogTitle(string szTitle)
        {
            GameHost.SaveLog(" ");
            GameHost.SaveLog("================================" + szTitle + "================================");
        }

        /// <summary>
        /// 打印一副牌阵
        /// </summary>
        /// <param name="cardList"></param>
        public void PrintCardList(List<byte> cardSrc, byte holdCard = MahjongDef.gInvalidMahjongValue)
        {
            if ((null == cardSrc) || (cardSrc.Count < 1))
            {
                return;
            }

            List<byte> cardList = new List<byte>(cardSrc);
            cardList.Sort();

            StringBuilder szCard = new StringBuilder();
            for (int i = 0; i < cardList.Count; i++)
            {
                szCard.Append(CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(cardList[i])]);
                szCard.Append(i == cardList.Count - 1 ? "" : ",");
            }
            if (MahjongDef.gInvalidMahjongValue != holdCard)
            {
                szCard.Append("  |  抓牌:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(holdCard)]);
            }
            GameHost.SaveLog(szCard.ToString());
        }

        /// <summary>
        /// 获取牌阵列表
        /// </summary>
        /// <param name="cardList"></param>
        /// <returns></returns>
        public string GetCardList(List<byte> cardList)
        {
            if ((null == cardList) || (cardList.Count < 1))
            {
                return "";
            }
            StringBuilder szCard = new StringBuilder();
            for (int i = 0; i < cardList.Count; i++)
            {
                szCard.Append(CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(cardList[i])]);
                szCard.Append(i == cardList.Count - 1 ? "" : ",");
            }
            return szCard.ToString();
        }

        /// <summary>
        /// 打印玩家手中活动牌
        /// </summary>
        /// <param name="charID"></param>
        public void PrintPlayerHandCard(byte charID)
        {
            if (charID < MGMJConstants.GAME_PLAYER)
            {
                List<byte> activeCard = new List<byte>(_playerAry[charID].PlayerCard.activeCard.handCard);
                activeCard.Sort();
                PrintCardList(activeCard, _playerAry[charID].HoldCard);
            }
        }

        /// <summary>
        /// 打印日志
        /// </summary>
        /// <param name="szLog"></param>
        public void PrintLog(string szLog)
        {
            GameHost.SaveLog(_videoTime.ToString() + ":" + szLog);
        }
        #endregion


        //----------------------------------------------- 未使用 ------------------------------

        /// <summary>
        /// 获取可以翻开的牌列表
        /// </summary>
        /// <returns></returns>
        public List<byte> GetCanFanKaiCardAry()
        {
            List<byte> CardAry = new List<byte>();
            CardAry.AddRange(_cardPackage.m_cPackage);

            return CardAry;
        }





    }
}
