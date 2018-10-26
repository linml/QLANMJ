using GameIF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MahjongAlgorithmForMGMJ;
namespace M_MGMJ
{
    /// <summary>
    /// 公共定义
    /// </summary>
    public class CommonDef
    {
        public static bool ISDEBUG = true;
        /// <summary>
        /// AI计时器
        /// </summary>
        public const int TimerID_AIOP = 100;

        /// <summary>
        /// 等待投票
        /// </summary>
        public const int TimerID_WaitVote = 102;
        /// <summary>
        /// 等待继续
        /// </summary>
        public const int TimerID_WaitGoon = 103;
        /// <summary>
        /// 等待解散房间
        /// </summary>
        public const int TimerID_WaitDissTable = 104;
        /// <summary>
        /// 准备计时器
        /// </summary>
        public const int TimerID_Ready = 105;
        /// <summary>
        /// 超时
        /// </summary>
        public const int TimerID_OutTime = 106;
        /// <summary>
        /// 等待保留房间
        /// </summary>
        public const int TimerID_SaveTable = 107;
        /// <summary>
        /// 是否需要找暗杠
        /// </summary>
        /// <param name="GA"></param>
        /// <returns></returns>
        public static bool CheckNeedFindAnGang(byte GA)
        {
            return (byte)(GA & findGangMask_AGang) > 0;
        }
        /// <summary>
        /// 是否需要找补杠
        /// </summary>
        /// <param name="GA"></param>
        /// <returns></returns>
        public static bool CheckNeedFindBuGang(byte GA)
        {
            return (byte)(GA & findGangMask_BGang) > 0;
        }

        /// <summary>
        /// 无需找任何类型的杠
        /// </summary>
        public const byte findGangMask_Null = 0x00;
        /// <summary>
        /// 找暗杠
        /// </summary>
        public const byte findGangMask_AGang = 0x01;
        /// <summary>
        /// 找补杠
        /// </summary>
        public const byte findGangMask_BGang = 0x02;
        /// <summary>
        /// 全找
        /// </summary>
        public const byte findGangMask_All = 0x04;
        /// <summary>
        /// 牌张中字
        /// </summary>
        public static readonly string[] gChineseCard =
        {
            "","一万","二万","三万","四万","五万","六万","七万","八万","九万",
            "","一筒","二筒","三筒","四筒","五筒","六筒","七筒","八筒","九筒",
            "","一条","两条","三条","四条","五条","六条","七条","八条","九条",
            "","东风","南风","西风","北风","红中","发财","白板"
        };
    }

    //==============================================
    //
    //				  枚举值定义
    //
    //==============================================

    /// <summary>
    /// 玩家操作
    /// </summary>
    public enum enPlayerOperator
    {
        /// <summary>
        /// 未知
        /// </summary>
        PlayerOperator_UnKnown = 0,
        /// <summary>
        /// 打牌
        /// </summary>
        PlayerOperator_OutCard = 1,
        /// <summary>
        /// 碰
        /// </summary>
        PlayerOperator_Peng = 2,
        /// <summary>
        /// 暗杠
        /// </summary>
        PlayerOperator_AGang = 3,
        /// <summary>
        /// 明杠
        /// </summary>
        PlayerOperator_MGang = 4,
        /// <summary>
        /// 补杠
        /// </summary>
        PlayerOperator_BGang = 5,
        /// <summary>
        /// 自摸
        /// </summary>
        PlayerOperator_ZiMo = 6,
        /// <summary>
        /// 炮胡
        /// </summary>
        PlayerOperator_PaoHu = 7,
        /// <summary>
        /// 抢杠
        /// </summary>
        PlayerOperator_QiangGang = 8
    };

    //==============================================
    //
    //				  结构体定义
    //
    //==============================================

    /// <summary>
    /// AI本次操作结果
    /// </summary>
    public class clsAIPlay
    {
        /// <summary>
        /// 操作结果
        /// </summary>
        public enPlayerOperator enPlayResult;
        /// <summary>
        /// 操作的牌
        /// </summary>
        public byte cOpCard;

