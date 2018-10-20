<?php 
require ('../include/init.inc.php');
$userid = $page_no= $method='';
extract ( $_REQUEST, EXTR_IF_EXISTS );

$agentid     = UserSession::getAgentId();

if($method=='loadData'&&!empty($page_no)){
	$page_no = $page_no < 1 ? 1 : $page_no;
	$playersList = Players::getAllPlayersByAgentId($agentid,$userid,($page_no-1)*PAGE_SIZE,PAGE_SIZE);
	exit(json_encode($playersList));
}

// 获取代理绑定的玩家数量
$players_num = Players::getAgentBindPlayerCount($agentid);

/*// START数据库查询及分页数据
$page_size = PAGE_SIZE;
$page_no = $page_no < 1 ? 1 : $page_no;
$row_count = Players::getAllPlayersCountByAgentId($agentid,$playerid);

$total_page=$row_count%$page_size==0?$row_count/$page_size:ceil($row_count/$page_size);
$total_page=$total_page<1?1:$total_page;

$page_no = $page_no > ($total_page) ? ($total_page) : $page_no;
$start = ($page_no - 1) * $page_size;
$playersList = Players::getAllPlayersByAgentId($agentid,$playerid,$start,$page_size);
$page_html = Pagination::showPager ( "players.php", $page_no, $page_size, $row_count );
*/
Template::assign ( '_REQUEST', $_REQUEST );
Template::assign ( 'page_html', $page_html );
Template::assign ('players_num', $players_num);
Template::assign ('playersList', $playersList);
Template::display ( 'agentcenter/Players.tpl' );