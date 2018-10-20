import { SetTextureRes, SetFontRes } from "../../MJCommon/MJ_Function";
import { LHZMJ } from "../ConstDef/LHZMJMahjongDef";

import { LoadHeader } from "../../../Tools/Function";


const { ccclass, property } = cc._decorator;

@ccclass
export default class HBMJ_SinglePlayerFX extends cc.Component {

    //背景
    @property(cc.Sprite)
    img_bg: cc.Sprite=null;

    //分数显示
    @property(cc.Label)
    lbl_total: cc.Label=null;

    //玩家头像
    @property(cc.Sprite)
    img_play: cc.Sprite=null;

    //头像遮罩
    // @property(cc.Sprite)
    // img_mask: cc.Sprite;

    //玩家昵称
    @property(cc.Label)
    lbl_play: cc.Label=null;

    //其他信息
    @property(cc.Label)
    lbl_other: cc.Label=null;

    //大赢家
    @property(cc.Sprite)
    img_win: cc.Sprite=null;

    private _idx: number;

    private _total: number;

    private _isShowWin: boolean;

    private _all: number;

    private _player:string;

    onLoad() {
        // init logic
        
    }

    public init() {

    }

    public SetData(all:number,totalScore: number, showWin: boolean): void {
        this._all = all;
        
        this._total = totalScore;
        this._isShowWin = showWin;

        var url = this._total > 0 ? "gameres/gameCommonRes/Texture/Mahjong/other/MJ_fx_huangtiao" : "gameres/gameCommonRes/Texture/Mahjong/other/MJ_fx_lantiao";
        SetTextureRes(url, this.img_bg);

        this.lbl_other.string = "对局数:" + this._all + this._player;
        //this.lbl_play.string = "游客1234224";

        
        
        //this.lbl_other.string = "对局数:23343/ID:2344544";

        
       // SetTextureRes(HBMJ.ins.iclass.getTablePlayerAry()[this._idx].FaceID, this.);

        this.img_win.node.active = this._isShowWin;

        url = this._total > 0 ? "gameres/gameCommonRes/Font/Mahjong/MJshare_hongzi" : "gameres/gameCommonRes/Font/Mahjong/MJshare_lanzi";
        // SetFontRes(url, this.lbl_total);

        // this.lbl_total.string = this._total.toString();

        this.node.active = true;
    }

    public SetPlayer(playidx:number):void{
        
        this._idx = playidx;
        this.lbl_play.string = LHZMJ.ins.iclass.getTablePlayerAry()[this._idx].NickName;
        this._player="/ID:" + `${LHZMJ.ins.iclass.getTablePlayerAry()[this._idx].PlayerID}`;
        LoadHeader(LHZMJ.ins.iclass.getTablePlayerAry()[this._idx].FaceID, this.img_play);
    }
}
