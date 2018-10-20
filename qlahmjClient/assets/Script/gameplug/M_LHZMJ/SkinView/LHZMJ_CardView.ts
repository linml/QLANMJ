import LHZMJ_ActiveBase from "../PlayerCard/active/LHZMJ_ActiveBase";
import { LHZMJ, LHZMJMahjongDef, enFixedCardType } from "../ConstDef/LHZMJMahjongDef";
import LHZMJEvent from "../LHZMJEvent";

import LHZMJ_FixedBase from "../PlayerCard/fixed/LHZMJ_FixedBase";
import LHZMJ_PoolBase from "../PlayerCard/pool/LHZMJ_PoolBase";
import LHZMJ_FlowerBase from "../PlayerCard/flower/LHZMJ_FlowerBase";
import LHZMJ_HunPi from "../PlayerCard/single/hunpi/LHZMJ_HunPi";
import LHZMJ_SinglePoolBase from "../PlayerCard/single/LHZMJ_SinglePoolBase";
import M_LHZMJView from "../M_LHZMJView";
const { ccclass, property } = cc._decorator;

@ccclass
export default class LHZMJ_CardView extends cc.Component {

    @property([LHZMJ_ActiveBase])
    activeCard:LHZMJ_ActiveBase[]=[];

    @property([LHZMJ_FixedBase])
    fixedCard:LHZMJ_FixedBase[]=[];

    @property([LHZMJ_PoolBase])
    poolCard:LHZMJ_PoolBase[]=[];

    @property([LHZMJ_FlowerBase])
    flowerCard:LHZMJ_FlowerBase[]=[];

    @property([LHZMJ_HunPi])
    private hunpiCard:LHZMJ_HunPi[]=[];

    @property(cc.Node)
    bg_poolCardArrow:cc.Node=null;
    @property(cc.Animation)
    img_poolCardArrow:cc.Animation=null;
    
    onLoad() {
        // init logic
        //this.init();
    }

    public static _freeActiveNode: Array<cc.NodePool> = [new cc.NodePool(),new cc.NodePool(),new cc.NodePool(),new cc.NodePool()];
    // public static _freeDownActiveNode= new cc.NodePool();
    // public static _freeOppoActiveNode= new cc.NodePool();
    // public static _freeUpActiveNode= new cc.NodePool();
    //Fixed
    public static _freeFixedNode: Array<cc.NodePool> = [new cc.NodePool(),new cc.NodePool(),new cc.NodePool(),new cc.NodePool()];
    // public static _freeDownFixedNode= new cc.NodePool();
    // public static _freeOppoFixedNode= new cc.NodePool();
    // public static _freeUpFixedNode= new cc.NodePool();
    //Pool
    public static _freePoolNode: Array<cc.NodePool> = [new cc.NodePool(),new cc.NodePool(),new cc.NodePool(),new cc.NodePool()];
    // public static _freeDownPoolNode= new cc.NodePool();
    // public static _freeOppoPoolNode= new cc.NodePool();
    // public static _freeUpPoolNode= new cc.NodePool();
     public static _freeFlowerNode:Array<cc.NodePool>=[new cc.NodePool(),new cc.NodePool(),new cc.NodePool(),new cc.NodePool()];

    //===================================================================
    //

    // //定牌
    // private _fixedCard:Array<LHZMJ_FixedBase>;
    // //牌池牌
    // private _poolCard:Array<LHZMJ_PoolBase>;
    
