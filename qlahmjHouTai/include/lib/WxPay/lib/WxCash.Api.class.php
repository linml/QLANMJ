<?php

/**
 * 
 * 接口访问类，包含所有微信支付API列表的封装，类中方法为static方法，
 * 每个接口有默认超时时间（除提交被扫支付为10s，上报超时时间为1s外，其他均为6s）
 * @author widyhu
 *
 */
class WxCashApi
{
	

	//企业向个人付款
    public function payToUser($params) {
        $url = 'https://api.mch.weixin.qq.com/mmpaymkttransfers/promotion/transfers';
        
        //检测必填参数
        if($params["partner_trade_no"] == null) {
            exit("提现申请接口中，缺少必填参数partner_trade_no！"."<br>");
        }elseif($params["openid"] == null){
            exit("提现申请接口中，缺少必填参数openid！"."<br>");
        }elseif($params["check_name"] == null){             //NO_CHECK：不校验真实姓名 FORCE_CHECK：强校验真实姓名（未实名认证的用户会校验失败，无法转账）OPTION_CHECK：针对已实名认证的用户才校验真实姓名（未实名认证用户不校验，可以转账成功）
            exit("提现申请接口中，缺少必填参数check_name！"."<br>");
        }elseif(($params["check_name"] == 'FORCE_CHECK' or $params["check_name"] == 'OPTION_CHECK') && ($params["re_user_name"] == null)){  //收款用户真实姓名。
            exit("提现申请接口中，缺少必填参数re_user_name！"."<br>");
        }elseif($params["amount"] == null){
            exit("提现申请接口中，缺少必填参数amount！"."<br>");
        }elseif($params["desc"] == null){
            exit("提现申请接口中，缺少必填参数desc！"."<br>");
        }
        
        $params["mch_appid"] = WxPayConfig::APPID;//公众账号ID
        $params["mchid"] = WxPayConfig::MCHID;//商户号
        $params["nonce_str"] = $this->getNonceStr();//随机字符串
        $params['spbill_create_ip'] = $_SERVER['REMOTE_ADDR'];//获取IP
        $params["sign"] = $this->getSign($params);//签名
        $xml = $this->arrayToXml($params);
        return $this->postXmlSSLCurl($xml, $url, false);
    }

	
	/**
	 * 
	 * 产生随机字符串，不长于32位
	 * @param int $length
	 * @return 产生的随机字符串
	 */
	private function getNonceStr($length = 32)
	{
		$chars = "abcdefghijklmnopqrstuvwxyz0123456789";  
		$str ="";
		for ( $i = 0; $i < $length; $i++ )  {  
			$str .= substr($chars, mt_rand(0, strlen($chars)-1), 1);  
		} 
		return $str;
	}
	

	/**
     *  array转xml
     */
    private function arrayToXml($arr)
    {
        $xml = "<xml>";
        foreach ($arr as $key=>$val)
        {
            if (is_numeric($val))
            {
               $xml.="<".$key.">".$val."</".$key.">"; 
            }
            else
            	$xml.="<".$key."><![CDATA[".$val."]]></".$key.">";  
        }
        $xml.="</xml>";
        return $xml; 
    }

    /**
     * [getSign 获取签名]
     * @Author   李爽
     * @DateTime 2018-08-21T10:50:08+0800
     * @return   [type]                   [description]
     */
    private function getSign($data){
    	//将要发送的数据整理为$data
		ksort($data);//排序
		//使用URL键值对的格式（即key1=value1&key2=value2…）拼接成字符串
		$str='';
		foreach($data as $k=>$v) {
		    $str.=$k.'='.$v.'&';
		}
		//拼接API密钥
		$str.='key='.WxPayConfig::KEY;

		return md5($str);//加密
    }

    /**
     * [xmltoarray 把xml转化成数组]
     * @Author   李爽
     * @DateTime 2018-08-21T11:07:21+0800
     * @param    [type]                   $xml [xml 文件]
     * @return   [type]                        [数组]
     */
    private function xmlToArray($xml) { 
     	//禁止引用外部xml实体 
	    libxml_disable_entity_loader(true); 
	    $xmlstring = simplexml_load_string($xml, 'SimpleXMLElement', LIBXML_NOCDATA); 
	    $val = json_decode(json_encode($xmlstring),true); 
	    return $val;
	}


	/**
    *   作用：使用证书，以post方式提交xml到对应的接口url
    */
    function postXmlSSLCurl($xml, $url, $second=30)
    {
        $ch = curl_init();
        //超时时间
        curl_setopt($ch,CURLOPT_TIMEOUT,$second);
        
        //这里设置代理，如果有的话
        //curl_setopt($ch,CURLOPT_PROXY, '8.8.8.8');
        //curl_setopt($ch,CURLOPT_PROXYPORT, 8080);
        curl_setopt($ch,CURLOPT_URL, $url);
        curl_setopt($ch,CURLOPT_SSL_VERIFYPEER,FALSE);
        curl_setopt($ch,CURLOPT_SSL_VERIFYHOST,FALSE);
        //设置header
        curl_setopt($ch,CURLOPT_HEADER,FALSE);
        //要求结果为字符串且输出到屏幕上
        curl_setopt($ch,CURLOPT_RETURNTRANSFER,TRUE);
        //设置证书
        //使用证书：cert 与 key 分别属于两个.pem文件
        //默认格式为PEM，可以注释
        curl_setopt($ch,CURLOPT_SSLCERTTYPE,'PEM');
        curl_setopt($ch,CURLOPT_SSLCERT,dirname(__FILE__).DIRECTORY_SEPARATOR.WxPayConfig::SSLCERT_PATH);
        //默认格式为PEM，可以注释
        curl_setopt($ch,CURLOPT_SSLKEYTYPE,'PEM');
        curl_setopt($ch,CURLOPT_SSLKEY, dirname(__FILE__).DIRECTORY_SEPARATOR.WxPayConfig::SSLKEY_PATH);
        //post提交方式
        curl_setopt($ch,CURLOPT_POST, true);
        curl_setopt($ch,CURLOPT_POSTFIELDS,$xml);
        $data = curl_exec($ch);
        //返回结果
        if($data){
            curl_close($ch);
            return $this->xmlToArray($data);
        }
        else {
            $error = curl_errno($ch);
            echo "curl出错，错误码:$error"."<br>"; 
            curl_close($ch);
            return false;
        }
    }
	
}

