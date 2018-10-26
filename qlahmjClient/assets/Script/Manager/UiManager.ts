import { IUiManager } from "../Interface/IUiManager";
import { Action } from "../CustomType/Action";
import UIBase from "../Form/Base/UIBase";
import Dictionary from "../CustomType/Dictionary";
import { Tips } from "../Form/General/Tips";
import { MessageBox } from "../Form/General/MessageBox";
import { UIName } from "../Global/UIName";
import Global from "../Global/Global";
import { EventCode } from "../Global/EventCode";
import { LoadingForm } from "../Form/Loading/LoadingForm";
import ConfigData from "../Global/ConfigData";
import { GameCachePool } from "../Global/GameCachePool";
import { UrlMsgBox } from "../Form/General/UrlMsgBox";
import { TimerForm } from "../Form/General/TimerForm";
import { QL_Common } from "../CommonSrc/QL_Common";
import { NoticeForm } from "../Form/General/NoticeForm";
import { IsIOS, PlayEffect } from "../Tools/Function";
import { InputFormViewParam } from "../Form/Daili/InputFormView";
import { AudioType } from "../CustomType/Enum";




export default class UiManager implements IUiManager {

    private _uiList: Dictionary<string, UIBase<any>>;
    private _tipsList: Array<Tips>;
    private _msgBoxList: Array<MessageBox>;
    private _onlyOneInstance: any = {};
    // private _noticeList: QL_Common.HallRoolNotice[];

    private _loading: LoadingForm;
    private _noticeForm: any;
    public constructor() {
        this._uiList = new Dictionary<string, UIBase<any>>();
        this._tipsList = new Array();
        this._msgBoxList = new Array();
        // this._noticeList = new Array();
    }

    private _loadingInfo: string;
    private _loadingShow: boolean;
    private _noticeLock: boolean;
    ShowLoading(str?: string) {
        this._loadingInfo = str;
        this._loadingShow = true;
        this._noticeLock = false;
        if (cc.isValid(this._loading)) {
            cc.log("已存在loading,直接再次显示");
            this._loading.Show(null);
            this.LoadingInfo(str);
            return;
        }
        const t = this;
        cc.log("开始加载" + UIName.Loading);
        cc.loader.loadRes("Prefabs/" + UIName.Loading, this.onLoadingLoaded.bind(this));
    }

    CloseLoading() {
        this._loadingShow = false;
        if (cc.isValid(this._loading)) {
            this._loading.Close();
        }
    }


    LoadingInfo(str: string) {
        if (cc.isValid(this._loading)) {
            this._loading.OnLoadInfo(str);

        }
    }




    ShowUi(uiname: string): void;
    ShowUi(uiname: string, param: any): void;
    ShowUi(uiname: string, param: any, action: Action): void;
    ShowUi(uiname: any, param?: any, action?: any) {

        //如果是审核服
        if (ConfigData.RegionName === "review") {
            //如果希望在ios中弹出充值界面
            if (uiname === UIName.Shop && IsIOS()) {
                //如果不支持ios_pay,则弹出审核专用界面，否则正常弹出
                if (ConfigData.SiteConfig.AttachParam2 !== "ios_pay") {
                    uiname = UIName.Contact;
                }
            }
        } else {
            // if (uiname === UIName.Shop && Global.Instance.DataCache.UserInfo.userData.AgentId === 0) {
            //     uiname = UIName.Daili;
            // }
            // if (uiname === UIName.Daili && Global.Instance.DataCache.UserInfo.userData.AgentId > 0) {
            //     this.ShowMsgBox("已经绑定过代理");
            //     return;
            // }
        }
        let ui = this._uiList.GetValue(uiname);
        if (cc.isValid(ui)) {
            cc.info(`已存在${uiname}，直接显示`);
            PlayEffect(cc.url.raw("resources/Sound/open_panel.mp3"));
            ui.Show(null, param, action);
            return;
        }
        const t = this;
        cc.log("开始加载" + uiname);

        cc.loader.loadRes("Prefabs/" + uiname, function (err, prefab: cc.Prefab) {

            if (err) {
                cc.error(err.message || err);
                return;
            }

            const newNode = cc.instantiate(prefab);
            var u = <UIBase<any>>newNode.getComponent(UIBase)
            if (!cc.isValid(u)) {
                cc.warn("无效的ui组件")
                return;
            }

            PlayEffect(cc.url.raw("resources/Sound/open_panel.mp3"));
            //检查是否是单根实例
            if (u.isOneInstance) {
                let _oneInstance = t._onlyOneInstance[uiname];
                if (cc.isValid(_oneInstance)) {
                    return;
                }
                t._onlyOneInstance[uiname] = u;
            }
            u.Show(null, param, action);
            t._uiList.AddOrUpdate(uiname, u);

        });
    }

    public GetUINode(UIName: string): cc.Node {
        let ui = this._uiList.GetValue(UIName);

        if (ui) {
            return ui.node;
        }
    }

    CloseUi(uiname: string, param?: any): void {
        let ui = this._uiList.GetValue(uiname);
        if (cc.isValid(ui)) {

            if (ui.canReUse) {
                ui.Close(null, param);
            } else {
                this.DestroyUi(uiname);
            }
        } else {
            cc.warn("未找到组件" + uiname);
        }
    }

