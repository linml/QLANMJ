import { NiuNiu } from "../GameHelp/INiuNiuClass";
import { M_NiuNiu_GameMessage } from "../../../CommonSrc/M_NiuNiu_GameMessage";
import GameLogic from "../GameHelp/GameLogic";
import { GameModel, ExtendBetType, RubCardType } from "../GameHelp/GameHelp";
import VoicePlayer from "../GameHelp/VoicePlayer";
import { QL_Common } from "../../../CommonSrc/QL_Common";

const { ccclass, property } = cc._decorator;

@ccclass
export default class SkinButtonView extends cc.Component {

    //菜单按钮
    @property(cc.Button)
    private btn_menu: cc.Button = null;
    @property(cc.Node)
    private group_menu: cc.Node = null;
    @property(cc.Button)
    private btn_exit: cc.Button = null;
    @property(cc.Button)
    private btn_share: cc.Button = null;
    @property(cc.Button)
    private btn_audio: cc.Button = null;

    @property(cc.Button)
    private btn_dissolvetable: cc.Button = null;
    //准备
    @property(cc.Button)
    private btn_ready: cc.Button = null;
    @property(cc.Button)
    private btn_invitation: cc.Button = null;
    @property(cc.Button)
    private btn_totalscore: cc.Button = null;
    //附加功能
    @property(cc.Button)
    private btn_chat: cc.Button = null;
    @property(cc.Button)
    public btn_voice: cc.Button = null;
    @property(cc.Button)
    public btn_queryscore: cc.Button = null;
    //抢庄
    @property(cc.Node)
    private group_rob: cc.Node = null;
    @property([cc.Button])
    private btn_rob: cc.Button[] = [];
    //下注
    @property(cc.Node)
    private group_bet: cc.Node = null;
    @property([cc.Button])
    private btn_bet: cc.Button[] = [];
    //选牌
    @property(cc.Node)
    private group_selectcard: cc.Node = null;
    @property(cc.Button)
    private btn_hasniu: cc.Button = null;
    @property(cc.Button)
    private btn_noniu: cc.Button = null;
    @property(cc.Button)
    private btn_selecthelp: cc.Button = null;
    @property(cc.RichText)
    private label_selecthelp: cc.RichText = null;
    @property(cc.Button)
    private btn_rubcard: cc.Button = null;

    // @property(cc.Label)
    // private label_rule: cc.Label = null;

    //变量
    private RobRate = new Array(0, 1, 2, 3);
    private BetRate1 = new Array(1, 2,3);
    private BetRate2 = new Array(5, 10, 15, 20, 25);
    private BetRate3 = new Array(1, 2, 3, 4, 5);
    private BetRate: number[];
    private extendBet: number = 0;

