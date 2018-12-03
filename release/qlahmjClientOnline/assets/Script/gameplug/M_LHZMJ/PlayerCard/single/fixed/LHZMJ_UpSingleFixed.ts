import LHZMJ_SingleFixedBase from "../LHZMJ_SingleFixedBase";
import { enFixedCardType, LHZMJ } from "../../../ConstDef/LHZMJMahjongDef";
import { SetTextureRes } from "../../../../MJCommon/MJ_Function";

const { ccclass, property } = cc._decorator;

@ccclass
export default class LHZMJ_UpSingleFixed extends LHZMJ_SingleFixedBase {


    onLoad() {
        // init logic
        
    }

    /**
     * 显示定牌
     * */
    public showCard(card: number,fixedType: enFixedCardType,index:number,pos:number): void {
        super.showCard(card,fixedType,index,pos);

        this.arrangeCard();
    }

    /**
     * 碰转杠
     * */
    public changePeng2Gang(card: number): boolean {
        if(super.changePeng2Gang(card)) {
            this.arrangeCard();
            return true;
        }

        return false;
    }

    /**
     * 整理牌阵
     * */
    // protected arrangeCard() {
    //     let url="";
    //     switch(this.fixedType) {
    //         case enFixedCardType.FixedCardType_AGang: {
                
    //             url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcardback_left_right_1280`;
    //             // SetTextureRes(url,this.bmp_cardbackAry[0]);
    //             // SetTextureRes(url,this.bmp_cardbackAry[1]);
    //             // SetTextureRes(url,this.bmp_cardbackAry[2]);
    //             url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_left_right_1280`;
    //             // SetTextureRes(url,this.bmp_cardbackAry[3]);
                
    //             this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcardback_left_right_1280");
    //             this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcardback_left_right_1280");
    //             this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcardback_left_right_1280");
    //             this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_left_right_1280");
    //             this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                
                
    //             // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
    //             // SetTextureRes(url,this.bmp_cardcolorAry[1]);

    //             this.bmp_cardcolorAry[1].node.y = 15;
    //             this.bmp_cardbackAry[0].node.active=true;
    //             this.bmp_cardbackAry[1].node.active=true;
    //             this.bmp_cardbackAry[2].node.active=true;
    //             this.bmp_cardbackAry[3].node.active=true;
    //             this.bmp_cardcolorAry[0].node.active=false;
    //             this.bmp_cardcolorAry[1].node.active=true;
    //             this.bmp_cardcolorAry[2].node.active=false;
    //             // this._bmp_cardcolorAry[0].x = 1;
    //             // this._bmp_cardcolorAry[0].y = 56;
    //             // this._bmp_cardcolorAry[0].scaleX = 0.5;
    //             // this._bmp_cardcolorAry[0].scaleY = 0.5;
    //             // this._bmp_cardcolorAry[0].rotation=-90;
    //             this.setPos();
    //             break;
    //         }
    //         case enFixedCardType.FixedCardType_MGang:
    //         case enFixedCardType.FixedCardType_BGang: {
    //             url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_left_right_1280`;
    //             // SetTextureRes(url,this.bmp_cardbackAry[0]);
    //             // SetTextureRes(url,this.bmp_cardbackAry[1]);
    //             // SetTextureRes(url,this.bmp_cardbackAry[2]);
    //             // SetTextureRes(url,this.bmp_cardbackAry[3]);
                
    //             // //
    //             // //=================
    //             // //
    //             // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
    //             // SetTextureRes(url,this.bmp_cardcolorAry[0]);
    //             // SetTextureRes(url,this.bmp_cardcolorAry[1]);
    //             // SetTextureRes(url,this.bmp_cardcolorAry[2]);
                
    //             this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_left_right_1280");
    //             this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_left_right_1280");
    //             this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_left_right_1280");
    //             this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_left_right_1280");
    //             this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
    //             this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
    //             this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                
    //             this.bmp_cardcolorAry[1].node.y = 15;
    //             this.bmp_cardbackAry[0].node.active=true;
    //             this.bmp_cardbackAry[1].node.active=true;
    //             this.bmp_cardbackAry[2].node.active=true;
    //             this.bmp_cardbackAry[3].node.active=true;
    //             this.bmp_cardcolorAry[0].node.active=true;
    //             this.bmp_cardcolorAry[1].node.active=true;
    //             this.bmp_cardcolorAry[2].node.active=true;
    //             this.setPos();
    //             break;
    //         }
    //         case enFixedCardType.FixedCardType_Peng: {

