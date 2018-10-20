import { AudioManager } from "../../Manager/AudioManager";
import { LocalStorage } from "../../CustomType/LocalStorage";
import { AudioType, VoiceType } from "../../CustomType/Enum";

import Global from "../../Global/Global";
import UIBase from "../../Form/Base/UIBase";

const {ccclass, property} = cc._decorator;

@ccclass
export default class GameSettingForm extends UIBase<any> {
	public IsEventHandler: boolean = true;
    public IsKeyHandler: boolean = true;

    @property(cc.Toggle)
    chbox_music: cc.Toggle = null;

    @property(cc.Toggle)
    chbox_effect: cc.Toggle = null;

    @property(cc.Toggle)
    chbox_shock: cc.Toggle = null;

	public InitShow(){
		let musicVolume = Global.Instance.AudioManager.GetVolume(AudioType.Music);
		let effectVolume = Global.Instance.AudioManager.GetVolume(AudioType.Effect);
		// let shockVolume = Global.Instance.AudioManager.GetVolume(AudioType.Music);

		if (0 == musicVolume) {
			this.chbox_music.isChecked = false;
		}else{
			this.chbox_music.isChecked = true;
		}

		if (0 == effectVolume) {
			this.chbox_effect.isChecked = false;
		}else{
			this.chbox_effect.isChecked = true;
		}
	}

	public OnShow(){

	}

	/**
	 * 音乐开关
	 */
	public switchMusicClick(toggle, customEventData) {
		Global.Instance.AudioManager.SwitchMusic(toggle.isChecked);
	}

	/**
	 * 音效开关
	 */
	public switchEffectClick(toggle, customEventData) {
		Global.Instance.AudioManager.SwitchEffect(toggle.isChecked);
	}

	/**
	 * 震动开关
	 */
	public switchShockClick(toggle, customEventData) {

	}

	/**
	 * 关闭
	 */
	public closeClick(){
		this.node.removeFromParent();
	}
}