    onLoad() {
        this.Init();
        this.btn_menu.node.on("click", this.OnButtonMenu, this);
        this.btn_exit.node.on("click", this.OnButtonExit, this);
        this.btn_share.node.on("click", this.OnButtonShare, this);
        this.btn_audio.node.on("click", this.OnButtonAudio, this);
        this.btn_dissolvetable.node.on("click", this.OnButtonDissolveTable, this);
        this.btn_ready.node.on("click", this.OnButtonReady, this);
        this.btn_invitation.node.on("click", this.OnButtonInvitation, this);
        this.btn_totalscore.node.on("click", this.OnButtonTotalScore, this);
        this.btn_chat.node.on("click", this.OnButtonChat, this);
        this.btn_voice.node.on(cc.Node.EventType.TOUCH_START, this.OnButtonVoice, this);
        this.btn_voice.node.on(cc.Node.EventType.TOUCH_END, this.OnVoiceStop, this);
        this.btn_voice.node.on(cc.Node.EventType.TOUCH_CANCEL, this.OnVoiceStop, this);
        this.btn_queryscore.node.on("click", this.OnButtonQueryScore, this);
        for (let i = 0; i < this.btn_rob.length; i++) {
            this.btn_rob[i].node.on("click", () => { this.OnButtonRob(i) }, this);
        }
        for (let i = 0; i < this.btn_bet.length; i++) {
            this.btn_bet[i].node.on("click", () => { this.OnButtonBet(i) }, this);
        }
        this.btn_hasniu.node.on("click", () => { this.OnButtonSelectCard(true) }, this);
        this.btn_noniu.node.on("click", () => { this.OnButtonSelectCard(false) }, this);
        this.btn_rubcard.node.on("click", this.OnButtonRubCard, this);
        this.btn_selecthelp.node.on("click", this.OnButtonSelectHelp, this);
        cc.game.on(cc.game.EVENT_HIDE, this.OnVoiceStop, this);
    }
    public onDestroy() {
        //销毁监听事件
        cc.game.off(cc.game.EVENT_HIDE, this.OnVoiceStop, this);
    }
    public Init() {
        //初始化一些设置，如按钮隐藏之类
        this.BetRate = this.BetRate1;
        this.node.active = true;
        this.btn_menu.node.active = true;
        this.group_menu.active = false;
        this.btn_exit.node.active = true;
        this.btn_share.node.active = true;
        this.btn_audio.node.active = true;
        this.btn_dissolvetable.node.active = false;
        this.btn_exit.interactable = true;
        this.btn_dissolvetable.interactable = false;
        this.btn_chat.node.active = true;
        this.btn_voice.node.active = false;
        this.btn_queryscore.node.active = false;
        this.btn_ready.node.active = false;
        this.btn_invitation.node.active = false;
        this.btn_totalscore.node.active = false;
        this.HideRob();
        this.HideBet();
        this.HideSelectCard();
    }
    /**
     * 设置游戏模式
     * 随机庄家和抢庄模式的下注按钮是不同的
     */
    public SetGameModel(value: GameModel) {
        if (value == GameModel.RandomMaster) {
           // if (NiuNiu.ins.iclass.IsCreateTable())
                this.BetRate = this.BetRate1;
            // else
            //     this.BetRate = this.BetRate1;
        }
        else if (value == GameModel.RobMaster) {
            this.BetRate = this.BetRate1;
        }
        else {
            this.BetRate = this.BetRate1;
        }
    }
    /**
     * 设置闲家下注倍数
     */
    public SetForBetRate(value: number[]) {
        this.BetRate = value;
    }
    /**
     * 隐藏菜单
     */
    public HideMenu() {
        this.group_menu.active = false;
        this.btn_menu.node.active = true;
    }
    /**
     * 显示准备相关按钮
     */
    public ShowReady() {
        var state = NiuNiu.ins.iclass.GetSelfState();
        if (NiuNiu.ins.iclass.IsCreateTable()) {
            if (state == QL_Common.GState.Free || state == QL_Common.GState.SitDown) {
                this.btn_ready.node.active = true;
                this.btn_invitation.node.active = true;
                this.btn_invitation.node.x = 120;
                this.btn_ready.node.x = -120;
            }
            else if (state == QL_Common.GState.PlayerReady) {
                this.btn_invitation.node.active = true;
                this.btn_invitation.node.x = 0;
                this.btn_ready.node.active = false;
            }
            else {
                this.btn_ready.node.active = true;
                this.btn_ready.node.x = 0;
                this.btn_ready.node.y = -320;
                this.btn_invitation.node.active = false;
            }
        }
        else {
            if (state == QL_Common.GState.Free || state == QL_Common.GState.SitDown) {
                this.btn_ready.node.active = true;
                this.btn_ready.node.x = 0;
                this.btn_ready.node.y = -320;
                this.btn_invitation.node.active = false;
            }
        }
    }
    /**
     * 显示总战绩按钮
     */
    public ShowTotalScore() {
        this.btn_totalscore.node.active = true;
        this.btn_ready.node.active = false;
        this.btn_invitation.node.active = false;
    }
    /**
     * 隐藏准备
     */
    public HideReady() {
        if (NiuNiu.ins.iclass.IsCreateTable() && NiuNiu.ins.iclass.GetSelfState() != QL_Common.GState.Gaming) {
            this.btn_invitation.node.active = true;
            this.btn_invitation.node.x = 0;
            this.btn_ready.node.active = false;
        }
        else {
            this.btn_ready.node.active = false;
            this.btn_invitation.node.active = false;
        }
    }
    /**
     * 隐藏踢人
     */
    public HideTiRen() {

    }
    /**
     * 显示抢庄
     */
    public ShowRob() {
        this.group_rob.active = true;
    }
    /**
     * 隐藏抢庄
     */
    public HideRob() {
        this.group_rob.active = false;
    }
    /**
     * 显示下注
     */
    public ShowBet(_extendBet: number = 0) {
        this.group_bet.active = true;
        this.extendBet = _extendBet;
        let betCount = _extendBet > 0 ? this.BetRate.length + 1 : this.BetRate.length;
        var start = -(betCount - 1) * 70;
        for (var i = 0; i < this.btn_bet.length; i++) {
            if (i < betCount) {
                this.btn_bet[i].node.active = true;
                this.btn_bet[i].node.x = start + i * 140;
                if (i == this.BetRate.length)
                    this.btn_bet[i].node.getChildByName("label").getComponent<cc.Label>(cc.Label).string = _extendBet + "倍";
                else
                    this.btn_bet[i].node.getChildByName("label").getComponent<cc.Label>(cc.Label).string = this.BetRate[i] + "倍";
            }
            else {
                this.btn_bet[i].node.active = false;
            }
        }
    }
    /**
     * 隐藏下注
     */
    public HideBet() {
        this.group_bet.active = false;
    }
    /**
     * 显示选牌
     */
    public ShowSelectCard(showRubCard: boolean = false) {
        this.group_selectcard.active = true;
        this.ShowSelectCardHelp();
        this.btn_rubcard.node.active = showRubCard;
    }
    /**
     * 隐藏搓牌按钮
     */
    public HideRubCardBtn() {
        this.btn_rubcard.node.active = false;
    }
    /**
     * 显示算牌帮助
     */
    public ShowSelectCardHelp() {
        this.label_selecthelp.string = "算不出来，点我帮你算牌！";
    }
    /**
     * 显示选牌牌型
     */
    public ShowSelectCardType(value: number) {
        var str = "您当前的牌型是：<color=#ff0000>" + GameLogic.GetCardTypeText(value) + "</color>"
        this.label_selecthelp.string = str;
    }
    /**
     * 隐藏选牌
     */
    public HideSelectCard() {
        this.group_selectcard.active = false;
    }
    /**
     * 设置多局游戏按钮
     * 若是多局游戏，则退出按钮不可点，取而代之的是解散房间按钮
     */
    public SetMulGameButton(value: boolean) {
        if (value && !this.IsButtonDisable()) {
            this.btn_exit.interactable = false;
            this.btn_dissolvetable.interactable = true;
             this.btn_exit.node.active = false
            this.btn_dissolvetable.node.active = true;
        }
        else {
            this.btn_exit.interactable = true;
            this.btn_dissolvetable.interactable = false;
             this.btn_dissolvetable.node.active = false;
            this.btn_exit.node.active = true;
        }
    }
    /**
     * 设置踢人按钮
     */
    public SetTirenButton(value: boolean) {

    }
    /**
     * 设置游戏规则
     */
    public SetGameRule(isCreateRoom: boolean, cell: number, tableCostType: string, gameCount: number, tableCostNum: number, tableCostName: string,
         gameModel: string, checkIP: boolean, startMasterModel: string, cardTypeModel: string, _extendBet: ExtendBetType, _rubCard: RubCardType) {
        // if (isCreateRoom) {
        //     this.label_rule.string = `底分：${cell}\n`;
        //     this.label_rule.string += `扣费模式：${tableCostType}\n`;
        //     this.label_rule.string += `局数：${gameCount}\n`;
        //     this.label_rule.string += tableCostNum > 0 ? `桌费：${tableCostNum}${tableCostName}` : ``;
        //     this.label_rule.string += `\n开局庄家：${startMasterModel}`;
        //     this.label_rule.string += `\n换庄模式：${gameModel}`;
        //     if (cardTypeModel.length > 0)
        //         this.label_rule.string += `\n特殊牌型：(${cardTypeModel})`;
        //     else
        //         this.label_rule.string += `\n特殊牌型：无`;
        //     if (_extendBet > ExtendBetType.NotShow)
        //         this.label_rule.string += _extendBet == ExtendBetType.Enable ? "\n允许闲家推注" : "\n不允许闲家推注";
        //     if (_rubCard > RubCardType.NotShow)
        //         this.label_rule.string += _rubCard == RubCardType.Enable ? "\n允许搓牌" : "\n不允许搓牌";
        //     this.label_rule.string += checkIP ? "\n同IP不许同桌" : "\n同IP允许同桌";
        // }
        // else {
        //     this.label_rule.string = `底分：${cell}\n`;
        //     this.label_rule.string += tableCostNum > 0 ? `桌费：${tableCostNum}${tableCostName}` : ``;
        //     this.label_rule.string += `\n开局庄家：${startMasterModel}`;
        //     this.label_rule.string += `\n换庄模式：${gameModel}`;
        //     if (_extendBet > ExtendBetType.NotShow)
        //         this.label_rule.string += _extendBet == ExtendBetType.Enable ? "\n允许闲家推注" : "\n不允许闲家推注";
        //     if (_rubCard > RubCardType.NotShow)
        //         this.label_rule.string += _rubCard == RubCardType.Enable ? "\n允许搓牌" : "\n不允许搓牌";
        // }
    }

