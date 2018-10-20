<?php
if(!defined('ACCESS')) {exit('Access denied.');}

class GameUser extends Base{

    private static $table_name = 'pigcms_users';

    public static function getTableName(){
		return self::$table_name;
    }
    
    //通过ID获取用户信息
    public static function getUser($userId){
        $db = self::__instance();
        $ret = $db->select(self::getTableName(), "*", ["userid"=>$userId]);
        
        if($ret) return $ret[0];
        else return null;
    }

    //为userId增加gems个钻石, 来自订单oid
    public static function addGems($userId, $gems, $oid){
        $db = self::__instance();
        $ret = $db->update(self::getTableName(), ["gems[+]"=>$gems], ["userid"=>$userId]);
        if($ret === false){
            SysLog::addLog("userId:".$userId, "addGems", "GameUser", "", ["oid"=>$oid, "userId"=>$userId, "gems"=>$gems, "errData"=>$db->error()], 2);
            return false;
        }
        return true;
    }

}