import GiftInfo from "./GiftInfo";
import { LoadHeader } from "../../Tools/Function";
import Global from "../../Global/Global";
import { UIName } from "../../Global/UIName";
import { UserData } from "../Record/RecordInfo";
import { QL_Common } from "../../CommonSrc/QL_Common";


const {ccclass, property} = cc._decorator;

@ccclass
export default class GiftItem extends cc.Component {
    /**
     * 七豆数量
     */
    @property(cc.Label)
    lab_qidouNum: cc.Label = null;
    /**
     * 礼品图片
     */
    @property(cc.Sprite)
    giftImg:cc.Sprite = null;
    /**
     * 礼品名称
     */
    @property(cc.Label)
    giftName:cc.Label = null;

    private giftInfo:GiftInfo=null;


    public initUI(Info:GiftInfo){
        this.lab_qidouNum.string = Info.price.toString();
        this.giftName.string = Info.giftName;
        cc.loader.loadRes(Info.image,cc.SpriteFrame,(err,spriteFrame)=>{
            this.giftImg.getComponent(cc.Sprite).spriteFrame = spriteFrame;
        })

        this.giftInfo = Info;
    }
    /**
     * 点击进入兑换页面
     */
    private goExchangeClick(){
        if(Global.Instance.DataCache.UserProp.GetValue(QL_Common.CurrencyType.QiDou) < this.giftInfo.price){
            Global.Instance.UiManager.ShowTip("您的七豆不足！无法进行兑换！");
            return;
        }
        Global.Instance.UiManager.ShowUi(UIName.GiftExchange,this.giftInfo);
    }
}
