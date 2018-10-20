<?php
if(!defined('ACCESS')) {exit('Access denied.');}
require_once (ADMIN_BASE_LIB.'Qrcode.class.php');
class PhpqrCode extends Base{


   /* bool imagecopyresampled (resource $dst_image , resource $src_image , int $dst_x , int $dst_y , int $src_x , int $src_y , int $dst_w , int $dst_h ,int $src_w , int $src_h  );
    $dst_image：新建的图片
    $src_image：需要载入的图片
    $dst_x：设定需要载入的图片在新图中的x坐标
    $dst_y：设定需要载入的图片在新图中的y坐标
    $src_x：设定载入图片要载入的区域x坐标
    $src_y：设定载入图片要载入的区域y坐标
    $dst_w：设定载入的原图的宽度（在此设置缩放）
    $dst_h：设定载入的原图的高度（在此设置缩放）
    $src_w：原图要载入的宽度
    $src_h：原图要载入的高度

    $image_logo = imagecreatefrompng($path_logo);
    $image_base = imagecreatefromjpeg($path_base );
    $corner = imagecreatefromstring(file_get_contents(ADMIN_BASE_QRCOD.'/images/agentCenter/bg8.png'));

    */

    
    /**
     * [getPhpqrCode 获取带icon的二维码]
     * @Author   李爽
     * @DateTime 2018-07-31T15:17:18+0800
     * @param    array                    $QRcodeData [数据数组]
     * array('url' =>'好好学习天天向上！' ,'userid'=>33601,'icon_url'=>'http://img07.tooopen.com/images/20170316/tooopen_sy_201956178977.jpg' )
     * @return   [type]                               [返回名称]
    */
    public static function getPhpqrCode($QRcodeData = array()){
        if(!is_array($QRcodeData)||empty($QRcodeData)) return;

        // 纠错级别：L、M、Q、H
        $errorCorrectionLevel = 'M';

        // 点的大小：1到10
        $matrixPointSize = 4;

        // 保存文件名
        $filename = ADMIN_BASE_QRCOD."/qrcode/".md5($QRcodeData['userid'].'|'.$errorCorrectionLevel.'|'.$matrixPointSize).'.png';
        //判断文件是否存在
        if(!file_exists($filename)){
            //生成二维码
            QRcode::png($QRcodeData['url'], $filename, $errorCorrectionLevel, $matrixPointSize, 1);
             
            //获取二维码
            $qrcode = file_get_contents($filename);
            $qrcode = imagecreatefromstring($qrcode);
            $qrcode_width = imagesx($qrcode);
            $qrcode_height = imagesy($qrcode);

            if(!empty($QRcodeData['iconName'])){
                //圆角图片
                $corner = file_get_contents(ADMIN_BASE_QRCOD.'/images/agentCenter/bg8.png');
                $corner = imagecreatefromstring($corner);
                $corner_width = imagesx($corner);
                $corner_height = imagesy($corner);

                //计算圆角图片的宽高及相对于二维码的摆放位置,将圆角图片拷贝到二维码中央
                $corner_qr_height = $corner_qr_width = $qrcode_width/5;
                $from_width = ($qrcode_width-$corner_qr_width)/2;
                imagecopyresampled($qrcode, $corner, $from_width, $from_width, 0, 0, $corner_qr_width, $corner_qr_height, $corner_width, $corner_height);


                //logo图片
                // $logo = file_get_contents($QRcodeData['icon_url']);
                // $logo = imagecreatefromstring($logo);
                $logo = $QRcodeData['iconName'];
                $logo_width = imagesx($logo);
                $logo_height = imagesy($logo);


                //计算logo图片的宽高及相对于二维码的摆放位置,将logo拷贝到二维码中央
                $logo_qr_height = $logo_qr_width = $qrcode_width/5 - 6;
                $from_width = ($qrcode_width-$logo_qr_width)/2;
                imagecopyresampled($qrcode, $logo, $from_width, $from_width, 0, 0, $logo_qr_width, $logo_qr_height, $logo_width, $logo_height);
            }

            // header('Content-type: image/png');
            imagepng($qrcode,$filename);
            imagedestroy($qrcode);
            imagedestroy($corner);
            imagedestroy($logo);
        }
        return md5($QRcodeData['userid'].'|'.$errorCorrectionLevel.'|'.$matrixPointSize);
    }

