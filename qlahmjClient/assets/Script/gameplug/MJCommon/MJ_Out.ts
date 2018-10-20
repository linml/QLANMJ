import M_HQMJClass from '../M_HQMJ/M_HQMJClass';
import M_HQMJView from '../M_HQMJ/M_HQMJView';
import HQMJ_SettingView from '../M_HQMJ/SkinView/HQMJ_SettingView';
import M_HQMJVideoClass from '../M_HQMJ/M_HQMJVideoClass';

const { ccclass, property } = cc._decorator;

@ccclass
export default class MJ_Cheating extends cc.Component {

    @property(cc.Sprite)
    mj_bg:cc.Sprite = null;

    @property(cc.Sprite)
    mj_pai:cc.Sprite = null;

    @property(cc.Sprite)
    mj_hua:cc.Sprite = null;
    
    onLoad() {
        
    }
    private UserDataPos: Array<{ x: number,y: number }> = [
            { x: 10,y: -80 },
            { x: 350,y: 80 },
            { x: 20,y: 200},
            { x: -330,y: 20 }
        ];

    public showOutPai(chair,outPai,isVideo:boolean = false){

        let _HQMJ:any = null;
        if(isVideo)
            _HQMJ = M_HQMJVideoClass.ins;
        else
            _HQMJ = M_HQMJClass.ins;
        this.mj_pai.spriteFrame=_HQMJ.getMahjong3DPaiBeiRes("hand_self_1");            
        this.mj_hua.spriteFrame=_HQMJ.getMahjongPaiHuaRes(outPai);
        
        var logicChair: number =_HQMJ.physical2logicChair(chair);

        this.mj_pai.node.x = this.UserDataPos[logicChair].x;
        this.mj_pai.node.y = this.UserDataPos[logicChair].y;

        this.node.active = true;

        setTimeout(function(){
            this.node.active=false;
        }.bind(this),800);
    }

}
