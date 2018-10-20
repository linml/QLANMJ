import { LHZMJSoundDef, LHZMJ } from "./ConstDef/LHZMJMahjongDef";
import { AudioType, VoiceType } from "../../CustomType/Enum";

const { ccclass, property } = cc._decorator;

@ccclass
export default class M_LHZMJVoice{

    /**
     * 播放聊天音效
     */
    public static PlayChatVoice(value: number, gender: number,Type:VoiceType) {
        //如果是普通话
        if(Type==VoiceType.Mandarin){
        var path = "resources/gameres/gameCommonRes/Voice/";
        if (gender == 1) {
            path += "ChatVoice/Boy/ChatVoiceB_" + value + ".mp3";
        }
        else {
            path += "ChatVoice/Girl/ChatVoiceG_" + value + ".mp3";
        }
        //path = cc.url.raw(path);
        LHZMJ.ins.iclass.playMJSound(path, AudioType.Effect, false);
    }else{


        var path = "resources/gameres/gameCommonRes/Voice/";
        if (gender == 1) {
            path += "ChatVoice/Boy/ChatVoiceB_" + value + ".mp3";
        }
        else {
            path += "ChatVoice/Girl/ChatVoiceG_" + value + ".mp3";
        }
        //path = cc.url.raw(path);
        LHZMJ.ins.iclass.playMJSound(path, AudioType.Effect, false);





        // var path = "resources/gameres/M_LHZMJ/sound/";
        // if (gender == 1) {
        //     path += "DialectVoice/Boy/DialectVoiceB_" + value + ".mp3";
        // }
        // else {
        //     path += "DialectVoice/Girl/DialectVoiceG_" + value + ".mp3";
        // }
       
        // LHZMJ.ins.iclass.playMJSound(path, AudioType.Effect, false);



    }




}
    /**
     * 播放牌型音效
     */
    public static PlayCardType(str:string) {
        var path = LHZMJSoundDef.VoicePath;
        // if (gender == 1) {
        //     path += "CardType/Boy/CardType76B_" + value + ".mp3";
        // }
        // else {
        //     path += "CardType/Girl/CardType76G_" + value + ".mp3";
        // }
        path+=str;
        //path = cc.url.raw(path);
        LHZMJ.ins.iclass.playMJSound(path, AudioType.Effect, false);
    }

      /**
     * 播放方言版牌型音效
     */
    public static PlayDiaCardType(str:string) {
        var path = str;
        // if (gender == 1) {
        //     path += "CardType/Boy/CardType76B_" + value + ".mp3";
        // }
        // else {
        //     path += "CardType/Girl/CardType76G_" + value + ".mp3";
        // }
        
        //path = cc.url.raw(path);
        LHZMJ.ins.iclass.playMJSound(path, AudioType.Effect, false);
    }
    /**
     * 播放公共音效
     */
    public static PlayPublicSound(value: string) {
        var path = cc.url.raw(LHZMJSoundDef.CommonVoicePath + "Voice/" + value + ".mp3");
        LHZMJ.ins.iclass.playMJSound(path, AudioType.Effect, false);
    }
    /**
     * 播放系统音效
     */
    public static PlaySysSound(value: string) {
        var path = cc.url.raw(LHZMJSoundDef.VoicePath + "SysSound/Sys76_" + value + ".mp3");
        LHZMJ.ins.iclass.playMJSound(path, AudioType.Effect, false);
    }
    /**
     * 播放bgm
     */
    public static PlayBgm() {
        var path = "resources/gameres/Voice/MJ_Voice/sound/mj_sound_bg.mp3";
        LHZMJ.ins.iclass.playMJSound(path, AudioType.Music, true);
    }
}
