<?php
require ('../include/init.inc.php');
$result = array (
		'status' => 0,
		'msg' => '' 
);

$uri = HttpRequest::parse_request_uri ();

if (strtolower ( $uri ) == 'getswitch') {
	$version = $type = '';
	extract ( $_REQUEST, EXTR_IF_EXISTS );
	$res = call_user_func ( $uri, array (
			"version" => $version,
			'type' => $type 
	) );
} else {
	$result['status'] = 0;
	$result['msg'] = '请求连接不存在';
	echo json_encode ( $result );
	exit ();
}
function getswitch($args) {
	if (empty ( $args ) || empty ( $args['type'] )) {
		$result['status'] = 0;
		$result['msg'] = 'type不能为空';
	} else {		
		$config = Notice::getswitch ( strtolower ( $args['type'] ) . 'payswitch' );
		if ($config) {
			$result['status'] = 1;
			$result['msg'] = '';
			$result['data'] = json_decode ( $config['switch'], true );
		} else {
			
			$result['status'] = 0;
			$result['msg'] = '不显示';
		}
	}
	
	echo json_encode ( $result );
}