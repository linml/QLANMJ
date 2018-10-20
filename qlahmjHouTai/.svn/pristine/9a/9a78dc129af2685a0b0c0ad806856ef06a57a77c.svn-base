<?php
require ('../include/init.inc.php');
extract ( $_REQUEST,EXTR_IF_EXISTS );
$gamelist = GameList::getGamelist();

Template::assign ('gamelist',$gamelist);
Template::display ('agent/gamelist.tpl');