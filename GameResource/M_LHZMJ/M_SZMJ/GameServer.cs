﻿using M_LHZMJ_GameMessage;
using MahjongAlgorithmForLHZMJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameIF;
using GameIF.Common;
using System.Threading;
using QL.Common;

namespace M_LHZMJ
{
    


    public class SZMJCMVar
    {
       
        public List<byte> HunCardAry;
        public byte FengQuanFlowerCard;

        public SZMJCMVar()
        {
            HunCardAry = new List<byte>();
            FengQuanFlowerCard = MahjongDef.gInvalidMahjongValue;
        }
        /// <summary>
        /// 设置混牌列表
        /// </summary>
        public void SetHunCard(List<byte> hunCardAry)
        {
            HunCardAry.Clear();
            HunCardAry.AddRange(hunCardAry);
        }

        public List<byte> GetHunCardAry()
        {
            List<byte> Ary = new List<byte>(HunCardAry);
            return Ary;
        }
        /// <summary>
        /// 红中麻将除了花牌以外的字牌
        /// </summary>
        /// <returns></returns>
        public List<byte> ZiCardOutFlower()
        {
            List<byte> ziCardAry = MahjongGeneralAlgorithm.GetDNXB();
            List<byte> cardAry = new List<byte>();
            for (int i = 0; i < ziCardAry.Count; i++)
            {
                if (FengQuanFlowerCard == ziCardAry[i])
                {
                    continue;
                }
                if (HunCardAry.Contains(ziCardAry[i]))
                {
                    continue;
                }
                cardAry.Add(ziCardAry[i]);
            }

            return cardAry;
        }
        /// <summary>
        /// 获取红中麻将花牌
        /// </summary>
        /// <param name="fqzCard">风圈字牌</param>
        /// <returns></returns>
        public List<byte> GetFlowerCard()
        {
            List<byte> flowerAry = new List<byte>();

            if (FengQuanFlowerCard != MahjongDef.gInvalidMahjongValue)//风圈存在值
            {
                if (!HunCardAry.Contains(FengQuanFlowerCard))//混牌不包含风圈
                {
                    flowerAry.Add(FengQuanFlowerCard);
                }
            }

            List<byte> zfb = MahjongGeneralAlgorithm.GetZFB();

            for (int i = 0; i < zfb.Count; i++)//中发白也有可能是混牌而失去作为花牌的属性
            {
                if (HunCardAry.Contains(zfb[i]))
                {
                    continue;
                }
                flowerAry.Add(zfb[i]);
            }
            flowerAry.AddRange(MahjongGeneralAlgorithm.GetCXQD());
            flowerAry.AddRange(MahjongGeneralAlgorithm.GetMLZJ());

            return flowerAry;
        }
        /// <summary>
        /// 获取花牌以外的所有牌
        /// </summary>
        /// <returns></returns>
        public List<byte> GetAllCardOutFlower()
        {
            List<byte> AllCardAry = new List<byte>();
            AllCardAry.AddRange(MahjongGeneralAlgorithm.Get029Wan());
            AllCardAry.AddRange(MahjongGeneralAlgorithm.Get029Tong());
            AllCardAry.AddRange(MahjongGeneralAlgorithm.Get029Tiao());
            AllCardAry.AddRange(ZiCardOutFlower());
            for (int i = 0; i < HunCardAry.Count; i++)//这把有可能的中发白中的混牌给加进来了
            {
                if (!AllCardAry.Contains(HunCardAry[i]))
                {
                    AllCardAry.Add(HunCardAry[i]);
                }
            }
            return AllCardAry;
        }
        /// <summary>
        /// 判断一副牌阵中是否全部是花牌
        /// </summary>
        /// <param name="CardAry"></param>
        /// <returns></returns>
        public bool IsAllFlowerCard(List<byte> CardAry)
        {
            if (CardAry == null)
            {
                return false;
            }
            bool ishp = true;

            List<byte> AllCardAry = GetAllCardOutFlower();

            for (int i = 0; i < CardAry.Count; i++)
            {
                if (AllCardAry.Contains(CardAry[i]))
                {
                    ishp = false;
                }
            }
            return ishp;
        }
        /// <summary>
        /// 一副牌阵中是否包含花牌
        /// </summary>
        /// <param name="CardAry"></param>
        /// <returns></returns>
        public bool IsContansFlowrCard(List<byte> CardAry)
        {
            bool iscf = false;
            if (CardAry == null)
            {
                return iscf;
            }
            List<byte> FlowerAry = GetFlowerCard();
            for (int i = 0; i < CardAry.Count; i++)
            {
                if (FlowerAry.Contains(CardAry[i]))
                {
                    iscf = true;
                }
            }
            return iscf;
        }

        public void clear()
        {
            HunCardAry.Clear();
            FengQuanFlowerCard = MahjongDef.gInvalidMahjongValue;
        }
    }
    /// <summary>
    /// 桌子
    /// </summary>
    public class GameServer : GameIF.GamePlugBaseClass
    {

        
        /// <summary>
        /// 当前操作玩家椅子号
        /// </summary>
        public byte _opPlayerChar;
        ///<summary>
        ///连庄数
        ///</summary>
        public byte lianzhuang = 0;
        //风圈开关
        public byte fengquan = 0;

        /// <summary>
        /// 检查可以投胡票的人数
        /// </summary>
        public byte CanHuNum = 0;
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
        /// 本局是否有AI参与 
        /// </summary>
        public bool _isHaveAIPlayer;
        /// <summary>
        /// 当前阶段 
        /// </summary>
        public enGamePhase _gamePhase;

        ///<summary>
        /// 是否有人离开
        /// </summary>
        private bool _someOneLeave;
        ///<summary>
        /// 庄号
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


     

        //=====================================================//

        /// <summary>
        /// 局号
        /// </summary>
        private string _gameID;


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
        public override int GameID { get { return LHZMJConstants.WHMJ_GAMEID; } }
        /// <summary>
        /// 游戏名称
        /// </summary>
        public override string GameName { get { return LHZMJConstants.GAME_NAME; } }
        /// <summary>
        /// 游戏版本号
        /// </summary>
        public override string GameVersion { get { return LHZMJConstants.GAME_VERSION; } }



        #region 红中麻将添加的内容

        public SZMJCMVar Szmjcmvar = new SZMJCMVar();

        private byte _hunPiCard;
        /// <summary>
        /// 混牌
        /// </summary>
        public byte HunPiCard
        {
            get
            {
                return this._hunPiCard;
            }
            set
            {
                this._hunPiCard = value;
            }
        }
      
        /// <summary>
        /// 获取可以翻开的牌列表
        /// </summary>
        /// <returns></returns>
        public List<byte> GetCanFanKaiCardAry()
        {
            List<byte> CardAry = new List<byte>();
            CardAry.AddRange(MahjongGeneralAlgorithm.Get029Wan());
            CardAry.AddRange(MahjongGeneralAlgorithm.Get029Tong());
            CardAry.AddRange(MahjongGeneralAlgorithm.Get029Tiao());
            CardAry.AddRange(MahjongGeneralAlgorithm.GetDNXB());
            CardAry.AddRange(MahjongGeneralAlgorithm.GetZFB());
            return CardAry;
        }


        /// <summary>
        /// 通过混皮牌获取混牌
        /// </summary>
        /// <param name="card">混皮牌</param>
        /// <returns>成功返回混牌，否则返回无效牌</returns>
        public List<byte> GetHunCardFromHunPiCard(byte card)
        {
            //byte hunCard = MahjongDef.gInvalidMahjongValue;

            List<byte> hunCardAry = new List<byte>();

            if (card == MahjongDef.gInvalidMahjongValue)
            {
                return hunCardAry;
            }
            hunCardAry.Add(0x35);
            //if (this._tableConfig.is4hui)//4混
            //{
            //    if (MahjongGeneralAlgorithm.GetMahjongColor(card) < 3)
            //    {
            //        if (MahjongGeneralAlgorithm.GetMahjongValue(card) != 9)
            //        {
            //            hunCardAry.Add((byte)(card + 1));
            //        }
            //        if (MahjongGeneralAlgorithm.GetMahjongValue(card) == 9)
            //        {
            //            hunCardAry.Add((byte)(card - 8));
            //        }
            //    }
            //    else if (MahjongGeneralAlgorithm.GetMahjongColor(card) == 3)
            //    {
            //        if (MahjongGeneralAlgorithm.GetMahjongValue(card) < 4)
            //        {
            //            hunCardAry.Add((byte)(card + 1));
            //        }

            //        if (MahjongGeneralAlgorithm.GetMahjongValue(card) == 4)
            //        {
            //            hunCardAry.Add(0x31);
            //        }

            //        if (MahjongGeneralAlgorithm.GetMahjongValue(card) >= 5 && MahjongGeneralAlgorithm.GetMahjongValue(card) < 7)
            //        {
            //            hunCardAry.Add((byte)(card + 1));
            //        }

            //        if (MahjongGeneralAlgorithm.GetMahjongValue(card) == 7)
            //        {
            //            hunCardAry.Add(0x35);
            //        }
            //    }
            //}
            //else if (this._tableConfig.is7hui)
            //{
            //    if (MahjongGeneralAlgorithm.GetMahjongColor(card) < 3)
            //    {
            //        if (MahjongGeneralAlgorithm.GetMahjongValue(card) != 9)
            //        {
            //            hunCardAry.Add(card);
            //            hunCardAry.Add((byte)(card + 1));
            //        }
            //        else if (MahjongGeneralAlgorithm.GetMahjongValue(card) == 9)
            //        {
            //            hunCardAry.Add(card);
            //            hunCardAry.Add((byte)(card - 8));
            //        }
            //    }
            //    else if (MahjongGeneralAlgorithm.GetMahjongColor(card) == 3)
            //    {
            //        if (MahjongGeneralAlgorithm.GetMahjongValue(card) < 4)
            //        {
            //            hunCardAry.Add(card);
            //            hunCardAry.Add((byte)(card + 1));
            //        }
            //        else if (MahjongGeneralAlgorithm.GetMahjongValue(card) == 4)
            //        {
            //            hunCardAry.Add(card);
            //            hunCardAry.Add(0x31);
            //        }
            //        else if (MahjongGeneralAlgorithm.GetMahjongValue(card) >= 5 && MahjongGeneralAlgorithm.GetMahjongValue(card) < 7)
            //        {
            //            hunCardAry.Add(card);
            //            hunCardAry.Add((byte)(card + 1));
            //        }
            //        else if (MahjongGeneralAlgorithm.GetMahjongValue(card) == 7)
            //        {
            //            hunCardAry.Add(card);
            //            hunCardAry.Add(0x35);
            //        }
            //    }
            //}

            return hunCardAry;
        }


        #endregion

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
            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                _playerAry.Add(new CPlayerInfo(this));
                this._gameForceLeftNum.Add(0);
                this._curGameUserID.Add(0);
            }
            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                        //        GameHost.SetTableOwner(0);
                        //        //this.SaveTableForceAll();
                        //        this.TableOwnerDeleteTable();
                        //        this._tableConfig.clear();
                        //        _bankerChar = MahjongDef.gInvalidChar;

