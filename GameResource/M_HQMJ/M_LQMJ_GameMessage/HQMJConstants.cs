using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_HQMJ_GameMessage
{
    /// <summary>
    /// 客户端至服务端的消息码定义
    /// </summary>
    [QL.Serialization.PackCommonID]
    public class HQMJMsgID_c2s
    {
        /// <summary>
        /// 结束抓牌动画
        /// </summary>
        public const byte CMD_C_HoldCardComplete = 10;
        /// <summary>
        /// 确定跑
        /// </summary>
        public const byte CMD_C_Pao = 11;
        /// <summary>
        /// 确定拉
        /// </summary>
        public const byte CMD_C_La = 12;
        ///// <summary>
        ///// 玩家定张
        ///// </summary>
        //public const byte CMD_C_ConfirmColor = 13;
        /// <summary>
        /// 打出牌
        /// </summary>
        public const byte CMD_C_OutCard = 14;
        /// <summary>
        /// 杠
        /// </summary>
        public const byte CMD_C_Gang = 15;
        /// <summary>
        /// 吃
        /// </summary>
        public const byte CMD_C_Chi = 31;
        /// <summary>
        /// 自摸
        /// </summary>
        public const byte CMD_C_ZiMo = 16;
        /// <summary>
        /// 投票
        /// </summary>
        public const byte CMD_C_Vote = 17;
        /// <summary>
        /// 玩家抢杠
        /// </summary>
        public const byte CMD_C_QiangGang = 18;
        /// <summary>
        /// 请求强退
        /// </summary>
        public const byte CMD_C_ForceLeft = 19;
        /// <summary>
        /// 创建桌子
        /// </summary>
        public const byte CMD_C_CreateTable = 20;
        /// <summary>
        /// 向好友求助
        /// </summary>
        public const byte CMD_C_FriendHelp = 21;
        /// <summary>
        /// 拒绝求助
        /// </summary>
        public const byte CMD_C_RejectHelp = 22;
        /// <summary>
        /// 帮助好友
        /// </summary>
        public const byte CMD_C_HelpFriend = 23;
        /// <summary>
        /// 查询游戏记录
        /// </summary>
        public const byte CMD_C_QueryGameRecord = 25;
        /// <summary>
        /// 申请解散房间
        /// </summary>
        public const byte CMD_C_OfferDissTable = 26;
        /// <summary>
        /// 投票解散房间
        /// </summary>
        public const byte CMD_C_VoteDissTable = 27;
        /// <summary>
        /// 玩家准备
        /// </summary>
        public const byte CMD_C_NextGame = 28;
        /// <summary>
        /// 重置场景
        /// </summary>
        public const byte CMD_C_ReSetScene = 29;
        /// <summary>
        /// 保留房间
        /// </summary>
        public const byte CMD_C_SaveTable = 30;
        /// <summary>
        /// 豹听
        /// </summary>
        public const byte CMD_C_BaoTing = 32;
        /// <summary>
        /// 放弃豹听
        /// </summary>
        public const byte CMD_C_GiveUpBaoTing = 33;
        /// <summary>
        /// 续局
        /// </summary>
        public const byte CMD_C_AddGameNum = 34;
    }

    /// <summary>
    /// 服务端至客户端的消息码定义
    /// </summary>
    [QL.Serialization.PackCommonID]
    public class HQMJMsgID_s2c
    {
        /// <summary>
        /// 版本号
        /// </summary>
        public const byte CMD_S_Version = 160;
        /// <summary>
        /// 游戏开始
        /// </summary>
        public const byte CMD_S_Start = 100;
        /// <summary>
        /// 骰子信息
        /// </summary>
        public const byte CMD_S_SZInfo = 101;
        /// <summary>
        /// 初始化牌
        /// </summary>
        public const byte CMD_S_InitCard = 102;
        /// <summary>
        /// 游戏ID
        /// </summary>
        public const byte CMD_S_GameID = 103;
        ///// <summary>
        ///// 开始换牌
        ///// </summary>
        //public const byte CMD_S_StartChangeCard = 104;
        /// <summary>
        /// 玩家抓了一张牌
        /// </summary>
        public const byte CMD_S_PlayerHoldCard = 105;
        /// <summary>
        /// 当前活动玩家
        /// </summary>
        public const byte CMD_S_ActivePlayer = 106;
        /// <summary>
        /// 投票权限
        /// </summary>
        public const byte CMD_S_VoteRight = 107;
        /// <summary>
        /// 玩家打出牌
        /// </summary>
        public const byte CMD_S_PlayerOutCard = 108;
        /// <summary>
        /// 玩家碰牌
        /// </summary>
        public const byte CMD_S_PlayerPengCard = 109;
        /// <summary>
        /// 玩家吃牌
        /// </summary>
        public const byte CMD_S_PlayerChiCard = 104;
        /// <summary>
        /// 暗杠牌
        /// </summary>
        public const byte CMD_S_PlayerAnGangCard = 110;
        /// <summary>
        /// 明杠牌
        /// </summary>
        public const byte CMD_S_PlayerMingGang = 111;
        /// <summary>
        /// 补杠牌
        /// </summary>
        public const byte CMD_S_PlayerBuGangCard = 112;
        /// <summary>
        /// 玩家胡牌
        /// </summary>
        public const byte CMD_S_PlayerHuCard = 113;
        /// <summary>
        /// 玩家操作权限
        /// </summary>
        public const byte CMD_S_OpPlayer = 114;
        /// <summary>
        /// 开始发送
        /// </summary>
        public const byte CMD_S_StartSendCard = 115;
        /// <summary>
        /// 玩家断线
        /// </summary>
        public const byte CMD_S_PlayerOffline = 116;
        /// <summary>
        /// 断线重连进来
        /// </summary>
        public const byte CMD_S_PlayerOfflineCome = 117;
        ///// <summary>
        ///// 开始定张
        ///// </summary>
        //public const byte CMD_S_StartConfirmColor = 118;
        ///// <summary>
        ///// 换牌结果
        ///// </summary>
        //public const byte CMD_S_ChangeCardResult = 119;
        ///// <summary>
        ///// 玩家定张信息
        ///// </summary>
        //public const byte CMD_S_PlayerConfirmInfo = 120;
        /// <summary>
        /// 抢杠
        /// </summary>
        public const byte CMD_S_QiangGang = 121;
        /// <summary>
        /// 玩家牌阵数据
        /// </summary>
        public const byte CMD_S_PlayerCardData = 122;
        ///// <summary>
        ///// 刮风下雨
        ///// </summary>
        //public const byte CMD_S_WindAndRain = 123;
        /// <summary>
        /// 结算
        /// </summary>
        public const byte CMD_S_Balance = 124;
        /// <summary>
        /// 游戏流水账
        /// </summary>
        public const byte CMD_S_GameFlow = 125;
        /// <summary>
        /// 桌子配置
        /// </summary>
        public const byte CMD_S_TableConfig = 126;
        /// <summary>
        /// 手牌数据
        /// </summary>
        public const byte CMD_S_HandCardData = 127;
        ///// <summary>
        ///// 玩家自己的定缺花色
        ///// </summary>
        //public const byte CMD_S_SelfDingQue = 128;
        /// <summary>
        /// 删除抢杠手牌
        /// </summary>
        public const byte CMD_S_DelQiangGangCard = 129;
        /// <summary>
        /// 强退成功
        /// </summary>
        public const byte CMD_S_ForceLeftSuccess = 130;
        /// <summary>
        /// 创建桌子成功
        /// </summary>
        public const byte CMD_S_CreateTableSuccess = 131;
        /// <summary>
        /// 开始创建桌子
        /// </summary>
        public const byte CMD_S_StartCreateTable = 132;
        /// <summary>
        /// 房主信息
        /// </summary>
        public const byte CMD_S_TableCreatorInfo = 133;
        /// <summary>
        /// 强制玩家离开
        /// </summary>
        public const byte CMD_S_ForceUserLeft = 134;
        /// <summary>
        /// 显示提示消息
        /// </summary>
        public const byte CMD_S_ShowMsg = 135;
        /// <summary>
        /// 好友拒绝帮助
        /// </summary>
        public const byte CMD_S_FriendReject = 136;
        /// <summary>
        /// 好友成功资助
        /// </summary>
        public const byte CMD_S_FriendHelpSuccess = 137;
        /// <summary>
        /// 好友求助信息
        /// </summary>
        public const byte CMD_S_FriendHelpInfo = 138;
        /// <summary>
        /// 好友帮助失败
        /// </summary>
        public const byte CMD_S_FriendHelpFail = 139;
        /// <summary>
        /// 游戏记录结果
        /// </summary>
        public const byte CMD_S_GameRecordResult = 140;
        /// <summary>
        /// 新的游戏回合
        /// </summary>
        public const byte CMD_S_NewGameRound = 141;
        ///// <summary>
        ///// 报警
        ///// </summary>
        //public const byte CMD_S_BaoJing = 142;
        /// <summary>
        /// 投抢杠结果
        /// </summary>
        public const byte CMD_S_VoteQGResult = 143;
        /// <summary>
        /// 玩家余额
        /// </summary>
        public const byte CMD_S_PlayerMoney = 144;
        /// <summary>
        /// 有玩家申请解散房间
        /// </summary>
        public const byte CMD_S_PlayerDissTable = 145;
        /// <summary>
        /// 玩家投票解散房间
        /// </summary>
        public const byte CMD_S_PlayerVoteDissTable = 146;
        /// <summary>
        /// 解散房间成功
        /// </summary>
        public const byte CMD_S_DissTableSuccess = 147;
        ///// <summary>
        ///// 海底捞时间
        ///// </summary>
        //public const byte CMD_S_HaiDiLaoTime = 148;
        /// <summary>
        /// 玩家准备
        /// </summary>
        public const byte CMD_S_UseReady = 149;
        /// <summary>
        /// 保留房间成功
        /// </summary>
        public const byte CMD_S_SaveTableSuccess = 150;
        /// <summary>
        /// 撤回牌池牌
        /// </summary>
        public const byte CMD_S_DelPoolCard = 151;
        /// <summary>
        /// 开始跑
        /// </summary>
        public const byte CMD_S_StartPao = 152;
        /// <summary>
        /// 开始拉
        /// </summary>
        public const byte CMD_S_StartLa = 153;
        /// <summary>
        /// 自己跑
        /// </summary>
        public const byte CMD_S_SelfPao = 154;
        /// <summary>
        /// 自己拉
        /// </summary>
        public const byte CMD_S_SelfLa = 155;
        /// <summary>
        /// 跑信息
        /// </summary>
        public const byte CMD_S_PlayerPaoInfo = 156;
        /// <summary>
        /// 拉信息
        /// </summary>
        public const byte CMD_S_PlayerLaInfo = 157;
        ///<summary>
        ///听牌信息
        /// </summary>
        public const byte CMD_S_Ting = 158;
        /// <summary>
        /// 操作频繁信息
        /// </summary>
        public const byte CMD_S_IsDissolution = 159;
        /// <summary>
        /// 翻开混牌
        /// </summary>
        public const byte CMD_S_FanKaiHun = 162;
        /// <summary>
        /// 豹听
        /// </summary>
        public const byte CMD_S_PlayerBaoTing = 163;
        /// <summary>
        /// 豹听
        /// </summary>
        public const byte CMD_S_PlayerBao = 164;
        #region 断线重连

        /// <summary>
        /// 断线重连游戏信息
        /// </summary>
        public const byte CMD_S_ORC_GameInfo = 200;
        /// <summary>
        /// 断线重连玩家牌阵
        /// </summary>
        public const byte CMD_S_ORC_PlayerCard = 201;
        ///// <summary>
        ///// 断线重连恢复换牌阶段
        ///// </summary>
        //public const byte CMD_S_ORC_ChangeCardPhase = 202;
        ///// <summary>
        ///// 断线重连恢复定缺阶段
        ///// </summary>
        //public const byte CMD_S_ORC_DingQuePhase = 203;
        /// <summary>
        /// 断线重连恢复投票阶段
        /// </summary>
        public const byte CMD_S_ORC_Vote = 204;
        /// <summary>
        /// 断线重连结束
        /// </summary>
        public const byte CMD_S_ORC_Over = 205;
        ///// <summary>
        ///// 胡牌玩家
        ///// </summary>
        //public const byte CMD_S_ORC_HuPlayer = 206;
        /// <summary>
        /// 解散房间
        /// </summary>
        public const byte CMD_S_ORC_DissTable = 207;
        /// <summary>
        /// 解散房间
        /// </summary>
        public const byte CMD_S_ORC_TableFree = 208;
        /// <summary>
        /// 断线重连玩家分数变化
        /// </summary>
        public const byte CMD_S_ORC_GameScoreChange = 209;
        #endregion

        public const byte CMD_S_QuitCreator = 165;

        public const byte CMD_S_AddGameNum = 166;

        public const byte CMD_S_AddGameOutTime = 167;

        public const byte CMD_S_ORC_AddGameNum = 210;
    }
}
