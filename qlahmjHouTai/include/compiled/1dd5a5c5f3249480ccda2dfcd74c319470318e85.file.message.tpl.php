<?php /* Smarty version Smarty-3.1.15, created on 2018-04-17 17:30:31
         compiled from "E:\hfmj.qilehuyu.cn\houtai\include\template\agent\message.tpl" */ ?>
<?php /*%%SmartyHeaderCode:115685ad5ac82c68e45-25183916%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '1dd5a5c5f3249480ccda2dfcd74c319470318e85' => 
    array (
      0 => 'E:\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\message.tpl',
      1 => 1523953676,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '115685ad5ac82c68e45-25183916',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5ad5ac82cb7056_55018787',
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'message' => 0,
    'osadmin_action_confirm' => 0,
  ),
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5ad5ac82cb7056_55018787')) {function content_5ad5ac82cb7056_55018787($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<!-- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>


<div class="row">
	<div class="col-xs-12">
		<form id="tab" method="post" action="" autocomplete="off" class="form-horizontal" role="form">
		
		 <div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">公告内容</label>
				<div class="col-sm-9">
					<textarea type="text" id="gonggao"  name=""  class="input-xlarge"  autofocus="true" rows="5" cols="40"><?php echo $_smarty_tpl->tpl_vars['message']->value;?>
</textarea>
				</div>
			</div>
			
		    <div class="form-group">
				<label class="col-sm-3 control-label no-padding-right">更新公告</label>
				<div class="col-sm-9">
					<textarea type="text" id="newgonggao" name="gonggao"  class="input-xlarge" autofocus="true" rows="5" cols="40" ></textarea>
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
<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>


<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


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

</script><?php }} ?>
