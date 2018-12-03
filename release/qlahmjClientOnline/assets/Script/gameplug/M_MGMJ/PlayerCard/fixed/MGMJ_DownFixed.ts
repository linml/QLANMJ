import MGMJ_FixedBase from "./MGMJ_FixedBase";
import { MGMJ } from "../../ConstDef/MGMJMahjongDef";

const { ccclass, property } = cc._decorator;

@ccclass
export default class MGMJ_DownFixed extends MGMJ_FixedBase {


    onLoad() {
        // init logic
        super.onLoad();
        this.init(1);
    }

    /**
     * 刷新定牌
     * */
    protected refreshFixedCard(): void {
        // if(this._fixedData.length > 0) {
        //     for(var i: number = 0;i < this._fixedData.length;i++) {
        //         this._fixedData[i].node.x = 490;
        //         this._fixedData[i].node.y = -150 + i*113-20;
        //     }
        // }
        if(this._fixedData.length > 0){
            if(MGMJ.ins.iclass.is2D()){
                for(let i: number = 0;i < this._fixedData.length;i++) {
                    this._fixedData[i].node.setLocalZOrder(this._fixedData.length-i);
                    this._fixedData[i].node.x = 490;
                    this._fixedData[i].node.y = -150 + i*113-20;
                }
            }else{
                for(let i: number = 0;i < this._fixedData.length;i++) {
                    this._fixedData[i].node.setLocalZOrder(this._fixedData.length-i);
                    // this._fixedData[i].node.x = 480;
                    // this._fixedData[i].node.y = -140 + i*115;
                }
            }
            
        }
    }
}