    DestroyUi(uiname: string): void {
        let ui = this._uiList.GetValue(uiname);
        if (cc.isValid(ui)) {
            ui.node.destroy();
            this._uiList.Remove(uiname);
            PlayEffect(cc.url.raw("resources/Sound/close_panel.mp3"));
        } else {
            cc.warn("未找到组件" + uiname);
        }
    }

    ShowTip(msg: string, time: number = 2) {
        let tip: Tips;
        for (let i = 0; i < this._tipsList.length; i++) {
            if (this._tipsList[i].IsFree) {
                tip = this._tipsList[i];
                break;
            }
        }

        if (cc.isValid(tip)) {
            tip.Go(msg, time);
            return;
        }
        const t = this;
        cc.loader.loadRes("Prefabs/General/Tips", function (err, prefab: cc.Prefab) {
            if (err) {
                cc.error(err.message || err);
                return;
            }
            const newNode = cc.instantiate(prefab);
            var tp = newNode.getComponent<Tips>(Tips);
            t._tipsList.push(tp);
            tp.Go(msg, time);
        });
    }

    ShowMsgBox(msg: string, thisobj?: any, okAction?: Function, cancleAction?: Function, closeAction?: Function, okArgs?: any, cancleArgs?: any, closeArgs?: any, align: cc.Label.HorizontalAlign = cc.Label.HorizontalAlign.CENTER): void {
        let box: MessageBox;
        for (let i = 0; i < this._msgBoxList.length; i++) {
            if (this._msgBoxList[i].IsFree) {
                box = this._msgBoxList[i];
                break;
            }
        }

        if (cc.isValid(box)) {
            box.Go(msg, thisobj, okAction, cancleAction, closeAction, okArgs, cancleArgs, closeArgs);
            box.text.horizontalAlign = align;
            return;
        }
        const t = this;
        cc.loader.loadRes("Prefabs/General/MessageBox", function (err, prefab: cc.Prefab) {
            if (err) {
                cc.error(err.message || err);
                return;
            }
            const newNode = cc.instantiate(prefab);
            var box = newNode.getComponent<MessageBox>(MessageBox);
            t._msgBoxList.push(box);
            box.Go(msg, thisobj, okAction, cancleAction, closeAction, okArgs, cancleArgs, closeArgs);
            box.text.horizontalAlign = align;
        });
    }

    ShowInputBox(param: InputFormViewParam) {
        this.ShowUi('Daili/InputFormView', param);
    }

    ShowUrlMsgBox(url: string): void {
        if (!url || url.length < 7) return;
        let node = GameCachePool.UrlMsgBoxPool.get();
        if (cc.isValid(node)) {
            let c = node.getComponent<UrlMsgBox>(UrlMsgBox);
            c.Go(null, url);
            return;
        }
        cc.loader.loadRes("Prefabs/General/UrlMsgBox", cc.Prefab, (err, prefab: cc.Prefab) => {
            if (err) {
                cc.error(err);
                return;
            }
            node = cc.instantiate(prefab);
            let c = node.getComponent<UrlMsgBox>(UrlMsgBox);
            c.Go(null, url);
        });
    }


    private onLoadingLoaded(err, prefab: cc.Prefab) {
        if (err) {
            cc.error(err.message || err);
            return;
        }
        const newNode = cc.instantiate(prefab);
        var u = newNode.getComponent<LoadingForm>(LoadingForm)
        if (!cc.isValid(u)) {
            cc.warn("无效的ui组件")
            return;
        }
        if (this._loadingInfo) {
            this.LoadingInfo(this._loadingInfo);
        }
        this._loading = u;
        if (this._loadingShow) {
            u.Show(null);
        }

    }


    public GetTimerForm(): cc.Node {
        return TimerForm.create();
    }


    PlayHallRoolNotice(notice: any) {
        // if (!notice) return;
        // this._noticeList.push(notice);
        // this.onPlayNotice();
    }


    private onPlayNotice() {
        // //如果正在播放公告，直接返回
        // if (this._noticeLock) {
        //     return;
        // }
        // if (!this._noticeList || this._noticeList.length === 0) {

        //     if (cc.isValid(this._noticeForm)) {
        //         this._noticeForm.Close();
        //     }
        //     return;
        // }
        // this._noticeLock = true;
        // const notice = this._noticeList.shift();

        // if (cc.isValid(this._noticeForm)) {
        //     this._noticeForm.Go(notice);
        //     return;
        // } else {
        //     const action = new Action(this, this.onPlayNoticeEnd);
        //     cc.loader.loadRes("Prefabs/General/NoticeForm", cc.Prefab, function (err, prefab: cc.Prefab) {
        //         if (err) {
        //             cc.error(err);
        //             return;
        //         }
        //         const node = cc.instantiate(prefab);
        //         let c = node.getComponent<NoticeForm>(NoticeForm);
        //         c.Action = action;
        //         this._noticeForm = c;
        //         c.Go(notice);
        //     }.bind(this));
        // }
    }

    private onPlayNoticeEnd() {
        this._noticeLock = false;
        cc.log("公告播放完成！")
        this.onPlayNotice();
    }

}