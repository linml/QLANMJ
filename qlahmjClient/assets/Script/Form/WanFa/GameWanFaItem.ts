import UIBase from "../Base/UIBase";
import GameWanfaDescItem from "./GameWanfaDescItem";

const {ccclass, property} = cc._decorator;

@ccclass
export default class GameWanFaItem extends cc.Component {
	/**
	 * 玩法描述预制体
	 */
	@property(cc.Prefab)
	descPrefab: cc.Prefab = null;

	@property(cc.Layout)
	layout: cc.Layout = null;

	/**
	 * 显示玩法字段 (一行只显示三个)
	 */
    public createRuleShow(rule: any) {
    	if (!rule) {
    		return;
    	}
    	
    	for (var idx = 0; idx < rule.length; ++idx) {
    		let descItem = cc.instantiate(this.descPrefab);
    		let compoment = descItem.getComponent(GameWanfaDescItem)
    		compoment.initShow(rule[idx]);
    		this.layout.node.addChild(descItem);
    	}
    }
}
