<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class Message extends Base {
	
	/**
	 * [getMessageList 获取公告列表]
	 * @Author   李龙
	 * @DateTime 2018-09-26T17:50:23+0800
	 * @return   [type]                   [description]
	 */
	public static function getMessageList(){
		$db = self::__instance();
		$sql = 'SELECT
					id,
					title,
					content,
					addtime,
					begintime,
					endtime,
					msgobject
				FROM
					msg_content
				WHERE		
					msgstatus = "1" ORDER BY addtime DESC ';
		$result = $db->query($sql)->fetchAll(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [getMessageById 通过ID查询公告信息]
	 * @Author   李龙
	 * @DateTime 2018-09-27T11:52:24+0800
	 * @param    [type]                   $id [description]
	 * @return   [type]                       [description]
	 */
	public static function getMessageById($id){
		if(empty($id)) return ;
		$db = self::__instance();
		$sql = 'SELECT
					id,
					title,
					content,
					begintime,
					endtime,
					msgobject
				FROM
					msg_content
				WHERE

					msgstatus = "1" and id = '.$id;
		$result = $db->query($sql)->fetch(PDO::FETCH_ASSOC);
		if($result) return $result;else return array();
	}

	/**
	 * [editMessage 编辑公告信息并更新]
	 * @Author   李龙
	 * @DateTime 2018-09-27T14:18:30+0800
	 * @param    [type]                   $id        [description]
	 * @param    [type]                   $title     [description]
	 * @param    [type]                   $content   [description]
	 * @param    [type]                   $begintime [description]
	 * @param    [type]                   $endtime   [description]
	 * @return   [type]                              [description]
	 */
	public static function editMessage($id,$title,$content,$begintime,$endtime,$object){
		if(empty($id)||empty($title)||empty($content)||empty($begintime)||empty($endtime)||empty($object)) return ;
		if($begintime > $endtime) return ;
		$db = self::__instance();
		$sql = "UPDATE msg_content
				SET begintime = '$begintime',
				 endtime = '$endtime',
				 title = '$title',
				 content = '$content',
				 msgobject = '$object'
				WHERE
					id = '$id'";
		return 0 + $db->exec($sql);
	}

	/**
	 * [delMessage 删除公告]
	 * @Author   李龙
	 * @DateTime 2018-09-27T14:19:02+0800
	 * @param    [type]                   $id [description]
	 * @return   [type]                       [description]
	 */
	public static function delMessage($id){
		if(empty($id)) return;
		$db = self::__instance();
		$sql = "UPDATE msg_content
				SET msgstatus = '0'
				WHERE 
					id = '$id'
				";
		return 0 + $db->exec($sql);
	}

	/**
	 * [addMessage 添加公告信息]
	 * @Author   李龙
	 * @DateTime 2018-09-27T17:04:42+0800
	 * @param    [type]                   $title     [description]
	 * @param    [type]                   $content   [description]
	 * @param    [type]                   $begintime [description]
	 * @param    [type]                   $endtime   [description]
	 * @param    [type]                   $object    [description]
	 */
	public static function addMessage($title,$content,$begintime,$endtime,$object){
		if(empty($title)||empty($content)||empty($begintime)||empty($endtime)||empty($object)) return ;
		if($begintime > $endtime) return ;
		$db = self::__instance();
		$sql = "INSERT INTO msg_content (
					msgobject,
					msgstatus,
					addtime,
					begintime,
					endtime,
					title,
					content
				)
				VALUES
					(	
						'$object',
						'1',
						SYSDATE(),
						'$begintime',
						'$endtime',
						'$title',
						'$content'
				)";
		return 0 + $db->exec($sql);
	}

	public static function getPdata(){
		$db = self::__instance();
		$sql = "";
	}

	public static function getYdata(){
		$db = self::__instance();
		$sql = "";
	}

	public static function UpdatePY(){

	}
}