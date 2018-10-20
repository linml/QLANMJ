import { IEventHandler } from "../../Interface/IEventHandler";
import { Action } from "../../CustomType/Action";
import Global from "../../Global/Global";
import { EventCode } from "../../Global/EventCode";
import { AudioType } from "../../CustomType/Enum";
import { PlayEffect, ReflushNodeWidgetAlignment } from "../../Tools/Function";

const { ccclass, property } = cc._decorator;

export default abstract class UIBase<T> extends cc.Component implements IEventHandler {
    /** 
     * 是否播放弹出动作
     */
    protected isPlayPopAction: boolean = true;
    protected isShowUI: boolean = false;
    //表示当前的页面是否已经激活进场动画
    protected hasEnterAnimation: boolean = false;
    //表示当前的页面是否已经激活进场动画
    protected hasExitAnimation: boolean = false;
    public get isOneInstance(): boolean { return true; }


    onLoad(): void {
        //cc.game.addPersistRootNode(this.node);
    }

    start(): void {
        //this.node.setPosition(640,360);
    }

    update(): void {

    }

    lateUpdate(): void {

    }

    onDestroy(): void {
        if (this.IsEventHandler) {
            Global.Instance.EventManager.UnRegisterEventHadnle(this);
        }
    }

    onEnable(): void {

    }

    onDisable(): void {

    }

    protected ShowParam: T;
    protected get DataCache() {
        return Global.Instance.DataCache;
    }
    protected get EventManager() {
        return Global.Instance.EventManager;
    }
    protected get UiManager() {
        return Global.Instance.UiManager;
    }

    protected get UserInfo() {
        return this.DataCache.UserInfo;
    }
    OnEventComeIn(eventCode: number, value: any): boolean {
        switch (eventCode) {
            case EventCode.onKeyPressed:
                return this.onKeyboardClick(value);
        }
        return this.OnUiEventComeIn(eventCode, value);
    }



    // /**
    //  * 名字
    //  */
    // public abstract get UIname(): string;

    private onKeyboardClick(value: cc.KEY) {
        if (!this.IsKeyHandler) {
            return false;
        }
        if (value === cc.KEY.escape || value == cc.KEY.back) {
            this.BackClick();
            return true;
        } else {
            return this.OnKeyClick(value);
        }
    }


    /**
     * 是否监听信息
     */
    public abstract get IsEventHandler(): boolean;

    /**
     * 是否处理物理按键
     */
    public abstract get IsKeyHandler(): boolean;

    /**
     * 
     * @param eventCode 消息到达
     * @param value 
     */
    protected OnUiEventComeIn(eventCode: number, value: any): boolean {
        return false;
    }

    /**
     * 显示
     * @param root 
     * @param param 
     * @param action 
     */
    public Show(root: cc.Node, param?: T, action?: Action) {
        if (this.isShowUI && this.isOneInstance) return;
        this.isShowUI = true;
        if (!(cc.isValid(root) && this.isValid)) {
            //root = cc.director.getScene();
            root = cc.Canvas.instance.node;
        }
        if (this.IsEventHandler) {
            Global.Instance.EventManager.RegisterEventHadnle(this);
        }
        this.ShowParam = param;
        this.node.removeFromParent(true);
        root.addChild(this.node);
        this.InitShow();
        this.OnShow();
        this.PlayEnterAnimation();
        if (action) {
            action.RunArgs();
        }
    }

    /**
     * 关闭
     * @param action 
     */
    public Close(action?: Action, param?: any) {
        this.scheduleOnce(() => {
            if (!this.isShowUI || this.hasEnterAnimation) return;
            this.isShowUI = false;
            this.hasEnterAnimation = false;
            this.PlayExitAnimation(() => {
                this.CloseUI();
            })
        });
    }
    private CloseUI(action?: Action, param?: any) {
        PlayEffect(cc.url.raw("resources/Sound/close_panel.mp3"));
        if (this.IsEventHandler) {
            Global.Instance.EventManager.UnRegisterEventHadnle(this);
        }
        //cc.log(this.node.parent);
        this.node.removeFromParent(true);
        this.OnClose();
        if (action) {
            action.RunArgs();
        }
    }


    /**
     * 刷新
     */
    protected InitShow() {

    }

    protected OnShow() {
        this.isShowUI = true;
        this.PlayEnterAnimation();
    }

    protected OnClose() {

    }


    /****************************** 界面的进场动画和退场动画部分 ************************************* */

    protected PlayEnterAnimation() {
        if (this.isPlayPopAction) {
            if (this.hasEnterAnimation) return;
            this.hasEnterAnimation = true;
            ReflushNodeWidgetAlignment(this, this.EnterAnimation.bind(this));
        }
    }
    protected EnterAnimation() {
        // 弹出效果、从小到大，然后再从大到小
        // if (this.isPlayPopAction) {
        let oldScale = this.node.scale;
        cc.log(oldScale);
        this.node.setScale(0.5);
        this.node.opacity = 255;
        let scaleadd = 0.05
        this.node.runAction(cc.spawn(
            cc.fadeTo(0.3, 255),
            cc.sequence(cc.scaleTo(0.15, oldScale + scaleadd, oldScale + scaleadd),
                cc.scaleTo(0.15, oldScale, oldScale)
                , cc.callFunc(() => {
                    this.hasEnterAnimation = false;
                }))
        ));
    }
    protected PlayExitAnimation(callBack?: Function) {
        if (this.isPlayPopAction) {
            if (this.hasExitAnimation) return;
            this.hasExitAnimation = true;
            this.ExitAnimation(callBack);
            return;
        }
        if (!!callBack) {
            callBack();
        }
    }
    protected ExitAnimation(callBack?: Function) {
        // 弹出效果、从小到大，然后再从大到小
        if (!callBack) {
            callBack = () => { };
        }

        let oldScale = this.node.scale;
        let closeScale = 0.3;
        cc.log(oldScale);
        // this.node.setScale(0.5);
        // this.node.opacity = 128;
        let scaleadd = 0.05
        this.node.runAction(cc.spawn(
            cc.fadeTo(0.3, 255),
            cc.sequence(cc.scaleTo(0.15, oldScale + scaleadd, oldScale + scaleadd),
                cc.scaleTo(0.15, closeScale, closeScale)
                , cc.callFunc(() => {
                    this.hasExitAnimation = false;
                    callBack();
                    this.node.setScale(oldScale);
                }))
        ));
    }




    public BackClick() {
        this.Close();
    }
    public OnKeyClick(value: cc.KEY): boolean {
        return false;
    }
    public CloseClick() {
        this.Close();
    }

}