    //             url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_left_right_1280`;
    //             // SetTextureRes(url,this.bmp_cardbackAry[0]);
    //             // SetTextureRes(url,this.bmp_cardbackAry[1]);
    //             // SetTextureRes(url,this.bmp_cardbackAry[2]);
    //             // SetTextureRes(url,this.bmp_cardbackAry[3]);
                
    //             // //
    //             // //=================
    //             // //
    //             // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
    //             // SetTextureRes(url,this.bmp_cardcolorAry[0]);
    //             // SetTextureRes(url,this.bmp_cardcolorAry[1]);
    //             // SetTextureRes(url,this.bmp_cardcolorAry[2]);
    //             this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_left_right_1280");
    //             this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_left_right_1280");
    //             this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_left_right_1280");
    //             this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
    //             this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
    //             this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);

                
    //             this.bmp_cardcolorAry[1].node.y = 5;
    //             this.bmp_cardbackAry[0].node.active=true;
    //             this.bmp_cardbackAry[1].node.active=true;
    //             this.bmp_cardbackAry[2].node.active=true;
    //             this.bmp_cardbackAry[3].node.active=false;
    //             this.bmp_cardcolorAry[0].node.active=true;
    //             this.bmp_cardcolorAry[1].node.active=true;
    //             this.bmp_cardcolorAry[2].node.active=true;
    //             this.setPos();
    //             break;
    //         }
    //     }
    //     this.node.active=true;
    // }
    protected arrangeCard() {
        let url="";
        if(LHZMJ.ins.iclass.is2D()){
            this.bmp_cardbackAry[0].node.x=0;
            this.bmp_cardbackAry[0].node.y=30;
            this.bmp_cardbackAry[0].node.width=56;
            this.bmp_cardbackAry[0].node.height=45;
            this.bmp_cardbackAry[0].node.scaleX=1;

            this.bmp_cardbackAry[1].node.x=0;
            this.bmp_cardbackAry[1].node.y=-1;
            this.bmp_cardbackAry[1].node.width=56;
            this.bmp_cardbackAry[1].node.height=45;
            this.bmp_cardbackAry[1].node.scaleX=1;
            
            this.bmp_cardbackAry[2].node.x=0;
            this.bmp_cardbackAry[2].node.y=-32;
            this.bmp_cardbackAry[2].node.width=56;
            this.bmp_cardbackAry[2].node.height=45;
            this.bmp_cardbackAry[2].node.scaleX=1;

            this.bmp_cardbackAry[3].node.x=0;
            this.bmp_cardbackAry[3].node.y=11;
            this.bmp_cardbackAry[3].node.width=56;
            this.bmp_cardbackAry[3].node.height=45;
            this.bmp_cardbackAry[3].node.scaleX=1;

            this.bmp_cardcolorAry[0].node.x=0;
            this.bmp_cardcolorAry[0].node.y=37;
            this.bmp_cardcolorAry[0].node.skewY=0;
            this.bmp_cardcolorAry[0].node.scaleX=0.4;
            this.bmp_cardcolorAry[0].node.scaleY=0.5;

            this.bmp_cardcolorAry[1].node.x=0;
            this.bmp_cardcolorAry[1].node.y=19;
            this.bmp_cardcolorAry[1].node.skewY=0;
            this.bmp_cardcolorAry[1].node.scaleX=0.4;
            this.bmp_cardcolorAry[1].node.scaleY=0.5;

            this.bmp_cardcolorAry[2].node.x=0;
            this.bmp_cardcolorAry[2].node.y=-24;
            this.bmp_cardcolorAry[2].node.skewY=0;
            this.bmp_cardcolorAry[2].node.scaleX=0.4;
            this.bmp_cardcolorAry[2].node.scaleY=0.5;

            this.bmp_cardHideAry[0].node.x=0;
            this.bmp_cardHideAry[0].node.y=37;
            this.bmp_cardHideAry[0].node.scaleX=0.45;
            this.bmp_cardHideAry[0].node.scaleY=0.45;
            this.bmp_cardHideAry[0].node.skewY=0;

            this.bmp_cardHideAry[1].node.x=0;
            this.bmp_cardHideAry[1].node.y=5;
            this.bmp_cardHideAry[1].node.scaleX=0.45;
            this.bmp_cardHideAry[1].node.scaleY=0.45;
            this.bmp_cardHideAry[1].node.skewY=0;

            this.bmp_cardHideAry[2].node.x=0;
            this.bmp_cardHideAry[2].node.y=-27;
            this.bmp_cardHideAry[2].node.scaleX=0.45;
            this.bmp_cardHideAry[2].node.scaleY=0.45;
            this.bmp_cardHideAry[2].node.skewY=0;
            switch(this.fixedType) {
                case enFixedCardType.FixedCardType_AGang: {
                
                    url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcardback_left_right_1280`;
                    // SetTextureRes(url,this.bmp_cardbackAry[0]);
                    // SetTextureRes(url,this.bmp_cardbackAry[1]);
                    // SetTextureRes(url,this.bmp_cardbackAry[2]);
                    url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_left_right_1280`;
                    // SetTextureRes(url,this.bmp_cardbackAry[3]);
                    
                    this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyou_back@2x");
                    this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyou_back@2x");
                    this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyou_back@2x");
                    this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyoupg@2x");
                    this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    
                    
                    // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
                    // SetTextureRes(url,this.bmp_cardcolorAry[1]);

                    this.bmp_cardcolorAry[1].node.y = 19;
                    this.bmp_cardbackAry[0].node.active=true;
                    this.bmp_cardbackAry[1].node.active=true;
                    this.bmp_cardbackAry[2].node.active=true;
                    this.bmp_cardbackAry[3].node.active=true;
                    this.bmp_cardcolorAry[0].node.active=false;
                    this.bmp_cardcolorAry[1].node.active=true;
                    this.bmp_cardcolorAry[2].node.active=false;
                    // this._bmp_cardcolorAry[0].x = 1;
                    // this._bmp_cardcolorAry[0].y = 56;
                    // this._bmp_cardcolorAry[0].scaleX = 0.5;
                    // this._bmp_cardcolorAry[0].scaleY = 0.5;
                    // this._bmp_cardcolorAry[0].rotation=-90;
                    this.setPos();
                    break;
                }
                case enFixedCardType.FixedCardType_MGang:
                case enFixedCardType.FixedCardType_BGang: {
                    url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_left_right_1280`;
                    // SetTextureRes(url,this.bmp_cardbackAry[0]);
                    // SetTextureRes(url,this.bmp_cardbackAry[1]);
                    // SetTextureRes(url,this.bmp_cardbackAry[2]);
                    // SetTextureRes(url,this.bmp_cardbackAry[3]);
                    
                    // //
                    // //=================
                    // //
                    // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
                    // SetTextureRes(url,this.bmp_cardcolorAry[0]);
                    // SetTextureRes(url,this.bmp_cardcolorAry[1]);
                    // SetTextureRes(url,this.bmp_cardcolorAry[2]);
                    
                    this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyoupg@2x");
                    this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyoupg@2x");
                    this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyoupg@2x");
                    this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyoupg@2x");
                    this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    
                    this.bmp_cardcolorAry[1].node.y = 19;
                    this.bmp_cardbackAry[0].node.active=true;
                    this.bmp_cardbackAry[1].node.active=true;
                    this.bmp_cardbackAry[2].node.active=true;
                    this.bmp_cardbackAry[3].node.active=true;
                    this.bmp_cardcolorAry[0].node.active=true;
                    this.bmp_cardcolorAry[1].node.active=true;
                    this.bmp_cardcolorAry[2].node.active=true;
                    this.setPos();
                    break;
                }
                case enFixedCardType.FixedCardType_Peng: {

                    url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_left_right_1280`;
                    // SetTextureRes(url,this.bmp_cardbackAry[0]);
                    // SetTextureRes(url,this.bmp_cardbackAry[1]);
                    // SetTextureRes(url,this.bmp_cardbackAry[2]);
                    // SetTextureRes(url,this.bmp_cardbackAry[3]);
                    
                    // //
                    // //=================
                    // //
                    // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
                    // SetTextureRes(url,this.bmp_cardcolorAry[0]);
                    // SetTextureRes(url,this.bmp_cardcolorAry[1]);
                    // SetTextureRes(url,this.bmp_cardcolorAry[2]);
                    this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyoupg@2x");
                    this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyoupg@2x");
                    this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("zuoyoupg@2x");
                    this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);

                    
                    this.bmp_cardcolorAry[1].node.y = 8;
                    this.bmp_cardbackAry[0].node.active=true;
                    this.bmp_cardbackAry[1].node.active=true;
                    this.bmp_cardbackAry[2].node.active=true;
                    this.bmp_cardbackAry[3].node.active=false;
                    this.bmp_cardcolorAry[0].node.active=true;
                    this.bmp_cardcolorAry[1].node.active=true;
                    this.bmp_cardcolorAry[2].node.active=true;
                    this.setPos();
                    break;
                }
            }
        }else{
            this.set3DSize();
            switch(this.fixedType) {
                case enFixedCardType.FixedCardType_AGang: {
                    // url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_backcard_self_1280`;
                    // // SetTextureRes(url,this.bmp_cardbackAry[0]);
                    // // SetTextureRes(url,this.bmp_cardbackAry[1]);
                    // // SetTextureRes(url,this.bmp_cardbackAry[2]);
                    // url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_self_1280`;
                    // // SetTextureRes(url,this.bmp_cardbackAry[3]);
                    // // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
                    // // SetTextureRes(url,this.bmp_cardcolorAry[1]);

                    // this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_backcard_self_1280");
                    // this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_backcard_self_1280");
                    // this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_backcard_self_1280");
                    // this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    // this.bmp_cardcolorAry[1].node.y = 30;
                    
                    if(this._cardIndex==1){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_01");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_02");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_03");
                        this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_02");
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    }else if(this._cardIndex==2){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_04");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_05");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_06");
                        this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_05");
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    }else if(this._cardIndex==3){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_07");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_08");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_09");
                        this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_08");
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    }else if(this._cardIndex==4){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_10");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_11");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_bm_bg_12");
                        this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_11");
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    }else{
                        cc.log("牌序异常！："+this._cardIndex);
                    }
                    

                    this.bmp_cardbackAry[0].node.active=true;
                    this.bmp_cardbackAry[1].node.active=true;
                    this.bmp_cardbackAry[2].node.active=true;
                    this.bmp_cardbackAry[3].node.active=true;

                    this.bmp_cardcolorAry[0].node.active=false;
                    this.bmp_cardcolorAry[1].node.active=true;
                    this.bmp_cardcolorAry[2].node.active=false;
                    this.setPos();
                    break;
                }
                case enFixedCardType.FixedCardType_MGang:
                case enFixedCardType.FixedCardType_BGang: {
                    // url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_self_1280`;
                    // // SetTextureRes(url,this.bmp_cardbackAry[0]);
                    // // SetTextureRes(url,this.bmp_cardbackAry[1]);
                    // // SetTextureRes(url,this.bmp_cardbackAry[2]);
                    // // SetTextureRes(url,this.bmp_cardbackAry[3]);
                    
                    // // //
                    // // //=================
                    // // //
                    // // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
                    // // SetTextureRes(url,this.bmp_cardcolorAry[0]);
                    // // SetTextureRes(url,this.bmp_cardcolorAry[1]);
                    // // SetTextureRes(url,this.bmp_cardcolorAry[2]);
                    // this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    // this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    // this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    
                    // this.bmp_cardcolorAry[1].node.y = 30;
                    if(this._cardIndex==1){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_01");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_02");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_03");
                        this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_02");
                        this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    }else if(this._cardIndex==2){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_04");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_05");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_06");
                        this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_05");
                        this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    }else if(this._cardIndex==3){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_07");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_08");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_09");
                        this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_08");
                        this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    }else if(this._cardIndex==4){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_10");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_11");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_12");
                        this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_11");
                        this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    }else{
                        cc.log("牌序异常！："+this._cardIndex);
                    }

                    this.bmp_cardbackAry[0].node.active=true;
                    this.bmp_cardbackAry[1].node.active=true;
                    this.bmp_cardbackAry[2].node.active=true;
                    this.bmp_cardbackAry[3].node.active=true;

                    this.bmp_cardcolorAry[0].node.active=true;
                    this.bmp_cardcolorAry[1].node.active=true;
                    this.bmp_cardcolorAry[2].node.active=true;
                    this.setPos();
                    break;
                }
                case enFixedCardType.FixedCardType_Peng: {
                    // url=`gameres/gameCommonRes/Texture/Mahjong/PaiBei3/pb3_showcard_self_1280`;
                    // // SetTextureRes(url,this.bmp_cardbackAry[0]);
                    // // SetTextureRes(url,this.bmp_cardbackAry[1]);
                    // // SetTextureRes(url,this.bmp_cardbackAry[2]);

                    // // url=LHZMJ.ins.iclass.getMahjongResName(this.cardValue);
                    // // SetTextureRes(url,this.bmp_cardcolorAry[0]);
                    // // SetTextureRes(url,this.bmp_cardcolorAry[1]);
                    // // SetTextureRes(url,this.bmp_cardcolorAry[2]);
                    // this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // //this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                    // this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    // this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                    // this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);

                    // this.bmp_cardcolorAry[1].node.y = 10;
                    if(this._cardIndex==1){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_01");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_02");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_03");
                        // this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_13");
                        //this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                        this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].node.x=-1;
                        this.bmp_cardcolorAry[1].node.y=8;
                    }else if(this._cardIndex==2){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_04");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_05");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_06");
                        // this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_10");
                        //this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                        this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].node.x=-1.5;
                        this.bmp_cardcolorAry[1].node.y=9.3;
                    }else if(this._cardIndex==3){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_07");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_08");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_09");
                        // this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_07");
                        //this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                        this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].node.x=-1.7;
                        this.bmp_cardcolorAry[1].node.y=8.7;
                    }else if(this._cardIndex==4){
                        this.bmp_cardbackAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_10");
                        this.bmp_cardbackAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_11");
                        this.bmp_cardbackAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_12");
                        // this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjong3DPaiBeiRes("d_left_mj_bg_04");
                        //this.bmp_cardbackAry[3].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiBeiRes("pb3_showcard_self_1280");
                        this.bmp_cardcolorAry[0].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[2].spriteFrame=LHZMJ.ins.iclass.getMahjongPaiHuaRes(this.cardValue);
                        this.bmp_cardcolorAry[1].node.x=-1.7;
                        this.bmp_cardcolorAry[1].node.y=9.4;
                    }else{
                        cc.log("牌序异常！："+this._cardIndex);
                    }

                    this.bmp_cardbackAry[0].node.active=true;
                    this.bmp_cardbackAry[1].node.active=true;
                    this.bmp_cardbackAry[2].node.active=true;
                    this.bmp_cardbackAry[3].node.active=false;
                    this.bmp_cardcolorAry[0].node.active=true;
                    this.bmp_cardcolorAry[1].node.active=true;
                    this.bmp_cardcolorAry[2].node.active=true;
                    this.setPos();
                    break;
                }
            }
        }
        
        this.node.active=true;
    }
    private setPos():void{
        this.bmp_arrow.node.active=false;
        if(this._pos!=0 && this._pos>0 && this._pos<4){
            switch(this._pos)
            {
                case 1:{
                    this.bmp_arrow.node.rotation = 180;
                    break;
                }
                case 2:{
                    this.bmp_arrow.node.rotation = 90;
                    break;
                }
                case 3:{
                    this.bmp_arrow.node.rotation = 0;
                    break;
                }
            }
            this.bmp_arrow.node.active=true;;
        }
    }
    private set3DSize(){
        switch(this._cardIndex){
            case 1:{
                this.node.x=-446.3;
                this.node.y=287.4;

                this.bmp_cardbackAry[0].node.x=8.7;
                this.bmp_cardbackAry[0].node.y=26.1;
                this.bmp_cardbackAry[0].node.width=59;
                this.bmp_cardbackAry[0].node.height=42;
                this.bmp_cardbackAry[0].node.setLocalZOrder(1);
                this.bmp_cardbackAry[0].node.scaleX=1;

                this.bmp_cardbackAry[1].node.x=0;
                this.bmp_cardbackAry[1].node.y=0;
                this.bmp_cardbackAry[1].node.width=60;
                this.bmp_cardbackAry[1].node.height=43;
                this.bmp_cardbackAry[1].node.setLocalZOrder(2);
                this.bmp_cardbackAry[1].node.scaleX=1;


                this.bmp_cardbackAry[2].node.x=-8.2;
                this.bmp_cardbackAry[2].node.y=-27.1;
                this.bmp_cardbackAry[2].node.width=60;
                this.bmp_cardbackAry[2].node.height=45;
                this.bmp_cardbackAry[2].node.setLocalZOrder(3);
                this.bmp_cardbackAry[2].node.scaleX=1;

                
                

                this.bmp_cardcolorAry[0].node.x=7.4;
                this.bmp_cardcolorAry[0].node.y=34.3;
                this.bmp_cardcolorAry[0].node.scaleX=0.36;
                this.bmp_cardcolorAry[0].node.scaleY=0.46;
                this.bmp_cardcolorAry[0].node.skewY=-13;
                this.bmp_cardcolorAry[0].node.setLocalZOrder(4);

                this.bmp_cardcolorAry[2].node.x=-10.1;
                this.bmp_cardcolorAry[2].node.y=-18.6;
                this.bmp_cardcolorAry[2].node.scaleX=0.37;
                this.bmp_cardcolorAry[2].node.scaleY=0.47;
                this.bmp_cardcolorAry[2].node.skewY=-14;
                this.bmp_cardcolorAry[2].node.setLocalZOrder(5);

                this.bmp_cardbackAry[3].node.x=-5.7;
                this.bmp_cardbackAry[3].node.y=14.6;
                this.bmp_cardbackAry[3].node.width=60;
                this.bmp_cardbackAry[3].node.height=43;
                this.bmp_cardbackAry[3].node.setLocalZOrder(6);
                this.bmp_cardbackAry[3].node.scaleX=1;    

                this.bmp_cardcolorAry[1].node.x=-6.7;
                this.bmp_cardcolorAry[1].node.y=22.1;
                this.bmp_cardcolorAry[1].node.scaleX=0.37;
                this.bmp_cardcolorAry[1].node.scaleY=0.47;
                this.bmp_cardcolorAry[1].node.skewY=-14;
                this.bmp_cardcolorAry[1].node.setLocalZOrder(7);
                

                this.bmp_cardHideAry[0].node.x=7.3;
                this.bmp_cardHideAry[0].node.y=33.6;
                this.bmp_cardHideAry[0].node.scaleX=0.36;
                this.bmp_cardHideAry[0].node.scaleY=0.41;
                this.bmp_cardHideAry[0].node.skewY=-15;

                this.bmp_cardHideAry[1].node.x=-1.1;
                this.bmp_cardHideAry[1].node.y=7.5;
                this.bmp_cardHideAry[1].node.scaleX=0.36;
                this.bmp_cardHideAry[1].node.scaleY=0.42;
                this.bmp_cardHideAry[1].node.skewY=-16;

                this.bmp_cardHideAry[2].node.x=-10.1;
                this.bmp_cardHideAry[2].node.y=-18.9;
                this.bmp_cardHideAry[2].node.scaleX=0.36;
                this.bmp_cardHideAry[2].node.scaleY=0.42;
                this.bmp_cardHideAry[2].node.skewY=-15;
                break;
            }
            case 2:{
                this.node.x=-473.8;
                this.node.y=193.7;

                this.bmp_cardbackAry[0].node.x=8.7;
                this.bmp_cardbackAry[0].node.y=27;
                this.bmp_cardbackAry[0].node.width=62;
                this.bmp_cardbackAry[0].node.height=46;
                this.bmp_cardbackAry[0].node.setLocalZOrder(1);
                this.bmp_cardbackAry[0].node.scaleX=1;

                this.bmp_cardbackAry[1].node.x=0;
                this.bmp_cardbackAry[1].node.y=0;
                this.bmp_cardbackAry[1].node.width=63;
                this.bmp_cardbackAry[1].node.height=47;
                this.bmp_cardbackAry[1].node.setLocalZOrder(2);
                this.bmp_cardbackAry[1].node.scaleX=1;


                this.bmp_cardbackAry[2].node.x=-7.8;
                this.bmp_cardbackAry[2].node.y=-27.1;
                this.bmp_cardbackAry[2].node.width=63;
                this.bmp_cardbackAry[2].node.height=47;
                this.bmp_cardbackAry[2].node.setLocalZOrder(3);
                this.bmp_cardbackAry[2].node.scaleX=1;

                
                

                this.bmp_cardcolorAry[0].node.x=7.4;
                this.bmp_cardcolorAry[0].node.y=36.4;
                this.bmp_cardcolorAry[0].node.scaleX=0.36;
                this.bmp_cardcolorAry[0].node.scaleY=0.47;
                this.bmp_cardcolorAry[0].node.skewY=-13;
                this.bmp_cardcolorAry[0].node.setLocalZOrder(4);

                this.bmp_cardcolorAry[2].node.x=-10.1;
                this.bmp_cardcolorAry[2].node.y=-18.6;
                this.bmp_cardcolorAry[2].node.scaleX=0.38;
                this.bmp_cardcolorAry[2].node.scaleY=0.49;
                this.bmp_cardcolorAry[2].node.skewY=-13;
                this.bmp_cardcolorAry[2].node.setLocalZOrder(5);

                this.bmp_cardbackAry[3].node.x=-4.7;
                this.bmp_cardbackAry[3].node.y=17.3;
                this.bmp_cardbackAry[3].node.width=63;
                this.bmp_cardbackAry[3].node.height=47;
                this.bmp_cardbackAry[3].node.setLocalZOrder(6);
                this.bmp_cardbackAry[3].node.scaleX=1;    

                this.bmp_cardcolorAry[1].node.x=-5.9;
                this.bmp_cardcolorAry[1].node.y=26;
                this.bmp_cardcolorAry[1].node.scaleX=0.37;
                this.bmp_cardcolorAry[1].node.scaleY=0.47;
                this.bmp_cardcolorAry[1].node.skewY=-14;
                this.bmp_cardcolorAry[1].node.setLocalZOrder(7);
                

                this.bmp_cardHideAry[0].node.x=7.3;
                this.bmp_cardHideAry[0].node.y=36.5;
                this.bmp_cardHideAry[0].node.scaleX=0.36;
                this.bmp_cardHideAry[0].node.scaleY=0.41;
                this.bmp_cardHideAry[0].node.skewY=-15;

                this.bmp_cardHideAry[1].node.x=-1.1;
                this.bmp_cardHideAry[1].node.y=9.4;
                this.bmp_cardHideAry[1].node.scaleX=0.37;
                this.bmp_cardHideAry[1].node.scaleY=0.43;
                this.bmp_cardHideAry[1].node.skewY=-16;

                this.bmp_cardHideAry[2].node.x=-10.1;
                this.bmp_cardHideAry[2].node.y=-17.6;
                this.bmp_cardHideAry[2].node.scaleX=0.37;
                this.bmp_cardHideAry[2].node.scaleY=0.44;
                this.bmp_cardHideAry[2].node.skewY=-15;
                break;
            }
            case 3:{
                this.node.x=-503.7;
                this.node.y=94.3;

                this.bmp_cardbackAry[0].node.x=8.7;
                this.bmp_cardbackAry[0].node.y=29.2;
                this.bmp_cardbackAry[0].node.width=66;
                this.bmp_cardbackAry[0].node.height=48;
                this.bmp_cardbackAry[0].node.setLocalZOrder(1);
                this.bmp_cardbackAry[0].node.scaleX=1;

                this.bmp_cardbackAry[1].node.x=0;
                this.bmp_cardbackAry[1].node.y=0;
                this.bmp_cardbackAry[1].node.width=68;
                this.bmp_cardbackAry[1].node.height=48;
                this.bmp_cardbackAry[1].node.setLocalZOrder(2);
                this.bmp_cardbackAry[1].node.scaleX=1;


                this.bmp_cardbackAry[2].node.x=-8.5;
                this.bmp_cardbackAry[2].node.y=-30.1;
                this.bmp_cardbackAry[2].node.width=68;
                this.bmp_cardbackAry[2].node.height=50;
                this.bmp_cardbackAry[2].node.setLocalZOrder(3);
                this.bmp_cardbackAry[2].node.scaleX=1;

                
                

                this.bmp_cardcolorAry[0].node.x=7.4;
                this.bmp_cardcolorAry[0].node.y=38.1;
                this.bmp_cardcolorAry[0].node.scaleX=0.38;
                this.bmp_cardcolorAry[0].node.scaleY=0.5;
                this.bmp_cardcolorAry[0].node.skewY=-13;
                this.bmp_cardcolorAry[0].node.setLocalZOrder(4);

                this.bmp_cardcolorAry[2].node.x=-10.6;
                this.bmp_cardcolorAry[2].node.y=-21.3;
                this.bmp_cardcolorAry[2].node.scaleX=0.4;
                this.bmp_cardcolorAry[2].node.scaleY=0.51;
                this.bmp_cardcolorAry[2].node.skewY=-13;
                this.bmp_cardcolorAry[2].node.setLocalZOrder(5);

                this.bmp_cardbackAry[3].node.x=-5.4;
                this.bmp_cardbackAry[3].node.y=17.3;
                this.bmp_cardbackAry[3].node.width=68;
                this.bmp_cardbackAry[3].node.height=48;
                this.bmp_cardbackAry[3].node.setLocalZOrder(6);
                this.bmp_cardbackAry[3].node.scaleX=1;    

                this.bmp_cardcolorAry[1].node.x=-7.4;
                this.bmp_cardcolorAry[1].node.y=25.8;
                this.bmp_cardcolorAry[1].node.scaleX=0.39;
                this.bmp_cardcolorAry[1].node.scaleY=0.5;
                this.bmp_cardcolorAry[1].node.skewY=-14;
                this.bmp_cardcolorAry[1].node.setLocalZOrder(7);
                

                this.bmp_cardHideAry[0].node.x=7.3;
                this.bmp_cardHideAry[0].node.y=38.2;
                this.bmp_cardHideAry[0].node.scaleX=0.38;
                this.bmp_cardHideAry[0].node.scaleY=0.45;
                this.bmp_cardHideAry[0].node.skewY=-15;

                this.bmp_cardHideAry[1].node.x=-1.3;
                this.bmp_cardHideAry[1].node.y=9;
                this.bmp_cardHideAry[1].node.scaleX=0.38;
                this.bmp_cardHideAry[1].node.scaleY=0.45;
                this.bmp_cardHideAry[1].node.skewY=-16;

                this.bmp_cardHideAry[2].node.x=-10.6;
                this.bmp_cardHideAry[2].node.y=-21.1;
                this.bmp_cardHideAry[2].node.scaleX=0.4;
                this.bmp_cardHideAry[2].node.scaleY=0.46;
                this.bmp_cardHideAry[2].node.skewY=-15;
                break;
            }
            case 4:{

                this.node.x=-534.4;
                this.node.y=-9.2;

                this.bmp_cardbackAry[0].node.x=9.4;
                this.bmp_cardbackAry[0].node.y=31.2;
                this.bmp_cardbackAry[0].node.width=70;
                this.bmp_cardbackAry[0].node.height=50;
                this.bmp_cardbackAry[0].node.setLocalZOrder(1);
                this.bmp_cardbackAry[0].node.scaleX=1;

                this.bmp_cardbackAry[1].node.x=0;
                this.bmp_cardbackAry[1].node.y=0;
                this.bmp_cardbackAry[1].node.width=71;
                this.bmp_cardbackAry[1].node.height=52;
                this.bmp_cardbackAry[1].node.setLocalZOrder(2);
                this.bmp_cardbackAry[1].node.scaleX=1;


                this.bmp_cardbackAry[2].node.x=-10;
                this.bmp_cardbackAry[2].node.y=-31.1;
                this.bmp_cardbackAry[2].node.width=72;
                this.bmp_cardbackAry[2].node.height=52;
                this.bmp_cardbackAry[2].node.setLocalZOrder(3);
                this.bmp_cardbackAry[2].node.scaleX=1;

                
                

                this.bmp_cardcolorAry[0].node.x=8.1;
                this.bmp_cardcolorAry[0].node.y=40.3;
                this.bmp_cardcolorAry[0].node.scaleX=0.41;
                this.bmp_cardcolorAry[0].node.scaleY=0.53;
                this.bmp_cardcolorAry[0].node.skewY=-13;
                this.bmp_cardcolorAry[0].node.setLocalZOrder(4);

                this.bmp_cardcolorAry[2].node.x=-11.6;
                this.bmp_cardcolorAry[2].node.y=-22;
                this.bmp_cardcolorAry[2].node.scaleX=0.43;
                this.bmp_cardcolorAry[2].node.scaleY=0.54;
                this.bmp_cardcolorAry[2].node.skewY=-13;
                this.bmp_cardcolorAry[2].node.setLocalZOrder(5);

                this.bmp_cardbackAry[3].node.x=-6.4;
                this.bmp_cardbackAry[3].node.y=17.8;
                this.bmp_cardbackAry[3].node.width=71;
                this.bmp_cardbackAry[3].node.height=52;
                this.bmp_cardbackAry[3].node.setLocalZOrder(6);
                this.bmp_cardbackAry[3].node.scaleX=1;    

                this.bmp_cardcolorAry[1].node.x=-8.6;
                this.bmp_cardcolorAry[1].node.y=27;
                this.bmp_cardcolorAry[1].node.scaleX=0.42;
                this.bmp_cardcolorAry[1].node.scaleY=0.53;
                this.bmp_cardcolorAry[1].node.skewY=-14;
                this.bmp_cardcolorAry[1].node.setLocalZOrder(7);
                

                this.bmp_cardHideAry[0].node.x=8.3;
                this.bmp_cardHideAry[0].node.y=40.4;
                this.bmp_cardHideAry[0].node.scaleX=0.41;
                this.bmp_cardHideAry[0].node.scaleY=0.47;
                this.bmp_cardHideAry[0].node.skewY=-15;

                this.bmp_cardHideAry[1].node.x=-1.5;
                this.bmp_cardHideAry[1].node.y=10;
                this.bmp_cardHideAry[1].node.scaleX=0.42;
                this.bmp_cardHideAry[1].node.scaleY=0.48;
                this.bmp_cardHideAry[1].node.skewY=-16;

                this.bmp_cardHideAry[2].node.x=-11.8;
                this.bmp_cardHideAry[2].node.y=-21.6;
                this.bmp_cardHideAry[2].node.scaleX=0.43;
                this.bmp_cardHideAry[2].node.scaleY=0.48;
                this.bmp_cardHideAry[2].node.skewY=-15;
                break;
            }
        }
        this.bmp_cardHideAry[0].node.setLocalZOrder(8);
        this.bmp_cardHideAry[1].node.setLocalZOrder(9);
        this.bmp_cardHideAry[2].node.setLocalZOrder(10);
        this.bmp_arrow.node.setLocalZOrder(11);
    }
}
