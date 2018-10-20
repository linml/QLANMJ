<?php
if (! defined ( 'ACCESS' )) {
	exit ( 'Access denied.' );
}
class Shoping extends Base {
	//获取所有商城信息
	public static function getAllShopingInfo(){
		$db = self::__instance ();
		$sql = "select s.id,s.name,s.price,s.gems,s.discount,s.state from osa_t_shop s";
		$list = $db->query ( $sql )->fetchAll();
		if ($list) {
			return $list;
		}
		return array ();
	}
	//更新商城信息
	public static function updateShopInfo($shop_id,$data){
		if (! $data || ! is_array ( $data ))return false;
		$db = self::__instance();
		$condition = array(
			"id" => $shop_id
		);
		$id = $db->update("osa_t_shop",$data,$condition);
		//STools::log("\nid".$id);
		return $id;
	}
	//查询商品数量
	public static function  getAllShopingsCount(){
		$db=self::__instance();
		return 0+($db.query("selct count(*) from osa_t_shop")->fetchColumn ());
	}

}