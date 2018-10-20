<?php
require ('../include/init.inc.php');
$method = $id = $title = $content = $begintime = $endtime = $object = '';
extract ( $_REQUEST, EXTR_IF_EXISTS );
if($method == 'release'){
	$message = Message::getMessageList();
	exit(json_encode($message));
}
if($method == 'edit' && !empty($id)){
	$result = Message::getMessageById($id);
	exit(json_encode($result));
}
if($method == 'publish' && !empty($id) && !empty($content) && !empty($title) && !empty($begintime) && !empty($endtime) && !empty($object)){
	$result = Message::editMessage($id,$title,$content,$begintime,$endtime,$object);
	exit(json_encode($result));
}
if($method == 'del' && !empty($id)){
	$result = Message::delMessage($id);
	exit(json_encode($result));
}
if($method == 'add' && !empty($content) && !empty($title) && !empty($begintime) && !empty($endtime) && !empty($object)){
	$result = Message::addMessage($title,$content,$begintime,$endtime,$object);
	exit(json_encode($result));
}
Template::assign ( 'message', $message );
Template::display ( 'agent/message.tpl' );