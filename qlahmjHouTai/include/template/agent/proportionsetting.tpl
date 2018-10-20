<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>
<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>

<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
		
		   <div class="form-group">
				<label class="col-sm-3 control-label no-padding-right"><b>区域经理提成</b></label>
				<div class="col-sm-9">
					<input maxlength="4" type="text" id="are_manager_t"  name="are_manager_t" value="<{$level.are_manager_t}>" class="input-xlarge" required="true" autofocus="true" >
				</div>
		   </div>
		   <div class="form-group">
				<label class="col-sm-3 control-label no-padding-right" ><b>三级提成</b></label>
				<div class="col-sm-9"  style="display:none;">
					<input name="t_level"   type="radio" value="3"
					required="true" 
					 <{if $level.t_level==3}>
					 checked="checked"
					<{else}>
					
					<{/if}>
					
					  required="true" />
                </div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">上三级提成比例</label>
				<div class="col-sm-9">
					<input maxlength="4" type="text" id="old_manager_t_manager_a" name="old_manager_t_manager_a" value="<{$level.old_manager_t_manager_a}>" class="input-xlarge" required="true" autofocus="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">上二级提成比例</label>
				<div class="col-sm-9">
					<input maxlength="4" type="text" id="manager_t_manager_a"  name="manager_t_manager_a" value="<{$level.manager_t_manager_a}>" class="input-xlarge" required="true" autofocus="true" >
				</div>
			</div>
			<div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">上一级提成比例</label>
				<div class="col-sm-9">
					<input maxlength="4" type="text" id="manager_t_player_a"  name="manager_t_player_a" value="<{$level.manager_t_player_a}>" class="input-xlarge" required="true" autofocus="true" >
				</div>
			</div>
			
			
			 <div class="form-group" >
				<label class="col-sm-3 control-label no-padding-right"><b>二级提成</b></label>
				<div class="col-sm-9" style="display:none;">
					<input name="t_level" type="radio" value="2"  required="true"
					
					 <{if $level.t_level==2}>
					 checked="checked"
					<{else}>
					
					<{/if}>
					
					 />
                </div>
			</div>
			
			<div class="form-group" >
				<label class="col-sm-3 control-label no-padding-right">上二级提成比例</label>
				<div class="col-sm-9">
					<input maxlength="4" type="text" id="manager_t_manager_b"  name="manager_t_manager_b" value="<{$level.manager_t_manager_b}>" class="input-xlarge" required="true" autofocus="true" >
				</div>
			</div>
			<div class="form-group" >
				<label class="col-sm-3 control-label no-padding-right">上一级提成比例</label>
				<div class="col-sm-9">
					<input maxlength="4" type="text" id="manager_t_player_b"  name="manager_t_player_b" value="<{$level.manager_t_player_b}>" class="input-xlarge" required="true" autofocus="true" >
				</div>
			</div>
			
			<div class="form-group" >
				<label class="col-sm-3 control-label no-padding-right"><b>一级提成</b></label>
				<div class="col-sm-9" style="display:none;">
					<input name="t_level" type="radio" value="2"  required="true"
					
					 <{if $level.t_level==2}>
					 checked="checked"
					<{else}>
					
					<{/if}>
					
					 />
                </div>
			</div>
			
			<div class="form-group" >
				<label class="col-sm-3 control-label no-padding-right">上一级提成比例</label>
				<div class="col-sm-9">
					<input maxlength="4" type="text" id="manager_t_player_c"  name="manager_t_player_c" value="<{$level.manager_t_player_c}>" class="input-xlarge" required="true" autofocus="true" >
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
	
	$("#old_manager_t_manager_a").keyup(function(){    
		
        var tmptxt=$(this).val();
        if(tmptxt!='0')		
        $(this).val(tmptxt.replace(/\D|^0/g,''));     
    }).bind("paste",function(){     
        var tmptxt=$(this).val();     
        $(this).val(tmptxt.replace(/\D|^0/g,''));     
    }).css("ime-mode", "disabled"); 
$("#manager_t_manager_a").keyup(function(){    
		
        var tmptxt=$(this).val();
        if(tmptxt!='0')		
        $(this).val(tmptxt.replace(/\D|^0/g,''));     
    }).bind("paste",function(){     
        var tmptxt=$(this).val();     
        $(this).val(tmptxt.replace(/\D|^0/g,''));     
    }).css("ime-mode", "disabled");    
$("#manager_t_player_a").keyup(function(){    
	
    var tmptxt=$(this).val();
    if(tmptxt!='0')		
    $(this).val(tmptxt.replace(/\D|^0/g,''));     
}).bind("paste",function(){     
    var tmptxt=$(this).val();     
    $(this).val(tmptxt.replace(/\D|^0/g,''));     
}).css("ime-mode", "disabled");    

$("#manager_t_manager_b").keyup(function(){    
	
    var tmptxt=$(this).val();
    if(tmptxt!='0')		
    $(this).val(tmptxt.replace(/\D|^0/g,''));     
}).bind("paste",function(){     
    var tmptxt=$(this).val();     
    $(this).val(tmptxt.replace(/\D|^0/g,''));     
}).css("ime-mode", "disabled");    
$("#manager_t_player_b").keyup(function(){    

var tmptxt=$(this).val();
if(tmptxt!='0')		
$(this).val(tmptxt.replace(/\D|^0/g,''));     
}).bind("paste",function(){     
var tmptxt=$(this).val();     
$(this).val(tmptxt.replace(/\D|^0/g,''));     
}).css("ime-mode", "disabled");    

$("#are_manager_t").keyup(function(){    

	var tmptxt=$(this).val();
	if(tmptxt!='0')		
	$(this).val(tmptxt.replace(/\D|^0/g,''));     
	}).bind("paste",function(){     
	var tmptxt=$(this).val();     
	$(this).val(tmptxt.replace(/\D|^0/g,''));     
	}).css("ime-mode", "are_manager_t"); 
</script>