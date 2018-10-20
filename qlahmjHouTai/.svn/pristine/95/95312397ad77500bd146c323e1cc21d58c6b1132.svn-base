<?php
if(!defined('ACCESS')) {exit('Access denied.');}
require_once(ADMIN_BASE_LIB."WxPay/lib/WxPay.Config.class.php");
class JSSDK extends Base {

  /**
   * [getAccessToken description]
   * @Author   李爽
   * @DateTime 2018-08-17T18:32:14+0800
   * @param    [type]                   $code [description]
   * @return   [type]                         [description]
   */
  public function getAccessToken($code) {
    if(empty($code)) return;
      $url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=".WxPayConfig::APPID."&secret=".WxPayConfig::APPSECRET."&code=$code&grant_type=authorization_code";
    $access_token = json_decode(self::curl_init($url));
    return $access_token;
  }

  /**
   * [getUserInfoByAccessToken 通过access_token 获取用户信息]
   * @Author   李爽
   * @DateTime 2018-08-18T09:39:48+0800
   * @param    [type]                   $accessToken [description]
   * @param    [type]                   $openid      [description]
   * @return   [type]                                [返回用户信息]
   */
  public function getUserInfoByAccessToken($accessToken,$openid){
    if(empty($accessToken)||empty($openid))return;
    $url ="https://api.weixin.qq.com/sns/userinfo?access_token=$accessToken&openid=$openid&lang=zh_CN";
    $userInfo = json_decode(self::curl_init($url));
    return $userInfo;
  }


  /**
   * [addUserAccount 添加玩家]
   * @Author   李爽
   * @DateTime 2018-08-18T11:53:51+0800
   * @param    [type]                   $name    [名称]
   * @param    [type]                   $sex     [性别]
   * @param    [type]                   $agentid [代理ID]
   * @param    [type]                   $picpath [头像路径]
   * @param    [type]                   $unionid [UnionID]
   * @param    [type]                   $openid  [Openid]
   */
  public static function addUserAccount($name,$sex,$agentid,$picpath,$unionid,$openid){
    if(empty($name)||empty($agentid)||empty($sex)||
      empty($picpath)||empty($unionid)||empty($openid)) return;
    $db = self::__instance();
    //添加绑定官方
    $db->exec("call sp_user_add('".$name."',".$sex.",".$agentid.",'".$picpath."','".$unionid."','".$openid."',@aua_out)");
    return $db ->query("select @aua_out")->fetch(PDO::FETCH_ASSOC)["@aua_out"];
  }

}