    public init() {
        this.clear();
        this.node.active=true;
        
        //this._activeCard = new Array<LHZMJ_ActiveBase>();
        // this._fixedCard = new Array<LHZMJ_FixedBase>();
        // this._poolCard = new Array<LHZMJ_PoolBase>();

        // if(this._activeCard.length > 0){
        //     return;
        // }
        
        // //下家处理
        // var pool_down : LHZMJ_DownPool = new LHZMJ_DownPool();
        // var fixed_down : LHZMJ_DownFixed = new LHZMJ_DownFixed();
        // var donwActiveCls : any = egret.getDefinitionByName(LHZMJ.ins.iclass.getActiveCardClassName()[1]);
        // var active_down: LHZMJ_ActiveBase = new donwActiveCls();
        
        // this._group_down.addChild(pool_down);
        // this._group_down.addChild(fixed_down);
        // this._group_down.addChild(active_down);
        
        // //对家处理
        // var pool_oppo : LHZMJ_OppoPool = new LHZMJ_OppoPool();
        // var fixed_oppo: LHZMJ_OppoFixed = new LHZMJ_OppoFixed();
        // var oppoActiveCls : any = egret.getDefinitionByName(LHZMJ.ins.iclass.getActiveCardClassName()[2]);
        // var active_oppo: LHZMJ_ActiveBase = new oppoActiveCls();
        
        
        // this._group_oppo.addChild(pool_oppo);
        // this._group_oppo.addChild(fixed_oppo);
        // this._group_oppo.addChild(active_oppo);
        
        // //上家处理
        // var pool_up : LHZMJ_UpPool = new LHZMJ_UpPool();
        // var upActiveCls: any = egret.getDefinitionByName(LHZMJ.ins.iclass.getActiveCardClassName()[3]);
        // var acitve_up: LHZMJ_ActiveBase = new upActiveCls();
        // var fixed_up : LHZMJ_UpFixed = new LHZMJ_UpFixed();
        
        // this._group_up.addChild(pool_up);
        // this._group_up.addChild(fixed_up);
        // this._group_up.addChild(acitve_up);
        
        // //自家处理
        // var pool_self: LHZMJ_SelfPool = new LHZMJ_SelfPool();
        // var fixed_self : LHZMJ_SelfFixed = new LHZMJ_SelfFixed();
        // var selfActiveCls : any = egret.getDefinitionByName(LHZMJ.ins.iclass.getActiveCardClassName()[0]);
        // var active_self: LHZMJ_ActiveBase = new selfActiveCls();
        
        //this.activeCard[0].node.on(LHZMJEvent.LHZMJ_EVENT_TYPE,this.onSelfActiveEvent,this);
        
        // this._group_self.addChild(pool_self);
        // this._group_self.addChild(fixed_self);
        // this._group_self.addChild(active_self);
        
        // this._activeCard.push(active_self);
        // this._activeCard.push(active_down);
        // this._activeCard.push(active_oppo);
        // this._activeCard.push(acitve_up);
        
        // this._fixedCard.push(fixed_self);
        // this._fixedCard.push(fixed_down);
        // this._fixedCard.push(fixed_oppo);
        // this._fixedCard.push(fixed_up);
        
        // this._poolCard.push(pool_self);
        // this._poolCard.push(pool_down);
        // this._poolCard.push(pool_oppo);
        // this._poolCard.push(pool_up);
    }
    