        /// <summary>
        /// 设置操作结果
        /// </summary>
        /// <param name="enOp"></param>
        /// <param name="cCard"></param>
        public void SetOp(enPlayerOperator enOp, byte cCard)
        {
            enPlayResult = enOp;
            cOpCard = cCard;
        }
        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            enPlayResult = enPlayerOperator.PlayerOperator_UnKnown;
            cOpCard = MahjongDef.gInvalidMahjongValue;
        }
    };

    /// <summary>
    /// 本局特殊属性
    /// </summary>
    public class clsSpecialAttri
    {
        public byte[] PayKa = new byte[8] { 1, 1, 3, 4, 2, 3, 6, 12 };
        public byte[] JuShu = new byte[4] { 4, 8, 16, 32 };
        /// <summary>
        /// 好的控制概率
        /// </summary>
        public int GoodProbability { get; set; }

        /// <summary>
        /// 坏的控制概率
        /// </summary>
        public int BadProbability { get; set; }
        /// <summary>
        /// 超时时间
        /// </summary>
        public int OutTime { get; set; }
        /// <summary>
        /// 自创房间超时时间
        /// </summary>
        public int OffLineOutTime { get; set; }
        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            GoodProbability = 0;
            BadProbability = 0;
            OutTime = 12;
            OffLineOutTime = 30;
            PayKa[0] = 1;
            PayKa[1] = 1;
            PayKa[2] = 3;
            PayKa[3] = 4;
            PayKa[4] = 1;
            PayKa[5] = 2;
            PayKa[6] = 3;
            PayKa[7] = 4;
            JuShu[0] = 4;
            JuShu[1] = 8;
            JuShu[2] = 16;
            JuShu[3] = 32;
        }
    };
    /// <summary>
    /// 游戏玩家记录
    /// </summary>
    public class clsGameUserRecord
    {
        private List<int> _playerRecord = new List<int>();
        /// <summary>
        /// 记录类型0正常1交2输光
        /// </summary>
        public byte ScoreType { get; set; }
        /// <summary>
        /// 庄号
        /// </summary>
        public byte BankerChair { get; set; }
        /// <summary>
        /// 大结算胡牌 杠牌次数
        /// </summary>
        public clsGameUserRecord()
        {
            ScoreType = 0;
            BankerChair = MahjongDef.gInvalidChar;
        }

        /// <summary>
        /// 添加一个玩家3记录
        /// </summary>
        /// <param name="gamescore"></param>
        public void addUserRecord(int gamescore)
        {
            this._playerRecord.Add(gamescore);
        }

        /// <summary>
        /// 玩家记录
        /// </summary>
        public List<int> playerRecord
        {
            get
            {
                return this._playerRecord;
            }
        }
    }
    /// <summary>
    /// 桌子规则
    /// </summary>
    public class clsTableRule
    {   
        /// <summary>
        /// 玩家数
        /// </summary>
        public int PlayerNum { get; set; }
        /// <summary>
        /// 等待时间
        /// </summary>
        public int WaitTimeNum { get; set; }
        
        /// <summary>
        /// 配子选择
        /// </summary>
        public int SetPeiZi { get; set; }
        /// <summary>
        /// 点炮
        /// </summary>
        public byte DianPao { get; set; }
        /// <summary>
        /// 抢杠胡
        /// </summary>
        public byte QiangGangHu { get; set; }
        /// <summary>
        /// 是否允许ip相同
        /// </summary>
        public bool IfCanSameIp { get; set; }
        /// <summary>
        /// 是否拉跑坐
        /// </summary>
        public bool LaPaoZuo { get; set; }
        /// <summary>
        /// 一番多少金币
        /// </summary>
        public int CellScore { get; set; }
        /// <summary>
        /// 带大牌
        /// </summary>
        public byte daiDaPai { get; set; }
        /// <summary>
        /// 七对加番
        /// </summary>
        public bool QiDuiJia { get; set; }
        /// <summary>
        /// 杠上开花加番
        /// </summary>
        public bool GangKaiJia { get; set; }
        /// <summary>
        /// 13不靠加番
        /// </summary>
        public bool BuKaoJia { get; set; }
        /// <summary>
        /// 一炮多响
        /// </summary>
        public bool YiPaoDuoXiang { get; set; }

        /// <summary>
        /// 房主买单
        /// </summary>
        public byte TableCreatorPay { get; set; }
        /// <summary>
        /// 是否是记分场
        /// </summary>
        public bool IsRecordScoreRoom { get; set; }
        ///<summary>
        ///whoLose谁打谁出分
        /// </summary>
        public byte whoLose { get; set; }
        ///<summary>
        ///占庄
        /// </summary>
        public byte zhanZhuang { get; set; }
        ///<summary>
        ///canChi
        /// </summary>
        public byte canChi { get; set; }
        ///<summary>
        ///杠分
        /// </summary>
        public byte gangFen { get; set; }
        /// <summary>
        /// 操作不频繁可以投票
        /// </summary>
        public bool IsDissolution { get; set; }
        /// <summary>
        /// 房主id
        /// </summary>
        public uint TableCreatorID { get; set; }
        /// <summary>
        /// 房主椅子号
        /// </summary>
        public ushort TableCreatorChair { get; set; }
        /// <summary>
        /// 是否已经创建
        /// </summary>
        public bool isCreateed { get; set; }
        /// <summary>
        /// 桌号
        /// </summary>
        public string TableCode { get; set; }
        /// <summary>
        /// 桌费
        /// </summary>
        public int TableCost { get; set; }

        /// <summary>
        /// 金币场底金索引
        /// </summary>
        public int GoldRoomBaseIdx { get; set; }
        //主guid
        private string _guid;
        /// <summary>
        /// 游戏guid
        /// </summary>
        public string GameGUID { get { return this._guid; } }

        //private int _realGameNum;
        ///// <summary>
        ///// 颖上麻将，将底作为时长计算，所以新增真实局数，以前的局数作为底数使用，新的一底，从零开始
        ///// </summary>
        //public int RealGameNum { get { return _realGameNum; } set { _realGameNum = value; } }

        private int _gameNum;
        /// <summary>
        /// 游戏局数
        /// </summary>
        public int GameNum { get { return this._gameNum; } set { this._gameNum = value; } }

        /// <summary>
        /// 玩家游戏记录
        /// </summary>
        public List<clsGameUserRecord> PlayerGameRecord { get; set; }

        private int _setGameNum;
        /// <summary>
        /// 设置局数
        /// </summary>
        public int SetGameNum { get { return this._setGameNum; } set { this._setGameNum = value; } }

        /// <summary>
        /// 骰子1点数
        /// </summary>
        public byte sz1Point { get; set; }
        /// <summary>
        /// 骰子2点数
        /// </summary>
        public byte sz2Point { get; set; }
        /// <summary>
        /// 自主建房场，是否需要超时代打
        /// </summary>
        public bool CreatedOutTimeOP { get; set; }
        /// <summary>
        /// 构造
        /// </summary>
        public clsTableRule()
        {
            PlayerGameRecord = new List<clsGameUserRecord>();
            this.clear();
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void clear()
        {
            PlayerNum = 0;
            WaitTimeNum = 2;
            LaPaoZuo = false;
            YiPaoDuoXiang = true;
            CellScore = 1;
            GangKaiJia = true;
            QiDuiJia = false;
            BuKaoJia = false;
            TableCreatorPay = 0;
            IsRecordScoreRoom = false;
            TableCreatorID = 0;
            TableCreatorChair = MahjongDef.gInvalidChar;
            this.isCreateed = false;
            this._guid = "";
            this.TableCode = "";
            TableCost = 0;
            GoldRoomBaseIdx = 0;
            //_realGameNum = 0;
            _gameNum = 0;
            _setGameNum = 1;
            PlayerGameRecord.Clear();
            sz1Point = 1;
            sz2Point = 1;
            CreatedOutTimeOP = false;
            IfCanSameIp = true;
            IsDissolution = true;
            whoLose = 1;
        }
        /// <summary>
        /// 创建新的guid
        /// </summary>
        public void createNewGUID(string s)
        {
            this._guid = s;
            this._gameNum = 0;
            //_realGameNum = 0;
            PlayerGameRecord.Clear();
        }
        /// <summary>
        /// 新一底开始
        /// </summary>
        public void newGameStart()
        {
            ++this._gameNum;
            //_realGameNum = 0;
        }

        //public void newRealGameStart()
        //{
        //    ++_realGameNum;
        //}
        /// <summary>
        /// 是否打满了设置的局数
        /// </summary>
        public bool isPlayEnoughGameNum
        {
            get
            {
                if(this._setGameNum == 0)
                {
                    return this._gameNum >= 8;
                }
                else{
                    //设置的局数
                    return this._gameNum >= 16;
                }
                
            }
        }
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isValid
        {
            get
            {
                if (0 != this.TableCreatorID)// && (MahjongDef.gInvalidChar != TableCreatorChair))
                {
                    return true;
                }
                return false;
            }
        }
    }

    /// <summary>
    /// 录像数据
    /// </summary>
    public class JsonData : RecrdDataBase
    {
        public Room room = new Room();

        public List<PlayerData> tableplayer = new List<PlayerData>();

        public List<VMessage> gamemessage = new List<VMessage>();
    }
    /// <summary>
    /// 录像场地数据
    /// </summary>
    public class Room
    {
        public uint ID;
        public int GameID;
        public uint AgentID;
        public int RoomType;
        public int GameType;
        public uint BaseMoney;
        public uint JoinMultiNum;
        public int MaxCount;
        public int RoomLV;
        public int CheckMoneyType;
        public int DisplayOrder;
        public uint TableCost;
        public string Name;
        public int TableCostMoneyType;
    }
    /// <summary>
    /// 录像玩家数据
    /// </summary>
    public class PlayerData
    {
        public uint PlayerID;
        public string NickName;
        public string FaceID;
        public uint PlayerLV;
        public int VIPLV;
        public int GoldNum;
        public int GoldCardNum;
        public int DiamondsNum;
        public int Gender;
    }
    /// <summary>
    /// 录像消息数据
    /// </summary>
    public class VMessage
    {
        public int time;
        public int chair;
        public List<int> data = new List<int>();
    }
}
