<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
		
		 <div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">关闭房间提示
</label>
				<div class="col-sm-9">
					<textarea style="height: 200px;" maxlength="1024" placeholder="通知内容不为空，则无法创建房间。" type="text" id="server_maintenance"  name="server_maintenance"  class="input-xlarge"  autofocus="true" ><{$message.server_maintenance.key_value}></textarea>
				</div>
			</div>

			
			
			<div class="form-group">
				<div class="col-md-offset-3 col-md-9">
					<button class="btn btn-info" type="submit">提交</button>
				</div>
			</div>
			<div style="clear:both;"></div>
		</form>
	</div>
</div>


				
<!---操作的确认层，相当于javascript:confirm函数--->
<{$osadmin_action_confirm}>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>

<script type="text/javascript">
	
	$("#touch_a").keyup(function(){    
		
        var tmptxt=$(this).val();
        if(tmptxt!='0')		
        $(this).val(tmptxt.replace(/\D|^0/g,''));     
    }).bind("paste",function(){     
        var tmptxt=$(this).val();     
        $(this).val(tmptxt.replace(/\D|^0/g,''));     
    }).css("ime-mode", "disabled"); 
	
$("#touch_b").keyup(function(){    
		
        var tmptxt=$(this).val();
        if(tmptxt!='0')		
        $(this).val(tmptxt.replace(/\D|^0/g,''));     
    }).bind("paste",function(){     
        var tmptxt=$(this).val();     
        $(this).val(tmptxt.replace(/\D|^0/g,''));     
    }).css("ime-mode", "disabled"); 
    
$("#touch_c").keyup(function(){    
	
    var tmptxt=$(this).val();
    if(tmptxt!='0')		
    $(this).val(tmptxt.replace(/\D|^0/g,''));     
}).bind("paste",function(){     
    var tmptxt=$(this).val();     
    $(this).val(tmptxt.replace(/\D|^0/g,''));     
}).css("ime-mode", "disabled"); 

</script>