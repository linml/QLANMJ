


import Global from "../../Global/Global";
import UIBase from "../Base/UIBase";
import { Action } from "../../CustomType/Action";
import { ReflushNodeWidgetAlignment, PlayEffect } from "../../Tools/Function";
import { AudioType } from "../../CustomType/Enum";

const { ccclass, property } = cc._decorator;

@ccclass

export class MessageBox extends UIBase<any>{
    public IsEventHandler: boolean = true;
    public IsKeyHandler: boolean = true;

    private _isFree = true;
    public get IsFree() {
        return this._isFree;
    }

    @property(cc.Label)
    text: cc.Label = null;

    thisobj: any;
    sureFun: Function;
    sureArgs: any;
    cancleFun: Function;
    cancleArgs: any;
    closeFun: Function;
    closeArgs: any;

    onLoad() {

        //cc.game.addPersistRootNode(this.node);
    }

    start() {
        // this.node.setPosition(640,360);
    }

    public Go(text: string, thisobj, okFun, cancleFun, closeFun, okArgs, cancleArgs, closeArgs) {
        
        //弹出音效
        PlayEffect(cc.url.raw("resources/Sound/open_panel.mp3"));

        this.text.string = text;
        this.thisobj = thisobj;
        this.sureFun = okFun;
        this.cancleFun = cancleFun;
        this.closeFun = closeFun;
        this.sureArgs = okArgs;
        this.cancleArgs = cancleArgs;
        this.closeArgs = closeArgs;

        this._isFree = false;
 
        const scene = cc.director.getScene();
        this.node.removeFromParent(true);
        scene.addChild(this.node);

        if (!cc.game.isPersistRootNode(this.node)) {
            cc.game.addPersistRootNode(this.node);
        }
        this.InitShow();
        this.OnShow();
        Global.Instance.EventManager.RegisterEventHadnle(this);
    }

    

    public SureClick() {
        this.RunAction(this.sureFun, this.thisobj, this.sureArgs);
        this.Close();
    }

    public CancleClick() {
        this.RunAction(this.cancleFun, this.thisobj, this.cancleArgs);
        this.Close();
    }

    public CloseClick() {
        this.RunAction(this.closeFun, this.thisobj, this.closeArgs);
        this.Close();
    }

    public Close() {
        super.Close();
        this._isFree = true;
    }


    private RunAction(fun: Function, obj?: any, argArray?: any) {
        if (typeof fun !== "function") {
            cc.warn("待执行的fun不是一个function")
            return;
        }
        fun.apply(obj, argArray);
    }
}