import UIBase from "../../Base/UIBase";
import FriendCircleDataCache from "../FriendCircleDataCache";

const {ccclass, property} = cc._decorator;

@ccclass
export default class FightRecordUI extends UIBase<any> {
	public IsEventHandler: boolean = true
    public IsKeyHandler: boolean = true;

    /**
     * 今日积分按钮标签文字
     */
    @property([cc.Label])
    lab_score: cc.Label[] = [];

    /**
     * 日期切换标签
     */
    @property([cc.Button])
    btn_tab_date: cc.Button[] = [];


    /**
     * 日期标签按钮选中状态图标
     */
    @property(cc.Sprite)
    sp_tabDateSelected: cc.Sprite = null;

    /**
     * 战绩切换标签
     */
    @property([cc.Button])
    btn_tab_record: cc.Button[] = [];

    /**
     * 战绩标签选中状态图标
     */
    @property(cc.Sprite)
    sp_tabRecordSelected: cc.Sprite = null;

    public get isPlayPopAction(): boolean { return false; }

    /**
     * 当前选择标签索引
     */
    private _curSelectTabIdx: number = 0;

    public InitShow() {

        // 默认显示第一个
        this.tabDataChangeLogic('0');
    }

    /**
     * 标签点击事件处理
     */
    public tabClickHandle(event,args) {
    	this.tabDataChangeLogic(args);
    }


    /**
     * 日期标签切换逻辑
     */
    public tabDataChangeLogic(tabTag: string) {
        let tag = parseInt(tabTag);

        if (tag < 0) {
            return;
        }

       
        // 更新文字颜色表示
        if (this.lab_score[this._curSelectTabIdx]) {
            this.lab_score[this._curSelectTabIdx].node.color = cc.hexToColor("#FFFFFF");
            this.lab_score[this._curSelectTabIdx].node.getComponent('cc.LabelOutline').enabled = false;
        }

        this._curSelectTabIdx = tag;

        // 更新当前选中按钮状态位置
        if (cc.isValid(this.btn_tab_date[this._curSelectTabIdx])) {
            this.sp_tabDateSelected.node.y = this.btn_tab_date[this._curSelectTabIdx].node.y;
        }

        // 更新文字颜色表示
        if (this.lab_score[tag]) {
            this.lab_score[tag].node.color = cc.hexToColor("#783000");
            this.lab_score[tag].node.getComponent('cc.LabelOutline').enabled = true;
        }
    }

    /**
     * 战绩标签切换逻辑
     */
    public tabRecordChangeLogic(tabTag: string) {
        let tag = parseInt(tabTag);

        if (tag < 0) {
            return;
        }

       
        // 更新文字颜色表示
        if (this.lab_score[this._curSelectTabIdx]) {
            this.lab_score[this._curSelectTabIdx].node.color = cc.hexToColor("#FFFFFF");
            this.lab_score[this._curSelectTabIdx].node.getComponent('cc.LabelOutline').enabled = false;
        }

        this._curSelectTabIdx = tag;

        // 更新当前选中按钮状态位置
        if (cc.isValid(this.btn_tab_date[this._curSelectTabIdx])) {
            this.sp_tabDateSelected.node.y = this.btn_tab_date[this._curSelectTabIdx].node.y;
        }

        // 更新文字颜色表示
        if (this.lab_score[tag]) {
            this.lab_score[tag].node.color = cc.hexToColor("#783000");
            this.lab_score[tag].node.getComponent('cc.LabelOutline').enabled = true;
        }
    }
}
