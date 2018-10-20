import UIBase from "../Base/UIBase";
import { UIName } from "../../Global/UIName";

const {ccclass, property} = cc._decorator;

@ccclass
export default class NewClass extends UIBase<any> {
    public IsEventHandler: boolean = true;
    public IsKeyHandler: boolean = true;


    @property(cc.EditBox)
    userName: cc.EditBox = null;
    @property(cc.EditBox)
    phone: cc.EditBox = null;
    @property(cc.EditBox)
    city: cc.EditBox = null;
    @property(cc.EditBox)
    detailsAddress: cc.EditBox = null;


    private chooseCity(){
        this.UiManager.ShowUi(UIName.Area)
    }
    // LIFE-CYCLE CALLBACKS:

    // onLoad () {}

    start () {

    }

    // update (dt) {}
}