    //==================================== 按钮事件 开始 =======================================
    private IsButtonDisable() {
        return NiuNiu.ins.iclass.IsVideo();
    }
    //菜单
    private OnButtonMenu() {
      if(this.group_menu.active){
            this.group_menu.active = false;
        }else{
            this.group_menu.active = true;
        }
     //   this.btn_menu.node.active = false;
    }
    private OnButtonExit() {
        this.HideMenu();
        NiuNiu.ins.iview.OnButtonExit();
    }
    private OnButtonShare() {
        if (this.IsButtonDisable()) return;
        this.HideMenu();
        NiuNiu.ins.iview.OnButtonShare();
    }
    private OnButtonAudio() {
        if (this.IsButtonDisable()) return;
        this.HideMenu();
        NiuNiu.ins.iview.OnButtonAudio();
    }
    private OnButtonHelp() {
        if (this.IsButtonDisable()) return;
        this.HideMenu();
        NiuNiu.ins.iview.OnButtonHelp();
    }
    private OnButtonDissolveTable() {
        if (this.IsButtonDisable()) return;
        this.HideMenu();
        var data = new M_NiuNiu_GameMessage.CMD_C_DissolveTable();
        data.agree = true;
        NiuNiu.ins.iclass.SendData(data);
    }
    //准备
    private OnButtonReady() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonReady();
    }
    private OnButtonInvitation() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonShare();
    }
    private OnButtonTotalScore() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.ShowTotalScore();
    }
    //附加功能
    public OnButtonChat() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonChat();
    }
    public OnButtonTiren() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonTiren();
    }
    public OnButtonVoice() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonVoice();
    }
    public OnVoiceStop() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnVoiceStop();
    }
    public OnButtonQueryScore() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonQueryScore();
    }
    //抢庄
    public OnButtonRob(value: number = 0) {
        if (this.IsButtonDisable()) return;
        this.HideRob();
        var data = new M_NiuNiu_GameMessage.CMD_C_RobMaster();
        data.robMasterRate = this.RobRate[value];
        NiuNiu.ins.iclass.SendData(data);
    }
    //下注
    public OnButtonBet(value: number = 0) {
        if (this.IsButtonDisable()) return;
        this.HideBet();
        var data = new M_NiuNiu_GameMessage.CMD_C_Bet();
        data.betRate = value == this.BetRate.length ? this.extendBet : this.BetRate[value];
        NiuNiu.ins.iclass.SendData(data);
    }
    //选牌
    private OnButtonSelectCard(value: boolean) {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonSelectCard(value);
    }
    //搓牌
    private OnButtonRubCard() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonRubCard();
    }
    //选牌提示
    private OnButtonSelectHelp() {
        if (this.IsButtonDisable()) return;
        NiuNiu.ins.iview.OnButtonSelectHelp();
    }

    private ShowWanfa(){
        NiuNiu.ins.iview.ShowWanfa();
    }
    //==================================== 按钮事件 结束 =======================================

    //==================================== 辅助 开始 =======================================
    /**
     * 是否显示准备
     */
    public IsShowReady() {
        return this.btn_ready.node.active;
    }
    //==================================== 辅助 结束 =======================================
}
