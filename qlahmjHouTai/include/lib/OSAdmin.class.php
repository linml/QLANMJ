<?php
if(!defined('ACCESS')) {exit('Access denied.');}

class OSAdmin extends Base {
	
	public static function alert($type,$message=""){
		if($message == "") {
			switch(strtolower($type)){
				case "success":
					$message=ErrorMessage::SUCCESS;
					break;
				case "error" :
					$message=ErrorMessage::ERROR;
					break;
			}
		}
		$alert_html="<div class=\"alert alertos alert-$type\" role=\"alert\"><button type=\"button\" class=\"close\" data-dismiss=\"alert\">×</button>$message</div>";
		Template::assign("osadmin_action_alert",$alert_html);
	}
	
	public static function renderJsConfirm($class,$confirm_title="确定要这样做吗？"){
		$confirm_html="<script>";
		if(!is_array($class)){
			$class=explode(',',$class);
		}
		foreach($class as $item){
			$confirm_html .= "
				$('.$item').click(function(){
					var href=$(this).attr('href');
					bootbox.confirm('$confirm_title', function(result) {
						if(result){
							location.replace(href);
						}
					});		
				})";
		}
		$confirm_html.="</script>";	
		return $confirm_html;
	}
	
}