using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahjongAlgorithmForHQMJ
{
    public class HQMJConstants
    {
        /// <summary>
        /// 游戏人数
        /// </summary>
        public const int GAME_PLAYER = 4;
        /// <summary>
        /// 游戏ID
        /// </summary>
        public const int WHMJ_GAMEID = 100;
        /// <summary>
        /// AI用户ID
        /// </summary>
        public const int AIPlayerID = 150000;
        /// <summary>
        /// 游戏名称
        /// </summary>
        public const string GAME_NAME = "霍邱麻将";
        /// <summary>
        /// 游戏版本号
        /// </summary>
        public const string GAME_VERSION = "1.0.0";
        /// <summary>
        /// 空闲状态
        /// </summary>
        public const byte GS_MJ_FREE = 0;
        /// <summary>
        /// 游戏状态
        /// </summary>
        public const byte GS_MJ_PLAY = 1;
        /// <summary>
        /// 牌包数量
        /// </summary>
        public const int gCardCount_Package = 136;
        /// <summary>
        /// 牌包数量
        /// </summary>
        public const int gCardCount_Package2 = 108;
    }
    /// <summary>
    /// 麻将常量定义
    /// </summary>

    public class MahjongDef
    {
        ///////////////////////////////////////////////////////////
        //
        //  数值常量定义
        //
        ///////////////////////////////////////////////////////////
        /// <summary>
        /// 花色掩码
        /// </summary>
        public const byte gCardMask_color = 0xf0;
        /// <summary>
        /// 数值掩码
        /// </summary>
        public const byte gCardMask_value = 0x0f;
        /// <summary>
        /// 无效的麻将牌数值
        /// </summary>
        public const byte gInvalidMahjongValue = 0;
        /// <summary>
        /// 无效的椅子号
        /// </summary>
        public const byte gInvalidChar = 255;
        /// <summary>
        /// 活动牌数量
        /// </summary>
        public const int gCardCount_Active = 14;
        ///// <summary>
        ///// 牌包数量
        ///// </summary>
        //public const int gCardCount_Package = 108;
        /// <summary>
        /// 真人思考时间
        /// </summary>
        public const int gTrueManWaitSecond = 0;
        /// <summary>
        /// 换牌张数
        /// </summary>
        public const int gChangeCardNum = 3;



        /// <summary>
        /// 麻将牌花色:无
        /// </summary>
        public const byte gMahjongColor_Null = 0xff;
        /// <summary>
        /// 麻将牌花色:万
        /// </summary>
        public const byte gMahjongColor_Wan = 0;
        /// <summary>
        /// 麻将牌花色:筒
        /// </summary>
        public const byte gMahjongColor_Tong = 1;
        /// <summary>
        /// 麻将牌花色:条
        /// </summary>
        public const byte gMahjongColor_Tiao = 2;
        /// <summary>
        /// 麻将牌花色:字
        /// </summary>
        public const byte gMahjongColor_Zhi = 3;


        /// <summary>
        /// 投票权限掩码:无
        /// </summary>
        public const byte gVoteRightMask_Null = 0x00;
        /// <summary>
        /// 投票权限掩码:碰
        /// </summary>
        public const byte gVoteRightMask_Peng = 0x01;
        /// <summary>
        /// 投票权限掩码:杠
        /// </summary>
        public const byte gVoteRightMask_Gang = 0x02;
        /// <summary>
        /// 投票权限掩码:胡
        /// </summary>
        public const byte gVoteRightMask_Hu = 0x04;
        /*
         *  投票权限掩码:吃
         */
        public const byte gVoteRightMask_Chi = 0x08;
        /// <summary>
        /// 操作权限掩码:无
        /// </summary>
        public const byte gOperateRightMask_Null = 0x00;
        /// <summary>
        /// 操作权限掩码:可杠
        /// </summary>
        public const byte gOperateRightMask_Gang = 0x01;
        /// <summary>
        /// 操作权限掩码:可自摸
        /// </summary>
        public const byte gOperateRightMask_Zimo = 0x02;


        /// <summary>
        /// 投票结果:弃
        /// </summary>
        public const byte gVoteResult_GiveUp = 0;
        /// <summary>
        /// 投票结果:碰
        /// </summary>
        public const byte gVoteResult_Peng = 1;
        /// <summary>
        /// 投票结果:杠
        /// </summary>
        public const byte gVoteResult_Gang = 2;
        /// <summary>
        /// 投票结果:胡
        /// </summary>
        public const byte gVoteResult_Hu = 3;
        /// <summary>
        /// 投票结果:吃
        /// </summary>
        public const byte gVoteResult_Chi = 4;
        /// <summary>
        /// 无投票操作
        /// </summary>
        public const byte gVoteResult_Null = byte.MaxValue;

        /// <summary>
        /// 花色掩码数组
        /// </summary>
        public static readonly byte[] gMahjongColorMask = { 0x00, 0x10, 0x20, 0x30 };
        /// <summary>
        /// 牌型倍数
        /// </summary>
        public static readonly int[] gMahjongPatternMultiple =
        {
            0,

            #region 4番
            
            4,           //清单调,手里的牌都碰或杠完只剩最后一张。例如：111筒、333筒、555筒、666筒都是碰掉了，手里剩一张2筒，胡2筒
            4,           //清七对,手上的牌是清一色的七对。 例：22334466778899条
            
            #endregion
 
            #region 3番

            3,           //将对,除了一对对牌以外，剩下的都是三张一对的，一共四对。而对牌必须为二、五、八。 例：222555888万55588筒
            3,           //龙七对,手牌为暗七对牌型，没有碰过或者杠过，并且有四张牌是一样的，叫龙七对。不再计七对。例：22333366条337788筒
            3,           //清大对,手上的牌是清一色的对对胡。 例： 22233355566699筒

            #endregion

            #region 2番

            2,           //大单吊,手里的牌都碰或杠完只剩最后一张。例如：111筒、333筒、555条、666条都是碰掉了，手里剩一张2筒或2条，胡2筒或2条
            2,           //带幺九,玩家手牌中，全部都是用1的连牌或者9的连牌组成的牌，且麻将也是1,9。 例：111222333筒78999万
            2,           //小七对,手牌全部是两张一对的，没有碰过和杠过 例：11335566条224466筒
            2,           //清一色,胡牌的手牌全部都是一门花色。 例：11122233345688筒。

            #endregion

            #region 1番

            1,         //对对胡,除了一对对牌以外，剩下的都是三张一对的，一共四对。例： 222666888万33399筒
            1,         //平胡

            #endregion

            #region 天地胡 -1

            -1,        //天胡
            -1         //地胡

            #endregion
        };

        /// <summary>
        /// 牌型名称
        /// </summary>
        public static readonly string[] gMahjongPatternName =
        {
            "无效牌型",
            "清单调",
            "清七对",

            "将对",
            "龙七对",
            "清大对",

            "大单吊",
            "带幺九",
            "小七对",
            "清一色",

            "对对胡",
            "平胡",

            "天胡",
            "地胡"
        };

        /// <summary>
        /// 胡牌类型名称
        /// </summary>
        public static readonly string[] gHuCardTypeName =
        {
            "没有胡牌",
            "自摸",
            "平胡",
            "杠上花",
            "杠上炮",
            "抢杠胡"
        };
    }


    ///////////////////////////////////////////////////////////
    //
    //  枚举定义
    //
    ///////////////////////////////////////////////////////////

    /// <summary>
    /// 游戏阶段
    /// </summary>
    public enum enGamePhase
    {
        /// <summary>
        /// 未知
        /// </summary>
        GamePhase_Unknown = 0,
        /// <summary>
        /// 发牌阶段
        /// </summary>
        GamePhase_SendCard = 1,
        /// <summary>
        /// 换牌阶段
        /// </summary>
        GamePhase_La = 2,
        /// <summary>
        /// 定张阶段
        /// </summary>
        GamePhase_Pao = 3,
        /// <summary>
        /// 玩家操作
        /// </summary>
        GamePhase_PlayerOP = 4,
        /// <summary>
        /// 投票阶段
        /// </summary>
        GamePhase_Vote = 5,
        /// <summary>
        /// 抢杠阶段
        /// </summary>
        GamePhase_QiangGang = 6,
        /// <summary>
        /// 游戏结束
        /// </summary>
        GamePhase_Over = 7

    };

    /// <summary>
    /// 胡牌类型
    /// </summary>
    public enum enHuCardType
    {
        /// <summary>
        /// 没有胡牌
        /// </summary>
        HuCardType_Null = 0,
        /// <summary>
        /// 自摸
        /// </summary>
        HuCardType_ZiMo = 1,
        /// <summary>
        /// 平胡
        /// </summary>
        HuCardType_PingHu = 2,
        /// <summary>
        /// 杠上花
        /// </summary>
        HuCardType_GangShangHua = 3,
        /// <summary>
        /// 杠上炮
        /// </summary>
        HuCardType_GangShaPao = 4,
        /// <summary>
        /// 抢杠胡
        /// </summary>
        HuCardType_QiangGangHu = 5,
    }

    /// <summary>
    /// 麻将牌型
    /// </summary>
    public enum enMahjongPattern
    {
        /// <summary>
        /// 无牌型
        /// </summary>
        MahjongPattern_Null = 0,

        #region 4番

        /// <summary>
        /// 清单调,手里的牌都碰或杠完只剩最后一张。例如：111筒、333筒、555筒、666筒都是碰掉了，手里剩一张2筒，胡2筒
        /// </summary>
        MahjongPattern_QingDanDiao = 1,
        /// <summary>
        /// 清七对,手上的牌是清一色的七对。 例：22334466778899条
        /// </summary>
        MahjongPattern_QingQiDui = 2,

        #endregion

        #region 3番

        /// <summary>
        /// 将对,除了一对对牌以外，剩下的都是三张一对的，一共四对。而对牌必须为二、五、八。 例：222555888万55588筒
        /// </summary>
        MahjongPattern_JiangDui = 3,
        /// <summary>
        /// 龙七对,手牌为暗七对牌型，没有碰过或者杠过，并且有四张牌是一样的，叫龙七对。不再计七对。例：22333366条337788筒
        /// </summary>
        MahjongPattern_LongQiDui = 4,
        /// <summary>
        /// 清大对,手上的牌是清一色的对对胡。 例： 22233355566699筒
        /// </summary>
        MahjongPattern_QingDaDui = 5,

        #endregion

        #region 2番

        /// <summary>
        /// 大单吊,手里的牌都碰或杠完只剩最后一张。例如：111筒、333筒、555条、666条都是碰掉了，手里剩一张2筒或2条，胡2筒或2条
        /// </summary>
        MahjongPattern_DaDanDiao = 6,
        /// <summary>
        /// 带幺九,玩家手牌中，全部都是用1的连牌或者9的连牌组成的牌，且麻将也是1,9。 例：111222333筒78999万
        /// </summary>
        MahjongPattern_DaiYaoJiu = 7,
        /// <summary>
        /// 小七对,手牌全部是两张一对的，没有碰过和杠过 例：11335566条224466筒
        /// </summary>
        MahjongPattern_XiaoQiDui = 8,
        /// <summary>
        /// 清一色,胡牌的手牌全部都是一门花色。 例：11122233345688筒。
        /// </summary>
        MahjongPattern_QingYiShe = 9,

        #endregion

        #region 1番

        /// <summary>
        /// 对对胡,除了一对对牌以外，剩下的都是三张一对的，一共四对。例： 222666888万33399筒
        /// </summary>
        MahjongPattern_DuiDuiHu = 10,
        /// <summary>
        /// 平胡
        /// </summary>
        MahjongPattern_PingHu = 11,

        #endregion

        #region 天地胡

        /// <summary>
        /// 天胡
        /// </summary>
        MahjongPattern_TianHu = 12,
        /// <summary>
        /// 地胡
        /// </summary>
        MahjongPattern_DiHu = 13,

        #endregion
    };

    /// <summary>
    /// 游戏流水类型
    /// </summary>
    public enum enGameFlowType
    {
        /// <summary>
        /// Unknow
        /// </summary>
        GameFlow_Unknown = 0,
        /// <summary>
        /// 暗杠
        /// </summary>
        GameFlow_AnGang = 1,
        /// <summary>
        /// 明杠
        /// </summary>
        GameFlow_MingGang = 2,
        /// <summary>
        /// 补杠
        /// </summary>
        GameFlow_BuGang = 3,

        /// <summary>
        /// 杠上花
        /// </summary>
        GameFlow_GangShangHua = 4,
        /// <summary>
        /// 自摸
        /// </summary>
        GameFlow_ZiMo = 5,
        /// <summary>
        /// 杠上炮
        /// </summary>
        GameFlow_GangShangPao = 6,
        /// <summary>
        /// 抢杠
        /// </summary>
        GameFlow_QiangGang = 7,
        /// <summary>
        /// 胡牌
        /// </summary>
        GameFlow_HuPai = 8,
        /// <summary>
        /// 呼叫转移
        /// </summary>
        GameFlow_GangMove = 9,

        /// <summary>
        /// 查花猪
        /// </summary>
        GameFlow_HuaPig = 10,
        /// <summary>
        /// 查大叫
        /// </summary>
        GameFlow_ChaJiao = 11
    }

    /// <summary>
    /// 玩家状态
    /// </summary>
    public enum enUserStatus
    {
        /// <summary>
        /// 正常状态
        /// </summary>
        userStatus_normal = 1,
        /// <summary>
        /// 断线状态
        /// </summary>
        userStatus_offLine = 2
    }

    /// <summary>
    /// 定牌组类型:碰，暗杠，明杠，补杠
    /// </summary>
    public enum enFixedCardType
    {
        /// <summary>
        /// 未知
        /// </summary>
        FixedCardType_UnKnown = 0,
        /// <summary>
        /// 暗杠
        /// </summary>
        FixedCardType_AGang = 1,
        /// <summary>
        /// 明杠
        /// </summary>
        FixedCardType_MGang = 2,
        /// <summary>
        /// 补杠
        /// </summary>
        FixedCardType_BGang = 3,
        /// <summary>
        /// 碰
        /// </summary>
        FixedCardType_Peng = 4,
        /// <summary>
        /// 吃
        /// </summary>
        FixedCardType_Chi = 5
    };

    /// <summary>
    /// 三元组牌类型
    /// </summary>
    public enum enTripleType
    {
        /// <summary>
        /// 未知
        /// </summary>
        TripleType_Unknown = 0,
        /// <summary>
        /// 暗杠
        /// </summary>
        TripleType_AGang = 1,
        /// <summary>
        /// 明杠
        /// </summary>
        TripleType_MGang = 2,
        /// <summary>
        /// 补杠
        /// </summary>
        TripleType_BGang = 3,
        /// <summary>
        /// 碰
        /// </summary>
        TripleType_Peng = 4,
        /// <summary>
        /// 刻
        /// </summary>
        TripleType_Echo = 5,
        /// <summary>
        /// 顺
        /// </summary>
        TripleType_Flash = 6
    };

    /// <summary>
    /// 听牌类型
    /// </summary>
    public enum enTinType
    {
        /// <summary>
        /// 不成模式
        /// </summary>
        TinType_Nothing = 0,
        /// <summary>
        /// 成组模式,例如:3万,4万,5万成一组 或者三张东风,都是成一组
        /// </summary>
        TinType_Tirple = 1,
        /// <summary>
        /// 含对模式,例如:3万,4万,5万 两个6万 成为含对模式
        /// </summary>
        TinType_HavePair = 2,
        /// <summary>
        /// 需对模式,例如:3万,4万,5万,7万,8万 成为需对模式(如果要想听牌,必须其他牌组必须含对)
        /// </summary>
        TinType_NeedPair = 3,
        /// <summary>
        /// 自由组合对模式,例如:3万,4万,5万,5万,5万 本身成为自由组合对模式(如果要想听牌,其他牌即可含对,也可需对)
        /// </summary>
        TinType_FreePair = 5,
        /// <summary>
        /// 需成组模式,例如:3万,4万,5万,8万,(如果要想听牌,其他牌必须都成组,所以叫需成组模式)
        /// </summary>
        TinType_OtherTriple = 7,
        /// <summary>
        /// 未知
        /// </summary>
        TinType_Unknown = 13
    };

    /// <summary>
    /// 牌阵类型
    /// </summary>
    public enum enCardWrapperType
    {
        /// <summary>
        /// 未知
        /// </summary>
        CardWrapperType_UnKnown = -1,
        /// <summary>
        /// 一张散牌
        /// </summary>
        CardWrapperType_1_Hash = 1,
        /// <summary>
        /// 两张一对
        /// </summary>
        CardWrapperType_2_Pair = 17,
        /// <summary>
        /// 两张相邻
        /// </summary>
        CardWrapperType_2_XL = 16,
        /// <summary>
        /// 两张相隔
        /// </summary>
        CardWrapperType_2_XG = 12,
        /// <summary>
        /// 两张散牌
        /// </summary>
        CardWrapperType_2_Hash = 2,
        /// <summary>
        /// 三张一刻
        /// </summary>
        CardWrapperType_3_Echo = 23,
        /// <summary>
        /// 三张一顺
        /// </summary>
        CardWrapperType_3_Flash = 22,
        /// <summary>
        /// 三张：一对+一张散牌
        /// </summary>
        CardWrapperType_3_PairAndHash = 7,
        /// <summary>
        /// 三张：相邻+一张散牌
        /// </summary>
        CardWrapperType_3_XLAndHash = 6,
        /// <summary>
        /// 三张：相隔+一张散牌
        /// </summary>
        CardWrapperType_3_XGAndHash = 4,
        /// <summary>
        /// 三张散牌
        /// </summary>
        CardWrapperType_3_Hash = 3,
        /// <summary>
        /// 四张一杠
        /// </summary>
        CardWrapperType_4_Gang = 24,
        /// <summary>
        /// 四张：两对
        /// </summary>
        CardWrapperType_4_TwoPair = 20,
        /// <summary>
        /// 四张：一对+相邻
        /// </summary>
        CardWrapperType_4_PairAndXL = 19,
        /// <summary>
        /// 四张：一对+相隔
        /// </summary>
        CardWrapperType_4_PairAndXG = 15,
        /// <summary>
        /// 四张：一对+两散牌
        /// </summary>
        CardWrapperType_4_PairAndTwoHash = 9,
        /// <summary>
        /// 四张：一刻+散牌
        /// </summary>
        CardWrapperType_4_EchoAndHash = 10,
        /// <summary>
        /// 四张：一顺+散牌
        /// </summary>
        CardWrapperType_4_FashAndHash = 11,
        /// <summary>
        /// 四张：四张顺
        /// </summary>
        CardWrapperType_4_Flash = 21,
        /// <summary>
        /// 四张：两个相邻牌
        /// </summary>
        CardWrapperType_4_TwoXL = 18,
        /// <summary>
        /// 四张：两个相隔牌
        /// </summary>
        CardWrapperType_4_TwoXG = 13,
        /// <summary>
        /// 四张：一个相邻，一个相隔
        /// </summary>
        CardWrapperType_4_XLAndXG = 14,
        /// <summary>
        /// 四张：一个相邻+两张散牌
        /// </summary>
        CardWrapperType_4_XLAndTwoHash = 8,
        /// <summary>
        /// 四张：一个相隔+两张散牌
        /// </summary>
        CardWrapperType_4_XGAndTwoHash = 5,
    };

    /// <summary>
    /// 杠类型
    /// </summary>
    public enum enGangType
    {
        Unknown = 0,
        /// <summary>
        /// 暗杠
        /// </summary>
        AnGang = 1,
        /// <summary>
        /// 明杠
        /// </summary>
        MingGang = 2,
        /// <summary>
        /// 补杠
        /// </summary>
        BuGang = 3
    }

    ///////////////////////////////////////////////////////////
    //
    //  结构体定义
    //
    ///////////////////////////////////////////////////////////

    /// <summary>
    /// 换牌辅助
    /// </summary>
    public class clsChangeCardHelper
    {
        /// <summary>
        /// 花色
        /// </summary>
        public byte color { get; set; }
        /// <summary>
        /// 牌阵权值
        /// </summary>
        public int weightValue { get; set; }
        /// <summary>
        /// 牌阵
        /// </summary>
        public List<byte> cardAry { get; set; }

        public clsChangeCardHelper()
        {
            color = MahjongDef.gMahjongColor_Null;
            weightValue = int.MinValue;
        }
    }

    /// <summary>
    /// 游戏算番
    /// </summary>
    public class clsPlayerBalanceFan
    {
        private enMahjongPattern _pattern;
        /// <summary>
        /// 解析牌型
        /// </summary>
        public enMahjongPattern Pattern { get { return _pattern; } set { _pattern = value; } }

        private enHuCardType _huType;
        /// <summary>
        /// 胡牌类型
        /// </summary>
        public enHuCardType HuType { get { return _huType; } set { _huType = value; } }

        private int _genNum;
        /// <summary>
        /// 根数量
        /// </summary>
        public int GenNum { get { return _genNum; } set { _genNum = value; } }

        public void clear()
        {
            _pattern = enMahjongPattern.MahjongPattern_Null;
            _huType = enHuCardType.HuCardType_Null;
            _genNum = 0;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isValid
        {
            get
            {
                if ((enMahjongPattern.MahjongPattern_Null != _pattern) && (enHuCardType.HuCardType_Null != _huType))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 总番数(未加限制,有多少番就算多少番)
        /// </summary>
        public int TotalFanNum
        {
            get
            {
                if (!isValid)
                {
                    return 0;
                }

                int fanNum = MahjongDef.gMahjongPatternMultiple[(int)_pattern] + _genNum;

                switch (_huType)
                {
                    case enHuCardType.HuCardType_GangShaPao:
                    case enHuCardType.HuCardType_QiangGangHu:
                    case enHuCardType.HuCardType_GangShangHua: fanNum += 1; break;
                }

                return fanNum;
            }
        }
    }

    /// <summary>
    /// 游戏流水账
    /// </summary>
    public class clsGameFlow
    {
        /// <summary>
        /// 流水发起者
        /// </summary>
        public ushort PlayerChair { get; set; }
        /// <summary>
        /// 玩家ID
        /// </summary>
        public uint PlayerID { get; set; }
        /// <summary>
        /// 流水类型
        /// </summary>
        public enGameFlowType FlowType { get; set; }
        /// <summary>
        /// 玩家得分
        /// </summary>
        public List<int> PlayerScore { get; set; }

        public clsGameFlow()
        {
            PlayerChair = 0;
            PlayerID = 0;
            FlowType = enGameFlowType.GameFlow_Unknown;
            PlayerScore = new List<int>();
            for (int i = 0; i < HQMJConstants.GAME_PLAYER; i++)
            {
                PlayerScore.Add(0);
            }
        }
    }

    ///// <summary>
    ///// 换牌的两个玩家
    ///// </summary>
    //public class clsSwitchCardPlayer
    //{
    //    /// <summary>
    //    /// 源玩家
    //    /// </summary>
    //    public byte SrcPlayer { get; set; }
    //    /// <summary>
    //    /// 目标玩家
    //    /// </summary>
    //    public byte DestPlayer { get; set; }
    //}

    /// <summary>
    /// 当前打出的牌的信息
    /// </summary>
    public class clsChairCardWrapper
    {
        /// <summary>
        /// 打出的牌的玩家的椅子号
        /// </summary>
        public ushort chair { get; set; }

        /// <summary>
        /// 打出的牌
        /// </summary>
        public byte card { get; set; }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            chair = MahjongDef.gInvalidChar;
            card = MahjongDef.gInvalidMahjongValue;
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isValid
        {
            get
            {
                if ((MahjongDef.gInvalidChar != chair) && (MahjongDef.gInvalidMahjongValue != card))
                {
                    return true;
                }
                return false;
            }
        }
    };

    /// <summary>
    /// 玩家分数
    /// </summary>
    public class clsPlayerScore
    {
        /// <summary>
        /// 胡牌分
        /// </summary>
        public int huScore { get; set; }
        /// <summary>
        /// 明杠
        /// </summary>
        public int MingGang { get; set; }
        /// <summary>
        /// 放杠
        /// </summary>
        public int FangGang { get; set; }
        /// <summary>
        /// 补杠
        /// </summary>
        public int BuGang { get; set; }
        /// <summary>
        /// 暗杠
        /// </summary>
        public int AnGang { get; set; }
        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            huScore = 0;
            MingGang = 0;
            FangGang = 0;
            BuGang = 0;
            AnGang = 0;
        }
        /// <summary>
        /// 总分
        /// </summary>
        public int TotalScore
        {
            get
            {
                return huScore;
            }
        }

        public int GangScore
        {
            get
            {
                return MingGang - FangGang + BuGang * 3 + AnGang * 6;
            }
        }
    }

    /// <summary>
    /// 单个引杠玩家
    /// </summary>
    public class clsSingleCauseGangPlayer
    {
        /// <summary>
        /// 玩家椅子号
        /// </summary>
        public ushort Chair { get; set; }
        /// <summary>
        /// 付的杠钱
        /// </summary>
        public int GangScore { get; set; }
    }

    /// <summary>
    /// 单个杠分记录
    /// </summary>
    public class clsSingleGangRecord
    {
        /// <summary>
        /// 杠类型
        /// </summary>
        public enGangType GangType { get; set; }

        private List<clsSingleCauseGangPlayer> _payPlayer = new List<clsSingleCauseGangPlayer>();
        /// <summary>
        /// 付钱玩家
        /// </summary>
        public List<clsSingleCauseGangPlayer> PayPlayer { get { return _payPlayer; } }

        /// <summary>
        /// 构造
        /// </summary>
        public clsSingleGangRecord()
        {
            this.Clear();
        }

        /// <summary>
        /// 杠分
        /// </summary>
        public int GangScore
        {
            get
            {
                int gangScore = 0;
                foreach (var item in _payPlayer)
                {
                    gangScore += item.GangScore;
                }

                return gangScore;
            }
        }

        /// <summary>
        /// 添加一个付费玩家
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="gangScore"></param>
        public void AddPayPlayer(ushort chair, int gangScore)
        {
            _payPlayer.Add(new clsSingleCauseGangPlayer()
            {
                Chair = chair,
                GangScore = gangScore
            });
        }

        public void Clear()
        {
            GangType = enGangType.Unknown;
            _payPlayer.Clear();
        }
    }

    /// <summary>
    /// 玩家杠记录
    /// </summary>
    public class clsPlayerGangRecord
    {
        /// <summary>
        /// 放杠输的分
        /// </summary>
        private int _loseGangScore;
        /// <summary>
        /// 杠分记录
        /// </summary>
        public List<clsSingleGangRecord> GangRecord { get; set; }

        /// <summary>
        /// 构造
        /// </summary>
        public clsPlayerGangRecord()
        {
            GangRecord = new List<clsSingleGangRecord>();
            this.Clear();
        }

        /// <summary>
        /// 输杠分
        /// </summary>
        public int LoseGangScore
        {
            set
            {
                _loseGangScore += value;
            }
        }

        /// <summary>
        /// 本局本的总计杠得分
        /// </summary>
        public int TotalGangScore
        {
            get
            {
                int winGangScore = 0;
                foreach (var gangRecord in GangRecord)
                {
                    winGangScore += gangRecord.GangScore;
                }
                return winGangScore + _loseGangScore;
            }
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            _loseGangScore = 0;
            GangRecord.Clear();
        }
    }

    /// <summary>
    /// 拆分后的相邻牌组
    /// </summary>
    public class clsSpiltXLWrapper
    {
        /// <summary>
        /// 第一张牌
        /// </summary>
        public byte cCard1;
        /// <summary>
        /// 第二张牌
        /// </summary>
        public byte cCard2;
        /// <summary>
        /// 设置
        /// </summary>
        /// <param name="c1"></param>
        /// <param name="c2"></param>
        public void Set(byte c1, byte c2)
        {
            if (c1 < c2)
            {
                cCard1 = c1;
                cCard2 = c2;
            }
            else
            {
                cCard1 = c2;
                cCard2 = c1;
            }
        }
        /// <summary>
        /// 是否边张组:12,89
        /// </summary>
        /// <returns></returns>
        public bool IsBianWrapper()
        {
            if (MahjongGeneralAlgorithm.GetMahjongValue(cCard1) == 1)
            {
                return true;
            }
            if (MahjongGeneralAlgorithm.GetMahjongValue(cCard2) == 9)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// 获取左边的牌
        /// </summary>
        /// <returns></returns>
        public byte GetLeftValue()
        {
            if (MahjongGeneralAlgorithm.GetMahjongValue(cCard1) == 1)//无左边值
            {
                return (byte)(cCard2 + 1);
            }
            return (byte)(cCard1 - 1);
        }
        /// <summary>
        /// 获取右边的牌
        /// </summary>
        /// <returns></returns>
        public byte GetRightValue()
        {
            if (MahjongGeneralAlgorithm.GetMahjongValue(cCard2) == 9)
            {
                return (byte)(cCard1 - 1);
            }
            return (byte)(cCard2 + 1);
        }
        /// <summary>
        /// 取特征值
        /// </summary>
        /// <returns></returns>
        public int GetTokenNum()
        {
            int wNum = 0;
            if (MahjongGeneralAlgorithm.GetMahjongValue(cCard1) > 5)
            {
                wNum += (10 - MahjongGeneralAlgorithm.GetMahjongValue(cCard1));
            }
            else
            {
                wNum += MahjongGeneralAlgorithm.GetMahjongValue(cCard1);
            }

            if (MahjongGeneralAlgorithm.GetMahjongValue(cCard2) > 5)
            {
                wNum += (10 - MahjongGeneralAlgorithm.GetMahjongValue(cCard2));
            }
            else
            {
                wNum += MahjongGeneralAlgorithm.GetMahjongValue(cCard2);
            }
            return wNum;
        }
        /// <summary>
        /// 取最小的特征牌
        /// </summary>
        /// <returns></returns>
        public byte GetMinCard()
        {
            if (cCard1 == cCard2)
            {
                return cCard1;
            }
            if (MahjongGeneralAlgorithm.GetMahjongValue(cCard2) < 6)//45
            {
                return cCard1;
            }
            if (MahjongGeneralAlgorithm.GetMahjongValue(cCard1) > 5)//67
            {
                return cCard2;
            }
            return cCard2;//56
        }
        public void Clear()
        {
            cCard1 = cCard2 = MahjongDef.gInvalidMahjongValue;
        }

    };

    /// <summary>
    /// 解析后的三元组定牌阵
    /// </summary>
    public class clsParseTriple
    {
        //特征牌
        public byte cTokenCard;
        //牌阵
        public byte[] cCardAry = new byte[3];
        //三元组类型
        public enTripleType enTripleType;

        public void Clear()
        {
            cTokenCard = MahjongDef.gInvalidMahjongValue;
            Array.Clear(cCardAry, 0, 3);
            enTripleType = enTripleType.TripleType_Unknown;
        }
        /// <summary>
        /// 特征数,这是一个很重要的属性,大量使用在算翻中  
        /// 1,如果一个牌组是顺子,他的特征数就是100+最小牌的牌码
        /// 2,如果一个牌组是刻或者杠(算翻中,刻和杠在大部分情况下是同样的),他的特征数就是200+最小牌的牌码
        /// 基于这个属性,可以快速方便地进行算翻处理
        /// </summary>
        /// <returns></returns>
        public int GetTokenNum()
        {
            if (enTripleType == enTripleType.TripleType_Unknown)
            {
                return 0;
            }
            int wBaseNum = (enTripleType == enTripleType.TripleType_Flash ? 100 : 200);
            return (wBaseNum + MahjongGeneralAlgorithm.GetMahjongLogicValue(cTokenCard));
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        /// <returns></returns>
        public bool isValid
        {
            get
            {
                if ((MahjongDef.gInvalidMahjongValue != cTokenCard) && (enTripleType.TripleType_Unknown != enTripleType))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// 是否有19牌
        /// </summary>
        /// <returns></returns>
        public bool have19Card
        {
            get
            {
                if (!isValid)
                {
                    return false;
                }
                if (MahjongDef.gMahjongColor_Zhi == MahjongGeneralAlgorithm.GetMahjongColor(cTokenCard))
                {
                    return false;
                }
                for (int i = 0; i < 3; i++)
                {
                    if ((1 == MahjongGeneralAlgorithm.GetMahjongValue(cCardAry[i])) || (9 == MahjongGeneralAlgorithm.GetMahjongValue(cCardAry[i])))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    };

    /// <summary>
    /// 模式解析中的对组包装
    /// 例如:将牌22333567789解析为
    /// 对:22
    /// 牌组:333,567,789
    /// 其中,333,567,789作为clsParseTriple加入到tagTripleList中
    /// </summary>
    public class clsPairTripleWrapper
    {
        //解析后的对子
        public byte cPair;

        //解析后的三元组
        public clsParseTriple[] tagTripleList = new clsParseTriple[4];

        //三元组个数
        public int wTripleCount;
        /// <summary>
        /// 构造
        /// </summary>
        public clsPairTripleWrapper()
        {
            cPair = MahjongDef.gInvalidMahjongValue;
            wTripleCount = 0;
            for (int i = 0; i < 4; i++)
            {
                tagTripleList[i] = new clsParseTriple();
            }
        }
        /// <summary>
        /// 添加一个triple
        /// </summary>
        /// <param name="triple"></param>
        /// <returns></returns>
        public bool AddTriple(clsParseTriple triple)
        {
            if (wTripleCount >= 4)
            {
                return false;
            }
            tagTripleList[wTripleCount] = triple;
            ++wTripleCount;
            return true;
        }
        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            cPair = MahjongDef.gInvalidMahjongValue;
            wTripleCount = 0;
            for (uint i = 0; i < 4; i++)
            {
                tagTripleList[i].Clear();
            }
        }
        /// <summary>
        /// 值
        /// </summary>
        public int tripleValue
        {
            get
            {
                int wTripleValue = 0;
                for (int i = 0; i < wTripleCount; i++)
                {
                    wTripleValue += tagTripleList[i].GetTokenNum();
                }
                return wTripleValue;
            }
        }
    };

    /// <summary>
    /// 计牌器,记录某些牌还剩余多少
    /// </summary>
    public class clsRememberCard
    {
        private int[] leftCardCount = new int[38];

        //重置
        public void Clear()
        {
            for (int i = 0; i < 38; i++)
            {
                leftCardCount[i] = i % 10 == 0 ? 0 : 4;
                if (i % 10 == 0)
                {
                    leftCardCount[i] = 0;
                }
                else
                {
                    leftCardCount[i] = 4;
                }
            }
        }

        /// <summary>
        /// 取一张牌剩余的张数
        /// </summary>
        /// <param name="card"></param>
        /// <param name="checkSrc"></param>
        /// <returns></returns>
        public int GetCardLeftCount(byte card, List<byte> checkSrc = null)
        {
            if (MahjongGeneralAlgorithm.GetMahjongLogicValue(card) >= 38)
            {
                return 0;
            }

            int left = leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)];

            if (left < 1)
            {
                return left;
            }

            int count = 0;

            if (null != checkSrc)
            {
                count = checkSrc.FindAll(delegate(byte checkCard) { return checkCard == card; }).Count();
            }

            return left >= count ? left - count : 0;
        }

        /// <summary>
        /// 取一张牌剩余的张数
        /// </summary>
        /// <param name="card"></param>
        /// <param name="checkSrc"></param>
        /// <returns></returns>
        public int GetCardLeftCount(List<byte> card, List<byte> checkSrc = null)
        {
            int left = 0;

            for (int i = 0; i < card.Count; i++)
            {
                if (MahjongGeneralAlgorithm.GetMahjongLogicValue(card[i]) >= 38)
                {
                    continue;
                }
                left += leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card[i])];
            }

            if (left < 1)
            {
                return left;
            }

            int count = 0;

            if (null != checkSrc)
            {
                for (int i = 0; i < card.Count; i++)
                {
                    if (MahjongGeneralAlgorithm.GetMahjongLogicValue(card[i]) >= 38)
                    {
                        continue;
                    }

                    count = checkSrc.FindAll(delegate(byte checkCard) { return checkCard == card[i]; }).Count();
                }
            }

            return left >= count ? left - count : 0;
        }

        //打出一张牌
        public void OutCard(byte card)
        {
            if (MahjongGeneralAlgorithm.GetMahjongLogicValue(card) >= 38)
            {
                return;
            }
            leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)] -= leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)] > 0 ? 1 : 0;
        }
        //吃了一张牌
        public void ChiCard(byte card)
        {
            if (MahjongGeneralAlgorithm.GetMahjongLogicValue(card) >= 38)
            {
                return;
            }
            leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)] -= 1;
        }
        //碰了一张牌
        public void PengCard(byte card)
        {
            if (MahjongGeneralAlgorithm.GetMahjongLogicValue(card) >= 38)
            {
                return;
            }
            leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)] -= leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)] > 2 ? 3 : leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)];
        }

        //杠了一张牌
        public void GangCard(byte card)
        {
            if (MahjongGeneralAlgorithm.GetMahjongLogicValue(card) >= 38)
            {
                return;
            }
            leftCardCount[MahjongGeneralAlgorithm.GetMahjongLogicValue(card)] = 0;
        }
    }

    /// <summary>
    /// 单个定牌
    /// </summary>
    public class clsSingleFixedCard
    {
        /// <summary>
        /// 牌值
        /// </summary>
        public byte card { get; set; }
        /// <summary>
        /// 定牌类型
        /// </summary>
        public enFixedCardType fixedType { get; set; }
        /// <summary>
        /// 放的玩家
        /// </summary>
        public byte outChair { get; set; }
        /// <summary>
        /// 是否弃杠转碰
        /// </summary>
        public bool isGiveUpGang2Peng { get; set; }
        /// <summary>
        /// 吃牌类型
        /// </summary>
        public byte chiSel { get; set; }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            card = MahjongDef.gInvalidMahjongValue;
            outChair = MahjongDef.gInvalidChar;
            fixedType = enFixedCardType.FixedCardType_UnKnown;
            isGiveUpGang2Peng = false;
        }

        /// <summary>
        /// 复制到目标
        /// </summary>
        /// <param name="dest"></param>
        public void CopyTo(ref clsSingleFixedCard dest)
        {
            dest.card = this.card;
            dest.outChair = outChair;
            dest.fixedType = this.fixedType;
            dest.isGiveUpGang2Peng = this.isGiveUpGang2Peng;
        }
    };

    /// <summary>
    /// 定牌包装
    /// </summary>
    public class clsFixedCard
    {
        //定牌数据
        private List<clsSingleFixedCard> _fixedCardList = new List<clsSingleFixedCard>();

        /// <summary>
        /// 定牌
        /// </summary>
        public List<clsSingleFixedCard> fixedCard { get { return _fixedCardList; } }

        public List<byte> FixedList()
        {
            List<byte> temp = new List<byte>();
            foreach (var VARIABLE in _fixedCardList)
            {
                temp.Add(VARIABLE.card);
                temp.Add((byte)VARIABLE.fixedType);
            }
            return temp;
        }
        /// <summary>
        /// 添加一个
        /// </summary>
        /// <param name="cCard"></param>
        /// <param name="pos"></param>
        /// <param name="type"></param>
        public void Add(byte cbCard, byte outchair, enFixedCardType type, bool giveUpGang2Peng = false,byte chiSel = 3)
        {
            _fixedCardList.Add(new clsSingleFixedCard()
            {
                card = cbCard,
                outChair = outchair,
                fixedType = type,
                isGiveUpGang2Peng = enFixedCardType.FixedCardType_Peng == type ? giveUpGang2Peng : false,
                chiSel = chiSel
            });
        }

        /// <summary>
        /// 碰转杠
        /// </summary>
        /// <param name="cCard"></param>
        /// <returns>此次碰转杠是否需要收费补杠费用</returns>
        public bool ChangePengToGang(byte cCard)
        {
            foreach (var fixedCard in _fixedCardList)
            {
                if ((enFixedCardType.FixedCardType_Peng == fixedCard.fixedType) && (cCard == fixedCard.card))
                {
                    bool isGiveUpGang2Peng = fixedCard.isGiveUpGang2Peng;

                    fixedCard.fixedType = enFixedCardType.FixedCardType_BGang;
                    fixedCard.isGiveUpGang2Peng = false;

                    return !isGiveUpGang2Peng;
                }
            }

            return false;
        }

        /// <summary>
        /// 查找碰
        /// </summary>
        /// <param name="cbCard"></param>
        /// <returns></returns>
        public bool FindPeng(byte cbCard)
        {
            foreach (var fixedCard in _fixedCardList)
            {
                if ((enFixedCardType.FixedCardType_Peng == fixedCard.fixedType) && (cbCard == fixedCard.card))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 清除数据
        /// </summary>
        public void Clear()
        {
            _fixedCardList.Clear();
        }

        /// <summary>
        /// 拷贝到目标
        /// </summary>
        /// <param name="dest"></param>
        public void CopyTo(ref clsFixedCard dest)
        {
            dest.Clear();
            foreach (var fixedCard in _fixedCardList)
            {
                dest.Add(fixedCard.card, fixedCard.outChair, fixedCard.fixedType, fixedCard.isGiveUpGang2Peng);
            }
        }

        /// <summary>
        /// 从源拷贝
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public clsFixedCard CopyFrom(ref clsFixedCard src)
        {
            this.Clear();
            foreach (var fixedCard in src.fixedCard)
            {
                this.Add(fixedCard.card, fixedCard.outChair, fixedCard.fixedType, fixedCard.isGiveUpGang2Peng, fixedCard.chiSel);
            }
            return this;
        }
    };

    /// <summary>
    /// 活动牌
    /// </summary>
    public class clsActiveCard
    {
        //牌阵数据
        private List<byte> _activeCard = new List<byte>();
        /// <summary>
        /// 
        /// </summary>
        public List<byte> handCard { get { return _activeCard; } }

        /// <summary>
        /// 添加一张牌
        /// </summary>
        /// <param name="cCard"></param>
        /// <returns></returns>
        public bool Add(byte cCard)
        {
            if (MahjongDef.gInvalidMahjongValue == cCard)
            {
                return false;
            }
            _activeCard.Add(cCard);
            _activeCard.Sort();
            return true;
        }

        /// <summary>
        /// 添加一组数据
        /// </summary>
        /// <param name="vSrc"></param>
        /// <returns></returns>
        public bool Add(List<byte> vSrc)
        {
            _activeCard.AddRange(vSrc);
            _activeCard.Sort();
            return true;
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        /// <param name="vTarget"></param>
        /// <returns></returns>
        public bool Remove(List<byte> delCard)
        {
            if (delCard.Count() == 0)
            {
                return true;
            }
            foreach (var card in delCard)
            {
                _activeCard.Remove(card);
            }
            _activeCard.Sort();

            return true;
        }

        /// <summary>
        /// 删除一组数据
        /// </summary>
        /// <param name="vTarget"></param>
        /// <returns></returns>
        public bool Remove(byte cbCard, int removeCount = 1)
        {
            if ((removeCount < 1) || (MahjongDef.gInvalidMahjongValue == cbCard))
            {
                return true;
            }
            if (_activeCard.FindAll(p => { return p == cbCard; }).Count >= removeCount)
            {
                while (removeCount-- > 0)
                {
                    _activeCard.Remove(cbCard);
                }
                return true;
            }
            return false;
        }

        /// <summary>
        /// 查找
        /// </summary>
        /// <param name="cCard"></param>
        /// <param name="wCount"></param>
        /// <returns></returns>
        public bool Find(byte cCard, int wCount = 1)
        {
            return _activeCard.FindAll(delegate(byte checkCard) { return checkCard == cCard; }).Count() >= wCount;
        }

        /// <summary>
        /// 返回牌阵中某张牌的数量
        /// </summary>
        /// <param name="cCard"></param>
        /// <returns></returns>
        public int GetAppointCardCount(byte cCard)
        {
            return _activeCard.FindAll(delegate(byte checkCard) { return checkCard == cCard; }).Count();
        }

        /// <summary>
        /// 是否有某个花色的牌
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool haveColorCard(byte color)
        {
            return _activeCard.FindIndex(p => { return color == MahjongGeneralAlgorithm.GetMahjongColor(p); }) >= 0;
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            _activeCard.Clear();
        }

        /// <summary>
        /// 最后一张有效的牌
        /// </summary>
        public byte LastInvalidCard
        {
            get
            {
                if (_activeCard.Count < 1)
                {
                    return MahjongDef.gInvalidMahjongValue;
                }

                return _activeCard[_activeCard.Count - 1];
            }
        }
    };

    //玩家牌
    public class clsPlayerCard
    {
        /// <summary>
        /// 活动牌
        /// </summary>
        public clsActiveCard activeCard = new clsActiveCard();
        /// <summary>
        /// 定牌
        /// </summary>
        public clsFixedCard fixedCard = new clsFixedCard();
        /// <summary>
        /// 牌池牌
        /// </summary>
        public List<byte> poolCard = new List<byte>();
        /// <summary>
        /// 听牌
        /// </summary>
        public List<byte> tingCard = new List<byte>();

        /// <summary>
        /// 重置
        /// </summary>
        public void Clear()
        {
            activeCard.Clear();
            fixedCard.Clear();

            poolCard.Clear();
            tingCard.Clear();
        }

        /// <summary>
        /// 拷贝一个临时副本
        /// </summary>
        /// <param name="activeCard"></param>
        /// <param name="fixedCard"></param>
        /// <param name="tingCard"></param>
        public void CopyACounterpart(List<byte> ac, ref clsFixedCard fc, List<byte> tc)
        {
            ac.Clear();
            fc.Clear();
            tc.Clear();

            ac.AddRange(activeCard.handCard);
            tc.AddRange(tingCard);
            fc.CopyFrom(ref fixedCard);
        }

        /// <summary>
        /// 复制一份活动牌副本
        /// </summary>
        /// <param name="activeCard"></param>
        public void CopyACounterpartForActiveCard(List<byte> ac)
        {
            ac.Clear();
            ac.AddRange(activeCard.handCard);
        }

        /// <summary>
        /// 复制一份听牌副本
        /// </summary>
        /// <param name="tingCard"></param>
        public void CopyACounterpartForTingCard(List<byte> tc)
        {
            tc.Clear();
            tc.AddRange(tingCard);
        }

        /// <summary>
        /// 复制一份定牌副本
        /// </summary>
        /// <param name="fixedCard"></param>
        public void CopyACounterpartForFixedCard(ref clsFixedCard fc)
        {
            fc.Clear();
            fc.CopyFrom(ref fixedCard);
        }
    };

    /// <summary>
    /// 普通胡牌结构
    /// </summary>
    public class clsNormalParseStruct
    {
        /// <summary>
        /// 解析后的对子
        /// </summary>
        public byte pair { get; set; }
        /// <summary>
        /// 三元组集合
        /// </summary>
        public List<clsParseTriple> triplyAry { get; set; }
        /// <summary>
        /// 活动牌
        /// </summary>
        public List<byte> activeCard { get; set; }

        public clsNormalParseStruct()
        {
            triplyAry = new List<clsParseTriple>();
            activeCard = new List<byte>();
        }

        public void Clear()
        {
            pair = MahjongDef.gInvalidMahjongValue;
            triplyAry.Clear();
            activeCard.Clear();
        }

        public bool isValid
        {
            get
            {
                return pair != MahjongDef.gInvalidMahjongValue;
            }
        }
    }

    /// <summary>
    /// 解析结构
    /// </summary>
    public class clsParseResult
    {
        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isValid { get; set; }
        /// <summary>
        /// 是否7对子牌型
        /// </summary>
        public bool is7Pair { get; set; }
        /// <summary>
        /// 胡的牌
        /// </summary>
        public byte huCard { get; set; }

        /// <summary>
        /// 7对子牌阵数据
        /// </summary>
        public List<byte> cardAryBy7Pair { get; set; }

        /// <summary>
        /// 普通解析结构
        /// </summary>
        public clsNormalParseStruct normalParse { get; set; }

        public clsParseResult()
        {
            cardAryBy7Pair = new List<byte>();
            normalParse = new clsNormalParseStruct();
            this.Clear();
        }

        /// <summary>
        /// 清除
        /// </summary>
        public void Clear()
        {
            isValid = false;
            is7Pair = false;
            huCard = MahjongDef.gInvalidMahjongValue;

            cardAryBy7Pair.Clear();
            normalParse.Clear();
        }
    };

    /// <summary>
    /// 结算番
    /// </summary>
    public class clsBalanceFan
    {
        /// <summary>
        /// 胡牌牌型
        /// </summary>
        public enMahjongPattern cardPattern { get; set; }
        /// <summary>
        /// 胡牌类型 ：平胡 或 自摸 
        /// </summary>
        public enHuCardType huType { get; set; }
        /// <summary>
        /// 明杠
        /// </summary>
        public int MingGang { get; set; }
        /// <summary>
        /// 放杠
        /// </summary>
        public int FangGang { get; set; }
        /// <summary>
        /// 补杠
        /// </summary>
        public int BuGang { get; set; }
        /// <summary>
        /// 暗杠
        /// </summary>
        public int AnGang { get; set; }
        /// <summary>
        /// 杠后开花
        /// </summary>
        public bool GangHouKaiHua { get; set; }
        /// <summary>
        /// 七对
        /// </summary>
        public bool QiDui { get; set; }
        /// <summary>
        /// 13不靠
        /// </summary>
        public bool BuKao { get; set; }
        /// <summary>
        /// 抢杠
        /// </summary>
        public bool QiangGang { get; set; }




        public clsBalanceFan()
        {
            this.Clear();
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void Clear()
        {
            cardPattern = enMahjongPattern.MahjongPattern_Null;
            huType = enHuCardType.HuCardType_Null;

            MingGang = 0;
            FangGang = 0;
            BuGang = 0;
            AnGang = 0;

            GangHouKaiHua = false;
            QiDui = false;
            BuKao = false;
            QiangGang = false;
        }

        /// <summary>
        /// 打包
        /// </summary>
        public void Package(ref List<byte> jiesuan)
        {
            cardPattern = enMahjongPattern.MahjongPattern_Null;
            huType = enHuCardType.HuCardType_Null;
            jiesuan.Clear();
            //庄第一位，好修改0
            jiesuan.Add(0);
            //拉/坐
            jiesuan.Add(0);
            //跑
            jiesuan.Add(0);
            //3
            jiesuan.Add((byte)MingGang);
            //4
            jiesuan.Add((byte)FangGang);
            //5
            jiesuan.Add((byte)BuGang);
            //6
            jiesuan.Add((byte)AnGang);
            //7
            jiesuan.Add((byte)(GangHouKaiHua ? 1 : 0));
            //8
            jiesuan.Add(0);
            //9
            jiesuan.Add((byte)(BuKao ? 1 : 0));
            //10
            jiesuan.Add((byte)(QiangGang ? 1 : 0));

            //庄在胡牌的时候自己改
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isValid
        {
            get
            {
                if ((enMahjongPattern.MahjongPattern_Null != cardPattern) && (enHuCardType.HuCardType_Null != huType))
                {
                    return true;
                }
                return false;
            }
        }
    }

    /// <summary>
    /// 一个牌阵的特征型包装
    /// </summary>
    public class clsCardCharacterWrapper
    {
        /// <summary>
        /// 牌型
        /// </summary>
        public enCardWrapperType cardWrapperType { get; set; }

        /// <summary>
        /// 牌数据，按权值从小到大排序，第一个是最优打出的
        /// </summary>
        public List<byte> cardData { get; set; }

        public clsCardCharacterWrapper()
        {
            cardWrapperType = enCardWrapperType.CardWrapperType_UnKnown;
            cardData = new List<byte>();
        }

        public void clear()
        {
            cardWrapperType = enCardWrapperType.CardWrapperType_UnKnown;
            cardData.Clear();
        }
    };
    /// <summary>
    /// 解散桌子
    /// </summary>
    public class clsDissTable
    {
        //发起者
        private byte _sponsorChair;
        /// <summary>
        /// 解散桌子的发起者
        /// </summary>
        public byte SponsorChair { get { return this._sponsorChair; } set { this._sponsorChair = value; this.playerVote(value, 1); } }

        //玩家投票结果
        private byte[] _playerVote;
        /// <summary>
        /// 玩家投票
        /// </summary>
        public byte[] PlayerVote { get { return this._playerVote; } }

        public clsDissTable()
        {
            _playerVote = new byte[HQMJConstants.GAME_PLAYER];
            clear();
        }

        /// <summary>
        /// 玩家投票
        /// </summary>
        /// <param name="chair"></param>
        /// <param name="vote">1同意,2拒绝</param>
        /// <returns></returns>
        public bool playerVote(byte chair, byte vote)
        {
            this._playerVote[chair] = vote;
            var agreeDis = 0;
            for(var i=0;i<4;i++)
            {
                if (2 == this._playerVote[i])
                {
                    return false;
                }
                if (1 == this._playerVote[i])
                {
                    agreeDis++;                  
                }
            }
            if (agreeDis >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void clear()
        {
            this._sponsorChair = MahjongDef.gInvalidChar;
            Array.Clear(this._playerVote, 0, HQMJConstants.GAME_PLAYER);
        }

        /// <summary>
        /// 是否有效
        /// </summary>
        public bool isValid
        {
            get
            {
                return MahjongDef.gInvalidChar != this._sponsorChair;
            }
        }
    }
    /// <summary>
    /// AI操作辅助
    /// </summary>
    public class clsAIOPHelper
    {
        //打清一色花色
        private byte _qys_color;

        public clsAIOPHelper()
        {
            this.clear();
        }

        /// <summary>
        /// 清理
        /// </summary>
        public void clear()
        {
            _qys_color = MahjongDef.gMahjongColor_Null;
        }

        /// <summary>
        /// 是否往清一色方向操作
        /// </summary>
        public bool isOp2QYS
        {
            get { return MahjongDef.gMahjongColor_Null != _qys_color; }
        }

        /// <summary>
        /// 设置清一色牌型花色
        /// </summary>
        public byte QYSColor
        {
            get { return _qys_color; }
            set { _qys_color = value; }
        }
    }
}
