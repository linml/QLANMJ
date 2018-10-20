import HQMJ_PoolBase from "./HQMJ_PoolBase";
import { HQMJ } from "../../ConstDef/HQMJMahjongDef";
import M_HQMJVideoClass from "../../M_HQMJVideoClass";

const { ccclass, property } = cc._decorator;

@ccclass
export default class HQMJ_UpPool extends HQMJ_PoolBase {

    onLoad() {
        // init logic
        this.init(3);
    }

    /**
     * 刷新牌池牌
     * */
    // protected refreshPoolCard(): {x:number,y:number} {
    //     if(this._poolCard.length < 1) {
    //         return {x:0,y:0};
    //     }
        
    //     var columnNum = Math.ceil((this._poolCard.length - 1) / 10) + 1;

    //     for(var i: number = 0;i < columnNum;i++) {
    //         for(var j: number = 0;j < 10;j++) {

    //             if((i * 10 + j) < this._poolCard.length) {

    //                 this._poolCard[i * 10 + j].node.x = -280 - i * 50.5;
    //                 this._poolCard[i * 10 + j].node.y = 182.5-15.75- j * 31.5-4;
    //                 this._poolCard[i * 10 + j].showCard(this._cardAry[i * 10 + j]);

    //             } else {
    //                 break;
    //             }

    //         }
    //     }

    //     var lastIdx: number = this._poolCard.length - 1;
        
    //     var rx: number = this._poolCard[lastIdx].node.x ;
    //     var ry: number = this._poolCard[lastIdx].node.y+ this._poolCard[lastIdx].size.height / 2;
    //     return { x: rx,y: ry };
    // }
    protected refreshPoolCard(): {x:number,y:number} {
        if(this._poolCard.length < 1) {
            return {x:0,y:0};
        }
        
        let columnNum = Math.ceil((this._poolCard.length - 1) / 10) + 1;
        let _hqmjclass = null;
        if(HQMJ.ins.iclass)
            _hqmjclass = HQMJ.ins.iclass;
        else
            _hqmjclass = M_HQMJVideoClass.ins;
        if(_hqmjclass.is2D()){
            for(var i: number = 0;i < columnNum;i++) {
                for(var j: number = 0;j < 10;j++) {

                    if((i * 10 + j) < this._poolCard.length) {

                        this._poolCard[i * 10 + j].node.x = -280 - i * 50.5;
                        this._poolCard[i * 10 + j].node.y = 182.5-15.75- j * 31.5-4;
                        this._poolCard[i * 10 + j].showCard(this._cardAry[i * 10 + j],0);

                    } else {
                        break;
                    }

                }
            }
        }else{
            //this.resetZ();
            for(let i: number = 0;i < columnNum;i++) {
                for(let j: number = 0;j < 10;j++) {
                    if((i * 10 + j) < this._poolCard.length) {
                        this._poolCard[i * 10 + j].showCard(this._cardAry[i * 10 + j],i * 10 + j+1,_hqmjclass);

                    } else {
                        break;
                    }

                }
            }
        }
        

        let lastIdx: number = this._poolCard.length - 1;
        
        let rx: number = this._poolCard[lastIdx].node.x ;
        let ry: number = this._poolCard[lastIdx].node.y+ this._poolCard[lastIdx].size.height / 2;
        return { x: rx,y: ry };
    }
    private resetZ(): void {
        if(this._poolCard.length <= 10){
            for (let i: number = 0; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(i + 21);
            }
        }else if (this._poolCard.length > 10 && this._poolCard.length <= 20) {
            for (let j: number = 0; j < 10; j++) {
                this._poolCard[j].node.setLocalZOrder(j + 21);
            }
            for (let i: number = 10; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(i + 1);
            }
        }else{
            for (let j: number = 0; j < 10; j++) {
                this._poolCard[j].node.setLocalZOrder(j + 21);
            }
            for (let k: number = 10; k < 20; k++) {
                this._poolCard[k].node.setLocalZOrder(k + 1);
            }
            for (let i: number = 20; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(1 - 19);
            }
        }

    }
    // private resetZ():void{
    //     if(this._poolCard.length>20){
    //         let temp=this._poolCard.length-20;
    //         for(let i: number = 0;i < temp;i++){
    //             this._poolCard[i+20].node.setLocalZOrder(i+1);
    //         }
    //         for(let i: number = 0;i < 10;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+1+temp);
    //         }
    //         for(let i: number = 10;i < 20;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+1+temp);
    //         }
    //     }else if(this._poolCard.length>10){
    //         let temp=this._poolCard.length-10;
    //         for(let i: number = 0;i < temp;i++){
    //             this._poolCard[i+10].node.setLocalZOrder(i+1);
    //         }
    //         for(let i: number = 0;i < 10;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+1+temp);
    //         }
    //     }else{
    //         for(let i: number = 0;i < this._poolCard.length;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+1);
    //         }
    //     }
        
    // }
}
