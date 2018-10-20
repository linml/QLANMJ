<?php

require "ChromePhp.php";

class console{

    public static function log($param){
        ChromePhp::log($param);
        //if(is_array($param)) ChromePhp::log($param);//self::log_withArray($param);
        //else ChromePhp::log($param);//echo("<script>console.log('".$param."');</script>");
    }


    /*private static function log_withArray($param){
        foreach($param as $k=>$v) {
            echo("<script>console.log('k:".$k."v:".$v."');</script>");
        }
    }*/
}


?>