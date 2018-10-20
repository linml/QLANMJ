import HQMJ_ActiveBase from "./HQMJ_ActiveBase";
import { HQMJMahjongAlgorithm } from "../../HQMJMahjongAlgorithm/HQMJMahjongAlgorithm";
import { HQMJ } from "../../ConstDef/HQMJMahjongDef";
import M_HQMJVideoClass from '../../M_HQMJVideoClass';

const { ccclass, property } = cc._decorator;

@ccclass
export default class HQMJ_VideoActiveBase extends HQMJ_ActiveBase {

    onLoad() {
        // init logic
        
    }

    public init(logicChair: number) {
        super.init(logicChair);

    }
    
    /**
     * 整理手牌
     * */
    public arrangeHandCard(): void {
        HQMJMahjongAlgorithm.sortCardAry(this._handCard);
        this.scheduleOnce(this.refreshHandCard,0.8);
    }
    
    /**
     * 抓牌墩牌
     * */
    public holdTricksCard(holdIdx: number): number {
        // var holdNum =holdIdx;// (3 == holdIdx ? 1 : 4);

        // for(var i: number = 0;i < holdNum;i++) {
        //     this._handCard.push(M_HQMJVideoClass.ins.getPlayerHandCardData(M_HQMJVideoClass.ins.logic2physicalChair(this._logicChair))[i]);//[holdIdx * 4 + i]);
        // }
        // this.handCardChange(M_HQMJVideoClass.ins);

        // return holdNum;
        return 0;
    }
    
    
    /**
     * 玩家胡牌
     * */
    public playerHu(huCard: number): void {

        var chair : number = M_HQMJVideoClass.ins.logic2physicalChair(this._logicChair);
        
        var lastCard: Array<number> = new Array<number>();
        for(var i: number = 0;i < M_HQMJVideoClass.ins.getPlayerHandCardData(chair).length;i++) {
            lastCard.push(M_HQMJVideoClass.ins.getPlayerHandCardData(chair)[i]);
        }

        if(2 == (lastCard.length % 3)) {
            lastCard.pop();
        }

        this.showLieCard(lastCard,huCard);
    }
    
}
