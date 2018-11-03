import UIBase from "../Base/UIBase";
import UiManager from '../../Manager/UiManager';
import { UIName } from "../../Global/UIName";

const { ccclass, property } = cc._decorator;

@ccclass
export default class HornPanel extends UIBase<any> {
    public IsEventHandler: boolean;
    public IsKeyHandler: boolean;

    private inteval = 10; //跑马灯总时间

    /**
     * 用于存放大厅跑马灯数据
     */
    public static HornHallList: Array<string> = [];

    /**
     * 用于存放游戏跑马灯数据
     */
    public static HornGameList: Array<string> = [];

    @property(cc.Sprite)
    private horn_img: cc.Sprite = null;

    @property(cc.RichText)
    private horn_text: cc.RichText = null;

    private horn_type = 0;

    private play_type = ""; //播放的跑马灯类型

    public isHallPlayHorn = false; //是否正在播放大厅跑马灯

    public isGamePlayHorn = false; //是否正在播放大厅跑马灯

    public init_location = -500;

    // LIFE-CYCLE CALLBACKS:

    // onLoad () {}

    // start() {
    //     this.Init();
    // }

    InitShow() {
        if (this.isHallPlayHorn) {
            return;
        }

        if (this.isGamePlayHorn) {
            return;
        }

        let obj = this.ShowParam;
        if (obj) {
            this.horn_type = obj.horn_type;
            this.play_type = obj.play_type;
            // this.horn_img.spriteFrame = obj.spriteFrame;
            this.Init();
        }
    }

    Init() {
        if (this.play_type == "Hall") {
            this.PlayHallHorn();
        }
    }

    PlayHallHorn() {
        var self = this;

        this.isHallPlayHorn == true; //开始播放

        let HornHallList = HornPanel.HornHallList;
        if (HornHallList.length > 0) {
            this.horn_text.string = HornHallList[HornHallList.length - 1]; //赋值最新跑马灯内容
            cc.log(HornHallList[HornHallList.length - 1]);

 
            this.horn_text.node.position = cc.v2(this.init_location, 1); //初始化位置
            if (this.horn_type != 1) {
                HornPanel.HornHallList = [];
            }

            /**
             * 开始播放操作
             */
            this.horn_text.node.runAction(cc.sequence(
                cc.moveTo((this.node.width + this.horn_text.node.width) / 100,
                    cc.v2(this.init_location - (this.node.width + this.horn_text.node.width), 0)),
                cc.callFunc(function () { //说明移动完了
                    self.EndHorn(); //播放完执行函数
                })
            ));

        } else {
            this.isHallPlayHorn = false;
            cc.log("没有可播放的内容");
            return;
        }
    }

    EndHorn() {
        let HornHallList = HornPanel.HornHallList;
        if (HornHallList.length > 0 || this.horn_type == 1) {
            this.Init();
            return;
        }

        this.isHallPlayHorn == false;
        this.UiManager.DestroyUi(UIName.HornPanel);
    }

    // update (dt) {}
}
