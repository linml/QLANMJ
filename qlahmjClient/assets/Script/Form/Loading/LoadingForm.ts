import UIBase from "../Base/UIBase";
import { UIName } from "../../Global/UIName";
import Global from "../../Global/Global";
import { QL_Common } from "../../CommonSrc/QL_Common";
import { EventCode } from "../../Global/EventCode";
import { Action } from "../../CustomType/Action";

const { ccclass, property } = cc._decorator;
@ccclass
export class LoadingForm extends UIBase<any>{

    public IsEventHandler: boolean = false;
    public IsKeyHandler: boolean = false;

    @property(cc.Label)
    label: cc.Label = null;

    // @property(cc.Animation)
    // ani: cc.Animation = null;


    onLoad() {

    }

    InitShow() {
        this.isPlayPopAction = false;
        
        if (!cc.game.isPersistRootNode(this.node)) {
            cc.game.addPersistRootNode(this.node);
        }
    }

    start() {
        // this.node.setPosition(640, 360);
    }

    public OnLoadInfo(str: string) {
        if (cc.isValid(this.label)) {
            this.label.string = str;
        }
    }
 }