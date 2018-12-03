import HQMJ_VideoActiveBase from "./HQMJ_VideoActiveBase";
import { HQMJ } from "../../ConstDef/HQMJMahjongDef";
import M_HQMJVideoClass from "../../M_HQMJVideoClass";

const { ccclass, property } = cc._decorator;

@ccclass
export default class HQMJ_OppoVideoActive extends HQMJ_VideoActiveBase {


    onLoad() {
        // init logic
        super.onLoad();
        this.init(2);
        
    }

    //
    //摊开状态,x间隔38
    //
    //活动牌起点:y=36
    //活动牌起点:x:847,733,619,505,391
    private static ArrangeStartPos_lie: Array<number> = [892,785,675,550,425];
    
    private static ArrangeStartPos3D_lie: Array<number> = [310,185,45,-95,-235];
    
    /**
     * 刷新手牌
     * */
    // protected refreshHandCard(): void {
    //     //起始位置
    //     var startPos: number = HQMJ_OppoVideoActive.ArrangeStartPos_lie[this.fixedCardNum];

    //     //开始排版
    //     for(var i: number = 0;i < this._cardData.length;i++) {
    //         this._cardData[i].node.x = startPos - i * 37-640-18;
    //         this._cardData[i].node.y = 284;
    //         this._cardData[i].showCard(this._handCard[i],true);

    //         if(this.isHoldAfter && (i == (this._cardData.length - 1))) {
    //             this._cardData[i].node.x -= 15;
    //         }
    //     }
    // }
    protected refreshHandCard(): void {
        if(M_HQMJVideoClass.ins.is2D()){
            //起始位置
            let startPos: number = HQMJ_OppoVideoActive.ArrangeStartPos_lie[this.fixedCardNum];

            //开始排版
            for(var i: number = 0;i < this._cardData.length;i++) {
                this._cardData[i].node.x = startPos - i * 37-640-18;
                this._cardData[i].node.y = 284;
                this._cardData[i].showCard(this._handCard[i],true,0,M_HQMJVideoClass.ins);

                if(this.isHoldAfter && (i == (this._cardData.length - 1))) {
                    this._cardData[i].node.x -= 15;
                }
            }
        }else{
            let temp=0;
            if(this._cardData.length%3==2){
                temp=14-this._cardData.length;
            }else{
                temp=13-this._cardData.length;
            }

            //起始位置
            let startPos: number = HQMJ_OppoVideoActive.ArrangeStartPos3D_lie[this.fixedCardNum];
            this.resetZ();
            
            //开始排版
            for(let i: number = 0;i < this._cardData.length;i++) {
                // this._cardData[i].node.setLocalZOrder(i+1);
                // this._cardData[i].node.x = startPos - i * 44;
                // this._cardData[i].node.y = 280;
                this._cardData[i].showCard(this._handCard[i],true,i+temp+1,M_HQMJVideoClass.ins);

                // if(this.isHoldAfter && (i == (this._cardData.length - 1))) {
                //     this._cardData[i].node.x -= 15;
                // }
            }
            
        }
        
        
    }
    private resetZ(){
        if(this._cardData.length<=7){
            for(let i: number = 0;i < this._cardData.length;i++){
                this._cardData[i].node.setLocalZOrder(this._cardData.length-i);
            }
        }else{
            let x=this._cardData.length-7;    
            for(let i: number = 0;i < x;i++){
                this._cardData[i].node.setLocalZOrder(i);
            }
            for(let i: number = x;i < this._cardData.length;i++){
                this._cardData[i].node.setLocalZOrder(this._cardData.length-i);
            }
            
        }

    }

    /**
     * 刷新手牌数据
     * */
    public refreshHandCardData(cardAry: Array<number>): void {
        // for(var i:number=0; i<cardAry.length; i++){
        //     cardAry[i]=0x01;
        // }
        super.refreshHandCardData(cardAry);
    }
    
    /**
     * 抓牌墩牌
     * */
    public holdTricksCard(holdIdx: number): number {
        
        //4+4+4+1
        var holdNum =holdIdx;// (3 == holdIdx ? 1 : 4);

        for(var i: number = 0;i < holdNum;i++) {
            this._handCard.push(0x01);
        }

        this.handCardChange();
        
        return holdNum;
    }

    /**
     * 抓到一张牌
     * */
    public holdACard(card: number,_hqmj): void {
        super.holdACard(card,_hqmj);
    }

    /**
     * 打出一张牌
     * */
    public outACard(card: number,_hqmj): void {
        super.outACard(card,_hqmj);
    }

     /**
     * 吃了一张牌
     * */
    public chiACard(card: number,type:number,_hqmj): void {
        super.chiACard(card,type,_hqmj);
    }
    
    /**
     * 碰了一张牌
     * */
    public pengACard(card: number,_hqmj): void {
        super.pengACard(card,_hqmj);
    }

    /**
     * 明杠了一张牌
     * */
    public MGangACard(card: number,_hqmj): void {
        super.MGangACard(card,_hqmj);
    }

    /**
     * 暗杠了一张牌
     * */
    public AGangACard(card: number,_hqmj): void {
        super.AGangACard(card,_hqmj);
    }

    /**
     * 补杠了一张牌
     * */
    public BGangACard(card: number,_hqmj): void {
        super.BGangACard(card,_hqmj);
    }

}
