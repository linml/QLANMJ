import { TingCardTip } from "../ConstDef/LHZMJMahjongDef";
import M_LHZMJClass from "../M_LHZMJClass";
import LHZMJ_SingleTingCardTip from "./LHZMJ_SingleTingCardTip";

const { ccclass, property } = cc._decorator;

@ccclass
export default class LHZMJ_TingTip extends cc.Component {

    //背景
    @property(cc.Sprite)
    img_bg: cc.Sprite=null;

    @property(cc.Prefab)
    LHZMJ_SingleTingCard_Tip: cc.Prefab=null;

     @property(cc.ScrollView)
    scroll:cc.ScrollView=null;

    @property(cc.Node)
    maskRect:cc.Node=null;

    @property(cc.Node)
    showNode:cc.Node=null;

    @property(cc.Sprite)
    img_hu: cc.Sprite=null;

    @property(cc.Sprite)
    img_zhezhao: cc.Sprite=null;


    //结算
    private _singleTingCard: LHZMJ_SingleTingCardTip;
    /**
     * 结算视图
     * */
    public get SingleTingCard(): LHZMJ_SingleTingCardTip {
        return this._singleTingCard;
    }
     public static _freeNode=new cc.NodePool();

    onLoad() {
        // init logic
       // this.init();
    }
    	
    //听牌提示
    private _tingCardAry: Array<LHZMJ_SingleTingCardTip>;

    public init() {
        this.node.active = false;
        this.img_zhezhao.node.active = false;
        if(this._tingCardAry!=null)
        {
            while (this._tingCardAry.length > 0) {
               // this._tingCardAry.pop().node.destroy();
                LHZMJ_TingTip._freeNode.put(this._tingCardAry.pop().node);
            }
        }else{
            this._tingCardAry = new Array<LHZMJ_SingleTingCardTip>();
        }
        
    }

    /**
     * 显示听牌提示
     * */
    public showTingTip(tingTip: Array<TingCardTip>, tips:boolean): void {
        if ((null == tingTip) || (tingTip.length < 1)) {
            this.node.active = false;
            return;
        }

        while (this._tingCardAry.length > 0) {
         //   this._tingCardAry.pop().node.destroy();
         LHZMJ_TingTip._freeNode.put(this._tingCardAry.pop().node);
        }

        //设置背景宽度
       // this.img_bg.node.width = 90 + tingTip.length * 120 - 40;

         let maxwidth=120 + tingTip.length * 120 - 40;
        this.showNode.width=maxwidth;
        if(maxwidth>1280){
            //this.maskRect.width=1280;
            this.img_bg.node.width=1280;
            //this.scroll.node.width=1280;
        }
        else{
            //this.maskRect.width=maxwidth;
            this.img_bg.node.width=maxwidth;
        }
        if(tips){
            if(maxwidth>1280){
                this.scroll.node.width = 1080;
                this.img_zhezhao.node.active = true;
               
                //this.maskRect.width = 880;
                this.scroll.node.x  = 719 - 80;
                this.scroll.horizontal = true;
                this.img_hu.node.x = 209;
                this.img_zhezhao.node.x = 200;
            }else{
                this.scroll.node.width = maxwidth-100;
                //this.maskRect.width =maxwidth -100;
                this.scroll.node.x  = 719 - (1280-maxwidth)/2+44;
                this.scroll.horizontal = false;
                this.img_zhezhao.node.active = false;
            }
        
        
        }else{
            this.scroll.node.x =719;
            this.scroll.node.width=1280;
            this.scroll.horizontal = true;
            this.img_hu.node.x = 9;
            this.img_zhezhao.node.active = false;
        }

        
        console.log(`滑动框宽度：${this.showNode.width}`);

        this.scroll.scrollToLeft();

        //添加听牌提示
        this.img_bg.node.opacity = 210;
        for (var i: number = 0; i < tingTip.length; i++) {
            //var singleTip: LHZMJ_SingleTingCardTip = new LHZMJ_SingleTingCardTip();

          //  let singleTip=cc.instantiate(this.LHZMJ_SingleTingCard_Tip);
          let singleTip = LHZMJ_TingTip._freeNode.get();
            if (!cc.isValid(singleTip)) {
                singleTip = cc.instantiate(this.LHZMJ_SingleTingCard_Tip);
            }
            this._singleTingCard=singleTip.getComponent<LHZMJ_SingleTingCardTip>(LHZMJ_SingleTingCardTip);
            this._singleTingCard.setData(tingTip[i]);
            if(tips&&maxwidth>1280){
            this._singleTingCard.node.x = 214 + i * 120;
            this._singleTingCard.node.y = 0;
            }else{
            this._singleTingCard.node.x = 30 + i * 120;
            this._singleTingCard.node.y = 0;
            }
            
            
            this.showNode.addChild(singleTip);

            this._tingCardAry.push(this._singleTingCard);
        }
        cc.log("显示全部听牌！！！");
        this.node.active = true;
    }

    /**
     * 获取尺寸
     * */
    public get size(): { width: number, height: number } {
        if (this.img_bg == null) {
            return { width: 20, height: 80 };
        }
        return { width: this.img_bg.node.width, height: 80 };
    }
}

