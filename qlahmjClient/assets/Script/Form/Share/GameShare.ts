/**
 * 游戏中的分享弹框
 */

import UIBase from "../Base/UIBase";
import { WxManager } from "../../Manager/WxManager";
import { ShareParam } from "../../CustomType/ShareParam";
import Global from "../../Global/Global";
import { deepCopy } from "../../Tools/Function";

const {ccclass, property} = cc._decorator;

@ccclass
export default class GameShare extends UIBase<any> {
   public IsEventHandler: boolean = true
   public IsKeyHandler: boolean = true;

   // 分享参数
   private _shareParams: any = null;

   // 分享类型
   private _shareType: string = '';

   public InitShow(){
   		super.InitShow();
   		this._shareParams = this.ShowParam['shareParam'];
   		this._shareType = this.ShowParam['shareType']
   }

   /**
    * 分享按钮事件处理
    */
   public btnShareClickEvent(type,param) {
   	if (!this._shareParams) {
   		this.UiManager.ShowTip('分享参数错误!');
   		return;
   	}

      let shareParam: any = null;
      
      if ('img' == this._shareType) {
         shareParam = this._shareParams;
      }else{
         shareParam = deepCopy(this._shareParams);
      }

   	let wXScene: number = 0;
   	
   	if ('XianLiao' == param) {
   		// 闲聊
   		wXScene = 1001
   	}else if ('WX' == param) {
   		// 微信
   		wXScene = this._shareParams['WXScene'];
   	}

   	shareParam['WXScene'] = wXScene;

   	if ('img' == this._shareType) {
         cc.info('--- game share param ', shareParam);
   		Global.Instance.WxManager.CaptureScreenshot(shareParam.node, wXScene, shareParam.haveMask);
         return;
   	}else if ('link'== this._shareType && 'XianLiao' == param) {
         shareParam['roomId'] = shareParam.link_param.tableid;
         shareParam['roomToken'] = '123456';
         shareParam['shareType'] = 'xlappshare';
      }

      Global.Instance.WxManager.Share(shareParam);   
   }
}
