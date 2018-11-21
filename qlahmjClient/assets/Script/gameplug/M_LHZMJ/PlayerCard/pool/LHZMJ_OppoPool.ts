import LHZMJ_PoolBase from "./LHZMJ_PoolBase";
import { LHZMJ } from "../../ConstDef/LHZMJMahjongDef";

const { ccclass, property } = cc._decorator;

@ccclass
export default class LHZMJ_OppoPool extends LHZMJ_PoolBase {


    onLoad() {
        // init logic
        this.init(2);
    }

    /**
     * 刷新牌池牌
     * */
    // protected refreshPoolCard(): {x:number,y:number} {
        
    //     if(this._poolCard.length < 1) {
    //         return {x:0,y:0};
    //     }
        
    //     var lineNum = Math.ceil((this._poolCard.length - 1) / 10) + 1;
    //     var valueIdx: number = 0;
    //     var cardIdx: number = this._poolCard.length;

    //     for(var i: number = 0;i < lineNum;i++) {
    //         for(var j: number = 0;j < 10;j++) {

    //             if((cardIdx > 0) && (valueIdx < this._cardAry.length)) {

    //                 --cardIdx;

    //                 this._poolCard[cardIdx].node.x = 189 - j * 42;
    //                 this._poolCard[cardIdx].node.y = 118 + i * 48;
    //                 this._poolCard[cardIdx].showCard(this._cardAry[valueIdx]);

    //                 ++valueIdx;
                    
    //             } else {
    //                 break;
    //             }

    //         }
    //     }

    //     var lastIdx = 0;
        
    //     var rx: number = this._poolCard[lastIdx].node.x;
    //     var ry: number = this._poolCard[lastIdx].node.y + this._poolCard[lastIdx].size.height / 2;
    //     return { x: rx,y: ry };
    // }
    protected refreshPoolCard(): {x:number,y:number} {
        
        if(this._poolCard.length < 1) {
            return {x:0,y:0};
        }
        
        
        let lastIdx = 0;
        let valueIdx: number = 0;
        let cardIdx: number = this._poolCard.length;
        if(LHZMJ.ins.iclass.is2D()){
            this.resetZ_2d();
            this.node.rotation = 0;
            let lineNum2d = Math.ceil((this._poolCard.length - 1) / 12) + 1;
            for(var i: number = 0;i < lineNum2d;i++) {
                for(var j: number = 0;j < 12;j++) {

                    if((cardIdx > 0) && (valueIdx < this._cardAry.length)) {

                        --cardIdx;

                        this._poolCard[cardIdx].node.x = 220 - j * 40;
                        this._poolCard[cardIdx].node.y = 133 + i * 47;
                        this._poolCard[cardIdx].showCard(this._cardAry[valueIdx],0);

                        ++valueIdx;
                        
                    } else {
                        break;
                    }

                }
            }
        }else{
            let lineNum = Math.ceil((this._poolCard.length - 1) / 9) + 1;
            this.resetZ();
            for(let i: number = 0;i < lineNum;i++) {
                for(let j: number = 0;j < 9;j++) {
                    if((i * 9 + j) < this._poolCard.length) {
                        this._poolCard[i * 9 + j].showCard(this._cardAry[i * 9 + j],i * 10 + j+1);

                    } else {
                        break;
                    }

                }
            }
            lastIdx=this._poolCard.length - 1;
        }
        let rx: number = this._poolCard[lastIdx].node.x;
        let ry: number = this._poolCard[lastIdx].node.y + this._poolCard[lastIdx].size.height / 2;
        return { x: rx,y: ry };
    }
    private resetZ_2d(): void {
        for (let i: number = 0; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(i+1);
            }
    }