    /**
     * 自己活动牌阵
     * */
    public get selfActive():LHZMJ_ActiveBase{
        return this.activeCard[0];
    }
    /**
     * 自己的定牌阵
     * */
    public get selfFixed():LHZMJ_FixedBase{
        return this.fixedCard[0];
    }
    /**
     * 自己的牌池
     * */
    public get selfPool():LHZMJ_PoolBase{
        return this.poolCard[0];
    }
    /**
     * 自己的花牌
     */
    public get selfFlower():LHZMJ_FlowerBase{
        return this.flowerCard[0];
    }
    /**
     * 获取混皮牌
     */
    public get hunPi():LHZMJ_HunPi{
        return this.hunpiCard[0];
    }
    /**
     * 获取活动牌阵
     * */
    public getActive(chair:number): LHZMJ_ActiveBase{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);
        return this.activeCard[logicChair];
    }
    /**
     * 获取定牌阵
     * */
    public getFixed(chair: number):LHZMJ_FixedBase{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);
        return this.fixedCard[logicChair];
    }
    /**
     * 获取牌池
     * */
    public getPool(chair: number):LHZMJ_PoolBase{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);
        return this.poolCard[logicChair];
    }
    /**
     * 隐藏出牌箭头
     * */
    public hideOutCardArrow():void{
      
        //this.unschedule(this.ArrowRun);
         if(cc.isValid(this.img_poolCardArrow)){
            this.img_poolCardArrow.stop();
        }
        
        // this.img_poolCardArrow.node.active = false;
        this.bg_poolCardArrow.active = false;
    }
    /**
     * 获取花牌
     * @param chair 
     */
    public getFlower(chair:number):LHZMJ_FlowerBase{
        var logicChair:number=LHZMJ.ins.iclass.physical2logicChair(chair);
        console.log(`物理椅子号：${chair}`);
        console.log(`逻辑椅子号：${logicChair}`);
        console.log(`花牌列表长度：${this.flowerCard.length}`);
        return this.flowerCard[logicChair];
    }
    /**
     * 玩家补花
     * @param chair 
     * @param card 
     */
    public playerBuHua(chair:number,card:number):void{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);
        this.activeCard[logicChair].outACard(card);
    }
    
    /**
     * 将花牌添加到花牌里面
     * @param chair 
     * @param card 
     */
    public addCard2Flower(card:number,chair:number):void{
        if((LHZMJMahjongDef.gInvalidChar == chair) || (LHZMJMahjongDef.gInvalidMahjongValue == card)){
            return;
        }
        
        this.getFlower(chair).addFlowerCard(card);
    }
    /**
     * 将牌添加到牌池中
     * */
    public addCard2Pool(chair:number,card:number):void{
        if((LHZMJMahjongDef.gInvalidChar == chair) || (LHZMJMahjongDef.gInvalidMahjongValue == card)){
            return;
        }
        
        
        
        var arrowPos : {x:number,y:number} = this.getPool(chair).addPoolCard(card);
        
        this.bg_poolCardArrow.x=arrowPos.x;
        this.bg_poolCardArrow.y=arrowPos.y;
        
        // this.img_poolCardArrow.node.stopAllActions();
        // let aciton= cc.repeatForever(cc.sequence(cc.moveBy(0.8, cc.p(0, 10)), cc.moveBy(0.8, cc.p(0, -10))));
        // //egret.Tween.get(this._img_poolCardArrow,{ loop: true }).to({ y: this.img_poolCardArrow.y - 10 },800).to({ y: this.img_poolCardArrow.y },800);
        // this.img_poolCardArrow.node.runAction(aciton);
       // this.schedule(this.ArrowRun,1.05);
       // this.img_poolCardArrow.node.active = true;
        this.RunArrow();
    }

    private ArrowRun():void{
       if(cc.isValid(this.img_poolCardArrow)){
            this.img_poolCardArrow.play();
        }
    }
    public RunArrow():void{
         // this.schedule(this.ArrowRun,1.05);
         this.bg_poolCardArrow.active = true;
        this.ArrowRun();
    }
    /**
     * 将牌池的最后一张牌删除
     */
    public delCardinPool(chair:number,card:number,leftnum:number){

        if((LHZMJMahjongDef.gInvalidChar == chair) || (LHZMJMahjongDef.gInvalidMahjongValue == card)){
            return;
        }
       // this.unschedule(this.ArrowRun);
         if(cc.isValid(this.img_poolCardArrow)){
            this.img_poolCardArrow.stop();
        }
        // this.img_poolCardArrow.node.active = false;
        this.bg_poolCardArrow.active = false;
        this.getPool(chair).delLastPoolCard(card,leftnum);            
    }
    /**
     * 恢复玩家活动牌
     * */
    public recoveryActiveCard(chair:number,cardAry:Array<number>):void{
        
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);
        //更新活动牌阵中定牌数量
        this.activeCard[logicChair].fixedCardNum = this.fixedCard[logicChair].fixedCardNum;
        //刷新手牌阵
        this.activeCard[logicChair].refreshHandCardData(cardAry);
    }


    /**
     * 恢复花牌
     * @param chair 
     * @param cardAry 
     */
    public recoveryFlowerCard(chair:number,cardAry:Array<number>):void{
        //var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);

        this.getFlower(chair).recoveryFlowerCard(cardAry);
    }
    
    /**
     * 活动牌事件
     * */
    // private onSelfActiveEvent(e:LHZMJEvent):void{
    //     switch(e.msgCode){
    //         default:{
    //             //this.node.dispatchEvent(e.clone());
    //             break;
    //         }
    //     }
    // }
    
    /**
     * 抓牌墩牌
     * */
    public holdTricksCard(chair:number,holdIdx:number):number{
        var logicChair : number = LHZMJ.ins.iclass.physical2logicChair(chair);
        return this.activeCard[logicChair].holdTricksCard(holdIdx);
    }
    
    /**
     * 玩家抓牌
     * */
    public playerHoldCard(chair:number,card:number):void{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);
        this.activeCard[logicChair].holdACard(card);
    }
    
    /**
     * 玩家打牌
     * */
    public playerOutCard(chair:number,card:number):void{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);
        this.activeCard[logicChair].outACard(card);
    }
    /**
     * 
     * @param card 
     */
    public refreshHideCard(card:number):void{
        for(var j:number=0; j<this.fixedCard.length; j++){
            this.fixedCard[j].refreshHideCard(card);
        }
        for(var m:number=0; m<this.poolCard.length; m++){
            this.poolCard[m].refreshHideCard(card);
        }
    }
    /**
     * 玩家碰牌
     * */
    public playerPeng(chair: number,card: number,outChair:number):void{
        
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);
        
        let pos=(outChair+LHZMJMahjongDef.gPlayerNum-chair)%LHZMJMahjongDef.gPlayerNum;
        //处理定牌
        this.fixedCard[logicChair].addFixed(card,enFixedCardType.FixedCardType_Peng,pos);
        
        //更新活动牌阵中定牌数量
        this.activeCard[logicChair].fixedCardNum = this.fixedCard[logicChair].fixedCardNum;
        
        //更新活动牌
        this.activeCard[logicChair].pengACard(card);
    }
    
    /**
     * 玩家暗杠
     * */
    public playerAGang(chair: number,card: number):void{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);

        //处理定牌
        this.fixedCard[logicChair].addFixed(card,enFixedCardType.FixedCardType_AGang,0);

        //更新活动牌阵中定牌数量
        this.activeCard[logicChair].fixedCardNum = this.fixedCard[logicChair].fixedCardNum;

        //更新活动牌
        this.activeCard[logicChair].AGangACard(card);
    }
    
    /**
     * 玩家明杠
     * */
    public playerMGang(chair: number,card: number,outChair:number):void{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);

        let pos=(outChair+LHZMJMahjongDef.gPlayerNum-chair)%LHZMJMahjongDef.gPlayerNum;
        //处理定牌
        this.fixedCard[logicChair].addFixed(card,enFixedCardType.FixedCardType_MGang,pos);

        //更新活动牌阵中定牌数量
        this.activeCard[logicChair].fixedCardNum = this.fixedCard[logicChair].fixedCardNum;

        //更新活动牌
        this.activeCard[logicChair].MGangACard(card);
    }
    
    /**
     * 玩家补杠
     * */
    public playerBGang(chair: number,card: number):void{
        var logicChair: number = LHZMJ.ins.iclass.physical2logicChair(chair);

        //处理定牌
        this.fixedCard[logicChair].peng2gang(card);

        //更新活动牌
        this.activeCard[logicChair].BGangACard(card);
    }
    
    /**
     * 清理
     * */
    public clear():void{
        for(var i:number=0; i<this.activeCard.length; i++){
            this.activeCard[i].clear();
        }
        for(var j:number=0; j<this.fixedCard.length; j++){
            this.fixedCard[j].clear();
        }
        for(var m:number=0; m<this.poolCard.length; m++){
            this.poolCard[m].clear();
        }
        // for(var i:number=0;i<this.flowerCard.length;i++){
        //     this.flowerCard[i].clear();
        // }
       
        for(var i:number=0;i<this.hunpiCard.length;i++){
            this.hunpiCard[i].HideCard();
        }
      
        if(cc.isValid(this.img_poolCardArrow)){
            this.img_poolCardArrow.stop();
        }
        // this.img_poolCardArrow.node.active=false;
        this.bg_poolCardArrow.active=false;
    }
}
