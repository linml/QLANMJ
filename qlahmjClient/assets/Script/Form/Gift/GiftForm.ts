import UIBase from "../Base/UIBase";
import { UIName } from "../../Global/UIName";
import GiftCategoryScrollView from "./GiftCategoryScrollView";
import { Action } from "../../CustomType/Action";
import GiftItem from "./GiftItem";

const {ccclass, property} = cc._decorator;

@ccclass
export default class GiftForm extends UIBase<any> {
    public IsEventHandler: boolean=true;
    public IsKeyHandler: boolean=true;
    /**
     * 礼品种类scrollview
     */
    @property(cc.ScrollView)
    GiftCategory_scrollview:cc.ScrollView = null;
    /**
     * 礼品列表
     */
    @property(cc.Layout)
    layout_gift:cc.Layout = null;
    /**
     * 礼品预制体
     */
    @property(cc.Prefab)
    prefab_giftCategoryItem:cc.Prefab = null;


    /**
    *初始化
    */
    public InitShow(){
        this.initGiftFormUI();
    }

    public initGiftFormUI():void{
        let giftCategory: GiftCategoryScrollView = this.GiftCategory_scrollview.getComponent("GiftCategoryScrollView");
        let giftCategoryList = [];
        giftCategory.resetList();
        giftCategory.clickAction = new Action(this,this.giftItemClickEvent);
        giftCategory.ShowData = giftCategoryList;
        giftCategory.refreshData(giftCategoryList);
        giftCategory.setDefaultSelectedIdx(0);
        
    }

    /**
    *按钮点击事件
    */
    public giftItemClickEvent(info:any):void{
        if (!info || !info.list) {
            return;
        }
        this.chanageGamePanel();
        this.initGiftInfoList(info.list);

    }

    /**
     *  切换礼品种类标签
     */
    public chanageGamePanel(): void{
    	// 清空面板
        this.layout_gift.node.removeAllChildren();
    }
    /**
     * 
     */
    private initGiftInfoList(giftList:any){
        if(!giftList){
            return;
        }
        for(var i = 0;i<giftList.length;i++){
            let newNode = cc.instantiate(this.prefab_giftCategoryItem);
            let item:GiftItem = newNode.getComponent(GiftItem);

            item.initUI(giftList[i]);
            item.node.getContentSize();
            
            this.layout_gift.node.addChild(item.node);
        }
    }

    /**
    *兑换记录
    */
    private recordClick(){
        this.UiManager.ShowUi(UIName.GiftExchangeRecord);
    }
}