    /**
     * [getSharePlayersQrCode 绘制分享图片]
     * @Author   李爽
     * @DateTime 2018-08-02T19:21:02+0800
     * @param    array                    $shareQrCodeData [数据]
     * $shareData = array('bgName'=>'invite_la','iconName'=>'img1',

        'icon'=>array('pos'=>array('x'=>10 ,'y'=>20 ),

        'size'=>array('width'=>200,'height'=>200)),

        'qrcodeData'=>array('url' =>'好好学习天天向上！' ,'userid'=>33601,'icon_url'=>'http://img07.tooopen.com/images/20170316/tooopen_sy_201956178977.jpg' ),

        'qrcode'=>array('pos'=>array('x'=>150 ,'y'=>200 ),'size'=>array('width'=>200,'height'=>200)),

        'font'=> array('fontSize'=>30,'angle'=>0,'x'=>200,'y'=>400,'color'=>array('r'=>0,'g'=>0,'b'=>255,'alpha'=>75))

        );
     * @return   [type]                                    [返回路径]
     */
    public static function getSharePlayersQrCode($shareQrCodeData =array()){
        if(empty($shareQrCodeData)) return;
        $basePath = "/sharedownload/".md5('sharedownload|'.$shareQrCodeData['qrcodeData']['userid']).".png";
        if(!file_exists(ADMIN_BASE_QRCOD.$basePath)){
            //1、配置底图
            $bg_basePath = ADMIN_BASE_QRCOD."/images/agentCenter/".$shareQrCodeData['bgName'].".jpg";
            $bgImageString = imagecreatefromstring(file_get_contents($bg_basePath));
            
            //2、配置ICON
            // $icon_basePath =ADMIN_BASE_QRCOD."/images/agentCenter/".$shareQrCodeData['iconName'].".png";
            $icon_basePath =$shareQrCodeData['iconName'];
            $iconImageString = imagecreatefromstring(file_get_contents($icon_basePath));
            imagecopyresampled($bgImageString, $iconImageString, $shareQrCodeData['icon']['pos']['x'], $shareQrCodeData['icon']['pos']['y'], 0, 0, $shareQrCodeData['icon']['size']['width'], $shareQrCodeData['icon']['size']['height'], imagesx($iconImageString), imagesy($iconImageString));
            //传入头像字符串
            $shareQrCodeData['qrcodeData']['iconName'] = $iconImageString;

            //3、拼图二维码
            $qrcode_basePath = ADMIN_BASE_QRCOD."/qrcode/".self::getPhpqrCode($shareQrCodeData['qrcodeData']).".png";
            $qrcodeImageString = imagecreatefromstring(file_get_contents($qrcode_basePath));
            imagecopyresampled($bgImageString, $qrcodeImageString, $shareQrCodeData['qrcode']['pos']['x'], $shareQrCodeData['qrcode']['pos']['y'], 0, 0, $shareQrCodeData['qrcode']['size']['width'], $shareQrCodeData['qrcode']['size']['height'], imagesx($qrcodeImageString), imagesy($qrcodeImageString));

            

            //4、字体拼图
            $fontTypefile = ADMIN_BASE_QRCOD."/font/tahoma.ttf";
            // 分配颜色和透明度
            $color = imagecolorallocatealpha($bgImageString,$shareQrCodeData['font']['color']['r'], $shareQrCodeData['font']['color']['g'], $shareQrCodeData['font']['color']['b'], $shareQrCodeData['font']['color']['alpha']);
            // 将文字写入到新图资源上
            imagettftext($bgImageString,$shareQrCodeData['font']['fontSize'],$shareQrCodeData['font']['angle'],$shareQrCodeData['font']['x'],$shareQrCodeData['font']['y'],$color,$fontTypefile,$shareQrCodeData['qrcodeData']['userid']);
            //5、合图保存
            imagepng($bgImageString,ADMIN_BASE_QRCOD.$basePath);
        }
        return "/assets".$basePath;
    }
}