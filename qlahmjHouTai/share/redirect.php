<?php
$APPID = 'wx4a98d29526a1f737';

//http://lamj.qilehuyu.cn/redirect.php?redirectUrl=manage.qileah.cn/share/pushbind.php&agentid=107
//获取openid 
GetOpenid($APPID);

/**
 * 
 * 通过跳转获取用户的openid，跳转流程如下：
 * 1、设置自己需要调回的url及其其他参数，跳转到微信服务器https://open.weixin.qq.com/connect/oauth2/authorize
 * 2、微信服务处理完成之后会跳转回用户redirect_uri地址，此时会带上一些参数，如：code
 * 
 * @return 用户的openid
 */
function GetOpenid($APPID)
{

    //通过code获得openid
    if (!isset($_GET['code'])){
        //触发微信返回code码
        /*var_dump($_SERVER['HTTP_HOST']);
        echo "<br>";
        var_dump($_SERVER['PHP_SELF']);
        echo "<br>";
        var_dump($_SERVER['QUERY_STRING']);
        echo "<br>";*/
        $baseUrl = urlencode('http://'.$_SERVER['HTTP_HOST'].$_SERVER['PHP_SELF']."?".$_SERVER['QUERY_STRING']);
        $url = __CreateOauthUrlForCode($baseUrl,$APPID);
        Header("Location: $url");
        exit();
    }else{
        $urlData = parse_url_param($_SERVER["QUERY_STRING"]);
        $redirectUrl .= "http://".$urlData['redirectUrl'];
        unset($urlData['redirectUrl']);
        foreach ($urlData as $key => $value) {
            $redirectUrl .= strpos($redirectUrl, '?')? "&".$key."=".$value: "?".$key."=".$value;
        }
        
        //返回数据节点返回
        Header("Location: $redirectUrl");
        exit();
    }
}

/**
 * 
 * 构造获取code的url连接
 * @param string $redirectUrl 微信服务器回跳的url，需要url编码
 * 
 * @return 返回构造好的url
 */
function __CreateOauthUrlForCode($redirectUrl,$appid)
{   

    $urlObj["appid"] = "$appid";
    $urlObj["redirect_uri"] = "$redirectUrl";
    $urlObj["response_type"] = "code";
    $urlObj["scope"] = "snsapi_userinfo";
    $urlObj["state"] = "STATE"."#wechat_redirect";
    $bizString = ToUrlParams($urlObj);
    return "https://open.weixin.qq.com/connect/oauth2/authorize?".$bizString;
}

/**
 * 
 * 拼接签名字符串
 * @param array $urlObj
 * 
 * @return 返回已经拼接好的字符串
 */
function ToUrlParams($urlObj)
{
    $buff = "";
    foreach ($urlObj as $k => $v)
    {
        if($k != "sign"){
            $buff .= $k . "=" . $v . "&";
        }
    }
    
    $buff = trim($buff, "&");
    return $buff;
}


/** 
     * 获取url中的各个参数 
     * 类似于 pay_code=alipay&bank_code=ICBC-DEBIT 
     * @param type $str 
     * @return type 
     */  
    function parse_url_param($str)  
    {  
        $data = array();  
        $arr=array();
        $p=array();
        $p = explode('&', $str); 
        foreach ($p as $val) {  
            $tmp = explode('=', $val);  
            $data[$tmp[0]] = $tmp[1];  
        }  
        return $data;  
    }  
    
