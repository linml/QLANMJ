

const { ccclass, property } = cc._decorator;

@ccclass
export default class HuDong_Animation extends cc.Component {

    @property([cc.Node])
    daoju: cc.Node[] = [];
    @property([cc.Animation])
    daoju_mingzhong: cc.Animation[] = [];
    @property([cc.Animation])
    daoju_feixing: cc.Animation[] = [];
    onLoad() {
        for (let i = 0; i < this.daoju_mingzhong.length; i++) {
            this.daoju_mingzhong[i].on("finished", () => { this.AniItemFinish(i) }, this.daoju_mingzhong[i]);
        }
    }
    public showChatItem(idx: number, point: cc.Vec2, point2: cc.Vec2) {
        this.daoju[idx].x = point.x;
        this.daoju[idx].y = point.y;
        var action = cc.sequence(cc.moveTo(1, point2.x, point2.y), cc.callFunc(this.AniChatItemOver, this, idx));
        this.daoju_feixing[idx].node.active = true;
        this.daoju_feixing[idx].play();
        this.daoju[idx].runAction(action);
    }
    private AniChatItemOver(target: any, idx: number) {
        this.daoju_feixing[idx].node.active = false;
        this.daoju_feixing[idx].stop();
        this.daoju_mingzhong[idx].node.active = true;
        this.daoju_mingzhong[idx].play();
    }
    private AniItemFinish(idx: number) {
        this.daoju_mingzhong[idx].stop();
        this.daoju_mingzhong[idx].node.active = false;
    }
}