                        //    }
                        //});
                    }
                    else
                    {
                        GameHost.SetTableOwner(0);
                        //this.SaveTableForceAll();
                        this.TableOwnerDeleteTable();
                        this._tableConfig.clear();
                        _bankerChar = MahjongDef.gInvalidChar;
                    }
                }
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
            _lastBanker = MahjongDef.gInvalidChar;
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

            //if (_dissTable.isValid)
            //{
            //    _tableConfig.createNewGUID(GameHost.HostRandomService.GetNewGuidString());
            //}


            _gameID = "";
            for (short i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                _playerAry[i].Clear();
                //每局强退重置
                _gameForceLeftNum[i] = 0;
                //if (_isNewGroup)
                //{
                //    _playerAry[i].SaveMoney = _tableConfig.JetonScore;
                //}
            }

        }
        /// <summary>
        /// 记录上下文
        /// </summary>
        private void RecordContext()
        {
            //记录场地数据
            /*this._jsonData["room"] = new JsonData();

            this._jsonData["room"]["ID"] = this.GameHost.GetRoomInfo.ID;
            this._jsonData["room"]["GameID"] = this.GameHost.GetRoomInfo.GameID;
            this._jsonData["room"]["AgentID"] = this.GameHost.GetRoomInfo.AgentID;
            this._jsonData["room"]["RoomType"] = (int)this.GameHost.GetRoomInfo.RoomType;
            this._jsonData["room"]["GameType"] = (int)this.GameHost.GetRoomInfo.GameType;
            this._jsonData["room"]["BaseMoney"] = this.GameHost.GetRoomInfo.BaseMoney;
            this._jsonData["room"]["JoinMultiNum"] = this.GameHost.GetRoomInfo.JoinMultiNum;
            this._jsonData["room"]["MaxCount"] = this.GameHost.GetRoomInfo.MaxCount;
            this._jsonData["room"]["RoomLV"] = this.GameHost.GetRoomInfo.RoomLV;
            this._jsonData["room"]["CheckMoneyType"] = (int)this.GameHost.GetRoomInfo.CheckMoneyType;
            this._jsonData["room"]["DisplayOrder"] = this.GameHost.GetRoomInfo.DisplayOrder;
            this._jsonData["room"]["TableCost"] = this.GameHost.GetRoomInfo.TableCost;
            this._jsonData["room"]["Name"] = this.GameHost.GetRoomInfo.Name;
            this._jsonData["room"]["TableCostMoneyType"] = (int)this.GameHost.GetRoomInfo.TableCostMoneyType;

            //记录桌子玩家数据
            this._jsonData["tableplayer"] = new JsonData();
            for (ushort i = 0; i < WHMJConstants.GAME_PLAYER; i++)
            {
                var player = GameHost.PlayerDataService.GetPlayerByChairID(i);
                var playerData = new JsonData();

                if (null != player)
                {
                    playerData["PlayerID"] = player.UserID;
                    playerData["NickName"] = player.NickName;
                    playerData["FaceID"] = player.Header;
                    playerData["PlayerLV"] = player.LV;
                    playerData["VIPLV"] = player.VipLV;
                    playerData["GoldNum"] = player.GoldNum;
                    playerData["GoldCardNum"] = player.GoldCardNum;
                    playerData["DiamondsNum"] = player.DiamondNum;
                    playerData["Gender"] = player.Gender;
                }
                else
                {
                    playerData["PlayerID"] = 0;
                }

                this._jsonData["tableplayer"].Add(playerData);
            }

            //记录消息
            this._jsonData["msg"] = new JsonData();*/
            //记录场地数据
            _jsonData = new JsonData();
            this._jsonData.room.ID = this.GameHost.GetRoomInfo.ID;
            this._jsonData.room.GameID = this.GameHost.GetRoomInfo.GameID;
            this._jsonData.room.RoomType = (int)this.GameHost.GetRoomInfo.RoomType;
            this._jsonData.room.BaseMoney = this.GameHost.GetRoomInfo.BaseMoney;
            this._jsonData.room.JoinMultiNum = this.GameHost.GetRoomInfo.JoinMultiNum;
            this._jsonData.room.MaxCount = this.GameHost.GetRoomInfo.MaxCount;
            this._jsonData.room.RoomLV = this.GameHost.GetRoomInfo.RoomLV;
            this._jsonData.room.CheckMoneyType = (int)this.GameHost.GetRoomInfo.CheckMoneyType;
            this._jsonData.room.TableCost = this.GameHost.GetRoomInfo.TableCost;
            this._jsonData.room.Name = this.GameHost.GetRoomInfo.Name;
            this._jsonData.room.TableCostMoneyType = (int)this.GameHost.GetRoomInfo.TableCostMoneyType;

            //记录桌子玩家数据
            for (ushort i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                    playerData.GoldCardNum = player.MoneyBag.GoldNum;
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
            
            ////自主建房设置局数
            //if (this._tableConfig.isValid && _tableConfig.SetGameNum > 3 && _tableConfig.SetGameNum < 9)
            //{
            //    //注册玩家准备计时器
            //    GameHost.HostTimerService.RegTimerHandle(CommonDef.TimerID_Ready, 1, () =>
            //    {
            //        this.HandleTimeMessage(
            //            CommonDef
            //                .TimerID_Ready);
            //    });
            //}
            //else
            //{
            //    RealGameStart();
            //}
            _dissTable.clear();
            CanHuNum = 0;
            if (_isSaveTable)
            {
                GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_SaveTable);
                //this.GameHost.HostSettlementService.WithHoldRoomCostBack(_payId, 2, p1 =>
                //{
                //});
                //_isSaveTable = false;
            }
            RealGameStart();
            return 0;
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
                //foreach (var player in GameHost.PlayerInfoOnTable)
                //{
                //    if (player.PlayerState == GState.OfflineInGame)
                //        GameHost.PlayerDataService.PostUserExitMessage(player);
                //}
            }
            if (GameHost.GameSceneStatus == 1)
                GameHost.GameEnd();
            GameHost.SetTableOwner(0);
            _tableConfig.GameNum = 0;

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
            
            //设置游戏状态
            //GameHost.GetTableInfo.bPlayStatus = WHMJConstants.GS_MJ_PLAY;

            //自动匹配
            if (!this._tableConfig.isValid)
            {
                this._tableConfig.createNewGUID(GameHost.HostRandomService.GetNewGuidString());
                _tableConfig.CellScore = (int)GameHost.GetRoomInfo.BaseMoney;
            }

            //检查是否新的开始
            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                if (this._curGameUserID[i] != this.GameHost.PlayerDataService.GetPlayerByChairID(i).UserID)
                {
                    this._tableConfig.createNewGUID(GameHost.HostRandomService.GetNewGuidString());
                    break;
                }
            }
            ////新一底开始
            //if (_isNewGroup)
            //{
            //    this._tableConfig.newGameStart();
            //    _isNewGroup = false;
            //}

            //_tableConfig.newRealGameStart();
            this._tableConfig.newGameStart();


            //通知游戏开始
            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_Start()
            {
                gameNum = this._tableConfig.GameNum,
                totalGameNum = this._tableConfig.SetGameNum,
                //realGameNum = this._tableConfig.RealGameNum
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
            liuju = 0;
            GameHost.SaveLog("**************************游戏开始************************\n");
            GameHost.SaveLog("游戏初始化信息");

            //骰子信息
            SetSZInfo();
            _noOneWin = true;
            AddLogTitle("玩家信息");
           



            for (ushort i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                var player = GameHost.PlayerDataService.GetPlayerByChairID(i);
                this._curGameUserID[i] = 0;

                if (null != player)
                {
                    ++_onlinePlayerCount;
                    _isHaveAIPlayer = player.UserID < LHZMJConstants.AIPlayerID ? true : _isHaveAIPlayer;

                    this._curGameUserID[i] = player.UserID;
                    //设置昵称
                    _playerAry[i].NickName = player.NickName;
                    //是否庄家
                    _playerAry[i].IsBanker = i == _bankerChar;
                    //if (_playerAry[i].IsBanker)
                    //    if (_someOneLeave)
                    //        _playerAry[i].LianBanker = 1;
                    //    else
                    //    {
                    //        _playerAry[i].LianBanker++;
                    //    }
                    //else
                    //{
                    //    _playerAry[i].LianBanker = 0;
                    //}
                    //玩家椅子号
                    _playerAry[i].PlayerChair = i;
                    //玩家ID
                    _playerAry[i].PlayerID = player.UserID;
                    //是否AI用户
                    _playerAry[i].IsAIPlayer = player.UserID < LHZMJConstants.AIPlayerID;
                    //玩家断线状态
                    if ((null != GameHost.PlayerInfoOnTableSeat[i]) && (GameHost.PlayerInfoOnTableSeat[i].PlayerState == GState.OfflineInGame))
                    {
                        _playerAry[i].Status = enUserStatus.userStatus_offLine;
                    }
                    //打印日志
                    string PlayType = player.UserID < LHZMJConstants.AIPlayerID ? "<AI>" : "<真人>";

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
            _bCtl = (0 == (temp % LHZMJConstants.GAME_PLAYER) ? false : true);
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

            //if (_tableConfig.LaPaoZuo)
            //{
            //    if (_tableConfig.GameNum % 4 == 1) //4局一跑
            //    {
            //        // 记录游戏阶段
            //        _gamePhase = enGamePhase.GamePhase_Pao;
            //        // 通知客户端开始跑点
            //        this.HandlePao();
            //    }
            //    else
            //    {
            //        // 记录游戏阶段
            //        _gamePhase = enGamePhase.GamePhase_La;
            //        // 通知客户端开始跑点
            //        this.HandleLa();
            //    }

            //}
            //else
            //{

            #region 红中麻将掀开混皮牌

            this._hunPiCard = MahjongDef.gInvalidMahjongValue;

            List<byte> cAry = this.GetCanFanKaiCardAry();
            Random rd = MahjongGeneralAlgorithm.GetRandomObject();
            int sy = rd.Next(0, cAry.Count);
            byte hunpicard = cAry[sy];

            #region 测试用的
            hunpicard = 0x35;
            #endregion



            _hunPiCard = hunpicard;

            this.PrintLog("红中麻将混皮牌：" + _hunPiCard.ToString());
            this.GameHost.WriteMessage("红中麻将混皮牌：" + _hunPiCard.ToString());

            //_cardPackage.HoldCard(hunpicard);//将牌包中的牌减去一张

            //SendHunPiToCustomer(MahjongDef.gInvalidChar);

            List<byte> hunAry = this.GetHunCardFromHunPiCard(this._hunPiCard);

            //SZMJVar.SetHunCard(hunAry);//设置混牌
            this.Szmjcmvar.SetHunCard(hunAry);

            PrintLog("红中麻将混牌:");
            PrintCardList(hunAry);

            this.SendFlowerAryToPlayer();//////////////////////////////将花牌发送到客户端

            #endregion








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
                for (int m = 0; m < LHZMJConstants.GAME_PLAYER; m++)
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
        /// <summary>
        /// 将花牌列表发送到客户端
        /// </summary>
        private void SendFlowerAryToPlayer()
        {
            this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_FlowerCardAry()
            {
                cardAry = this.Szmjcmvar.GetFlowerCard().ToArray(),
            });
        }

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

        //游戏结束
        private void OnEventGameEnd(ushort wChairID, bool forceEnd = false)
        {
            AddLogTitle("游戏结束");
            if (_isSaveTable)//保留房间房费已扣
            {
                //this.GameHost.HostSettlementService.WithHoldRoomCostBack(_payId, 2, p1 =>
                //{
                //});
                _isSaveTable = false;
            }
            //销毁游戏定时器
            GameHost.HostTimerService.DestroyTimer(CommonDef.TimerID_AIOP);
            //状态设置
            _gamePhase = enGamePhase.GamePhase_Unknown;
            this._isGameing = false;
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
                        pos = 0
                    });
                }
                //player.PlayerCard.activeCard.handCard.Sort();
               
                GameHost.WriteMessage("胡牌时手上活动牌：");
                PrintPlayerHandCard((byte)player.PlayerChair);
                playerCard.Add(new PlayerCard()
                {
                    huCard = MahjongDef.gInvalidMahjongValue != player.HoldCard ? player.HoldCard : player.HuCard,
                    handCard = player.PlayerCard.activeCard.handCard.ToArray(),
                    fixedCard = fixedCards.ToArray(),
                    flowerCardAry = player.PlayerCard.flowerCard.ToArray()
                });
            }
            List<PlayerBalance> playerBalance = new List<PlayerBalance>();
            foreach (var player in _playerAry)
            {
                if (player.JieSuan.Count != 11)
                {
                    player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0);
                    player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0); player.JieSuan.Add(0);
                    player.JieSuan.Add(0); player.JieSuan.Add(0);
                }
                player.JieSuan[0] = (byte)(player.IsBanker ? 1 : 0);
                player.JieSuan[1] = (byte)player.LaNum;
                player.JieSuan[2] = (byte)player.PaoNum;
                player.JieSuan[7] = (byte)player.PlayerScore.Gangkai;
                if (_tableConfig.IsGangJiuYou)
                {
                    player.JieSuan[3] = (byte)player.PlayerScore.MingGang;
                    player.JieSuan[4] = (byte)player.PlayerScore.FangGang;
                    player.JieSuan[5] = (byte)player.PlayerScore.BuGang;
                    player.JieSuan[6] = (byte)player.PlayerScore.AnGang;

                }
                playerBalance.Add(new PlayerBalance()
                {
                    HuType = (int)player.HuCardType,
                    FangPao = player.IsFangPao ? 1 : 0,
                    TotalScore = player.TotalGameScore,
                    JieSuan = player.JieSuan.ToArray()// player.HuCardType == enHuCardType.HuCardType_Null ? new List<byte>().ToArray() : player.JieSuan.ToArray()
                });
                if (player.TotalGameScore != 0)
                    _noOneWin = false;
            }
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

                this._tableConfig.PlayerGameRecord.Add(record);
                //如果有人输光，输光者为下底庄，多人从下家开始数
                //if (_isNewGroup && _bankerChar != MahjongDef.gInvalidChar)
                //{
                //    for (int i = 1; i < WWMJConstants.GAME_PLAYER; i++)
                //    {
                //        int temp = (_bankerChar + i) % WWMJConstants.GAME_PLAYER;
                //        if (_playerAry[temp].SaveMoney <= 0)
                //        {
                //            _bankerChar = (byte)temp;
                //            break;
                //        }
                //    }
                //}
            }
            if (_noOneWin)
            {
                foreach (var player in _playerAry)
                {
                    if (player.IsHasGang)
                    {
                        _bankerChar = (byte)((_bankerChar) % LHZMJConstants.GAME_PLAYER);
                        break;
                    }
                }
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
                    payRoomCostUserID = _tableConfig.TableCreatorPay == 2 ? this._tableConfig.TableCreatorID : 0;
                    roomCost = (uint)(this._tableConfig.TableCost);
                }
                //if (_isSaveTable)//保留房间房费已扣
                //{
                //    this.GameHost.HostSettlementService.WithHoldRoomCostBack(_payId, 2, p1 =>
                //    {
                //    });
                //    _isSaveTable = false;
                //}
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
                            //第一局结束算桌费
                            var balance = new PlayerForFeeDataMultiple()
                            {
                                FeeDataType = ForFeeDataType.多人游戏结算,
                                FeeUserCount = userAuditData.Count,
                                Mark = "红中麻将记分场结算",
                                MoneyType = GameHost.GetRoomInfo.CheckMoneyType,
                                NoCheckUserMoney = 1,
                            //    RoomCostPayType = (RoomCostPayType)tableInfo.tableCostType,
                                //PayRoomCostUserID = payRoomCostUserID,
                                RoomCost = roomCost,
                                RoomCostType = this.GameHost.GetRoomInfo.TableCostMoneyType,
                                RoomID = GameHost.GetRoomInfo.ID,
                                UserAuditDataArray = userAuditData.ToArray()
                            };

                            this.GameHost.HostSettlementService.PlayerForFeeMultiple(balance, p1 =>
                            {
                                //this._isGameing = false;
                                //foreach (var player in _playerAry)
                                //{
                                //    SendPlayerCard2Client((byte)player.PlayerChair, MahjongDef.gInvalidChar);
                                //}

                                this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_Balance()
                                {
                                    playerCard = playerCard.ToArray(),
                                    playerBalance = playerBalance.ToArray(),
                                    isPlayEnougnGameNum = (byte)(forceEnd ? 1 : this._tableConfig.isPlayEnoughGameNum ? 1 : 0)
                                });

                                //如果有人一底输光，强推，计分板，然后在下一底开始时清空记录
                                if (!this._tableConfig.isPlayEnoughGameNum)
                                    //发送玩家余额
                                    this.UpdateClientPlayerMoney();
                                //打满局数,游戏结束
                                if (forceEnd || this._tableConfig.isPlayEnoughGameNum)
                                {
                                    this.GameHost.WriteMessage("** 红中麻将,记分场，游戏结束 **");
                                    //通知平台游戏结束
                                    GameEnd();
                                }
                            });
                        }
                    });
                }
                //金币场
                //else
                //{
                //    this.GameHost.HostGameReplayHelperServices.SaveRecord(gameRecordData, p =>
                //    {
                //        if (null == p)
                //        {
                //            throw new Exception("保存录像返回结果为null");
                //        }
                //        else
                //        {
                //            //第一局结束算桌费
                //            var balance = new PlayerForFeeDataMultiple()
                //            {
                //                FeeDataType = ForFeeDataType.多人游戏结算,
                //                FeeUserCount = userAuditData.Count,
                //                Mark = "红中麻将结算",
                //                MoneyType = this.GameHost.GetRoomInfo.CheckMoneyType,
                //                NoCheckUserMoney = 1,
                //                PayRoomCostUserID = payRoomCostUserID,
                //                RoomCost = roomCost,
                //                RoomCostType = this.GameHost.GetRoomInfo.TableCostMoneyType,
                //                RoomID = GameHost.GetRoomInfo.ID,
                //                UserAuditDataArray = userAuditData.ToArray()
                //            };
                //            GameHost.HostSettlementService.PlayerForFeeMultiple(balance, p1 =>
                //            {
                //                this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_Balance()
                //                {
                //                    playerCard = playerCard.ToArray(),
                //                    playerBalance = playerBalance.ToArray(),
                //                    isPlayEnougnGameNum = (byte)(forceEnd ? 1 : this._tableConfig.isPlayEnoughGameNum ? 1 : 0)
                //                });
                //                //发送玩家余额
                //                this.UpdateClientPlayerMoney();

                //                //不限局数 or 打满设置的局数,游戏结束
                //                if (forceEnd || this._tableConfig.isPlayEnoughGameNum)
                //                {
                //                    this.GameHost.WriteMessage("** 红中麻将,金币场，游戏结束 **");
                //                    //通知平台游戏结束
                //                    GameEnd();
                //                }
                //            });
                //        }
                //    });
                //}

            }
            //自动匹配要加桌费
            else
            {
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
                            Mark = "红中麻将结算",
                            MoneyType = this.GameHost.GetRoomInfo.CheckMoneyType,
                            NoCheckUserMoney = 1,
                         //   PayRoomCostUserID = 0,
                            RoomCost = this.GameHost.GetRoomInfo.TableCost,
                            RoomCostType = this.GameHost.GetRoomInfo.TableCostMoneyType,
                            RoomID = GameHost.GetRoomInfo.ID,
                            UserAuditDataArray = userAuditData.ToArray()
                        };
                        GameHost.HostSettlementService.PlayerForFeeMultiple(balance, p1 =>
                        {
                            //this._isGameing = false;
                            //foreach (var player in _playerAry)
                            //{
                            //    SendPlayerCard2Client((byte)player.PlayerChair, MahjongDef.gInvalidChar);
                            //}
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

            ////游戏结束判断
            //if (this._tableConfig.isValid)
            //{
            //    if ( forceEnd||_tableConfig.isPlayEnoughGameNum)//打满局数，真结束
            //        GameHost.GameEnd();
            //    else
            //    {
            //        //注册玩家准备计时器
            //        GameHost.HostTimerService.RegTimerHandle(CommonDef.TimerID_Ready, 1, () => {
            //            this.HandleTimeMessage(CommonDef.TimerID_Ready);
            //        });
            //    }      
            //}
            //else
            //{
            //    GameHost.GameEnd();
            //}
            #endregion

            this._jsonData = null;

            #region 换房主检查

            //检查房主是否还在
            //if (!forceEnd && this._tableConfig.isValid && this._tableConfig.TableCreatorChair != MahjongDef.gInvalidChar)
            //{
            //    //房主不在,或仍是断线状态,其他玩家强制离开
            //    if ((null == this.GameHost.PlayerDataService.GetPlayerByChairID(this._tableConfig.TableCreatorChair)) ||
            //        _playerAry[this._tableConfig.TableCreatorChair].IsOffline)
            //    {

            //        //房主买单模式
            //        //if (this._tableConfig.TableCreatorPay)
            //        //{
            //        if (this._tableConfig.isPlayEnoughGameNum)//打满了设置局数
            //        {
            //            _tableConfig.TableCreatorChair = MahjongDef.gInvalidChar;
            //        }
            //        //}
            //        //else//AA制
            //        //{
            //        //    this.changeTableCreator();
            //        //}
            //    }
            //}
            _completeCount = 0;
            #endregion

            //自建房间,局数未打完,断线玩家自动准备
            if (this._tableConfig.isValid && !this._tableConfig.isPlayEnoughGameNum && !forceEnd)
            {
                for (ushort i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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

        ///// <summary>
        ///// 阶段结束
        ///// </summary>
        ///// <param name="stageid">阶段ID</param>
        ///// <returns></returns>
        //public override int OnStageEnd(int stageid)
        //{
        //    return 0;
        //}
        /// <summary>
        /// 游戏维护处理，主要是房费返回
        /// </summary>
        /// <param name="status"></param>
        /// <param name="MaintainText"></param>
        /// <returns></returns>
        public override int OnServerMaintain(int status, string MaintainText)
        {
            if (status == 1 && _isSaveTable && GameHost.GameSceneStatus != 1)
            {
                //this.GameHost.HostSettlementService.WithHoldRoomCostBack(_payId, 3, p1 =>
                //{
                //});
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

            this.GameHost.WriteMessage("红中麻将消息:" + cm.wMainCmdID.ToString() + " | " + cm.wSubCmdID.ToString());

            if (cm.wMainCmdID == LHZMJConstants.WHMJ_GAMEID)
            {
                switch (cm.wSubCmdID)
                {
                    //抓牌结束
                    case LHZMJMsgID_c2s.CMD_C_HoldCardComplete:
                        {
                            HandleMsg_CMD_C_HoldCardComplete(chairID);
                            break;
                        }
                    //玩家打出牌
                    case LHZMJMsgID_c2s.CMD_C_OutCard:
                        {
                            CMD_C_OutCard pOutCard = cm as CMD_C_OutCard;
                            HandleMsg_CMD_C_OutCard(chairID, pOutCard.outCard);
                            break;
                        }
                    //玩家杠
                    case LHZMJMsgID_c2s.CMD_C_Gang:
                        {
                            CMD_C_Gang pGang = cm as CMD_C_Gang;
                            HandleMsg_CMD_C_Gang(chairID, pGang.gangCard);
                            break;
                        }
                    //玩家自摸
                    case LHZMJMsgID_c2s.CMD_C_ZiMo:
                        {
                            HandleMsg_CMD_C_ZiMo(chairID);
                            break;
                        }
                    //玩家投票
                    case LHZMJMsgID_c2s.CMD_C_Vote:
                        {
                            CMD_C_Vote pVote = cm as CMD_C_Vote;
                            HandleMsg_CMD_C_Vote(chairID, pVote.voteResult);
                            break;
                        }
                    //玩家抢杠
                    case LHZMJMsgID_c2s.CMD_C_QiangGang:
                        {
                            CMD_C_QiangGang qiangGang = cm as CMD_C_QiangGang;
                            HandleMsg_CMD_C_QiangGang(chairID, qiangGang.qiangGang);
                            break;
                        }
                    //请求强退
                    case LHZMJMsgID_c2s.CMD_C_ForceLeft:
                        {
                            CMD_C_ForceLeft forceLeft = cm as CMD_C_ForceLeft;
                            this.HandleMsg_CMD_C_ForceLeft(chairID, forceLeft.PlayerID);
                            break;
                        }
                    //创建桌子
                    case LHZMJMsgID_c2s.CMD_C_CreateTable:
                        {
                            this.HandleMsg_CMD_C_CreateTable(chairID, cm as CMD_C_CreateTable);
                            break;
                        }
                    //向好友求助
                    case LHZMJMsgID_c2s.CMD_C_FriendHelp:
                        {
                            this.HandleMsg_CMD_C_FriendHelp(chairID, cm as CMD_C_FriendHelp);
                            break;
                        }
                    //拒绝帮助好友
                    case LHZMJMsgID_c2s.CMD_C_RejectHelp:
                        {
                            this.HandleMsg_CMD_C_RejectHelp(chairID, cm as CMD_C_RejectHelp);
                            break;
                        }
                    //确认帮助好友
                    case LHZMJMsgID_c2s.CMD_C_HelpFriend:
                        {
                            this.HandleMsg_CMD_C_HelpFriend(chairID, cm as CMD_C_HelpFriend);
                            break;
                        }
                    //查询记录
                    case LHZMJMsgID_c2s.CMD_C_QueryGameRecord:
                        {
                            this.HandleMsg_CMD_C_QueryGameRecord(chairID, cm as CMD_C_QueryGameRecord);
                            break;
                        }
                    //玩家请求解散房间
                    case LHZMJMsgID_c2s.CMD_C_OfferDissTable:
                        {
                            this.HandleMsg_CMD_C_OfferDissTable(chairID, cm as CMD_C_OfferDissTable);
                            break;
                        }
                    //玩家对解散房间进行投票
                    case LHZMJMsgID_c2s.CMD_C_VoteDissTable:
                        {
                            this.HandleMsg_CMD_C_VoteDissTable(chairID, cm as CMD_C_VoteDissTable);
                            break;
                        }
                    //玩家准备下一局
                    case LHZMJMsgID_c2s.CMD_C_NextGame:
                        {
                            this.HandleMsg_CMD_C_NextGame(chairID, cm as CMD_C_NextGame);
                            break;
                        }
                    //玩家准备下一局
                    case LHZMJMsgID_c2s.CMD_C_ReSetScene:
                        {
                            this.HandleMsg_CMD_C_ReSetScene(chairID);
                            break;
                        }
                    //测试客户端保留桌子
                    case LHZMJMsgID_c2s.CMD_C_SaveTable:
                        {
                            this.HandleMsg_CMD_C_SaveTable(chairID);
                            break;
                        }
                    case LHZMJMsgID_c2s.CMD_C_Pao:
                        {
                            CMD_C_Pao pao = cm as CMD_C_Pao;
                            this.HandleMsg_CMD_C_Pao(chairID, pao.point);
                            break;
                        }
                    case LHZMJMsgID_c2s.CMD_C_La:
                        {
                            CMD_C_La la = cm as CMD_C_La;
                            this.HandleMsg_CMD_C_La(chairID, la.point);
                            break;
                        }
                    case LHZMJMsgID_c2s.CMD_C_BuHua:
                        {
                            CMD_C_BuHua buhua = cm as CMD_C_BuHua;
                            HandleMsg_CMD_C_BuHua(chairID, buhua.card);
                            break;
                        }
                    case LHZMJMsgID_c2s.CMD_C_NoZiMo:
                        {  
                            HandleMsg_CMD_C_NoZiMo(chairID);
                            break;
                        }
                    case LHZMJMsgID_c2s.CMD_C_NoGang:
                        {
                            HandleMsg_CMD_C_NoGang(chairID);
                            break;
                        }
                }
            }
            return 0;
        }




     //玩家放弃自摸
       private void HandleMsg_CMD_C_NoZiMo(ushort chair)
        {
            if (_playerAry[chair].IsTing)
            {
                HandleMsg_CMD_C_OutCard(_opPlayerChar, CurPlayer.HoldCard);
            }
            else
            {
                return;
            }
            

        }
       private void HandleMsg_CMD_C_NoGang(ushort chair)
       {
           if (_playerAry[chair].IsTing)
           {
               HandleMsg_CMD_C_OutCard(_opPlayerChar, CurPlayer.HoldCard);
           }
           else
           {
               return;
           }


       }


        /// <summary>
        /// 玩家补花
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void HandleMsg_CMD_C_BuHua(ushort chair, byte card)
        {
            if (!_playerAry[chair].IfCanOp || (_opPlayerChar != chair) || (_gamePhase != enGamePhase.GamePhase_PlayerOP) || !_playerAry[chair].CheckIfCanOutACard(card))
            {
                return;
            }
            //关闭玩家操作超时
            closeOutTimer();
            PrintLog(chair.ToString() + "号玩家补花:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)]);
            
            //设置玩家不可操作
            _playerAry[chair].IfCanOp = true;//自动补花要把此变量设置为true
            _playerAry[chair].IfOutOp = false;
            _playerAry[chair]._havehua++;

            //通知客户端玩家有人补花
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_BuHua()
            {
                chair = (byte)chair,
                huacard = card,
              
            });

            //记录本次补花信息
            PrintLog("打牌前玩家活动牌");
            PrintPlayerHandCard((byte)chair);

            _playerAry[chair].HandleByAfterBuHua(card);//玩家出牌后的处理,检查听牌就是在这里面
            //if()


            //记录当前打牌玩家信息
            _outCardInfo.chair = chair;
            _outCardInfo.card = card;
            PrintLog("打牌后玩家活动牌");
            PrintPlayerHandCard((byte)chair);


            if (_playerAry[chair].PlayerCard.tingCard.Count > 0)
            {
                PrintLog("打完牌之后玩家听的牌:");
                PrintCardList(_playerAry[chair].PlayerCard.tingCard);
            }

            this._gamePhase = enGamePhase.GamePhase_PlayerOP;


            _playerAry[chair].PlayerCard.flowerCard.Add(card);

            //补完花之后
            //8个时间周期后进行投票处理
            //GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            //{
            //没有玩家投票，再将打出的这张牌，放入打牌玩家牌池(补花的牌不能放入牌池中)
            //_playerAry[_outCardInfo.chair].PlayerCard.poolCard.Add(_outCardInfo.card);
            //添加打牌记录
            _outCardRecord.Add(_outCardInfo.card);



            //取下自己玩家椅子号(也就是不操作)
            //_opPlayerChar = _opPlayerChar;

            PrintLog("本次轮到" + _opPlayerChar.ToString() + "号玩家操作");
            //给当前玩家发牌
            SendCardToPlayer();
            //});
        }
        /// <summary>
        /// 处理显示花牌
        /// </summary>
        /// <param name="chair"></param>
        private void HandleShowFlowerCard(byte chair)
        {
            List<byte> activeAry = _playerAry[chair].CopyActiveCard();
            byte flowerCard = MahjongDef.gInvalidMahjongValue;
            List<byte> FlowerAry = this.Szmjcmvar.GetFlowerCard();

            for (int i = 0; i < activeAry.Count; i++)
            {
                if (!FlowerAry.Contains(activeAry[i]))
                {
                    continue;
                }
                flowerCard = activeAry[i];
                break;
            }

            

            if (flowerCard != MahjongDef.gInvalidMahjongValue)
            {
                _gamePhase = enGamePhase.GamePhase_PlayerOP;


                
                    this.HandleMsg_CMD_C_BuHua(chair, flowerCard);
                

            }
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
                Version = LHZMJConstants.GAME_VERSION,
            });
            //朋友圈游戏,创建桌子场
            if (GameHost.GetRoomInfo.RoomType == RoomType.MomentsGame)
            {
                if (null == this.GameHost.TableOnwer || this._tableConfig.isValid)
                {
                    //this.GameHost.WriteMessage(userInfo.NickName + "(" + userInfo.PlayerID + ")进入,TableOnwer.PlayerID=" + this.GameHost.TableOnwer.PlayerID);

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
                            if (_tableConfig.TableCreatorPay < 2 && userInfo.DiamondsNum < _tableConfig.TableCost && _tableConfig.GameNum == 0)
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

                        //预先设置房主信息
                        //this._tableConfig.TableCreatorChair = chairID;
                        //this._tableConfig.TableCreatorID = userInfo.PlayerID;

                        //1、自创房间，房卡档次（具体有几档看游戏设计，例：4档，4局，8局，16局， 4-1:8-2:16-3）
                        string[] str = GameHost.GetRoomInfo.SpareAttrib.Attribute1.Split(',');
                        byte temp = 0;
                        //if (str.Length == _specialAttri.JuShu.Length + 1)
                        //{
                        //    for (int i = 0; i < str.Length - 1; i++)
                        //    {
                        //        string[] str1 = str[i].Split('-');
                        //        if (str1.Length == 3)
                        //        {
                        //            if (byte.TryParse(str1[0], out temp))
                        //            {
                        //                _specialAttri.JuShu[i] = temp;
                        //            }
                        //            if (byte.TryParse(str1[1], out temp))
                        //            {
                        //                _specialAttri.PayKa[i] = temp;
                        //            }
                        //            if (byte.TryParse(str1[2], out temp))
                        //            {
                        //                _specialAttri.PayKa[i + 4] = temp;
                        //            }
                        //        }
                        //    }
                        //}
                        for (int i = 0; i < str.Length; i++)
                        {
                            if (string.IsNullOrEmpty(str[i]))
                            {
                                continue;
                            }
                            string[] oneStr = str[i].Split('_');


                            if (oneStr.Length == 2)
                            {
                                for (int k = 0; k < oneStr.Length; k++)
                                {
                                    string[] str2 = oneStr[k].Split('|');
                                    if (str2.Length == 2)
                                    {
                                        if (byte.TryParse(str2[0], out temp))
                                        {
                                            _specialAttri.JuShu[k] = temp;
                                        }
                                        if (i == 1)
                                        {
                                            if (byte.TryParse(str2[1], out temp))
                                            {
                                                _specialAttri.PayKa[k] = temp;//AA制房卡
                                            }
                                        }
                                        else
                                        {
                                            if (byte.TryParse(str2[1], out temp))
                                            {
                                                _specialAttri.PayKa[k + _specialAttri.JuShu.Length] = temp;//房主一人付房卡
                                            }
                                        }
                                    }
                                }
                            }




                            //if (!byte.TryParse(oneStr[oneStr.Length - 1], out temp))
                            //{
                            //    temp = _specialAttri.JuShu[0];
                            //}


                        }


                            //if (!byte.TryParse(str[str.Length - 1], out temp))
                            //{
                            //    temp = _specialAttri.JuShu[0];
                            //}
                            //通知客户端开始创建房间
                            this.SendGameMsg(chairID, new CMD_S_StartCreateTable()
                            {
                                payKa = _specialAttri.PayKa,
                                juShu = _specialAttri.JuShu,
                                defaultJuShu = temp,
                                Version = LHZMJConstants.GAME_VERSION

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

                for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                        //if (this._tableConfig.TableCreatorPay)
                        //{
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
                                    GameHost.SetTableOwner(0);
                                    this.TableOwnerExitAndForceAll();
                                }
                            }
                        }
                        //}
                        //else//AA制
                        //{
                        //    if (0 == userState)//正常离开,找下一个有效的椅子号玩家
                        //    {
                        //        this.changeTableCreator();
                        //    }
                        //}
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
                    //所有玩家都断线,30分钟后自动解散该房间
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
                //AA制
                //if (_tableConfig.isValid && !_tableConfig.TableCreatorPay && _tableConfig.TableCreatorChair == chairID)
                //{
                //    changeTableCreator();
                //}
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

            // 通知玩家开始跑点
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_StartPao());
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

            if (++_completeCount == LHZMJConstants.GAME_PLAYER)
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

                HandleLa();
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

            if (++_completeCount == LHZMJConstants.GAME_PLAYER)
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
                //AddLogTitle("进入发牌流程");
                ////初始化玩家牌
                //InitPlayerCard();
                //// 设置游戏阶段为发牌阶段
                //_gamePhase = enGamePhase.GamePhase_SendCard;
                //// 设置所有玩家可以操作
                //foreach (var player in _playerAry)
                //{
                //    player.IfCanOp = true;
                //}
                //// 通知客户端开始发牌
                //SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_StartSendCard());
                ///* Added for 操作超时处理 below */
                //GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitOp, 70, HandleOpTimer);
                ///* Added for 操作超时处理 above */
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
                for (int m = 0; m < LHZMJConstants.GAME_PLAYER; m++)
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
                //this.GameHost.HostSettlementService.WithHoldRoomCost(_tableConfig.TableCreatorID, this.GameHost.GetRoomInfo.TableCostMoneyType,
                //(uint)(this._tableConfig.TableCost), "红中麻将房费暂扣" + _tableConfig.TableCode, p =>
                //{
                //    if (p.IsSuccess)
                //    {
                //        this.UpdateClientPlayerMoney();
                //        _isSaveTable = true;
                //        _payId = p.PrePayID;
                //        GameHost.SetTableOwner(_tableConfig.TableCreatorID);
                //        //房费已扣除，房主可以离开。
                //        this.SendGameMsg(chair, new CMD_S_SaveTableSuccess(), false);
                //        GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_SaveTable, _saveTableTime * 60 * 10,
                //            () =>
                //            {
                //                this.GameHost.HostSettlementService.WithHoldRoomCostBack(_payId, 3, p1 =>
                //                {
                //                    this.UpdateClientPlayerMoney();
                //                    _isSaveTable = false;
                //                    GameHost.SetTableOwner(0);
                //                    this.SaveTableForceAll();
                //                    this._tableConfig.clear();
                //                    _bankerChar = MahjongDef.gInvalidChar;

                //                });
                //            });
                //    }
                //    else
                //    {
                //        this.SendGameMsg(chair, new CMD_S_ForceUserLeft()
                //        {
                //            msg = "您的余额不足，保留房间失败！"
                //        }, false);
                //    }
                //    _isSavingTable = false;
                //});
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
                if (++_completeCount >= LHZMJConstants.GAME_PLAYER)//如果所有玩家可以投票
                {
                    AddLogTitle("开始游戏");
                    RealGameStart();
                }
                else
                {
                    this.SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_UseReady() { chair = (byte)chair }, false);
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

            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                if (_playerAry[i].IsReady)
                {
                    ++_completeCount;
                }
            }

            if (_completeCount == LHZMJConstants.GAME_PLAYER)//如果所有玩家可以投票
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
           
            if (!_playerAry[chair].IfCanOp || (_gamePhase != enGamePhase.GamePhase_SendCard))
            {
                return;
            }

            PrintLog(chair.ToString() + "号玩家抓牌结束,已经结束人数:" + (_completeCount + 1));
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            if (++_completeCount == LHZMJConstants.GAME_PLAYER)
            {
                //关闭超时计时
                closeOutTimer();
                foreach (var player in _playerAry)
                {
                    player.TingCheck();

                    //将玩家最新手牌数据发给玩家
                    this.SendGameMsg(player.PlayerChair, new CMD_S_HandCardData()
                    {
                        handCardData = player.PlayerCard.activeCard.handCard.ToArray()
                    });
                }

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
            _playerAry[chair]._outcard = false;
           

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
            if (Szmjcmvar.GetHunCardAry().Contains(card)){
                _playerAry[chair]._havehun++;
            }

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

          //  CMD_S_Ting ting = new CMD_S_Ting();

            if (_playerAry[chair].PlayerCard.tingCard.Count > 0)
            {
               // _playerAry[chair].IsTing = true;
                PrintLog("打完牌之后玩家听的牌:");
                PrintCardList(_playerAry[chair].PlayerCard.tingCard);
             //   ting.TingNum = chair;
           //     SendGameMsg(chair, ting);          
            }

            this._gamePhase = enGamePhase.GamePhase_Unknown;
            //if (_tableConfig.DianPao || _tableConfig.CanPeng)
            //{
            //8个时间周期后进行投票处理
            //GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitVote, 8, () =>
            //{
            this.HandleTimeMessage(CommonDef.TimerID_WaitVote);
            //});
            //}
            //else
            //{
            //    //不能碰，不能点炮，只能自摸
            //    //8个时间周期后进行投票处理
            //    GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            //    {
            //        //没有玩家投票，再将打出的这张牌，放入打牌玩家牌池
            //        _playerAry[_outCardInfo.chair].PlayerCard.poolCard.Add(_outCardInfo.card);
            //        //添加打牌记录
            //        _outCardRecord.Add(_outCardInfo.card);

            //        //取下一个操作玩家椅子号
            //        GetNextOpPlayer((byte)_outCardInfo.chair);
            //        PrintLog("本次轮到" + _opPlayerChar.ToString() + "号玩家操作");
            //        //给当前玩家发牌
            //        SendCardToPlayer();
            //    });
            //}



        }

        /// <summary>
        /// 处理玩家能否投票
        /// </summary>
        private void HandlePlayerVote()
        {
            AddLogTitle("开始检查玩家投票权限");

            _completeCount = 0;
            Random rand = MahjongGeneralAlgorithm.GetRandomObject();

            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                _playerAry[i].IfCanOp = false;
                _playerAry[i].ClearVote();

                if (_playerAry[i].IsAlreadyHu || (i == _outCardInfo.chair))
                {
                    if (i != _outCardInfo.chair&&_playerAry[i].IsTing==false)
                    {
                        if (_playerAry[i].CheckIfCanVote(_outCardInfo.card, enHuCardType.HuCardType_PingHu, _outCardInfo.chair, true))
                        {
                            _playerAry[i].canVote = true;
                        _playerAry[i].IfCanOp = true;
                        ++_completeCount;

                        if (_playerAry[i].IsAIPlayer)//如果是AI
                        {
                            PrintLog(i.ToString() + "号AI玩家可以进行投票");
                            _playerAry[i].VoteResult = MahjongDef.gVoteResult_Ting;

                            if (MahjongDef.gVoteResult_Null == _playerAry[i].VoteResult)
                            {
                                _playerAry[i].VoteResult = MahjongDef.gVoteResult_GiveUp;
                            }

                            //根据投票结果来确定AI思考时间
                            switch (_playerAry[i].VoteResult)
                            {
                              
                                //投票听
                                case MahjongDef.gVoteResult_Ting:
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
                                    voteRight = _playerAry[i].VoteRight
                                });
                            }
                        }
                        }
                    }
                    continue;
                }
                if (_playerAry[i].CheckIfCanVote(_outCardInfo.card, enHuCardType.HuCardType_PingHu, _outCardInfo.chair,false))
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
                       
                            ////投票胡
                            //case MahjongDef.gVoteResult_Hu:
                            //    {
                            //        _playerAry[i].WaitSeconds = rand.Next(1, 2);
                            //        break;
                            //    }
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
                                voteRight = _playerAry[i].VoteRight
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
                        //if (!this.CheckQiangGang(chair, card))
                        //{
                            this.HandlePlayerBuGang(chair, card);
                        //}
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
            //if (_playerAry[chair].BaoJing())
            //{
            //    _playerAry[chair].IsBaoJing = true;
            //    //报警
            //    SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_BaoJing()
            //    {
            //        chair = (byte)chair,
            //    }, false);
            //}
            _opPlayerChar = (byte)chair;

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行投票处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                //杠牌玩家继续抓牌打牌
                SendCardToPlayer();
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
                }
            }

            if (_waitQiangGangPlayer.Count > 0)//有抢杠玩家,进入抢杠阶段
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
            _playerAry[chair].DianGangPlayer = (byte)chair;

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

            //CMD_S_WindAndRain windAndRain = new CMD_S_WindAndRain();
            //windAndRain.chair = (byte)chair;
            //windAndRain.gangType = (byte)enGangType.BuGang;
            //windAndRain.gangScore = new int[XZMJConstants.GAME_PLAYER];
            //Array.Clear(windAndRain.gangScore, 0, XZMJConstants.GAME_PLAYER);

            ////处理杠分
            //foreach (var player in _playerAry)
            //{
            //    if (player.IsAlreadyHu || (chair == player.PlayerChair))
            //    {
            //        continue;
            //    }
            //    gangRecord.AddPayPlayer(player.PlayerChair, 1 * _tableConfig.CellScore);
            //    player.PlayerGangRecord.LoseGangScore = (0 - 1 * _tableConfig.CellScore);

            //    gameFlow.PlayerScore[player.PlayerChair] -= 1 * _tableConfig.CellScore;
            //    gameFlow.PlayerScore[chair] += 1 * _tableConfig.CellScore;

            //    windAndRain.gangScore[chair] += 1 * _tableConfig.CellScore;
            //    windAndRain.gangScore[player.PlayerChair] -= 1 * _tableConfig.CellScore;
            //}



            //通知客户端有玩家补杠牌了
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerBuGangCard()
            {
                chair = (byte)chair,
                card = card
            });
            //if (_playerAry[chair].BaoJing())
            //{
            //    _playerAry[chair].IsBaoJing = true;
            //    //报警
            //    SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_BaoJing()
            //    {
            //        chair = (byte)chair,
            //    }, false);
            //}
            //SendGameMsg(MahjongDef.gInvalidChar, windAndRain);

            _opPlayerChar = (byte)chair;

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行投票处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                //杠牌玩家继续抓牌打牌
                SendCardToPlayer();
            });
            //杠牌玩家继续抓牌打牌
            //SendCardToPlayer();
        }
        #endregion

        /// <summary>
        /// 根据座位号或者下标来获得该玩家的杠分
        /// </summary>
        /// <returns></returns>
        int GangScore(ushort chair)
        {
            int tempgang = 0;
            for (int i = 0; i < _playerAry[chair].PlayerCard.fixedCard.fixedCard.Count; i++)
            {
                if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[i].fixedType == enFixedCardType.FixedCardType_AGang)
                {
                
                        tempgang += 2;
                    
                }
                if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[i].fixedType == enFixedCardType.FixedCardType_BGang)
                {            
                        tempgang ++;             
                }
                if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[i].fixedType == enFixedCardType.FixedCardType_MGang)
                {
                    
                }
            }

            return tempgang;
        }




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
            _lastBankerWin = _playerAry[chair].IsBanker;//
            _bankerChar = (byte)chair;
            //if (_bankerChar != (byte)chair)
            //{
            //    _bankerChar = (byte)((_bankerChar + 1) % LHZMJConstants.GAME_PLAYER);
            //}
            
            _playerAry[chair].IfCanOp = false;
            _playerAry[chair].IfOutOp = false;
            //GameHost.WriteMessage("zimo1");
            //自摸操作
            closeOutTimer();
            byte cbHuCard = CurPlayer.HoldCard;
            int multiple = CurPlayer.HandleByHu(cbHuCard, CurPlayer.IsJustGang ? enHuCardType.HuCardType_GangShangHua : enHuCardType.HuCardType_ZiMo);
            //GameHost.WriteMessage("总：" + multiple);
            _noOneWin = false;
            //加番
            int tempjia = 0;

            if (_tableConfig.GangKaiJia)
            {
                if (_playerAry[chair].IsJustGang)
                {
                    _playerAry[chair].JieSuan[7] = 1;
                    _playerAry[chair].PlayerScore.Gangkai = 1;
                    
                }
                tempjia += _playerAry[chair].JieSuan[7] > 0 ? 2 : 0;
            }
            if (_playerAry[chair].PlayerCard.poolCard.Count == 0 && _playerAry[chair]._outcard&&_tableConfig.ifCanTianHu)
            {
                tempjia += 3;
                _playerAry[chair].JieSuan[8] = 1;
            }
            //检查是否是门清
            if (CheckPengShou(chair))
            {
                tempjia += 2;
            }
            //if (_playerAry[chair]._havehun > 0&&_tableConfig.isChuHunJiaFan)
            //{
            //    tempjia *= _playerAry[chair]._havehun * 2;
            //    _playerAry[chair].JieSuan[10] = (byte)_playerAry[chair]._havehun;

            //}

            //if (_tableConfig.BuKaoJia)
            //{
            //    tempjia *= CurPlayer.JieSuan[9] > 0 ? 2 : 1;
            //}
            //int tempgang = 0;
            //if (!_tableConfig.IsGangJiuYou)
            //{
            //    //杠分
            //    tempgang = CurPlayer.JieSuan[3] + CurPlayer.JieSuan[5] + CurPlayer.JieSuan[6] * 2;
            //}


            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                if ((i != chair) && !_playerAry[i].IsAlreadyHu)
                {

                    if (_playerAry[chair].IsBanker||_playerAry[i].IsBanker)
                    {

                        _playerAry[i].PlayerScore.huScore -= (multiple + tempjia +GangScore((ushort)i))* _tableConfig.CellScore;
                        _playerAry[chair].PlayerScore.huScore += (multiple + tempjia + GangScore((ushort)i) )* _tableConfig.CellScore;
                    }
                    else
                    {
                        _playerAry[i].PlayerScore.huScore -= (multiple  +tempjia + GangScore((ushort)i)) * _tableConfig.CellScore;
                        _playerAry[chair].PlayerScore.huScore += (multiple +tempjia + GangScore((ushort)i) )* _tableConfig.CellScore;
                    }

                }
            }

            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                if (_playerAry[i].PlayerCard.fixedCard.fixedCard.Count>0)
                {

                    for (int j = 0; j < _playerAry[i].PlayerCard.fixedCard.fixedCard.Count; j++)
                    {

                        if(_playerAry[i].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_MGang)
                        {
                            _playerAry[i].PlayerScore.huScore += 3;
                        }

                    }
                }
                _playerAry[i].PlayerScore.huScore -= _playerAry[i].fanggang*3;
            }
            //}
            //GameHost.WriteMessage("总：" + multiple);
            PrintLog(_opPlayerChar.ToString() + "号玩家自摸:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(cbHuCard)]);

            //发送自摸玩家
            SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHuCard()
            {
                chair = (byte)chair,
                card = cbHuCard,
                huType = (byte)(enHuCardType.HuCardType_ZiMo),
                huScore = null
            });

            //SendPlayerCard2Client(chair, MahjongDef.gInvalidChar);

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行结算处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                this.OnEventGameEnd(MahjongDef.gInvalidChar);
            });
        }

        #endregion



        private bool CheckPengShou(int chair)
        {
            if (_playerAry[chair].PlayerCard.fixedCard.fixedCard.Count == 0)
            {
                return true;
            }
            else
            {
                for (int j = 0; j < _playerAry[chair].PlayerCard.fixedCard.fixedCard.Count; j++)
                {

                    if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_MGang)
                    {
                        return false;
                    }
                    if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_BGang)
                    {
                        return false;
                    }
                    if (_playerAry[chair].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_Peng)
                    {
                        return false;
                    }
                }
            }
            return true;
        
        }



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

            //弃听检查
            if ((MahjongDef.gVoteResult_GiveUp == voteResult) && MahjongGeneralAlgorithm.CheckVoteRight_Ting(_playerAry[chair].VoteRight))
            {
                _playerAry[chair].checkGiveUpTing();
               
            }

            //弃碰检查
            if ((MahjongDef.gVoteResult_GiveUp == voteResult) && MahjongGeneralAlgorithm.CheckVoteRight_Peng(_playerAry[chair].VoteRight) &&( _playerAry[chair].VoteRight!=0x05))
            {
                _playerAry[chair].checkGiveUpPeng(_outCardInfo.card);
            }

            if (voteResult == MahjongDef.gVoteResult_Ting)
            {

                _playerAry[_outCardInfo.chair].IsJustGang = false;
                this.PlayerTing(chair);
                



            }





            //投票听
            if (voteResult == 3 && CanHuNum == 1)
            {
                for (int i = 1; i < LHZMJConstants.GAME_PLAYER; i++) //不带一炮多响，从出牌者的下家开始找起
                {
                    int temp = (i + _outCardInfo.chair) % LHZMJConstants.GAME_PLAYER;
                    if (MahjongDef.gVoteResult_Hu == _playerAry[temp].VoteResult)
                    {
                        //   huPlayer.Add(_playerAry[temp].PlayerChair);
                        this.PlayerHuCard(_playerAry[temp].PlayerChair, _outCardInfo.card);
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
            else
                if (0 == _completeCount)//所有可以投票的玩家都已经投完票
                {
                    //关闭投票超时
                    closeOutTimer();
                    //1、找投胡牌票的
                    List<ushort> huPlayer = new List<ushort>();

                    if (!_tableConfig.YiPaoDuoXiang)
                    {

                        for (int i = 1; i < LHZMJConstants.GAME_PLAYER; i++) //不带一炮多响，从出牌者的下家开始找起
                        {
                            int temp = (i + _outCardInfo.chair) % LHZMJConstants.GAME_PLAYER;
                            if (MahjongDef.gVoteResult_Hu == _playerAry[temp].VoteResult)
                            {
                                huPlayer.Add(_playerAry[temp].PlayerChair);
                                this.PlayerHuCard(_playerAry[temp].PlayerChair, _outCardInfo.card);
                                break;
                            }
                        }
                    }
                    else
                    {
                        foreach (var player in _playerAry)
                        {
                            if (MahjongDef.gVoteResult_Hu == player.VoteResult)
                            {
                                huPlayer.Add(player.PlayerChair);
                                this.PlayerHuCard(player.PlayerChair, _outCardInfo.card);
                            }
                        }
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
                    ////3、找投听的
                    //foreach (var player in _playerAry)
                    //{
                    //    if (MahjongDef.gVoteResult_Ting == player.VoteResult)
                    //    {
                           
                    //        return;
                    //    }
                    //}
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
        /// <summary>
        /// 处理玩家投票听牌
        /// </summary>
        /// <param name="chair"></param>
        private void PlayerTing(ushort chair)
        {
            PrintLog(chair.ToString() + "号玩家听牌:");
            CMD_S_Ting ting= new CMD_S_Ting();
            ting.TingNum = chair;
            SendGameMsg(MahjongDef.gInvalidChar, ting);
            _playerAry[chair].IsTing = true;
            if (this._gamePhase == enGamePhase.GamePhase_Vote)
            {
                return;

            }

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //取下一个操作玩家椅子号
            GetNextOpPlayer((byte)_outCardInfo.chair);
            //玩家继续抓牌打牌
           
                SendCardToPlayer();
            
            
        
            
           
        }

        /// <summary>
        /// 取下一个玩家椅子号
        /// </summary>
        /// <param name="chair"></param>
        /// <returns></returns>
        private int nextChair(ushort chair){
            int opchair=((int)chair + 1)%4;
            return opchair;

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
            //if (_playerAry[chair].BaoJing())
            //{
            //    _playerAry[chair].IsBaoJing = true;
            //    //报警
            //    SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_BaoJing()
            //    {
            //        chair = (byte)chair,
            //    }, false);
            //}
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

            /*

            //通知当前操作的玩家
            InformCurOpPlayer();

            //设置游戏阶段及AI思考间隔
            ConfirmGamePhase();

            //通知当前操作的玩家
            InformCustomOpPlayer();

            */
        }

        /// <summary>
        /// 处理玩家投票杠
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void PlayerVoteGang(ushort chair, byte card, ushort dianGangPlayer)
        {
            liuju++;
            List<byte> ziCardAry = MahjongGeneralAlgorithm.GetDNXB();
            if (ziCardAry.Contains(card))
            {
                _playerAry[chair]._havegang++;
            }
            _playerAry[dianGangPlayer].fanggang++;
            PrintLog(chair.ToString() + "号玩家明杠:" + CommonDef.gChineseCard[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)]);
            _playerAry[chair].HandleByAfterMGang(card, (byte)_outCardInfo.chair);
            _rememberCard.GangCard(card);
            _playerAry[chair].DianGangPlayer = (byte)dianGangPlayer;

            if (_playerAry[chair].PlayerCard.tingCard.Count > 0)
            {
                PrintLog("明杠后玩家听的牌:");
                PrintCardList(_playerAry[chair].PlayerCard.tingCard);
            }

            _playerAry[chair].PlayerScore.MingGang++;
            _playerAry[dianGangPlayer].PlayerScore.FangGang++;
            //clsSingleGangRecord gangRecord = new clsSingleGangRecord();
            //gangRecord.GangType = enGangType.MingGang;
            //gangRecord.AddPayPlayer(dianGangPlayer, 2 * _tableConfig.CellScore);
            //_playerAry[chair].PlayerGangRecord.GangRecord.Add(gangRecord);

            //_playerAry[dianGangPlayer].PlayerGangRecord.LoseGangScore = (0 - 2 * _tableConfig.CellScore);

            //CMD_S_WindAndRain windAndRain = new CMD_S_WindAndRain();
            //windAndRain.chair = (byte)chair;
            //windAndRain.gangType = (byte)enGangType.BuGang;
            //windAndRain.gangScore = new int[WHMJConstants.GAME_PLAYER];
            //Array.Clear(windAndRain.gangScore, 0, WHMJConstants.GAME_PLAYER);

            //clsGameFlow gameFlow = new clsGameFlow()
            //{
            //    PlayerChair = chair,
            //    PlayerID = _playerAry[chair].PlayerID,
            //    FlowType = enGameFlowType.GameFlow_MingGang
            //};
            //gameFlow.PlayerScore[dianGangPlayer] -= 2 * _tableConfig.CellScore;
            //gameFlow.PlayerScore[chair] += 2 * _tableConfig.CellScore;
            //_gameFlow.Add(gameFlow);

            //windAndRain.gangScore[chair] += 2 * _tableConfig.CellScore;
            //windAndRain.gangScore[dianGangPlayer] -= 2 * _tableConfig.CellScore;

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
            //if (_playerAry[chair].BaoJing())
            //{
            //    _playerAry[chair].IsBaoJing = true;
            //    //报警
            //    SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_BaoJing()
            //    {
            //        chair = (byte)chair,
            //    }, false);
            //}
            //SendGameMsg(MahjongDef.gInvalidChar, windAndRain);

            _opPlayerChar = (byte)chair;

            this._gamePhase = enGamePhase.GamePhase_Unknown;

            //8个时间周期后进行投票处理
            GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 8, () =>
            {
                //杠牌玩家继续抓牌打牌
                SendCardToPlayer();
            });

            //杠牌玩家继续抓牌打牌
            //SendCardToPlayer();
        }

        /// <summary>
        /// 处理玩家投票胡牌
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="card"></param>
        private void PlayerHuCard(ushort chair, byte card)
        {
            _playerAry[chair].IfCanOp = false;
            _outCardRecord.Add(card);
            int multiple = 0;//_playerAry[chair].HandleByHu(card, enHuCardType.HuCardType_PingHu);
            // int multiple = _playerAry[chair].HandleByHu(card, _playerAry[_outCardInfo.chair].IsJustGang ? enHuCardType.HuCardType_GangShaPao : enHuCardType.HuCardType_ZiMo);


            if (_playerAry[_outCardInfo.chair].IsJustGang)
            {
                multiple = _playerAry[chair].HandleByHu(card, enHuCardType.HuCardType_PingHu) + 1;
            }
            else
            {
                multiple = _playerAry[chair].HandleByHu(card, enHuCardType.HuCardType_PingHu);
            }
            GameHost.WriteMessage("总：" + multiple);
            _noOneWin = false;
            //加番
            int tempjia = 1;

            if (_tableConfig.GangKaiJia)
            {
                tempjia *= _playerAry[chair].JieSuan[7] > 0 ? 2 : 1;
            }
            if (_tableConfig.BuKaoJia)
            {
                tempjia *= _playerAry[chair].JieSuan[9] > 0 ? 2 : 1;
            }
            if (_playerAry[_outCardInfo.chair].IsJustGang)
            {
                tempjia = 2;
                _playerAry[chair].JieSuan[9] = 1;
            }
            //杠分
            int tempgang = 0;

            if (!_tableConfig.IsGangJiuYou)
            {
                tempgang = _playerAry[chair].JieSuan[3] + _playerAry[chair].JieSuan[5] + _playerAry[chair].JieSuan[6] * 2;
            }


            if (_playerAry[chair].IsBanker || _playerAry[_outCardInfo.chair].IsBanker)
            {
                //拉跑
                int templp = 0;
                if (_tableConfig.LaPaoZuo)
                {
                    templp = _playerAry[chair].LaNum + _playerAry[_outCardInfo.chair].LaNum + _playerAry[chair].PaoNum + _playerAry[_outCardInfo.chair].PaoNum;
                }
                _playerAry[_outCardInfo.chair].PlayerScore.huScore -= (multiple + 1 + tempgang + lianzhuang + GangScore(_outCardInfo.chair)) * tempjia * _tableConfig.CellScore;
                _playerAry[chair].PlayerScore.huScore += (multiple + 1 + tempgang + lianzhuang + GangScore(_outCardInfo.chair)) * tempjia * _tableConfig.CellScore;
            }
            else
            {
                //拉跑
                int templp = 0;
                if (_tableConfig.LaPaoZuo)
                {
                    templp = _playerAry[chair].PaoNum + _playerAry[_outCardInfo.chair].PaoNum;
                }
                _playerAry[_outCardInfo.chair].PlayerScore.huScore -= (multiple + tempgang + GangScore(_outCardInfo.chair)) * tempjia * _tableConfig.CellScore;
                _playerAry[chair].PlayerScore.huScore += (multiple + tempgang + GangScore(_outCardInfo.chair)) * tempjia * _tableConfig.CellScore;
            }





            GameHost.WriteMessage("总：" + multiple);
            //_bankerChar = (byte)chair;
            //if (_bankerChar != (byte)chair)
            //{
            //    _bankerChar = (byte)((_bankerChar + 1) % LHZMJConstants.GAME_PLAYER);
            //}
            if (!_lastBankerWin)//防止一炮多响
                _lastBankerWin = _playerAry[chair].IsBanker;
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
                huScore = null
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
            if (_waitQiangGangPlayer.Count > 1)
            {
                _bankerChar = (byte)_qiangGangInfo.chair;
            }
            else
            {
                _bankerChar = (byte)chair;
            }
            if (_completeCount == _waitQiangGangPlayer.Count)
            {
                //关闭抢杠超时计时
                closeOutTimer();

                ushort lastHuChair = MahjongDef.gInvalidChar;

                foreach (var playerChair in _waitQiangGangPlayer)
                {
                    if (_playerAry[playerChair].IsVoteQiangGang)
                    {
                        lastHuChair = playerChair;
                        _playerAry[_qiangGangInfo.chair].IsFangPao = true;
                        int multiple = _playerAry[playerChair].HandleByHu(_qiangGangInfo.card,
                            enHuCardType.HuCardType_QiangGangHu);
                        _noOneWin = false;
                        //if (_playerAry[playerChair].IsBanker || _playerAry[_qiangGangInfo.chair].IsBanker)
                        //{
                        //    multiple += _playerAry[playerChair].LianBanker + _playerAry[_qiangGangInfo.chair].LianBanker;
                        //    _playerAry[playerChair].JieSuan[0] = (byte)(_playerAry[playerChair].LianBanker +
                        //                                         _playerAry[_qiangGangInfo.chair].LianBanker);
                        //}
                        if (!_lastBankerWin)//防止一炮多响
                            _lastBankerWin = _playerAry[playerChair].IsBanker;
                        //_playerAry[playerChair].PlayerScore.huScore += multiple * _tableConfig.CellScore;
                        //_playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= multiple * _tableConfig.CellScore;
                        //加番
                        int tempjia = 1;


                        if (_tableConfig.GangKaiJia)
                        {
                            tempjia *= _playerAry[playerChair].JieSuan[7] > 0 ? 2 : 1;
                        }

                        //杠分
                        int tempgang = 0;

                        //包三家
                        for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
                        {
                            if ((i != playerChair))
                            {
                                if (_playerAry[i].IsBanker || _playerAry[playerChair].IsBanker)
                                {
                                    //拉跑
                                    int templp = 0;
                                    if (_tableConfig.LaPaoZuo)
                                    {
                                        templp =
                                                 _playerAry[playerChair].PaoNum + _playerAry[i].PaoNum;
                                    }
                                    _playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= (multiple + 1 + templp + GangScore((ushort)i) + lianzhuang +
                                                                                             tempgang) * tempjia *
                                                                                            _tableConfig.CellScore;
                                    _playerAry[playerChair].PlayerScore.huScore += (multiple + 1 + templp + GangScore((ushort)i) + lianzhuang + tempgang) *
                                                                                   tempjia * _tableConfig.CellScore;
                                }
                                else
                                {
                                    //拉跑
                                    int templp = 0;
                                    if (_tableConfig.LaPaoZuo)
                                    {
                                        templp = _playerAry[playerChair].PaoNum + _playerAry[i].PaoNum;
                                    }
                                    _playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= (multiple + templp) * tempjia *
                                                                                            _tableConfig.CellScore;
                                    _playerAry[playerChair].PlayerScore.huScore += (multiple + templp) *
                                                                                   tempjia * _tableConfig.CellScore;
                                }

                            }
                        }

                        //发送抢杠玩家
                        SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHuCard()
                        {
                            chair = (byte)playerChair,
                            card = _qiangGangInfo.card,
                            huType = (byte)(enHuCardType.HuCardType_ZiMo),
                            huScore = null
                        });
                    }
                }
            

            //for (int j = 1; j < LHZMJConstants.GAME_PLAYER; j++)//不带一炮多响，从出牌者的下家开始找起
            //        {
            //            int temp = (j + _qiangGangInfo.chair) % LHZMJConstants.GAME_PLAYER;
            //            if (_playerAry[temp].IsVoteQiangGang)
            //            {
            //                lastHuChair = (ushort)temp;
            //                _playerAry[_qiangGangInfo.chair].IsFangPao = true;
            //                int multiple = _playerAry[temp].HandleByHu(_qiangGangInfo.card, enHuCardType.HuCardType_QiangGangHu);
            //                _noOneWin = false;
            //                _playerAry[temp].JieSuan[8]++;
            //                //加番
            //                int tempjia = 1;

            //                //if (_tableConfig.GangKaiJia)
            //                //{
            //                //    tempjia *= _playerAry[temp].JieSuan[7] > 0 ? 2 : 1;
            //                //}
            //                //if (_tableConfig.BuKaoJia)
            //                //{
            //                //    tempjia *= _playerAry[temp].JieSuan[9] > 0 ? 2 : 1;
            //                //}
            //                //杠分
            //                int tempgang = 0;
            //                if (!_tableConfig.IsGangJiuYou)
            //                {
            //                    //tempgang = _playerAry[_qiangGangInfo.chair].JieSuan[3] + _playerAry[_qiangGangInfo.chair].JieSuan[5] + _playerAry[_qiangGangInfo.chair].JieSuan[6] * 2;
            //                    tempgang = GangScore((ushort)_qiangGangInfo.chair);
            //                }
            //                //包三家
            //                for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            //                {
            //                    if ((i != _qiangGangInfo.chair))
            //                    {
            //                        if (_playerAry[i].IsBanker || _playerAry[_qiangGangInfo.chair].IsBanker)
            //                        {
            //                            //拉跑
            //                            int templp = 0;
            //                            if (_tableConfig.LaPaoZuo)
            //                            {
            //                                templp = _playerAry[temp].LaNum + _playerAry[i].LaNum +
            //                                         _playerAry[temp].PaoNum + _playerAry[i].PaoNum;
            //                            }
            //                            _playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= (multiple + 1 + templp + GangScore((ushort)i) + lianzhuang +
            //                                                                                     tempgang) * tempjia *
            //                                                                                    _tableConfig.CellScore;
            //                            _playerAry[temp].PlayerScore.huScore += (multiple + 1 + GangScore((ushort)i) + lianzhuang + templp + tempgang) *
            //                                                                           tempjia * _tableConfig.CellScore;
            //                        }
            //                        else
            //                        {
            //                            //拉跑
            //                            int templp = 0;
            //                            if (_tableConfig.LaPaoZuo)
            //                            {
            //                                templp = _playerAry[temp].PaoNum + _playerAry[i].PaoNum;
            //                            }
            //                            _playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= (multiple + templp + GangScore((ushort)i) +
            //                                                                                     tempgang) * tempjia *
            //                                                                                    _tableConfig.CellScore;
            //                            _playerAry[temp].PlayerScore.huScore += (multiple + GangScore((ushort)i) + templp + tempgang) *
            //                                                                           tempjia * _tableConfig.CellScore;
            //                        }

            //                    }
            //                }

            //                //_bankerChar = (byte)temp;
            //                //if (_bankerChar != (byte)temp)
            //                //{
            //                //    _bankerChar = (byte)((_bankerChar + 1) % LHZMJConstants.GAME_PLAYER);
            //                //}
            //                if (!_lastBankerWin)//防止一炮多响
            //                    _lastBankerWin = _playerAry[temp].IsBanker;
            //                //_playerAry[temp].PlayerScore.huScore += multiple * _tableConfig.CellScore;
            //                //_playerAry[_qiangGangInfo.chair].PlayerScore.huScore -= multiple * _tableConfig.CellScore;

            //                //发送抢杠玩家
            //                SendGameMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHuCard()
            //                {
            //                    chair = (byte)temp,
            //                    card = _qiangGangInfo.card,
            //                    huType = (byte)(enHuCardType.HuCardType_PingHu),
            //                    huScore = null
            //                });
            //                break;
            //            }
            //        }
                


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
            //if ((null != friend) && (friend.UserID == helpFriend.friendID))
            //{
            //    //进行结算
            //    this.GameHost.HostSettlementService.UserTransferGameQiuZhu(new UserTransferGameQiuZhuReq()
            //    {
            //        MarkContext = "红中麻将求助处理",
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
            //}
        }
        #endregion

        /// <summary>
        /// 请求强退
        /// </summary>
        /// <param name="playerID"></param>
        private void HandleMsg_CMD_C_ForceLeft(ushort chair, uint playerID)
        {
            #region 强退扣费

            if (0 == this._gameForceLeftNum[chair])
            {
                var forceMoneyType = CurrencyType.Gold;
                int forceMoneyNum = -1000;

                #region 取系统配置表,获取强退惩罚

                var forceConfig = (this.GameHost.HostSystemConfigManger["QuitDeduct"] ?? "4|-1000").Split('|');
                if (forceConfig.Length >= 2)
                {
                    int moneyType = 0;
                    if (int.TryParse(forceConfig[0], out moneyType))
                    {
                        forceMoneyType = (CurrencyType)moneyType;
                    }

                    int moneyNum = 0;
                    if (int.TryParse(forceConfig[1], out moneyNum))
                    {
                        forceMoneyNum = moneyNum;
                    }
                }

                #endregion

                List<UserAuditData> userAuditData = new List<UserAuditData>();
                userAuditData.Add(new UserAuditData()
                {
                    MoneyNum = forceMoneyNum,
                    UserID = playerID
                });

                GameHost.HostSettlementService.PlayerForFeeMultiple(new PlayerForFeeDataMultiple()
                {
                    FeeDataType = ForFeeDataType.多人游戏结算,
                    Mark = "强退扣费",
                    MoneyType = forceMoneyType,
                    NoCheckUserMoney = 0,
                    RoomID = GameHost.GetRoomInfo.ID,
                    UserAuditDataArray = userAuditData.ToArray()
                }, p =>
                {

                });

                ++this._gameForceLeftNum[chair];
            }

            //强退影响其他不在家的玩家
            this.playerForceLeftCheckOtherPlayerForce(chair);
            _playerAry[chair].isForceLefting = true;

            #endregion

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
            tableRule.GoldRoomBaseIdx = tableRule.SetGameNum;
            //检查数据是否正确
            if (tableRule.isTableCreatorPay > 1) //房主买单
            {
                if (tableRule.GoldRoomBaseIdx < 0 || tableRule.GoldRoomBaseIdx > 3 ||
                    (_specialAttri.PayKa[tableRule.GoldRoomBaseIdx + 4] != tableRule.TableCost))
                {
                    BadCreateForce(chair);
                    return;
                }
            }
            else
            {
                if (tableRule.GoldRoomBaseIdx < 0 || tableRule.GoldRoomBaseIdx > 3 ||
                    (_specialAttri.PayKa[tableRule.GoldRoomBaseIdx] != tableRule.TableCost))
                {
                    BadCreateForce(chair);
                    return;
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

                _tableConfig.IsGangJiuYou = tableRule.isGangJiuYou;
                _tableConfig.GuoHuBuHu = tableRule.GuoHuBuHu;
                _tableConfig.CheckGps = tableRule.CheckGps;
                if(tableRule.MaShu<0 || tableRule.MaShu > 2)
                {
                    tableRule.MaShu = 2;
                }
                else
                {
                    _tableConfig.MaShu = (byte)((tableRule.MaShu+1)* 2);
                }
                
                _tableConfig.RulePeng = tableRule.RulePeng;
                _tableConfig.OutCardTime = tableRule.OutCardTime;
                _tableConfig.PeopleNum = tableRule.PeopleNum;

                //_tableConfig.LaPaoZuo = tableRule.LaPaoZuo > 0;

                this._tableConfig.CellScore = 1;

                //_tableConfig.QiDuiJia = tableRule.QiDuiJia > 0;

                _tableConfig.GangKaiJia = true;//tableRule.GangKaiJia > 0;
                _tableConfig.IfCanSameIp = tableRule.IfCanSameIp > 0 ? true : false;

                // _tableConfig.BuKaoJia = tableRule.BuKaoJia > 0;

                //_tableConfig.YiPaoDuoXiang = tableRule.isYiPaoDuoXiang > 0;

                _tableConfig.TableCost = tableRule.TableCost;
                _tableConfig.TableCreatorPay = tableRule.isTableCreatorPay;
                _tableConfig.IsRecordScoreRoom = true;
                _tableConfig.isCreateed = true;
                _tableConfig.TableCode = tableRule.TableCode;
                _tableConfig.SetGameNum = (tableRule.SetGameNum+1)*8;
             //   _tableConfig.GoldRoomBaseIdx = tableRule.GoldRoomBaseIdx;
                _tableConfig.CreatedOutTimeOP = false;
                _tableConfig.is4hui = true;
                _tableConfig.is7hui = false;
                _tableConfig.isChuHunJiaFan = false;
                _tableConfig.ifCanHu7Dui = tableRule.ifCanHu7Dui;
                _tableConfig.IfCanBaoTing = false;
                _tableConfig.ifCanTianHu = true;
                _tableConfig.isM1A2 = false;
                _tableConfig.isM3A4 = true;
                //通知桌子规则
                this.SendTableRule2Client(MahjongDef.gInvalidChar);

                //通知房主
                this.SendTableCreator2Client(MahjongDef.gInvalidChar);
                //创建成功
                this.SendGameMsg(chair, new CMD_S_CreateTableSuccess());
            }
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
                                Banker = _tableConfig.PlayerGameRecord[i].BankerChair
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
                                Banker = _tableConfig.PlayerGameRecord[_tableConfig.PlayerGameRecord.Count - 1].BankerChair
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
                    Banker = _tableConfig.PlayerGameRecord[i].BankerChair
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
                    ////断线玩家自动同意
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
                

            }
        }   /// <summary>
        /// 是否能够申请解散房间
        /// </summary>
        /// <returns></returns>
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
                            this.OnEventGameEnd(MahjongDef.gInvalidChar, true);
                            this._tableConfig.SetGameNum = 0;
                            dissTableSuccess.gameing = 1;


                        }
                        else
                        {
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
                    }
                }
            }
        }



        #endregion


        #region 发牌相关方法

        /// <summary>
        /// 处理给玩家发牌
        /// </summary>
        /// <returns></returns>
        private bool SendCardToPlayer()
        {
            if (_outCardInfo.isValid && _opPlayerChar != _outCardInfo.chair)
                _playerAry[_outCardInfo.chair].IsJustGang = false;
            _outCardInfo.Clear();
            //检查该玩家牌池是否满了，如果满了结束游戏
            if (NeedOverGame)
            {
                //只剩四张，海底捞时间
                //HaiDiLaoTime();
                //AddLogTitle(_opPlayerChar.ToString() + "为" + _opPlayerChar + "号玩家发牌时,没有牌了,结束游戏");
                GameHost.HostTimerService.RegTimerNonAutoHandle(CommonDef.TimerID_WaitGoon, 10, () =>
                {
                    //杠了就有计算杠分
                    if (_tableConfig.IsGangJiuYou)
                    {
                        for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
                        {
                            if (_playerAry[i].PlayerCard.fixedCard.fixedCard.Count > 0)
                            {

                                for (int j = 0; j < LHZMJConstants.GAME_PLAYER; j++)
                                {

                                    if (_playerAry[i].PlayerCard.fixedCard.fixedCard[j].fixedType == enFixedCardType.FixedCardType_MGang)
                                    {
                                        _playerAry[i].PlayerScore.huScore += 3;
                                    }

                                }
                            }
                            _playerAry[i].PlayerScore.huScore -= _playerAry[i].fanggang * 3;
                        }

                        for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
                        {
                            if (_playerAry[i].PlayerCard.fixedCard.fixedCard.Count > 0)
                            {

                                for (int j = 0; j < LHZMJConstants.GAME_PLAYER; j++)
                                {
                                    if (i != j)
                                    {
                                        _playerAry[i].PlayerScore.huScore += GangScore((ushort)i);
                                        _playerAry[j].PlayerScore.huScore -= GangScore((ushort)i);
                                    }

                                }
                            }
                        }
                    }
                 
                    this.OnEventGameEnd(MahjongDef.gInvalidChar);
                });
                return false;
            }

            //通知当前操作玩家
            this.InformCurOpPlayer();

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
                // holdCard = 0x05;
            }

            PrintLog("=======================轮到 " + _opPlayerChar + "号玩家抓牌 ==========================");
            PrintLog("玩家抓牌前手中的活动牌:");
            PrintPlayerHandCard(_opPlayerChar);

            //测试用
            //holdCard = 0x08;
            //设置当前玩家抓到的牌
            CurPlayer.HoldCard = holdCard;
            PrintPlayerHandCard(_opPlayerChar);
            this._ORCTime = DateTime.Now;

            //发送抓牌信息到所有真人客户端
            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                //玩家抓牌,除去自己其他玩家刚刚杠标志清除
                //_playerAry[i].IsJustGang = (i == _opPlayerChar ? _playerAry[i].IsJustGang : false);

                if (_playerAry[i].IsAIPlayer || _playerAry[i].IsOffline)//
                {
                    continue;
                }
                SendGameMsg(i, new CMD_S_PlayerHoldCard()
                {
                    chair = _opPlayerChar,
                    card = (i == _opPlayerChar ? holdCard : MahjongDef.gInvalidMahjongValue)
                }, false);
            }
            this.SaveMsg(MahjongDef.gInvalidChar, new CMD_S_PlayerHoldCard()
            {
                chair = _opPlayerChar,
                card = holdCard
            });


            //#region 南京麻将亮出硬花
            ////发完牌后如果手中有硬花，则把硬花亮出来
            //if (this._playerAry[_opPlayerChar].IsHaveFlowerHardInActiveCard())
            //{
            //    //if (_cardPackage.leftCardNum > 20+ GetAllGangNum())//只有在补完花之后可以发牌的情况下才可以补花,不在这里判断了，统一在发牌出判断
            //    //{
                
            //    this.HandleShowFlowerCard(_opPlayerChar);
            //    //}

            //    return true;//开始有这个return时，会出现，补完花之后不能操作的情况，所以给注释掉了，起作用的因该是下面的InformCustomOpPlayer();
            //    //貌似自动补花的时候，需要此return,
            //    //此return在手动补花的时候需要注释掉，原因：第一个注释
            //    //此return在自动补花的时候不需要注释掉，因为会改变游戏阶段(通过递归改变)
            //}
            //#endregion
            
            
            
            //设置游戏阶段及AI思考间隔
            ConfirmGamePhase();

            //通知当前操作的玩家
            InformCustomOpPlayer(_opPlayerChar);
              List<byte> gangCard = new List<byte>();
              
            if (_playerAry[_opPlayerChar].IsTing)
            {
                if (_completeCount > 0 || CanZiMo == 1||_playerAry[_opPlayerChar].FindGangCard(gangCard) )
                {
                    return true;
                }
                Thread.Sleep(500);

           
                    HandleMsg_CMD_C_OutCard(_opPlayerChar, holdCard);
               
                
                //for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
                //{



                //    if (_playerAry[i].canVote)
                //    {
                //        _playerAry[i].canVote = false;
                //        return true;
                //    }
                
                
                //}
               
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
                            CurPlayer.WaitSeconds = randObj.Next(0, 1);
                            break;
                        }
                    //打出牌,1~8秒
                    case enPlayerOperator.PlayerOperator_OutCard:
                        {
                            //有其他人报警，打报警牌速度+3s
                            //List<byte> baojingcard = new List<byte>();
                            //foreach (var player in _playerAry)
                            //{
                            //    if (player.PlayerChair != CurPlayer.PlayerChair && player.IsBaoJing)
                            //    {
                            //        baojingcard.AddRange(player.BaoJingCards);
                            //    }
                            //}
                            CurPlayer.WaitSeconds = randObj.Next(0, 1);
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
            //if (!CurPlayer.IsJustPeng)
            //{
           
            CurPlayer.FindGangCard(gangCard);
            //}

            //if (lianzhuang < 3)
            //{
            //     CanZiMo=(byte)(CurPlayer.CheckIfCanHuACard(CurPlayer.HoldCard) ? 1 : 0);
            //}
            //else if(lianzhuang>=3)
            //{
            //    if (_opPlayerChar == _bankerChar)
            //    {
            //        CanZiMo = (byte)(CurPlayer.CheckIfCanHuACard(CurPlayer.HoldCard) ? 1 : 0);
            //    }
            //    else
            //    {
            //        if (_playerAry[_opPlayerChar].HasGang())
            //        {
            CanZiMo = (byte)(CurPlayer.CheckIfCanHuACard(CurPlayer.HoldCard) ? 1 : 0);
            //        }
            //        else
            //        {
            //            CanZiMo = 0;
            //        }
            //    }

            //}
            PrintLog("杠牌结果数量"+gangCard.Count);
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
                szInfo.bankerChair = (byte)(rand.Next(LHZMJConstants.GAME_PLAYER));
                //确定庄家
                _bankerChar = szInfo.bankerChair;

                start.reMain++;
                lianzhuang = 0;
                szInfo.lianBanker = lianzhuang;
                
                fengquan = 0;
            }
            else
            {
                if (_tableConfig.GameNum < 1)
                {
                    _bankerChar = (byte)this._tableConfig.TableCreatorChair;
                    szInfo.bankerChair = _bankerChar;
                }else
                //上局庄赢或流局
                if (_noOneWin)
                {
                    szInfo.bankerChair = (byte)((_bankerChar + 1) % LHZMJConstants.GAME_PLAYER);
                    _lastBankerWin = false;
                    //szInfo.lianBanker = (byte)(_playerAry[_bankerChar].LianBanker + 1);

                    //lianzhuang++;
                    //szInfo.lianBanker = lianzhuang;
                }else
                {                    
                    szInfo.bankerChair = _bankerChar;
                }

            }
            //#region 红中麻将设置风圈
            //if (fengquan >=0&&fengquan<4)
            //{
            //   ; Szmjcmvar.FengQuanFlowerCard = 0x31;
            //}
            //else if (fengquan >= 4 && fengquan < 8)
            //{
            //    Szmjcmvar.FengQuanFlowerCard = 0x32;
            //}
            //else if (fengquan >= 8 && fengquan < 12)
            //{
            //    Szmjcmvar.FengQuanFlowerCard = 0x33;
            //}
            //else if(fengquan>=12&&fengquan<16)
            //{
            //    Szmjcmvar.FengQuanFlowerCard = 0x34;
                
            //}
            //else
            //{
            //    Szmjcmvar.FengQuanFlowerCard = 0x31;
            //    fengquan = 0;

            //}
           

            //#endregion

            _lastBanker = szInfo.bankerChair;
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
            CMD_S_Ting ting = new CMD_S_Ting();
            for (short i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                _cardPackage.HoldCard(_playerAry[i].PlayerCard.activeCard.handCard);

                GameHost.SaveLog(i.ToString() + "号位置玩家抓牌:");

                //#region 测试牌阵

                //if (i == 1)//_playerAry[i].IsAIPlayer)
                //{

                //    //    //一万,二万,三万,五万, 一筒,三筒,六筒,七筒,八筒,八筒, 四条,五条,六条
                //    _playerAry[i].PlayerCard.activeCard.handCard.Clear();

                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x36);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x36);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x36);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x36);

                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x35);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x35);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x35);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x35);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x31);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x31);

                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x31);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x31);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x37);




                //}
                //else
                //{
                //    //六万,八条,发财,    红中,三条,三筒  ,四筒,三条,八万  ,五万,五条,二筒,九筒
                //    _playerAry[i].PlayerCard.activeCard.handCard.Clear();

                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x27);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x23);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x12);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x12);

                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x12);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x12);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x23);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x23);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x23);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x08);

                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x08);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x08);
                //    _playerAry[i].PlayerCard.activeCard.handCard.Add(0x08);
                //}

                //#endregion

                PrintCardList(_playerAry[i].PlayerCard.activeCard.handCard);

                SendGameMsg(i, new CMD_S_InitCard()
                {
                    cardAry = _playerAry[i].PlayerCard.activeCard.handCard.ToArray()
                });

                

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
                checkChair = (byte)((checkChair + 1) % LHZMJConstants.GAME_PLAYER);
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
                msg = "因为房主离开游戏,房间被解散"
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
                msg = "房间被房主解散！"
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
            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                tableCreator = (byte)((tableCreator + 1) % LHZMJConstants.GAME_PLAYER);
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
            //看似处理玩家断线自动投解散房间同意票
            //if (this._dissTable.isValid && (0 == this._dissTable.PlayerVote[chairID]))
            //{
            //    this.HandleMsg_CMD_C_VoteDissTable(chairID, new CMD_C_VoteDissTable()
            //    {
            //        voteResult = 1
            //    });
            //}
            //断线重连自主建房,局数没打满处理
            //  else
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
                    lianbank = lianzhuang
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
            SendHunPiToCustomer(chairID);

            //2、恢复牌阵信息
            if (this._gamePhase != enGamePhase.GamePhase_La && this._gamePhase != enGamePhase.GamePhase_Pao)
            {
                var selfCard = new ORCSelfCard();
                selfCard.holdCard = _playerAry[chairID].HoldCard;
                selfCard.handCard = _playerAry[chairID].PlayerCard.activeCard.handCard.ToArray();
                selfCard.poolCard = _playerAry[chairID].PlayerCard.poolCard.ToArray();
                selfCard.flowerCard = _playerAry[chairID].PlayerCard.flowerCard.ToArray();
                selfCard.isTing = _playerAry[chairID].IsTing;
                var selfFixed = new List<ORCFixedCard>();
                foreach (var fixedCard in _playerAry[chairID].PlayerCard.fixedCard.fixedCard)
                {
                    selfFixed.Add(new ORCFixedCard()
                    {
                        fixedType = (byte)fixedCard.fixedType,
                        fixedCard = fixedCard.card,
                        outChair = fixedCard.outChair
                    });
                }
                selfCard.fixedCard = selfFixed.ToArray();

               








                var otherCard = new List<ORCOtherPlayerCard>();
                for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
                {
                    if (i == chairID)
                    {
                        continue;
                    }
                    var otherPlayerCard = new ORCOtherPlayerCard();

                    otherPlayerCard.chair = (byte)i;
                    otherPlayerCard.handCardNum = (byte)_playerAry[i].PlayerCard.activeCard.handCard.Count;
                    otherPlayerCard.poolCard = _playerAry[i].PlayerCard.poolCard.ToArray();
                    otherPlayerCard.flowerCard = _playerAry[i].PlayerCard.flowerCard.ToArray();
                    otherPlayerCard.IsTing = _playerAry[i].IsTing;

                    var otherFixed = new List<ORCFixedCard>();
                    foreach (var fixedCard in _playerAry[i].PlayerCard.fixedCard.fixedCard)
                    {
                        otherFixed.Add(new ORCFixedCard()
                        {
                            fixedType = (byte)fixedCard.fixedType,
                            fixedCard = fixedCard.card,
                            outChair = fixedCard.outChair
                        });
                    }
                    otherPlayerCard.fixedCard = otherFixed.ToArray();

                    otherCard.Add(otherPlayerCard);
                }

                this.SendGameMsg(chairID, new CMD_S_ORC_PlayerCard()
                {
                    selfCard = selfCard,
                    otherPlayerCard = otherCard.ToArray()
                }, false);

                //if (_tableConfig.LaPaoZuo)
                //{
                //    List<byte> players1 = new List<byte>();
                //    List<byte> players2 = new List<byte>();
                //    foreach (var player in _playerAry)
                //    {
                //        players1.Add((byte)player.LaNum);
                //        players2.Add((byte)player.PaoNum);
                //    }
                //    SendGameMsg(chairID, new CMD_S_PlayerLaInfo()
                //    {
                //        points = players1.ToArray()
                //    }, false);
                //    SendGameMsg(chairID, new CMD_S_PlayerPaoInfo()
                //    {
                //        points = players2.ToArray()
                //    }, false);
                //}
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
            this.SendGameMsg(chairID, new CMD_S_ORC_Over()
            {
                leftCardNum = (byte)_cardPackage.leftCardNum
            }, false);
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
        /// 发送玩家分数变化,,红中麻将发送的当前底的玩家底注
        /// </summary>
        /// <param name="chairID"></param>
        private void playerScoreChange(byte chairID)
        {
            //玩家分数
            List<int> playerScores = new List<int>();
            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
            {
                playerScores.Add(0);
            }
            if (_tableConfig.isValid)
            {
                foreach (var pgRecord in _tableConfig.PlayerGameRecord)
                {
                    if (pgRecord.playerRecord.Count == LHZMJConstants.GAME_PLAYER)
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
                //LaPaoZuo = (byte)(_tableConfig.LaPaoZuo ? 1 : 0),
                //qiduijia = (byte)(_tableConfig.QiDuiJia ? 1 : 0),
                CellScore = this._tableConfig.CellScore,
                gangkaijia = (byte)(_tableConfig.GangKaiJia ? 1 : 0),
                //bukaojia = (byte)(_tableConfig.BuKaoJia ? 1 : 0),
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
                IfCanSameIP=_tableConfig.IfCanSameIp,



                 isChuHunJiaFan=this._tableConfig.isChuHunJiaFan,
                 ifCanHu7Dui=this._tableConfig.ifCanHu7Dui,
                 ifCanTianHu=this._tableConfig.ifCanTianHu,
                 IfCanBaoTing=this._tableConfig.IfCanBaoTing,
                // isYiPaoDuoXiang = (byte)(_tableConfig.YiPaoDuoXiang ? 1 : 0),
                GangLeJiuYou = _tableConfig.IsGangJiuYou,
                 GuoHuBuHu = _tableConfig.GuoHuBuHu,
                 CheckGps = _tableConfig.CheckGps,
                MaShu = _tableConfig.MaShu,
                RulePeng = _tableConfig.RulePeng,
                PeopleNum = _tableConfig.PeopleNum,
                OutCardTime = _tableConfig.OutCardTime,

            });
        }
        /// <summary>
        /// 更新客户端玩家余额
        /// </summary>
        /// <param name="chairID"></param>
        private void UpdateClientPlayerMoney()
        {
            for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                        goldCard = playerInfo.GoldNum,
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
                return (byte)((_bankerChar + 1) % LHZMJConstants.GAME_PLAYER);
            }
        }
        /// <summary>
        /// 庄家对家玩家的椅子号
        /// </summary>
        public byte BankerOppoChair
        {
            get
            {
                return (byte)((_bankerChar + 2) % LHZMJConstants.GAME_PLAYER);
            }
        }
        /// <summary>
        /// 庄家上家或是左手边玩家的椅子号
        /// </summary>
        public byte BankerUpChair
        {
            get
            {
                return (byte)((_bankerChar + 3) % LHZMJConstants.GAME_PLAYER);
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
                if (!_cardPackage.haveCard || _cardPackage.leftCardNum <= _tableConfig.MaShu || LeftGamePlayerNum < 4)
                {
                    return true;
                }
                return false;
            }
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
                //等待准备
                
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
                        for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                        for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                        for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                        for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                        for (int i = 0; i < LHZMJConstants.GAME_PLAYER; i++)
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
                    if (!_tableConfig.CreatedOutTimeOP)
                    {
                        this.SendGameMsg(player.PlayerChair, new CMD_S_ShowMsg()
                        {
                            msg = "有玩家暂离，请耐心等待！",
                            tipType = 1
                        }, false);
                    }
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
            if (charID < LHZMJConstants.GAME_PLAYER)
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


    }
}
