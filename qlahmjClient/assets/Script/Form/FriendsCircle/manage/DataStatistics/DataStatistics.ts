import { Action, ActionNet } from "../../../../CustomType/Action";
import { UIName } from "../../../../Global/UIName";
import Global from "../../../../Global/Global";
import FriendCircleDataCache from "../../FriendCircleDataCache";
import FriendCircleWebHandle from "../../FriendCircleWebHandle";
import ManageChildBase from "../ManageChildBase";

const {ccclass, property} = cc._decorator;

@ccclass
export default class DataStatistics extends ManageChildBase {
	/**
     * 今日耗钻
     */
    @property(cc.Label)
    lab_todayCostNum: cc.Label = null;

    /**
     * 昨日耗钻
     */
    @property(cc.Label)
    lab_yesterdayCostNum: cc.Label = null;

    /**
     * 七日耗钻
     */
    @property(cc.Label)
    lab_sevenDayCostNum: cc.Label = null;

    /**
     * 今日开房数
     */
    @property(cc.Label)
    lab_todayRoomNum: cc.Label = null;

    /**
     * 昨日开房数
     */
    @property(cc.Label)
    lab_yesterdayRoomNum: cc.Label = null;

    /**
     * 七日开房数
     */
    @property(cc.Label)
    lab_sevenDayRoomNum: cc.Label = null;

    /**
     * 初始化显示
     */
    public InitShow() {

    }
}
