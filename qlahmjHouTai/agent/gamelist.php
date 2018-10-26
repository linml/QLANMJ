<?php
require ('../include/init.inc.php');
$method = $gameid = $gamecity = $gametype = $gamestatus = $GameDesc = '';
extract ( $_REQUEST,EXTR_IF_EXISTS );
$gamelist = GameList::getGamelist();

if($method == 'showGameInfo' && !empty($gameid)){
	$result = GameList::getGameInfo($gameid);
	exit(json_encode($result));
}
switch ($method) {
	case 'chgamecity':
		$sql = "update game_info set gamecity = '$gamecity' where gameid = '$gameid' ";
		$result = GameList::updateInfo($sql);
		exit(json_encode($result));
		break;
	case 'chgametype':
		$sql = "update game_info set gametype = '$gametype' where gameid = '$gameid' ";
		$result = GameList::updateInfo($sql);
		exit(json_encode($result));
		break;
	case 'chgamestatus':
		$sql = "update game_info set gamestatus = '$gamestatus' where gameid = '$gameid' ";
		$result = GameList::updateInfo($sql);
		exit(json_encode($result));
		break;
	case 'chGameDesc':
		$sql = "update game_info set GameDesc = '$GameDesc' where gameid = '$gameid' ";
		$result = GameList::updateInfo($sql);
		exit(json_encode($result));
		break;
	default:
		# code...
		break;
}
Template::assign ('gamelist',$gamelist);
Template::display ('agent/gamelist.tpl');