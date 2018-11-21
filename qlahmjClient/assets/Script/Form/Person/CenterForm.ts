import UIBase from "../Base/UIBase";
import { LoadHeader } from "../../Tools/Function";
import Global from "../../Global/Global";
import ConfigData from "../../Global/ConfigData";
import { QL_Common } from "../../CommonSrc/QL_Common";
import { UIName } from "../../Global/UIName";
import { NativeCtrl } from '../../Native/NativeCtrl';

const { ccclass, property } = cc._decorator;

@ccclass
export class CenterForm extends UIBase<any>{
    public IsEventHandler: boolean = true;
    public IsKeyHandler: boolean = true;

    @property(cc.Sprite)
    header: cc.Sprite = null;
    @property(cc.Label)
    nickname: cc.Label = null;
    @property(cc.Node)
    isAttestation : cc.Node = null;
    @property(cc.Label)
    id: cc.Label = null;
    @property(cc.Label)
    ip: cc.Label = null;
    @property(cc.EditBox)
    editBox: cc.EditBox = null;
    @property(cc.Node)
    btn_bind_phone : cc.Node = null;
    @property(cc.Label)
    lab_bind_text : cc.Label = null;

    @property(cc.Toggle)
    man:cc.Toggle = null;
    @property(cc.Toggle)
    woman:cc.Toggle = null;
    @property(cc.Toggle)
    secrecy:cc.Toggle = null;


    InitShow(): void {
        super.onLoad();
        this.id.string = "ID：" + this.UserInfo.userData.UserID;
        this.nickname.string = this.UserInfo.userData.NickName;
        LoadHeader(this.UserInfo.userData.Header, this.header);
        this.ip.string = this.UserInfo.userData.UserIP;

        let userGender =cc.sys.localStorage.getItem("userGender");
        cc.log("++++++++++"+userGender);
        if(userGender){
            switch(userGender){
                case "man":
                    this.secrecy.node.getComponent(cc.Toggle).isChecked = false;
                    this.woman.node.getComponent(cc.Toggle).isChecked = false;
                    this.man.node.getComponent(cc.Toggle).isChecked = true;
                break;
                case "woman":
                    this.man.node.getComponent(cc.Toggle).isChecked = false;
                    this.secrecy.node.getComponent(cc.Toggle).isChecked = false;
                    this.woman.node.getComponent(cc.Toggle).isChecked = true;
                break;
                default:
                    this.man.node.getComponent(cc.Toggle).isChecked = false;
                    this.woman.node.getComponent(cc.Toggle).isChecked = false;
                    this.secrecy.node.getComponent(cc.Toggle).isChecked = true;
                break;
            }
        }else{
            switch(this.UserInfo.userData.Gender){
                case 0:
                    this.man.node.getComponent(cc.Toggle).isChecked = false;
                    this.woman.node.getComponent(cc.Toggle).isChecked = false;
                    this.secrecy.node.getComponent(cc.Toggle).isChecked = true;
                break;
                case 1:
                    this.secrecy.node.getComponent(cc.Toggle).isChecked = false;
                    this.woman.node.getComponent(cc.Toggle).isChecked = false;
                    this.man.node.getComponent(cc.Toggle).isChecked = true;
                break;
                default:
                    this.man.node.getComponent(cc.Toggle).isChecked = false;
                    this.secrecy.node.getComponent(cc.Toggle).isChecked = false;
                    this.woman.node.getComponent(cc.Toggle).isChecked = true;
                break;
            }
        }
        this.editBox.string = this.UserInfo.Signature;

        if(this.DataCache.UserInfo.userData.IsAuthentication){
            this.isAttestation.active = true;
        }

        if(!this.UserInfo.userData.PhoneNum){
            this.btn_bind_phone.active = true;
            this.lab_bind_text.string = "点击右边文字绑定手机→";
        }else{
            this.btn_bind_phone.active = false;
            this.lab_bind_text.string = "绑定手机号为：" + this.UserInfo.userData.PhoneNum;
        }
        
    }

   private updateAddress(){
       this.UiManager.ShowUi(UIName.Address)
   }

   private copyMyId(){
    NativeCtrl.CopyToClipboard(""+this.UserInfo.userData.UserID);
   }

   public switchClick(toggle, customEventData:string) {
        cc.sys.localStorage.setItem("userGender",customEventData);
   }

   private bindPhone(){
        this.UiManager.ShowUi(UIName.BindPhonePanel);
        super.Close();
   }
}