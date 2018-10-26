using MahjongAlgorithmForMGMJ;
using QL.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QL.Serialization;

namespace M_MGMJ_GameMessage
{
    #region 实体类

    /// <summary>
    /// 恢复活动牌
    /// </summary>
    [PacketContract]
    public class RecoveryActiveCard
    {
        /// <summary>
        /// 自己的活动牌阵
        /// </summary>
        [PacketMember(1)]
        public byte[] selfActive;

        /// <summary>
        /// 自己抓到的牌
        /// </summary>
        [PacketMember(2)]
        public byte selfHoldCard;

        /// <summary>
        /// 对方活动牌阵数量
        /// </summary>
        [PacketMember(3)]
        public byte oppoActiveCount;

        /// <summary>
        /// 对方抓到的牌
        /// </summary>
        [PacketMember(4)]
        public byte oppoHoldCard;
    }

    /// <summary>
    /// 恢复牌池牌
    /// </summary>
    [PacketContract]
    public class RecoveryPoolCard
    {
        /// <summary>
        /// 自己牌池牌
        /// </summary>
        [PacketMember(1)]
        public byte[] selfPoolCard;

        /// <summary>
        /// 对家牌池牌
        /// </summary>
        [PacketMember(2)]
        public byte[] oppoPoolCard;
    }

    /// <summary>
    /// 单个定牌
    /// </summary>
    [PacketContract]
    public class SingleFixedCard
    {
        /// <summary>
        /// 定牌特征牌
        /// </summary>
        [PacketMember(1)]
        public byte tokenCard;

        /// <summary>
        /// 定牌类型
        /// </summary>
        [PacketMember(2)]
        public byte type;

        /// <summary>
        /// 特征牌位置
        /// </summary>
        [PacketMember(3)]
        public byte pos;

        ///<summary>
        ///吃牌类型
        ///</summary>>
        [PacketMember]
        public byte chiType;

    }

    /// <summary>
    /// 恢复定牌
    /// </summary>
    [PacketContract]
    public class RecoveryFixedCard
    {
        /// <summary>
        /// 自己的定牌
        /// </summary>
        [PacketMember(1)]
        public SingleFixedCard[] selfFixedCard;

        /// <summary>
        /// 对方定牌
        /// </summary>
        [PacketMember(2)]
        public SingleFixedCard[] oppoFixedCard;
    }

    /// <summary>
    /// 玩家结算信息
    /// </summary>
    [PacketContract]
    public class PlayerBalance
    {
        /// <summary>
        /// 胡牌类型
        /// </summary>
        [PacketMember(1)]
        public int HuType;

        /// <summary>
        /// 是否放炮
        /// </summary>
        [PacketMember(2)]
        public int FangPao;

        /// <summary>
        /// 总赢
        /// </summary>
        [PacketMember(3)]
        public int TotalScore;
        /// <summary>
        /// 结算
        /// </summary>
        [PacketMember(4)]
        public byte[] JieSuan;
        /// <summary>
        /// 牌型分字段
        /// </summary>
        [PacketMember(5)]
        public String vecType;
    }

    /// <summary>
    /// 玩家牌信息
    /// </summary>
    [PacketContract]
    public class PlayerCard
    {

        /// <summary>
        /// 胡的牌
        /// </summary>
        [PacketMember(1)]
        public byte huCard;

        /// <summary>
        /// 活动牌阵
        /// </summary>
        [PacketMember(2)]
        public byte[] handCard;
        /// <summary>
        /// 活动牌阵
        /// </summary>
        [PacketMember(3)]
        public SingleFixedCard[] fixedCard;
    }

    /// <summary>
    /// 游戏流水账
    /// </summary>
    [PacketContract]
    public class GameFlowDetail
    {
        /// <summary>
        /// 流水发起者
        /// </summary>
        [PacketMember(1)]
        public byte PlayerChair;
        /// <summary>
        /// 流水类型
        /// </summary>
        [PacketMember(2)]
        public byte FlowType;
        /// <summary>
        /// 玩家得分
        /// </summary>
        [PacketMember(3)]
        public int[] PlayerScore;
    }

    /// <summary>
    /// 游戏记分结果
    /// </summary>
    [PacketContract]
    public class GameRecordResult
    {
        /// <summary>
        /// 玩家得分
        /// </summary>
        [PacketMember(1)]
        public int[] PlayerScore;
        /// <summary>
        /// 得分类型 0正常1交2输光底
        /// </summary>
        [PacketMember(2)]
        public byte ScoreType;
        /// <summary>
        /// 庄号
        /// </summary>
        [PacketMember(3)]
        public byte Banker;
        [PacketMember(4)]
        public byte[][] huGangCount;
    }

    #region 断线重连牌阵恢复

    /// <summary>
    /// 断线重连单个定牌
    /// </summary>
    [PacketContract]
    public class ORCFixedCard
    {
        /// <summary>
        /// 定牌类型
        /// </summary>
        [PacketMember(1)]
        public byte fixedType;
        /// <summary>
        /// 定牌
        /// </summary>
        [PacketMember(2)]
        public byte fixedCard;
        /// <summary>
        /// 放牌玩家
        /// </summary>
        [PacketMember(3)]
        public byte outChair;
        ///<summary>
        ///吃牌类型
        ///</summary
        [PacketMember]
        public byte chiType;
    }

    /// <summary>
    /// 其他玩家牌阵恢复
    /// </summary>
    [PacketContract]
    public class ORCOtherPlayerCard
    {
        /// <summary>
        /// 玩家椅子号
        /// </summary>
        [PacketMember(1)]
        public byte chair;
        /// <summary>
        /// 手牌剩余数
        /// </summary>
        [PacketMember(2)]
        public byte handCardNum;
        /// <summary>
        /// 牌池牌
        /// </summary>
        [PacketMember(3)]
        public byte[] poolCard;
        /// <summary>
        /// 定牌
        /// </summary>
        [PacketMember(4)]
        public ORCFixedCard[] fixedCard;
        /// <summary>
        /// 是否听牌
        /// </summary>
        [PacketMember(5)]
        public bool IsTing;
    }

