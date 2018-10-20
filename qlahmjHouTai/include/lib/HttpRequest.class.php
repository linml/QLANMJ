<?php
if(!defined('ACCESS')) {exit('Access denied.');}

class HttpRequest {
	
	public static function getSdXml($date, $api, $dataArray) {
		$xmldata = "<?xml version=\"1.0\" encoding=\"utf-8\" ?><Request>";
		$xmldata .= "<Datetime>".$date."</Datetime><$api>";
		foreach ( $dataArray as $key => $value ) {
			$xmldata .= "<" . $key . ">" . $value . "</" . $key . ">";
		}
		$xmldata .= "</$api></Request>";
		return $xmldata;
	}
	
	public static function postRequest($url, $header, $xmldata) {
		$ch = curl_init ();
		curl_setopt ( $ch, CURLOPT_URL, $url );
		curl_setopt ( $ch, CURLOPT_TIMEOUT, 30 );
		curl_setopt ( $ch, CURLOPT_RETURNTRANSFER, 1 );
		curl_setopt ( $ch, CURLOPT_CUSTOMREQUEST, 'POST' );
		curl_setopt ( $ch, CURLOPT_HTTPHEADER, $header );
		curl_setopt ( $ch, CURLOPT_POSTFIELDS, $xmldata );
		curl_setopt ( $ch, CURLOPT_SSL_VERIFYPEER, FALSE );
		curl_setopt ( $ch, CURLOPT_SSL_VERIFYHOST, FALSE );
		curl_setopt ( $ch, CURLOPT_HEADER, 1 );
		try {
			$res = curl_exec ( $ch );
			$httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
			$responseHeaderSize = curl_getinfo($ch, CURLINFO_HEADER_SIZE);
			$responseHeader = substr($res, 0, $responseHeaderSize);
			$responseContent = substr($res, $responseHeaderSize);
			if(!$res){
				$msg = curl_error($ch);
			}
		} catch (Exception $e) {
			$msg = $e->getMessage();
		}
		curl_close($ch);
		return array(
				"httpcode"=>isset($httpCode)?$httpCode:"",
				"header"=>isset($responseHeader)?$responseHeader:"",
				"content"=>isset($responseContent)?$responseContent:"",
				"msg"=>isset($msg)?$msg:""
		);
	}
	
	public static function getRequest($url, $header) {
		$ch = curl_init ();
		curl_setopt ( $ch, CURLOPT_URL, $url );
		curl_setopt ( $ch, CURLOPT_TIMEOUT, 30 );
		curl_setopt ( $ch, CURLOPT_RETURNTRANSFER, 1 );
		curl_setopt ( $ch, CURLOPT_HTTPHEADER, $header);
		curl_setopt ( $ch, CURLOPT_SSL_VERIFYPEER, FALSE );
		curl_setopt ( $ch, CURLOPT_SSL_VERIFYHOST, FALSE );
		curl_setopt ( $ch, CURLOPT_HEADER, 1 );
		try {
			$res = curl_exec ( $ch );
			$httpCode = curl_getinfo($ch, CURLINFO_HTTP_CODE);
			$responseHeaderSize = curl_getinfo($ch, CURLINFO_HEADER_SIZE);
			$responseHeader = substr($res, 0, $responseHeaderSize);
			$responseContent = substr($res, $responseHeaderSize);
			if(!$res){
				$msg = curl_error($ch);
			}
		} catch (Exception $e) {
			$msg = $e->getMessage();
		}
		curl_close($ch);
		return array(
				"httpcode"=>isset($httpCode)?$httpCode:"",
				"header"=>isset($responseHeader)?$responseHeader:"",
				"content"=>isset($responseContent)?$responseContent:"",
				"msg"=>isset($msg)?$msg:""
		);
	}
	
// 	public static function send_post($url, $postdata) {
// 		$options = array (
// 				'http' => array (
// 						'method' => 'POST',
// 						'header' => 'Content-type:application/x-www-form-urlencoded;charset=utf-8',
// 						'content' => $postdata,
// 						'timeout' => 15 * 60
// 				) // 超时时间（单位:s）
// 		);
// 		$context = stream_context_create ( $options );
// 		$result = file_get_contents ( $url, false, $context );
// 		return $result;
// 	}
	
	public static function getResponse($type, $response) {
		switch ($type) {
			case "json":
				$return = json_encode($response);
				break;
			default:
				$return = json_encode($response);
				break;
		}
		return $return;
	}
	
	public static function parse_request_uri() {
		if ( ! isset($_SERVER['REQUEST_URI'], $_SERVER['SCRIPT_NAME']))
			return '';
		$uri = parse_url('http://dummy'.$_SERVER['REQUEST_URI']);
		$query = isset($uri['query']) ? $uri['query'] : '';
		$uri = isset($uri['path']) ? $uri['path'] : '';
		if (isset($_SERVER['SCRIPT_NAME'][0]))
		{
			if (strpos($uri, $_SERVER['SCRIPT_NAME']) === 0)
			{
				$uri = (string) substr($uri, strlen($_SERVER['SCRIPT_NAME']));
			}
			elseif (strpos($uri, dirname($_SERVER['SCRIPT_NAME'])) === 0)
			{
				$uri = (string) substr($uri, strlen(dirname($_SERVER['SCRIPT_NAME'])));
			}
		}
		if (trim($uri, '/') === '' && strncmp($query, '/', 1) === 0)
		{
			$query = explode('?', $query, 2);
			$uri = $query[0];
			$_SERVER['QUERY_STRING'] = isset($query[1]) ? $query[1] : '';
		}
		else
		{
			$_SERVER['QUERY_STRING'] = $query;
		}
		parse_str($_SERVER['QUERY_STRING'], $_GET);
		if ($uri === '/' OR $uri === '')
		{
			return '/';
		}
		$uris = array();
		$tok = strtok($uri, '/');
		while ($tok !== FALSE)
		{
			if (( ! empty($tok) OR $tok === '0') && $tok !== '..')
			{
				$uris[] = $tok;
			}
			$tok = strtok('/');
		}
		return implode('/', $uris);
	}
	
}