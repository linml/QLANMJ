import HZMJ_CardBase from "../single/HZMJ_CardBase";
import { HZMJMahjongDef } from "../../ConstDef/HZMJMahjongDef";
import HZMJ_SingleActive from "../single/banlanceShow/HZMJ_SingleActive";
import { ReportError } from "../../../../Tools/Function";

const { ccclass, property } = cc._decorator;

@ccclass
export default class HZMJ_BanlanceActive extends HZMJ_CardBase {

    @property(cc.Prefab)
    CardType: cc.Prefab=null;

    onLoad() {
        // init logic
        
    }

    /**
     * 排列起始位置
     * 
     * 站立状态,x间隔:74
     * 活动牌起点:y=595
     * 活动牌起点:x:159,270,381,492,603
     * 
     * 
     * 摊开状态,x间隔:74
     * 活动牌起点:y=595
     * 活动牌起点:x:159,270,381,492,603
     * */
    private _arrangeStartPos: Array<number> = [-45,117,270,420,565];
    /**
     * 显示牌
     * */
    protected _cardData: Array<HZMJ_SingleActive>;
    /**
     * 手牌
     * */
    protected _handCard:Array<number>
    /**
     * 抓到的牌
     * */
    public _holdCard:number;
    /**
     * 定牌数量
     * */
    private _fixedCardNum: number;
    public static _freeNode=new cc.NodePool();


    
    public init() {
        this._cardData = new Array<HZMJ_SingleActive>(0);
        this._handCard = new Array<number>(0);
        this._holdCard=HZMJMahjongDef.gInvalidMahjongValue;
        this._fixedCardNum=0;
    }
    
    /**
     * 获取定牌数量
     * */
    public get fixedCardNum():number{
        return this._fixedCardNum;
    }
    
    /**
     * 设置定牌剩余数量
     * */
    public set fixedCardNum(fixedNum:number){
        this._fixedCardNum=fixedNum;
    }
    
    /**
     * 刷新手牌数据
     * */
    public refreshHandCardData(cardAry:Array<number>):void{
        this._handCard.splice(0,this._handCard.length);
        for(var i:number=0; i<cardAry.length; i++){
            this._handCard.push(cardAry[i]);
        }
        
        this.handCardChange();
    }

    /**
     * 刷新手牌
     * */
    protected refreshHandCard(): void {
            //起始位置
        var startPos: number = this._arrangeStartPos[this.fixedCardNum];
        
        //开始排版
        for(var i: number = 0;i < this._cardData.length;i++) {
            this._cardData[i].node.x = startPos + i * 49-350+22.5+10;
            this._cardData[i].node.y = -5;
            this._cardData[i].showCard(this._handCard[i],true);
            
            if(this._holdCard != HZMJMahjongDef.gInvalidMahjongValue && (i == (this._cardData.length - 1))) {
                this._cardData[i].node.x += 15;
            }
        }
    }



    /**
     * 牌阵变化
     * */
    protected handCardChange(): void {

        

        if(this._handCard.length > this._cardData.length) {//需要增加活动牌

            var newNum = this._handCard.length - this._cardData.length;
            for(var i: number = 0;i < newNum;i++) {
              //  var newnode=cc.instantiate(this.CardType);
              let newnode = HZMJ_BanlanceActive._freeNode.get();
                if (!cc.isValid(newnode)) {
                    newnode = cc.instantiate(this.CardType);
                }
                this.node.addChild(newnode);
                var active = newnode.getComponent<HZMJ_SingleActive>(HZMJ_SingleActive);
                active.init();
                this._cardData.push(active);
                newnode.active=true;
            }

        } else if(this._handCard.length < this._cardData.length) {//需要删除活动牌

            var delNum = this._cardData.length - this._handCard.length;
            for(var i: number = 0;i < delNum;i++) {
             //   this._cardData[i].node.destroy();
              HZMJ_BanlanceActive._freeNode.put(this._cardData[i].node);
            }
            this._cardData.splice(0,delNum);
        }
    
        this.refreshHandCard();
    }

    /**
     * 清理
     * */
    public clear(): void {
        super.clear();
        this._cardData.length = 0;
        while (this.node.children.length > 0) {
            // this._cardData.pop().node.destroy();
            // HBMJ_BanlanceActive._freeNode.put(this.node.children[0]);
            let active = this.node.children[0];


            if (cc.isValid(active)) {
                // if (cc.sys.isNative && cc.sys.platform === cc.sys.ANDROID) {
                //     active.removeFromParent();
                //     active.destroy();
                // } else {
                    HZMJ_BanlanceActive._freeNode.put(active);
                // }
            } else {
                ReportError("手牌数据出错！！！");
            }
        }
        this._handCard.splice(0,this._handCard.length);
        this._holdCard = HZMJMahjongDef.gInvalidMahjongValue;
        this._fixedCardNum = 0;
    }
}
