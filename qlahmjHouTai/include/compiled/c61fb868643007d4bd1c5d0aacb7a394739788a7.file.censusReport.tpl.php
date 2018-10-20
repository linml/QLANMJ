<?php /* Smarty version Smarty-3.1.15, created on 2018-06-09 15:21:16
         compiled from "F:\project\hfmj.qilehuyu.cn\houtai\include\template\agent\censusReport.tpl" */ ?>
<?php /*%%SmartyHeaderCode:295245b1b71dc732cf4-39305810%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'c61fb868643007d4bd1c5d0aacb7a394739788a7' => 
    array (
      0 => 'F:\\project\\hfmj.qilehuyu.cn\\houtai\\include\\template\\agent\\censusReport.tpl',
      1 => 1525846167,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '295245b1b71dc732cf4-39305810',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'osadmin_action_alert' => 0,
    'm_Report' => 0,
    'i_Report' => 0,
    'page_html' => 0,
    'osadmin_action_confirm' => 0,
    '_REQUEST' => 0,
    'diffrentTime' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b1b71dc7c7428_30509519',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b1b71dc7c7428_30509519')) {function content_5b1b71dc7c7428_30509519($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("ace/header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/navibar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<?php echo $_smarty_tpl->getSubTemplate ("ace/sidebar.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<!--- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<?php echo $_smarty_tpl->tpl_vars['osadmin_action_alert']->value;?>

<style>
.ui-datepicker td>a, .ui-datepicker td>span {
	min-width: auto;
}
</style>
<div class="row">
	<div class="col-xs-12">
		<div id="search" class="collapse in">
		<form action="" method="GET" class="form-horizontal" role="form">
			<div class="form-group">
				<div class="col-md-offset-3 col-md-9">
					<select name="month" id="m_type"></select>
					<button class="btn btn-info" type="submit">检索</button>
				</div>
			</div>
			<div class="form-group">
				<div class="col-md-offset-3 col-md-9">
					<label><h1><strong id="c_RemainM">XX</strong>:<strong id="c_RemainS">XX</strong></h1></label>
					<button class="btn btn-info" onclick='refreshCashData()' >刷新</button>
				</div>
			</div>
			<div style="clear:both;"></div>
		</form>
		</div>
	</div>
</div>	


<div class="row">
	<div class="col-xs-12">
		<div class="table-header">数据统计</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					
					<th>创建时间</th>
					<th >开局数</th>
					<th >耗钻</th>
					<th>注册</th>
					<th>登录</th>
					<th>活跃</th>
					<th>次留</th>
					<th>三留</th>
					<th>七留</th>
					<th>充值人数</th>
					<th>充值金额</th>
					<th>新增充值人数</th>
					<th>新增充值金额</th>
					<th>付费率</th>
					<th>新增付费率</th>
					<th>钻石消耗>300</th>
					<th>钻石消耗>200</th>
					<th>钻石消耗>100</th>
					<th>钻石消耗>50</th>
					<th>新增用户钻石消耗>100</th>
					<th>新增用户钻石消耗>50</th>
					<th>新增用户钻石消耗=0</th>
					<th>同时在线人数</th>
				</tr>
			</thead>
			<tbody>
				<?php  $_smarty_tpl->tpl_vars['i_Report'] = new Smarty_Variable; $_smarty_tpl->tpl_vars['i_Report']->_loop = false;
 $_from = $_smarty_tpl->tpl_vars['m_Report']->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
foreach ($_from as $_smarty_tpl->tpl_vars['i_Report']->key => $_smarty_tpl->tpl_vars['i_Report']->value) {
$_smarty_tpl->tpl_vars['i_Report']->_loop = true;
?>
				<tr>
					<td><?php echo mb_substr($_smarty_tpl->tpl_vars['i_Report']->value['date'],-5,5,'utf-8');?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['open'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['gems'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['register'];?>
</td>
					<td>---</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['active'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['s_retention'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['t_retention'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['se_retention'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['rechargeCount'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['rechargeMoney'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['n_rechargeCount'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['n_rechargeMoney'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['rate'];?>
%</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['n_rate'];?>
%</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['diamondThree'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['diamondTwo'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['diamondOne'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['diamondFive'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['n_diamondOne'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['n_diamondFive'];?>
</td>
					<td><?php echo $_smarty_tpl->tpl_vars['i_Report']->value['n_diamondZero'];?>
</td>
					<td>---</td>
				</tr>
				<?php } ?>
			</tbody>
		</table>
		<!-- START 分页模板 -->
        <?php echo $_smarty_tpl->tpl_vars['page_html']->value;?>

		<!-- END -->
	</div>
</div>

<!--操作的确认层，相当于javascript:confirm函数-->
<?php echo $_smarty_tpl->tpl_vars['osadmin_action_confirm']->value;?>


<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<?php echo $_smarty_tpl->getSubTemplate ("ace/footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<script>
	$(function() {
		//设置传入的select 的值设置默认选项
		var mydate = new Date();
		var year =mydate.getFullYear(); 
		var month = mydate.getMonth()+1;
		while(month > 0){
			$('#m_type').append("<option value="+month+"> "+year+" 年 "+month+" 月 </option>");
			month--;
		}
		$("#m_type option[value='<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['month'];?>
']").attr('selected',true);
		    
	});

	function GetRTime(){        
		var runtimes = getCookie('cencusReport');        
	    var nMS = <?php echo $_smarty_tpl->tpl_vars['diffrentTime']->value;?>
 - runtimes;
	    //页面时间为0 自动刷新
	    if(nMS < 0) return;             
		var nM=Math.floor(nMS/60);        
		var nS=Math.floor(nMS) % 60;               
		document.getElementById("c_RemainM").innerHTML=nM;        
		document.getElementById("c_RemainS").innerHTML=nS;                
		runtimes++;
		Setcookie('cencusReport',runtimes); 
		if(nMS==0){
	    	refreshCashData();
	    }

		setTimeout("GetRTime()",1000);        
	}    
	window.onload=GetRTime;

	function Setcookie (name, value){ 
	    var expdate = new Date();   //初始化时间
	    expdate.setTime(expdate.getTime() + 30 * 60 * 1000);   //时间
	    document.cookie = name+"="+value+";expires="+expdate.toGMTString()+";path=/";
	}

	function getCookie(c_name){
		if (document.cookie.length>0){
			c_start=document.cookie.indexOf(c_name + "=")
		  	if (c_start!=-1){ 
			    c_start=c_start + c_name.length+1 
			    c_end=document.cookie.indexOf(";",c_start)
			    if (c_end==-1) c_end=document.cookie.length
			    return unescape(document.cookie.substring(c_start,c_end))
		    } 
		}
		return 0;
	}

	function refreshCashData(){
		$.ajax({
    		url: '/houtai/agent/censusReport.php',
    		type: 'POST',
    		dataType: '',
    		data: {
    			method: 'redealTimeRightNow'
    		},
    		success:function(res){
    			res = jQuery.parseJSON(res);
    			if(res['result']=='OK'){
    				Setcookie('cencusReport',0); 
    				window.location.reload();
    			}
    		},
    		error:function(){}
	    });
	}

</script><?php }} ?>
