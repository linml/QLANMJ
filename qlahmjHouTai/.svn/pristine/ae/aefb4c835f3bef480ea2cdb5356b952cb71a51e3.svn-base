<?php
require_once ADMIN_BASE_LIB."WxPay/lib/WxPay.Config.class.php";
require_once ADMIN_BASE_LIB."WxPay/lib/WxCash.Api.class.php";
class WxCash
{
	
	/**
	 * 
	 * 通过跳转获取用户的openid，跳转流程如下：
	 * 1、设置自己需要调回的url及其其他参数，跳转到微信服务器https://open.weixin.qq.com/connect/oauth2/authorize
	 * 2、微信服务处理完成之后会跳转回用户redirect_uri地址，此时会带上一些参数，如：code
	 * 
	 * @return 用户的openid
	 */
	public function GetOpenid()
	{
		//通过code获得openid
		if (!isset($_GET['code'])){
			$redirctUrl = $_SERVER['HTTP_HOST'].$_SERVER['PHP_SELF'];
			$url = "http://lamj.qilehuyu.cn/redirect.php?redirectUrl=".$redirctUrl."&".$_SERVER["QUERY_STRING"];
			Header("Location: $url");
			exit();
		} else {
			//获取code码，以获取openid
		    $code = $_GET['code'];
			$openid = $this->GetOpenidFromMp($code);
			return $openid;
		}
	}
	
	
	/**
	 * 
	 * 通过code从工作平台获取openid机器access_token
	 * @param string $code 微信跳转回来带上的code
	 * 
	 * @return openid
	 */
	public function GetOpenidFromMp($code)
	{
		$url = $this->__CreateOauthUrlForOpenid($code);
		//初始化curl
		$ch = curl_init();
		//设置超时
		curl_setopt($ch, CURLOPT_TIMEOUT, $this->curl_timeout);
		curl_setopt($ch, CURLOPT_URL, $url);
		curl_setopt($ch, CURLOPT_SSL_VERIFYPEER,FALSE);
		curl_setopt($ch, CURLOPT_SSL_VERIFYHOST,FALSE);
		curl_setopt($ch, CURLOPT_HEADER, FALSE);
		curl_setopt($ch, CURLOPT_RETURNTRANSFER, TRUE);
		if(WxPayConfig::CURL_PROXY_HOST != "0.0.0.0" 
			&& WxPayConfig::CURL_PROXY_PORT != 0){
			curl_setopt($ch,CURLOPT_PROXY, WxPayConfig::CURL_PROXY_HOST);
			curl_setopt($ch,CURLOPT_PROXYPORT, WxPayConfig::CURL_PROXY_PORT);
		}
		//运行curl，结果以jason形式返回
		$res = curl_exec($ch);
		curl_close($ch);
		//取出openid
		$data = json_decode($res,true);
		return $data;
	}
	
	/**
	 * 
	 * 拼接签名字符串
	 * @param array $urlObj
	 * 
	 * @return 返回已经拼接好的字符串
	 */
	private function ToUrlParams($urlObj)
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
	 * 
	 * 构造获取open和access_toke的url地址
	 * @param string $code，微信跳转带回的code
	 * 
	 * @return 请求的url
	 */
	private function __CreateOauthUrlForOpenid($code)
	{
		$urlObj["appid"] = WxPayConfig::APPID;
		$urlObj["secret"] = WxPayConfig::APPSECRET;
		$urlObj["code"] = $code;
		$urlObj["grant_type"] = "authorization_code";
		$bizString = $this->ToUrlParams($urlObj);
		return "https://api.weixin.qq.com/sns/oauth2/access_token?".$bizString;
	}

	/**
	 * [WeChatCash 付款给用户]
	 * @Author   李爽
	 * @DateTime 2018-08-21T11:39:43+0800
	 * @param    [type]                   $cashData [返回支付信息]
	 */
	public function WeChatCash($cashData){
		if(!array_key_exists("openid", $cashData)
			|| $cashData['openid'] == "")
			 exit("业务处理中缺少openId参数"."<br>");

		$wxCash = new WxCashApi();
		return $wxCash->payToUser($cashData);
	}

}