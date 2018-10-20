import HQMJ_CardBase from "../single/HQMJ_CardBase";
import HQMJ_SinglePoolBase from "../single/HQMJ_SinglePoolBase";
import M_HQMJClass from "../../M_HQMJClass";
import { HQMJ } from "../../ConstDef/HQMJMahjongDef";
import M_HQMJVideoClass from "../../M_HQMJVideoClass";

const { ccclass, property } = cc._decorator;

@ccclass
export default class HQMJ_PoolBase extends HQMJ_CardBase {

    @property(cc.Prefab)
    PoolType: cc.Prefab=null;

    onLoad() {
        // init logic
        
    }

    //牌池数据
    protected _poolCard:Array<HQMJ_SinglePoolBase>;
    //牌阵数据
    protected _cardAry:Array<number>;
    /**
     * 逻辑椅子号
     * */
    protected _logicChair:number;
    
    public init(logicChair: number) {
        this._logicChair= logicChair;
        this._poolCard = new Array<HQMJ_SinglePoolBase>(0);
        this._cardAry = new Array<number>(0);
    }
    
    /**
     * 添加一个牌池牌
     * */
    public addPoolCard(card:number):{x:number,y:number}{
        let _hqmj = HQMJ.ins.iclass;
        if(!HQMJ.ins.iclass)
            // _hqmj = HQMJ.ins.iclass;
        // else
            _hqmj = M_HQMJVideoClass.ins;
        let newnode = _hqmj.getFreePool(this._logicChair).get();
        if (!cc.isValid(newnode)) {
            newnode = cc.instantiate(this.PoolType);
        }
        // var newnode=cc.instantiate(this.PoolType);
        var pool = newnode.getComponent<HQMJ_SinglePoolBase>(HQMJ_SinglePoolBase);
        pool.init();
        this.node.addChild(newnode);
        this._poolCard.push(pool);
        //pool.showCard(card);
        this._cardAry.push(card);
        
        // var poolCard : SinglePoolBase = this.createSinglePoolCard();
        // this._poolCard.push(poolCard);
        
        // this.addChild(poolCard);
        return this.refreshPoolCard(_hqmj);
    }
    /**
     * 删除最后一个牌池牌
     * */
    public delLastPoolCard(card:number,leftnum:number):{x:number,y:number}{
        if(leftnum!=this._cardAry.length-1)
        {return;}

        if(card!= this._cardAry[leftnum])
        {return;}
        let _hqmj = null;
        if(HQMJ.ins.iclass)
            _hqmj = HQMJ.ins.iclass;
        else
            _hqmj = M_HQMJVideoClass.ins;
        this._cardAry.pop();
        // this._poolCard.pop().node.destroy();
        _hqmj.getFreePool(this._logicChair).put(this._poolCard.pop().node);
        return this.refreshPoolCard();
    }
    /**
     * 恢复牌池
     * */
    public recoveryPoolCard(cardAry:Array<number>):void{
        let _hqmj = null;
        if(HQMJ.ins.iclass)
            _hqmj = HQMJ.ins.iclass;
        else
            _hqmj = M_HQMJVideoClass.ins;
        if((null != cardAry) && (cardAry.length > 0)){
            for(var i:number=0; i<cardAry.length; i++){
                
                this._cardAry.push(cardAry[i]);
                _hqmj.RecordCard.outACard(cardAry[i]);
                let newnode = HQMJ.ins.iclass.getFreePool(this._logicChair).get();
                if (!cc.isValid(newnode)) {
                    newnode = cc.instantiate(this.PoolType);
                }
                // var newnode=cc.instantiate(this.PoolType);
                var pool = newnode.getComponent<HQMJ_SinglePoolBase>(HQMJ_SinglePoolBase);
                pool.init();
                this.node.addChild(newnode);
                this._poolCard.push(pool);
            }
            
            this.refreshPoolCard();
        }
    }
    
    /**
     * 刷新牌池牌
     * */
    protected refreshPoolCard(): {x:number,y:number} {
        return {x:0,y:0};
    }
    /**
     * 
     * @param card 刷新当前牌的牌池位置
     */
    public refreshHideCard(card:number):void{
        if(cc.isValid(this._poolCard)){
            for(let i=0;i<this._poolCard.length;i++){
                this._poolCard[i].showHide(card);
            }
        }
    }

    public HideLastCard(): {x:number,y:number}{
        if(this._poolCard.length < 1) {
            return {x:0,y:0};
        }
        let lastIdx=this._poolCard.length - 1;
        let rx: number = this._poolCard[lastIdx].node.x ;
        let ry: number = this._poolCard[lastIdx].node.y+ this._poolCard[lastIdx].size.height / 2;
        this._poolCard[lastIdx].node.active=false;
        return { x: rx,y: ry };
    }

    public ShowAllCard():void{
        if(cc.isValid(this._poolCard)){
            for(let i=0;i<this._poolCard.length;i++){
                this._poolCard[i].node.active=true;
            }
        }
    }
    // /**
    //  * 创建一个新的牌池牌
    //  * */
    // protected createSinglePoolCard(): SinglePoolBase {
    //     return null;
    // }
    
    /**
     * 清理
     * */
    public clear(): void {
        super.clear();
        if(this._cardAry)
            this._cardAry.splice(0,this._cardAry.length);
        if(this._poolCard)
            this._poolCard.length=0;
        while(this.node.children.length > 0) {
            // this._poolCard.pop().node.destroy();
            HQMJ.ins.iclass.getFreePool(this._logicChair).put(this.node.children[0]);
        }
    }
}
