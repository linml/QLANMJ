<?php

class STools {

    public static function decodeArray($array){
        if(!is_array($array)) return "";
    
        $ret = "{";
        foreach($array as $k=>$v){
            if(strlen($ret) > 1) $ret .= ",";
            if(is_array($v)) $v = decodeArray($v);
            $ret .= $k.":".$v;
        }
        $ret .= "}";
    
        return $ret;
    }

    public static function log($text){
        static $file = "slog.txt";
        if(is_array($text)) $text = self::decodeArray($text);
        $success = file_put_contents($file, $text, FILE_APPEND);
    }
}