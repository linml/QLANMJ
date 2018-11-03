import UIBase from "../../Form/Base/UIBase";
import Dictionary from "../../CustomType/Dictionary";
import { QL_Common } from "../../CommonSrc/QL_Common";
import { LocalStorage } from "../../CustomType/LocalStorage";
import Global from "../../Global/Global";
import { Action } from "../../CustomType/Action";
import TopFormBase from "../General/TopFormBase";

const { ccclass, property } = cc._decorator;

@ccclass
export class ResumeGame extends UIBase<any> {
	public IsEventHandler: boolean = true;
    public IsKeyHandler: boolean = true;
    
    private _gameEndAct: Action = null;
    private _agreeResumeGameAct: Action = null;

    /**
     * 同意继续游戏按钮
     */

    @property(cc.Button)
    btn_agreeResum: cc.Button = null;

    public InitShow(){
        super.InitShow();
        
        if (this.btn_agreeResum) {
            this.btn_agreeResum.enabled = true;
        }

        if (this.ShowParam) {
        	this._gameEndAct = this.ShowParam.gameEndEventHandle;
        	this._agreeResumeGameAct = this.ShowParam.agreeEventHandle;
        }
    }

    /**
     * 游戏结束按钮回调事件
     */
    public btnGameEndEvent() {
    	if (this._gameEndAct) {
    		cc.info('--- player argee refuse resume game. ');
    		this._gameEndAct.Run([]);
    	}
    }

    /**
     * 同意续局按钮事件回调
     */
    public btnAgreeResumeGameEvent() {
    	if (this._agreeResumeGameAct) {
    		this._agreeResumeGameAct.Run([]);

            if (this.btn_agreeResum) {
                this.btn_agreeResum.enabled = false;
            }

            cc.info('--- player argee resume game. ');
    	}
    }

    /**
     * 更新玩家投票状态
     */
    public updatePlayerVoteStatus(chair: number, status: number) {

    }
}