    /// <summary>
    /// 断线重连恢复自己牌阵
    /// </summary>
    [PacketContract]
    public class ORCSelfCard
    {
        /// <summary>
        /// 手牌剩余数
        /// </summary>
        [PacketMember(1)]
        public byte holdCard;
        /// <summary>
        /// 手牌剩余数
        /// </summary>
        [PacketMember(2)]
        public byte[] handCard;
        /// <summary>
        /// 牌池牌
        /// </summary>
        [PacketMember(3)]
        public byte[] poolCard;
        /// <summary>
        /// 定牌
        /// </summary>
        [PacketMember(4)]
        public ORCFixedCard[] fixedCard;

    }

    /// <summary>
    /// 断线重连恢复牌蹲
    /// </summary>
    [PacketContract]
    public class PaiWalls
    {
        /// <summary>
        /// 本局庄家
        /// </summary>
        [PacketMember(1)]
        public byte banker;
        /// <summary>
        ///已经抓牌的数量
        /// </summary>
        [PacketMember(2)]
        public byte paiCount;
        /// <summary>
        /// 已经杠后拿牌的数量
        /// </summary>
        [PacketMember(3)]
        public byte houPai;
    }

    #endregion

    #endregion

    #region 服务端 ==> 客户端 消息体

    /// <summary>
    /// 游戏开始
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_Start)]
    public class CMD_S_Start : GameIF.GameMessage
    {
        /// <summary>
        /// 游戏局数
        /// </summary>
        [PacketMember(1)]
        public int gameNum;

        /// <summary>
        /// 总局数
        /// </summary>
        [PacketMember(2)]
        public int totalGameNum;

        /// <summary>
        /// 当前底中的局数
        /// </summary>
        [PacketMember(3)]
        public int realGameNum;

        ///<summary>
        ///连庄数
        ///</summary>
        [PacketMember(4)]
        public int reMain = 0;

    };

    /// <summary>
    /// 当前活动玩家
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ActivePlayer)]
    public class CMD_S_ActivePlayer : GameIF.GameMessage
    {
        /// <summary>
        /// 活动玩家椅子号
        /// </summary>
        [PacketMember(1)]
        public byte playerChair;
        /// <summary>
        /// 记录倒计时时间
        /// </summary>
        [PacketMember(2)]
        public byte timer;

    };

    ///// <summary>
    ///// 玩家定张信息
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_s2c.CMD_S_PlayerConfirmInfo)]
    //public class CMD_S_PlayerConfirmInfo : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 玩家定张花色
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte[] playerColor;
    //};

    /// <summary>
    /// 客户端开始发牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_StartSendCard)]
    public class CMD_S_StartSendCard : GameIF.GameMessage
    {

    };

    /// <summary>
    /// 玩家断线
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerOffline)]
    public class CMD_S_PlayerOffline : GameIF.GameMessage
    {
        /// <summary>
        /// 断线玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;
    };

    /// <summary>
    /// 玩家断线重连进来
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerOfflineCome)]
    public class CMD_S_PlayerOfflineCome : GameIF.GameMessage
    {
        /// <summary>
        /// 重连玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;
    };

    /// <summary>
    /// 色子及庄家信息
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_SZInfo)]
    public class CMD_S_SZInfo : GameIF.GameMessage
    {
        /// <summary>
        /// 骰子1点数
        /// </summary>
        [PacketMember(1)]
        public byte sz1;

        /// <summary>
        /// 骰子2点数
        /// </summary>
        [PacketMember(2)]
        public byte sz2;

        /// <summary>
        /// 庄家椅子号
        /// </summary>
        [PacketMember(3)]
        public byte bankerChair;
        /// <summary>
        /// 庄家椅子号
        /// </summary>
        [PacketMember(4)]
        public byte lianBanker;
    };

    /// <summary>
    /// 游戏ID
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_GameID)]
    public class CMD_S_GameID : GameIF.GameMessage
    {
        /// <summary>
        /// 游戏id
        /// </summary>
        [PacketMember(1)]
        public string gameid;
    };

    /// <summary>
    /// 初始化牌阵
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_InitCard)]
    public class CMD_S_InitCard : GameIF.GameMessage
    {
        /// <summary>
        /// 牌阵
        /// </summary>
        [PacketMember(1)]
        public byte[] cardAry;
    };
    /// <summary>
    /// 翻开混牌阶段
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_FanKaiHun)]
    public class CMD_S_FanKaiHun : GameIF.GameMessage
    {
        /// <summary>
        /// 混牌
        /// </summary>
        [PacketMember(1)]
        public byte card;
    }
    ///// <summary>
    ///// 通知客户端开始换牌
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_s2c.CMD_S_StartChangeCard)]
    //public class CMD_S_StartChangeCard : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 骰子1
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte sz1;

    //    /// <summary>
    //    /// 骰子2
    //    /// </summary>
    //    [PacketMember(2)]
    //    public byte sz2;
    //};

    ///// <summary>
    ///// 通知客户端开始定张
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_s2c.CMD_S_StartConfirmColor)]
    //public class CMD_S_StartConfirmColor : GameIF.GameMessage
    //{

    //};

    /// <summary>
    /// 一玩家打出牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerOutCard)]
    public class CMD_S_PlayerOutCard : GameIF.GameMessage
    {
        /// <summary>
        /// 打牌的玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 打出的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;
    };

    /// <summary>
    /// 玩家抓牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerHoldCard)]
    public class CMD_S_PlayerHoldCard : GameIF.GameMessage
    {
        /// <summary>
        /// 抓牌玩家椅子号
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 抓到的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;

        /// <summary>
        /// 抓牌总数(正常抓牌)
        /// </summary>
        [PacketMember(3)]
        public byte countPai;

        /// <summary>
        /// 抓牌总数(杠后摸牌)
        /// </summary>
        [PacketMember(4)]
        public byte gangNum;

        /// <summary>
        /// 是否属于正常抓牌（非杠、补花抓牌）
        /// </summary>
        [PacketMember(5)]
        public bool usual;
    };

    /// <summary>
    /// 玩家豹听
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerBaoTing)]
    public class CMD_S_PlayerBaoTing : GameIF.GameMessage
    {
        /// <summary>
        /// 豹听玩家椅子号
        /// </summary>
        [PacketMember(1)]
        public byte chair;

    };

    /// <summary>
    /// 玩家暗杠牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerAnGangCard)]
    public class CMD_S_PlayerAnGangCard : GameIF.GameMessage
    {
        /// <summary>
        /// 杠牌玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 杠的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;
    };

    /// <summary>
    /// 玩家补杠牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerBuGangCard)]
    public class CMD_S_PlayerBuGangCard : GameIF.GameMessage
    {
        /// <summary>
        /// 杠牌玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;
        /// <summary>
        /// 杠的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;
    };

    /// <summary>
    /// 玩家明杠牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerMingGang)]
    public class CMD_S_PlayerMingGang : GameIF.GameMessage
    {
        /// <summary>
        /// 杠牌玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 杠牌玩家
        /// </summary>
        [PacketMember(2)]
        public byte outChair;

        /// <summary>
        /// 杠的牌
        /// </summary>
        [PacketMember(3)]
        public byte card;

    };

    /// <summary>
    /// 抢杠
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_QiangGang)]
    public class CMD_S_QiangGang : GameIF.GameMessage
    {
        /// <summary>
        /// 抢杠玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 抢杠的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;
    };

    /// <summary>
    /// 玩家吃牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerChiCard)]
    public class CMD_S_PlayerChiCard : GameIF.GameMessage
    {
        /// <summary>
        /// 吃牌玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;
        /// <summary>
        /// 吃牌玩家
        /// </summary>
        [PacketMember(2)]
        public byte outChair;
        /// <summary>
        /// 吃的牌
        /// </summary>
        [PacketMember(3)]
        public byte card;
        /// <summary>
        /// 吃的类型
        /// </summary>
        [PacketMember(4)]
        public byte chi_type;
    };

    /// <summary>
    /// 玩家碰牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerPengCard)]
    public class CMD_S_PlayerPengCard : GameIF.GameMessage
    {
        /// <summary>
        /// 碰牌玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;
        /// <summary>
        /// 碰牌玩家
        /// </summary>
        [PacketMember(2)]
        public byte outChair;
        /// <summary>
        /// 碰的牌
        /// </summary>
        [PacketMember(3)]
        public byte card;
    };

    /// <summary>
    /// 玩家豹听
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerBao)]
    public class CMD_S_PlayerBao : GameIF.GameMessage
    {
        /// <summary>
        /// 豹听玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;
    };

    /// <summary>
    /// 玩家胡牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerHuCard)]
    public class CMD_S_PlayerHuCard : GameIF.GameMessage
    {
        /// <summary>
        /// 自摸玩家椅子号
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 自摸的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;

        /// <summary>
        /// 胡牌类型
        /// </summary>
        [PacketMember(3)]
        public byte huType;

        /// <summary>
        /// 本次玩家分数
        /// </summary>
        [PacketMember(4)]
        public int[] huScore;

        /// <summary>
        /// 玩家牌型分
        /// </summary>
        [PacketMember(5)]
        public String vecHuType;

    };

    /// <summary>
    /// 当前操作的真人玩家操作权限等等
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_OpPlayer)]
    public class CMD_S_OpPlayer : GameIF.GameMessage
    {
        /// <summary>
        /// 可以操作的权限:杠，胡
        /// </summary>
        [PacketMember(1)]
        public byte ifCanZiMo;

        /// <summary>
        /// 可以杠的牌
        /// </summary>
        [PacketMember(2)]
        public byte[] gangCard;
    };

    ///// <summary>
    ///// 换牌结果
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_s2c.CMD_S_ChangeCardResult)]
    //public class CMD_S_ChangeCardResult : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 换的牌从哪里来
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte srcChair;

    //    /// <summary>
    //    /// 最新牌阵
    //    /// </summary>
    //    [PacketMember(2)]
    //    public byte[] lastCardAry;

    //    /// <summary>
    //    /// 换到的牌
    //    /// </summary>
    //    [PacketMember(3)]
    //    public byte[] changeCard;
    //};

    /// <summary>
    /// 玩家投票权限
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_VoteRight)]
    public class CMD_S_VoteRight : GameIF.GameMessage
    {
        /// <summary>
        /// 投票操作的牌
        /// </summary>
        [PacketMember(1)]
        public byte voteCard;

        /// <summary>
        /// 投票权限 
        /// </summary>
        [PacketMember(2)]
        public byte voteRight;
    };

    /// <summary>
    /// 玩家牌阵
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerCardData)]
    public class CMD_S_PlayerCardData : GameIF.GameMessage
    {
        /// <summary>
        /// 玩家椅子号
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 胡的牌
        /// </summary>
        [PacketMember(2)]
        public byte huCard;

        /// <summary>
        /// 活动牌阵
        /// </summary>
        [PacketMember(3)]
        public byte[] handCard;
    };

    /// <summary>
    /// 结算信息
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_Balance)]
    public class CMD_S_Balance : GameIF.GameMessage
    {
        /// <summary>
        /// 玩家结算信息
        /// </summary>
        [PacketMember(1)]
        public PlayerCard[] playerCard;
        /// <summary>
        /// 玩家结算信息
        /// </summary>
        [PacketMember(2)]
        public PlayerBalance[] playerBalance;
        /// <summary>
        /// 是否打满局数
        /// </summary>
        [PacketMember(3)]
        public byte isPlayEnougnGameNum;
        /// <summary>
        /// 是否是流局
        /// </summary>
        [PacketMember(4)]
        public bool liuju;
    };

    /// <summary>
    /// 游戏流水账
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_GameFlow)]
    public class CMD_S_GameFlow : GameIF.GameMessage
    {
        /// <summary>
        /// 流水记录
        /// </summary>
        [PacketMember(1)]
        public GameFlowDetail[] gameFlow;
    };

    /// <summary>
    /// 桌子配置
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_TableConfig)]
    public class CMD_S_TableConfig : GameIF.GameMessage
    {
        /// <summary>
        /// 是否拉跑坐
        /// </summary>
        [PacketMember(1)]
        public byte LaPaoZuo;
        /// <summary>
        /// 七对加番
        /// </summary>
        [PacketMember(2)]
        public byte qiduijia;
        /// <summary>
        /// 杠开加番
        /// </summary>
        [PacketMember(3)]
        public int gangkaijia;
        /// <summary>
        /// 13不靠加番
        /// </summary>
        [PacketMember(4)]
        public int bukaojia;
        /// <summary>
        /// 底分
        /// </summary>
        [PacketMember(5)]
        public int CellScore;
        /// <summary>
        /// 金币场底金索引
        /// </summary>
        [PacketMember(6)]
        public int GoldCardBaseIdx;
        /// <summary>
        /// 是否是记分场
        /// </summary>
        [PacketMember(7)]
        public byte IsRecordScoreRoom;
        /// <summary>
        /// 房主id
        /// </summary>
        [PacketMember(8)]
        public uint TableCreatorID;
        /// <summary>
        /// 房主椅子号
        /// </summary>
        [PacketMember(9)]
        public byte TableCreatorChair;
        /// <summary>
        /// 桌号
        /// </summary>
        [PacketMember(10)]
        public string TableCode;
        /// <summary>
        /// 设置底数
        /// </summary>
        [PacketMember(11)]
        public int SetGameNum;
        /// <summary>
        /// 已进行底数
        /// </summary>
        [PacketMember(12)]
        public int GameNum;
        /// <summary>
        /// 当前底中的局数
        /// </summary>
        [PacketMember(13)]
        public int RealGameNum;
        /// <summary>
        /// 自建房是否超时代打
        /// </summary>
        [PacketMember(14)]
        public byte isOutTimeOp;
        /// <summary>
        /// 是不是保留房间
        /// </summary>
        [PacketMember(15)]
        public byte isSaveTable;
        /// <summary>
        /// 保留房间时间
        /// </summary>
        [PacketMember(16)]
        public int saveTableTime;
        /// <summary>
        /// 是不是房主买单
        /// </summary>
        [PacketMember(17)]
        public byte tableCreatorPay;
        /// <summary>
        /// 房费
        /// </summary>
        [PacketMember(18)]
        public int tableCost;
        /// <summary>
        /// 一炮多响
        /// </summary>
        [PacketMember(19)]
        public byte isYiPaoDuoXiang;
        /// <summary>
        /// 是否IP相同
        /// </summary>
        [PacketMember(20)]
        public byte IfCanSameIP;
        /// <summary>
        /// 吃
        /// </summary>
        [PacketMember(21)]
        public byte canChi;
        /// <summary>
        /// 杠分
        /// </summary>
        [PacketMember(22)]
        public byte gangFen;
        /// <summary>
        /// 谁打谁出分
        /// </summary>
        [PacketMember(23)]
        public byte whoLose;
        /// <summary>
        /// 占庄
        /// </summary>
        [PacketMember(24)]
        public byte zhanZhuang;
        /// <summary>
        /// 带大牌
        /// </summary>
        [PacketMember(25)]
        public byte daiDaPai;
        /// <summary>
        /// 玩家数
        /// </summary>
        [PacketMember(26)]
        public int PlayerNum;
        /// <summary>
        /// 等待时间
        /// </summary>
        [PacketMember(27)]
        public int WaitTimeNum;
        /// <summary>
        /// 配子
        /// </summary>
        [PacketMember(28)]
        public int SetPeiZi;
        /// <summary>
        /// 点炮
        /// </summary>
        [PacketMember(29)]
        public byte DianPao;
        /// <summary>
        /// 抢杠胡
        /// </summary>
        [PacketMember(30)]
        public byte QiangGangHu;
        /// <summary>
        /// 
        /// </summary>
        [PacketMember(31)]
        public int tableWhere;
        
    };

    /// <summary>
    /// 手牌数据
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_HandCardData)]
    public class CMD_S_HandCardData : GameIF.GameMessage
    {
        /// <summary>
        /// 手牌最新数据
        /// </summary>
        [PacketMember(1)]
        public byte[] handCardData;
    };

    ///// <summary>
    ///// 玩家自己的定缺
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_s2c.CMD_S_SelfDingQue)]
    //public class CMD_S_SelfDingQue : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 花色
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte color;
    //};

    /// <summary>
    /// 删除抢杠牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_DelQiangGangCard)]
    public class CMD_S_DelQiangGangCard : GameIF.GameMessage
    {
        /// <summary>
        /// 牌
        /// </summary>
        [PacketMember(1)]
        public byte card;
    };

    /// <summary>
    /// 强退成功
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ForceLeftSuccess)]
    public class CMD_S_ForceLeftSuccess : GameIF.GameMessage
    {

    };

    /// <summary>
    /// 创建桌子成功
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_CreateTableSuccess)]
    public class CMD_S_CreateTableSuccess : GameIF.GameMessage
    {

    };

    /// <summary>
    /// 开始创建桌子
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_StartCreateTable)]
    public class CMD_S_StartCreateTable : GameIF.GameMessage
    {
        /// <summary>
        /// 房卡档次
        /// </summary>
        [PacketMember(1)]
        public byte[] payKa;
        /// <summary>
        /// 局数档次
        /// </summary>
        [PacketMember(2)]
        public byte[] juShu;
        /// <summary>
        /// 默认局数
        /// </summary>
        [PacketMember(3)]
        public byte defaultJuShu;
        /// <summary>
        /// 客户端版本号
        /// </summary>
        [PacketMember(4)]
        public string Version;
    };

    /// <summary>
    /// 房主信息
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_TableCreatorInfo)]
    public class CMD_S_TableCreatorInfo : GameIF.GameMessage
    {
        /// <summary>
        /// 房主ID
        /// </summary>
        [PacketMember(1)]
        public uint plyaerID;

        /// <summary>
        /// 房主椅子号
        /// </summary>
        [PacketMember(2)]
        public byte chair;
    };

    /// <summary>
    /// 强制玩家离开
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ForceUserLeft)]
    public class CMD_S_ForceUserLeft : GameIF.GameMessage
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        [PacketMember(1)]
        public string msg;
    };

    /// <summary>
    /// 显示提示消息
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ShowMsg)]
    public class CMD_S_ShowMsg : GameIF.GameMessage
    {
        /// <summary>
        /// 提示信息
        /// </summary>
        [PacketMember(1)]
        public string msg;

        /// <summary>
        /// 提示信息,1:tip,其他为弹窗
        /// </summary>
        [PacketMember(2)]
        public byte tipType;
    };

    /// <summary>
    /// 好友求助信息
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_FriendHelpInfo)]
    public class CMD_S_FriendHelpInfo : GameIF.GameMessage
    {
        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(1)]
        public byte friendChair;

        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(2)]
        public uint friendID;

        /// <summary>
        /// 求助币种
        /// </summary>
        [PacketMember(3)]
        public QL.Common.CurrencyType moneyType;

        /// <summary>
        /// 求助数量
        /// </summary>
        [PacketMember(4)]
        public int moneyNum;
    };

    /// <summary>
    /// 好友拒绝资助
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_FriendReject)]
    public class CMD_S_FriendReject : GameIF.GameMessage
    {
        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(1)]
        public byte friendChair;

        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(2)]
        public uint friendID;
    };

    /// <summary>
    /// 好友资助成功
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_FriendHelpSuccess)]
    public class CMD_S_FriendHelpSuccess : GameIF.GameMessage
    {
        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(1)]
        public byte friendChair;

        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(2)]
        public uint friendID;

        /// <summary>
        /// 是否成功
        /// </summary>
        [PacketMember(3)]
        public byte result;
    };

    /// <summary>
    /// 游戏记录结果
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_GameRecordResult)]
    public class CMD_S_GameRecordResult : GameIF.GameMessage
    {
        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(1)]
        public GameRecordResult[] record;
    };

    /// <summary>
    /// 游戏记录结果
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_QuitCreator)]
    public class CMD_S_QuitCreator : GameIF.GameMessage
    {

    };

    /// <summary>
    /// 新的游戏回合
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_NewGameRound)]
    public class CMD_S_NewGameRound : GameIF.GameMessage
    {

    };

    /// <summary>
    /// 抢杠结果
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_VoteQGResult)]
    public class CMD_S_VoteQGResult : GameIF.GameMessage
    {
        /// <summary>
        /// 抢杠结果
        /// </summary>
        [PacketMember(1)]
        public byte voteqg;
    };

    /// <summary>
    /// 玩家余额
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerMoney)]
    public class CMD_S_PlayerMoney : GameIF.GameMessage
    {
        /// <summary>
        /// 椅子号
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 玩家ID
        /// </summary>
        [PacketMember(2)]
        public uint userID;

        /// <summary>
        /// 金豆
        /// </summary>
        [PacketMember(3)]
        public int gold;

        /// <summary>
        /// 金币
        /// </summary>
        [PacketMember(4)]
        public int goldCard;

        /// <summary>
        /// 钻石
        /// </summary>
        [PacketMember(5)]
        public int diamond;
    };

    /// <summary>
    /// 有玩家申请解散房间
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerDissTable)]
    public class CMD_S_PlayerDissTable : GameIF.GameMessage
    {
        /// <summary>
        /// 发起者
        /// </summary>
        [PacketMember(1)]
        public byte sponsorChair;
    };

    /// <summary>
    /// 玩家投票解散房间
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerVoteDissTable)]
    public class CMD_S_PlayerVoteDissTable : GameIF.GameMessage
    {
        /// <summary>
        /// 投票玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 结果
        /// </summary>
        [PacketMember(2)]
        public byte vote;
    };
    /// <summary>
    /// 解散房间成功
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_DissTableSuccess)]
    public class CMD_S_DissTableSuccess : GameIF.GameMessage
    {
        /// <summary>
        /// 是否游戏中
        /// </summary>
        [PacketMember(1)]
        public byte gameing;
    };
    ///// <summary>
    ///// 海底捞时间
    ///// </summary>
    //[PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_HaiDiLaoTime)]
    //public class CMD_S_HaiDiLaoTime : GameIF.GameMessage
    //{

    //};
    ///// <summary>
    ///// 报警
    ///// </summary>
    //[PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_BaoJing)]
    //public class CMD_S_BaoJing : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 报警玩家
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte chair;
    //};
    /// <summary>
    /// 玩家准备
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_UseReady)]
    public class CMD_S_UseReady : GameIF.GameMessage
    {
        /// <summary>
        /// 本次准备玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

    };
    /// <summary>
    /// 保留桌子成功
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_SaveTableSuccess)]
    public class CMD_S_SaveTableSuccess : GameIF.GameMessage
    {

    };
    /// <summary>
    /// 删除玩家牌池牌牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_DelPoolCard)]
    public class CMD_S_DelPoolCard : GameIF.GameMessage
    {
        /// <summary>
        /// 被删牌玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 被删的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;

        /// <summary>
        /// 被删后，牌池数量
        /// </summary>
        [PacketMember(3)]
        public byte cardnum;
    };

    public class CMD_S_DelPoolCardForChi : GameIF.GameMessage
    {
        /// <summary>
        /// 被删牌玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 被删的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;

        /// <summary>
        /// 被删后，牌池数量
        /// </summary>
        [PacketMember(3)]
        public byte cardnum;
    };

    /// <summary>
    /// 开始跑
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_StartPao)]
    public class CMD_S_StartPao : GameIF.GameMessage
    {
        /// <summary>
        /// 跑
        /// </summary>
        [PacketMember(1)]
        public bool pao;

    };
    /// <summary>
    /// 开始拉
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_StartLa)]
    public class CMD_S_StartLa : GameIF.GameMessage
    {
    };

    /// <summary>
    /// 自己的跑
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_SelfPao)]
    public class CMD_S_SelfPao : GameIF.GameMessage
    {
        /// <summary>
        /// 跑
        /// </summary>
        [PacketMember(1)]
        public byte point;
    };
    /// <summary>
    /// 自己的拉
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_SelfLa)]
    public class CMD_S_SelfLa : GameIF.GameMessage
    {
        /// <summary>
        /// 拉
        /// </summary>
        [PacketMember(1)]
        public byte point;
    };
    /// <summary>
    /// 自己的跑
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerPaoInfo)]
    public class CMD_S_PlayerPaoInfo : GameIF.GameMessage
    {
        /// <summary>
        /// 跑
        /// </summary>
        [PacketMember(1)]
        public byte[] points;
    };
    /// <summary>
    /// 自己的拉
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_PlayerLaInfo)]
    public class CMD_S_PlayerLaInfo : GameIF.GameMessage
    {
        /// <summary>
        /// 拉
        /// </summary>
        [PacketMember(1)]
        public byte[] points;
    };
    #region 断线重连

    /// <summary>
    /// 断线重连游戏信息
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ORC_GameInfo)]
    public class CMD_S_ORC_GameInfo : GameIF.GameMessage
    {
        /// <summary>
        /// 庄家椅子号
        /// </summary>
        [PacketMember(1)]
        public byte bankerChair;

        /// <summary>
        /// 庄家连庄数
        /// </summary>
        [PacketMember(2)]
        public byte lianBanker;

        /// <summary>
        /// 本局id
        /// </summary>
        [PacketMember(3)]
        public string gameid;

        /// <summary>
        /// 当前游戏阶段
        /// </summary>
        [PacketMember(4)]
        public byte gamePhase;

        /// <summary>
        /// 自己是否已经胡牌
        /// </summary>
        [PacketMember(5)]
        public byte selfIsAlreadyHu;
    };

    /// <summary>
    /// 断线重连玩家牌阵
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ORC_PlayerCard)]
    public class CMD_S_ORC_PlayerCard : GameIF.GameMessage
    {
        /// <summary>
        /// 自己牌
        /// </summary>
        [PacketMember(1)]
        public ORCSelfCard selfCard;

        /// <summary>
        /// 其他玩家牌
        /// </summary>
        [PacketMember(2)]
        public ORCOtherPlayerCard[] otherPlayerCard;

        ///<summary>
        ///牌墙
        ///</summary>>
        [PacketMember(3)]
        public PaiWalls paiWall;
    };

    ///// <summary>
    ///// 断线重连恢复换牌阶段
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_s2c.CMD_S_ORC_ChangeCardPhase)]
    //public class CMD_S_ORC_ChangeCardPhase : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 我需要换的牌
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte[] needChangeCard;
    //};

    ///// <summary>
    ///// 断线重连恢复定缺阶段
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_s2c.CMD_S_ORC_DingQuePhase)]
    //public class CMD_S_ORC_DingQuePhase : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 我的定缺
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte selfDingQue;
    //};

    /// <summary>
    /// 断线重连恢复投票阶段
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ORC_Vote)]
    public class CMD_S_ORC_Vote : GameIF.GameMessage
    {
        /// <summary>
        /// 当前打牌玩家
        /// </summary>
        [PacketMember(1)]
        public byte chair;

        /// <summary>
        /// 打出的牌
        /// </summary>
        [PacketMember(2)]
        public byte card;
    };

    /// <summary>
    /// 断线重连结束
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ORC_Over)]
    public class CMD_S_ORC_Over : GameIF.GameMessage
    {
        /// <summary>
        /// 剩余牌张数
        /// </summary>
        [PacketMember(1)]
        public byte leftCardNum;
    };
    /// <summary>
    /// 断线重连恢复胡解散房间
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ORC_DissTable)]
    public class CMD_S_ORC_DissTable : GameIF.GameMessage
    {
        /// <summary>
        /// 发起者
        /// </summary>
        [PacketMember(1)]
        public byte sponsor;

        /// <summary>
        /// 玩家投票结果
        /// </summary>
        [PacketMember(2)]
        public byte[] playerVote;
        /// <summary>
        /// 剩余时间
        /// </summary>
        [PacketMember(3)]
        public byte leftTime;

    };

    /// <summary>
    /// 断线重连局数未打完准备阶段
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ORC_TableFree)]
    public class CMD_S_ORC_TableFree : GameIF.GameMessage
    {
        /// <summary>
        /// 用于玩家断线重连恢复连庄数
        /// </summary>
        [PacketMember(1)]
        public byte lianbank;
    };
    /// <summary>
    /// 断线重连,玩家分数变化
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_ORC_GameScoreChange)]
    public class CMD_S_ORC_GameScoreChange : GameIF.GameMessage
    {
        /// <summary>
        /// 玩家分数变化
        /// </summary>
        [PacketMember(1)]
        public int[] PlayerScoreChange;
    };
    #endregion

    #endregion


    #region 客户端 ==> 服务端 消息体

    /// <summary>
    /// 玩家抓牌结束
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_HoldCardComplete)]
    public class CMD_C_HoldCardComplete : GameIF.GameMessage
    {

    };

    ///// <summary>
    ///// 玩家定张
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_c2s.CMD_C_ConfirmColor)]
    //public class CMD_C_ConfirmColor : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 定张花色
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte confirmColor;
    //};

    /// <summary>
    /// 玩家自摸
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_ZiMo)]
    public class CMD_C_ZiMo : GameIF.GameMessage
    {

    };

    ///// <summary>
    ///// 玩家换牌
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_c2s.CMD_C_ChangeCard)]
    //public class CMD_C_ChangeCard : GameIF.GameMessage
    //{
    //    /// <summary>
    //    /// 要换的牌
    //    /// </summary>
    //    [PacketMember(1)]
    //    public byte[] changeCard;
    //};

    ///// <summary>
    ///// 换牌结束
    ///// </summary>
    //[PacketContract(((byte)WHMJConstants.WHMJ_GAMEID) << 8 | (byte)WHMJMsgID_c2s.CMD_C_ChangeCardEnd)]
    //public class CMD_C_ChangeCardEnd : GameIF.GameMessage
    //{

    //};


    /// <summary>
    /// 玩家杠
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_Gang)]
    public class CMD_C_Gang : GameIF.GameMessage
    {
        /// <summary>
        /// 杠的牌
        /// </summary>
        [PacketMember(1)]
        public byte gangCard;
    };

    /// <summary>
    /// 玩家吃
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_Chi)]
    public class CMD_C_Chi : GameIF.GameMessage
    {
        /// <summary>
        /// 吃的牌
        /// </summary>
        [PacketMember(1)]
        public byte chiCard;
        [PacketMember(2)]
        public byte chiType;
    };

    /// <summary>
    /// 玩家打出牌
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_OutCard)]
    public class CMD_C_OutCard : GameIF.GameMessage
    {
        /// <summary>
        /// 打出的牌
        /// </summary>
        [PacketMember(1)]
        public byte outCard;
    };

    /// <summary>
    /// 玩家投票
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_Vote)]
    public class CMD_C_Vote : GameIF.GameMessage
    {
        /// <summary>
        /// 投票结果
        /// </summary>
        [PacketMember(1)]
        public byte voteResult;
    };

    /// <summary>
    /// 玩家抢杠
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_QiangGang)]
    public class CMD_C_QiangGang : GameIF.GameMessage
    {
        /// <summary>
        /// 是否抢杠
        /// </summary>
        [PacketMember(1)]
        public byte qiangGang;
    };

    /// <summary>
    /// 请求强退
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_ForceLeft)]
    public class CMD_C_ForceLeft : GameIF.GameMessage
    {
        /// <summary>
        /// 请求强退
        /// </summary>
        [PacketMember(1)]
        public uint PlayerID;
    };

    /// <summary>
    /// 创建桌子
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_CreateTable)]
    public class CMD_C_CreateTable : GameIF.GameMessage
    {
        /// <summary>
        /// 是否拉跑坐
        /// </summary>
        [PacketMember(1)]
        public byte LaPaoZuo;
        /// <summary>
        /// 是否七对
        /// </summary>
        [PacketMember(2)]
        public byte QiDuiJia;
        /// <summary>
        /// 带大牌
       /// </summary>
        [PacketMember(3)]
        public byte daiDaPai;
        /// <summary>
        /// 杠开
        /// </summary>
        [PacketMember(4)]
        public int GangKaiJia;
        /// <summary>
        /// 13不靠
        /// </summary>
        [PacketMember(5)]
        public int BuKaoJia;
        /// <summary>
        /// 桌费
        /// </summary>
        [PacketMember(6)]
        public int TableCost;

        /// <summary>
        /// 是否是记分场
        /// </summary>
        [PacketMember(7)]
        public byte IsRecordScoreRoom;
        /// <summary>
        /// 桌号
        /// </summary>
        [PacketMember(8)]
        public string TableCode;
        /// <summary>
        /// 设置局数
        /// </summary>
        [PacketMember(9)]
        public int SetGameNum;
        /// <summary>
        /// 金币场底金索引
        /// </summary>
        [PacketMember(10)]
        public int GoldRoomBaseIdx;
        /// <summary>
        /// 自主建房是否超时代打
        /// </summary>
        [PacketMember(11)]
        public byte isOutTimeOp;
        /// <summary>
        /// 是否房主买单
        /// </summary>
        [PacketMember(12)]
        public byte isTableCreatorPay;
        /// <summary>
        /// 是否一炮多响
        /// </summary>
        [PacketMember(13)]
        public byte isYiPaoDuoXiang;
        /// <summary>
        /// 是否同ip
        /// </summary>
        [PacketMember(14)]
        public byte IfCanSameIp;
        /// <summary>
        /// 谁打谁出分
        /// </summary>
        [PacketMember(15)]
        public byte whoLose;
        /// <summary>
        /// 占庄
        /// </summary>
        [PacketMember(16)]
        public byte zhanZhuang;
        /// <summary>
        /// 杠分
        /// </summary>
        [PacketMember(17)]
        public byte gangFen;
        /// <summary>
        /// 不准吃牌
        /// </summary>
        [PacketMember(18)]
        public byte canChi;

        /// <summary>
        /// 玩家数
        /// </summary>
        [PacketMember(19)]
        public byte PlayerNum;

        /// <summary>
        /// 等待时间
        /// </summary>
        [PacketMember(20)]
        public byte WaitTimeNum;

        /// <summary>
        /// 等待时间
        /// </summary>
        [PacketMember(21)]
        public byte SetPeiZi;

        /// <summary>
        /// 等待时间
        /// </summary>
        [PacketMember(22)]
        public byte DianPao;

        /// <summary>
        /// 等待时间
        /// </summary>
        [PacketMember(23)]
        public byte QiangGangHu;


    };
    /// <summary>
    /// 操作频繁
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_IsDissolution)]
    public class CMD_S_IsDissolution : GameIF.GameMessage
    {


        /// <summary>
        /// 操作频繁
        /// </summary>
        [PacketMember(1)]
        public bool IsDissolution;





    }
    /// <summary>
    /// 向好友求助
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_FriendHelp)]
    public class CMD_C_FriendHelp : GameIF.GameMessage
    {
        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(1)]
        public byte friendChair;

        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(2)]
        public uint friendID;

        /// <summary>
        /// 求助币种
        /// </summary>
        [PacketMember(3)]
        public QL.Common.CurrencyType moneyType;

        /// <summary>
        /// 求助数量
        /// </summary>
        [PacketMember(4)]
        public int moneyNum;
    };

    /// <summary>
    /// 拒绝帮助好友
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_RejectHelp)]
    public class CMD_C_RejectHelp : GameIF.GameMessage
    {
        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(1)]
        public byte friendChair;

        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(2)]
        public uint friendID;
    };

    /// <summary>
    /// 确认帮助好友
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_HelpFriend)]
    public class CMD_C_HelpFriend : GameIF.GameMessage
    {
        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(1)]
        public byte friendChair;

        /// <summary>
        /// 好友椅子号
        /// </summary>
        [PacketMember(2)]
        public uint friendID;

        /// <summary>
        /// 求助币种
        /// </summary>
        [PacketMember(3)]
        public QL.Common.CurrencyType moneyType;

        /// <summary>
        /// 求助数量
        /// </summary>
        [PacketMember(4)]
        public int moneyNum;
    };

    /// <summary>
    /// 查询游戏记录
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_QueryGameRecord)]
    public class CMD_C_QueryGameRecord : GameIF.GameMessage
    {
        /// <summary>
        /// 查询个数,0:返回所有,其他值返回最后一条
        /// </summary>
        [PacketMember(1)]
        public byte queryNum;
    };

    /// <summary>
    /// 玩家申请解散房间
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_OfferDissTable)]
    public class CMD_C_OfferDissTable : GameIF.GameMessage
    {

    };

    /// <summary>
    /// 投票解散房间
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_VoteDissTable)]
    public class CMD_C_VoteDissTable : GameIF.GameMessage
    {
        /// <summary>
        /// 投票结果
        /// </summary>
        [PacketMember(1)]
        public byte voteResult;
    };
    /// <summary>
    /// 玩家准备下一局
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_NextGame)]
    public class CMD_C_NextGame : GameIF.GameMessage
    {

    };
    /// <summary>
    /// 玩家准备下一局
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_ReSetScene)]
    public class CMD_C_ReSetScene : GameIF.GameMessage
    {

    };
    /// <summary>
    /// 保留桌子
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_SaveTable)]
    public class CMD_C_SaveTable : GameIF.GameMessage
    {

    };

    /// <summary>
    /// 玩家跑
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_Pao)]
    public class CMD_C_Pao : GameIF.GameMessage
    {
        /// <summary>
        /// 跑结果
        /// </summary>
        [PacketMember(1)]
        public byte point;
    };
    /// <summary>
    /// 玩家拉
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_La)]
    public class CMD_C_La : GameIF.GameMessage
    {
        /// <summary>
        /// 拉结果
        /// </summary>
        [PacketMember(1)]
        public byte point;
    };

    /// <summary>
    /// 玩家豹听
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_BaoTing)]
    public class CMD_C_BaoTing : GameIF.GameMessage
    {
        /// <summary>
        /// 豹听玩家
        /// </summary>
        [PacketMember(1)]
        public byte point;
    };

    /// <summary>
    /// 玩家放弃豹听
    /// </summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_c2s.CMD_C_GiveUpBaoTing)]
    public class CMD_C_GiveUpBaoTing : GameIF.GameMessage
    {
        /// <summary>
        /// 放弃豹听玩家
        /// </summary>
        [PacketMember(1)]
        public byte point;
    };

    #endregion


    ///<summary>
    ///听牌椅子号
    ///</summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_Ting)]
    public class CMD_S_Ting : GameIF.GameMessage
    {
        /// <summary>
        /// 听牌的人的椅子号
        /// </summary>
        [PacketMember(1)]
        public ushort TingNum;
    }


    ///<summary>
    ///听牌椅子号
    ///</summary>
    [PacketContract(((byte)MGMJConstants.WHMJ_GAMEID) << 8 | (byte)MGMJMsgID_s2c.CMD_S_Version)]
    public class CMD_S_Version : GameIF.GameMessage
    {
        /// <summary>
        /// 服务端版本号
        /// </summary>
        [PacketMember(1)]
        public string Version;
    }
}