    private resetZ(): void {
        if (this._poolCard.length <= 5) {
            for (let i: number = 0; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(i);
            }
        } else if (this._poolCard.length <= 9) {
            for (let i: number = 0; i < 5; i++) {
                this._poolCard[i].node.setLocalZOrder(i);
            }
            for (let i: number = 5; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(this._poolCard.length - i + 5);
            }
        } else if (this._poolCard.length <= 15) {
            let x = this._poolCard.length - 9;
            for (let i: number = 9; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(i - 9);
            }
            for (let i: number = 0; i < 5; i++) {
                this._poolCard[i].node.setLocalZOrder(i + x);
            }
            for (let i: number = 5; i <  9; i++) {
                this._poolCard[i].node.setLocalZOrder(9 - i + x);
            }

        } else if(this._poolCard.length <= 20){
            for (let i: number = 15; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(this._poolCard.length - i);
            }
            for (let i: number = 10; i < 15; i++) {
                this._poolCard[i].node.setLocalZOrder(i - 10);
            }
            for (let i: number = 0; i < 5; i++) {
                this._poolCard[i].node.setLocalZOrder(i + 10);
            }
            for (let i: number = 5; i < 10; i++) {
                this._poolCard[i].node.setLocalZOrder(this._poolCard.length - i);
            }
        }else if(this._poolCard.length <= 25){
            for (let i: number = 20; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(i - 20);
            }
            for (let i: number = 15; i < 20; i++) {
                this._poolCard[i].node.setLocalZOrder(29 - i);
            }
            for (let i: number = 10; i < 15; i++) {
                this._poolCard[i].node.setLocalZOrder(i-5);
            }
            for (let i: number = 5; i < 10; i++) {
                this._poolCard[i].node.setLocalZOrder(29-i);
            }
            for (let i: number = 0; i < 5; i++) {
                this._poolCard[i].node.setLocalZOrder(15 + i);
            }
        }else if(this._poolCard.length <= 30){
            for (let i: number = 25; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(24-i);
            }
            for (let i: number = 20; i < this._poolCard.length; i++) {
                this._poolCard[i].node.setLocalZOrder(i - 20);
            }
            for (let i: number = 15; i < 20; i++) {
                this._poolCard[i].node.setLocalZOrder(29 - i);
            }
            for (let i: number = 10; i < 15; i++) {
                this._poolCard[i].node.setLocalZOrder(i-5);
            }
            for (let i: number = 5; i < 10; i++) {
                this._poolCard[i].node.setLocalZOrder(29-i);
            }
            for (let i: number = 0; i < 5; i++) {
                this._poolCard[i].node.setLocalZOrder(15 + i);
            }
        }
    }

    // private resetZ():void{
    //     if(this._poolCard.length<=5){
    //         for(let i: number = 0;i < this._poolCard.length;i++){
    //             this._poolCard[i].node.setLocalZOrder(i);
    //         }
    //     }else if(this._poolCard.length<=10){
    //         for(let i: number = 0;i < 5;i++){
    //             this._poolCard[i].node.setLocalZOrder(i);
    //         }
    //         for(let i: number = 5;i < this._poolCard.length;i++){
    //             this._poolCard[i].node.setLocalZOrder(this._poolCard.length-i+5);
    //         }
    //     }else if(this._poolCard.length<=15){
    //         let x=this._poolCard.length-10;
    //         for(let i: number = 10;i < this._poolCard.length;i++){
    //             this._poolCard[i].node.setLocalZOrder(i-10);
    //         }
    //         for(let i: number = 0;i < 5;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+x);
    //         }
    //         for(let i: number = 5;i < 10;i++){
    //             this._poolCard[i].node.setLocalZOrder(10-i+x);
    //         }
            
    //     }else if(this._poolCard.length<=20){
    //         for(let i: number = 15;i < this._poolCard.length;i++){
    //             this._poolCard[i].node.setLocalZOrder(this._poolCard.length-i);
    //         }
    //         for(let i: number = 10;i < 15;i++){
    //             this._poolCard[i].node.setLocalZOrder(i-10);
    //         }
    //         for(let i: number = 5;i < 10;i++){
    //             this._poolCard[i].node.setLocalZOrder(this._poolCard.length-i);
    //         }
    //         for(let i: number = 0;i < 5;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+10);
    //         }
    //     }
    //     else if(this._poolCard.length<=25){
    //         let x=this._poolCard.length-20;
    //         for(let i: number = 20;i < this._poolCard.length;i++){
    //             this._poolCard[i].node.setLocalZOrder(i-20);
    //         }
    //         for(let i: number = 0;i < 5;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+x);
    //         }
    //         for(let i: number = 5;i < 10;i++){
    //             this._poolCard[i].node.setLocalZOrder(20-i+x);
    //         }

    //         for(let i: number = 10;i < 15;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+x-10);
    //         }
    //         for(let i: number = 15;i < 20;i++){
    //             this._poolCard[i].node.setLocalZOrder(20-i+x-10);
    //         }
            
    //     }else{
    //         for(let i: number = 25;i < this._poolCard.length;i++){
    //             this._poolCard[i].node.setLocalZOrder(this._poolCard.length-i);
    //         }
    //         for(let i: number = 20;i < 25;i++){
    //             this._poolCard[i].node.setLocalZOrder(i-20);
    //         }
    //         for(let i: number = 15;i < 20;i++){
    //             this._poolCard[i].node.setLocalZOrder(this._poolCard.length-i);
    //         }
    //         for(let i: number = 10;i < 15;i++){
    //             this._poolCard[i].node.setLocalZOrder(i);
    //         }
    //         for(let i: number = 5;i < 10;i++){
    //             this._poolCard[i].node.setLocalZOrder(this._poolCard.length-i);
    //         }
    //         for(let i: number = 0;i < 5;i++){
    //             this._poolCard[i].node.setLocalZOrder(i+20);
    //         }
            
    //     }
    // }
}
