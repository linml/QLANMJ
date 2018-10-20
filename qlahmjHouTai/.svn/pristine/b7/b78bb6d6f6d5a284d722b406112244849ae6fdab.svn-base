<?php
require ('../include/init.inc.php');
$result = array (
		'status' => 0,
		'msg' => '' 
);

$uri = HttpRequest::parse_request_uri ();

if (strtolower ( $uri ) == 'getagentqrcode') {
	$uid = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$result=SharedDll::GetQrcode (array (
			"userid" => $uid 
	));
	echo json_encode ( $result );
}elseif(strtolower ( $uri ) == 'getqrcode_url'){
	

	$res = call_user_func ( $uri);
}
else {
	$result['status'] = 0;
	$result['msg'] = '请求的连接不存在';
	echo json_encode ( $result );
	exit ();
}
/*function getagentqrcode($args) {
 	$result['status'] = 0;
 	$result['msg'] = '公众号暂时不可以用！';
 	echo json_encode ( $result );
 	exit();

	//echo $args;
	
	if (empty ( $args ) || empty ( $args['uid'] )) {
		$result['status'] = 0;
		$result['msg'] = 'UID不能为空';
	} else {
		$user = ApiDll::getTuserByUid ( $args['uid'] );
		if (! $user) {
			$result['status'] = 0;
			$result['msg'] = '玩家UID不存在';
		} else {
			$userqrcode =  ApiDll::getTuserQrcodeByUid ( $args['uid'] );
			if ($userqrcode) {
				$result['status'] = 1;
				$result['msg'] = 'old';
				$result['data'] = $userqrcode;
			} else {
				//生产二维码
				include '../assets/qrcode/phpqrcode.php';
				//$value = strtolower ( ADMIN_URL ) . "/sharedownload/index.php?uid=". $args['uid'] ; // 二维码内容
				$value = "http://taihumajiang.game.magicred.net:3800/sharedownload/index.php?uid=". $args['uid'] ; // 二维码内容
				
				$errorCorrectionLevel = 'L'; // 容错级别
				$matrixPointSize = 6; // 生成图片大小
				                      // 生成二维码图片
				$time = time ();
				// echo $time;
				$qrname = "qrcode" . $args['uid'] . "_" . ( string ) $time . '.jpg';
				$path = '/assets/qrcode/img/' . $qrname;
				//$mjadmin='mjadmin';
				$fullpath = ADMIN_BASE_QRCOD . DIRECTORY_SEPARATOR . "qrcode" . DIRECTORY_SEPARATOR . "img" . DIRECTORY_SEPARATOR . $qrname;
				
				// echo $fullpath;
				QRcode::png ( $value, $fullpath, $errorCorrectionLevel, $matrixPointSize, 2 );
				
				
				// emp.jpg路径
				$bigImgPath = ADMIN_BASE_QRCOD . DIRECTORY_SEPARATOR . "qrcode" . DIRECTORY_SEPARATOR . "emp.jpg";
				//头像图片路径 下载保存
				$photoPath = ADMIN_BASE_QRCOD . DIRECTORY_SEPARATOR . "qrcode" . DIRECTORY_SEPARATOR . "photo" . DIRECTORY_SEPARATOR . 'photo_' . $qrname;
				
				if($user['headimg'])
				{
					saveImage ( $photoPath, $user['headimg'] );
				}
				else {
					if($user['sex']==1)
					{
						$photoPath=ADMIN_BASE_QRCOD . DIRECTORY_SEPARATOR . "qrcode" . DIRECTORY_SEPARATOR . "default_male.jpg";
							
					}else {
						$photoPath=ADMIN_BASE_QRCOD . DIRECTORY_SEPARATOR . "qrcode" . DIRECTORY_SEPARATOR . "default_female.jpg";
							
					}
				}
				
				
				//二维码图片路径
				$qCodePath = $fullpath;
				
				
				
				$bigImg = imagecreatefromstring ( file_get_contents ( $bigImgPath ) );
				$photoImg = imagecreatefromstring ( file_get_contents ( $photoPath ) );
				$qCodeImg = imagecreatefromstring ( file_get_contents ( $qCodePath ) );
				
				//添加文字 开始
// 				$text="testsetwse";
// 				$font = '../assets/font/tahoma.ttf';
// 				$gray = ImageColorAllocate($bigImg, 200,200,200);				
// 				imagettftext($bigImg, 15, 0, 200, 200, $fontcolor, $font, $text);
				//添加文字 结束
				
				//添加头像 开始
				list ( $qCodeWidth, $qCodeHight, $qCodeType ) = getimagesize ( $photoPath );
				imagecopymerge ( $bigImg, $photoImg, 41, 676, 0, 0, $qCodeWidth, $qCodeHight, 100 );
				
				//添加二维码 开始
				list ( $qCodeWidth, $qCodeHight, $qCodeType ) = getimagesize ( $qCodePath );				
				imagecopymerge ( $bigImg, $qCodeImg, 260, 840, 0, 0, $qCodeWidth, $qCodeHight, 100 );
				
				//分享二维码路径
				$sharepath = '/assets/qrcode/shareimg/share_' . $qrname;
				$sharefullpath = ADMIN_BASE_QRCOD . DIRECTORY_SEPARATOR . "qrcode" . DIRECTORY_SEPARATOR . "shareimg" . DIRECTORY_SEPARATOR . 'share_' . $qrname;
				imagejpeg ( $bigImg, $sharefullpath , 70 );
				
				imagedestroy ( $bigImg );
				imagedestroy ( $photoImg );
				imagedestroy ( $qCodeImg );
				
				$input_data = array (
						'uid' => $args['uid'],
						'qrcode_url' => $path,
						'share_qrcode_url' => $sharepath 
				);
				ApiDll::addUserQrcode ( $input_data );
				$result['status'] = 1;
				$result['msg'] = 'new';
				$result['data'] = $input_data;
			}
		}
	}
	echo json_encode ( $result );
}
function saveImage($photoPath, $path) {
	$ch = curl_init ( $path );
	curl_setopt ( $ch, CURLOPT_RETURNTRANSFER, 1 );
	curl_setopt ( $ch, CURLOPT_BINARYTRANSFER, 1 );
	$img = curl_exec ( $ch );
	curl_close ( $ch );
	$fp = fopen ( $photoPath, 'w' );
	fwrite ( $fp, $img );
	fclose ( $fp );
	
	$filename = $photoPath;
	$percent = 0.15;
	// Content type
	// header('Content-Type: image/jpeg');
	// Get new dimensions
	list ( $width, $height ) = getimagesize ( $filename );
	$new_width = 100;
	$new_height = 100;
	// Resample
	$image_p = imagecreatetruecolor ( $new_width, $new_height );
	$image = imagecreatefromjpeg ( $filename );
	imagecopyresampled ( $image_p, $image, 0, 0, 0, 0, $new_width, $new_height, $width, $height );
	// Output
	imagepng ( $image_p, $photoPath );
	// imagejpeg($image_p, null, 100);
}
function getqrcode_url()
{
	Header ( "Access-Control-Allow-Origin: * " );
	Header ( "Access-Control-Allow-Methods: POST, GET, OPTIONS, PUT, DELETE" );
	
	
	$img = ADMIN_BASE_QRCOD . DIRECTORY_SEPARATOR . "qrcode" . DIRECTORY_SEPARATOR . "img" . DIRECTORY_SEPARATOR . 'qrcode100053_1496283632.jpg';
	$base64_img = base64EncodeImage($img);
	
	echo '<img src="' . $base64_img . '" />';
	
	
}
function base64EncodeImage ($image_file) {
	$base64_image = '';
	$image_info = getImageSize($image_file);
	//$image_path = 'E:/data/www/lamahui/aliyun_imgs/static/images/2016/05/24/21d98edf98bd6c30afe1c83891132c2f1374.png';
	$image_data = fread(fopen($image_file, 'r'), filesize($image_file));
	$base64_image = 'data:' . $image_info['mime'] . ';base64,' .chunk_split(base64_encode($image_data));
	return $base64_image;
}*/
