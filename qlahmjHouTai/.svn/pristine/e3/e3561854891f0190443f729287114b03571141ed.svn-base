function isWx(){
    var ua = navigator.userAgent.toLowerCase();
    if (ua.match(/MicroMessenger/i) == "micromessenger") {
        return true;
    } else {
        return false;
    }
}

var BrowserType = {
    "ANDROID": "android", //android
    "IOS":     "ios",     //ios
    "MOBILE":  "mobile",  //移动端
    "QQ":      "qq",      //QQ
    "WECHAT":  "weixin",  //微信

    "TRIDENT": "trident", //IE内核
    "PRESTO":  "presto",  //opera内核
    "WEBKIT":  "webKit",  //苹果或谷歌内核
    "GECKO":   "gecko",   //火狐内核

    "IPHONE":  "iPhone",  //iPhone或者QQHD浏览器
    "IPAD":    "iPad",    //ipad
    "WEBAPP":  "webApp",  //?
};

function checkBrowserType(type){

    var u = navigator.userAgent;
    var app = navigator.appVersion;

    var types = {
        "trident": u.indexOf('Trident') > -1, 
        "presto":  u.indexOf('Presto') > -1, 
        "webKit":  u.indexOf('AppleWebKit') > -1, 
        "gecko":   u.indexOf('Gecko') > -1 && u.indexOf('KHTML') == -1,
        "mobile":  !!u.match(/AppleWebKit.*Mobile.*/), 
        "ios":     !!u.match(/\(i[^;]+;( U;)? CPU.+Mac OS X/), 
        "android": u.indexOf('Android') > -1 || u.indexOf('Adr') > -1, 
        "iPhone":  u.indexOf('iPhone') > -1, 
        "iPad":    u.indexOf('iPad') > -1, 
        "webApp":  u.indexOf('Safari') == -1, 
        "weixin":  u.indexOf('MicroMessenger') > -1, 
        "qq":      u.match(/\sQQ/i) == " qq",
    };

    if(type == null) return types;

    return types[type];
}