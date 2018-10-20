﻿import { UyiObject } from "../Serializer/UyiObject";
import { SerializerCreator } from "../Serializer/SerializerCreator";
import { TSRH } from "../Serializer/TypeSerializerRegisterHandle";
import {GameIF} from "./GameIF";
import {QL_Common} from "./QL_Common";
export module M_MGMJ_GameMessage {
    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class MGMJMsgID_c2s{
    /**
    * 
    */
   public static readonly CMD_C_HoldCardComplete = 10;
    /**
    * 
    */
   public static readonly CMD_C_Pao = 11;
    /**
    * 
    */
   public static readonly CMD_C_La = 12;
    /**
    * 
    */
   public static readonly CMD_C_OutCard = 14;
    /**
    * 
    */
   public static readonly CMD_C_Gang = 15;
    /**
    * 
    */
   public static readonly CMD_C_Chi = 31;
    /**
    * 
    */
   public static readonly CMD_C_ZiMo = 16;
    /**
    * 
    */
   public static readonly CMD_C_Vote = 17;
    /**
    * 
    */
   public static readonly CMD_C_QiangGang = 18;
    /**
    * 
    */
   public static readonly CMD_C_ForceLeft = 19;
    /**
    * 
    */
   public static readonly CMD_C_CreateTable = 20;
    /**
    * 
    */
   public static readonly CMD_C_FriendHelp = 21;
    /**
    * 
    */
   public static readonly CMD_C_RejectHelp = 22;
    /**
    * 
    */
   public static readonly CMD_C_HelpFriend = 23;
    /**
    * 
    */
   public static readonly CMD_C_QueryGameRecord = 25;
    /**
    * 
    */
   public static readonly CMD_C_OfferDissTable = 26;
    /**
    * 
    */
   public static readonly CMD_C_VoteDissTable = 27;
    /**
    * 
    */
   public static readonly CMD_C_NextGame = 28;
    /**
    * 
    */
   public static readonly CMD_C_ReSetScene = 29;
    /**
    * 
    */
   public static readonly CMD_C_SaveTable = 30;
    /**
    * 
    */
   public static readonly CMD_C_BaoTing = 32;
    /**
    * 
    */
   public static readonly CMD_C_GiveUpBaoTing = 33;

    }


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class MGMJMsgID_s2c{
    /**
    * 
    */
   public static readonly CMD_S_Version = 160;
    /**
    * 
    */
   public static readonly CMD_S_Start = 100;
    /**
    * 
    */
   public static readonly CMD_S_SZInfo = 101;
    /**
    * 
    */
   public static readonly CMD_S_InitCard = 102;
    /**
    * 
    */
   public static readonly CMD_S_GameID = 103;
    /**
    * 
    */
   public static readonly CMD_S_PlayerHoldCard = 105;
    /**
    * 
    */
   public static readonly CMD_S_ActivePlayer = 106;
    /**
    * 
    */
   public static readonly CMD_S_VoteRight = 107;
    /**
    * 
    */
   public static readonly CMD_S_PlayerOutCard = 108;
    /**
    * 
    */
   public static readonly CMD_S_PlayerPengCard = 109;
    /**
    * 
    */
   public static readonly CMD_S_PlayerChiCard = 104;
    /**
    * 
    */
   public static readonly CMD_S_PlayerAnGangCard = 110;
    /**
    * 
    */
   public static readonly CMD_S_PlayerMingGang = 111;
    /**
    * 
    */
   public static readonly CMD_S_PlayerBuGangCard = 112;
    /**
    * 
    */
   public static readonly CMD_S_PlayerHuCard = 113;
    /**
    * 
    */
   public static readonly CMD_S_OpPlayer = 114;
    /**
    * 
    */
   public static readonly CMD_S_StartSendCard = 115;
    /**
    * 
    */
   public static readonly CMD_S_PlayerOffline = 116;
    /**
    * 
    */
   public static readonly CMD_S_PlayerOfflineCome = 117;
    /**
    * 
    */
   public static readonly CMD_S_QiangGang = 121;
    /**
    * 
    */
   public static readonly CMD_S_PlayerCardData = 122;
    /**
    * 
    */
   public static readonly CMD_S_Balance = 124;
    /**
    * 
    */
   public static readonly CMD_S_GameFlow = 125;
    /**
    * 
    */
   public static readonly CMD_S_TableConfig = 126;
    /**
    * 
    */
   public static readonly CMD_S_HandCardData = 127;
    /**
    * 
    */
   public static readonly CMD_S_DelQiangGangCard = 129;
    /**
    * 
    */
   public static readonly CMD_S_ForceLeftSuccess = 130;
    /**
    * 
    */
   public static readonly CMD_S_CreateTableSuccess = 131;
    /**
    * 
    */
   public static readonly CMD_S_StartCreateTable = 132;
    /**
    * 
    */
   public static readonly CMD_S_TableCreatorInfo = 133;
    /**
    * 
    */
   public static readonly CMD_S_ForceUserLeft = 134;
    /**
    * 
    */
   public static readonly CMD_S_ShowMsg = 135;
    /**
    * 
    */
   public static readonly CMD_S_FriendReject = 136;
    /**
    * 
    */
   public static readonly CMD_S_FriendHelpSuccess = 137;
    /**
    * 
    */
   public static readonly CMD_S_FriendHelpInfo = 138;
    /**
    * 
    */
   public static readonly CMD_S_FriendHelpFail = 139;
    /**
    * 
    */
   public static readonly CMD_S_GameRecordResult = 140;
    /**
    * 
    */
   public static readonly CMD_S_NewGameRound = 141;
    /**
    * 
    */
   public static readonly CMD_S_VoteQGResult = 143;
    /**
    * 
    */
   public static readonly CMD_S_PlayerMoney = 144;
    /**
    * 
    */
   public static readonly CMD_S_PlayerDissTable = 145;
    /**
    * 
    */
   public static readonly CMD_S_PlayerVoteDissTable = 146;
    /**
    * 
    */
   public static readonly CMD_S_DissTableSuccess = 147;
    /**
    * 
    */
   public static readonly CMD_S_UseReady = 149;
    /**
    * 
    */
   public static readonly CMD_S_SaveTableSuccess = 150;
    /**
    * 
    */
   public static readonly CMD_S_DelPoolCard = 151;
    /**
    * 
    */
   public static readonly CMD_S_StartPao = 152;
    /**
    * 
    */
   public static readonly CMD_S_StartLa = 153;
    /**
    * 
    */
   public static readonly CMD_S_SelfPao = 154;
    /**
    * 
    */
   public static readonly CMD_S_SelfLa = 155;
    /**
    * 
    */
   public static readonly CMD_S_PlayerPaoInfo = 156;
    /**
    * 
    */
   public static readonly CMD_S_PlayerLaInfo = 157;
    /**
    * 
    */
   public static readonly CMD_S_Ting = 158;
    /**
    * 
    */
   public static readonly CMD_S_IsDissolution = 159;
    /**
    * 
    */
   public static readonly CMD_S_FanKaiHun = 162;
    /**
    * 
    */
   public static readonly CMD_S_PlayerBaoTing = 163;
    /**
    * 
    */
   public static readonly CMD_S_PlayerBao = 164;
    /**
    * 
    */
   public static readonly CMD_S_ORC_GameInfo = 200;
    /**
    * 
    */
   public static readonly CMD_S_ORC_PlayerCard = 201;
    /**
    * 
    */
   public static readonly CMD_S_ORC_Vote = 204;
    /**
    * 
    */
   public static readonly CMD_S_ORC_Over = 205;
    /**
    * 
    */
   public static readonly CMD_S_ORC_DissTable = 207;
    /**
    * 
    */
   public static readonly CMD_S_ORC_TableFree = 208;
    /**
    * 
    */
   public static readonly CMD_S_ORC_GameScoreChange = 209;
    /**
    * 
    */
   public static readonly CMD_S_QuitCreator = 165;

    }


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class RecoveryActiveCard extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.RecoveryActiveCard"; 
        }
       /**
        *
        */
       public selfActive: number[] = null;
       /**
        *
        */
       public selfHoldCard: number = 0;
       /**
        *
        */
       public oppoActiveCount: number = 0;
       /**
        *
        */
       public oppoHoldCard: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.RecoveryActiveCard", function () {return new RecoveryActiveCard()})
    TSRH.RSerializer("M_MGMJ_GameMessage.RecoveryActiveCard", "13|selfActive&1|selfHoldCard&1|oppoActiveCount&1|oppoHoldCard", "M_MGMJ_GameMessage.RecoveryActiveCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class RecoveryPoolCard extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.RecoveryPoolCard"; 
        }
       /**
        *
        */
       public selfPoolCard: number[] = null;
       /**
        *
        */
       public oppoPoolCard: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.RecoveryPoolCard", function () {return new RecoveryPoolCard()})
    TSRH.RSerializer("M_MGMJ_GameMessage.RecoveryPoolCard", "13|selfPoolCard&13|oppoPoolCard", "M_MGMJ_GameMessage.RecoveryPoolCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class SingleFixedCard extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.SingleFixedCard"; 
        }
       /**
        *
        */
       public tokenCard: number = 0;
       /**
        *
        */
       public type: number = 0;
       /**
        *
        */
       public pos: number = 0;
       /**
        *
        */
       public chiType: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.SingleFixedCard", function () {return new SingleFixedCard()})
    TSRH.RSerializer("M_MGMJ_GameMessage.SingleFixedCard", "1|tokenCard&1|type&1|pos&1|chiType", "M_MGMJ_GameMessage.SingleFixedCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class RecoveryFixedCard extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.RecoveryFixedCard"; 
        }
       /**
        *
        */
       public selfFixedCard: SingleFixedCard[] = null;
       /**
        *
        */
       public oppoFixedCard: SingleFixedCard[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.RecoveryFixedCard", function () {return new RecoveryFixedCard()})
    TSRH.RSerializer("M_MGMJ_GameMessage.RecoveryFixedCard", "!M_MGMJ_GameMessage.SingleFixedCard|selfFixedCard&!M_MGMJ_GameMessage.SingleFixedCard|oppoFixedCard", "M_MGMJ_GameMessage.RecoveryFixedCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class PlayerBalance extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.PlayerBalance"; 
        }
       /**
        *
        */
       public HuType: number = 0;
       /**
        *
        */
       public FangPao: number = 0;
       /**
        *
        */
       public TotalScore: number = 0;
       /**
        *
        */
       public JieSuan: number[] = null;
       /**
        *
        */
       public vecType: string = "";
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.PlayerBalance", function () {return new PlayerBalance()})
    TSRH.RSerializer("M_MGMJ_GameMessage.PlayerBalance", "4|HuType&4|FangPao&4|TotalScore&13|JieSuan&12|vecType", "M_MGMJ_GameMessage.PlayerBalance");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class PlayerCard extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.PlayerCard"; 
        }
       /**
        *
        */
       public huCard: number = 0;
       /**
        *
        */
       public handCard: number[] = null;
       /**
        *
        */
       public fixedCard: SingleFixedCard[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.PlayerCard", function () {return new PlayerCard()})
    TSRH.RSerializer("M_MGMJ_GameMessage.PlayerCard", "1|huCard&13|handCard&!M_MGMJ_GameMessage.SingleFixedCard|fixedCard", "M_MGMJ_GameMessage.PlayerCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class GameFlowDetail extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.GameFlowDetail"; 
        }
       /**
        *
        */
       public PlayerChair: number = 0;
       /**
        *
        */
       public FlowType: number = 0;
       /**
        *
        */
       public PlayerScore: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.GameFlowDetail", function () {return new GameFlowDetail()})
    TSRH.RSerializer("M_MGMJ_GameMessage.GameFlowDetail", "1|PlayerChair&1|FlowType&!4|PlayerScore", "M_MGMJ_GameMessage.GameFlowDetail");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class GameRecordResult extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.GameRecordResult"; 
        }
       /**
        *
        */
       public PlayerScore: number[] = null;
       /**
        *
        */
       public ScoreType: number = 0;
       /**
        *
        */
       public Banker: number = 0;
       /**
        *
        */
       public huGangCount: number[][] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.GameRecordResult", function () {return new GameRecordResult()})
    TSRH.RSerializer("M_MGMJ_GameMessage.GameRecordResult", "!4|PlayerScore&1|ScoreType&1|Banker&!13|huGangCount", "M_MGMJ_GameMessage.GameRecordResult");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class ORCFixedCard extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.ORCFixedCard"; 
        }
       /**
        *
        */
       public fixedType: number = 0;
       /**
        *
        */
       public fixedCard: number = 0;
       /**
        *
        */
       public outChair: number = 0;
       /**
        *
        */
       public chiType: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.ORCFixedCard", function () {return new ORCFixedCard()})
    TSRH.RSerializer("M_MGMJ_GameMessage.ORCFixedCard", "1|fixedType&1|fixedCard&1|outChair&1|chiType", "M_MGMJ_GameMessage.ORCFixedCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class ORCOtherPlayerCard extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.ORCOtherPlayerCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public handCardNum: number = 0;
       /**
        *
        */
       public poolCard: number[] = null;
       /**
        *
        */
       public fixedCard: ORCFixedCard[] = null;
       /**
        *
        */
       public IsTing: boolean = false;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.ORCOtherPlayerCard", function () {return new ORCOtherPlayerCard()})
    TSRH.RSerializer("M_MGMJ_GameMessage.ORCOtherPlayerCard", "1|chair&1|handCardNum&13|poolCard&!M_MGMJ_GameMessage.ORCFixedCard|fixedCard&14|IsTing", "M_MGMJ_GameMessage.ORCOtherPlayerCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class ORCSelfCard extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.ORCSelfCard"; 
        }
       /**
        *
        */
       public holdCard: number = 0;
       /**
        *
        */
       public handCard: number[] = null;
       /**
        *
        */
       public poolCard: number[] = null;
       /**
        *
        */
       public fixedCard: ORCFixedCard[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.ORCSelfCard", function () {return new ORCSelfCard()})
    TSRH.RSerializer("M_MGMJ_GameMessage.ORCSelfCard", "1|holdCard&13|handCard&13|poolCard&!M_MGMJ_GameMessage.ORCFixedCard|fixedCard", "M_MGMJ_GameMessage.ORCSelfCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class PaiWalls extends UyiObject {
        public constructor()
        {
            super();
            this.$T="M_MGMJ_GameMessage.PaiWalls"; 
        }
       /**
        *
        */
       public banker: number = 0;
       /**
        *
        */
       public paiCount: number = 0;
       /**
        *
        */
       public houPai: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.PaiWalls", function () {return new PaiWalls()})
    TSRH.RSerializer("M_MGMJ_GameMessage.PaiWalls", "1|banker&1|paiCount&1|houPai", "M_MGMJ_GameMessage.PaiWalls");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_Start extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 100;
            this.$T="M_MGMJ_GameMessage.CMD_S_Start"; 
        }
       /**
        *
        */
       public gameNum: number = 0;
       /**
        *
        */
       public totalGameNum: number = 0;
       /**
        *
        */
       public realGameNum: number = 0;
       /**
        *
        */
       public reMain: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_Start", function () {return new CMD_S_Start()})
    TSRH.RSerializer("26212", "4|gameNum&4|totalGameNum&4|realGameNum&4|reMain", "M_MGMJ_GameMessage.CMD_S_Start");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ActivePlayer extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 106;
            this.$T="M_MGMJ_GameMessage.CMD_S_ActivePlayer"; 
        }
       /**
        *
        */
       public playerChair: number = 0;
       /**
        *
        */
       public timer: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ActivePlayer", function () {return new CMD_S_ActivePlayer()})
    TSRH.RSerializer("26218", "1|playerChair&1|timer", "M_MGMJ_GameMessage.CMD_S_ActivePlayer");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_StartSendCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 115;
            this.$T="M_MGMJ_GameMessage.CMD_S_StartSendCard"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_StartSendCard", function () {return new CMD_S_StartSendCard()})
    TSRH.RSerializer("26227", "", "M_MGMJ_GameMessage.CMD_S_StartSendCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerOffline extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 116;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerOffline"; 
        }
       /**
        *
        */
       public chair: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerOffline", function () {return new CMD_S_PlayerOffline()})
    TSRH.RSerializer("26228", "1|chair", "M_MGMJ_GameMessage.CMD_S_PlayerOffline");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerOfflineCome extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 117;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerOfflineCome"; 
        }
       /**
        *
        */
       public chair: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerOfflineCome", function () {return new CMD_S_PlayerOfflineCome()})
    TSRH.RSerializer("26229", "1|chair", "M_MGMJ_GameMessage.CMD_S_PlayerOfflineCome");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_SZInfo extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 101;
            this.$T="M_MGMJ_GameMessage.CMD_S_SZInfo"; 
        }
       /**
        *
        */
       public sz1: number = 0;
       /**
        *
        */
       public sz2: number = 0;
       /**
        *
        */
       public bankerChair: number = 0;
       /**
        *
        */
       public lianBanker: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_SZInfo", function () {return new CMD_S_SZInfo()})
    TSRH.RSerializer("26213", "1|sz1&1|sz2&1|bankerChair&1|lianBanker", "M_MGMJ_GameMessage.CMD_S_SZInfo");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_GameID extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 103;
            this.$T="M_MGMJ_GameMessage.CMD_S_GameID"; 
        }
       /**
        *
        */
       public gameid: string = "";
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_GameID", function () {return new CMD_S_GameID()})
    TSRH.RSerializer("26215", "12|gameid", "M_MGMJ_GameMessage.CMD_S_GameID");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_InitCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 102;
            this.$T="M_MGMJ_GameMessage.CMD_S_InitCard"; 
        }
       /**
        *
        */
       public cardAry: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_InitCard", function () {return new CMD_S_InitCard()})
    TSRH.RSerializer("26214", "13|cardAry", "M_MGMJ_GameMessage.CMD_S_InitCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_FanKaiHun extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 162;
            this.$T="M_MGMJ_GameMessage.CMD_S_FanKaiHun"; 
        }
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_FanKaiHun", function () {return new CMD_S_FanKaiHun()})
    TSRH.RSerializer("26274", "1|card", "M_MGMJ_GameMessage.CMD_S_FanKaiHun");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerOutCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 108;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerOutCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerOutCard", function () {return new CMD_S_PlayerOutCard()})
    TSRH.RSerializer("26220", "1|chair&1|card", "M_MGMJ_GameMessage.CMD_S_PlayerOutCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerHoldCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 105;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerHoldCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public card: number = 0;
       /**
        *
        */
       public countPai: number = 0;
       /**
        *
        */
       public gangNum: number = 0;
       /**
        *
        */
       public usual: boolean = false;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerHoldCard", function () {return new CMD_S_PlayerHoldCard()})
    TSRH.RSerializer("26217", "1|chair&1|card&1|countPai&1|gangNum&14|usual", "M_MGMJ_GameMessage.CMD_S_PlayerHoldCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerBaoTing extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 163;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerBaoTing"; 
        }
       /**
        *
        */
       public chair: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerBaoTing", function () {return new CMD_S_PlayerBaoTing()})
    TSRH.RSerializer("26275", "1|chair", "M_MGMJ_GameMessage.CMD_S_PlayerBaoTing");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerAnGangCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 110;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerAnGangCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerAnGangCard", function () {return new CMD_S_PlayerAnGangCard()})
    TSRH.RSerializer("26222", "1|chair&1|card", "M_MGMJ_GameMessage.CMD_S_PlayerAnGangCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerBuGangCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 112;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerBuGangCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerBuGangCard", function () {return new CMD_S_PlayerBuGangCard()})
    TSRH.RSerializer("26224", "1|chair&1|card", "M_MGMJ_GameMessage.CMD_S_PlayerBuGangCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerMingGang extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 111;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerMingGang"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public outChair: number = 0;
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerMingGang", function () {return new CMD_S_PlayerMingGang()})
    TSRH.RSerializer("26223", "1|chair&1|outChair&1|card", "M_MGMJ_GameMessage.CMD_S_PlayerMingGang");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_QiangGang extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 121;
            this.$T="M_MGMJ_GameMessage.CMD_S_QiangGang"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_QiangGang", function () {return new CMD_S_QiangGang()})
    TSRH.RSerializer("26233", "1|chair&1|card", "M_MGMJ_GameMessage.CMD_S_QiangGang");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerChiCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 104;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerChiCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public outChair: number = 0;
       /**
        *
        */
       public card: number = 0;
       /**
        *
        */
       public chi_type: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerChiCard", function () {return new CMD_S_PlayerChiCard()})
    TSRH.RSerializer("26216", "1|chair&1|outChair&1|card&1|chi_type", "M_MGMJ_GameMessage.CMD_S_PlayerChiCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerPengCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 109;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerPengCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public outChair: number = 0;
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerPengCard", function () {return new CMD_S_PlayerPengCard()})
    TSRH.RSerializer("26221", "1|chair&1|outChair&1|card", "M_MGMJ_GameMessage.CMD_S_PlayerPengCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerBao extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 164;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerBao"; 
        }
       /**
        *
        */
       public chair: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerBao", function () {return new CMD_S_PlayerBao()})
    TSRH.RSerializer("26276", "1|chair", "M_MGMJ_GameMessage.CMD_S_PlayerBao");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerHuCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 113;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerHuCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public card: number = 0;
       /**
        *
        */
       public huType: number = 0;
       /**
        *
        */
       public huScore: number[] = null;
       /**
        *
        */
       public vecHuType: string = "";
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerHuCard", function () {return new CMD_S_PlayerHuCard()})
    TSRH.RSerializer("26225", "1|chair&1|card&1|huType&!4|huScore&12|vecHuType", "M_MGMJ_GameMessage.CMD_S_PlayerHuCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_OpPlayer extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 114;
            this.$T="M_MGMJ_GameMessage.CMD_S_OpPlayer"; 
        }
       /**
        *
        */
       public ifCanZiMo: number = 0;
       /**
        *
        */
       public gangCard: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_OpPlayer", function () {return new CMD_S_OpPlayer()})
    TSRH.RSerializer("26226", "1|ifCanZiMo&13|gangCard", "M_MGMJ_GameMessage.CMD_S_OpPlayer");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_VoteRight extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 107;
            this.$T="M_MGMJ_GameMessage.CMD_S_VoteRight"; 
        }
       /**
        *
        */
       public voteCard: number = 0;
       /**
        *
        */
       public voteRight: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_VoteRight", function () {return new CMD_S_VoteRight()})
    TSRH.RSerializer("26219", "1|voteCard&1|voteRight", "M_MGMJ_GameMessage.CMD_S_VoteRight");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerCardData extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 122;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerCardData"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public huCard: number = 0;
       /**
        *
        */
       public handCard: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerCardData", function () {return new CMD_S_PlayerCardData()})
    TSRH.RSerializer("26234", "1|chair&1|huCard&13|handCard", "M_MGMJ_GameMessage.CMD_S_PlayerCardData");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_Balance extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 124;
            this.$T="M_MGMJ_GameMessage.CMD_S_Balance"; 
        }
       /**
        *
        */
       public playerCard: PlayerCard[] = null;
       /**
        *
        */
       public playerBalance: PlayerBalance[] = null;
       /**
        *
        */
       public isPlayEnougnGameNum: number = 0;
       /**
        *
        */
       public liuju: boolean = false;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_Balance", function () {return new CMD_S_Balance()})
    TSRH.RSerializer("26236", "!M_MGMJ_GameMessage.PlayerCard|playerCard&!M_MGMJ_GameMessage.PlayerBalance|playerBalance&1|isPlayEnougnGameNum&14|liuju", "M_MGMJ_GameMessage.CMD_S_Balance");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_GameFlow extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 125;
            this.$T="M_MGMJ_GameMessage.CMD_S_GameFlow"; 
        }
       /**
        *
        */
       public gameFlow: GameFlowDetail[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_GameFlow", function () {return new CMD_S_GameFlow()})
    TSRH.RSerializer("26237", "!M_MGMJ_GameMessage.GameFlowDetail|gameFlow", "M_MGMJ_GameMessage.CMD_S_GameFlow");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_TableConfig extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 126;
            this.$T="M_MGMJ_GameMessage.CMD_S_TableConfig"; 
        }


       /**
        *
        */
       public LaPaoZuo: number = 0;
       /**
        *
        */
       public qiduijia: number = 0;
       /**
        *
        */
       public gangkaijia: number = 0;
       /**
        *
        */
       public bukaojia: number = 0;
       /**
        *
        */
       public CellScore: number = 0;
       /**
        *
        */
       public GoldCardBaseIdx: number = 0;
       /**
        *
        */
       public IsRecordScoreRoom: number = 0;
       /**
        *
        */
       public TableCreatorID: number = 0;
       /**
        *
        */
       public TableCreatorChair: number = 0;
       /**
        *
        */
       public TableCode: string = "";
       /**
        *
        */
       public SetGameNum: number = 0;
       /**
        *
        */
       public GameNum: number = 0;
       /**
        *
        */
       public RealGameNum: number = 0;
       /**
        *
        */
       public isOutTimeOp: number = 0;
       /**
        *
        */
       public isSaveTable: number = 0;
       /**
        *
        */
       public saveTableTime: number = 0;
       /**
        *
        */
       public tableCreatorPay: number = 0;
       /**
        *
        */
       public tableCost: number = 0;
       /**
        *
        */
       public isYiPaoDuoXiang: number = 0;
       /**
        *
        */
       public IfCanSameIP: number = 0;
       /**
        *
        */
       public canChi: number = 0;
       /**
        *
        */
       public gangFen: number = 0;
       /**
        *
        */
       public whoLose: number = 0;
       /**
        *
        */
       public zhanZhuang: number = 0;
       /**
        *
        */
       public daiDaPai: number = 0;
       /**
        * 
        */
       public tableWhere:number;
        /**
        *
        */
        public PlayerNum:number=0;
        /**
        *
        */
        public WaitTimeNum:number=0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_TableConfig", function () {return new CMD_S_TableConfig()})
    TSRH.RSerializer("26238", "1|LaPaoZuo&12|TableCode&4|SetGameNum&4|GameNum&4|RealGameNum&1|isOutTimeOp&1|isSaveTable&4|saveTableTime&1|tableCreatorPay&4|tableCost&1|isYiPaoDuoXiang&1|qiduijia&1|IfCanSameIP&1|canChi&1|gangFen&1|whoLose&1|zhanZhuang&1|daiDaPai&4|gangkaijia&4|bukaojia&4|CellScore&4|GoldCardBaseIdx&1|IsRecordScoreRoom&5|TableCreatorID&1|TableCreatorChair", "M_MGMJ_GameMessage.CMD_S_TableConfig");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_HandCardData extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 127;
            this.$T="M_MGMJ_GameMessage.CMD_S_HandCardData"; 
        }
       /**
        *
        */
       public handCardData: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_HandCardData", function () {return new CMD_S_HandCardData()})
    TSRH.RSerializer("26239", "13|handCardData", "M_MGMJ_GameMessage.CMD_S_HandCardData");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_DelQiangGangCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 129;
            this.$T="M_MGMJ_GameMessage.CMD_S_DelQiangGangCard"; 
        }
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_DelQiangGangCard", function () {return new CMD_S_DelQiangGangCard()})
    TSRH.RSerializer("26241", "1|card", "M_MGMJ_GameMessage.CMD_S_DelQiangGangCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ForceLeftSuccess extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 130;
            this.$T="M_MGMJ_GameMessage.CMD_S_ForceLeftSuccess"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ForceLeftSuccess", function () {return new CMD_S_ForceLeftSuccess()})
    TSRH.RSerializer("26242", "", "M_MGMJ_GameMessage.CMD_S_ForceLeftSuccess");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_CreateTableSuccess extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 131;
            this.$T="M_MGMJ_GameMessage.CMD_S_CreateTableSuccess"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_CreateTableSuccess", function () {return new CMD_S_CreateTableSuccess()})
    TSRH.RSerializer("26243", "", "M_MGMJ_GameMessage.CMD_S_CreateTableSuccess");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_StartCreateTable extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 132;
            this.$T="M_MGMJ_GameMessage.CMD_S_StartCreateTable"; 
        }
       /**
        *
        */
       public payKa: number[] = null;
       /**
        *
        */
       public juShu: number[] = null;
       /**
        *
        */
       public defaultJuShu: number = 0;
       /**
        *
        */
       public Version: string = "";
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_StartCreateTable", function () {return new CMD_S_StartCreateTable()})
    TSRH.RSerializer("26244", "13|payKa&13|juShu&1|defaultJuShu&12|Version", "M_MGMJ_GameMessage.CMD_S_StartCreateTable");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_TableCreatorInfo extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 133;
            this.$T="M_MGMJ_GameMessage.CMD_S_TableCreatorInfo"; 
        }
       /**
        *
        */
       public plyaerID: number = 0;
       /**
        *
        */
       public chair: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_TableCreatorInfo", function () {return new CMD_S_TableCreatorInfo()})
    TSRH.RSerializer("26245", "5|plyaerID&1|chair", "M_MGMJ_GameMessage.CMD_S_TableCreatorInfo");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ForceUserLeft extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 134;
            this.$T="M_MGMJ_GameMessage.CMD_S_ForceUserLeft"; 
        }
       /**
        *
        */
       public msg: string = "";
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ForceUserLeft", function () {return new CMD_S_ForceUserLeft()})
    TSRH.RSerializer("26246", "12|msg", "M_MGMJ_GameMessage.CMD_S_ForceUserLeft");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ShowMsg extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 135;
            this.$T="M_MGMJ_GameMessage.CMD_S_ShowMsg"; 
        }
       /**
        *
        */
       public msg: string = "";
       /**
        *
        */
       public tipType: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ShowMsg", function () {return new CMD_S_ShowMsg()})
    TSRH.RSerializer("26247", "12|msg&1|tipType", "M_MGMJ_GameMessage.CMD_S_ShowMsg");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_FriendHelpInfo extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 138;
            this.$T="M_MGMJ_GameMessage.CMD_S_FriendHelpInfo"; 
        }
       /**
        *
        */
       public friendChair: number = 0;
       /**
        *
        */
       public friendID: number = 0;
       /**
        *
        */
       public moneyType: QL_Common.CurrencyType = 0;
       /**
        *
        */
       public moneyNum: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_FriendHelpInfo", function () {return new CMD_S_FriendHelpInfo()})
    TSRH.RSerializer("26250", "1|friendChair&5|friendID&1|moneyType&4|moneyNum", "M_MGMJ_GameMessage.CMD_S_FriendHelpInfo");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_FriendReject extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 136;
            this.$T="M_MGMJ_GameMessage.CMD_S_FriendReject"; 
        }
       /**
        *
        */
       public friendChair: number = 0;
       /**
        *
        */
       public friendID: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_FriendReject", function () {return new CMD_S_FriendReject()})
    TSRH.RSerializer("26248", "1|friendChair&5|friendID", "M_MGMJ_GameMessage.CMD_S_FriendReject");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_FriendHelpSuccess extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 137;
            this.$T="M_MGMJ_GameMessage.CMD_S_FriendHelpSuccess"; 
        }
       /**
        *
        */
       public friendChair: number = 0;
       /**
        *
        */
       public friendID: number = 0;
       /**
        *
        */
       public result: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_FriendHelpSuccess", function () {return new CMD_S_FriendHelpSuccess()})
    TSRH.RSerializer("26249", "1|friendChair&5|friendID&1|result", "M_MGMJ_GameMessage.CMD_S_FriendHelpSuccess");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_GameRecordResult extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 140;
            this.$T="M_MGMJ_GameMessage.CMD_S_GameRecordResult"; 
        }
       /**
        *
        */
       public record: GameRecordResult[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_GameRecordResult", function () {return new CMD_S_GameRecordResult()})
    TSRH.RSerializer("26252", "!M_MGMJ_GameMessage.GameRecordResult|record", "M_MGMJ_GameMessage.CMD_S_GameRecordResult");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_QuitCreator extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 165;
            this.$T="M_MGMJ_GameMessage.CMD_S_QuitCreator"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_QuitCreator", function () {return new CMD_S_QuitCreator()})
    TSRH.RSerializer("26277", "", "M_MGMJ_GameMessage.CMD_S_QuitCreator");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_NewGameRound extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 141;
            this.$T="M_MGMJ_GameMessage.CMD_S_NewGameRound"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_NewGameRound", function () {return new CMD_S_NewGameRound()})
    TSRH.RSerializer("26253", "", "M_MGMJ_GameMessage.CMD_S_NewGameRound");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_VoteQGResult extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 143;
            this.$T="M_MGMJ_GameMessage.CMD_S_VoteQGResult"; 
        }
       /**
        *
        */
       public voteqg: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_VoteQGResult", function () {return new CMD_S_VoteQGResult()})
    TSRH.RSerializer("26255", "1|voteqg", "M_MGMJ_GameMessage.CMD_S_VoteQGResult");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerMoney extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 144;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerMoney"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public userID: number = 0;
       /**
        *
        */
       public gold: number = 0;
       /**
        *
        */
       public goldCard: number = 0;
       /**
        *
        */
       public diamond: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerMoney", function () {return new CMD_S_PlayerMoney()})
    TSRH.RSerializer("26256", "1|chair&5|userID&4|gold&4|goldCard&4|diamond", "M_MGMJ_GameMessage.CMD_S_PlayerMoney");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerDissTable extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 145;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerDissTable"; 
        }
       /**
        *
        */
       public sponsorChair: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerDissTable", function () {return new CMD_S_PlayerDissTable()})
    TSRH.RSerializer("26257", "1|sponsorChair", "M_MGMJ_GameMessage.CMD_S_PlayerDissTable");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerVoteDissTable extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 146;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerVoteDissTable"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public vote: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerVoteDissTable", function () {return new CMD_S_PlayerVoteDissTable()})
    TSRH.RSerializer("26258", "1|chair&1|vote", "M_MGMJ_GameMessage.CMD_S_PlayerVoteDissTable");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_DissTableSuccess extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 147;
            this.$T="M_MGMJ_GameMessage.CMD_S_DissTableSuccess"; 
        }
       /**
        *
        */
       public gameing: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_DissTableSuccess", function () {return new CMD_S_DissTableSuccess()})
    TSRH.RSerializer("26259", "1|gameing", "M_MGMJ_GameMessage.CMD_S_DissTableSuccess");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_UseReady extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 149;
            this.$T="M_MGMJ_GameMessage.CMD_S_UseReady"; 
        }
       /**
        *
        */
       public chair: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_UseReady", function () {return new CMD_S_UseReady()})
    TSRH.RSerializer("26261", "1|chair", "M_MGMJ_GameMessage.CMD_S_UseReady");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_SaveTableSuccess extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 150;
            this.$T="M_MGMJ_GameMessage.CMD_S_SaveTableSuccess"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_SaveTableSuccess", function () {return new CMD_S_SaveTableSuccess()})
    TSRH.RSerializer("26262", "", "M_MGMJ_GameMessage.CMD_S_SaveTableSuccess");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_DelPoolCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 151;
            this.$T="M_MGMJ_GameMessage.CMD_S_DelPoolCard"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public card: number = 0;
       /**
        *
        */
       public cardnum: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_DelPoolCard", function () {return new CMD_S_DelPoolCard()})
    TSRH.RSerializer("26263", "1|chair&1|card&1|cardnum", "M_MGMJ_GameMessage.CMD_S_DelPoolCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_StartPao extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 152;
            this.$T="M_MGMJ_GameMessage.CMD_S_StartPao"; 
        }
       /**
        *
        */
       public pao: boolean = false;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_StartPao", function () {return new CMD_S_StartPao()})
    TSRH.RSerializer("26264", "14|pao", "M_MGMJ_GameMessage.CMD_S_StartPao");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_StartLa extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 153;
            this.$T="M_MGMJ_GameMessage.CMD_S_StartLa"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_StartLa", function () {return new CMD_S_StartLa()})
    TSRH.RSerializer("26265", "", "M_MGMJ_GameMessage.CMD_S_StartLa");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_SelfPao extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 154;
            this.$T="M_MGMJ_GameMessage.CMD_S_SelfPao"; 
        }
       /**
        *
        */
       public point: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_SelfPao", function () {return new CMD_S_SelfPao()})
    TSRH.RSerializer("26266", "1|point", "M_MGMJ_GameMessage.CMD_S_SelfPao");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_SelfLa extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 155;
            this.$T="M_MGMJ_GameMessage.CMD_S_SelfLa"; 
        }
       /**
        *
        */
       public point: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_SelfLa", function () {return new CMD_S_SelfLa()})
    TSRH.RSerializer("26267", "1|point", "M_MGMJ_GameMessage.CMD_S_SelfLa");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerPaoInfo extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 156;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerPaoInfo"; 
        }
       /**
        *
        */
       public points: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerPaoInfo", function () {return new CMD_S_PlayerPaoInfo()})
    TSRH.RSerializer("26268", "13|points", "M_MGMJ_GameMessage.CMD_S_PlayerPaoInfo");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_PlayerLaInfo extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 157;
            this.$T="M_MGMJ_GameMessage.CMD_S_PlayerLaInfo"; 
        }
       /**
        *
        */
       public points: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_PlayerLaInfo", function () {return new CMD_S_PlayerLaInfo()})
    TSRH.RSerializer("26269", "13|points", "M_MGMJ_GameMessage.CMD_S_PlayerLaInfo");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ORC_GameInfo extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 200;
            this.$T="M_MGMJ_GameMessage.CMD_S_ORC_GameInfo"; 
        }
       /**
        *
        */
       public bankerChair: number = 0;
       /**
        *
        */
       public lianBanker: number = 0;
       /**
        *
        */
       public gameid: string = "";
       /**
        *
        */
       public gamePhase: number = 0;
       /**
        *
        */
       public selfIsAlreadyHu: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ORC_GameInfo", function () {return new CMD_S_ORC_GameInfo()})
    TSRH.RSerializer("26312", "1|bankerChair&1|lianBanker&12|gameid&1|gamePhase&1|selfIsAlreadyHu", "M_MGMJ_GameMessage.CMD_S_ORC_GameInfo");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ORC_PlayerCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 201;
            this.$T="M_MGMJ_GameMessage.CMD_S_ORC_PlayerCard"; 
        }
       /**
        *
        */
       public selfCard: ORCSelfCard = null;
       /**
        *
        */
       public otherPlayerCard: ORCOtherPlayerCard[] = null;
       /**
        *
        */
       public paiWall: PaiWalls = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ORC_PlayerCard", function () {return new CMD_S_ORC_PlayerCard()})
    TSRH.RSerializer("26313", "M_MGMJ_GameMessage.ORCSelfCard|selfCard&!M_MGMJ_GameMessage.ORCOtherPlayerCard|otherPlayerCard&M_MGMJ_GameMessage.PaiWalls|paiWall", "M_MGMJ_GameMessage.CMD_S_ORC_PlayerCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ORC_Vote extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 204;
            this.$T="M_MGMJ_GameMessage.CMD_S_ORC_Vote"; 
        }
       /**
        *
        */
       public chair: number = 0;
       /**
        *
        */
       public card: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ORC_Vote", function () {return new CMD_S_ORC_Vote()})
    TSRH.RSerializer("26316", "1|chair&1|card", "M_MGMJ_GameMessage.CMD_S_ORC_Vote");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ORC_Over extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 205;
            this.$T="M_MGMJ_GameMessage.CMD_S_ORC_Over"; 
        }
       /**
        *
        */
       public leftCardNum: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ORC_Over", function () {return new CMD_S_ORC_Over()})
    TSRH.RSerializer("26317", "1|leftCardNum", "M_MGMJ_GameMessage.CMD_S_ORC_Over");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ORC_DissTable extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 207;
            this.$T="M_MGMJ_GameMessage.CMD_S_ORC_DissTable"; 
        }
       /**
        *
        */
       public sponsor: number = 0;
       /**
        *
        */
       public playerVote: number[] = null;
       /**
        *
        */
       public leftTime: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ORC_DissTable", function () {return new CMD_S_ORC_DissTable()})
    TSRH.RSerializer("26319", "1|sponsor&13|playerVote&1|leftTime", "M_MGMJ_GameMessage.CMD_S_ORC_DissTable");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ORC_TableFree extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 208;
            this.$T="M_MGMJ_GameMessage.CMD_S_ORC_TableFree"; 
        }
       /**
        *
        */
       public lianbank: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ORC_TableFree", function () {return new CMD_S_ORC_TableFree()})
    TSRH.RSerializer("26320", "1|lianbank", "M_MGMJ_GameMessage.CMD_S_ORC_TableFree");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_ORC_GameScoreChange extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 209;
            this.$T="M_MGMJ_GameMessage.CMD_S_ORC_GameScoreChange"; 
        }
       /**
        *
        */
       public PlayerScoreChange: number[] = null;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_ORC_GameScoreChange", function () {return new CMD_S_ORC_GameScoreChange()})
    TSRH.RSerializer("26321", "!4|PlayerScoreChange", "M_MGMJ_GameMessage.CMD_S_ORC_GameScoreChange");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_HoldCardComplete extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 10;
            this.$T="M_MGMJ_GameMessage.CMD_C_HoldCardComplete"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_HoldCardComplete", function () {return new CMD_C_HoldCardComplete()})
    TSRH.RSerializer("26122", "", "M_MGMJ_GameMessage.CMD_C_HoldCardComplete");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_ZiMo extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 16;
            this.$T="M_MGMJ_GameMessage.CMD_C_ZiMo"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_ZiMo", function () {return new CMD_C_ZiMo()})
    TSRH.RSerializer("26128", "", "M_MGMJ_GameMessage.CMD_C_ZiMo");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_Gang extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 15;
            this.$T="M_MGMJ_GameMessage.CMD_C_Gang"; 
        }
       /**
        *
        */
       public gangCard: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_Gang", function () {return new CMD_C_Gang()})
    TSRH.RSerializer("26127", "1|gangCard", "M_MGMJ_GameMessage.CMD_C_Gang");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_Chi extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 31;
            this.$T="M_MGMJ_GameMessage.CMD_C_Chi"; 
        }
       /**
        *
        */
       public chiCard: number = 0;
       /**
        *
        */
       public chiType: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_Chi", function () {return new CMD_C_Chi()})
    TSRH.RSerializer("26143", "1|chiCard&1|chiType", "M_MGMJ_GameMessage.CMD_C_Chi");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_OutCard extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 14;
            this.$T="M_MGMJ_GameMessage.CMD_C_OutCard"; 
        }
       /**
        *
        */
       public outCard: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_OutCard", function () {return new CMD_C_OutCard()})
    TSRH.RSerializer("26126", "1|outCard", "M_MGMJ_GameMessage.CMD_C_OutCard");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_Vote extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 17;
            this.$T="M_MGMJ_GameMessage.CMD_C_Vote"; 
        }
       /**
        *
        */
       public voteResult: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_Vote", function () {return new CMD_C_Vote()})
    TSRH.RSerializer("26129", "1|voteResult", "M_MGMJ_GameMessage.CMD_C_Vote");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_QiangGang extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 18;
            this.$T="M_MGMJ_GameMessage.CMD_C_QiangGang"; 
        }
       /**
        *
        */
       public qiangGang: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_QiangGang", function () {return new CMD_C_QiangGang()})
    TSRH.RSerializer("26130", "1|qiangGang", "M_MGMJ_GameMessage.CMD_C_QiangGang");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_ForceLeft extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 19;
            this.$T="M_MGMJ_GameMessage.CMD_C_ForceLeft"; 
        }
       /**
        *
        */
       public PlayerID: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_ForceLeft", function () {return new CMD_C_ForceLeft()})
    TSRH.RSerializer("26131", "5|PlayerID", "M_MGMJ_GameMessage.CMD_C_ForceLeft");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_CreateTable extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 20;
            this.$T="M_MGMJ_GameMessage.CMD_C_CreateTable"; 
        }

        /**
        *
        */
       public PlayerNum: number = 0;
       /**
        *
        */
       public WaitTimeNum: number = 0;
       /**
        *
        */
       public LaPaoZuo: number = 0;
       /**
        *
        */
       public QiDuiJia: number = 0;
       /**
        *
        */
       public daiDaPai: number = 0;
       /**
        *
        */
       public GangKaiJia: number = 0;
       /**
        *
        */
       public BuKaoJia: number = 0;
       /**
        *
        */
       public TableCost: number = 0;
       /**
        *
        */
       public IsRecordScoreRoom: number = 0;
       /**
        *
        */
       public TableCode: string = "";
       /**
        *
        */
       public SetGameNum: number = 0;
       /**
        *
        */
       public GoldRoomBaseIdx: number = 0;
       /**
        *
        */
       public isOutTimeOp: number = 0;
       /**
        *
        */
       public isTableCreatorPay: number = 0;
       /**
        *
        */
       public isYiPaoDuoXiang: number = 0;
       /**
        *
        */
       public IfCanSameIp: number = 0;
       /**
        *
        */
       public whoLose: number = 0;
       /**
        *
        */
       public zhanZhuang: number = 0;
       /**
        *
        */
       public gangFen: number = 0;
       /**
        *
        */
       public canChi: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_CreateTable", function () {return new CMD_C_CreateTable()})
    TSRH.RSerializer("26132", "1|LaPaoZuo&4|GoldRoomBaseIdx&1|isOutTimeOp&1|isTableCreatorPay&1|isYiPaoDuoXiang&1|IfCanSameIp&1|whoLose&1|zhanZhuang&1|gangFen&1|canChi&1|QiDuiJia&1|daiDaPai&4|GangKaiJia&4|BuKaoJia&4|TableCost&1|IsRecordScoreRoom&12|TableCode&4|SetGameNum", "M_MGMJ_GameMessage.CMD_C_CreateTable");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_IsDissolution extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 159;
            this.$T="M_MGMJ_GameMessage.CMD_S_IsDissolution"; 
        }
       /**
        *
        */
       public IsDissolution: boolean = false;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_IsDissolution", function () {return new CMD_S_IsDissolution()})
    TSRH.RSerializer("26271", "14|IsDissolution", "M_MGMJ_GameMessage.CMD_S_IsDissolution");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_FriendHelp extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 21;
            this.$T="M_MGMJ_GameMessage.CMD_C_FriendHelp"; 
        }
       /**
        *
        */
       public friendChair: number = 0;
       /**
        *
        */
       public friendID: number = 0;
       /**
        *
        */
       public moneyType: QL_Common.CurrencyType = 0;
       /**
        *
        */
       public moneyNum: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_FriendHelp", function () {return new CMD_C_FriendHelp()})
    TSRH.RSerializer("26133", "1|friendChair&5|friendID&1|moneyType&4|moneyNum", "M_MGMJ_GameMessage.CMD_C_FriendHelp");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_RejectHelp extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 22;
            this.$T="M_MGMJ_GameMessage.CMD_C_RejectHelp"; 
        }
       /**
        *
        */
       public friendChair: number = 0;
       /**
        *
        */
       public friendID: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_RejectHelp", function () {return new CMD_C_RejectHelp()})
    TSRH.RSerializer("26134", "1|friendChair&5|friendID", "M_MGMJ_GameMessage.CMD_C_RejectHelp");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_HelpFriend extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 23;
            this.$T="M_MGMJ_GameMessage.CMD_C_HelpFriend"; 
        }
       /**
        *
        */
       public friendChair: number = 0;
       /**
        *
        */
       public friendID: number = 0;
       /**
        *
        */
       public moneyType: QL_Common.CurrencyType = 0;
       /**
        *
        */
       public moneyNum: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_HelpFriend", function () {return new CMD_C_HelpFriend()})
    TSRH.RSerializer("26135", "1|friendChair&5|friendID&1|moneyType&4|moneyNum", "M_MGMJ_GameMessage.CMD_C_HelpFriend");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_QueryGameRecord extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 25;
            this.$T="M_MGMJ_GameMessage.CMD_C_QueryGameRecord"; 
        }
       /**
        *
        */
       public queryNum: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_QueryGameRecord", function () {return new CMD_C_QueryGameRecord()})
    TSRH.RSerializer("26137", "1|queryNum", "M_MGMJ_GameMessage.CMD_C_QueryGameRecord");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_OfferDissTable extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 26;
            this.$T="M_MGMJ_GameMessage.CMD_C_OfferDissTable"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_OfferDissTable", function () {return new CMD_C_OfferDissTable()})
    TSRH.RSerializer("26138", "", "M_MGMJ_GameMessage.CMD_C_OfferDissTable");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_VoteDissTable extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 27;
            this.$T="M_MGMJ_GameMessage.CMD_C_VoteDissTable"; 
        }
       /**
        *
        */
       public voteResult: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_VoteDissTable", function () {return new CMD_C_VoteDissTable()})
    TSRH.RSerializer("26139", "1|voteResult", "M_MGMJ_GameMessage.CMD_C_VoteDissTable");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_NextGame extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 28;
            this.$T="M_MGMJ_GameMessage.CMD_C_NextGame"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_NextGame", function () {return new CMD_C_NextGame()})
    TSRH.RSerializer("26140", "", "M_MGMJ_GameMessage.CMD_C_NextGame");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_ReSetScene extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 29;
            this.$T="M_MGMJ_GameMessage.CMD_C_ReSetScene"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_ReSetScene", function () {return new CMD_C_ReSetScene()})
    TSRH.RSerializer("26141", "", "M_MGMJ_GameMessage.CMD_C_ReSetScene");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_SaveTable extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 30;
            this.$T="M_MGMJ_GameMessage.CMD_C_SaveTable"; 
        }
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_SaveTable", function () {return new CMD_C_SaveTable()})
    TSRH.RSerializer("26142", "", "M_MGMJ_GameMessage.CMD_C_SaveTable");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_Pao extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 11;
            this.$T="M_MGMJ_GameMessage.CMD_C_Pao"; 
        }
       /**
        *
        */
       public point: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_Pao", function () {return new CMD_C_Pao()})
    TSRH.RSerializer("26123", "1|point", "M_MGMJ_GameMessage.CMD_C_Pao");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_La extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 12;
            this.$T="M_MGMJ_GameMessage.CMD_C_La"; 
        }
       /**
        *
        */
       public point: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_La", function () {return new CMD_C_La()})
    TSRH.RSerializer("26124", "1|point", "M_MGMJ_GameMessage.CMD_C_La");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_BaoTing extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 32;
            this.$T="M_MGMJ_GameMessage.CMD_C_BaoTing"; 
        }
       /**
        *
        */
       public point: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_BaoTing", function () {return new CMD_C_BaoTing()})
    TSRH.RSerializer("26144", "1|point", "M_MGMJ_GameMessage.CMD_C_BaoTing");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_C_GiveUpBaoTing extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 33;
            this.$T="M_MGMJ_GameMessage.CMD_C_GiveUpBaoTing"; 
        }
       /**
        *
        */
       public point: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_C_GiveUpBaoTing", function () {return new CMD_C_GiveUpBaoTing()})
    TSRH.RSerializer("26145", "1|point", "M_MGMJ_GameMessage.CMD_C_GiveUpBaoTing");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_Ting extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 158;
            this.$T="M_MGMJ_GameMessage.CMD_S_Ting"; 
        }
       /**
        *
        */
       public TingNum: number = 0;
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_Ting", function () {return new CMD_S_Ting()})
    TSRH.RSerializer("26270", "3|TingNum", "M_MGMJ_GameMessage.CMD_S_Ting");


    /**
     *
     * @创建时间：2018年10月20日 10:26:01
     * @创建人员：PC-20180301CFOZ\Administrator
     * @备注信息：
     *
     */
    export class CMD_S_Version extends GameIF.GameMessage {
        public constructor()
        {
            super();
            
            this.wMainCmdID = 102;
            this.wSubCmdID = 160;
            this.$T="M_MGMJ_GameMessage.CMD_S_Version"; 
        }
       /**
        *
        */
       public Version: string = "";
   
    }
    SerializerCreator.Register("M_MGMJ_GameMessage.CMD_S_Version", function () {return new CMD_S_Version()})
    TSRH.RSerializer("26272", "12|Version", "M_MGMJ_GameMessage.CMD_S_Version");

}