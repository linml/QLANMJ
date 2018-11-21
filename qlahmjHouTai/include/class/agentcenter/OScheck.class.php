<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class OScheck extends Base {
	public static function checkOSisAgentByUnionId($unionid=''){
		if(empty($unionid)) return;
		$db = self::__instance();
		$sql = 'SELECT
					ai.agentid,ai.status
				FROM
					agent_info ai
				LEFT JOIN user_snsinfo us ON ai.userid = us.userid
				WHERE
					us.unionId = "'.$unionid.'"';
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}
}