﻿import { WebSiteConfig } from "../CustomType/WebSiteConfig";
import { Debug, StartWiths, CurrentPackageType } from "../Tools/Function";
import { NativeCallBack } from "../Native/NativeCallBack";
import { NativeCtrl } from "../Native/NativeCtrl";
import { PackageType } from "../CustomType/PackageType";

export default class ConfigData {

    public static NeedHotupdate = true;
    public static AutoLogin = true;
    private static _siteConfig = new WebSiteConfig();
    public static _isGetedOpenUri:boolean =false;


    private static _nativeConf: any = null;

    public static get GetNativeConf(): any {
        if (!cc.isValid(ConfigData._nativeConf)) {

            cc.log(`获取的Native参数无效`);
            try {
                //初始化默认的Native参数
                ConfigData._nativeConf = ConfigData.init();
                let s = NativeCtrl.GetNativeConfig();
                cc.log(`获取到Native 参数：${s}`);
                //获取到Native 参数赋值
                let jsonObj = JSON.parse(s);
                for (let i in jsonObj) {
                    cc.log(`初始化Native 参数：${i} = ${jsonObj[i]}`);
                    ConfigData._nativeConf[i] = jsonObj[i];
                }
            }
            catch (ex) {
                cc.log(ex.message);
            }
        }
        cc.log(`获取的Native参数有效`);
        return ConfigData._nativeConf;
    }
    static init() {
        let o: any = {};

        o.Identifier = "ceshi_android";
        o.RegionName = "ceshi";
        o.AppVersion = 0;
        o.Identifier = "ceshi_android";

        return o;
    }

    public static InitConfigFromNative() {

        // //获取app的版本号 
        let pkg_version = cc["LocalVersion"]
        if (!cc.isValid(pkg_version)) {
            pkg_version = parseInt(ConfigData.GetNativeConf.AppVersion);
        }
        cc.log("获取到App版本号：" + pkg_version);
        cc.sys.localStorage.setItem("currentVersion", pkg_version + "");
        ConfigData.AppVersion = pkg_version;
        ConfigData.RegionName = ConfigData.GetNativeConf.RegionName;
        ConfigData.Identifier = ConfigData.GetNativeConf.Identifier;
    }

    public static get SiteConfig() {
        return ConfigData._siteConfig;
    }

    public static get IPPort(): Array<string> {
        let ipArray = ["ws://106.14.166.171:9003/"];

        switch (CurrentPackageType()) {
            case PackageType.Debug:
                return ipArray;
            case PackageType.Preview:
            default:
                return [`ls.${ConfigData.RegionName}-login.qileah.cn:9003`]
        }
    }

    /**
     * 通用类服务接口地址，类似检查热更新地址
     */
    public static get CommonBaseUrl(): string {
        let apiBaseUrl = "http://api.test.qileah.cn";
        switch (CurrentPackageType()) {
            case PackageType.Debug:
                return apiBaseUrl;
            case PackageType.Preview:
            default:
                return "http://api.qileah.cn";
        }
    }

    /*
     * 网站服务接口地址
     * */
    public static get webserverinterfaceUrl(): string {

        let apiBaseUrl = "http://api.test.qileah.cn";

        switch (CurrentPackageType()) {
            case PackageType.Debug:
                return apiBaseUrl;
            case PackageType.Preview:
            default:
                return `http://api.${ConfigData.RegionName}-qlgame.qileah.cn`
        }
        // return "http://api.test.qileah.cn"
        // //return "http://192.168.1.250:12345";

        // if (Debug()) {
        //     /**
        //     * 测试
        //     */
        //     return "http://192.168.1.12:12345";
        //     // return `http://${ConfigData.RegionName}.8hb.cc/open`;
        // }

        // if (!cc.sys.isNative) {
        //     return 'open';
        // }

        // if (StartWiths(ConfigData.domain, "http")) {
        //     return ConfigData.domain;
        // }
        // if (ConfigData.RegionName === "review") {
        //     return `http://review-new.8hb.cc/open`;
        // }
        // cc.log("当前domain=" + ConfigData.domain);
        // return `http://${ConfigData.RegionName}.8hb.cc/open`;
    }

    public static domain = "";
    public static get resWebUrl(): string {
        if (Debug()) {
            return "http://192.168.1.115:80";
        }

        return "http://files.8hb.cc";
    }
    public static get UploadInfoUrl(): string {
        return "http://v0.api.upyun.com";
    }
    /**
     * 无头像的时候使用的默认头像
     */
    public static defaultHeader = ConfigData.resWebUrl + "/liufei/city_header_default.png";
    /**
     * app唯一标识符
     */
    public static Identifier = "ceshi_android";
    /**
     * 分区名称
     */
    public static RegionName: string = "ceshi";
    /**
     * app版本号
     */
    public static AppVersion: number = 0;

    public static SystemInited: boolean = false;
    private static _gameList: Array<number>;
    public static get GameList(): Array<number> {
        if (ConfigData._gameList == null) {
            ConfigData._gameList = [1];
        }
        return ConfigData._gameList;
    }
    public static set GameList(val: Array<number>) {
        ConfigData._gameList = val;
    }
}