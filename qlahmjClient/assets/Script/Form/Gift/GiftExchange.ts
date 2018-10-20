import UIBase from "../Base/UIBase";
import { UIName } from "../../Global/UIName";
import GiftInfo from "./GiftInfo";

const {ccclass, property} = cc._decorator;

@ccclass
export default class NewClass extends UIBase<any> {
    public IsEventHandler: boolean=true;
    public IsKeyHandler: boolean=true;
    /**
     * 礼品简介
     */
    @property(cc.Label)
    desc_label: cc.Label = null;
    /**
     * 礼品名称
     */
    @property(cc.Label)
    giftName_label: cc.Label = null;
    /**
     * 所需七豆数量
     */
    @property(cc.Label)
    giftCoupon_label: cc.Label = null;
    /**
     * 礼品图片
     */
    @property(cc.Sprite)
    giftImg:cc.Sprite = null;
    /**
     * 虚拟物品editBox
     */
    @property(cc.Node)
    node_virtual:cc.Node = null;
    /**
     * 实物礼品editBox
     */
    @property(cc.Node)
    node_entity:cc.Node = null;
    /**
     * 话费editBox
     */
    @property(cc.Node)
    node_phone:cc.Node = null;
    /**
     * 虚拟物品充值账号
     */
    @property(cc.EditBox)   
    rechargeNum:cc.EditBox = null;
    /**
     * 手机号
     */
    @property(cc.EditBox)   
    phoneNum:cc.EditBox = null;
    /**
     * 姓名
     */
    @property(cc.EditBox)   
    userName:cc.EditBox = null;
    /**
     * 收货地址
     */
    @property(cc.EditBox)   
    userAddress:cc.EditBox = null;

    private giftInfo:GiftInfo = null;
    private category:number = null;

    /**
     * initShow
     */

    InitShow() {
        this.giftInfo = this.ShowParam;
        if(this.desc_label){
            this.desc_label.string = this.giftInfo.introduces;
        }
        if(this.giftName_label){
            this.giftName_label.string = this.giftInfo.giftName;
        }
        if(this.giftCoupon_label){
            this.giftCoupon_label.string = this.giftInfo.price.toString();
        }
        cc.loader.loadRes(this.giftInfo.image,cc.SpriteFrame,(err,spriteFrame)=>{
            this.giftImg.getComponent(cc.Sprite).spriteFrame = spriteFrame;
        })

        //判断礼品类型，显示不同的editBox
        this.category = this.giftInfo.category;
        switch(this.giftInfo.category){
            case 0://虚拟
                this.node_entity.active = false;
                this.node_phone.active = false;
                this.node_virtual.active = true;
            break;
            case 1://话费
                this.node_entity.active = false;
                this.node_virtual.active = false;
                this.node_phone.active = true;
            break;
            default://实物
                this.node_virtual.active = false;
                this.node_phone.active = true;
                this.node_entity.active = true;
            break;
        }
    }
    /**
     * 获取用户输入的信息，进行兑换
     */
    private startExchangeClick(){
        if(this.category === 0){
            let rechargeNum = this.rechargeNum.string;
            
        }else if(this.category === 1){
            let phoneNum = this.phoneNum.string;
            
        }else{
            let phoneNum = this.phoneNum.string;
            let userAddress = this.userAddress.string;
            let userName = this.userName.string;
        }
    }

   
}
