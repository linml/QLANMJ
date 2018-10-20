<?php 
session_start();

//header("Content-type: image/png");

$im = imagecreatetruecolor(55, 28);
$english = array(2,3,4,5,6,7,8,9);
$chinese= array();
//$chinese = array("人","出","来","友","学","孝","仁","义","礼","廉","忠","国","中","易","白","者","火 ","土","金","木","雷","风","龙","虎","天","地", "生","晕","菜","鸟","田","三","百","钱","福","爱","情","兽","虫","鱼","九","网","新","度","哎","唉","啊","哦","仪","老","少","日","月","星","于","文","琦","搜","狐","卓","望"); 
$chars = array_merge($english,$chinese);
// 创建颜色 
$fontcolor = imagecolorallocate($im, 0x6c, 0x6c, 0x6c);
//$bg = imagecolorallocate($im, rand(0,85), rand(85,170), rand(170,255));
$bg = imagecolorallocate($im, 0xfc, 0xfc, 0xfc);
imagefill($im, 0, 0, $bg);
// 设置文字 
$text = "";
for($i=0;$i<4;$i++) $text .= trim($chars[rand(0,count($chars)-1)]);
$_SESSION['osa_verify_code'] = $text;
$font = '../assets/font/tahoma.ttf';
$gray = ImageColorAllocate($im, 200,200,200);
// 添加文字 
imagettftext($im, 15, 0, 1, 23, $fontcolor, $font, $text);
//imagestring($im, 15, 10, 7, $text, $fontcolor);
//加入干扰象素
$r = rand()%50;
for($i=0;$i<150;$i++){
	$x=sqrt($i)*2+$r;
	imagesetpixel($im, abs(sin($i)*80) , abs(cos($i)*28) , $gray);
	imagesetpixel($im, $x , $i , $gray);
	imagesetpixel($im, rand()%80 , rand()%28 , $gray);
}

//保存alpha信息  
imagealphablending($im, false);  
imagesavealpha($im, true);  
// start buffering  
//  
imagepng($im);  
$contents =  ob_get_contents();  
ob_end_clean();

echo base64_encode($contents);
// 输出图片 
// imagepng($im);
// $contents =  ob_get_contents();  
// ob_end_clean();
// echo $contents;
// imagedestroy($im);
?> 