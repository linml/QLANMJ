import LHZMJ_FixedBase from "./LHZMJ_FixedBase";
import { LHZMJ } from "../../ConstDef/LHZMJMahjongDef";

const { ccclass, property } = cc._decorator;

@ccclass
export default class LHZMJ_OppoFixed extends LHZMJ_FixedBase {

    onLoad() {
        // init logic
        super.onLoad();
        this.init(2);
    }

    /**
     * 刷新定牌
     * */
    protected refreshFixedCard(): void {
        // if(this._fixedData.length > 0) {
        //     for(var i: number = 0;i < this._fixedData.length;i++) {
        //         this._fixedData[i].node.x = 284 - i*130-40;//830
        //         this._fixedData[i].node.y = 284;
        //     }
        // }
        if(this._fixedData.length > 0){
            if(LHZMJ.ins.iclass.is2D()){
                for(let i: number = 0;i < this._fixedData.length;i++) {
                this._fixedData[i].node.x = 284 - i*130-40;//830
                this._fixedData[i].node.y = 284;
            }
            }else{
                // for(let i:number=0; i<this._fixedData.length; i++){
                //     this._fixedData[i].node.x = 290 - i*140;
                //     this._fixedData[i].node.y = 285;
                // }
            }
            
        }
    }
}
