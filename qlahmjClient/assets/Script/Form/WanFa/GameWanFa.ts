import UIBase from "../Base/UIBase";
import { Action } from "../../CustomType/Action";
import CreateRoomDataCache from "../CreateRoom/CreateRoomDataCache";
import GameWanFaItem from "./GameWanFaItem";

const {ccclass, property} = cc._decorator;

@ccclass
export default class GameWanFa extends UIBase<any> {
	public IsEventHandler: boolean = true;
    public IsKeyHandler: boolean = true;

    @property(cc.Layout)
	layout: cc.Layout = null;

	@property(cc.Prefab)
	wanfaItemPrefab: cc.Prefab = null;

    public InitShow() {
    	if (!this.ShowParam) {
    		return;
    	}

    	let act = new Action(this,this.showRule);
    	CreateRoomDataCache.Instance.getRuleDesc(this.ShowParam.modelName,this.ShowParam.rule,act);
    }

    public showRule(obj: any){
    	if (!obj || !this.layout || !this.wanfaItemPrefab) {
    		return;
    	}

    	this.layout.node.removeAllChildren();

    	let array = new Array<any>();
    	let keys = Object.keys(obj);
    	/**
         * 排序 
         * 房费和局数排在最前面
         */
        let idx1 = keys.indexOf('房费');
        let idx2 = keys.indexOf('局数');

        if (-1 != idx1 && -1 != idx2) {
            keys.splice(idx1,1);
            keys.splice(idx2,1);
            keys = ['局数','房费'].concat(keys);
        }

    	for (let idx = 0; idx < keys.length; ++idx) {
    		let isCreateItem = false;

    		// 进行分组一组两个
    		if (0 != (idx+1) % 2) {
    			array.push({name: keys[idx],value: obj[keys[idx]]});

    			if (idx + 1 >= keys.length) {
    				isCreateItem = true;
    			}
    		}else{
    			array.push({name: keys[idx],value: obj[keys[idx]]});
    			isCreateItem = true;    			
    		}

    		if (isCreateItem) {
    			let prefab = cc.instantiate(this.wanfaItemPrefab);
    			let item: GameWanFaItem = prefab.getComponent(GameWanFaItem);
    			item.createRuleShow(array);
    			this.layout.node.addChild(prefab);

    			// 清空数组
    			array = [];
    		}
    	}
    }
}
