import M_HQMJClass from "../M_HQMJClass";
import { TingCardTip, HQMJ } from "../ConstDef/HQMJMahjongDef";
import { SetTextureRes } from "../../MJCommon/MJ_Function";

const { ccclass, property } = cc._decorator;

/**
 * 血战麻将单个听牌提示牌
 * */
@ccclass
export default class HQMJ_SingleTingCardTip extends cc.Component {


    //牌花
    @property(cc.Sprite)
    img_cardColor: cc.Sprite=null;

    //剩余牌张数
    @property(cc.Label)
    lbl_leftCardNum: cc.Label=null;

    //番数
    // @property(cc.Label)
    // lbl_fanNum: cc.Label;
    onLoad() {
        // init logic
        
    }

    private _data: TingCardTip;

    // public HQMJ_SingleTingCardTip(){
    //     this.img_cardColor = new cc.Sprite();
    //     this.lbl_leftCardNum.string = "";
    // }

    public setData(data: TingCardTip) {
        this._data = data;
        this.setTexture();
    }

    /**
     * ui创建完成
     * */
    protected setTexture(): void {
        // cc.log("显示单个听牌！！！"); 
        // var sFrame = new cc.SpriteFrame(M_HQMJClass.ins.getMahjongResName(this._data.tingCard));
        // this.img_cardColor.spriteFrame = sFrame;

        // cc.log(`听的牌为：${this._data.tingCard}`);
        //  let url = HQMJ.ins.iclass.getMahjongResName(this._data.tingCard);
        //  SetTextureRes(url,this.img_cardColor);
        this.img_cardColor.spriteFrame=HQMJ.ins.iclass.getMahjongPaiHuaRes(this._data.tingCard);

        // load the sprite frame of (project/assets/resources/imgs/cocos.png) from resources folder
		// cc.loader.loadRes(url, cc.SpriteFrame, function (err, spriteFrame) {
		//     if (err) {
		//         cc.error(err.message || err);
		//         return;
		//     }
		//     this.img_cardColor.spriteFrame = spriteFrame;
		// });

        this.lbl_leftCardNum.string =  `${this._data.leftCardNum}`;

        // this.lbl_leftCardNum.textFlow = <Array<cc.Label.ITextElement>>[
        //     { text: this._data.leftCardNum.toString(), style: { "textColor": 0xffcc31 } },
        //     { text: "张", style: { "textColor": 0x73cf66 } }
        // ];

        // this._lbl_fanNum.textFlow = <Array<egret.ITextElement>>[
        //     { text: this._data.maxFanNum.toString(),style: { "textColor": 0xffcc31 } },
        //     { text: "嘴",style: { "textColor": 0x73cf66 } }
        // ];
    }
}
