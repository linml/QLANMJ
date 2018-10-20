<{include file ="ace/header.tpl"}>
<{include file ="ace/navibar.tpl"}>
<{include file ="ace/sidebar.tpl"}>

<!--- START 以上内容不需更改，保证该TPL页内的标签匹配即可 -->

<{$osadmin_action_alert}>
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
					<label><h1><strong id="RemainM">XX</strong>:<strong id="RemainS">XX</strong></h1></label>
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
		<div class="table-header">财务报表</div>
  		<table id="simple-table" class="table table-striped table-bordered table-hover">
			<thead>
				<tr>
					<th>创建时间</th>
					<th >开局数</th>
					<th >耗钻</th>
					<th>新增代理</th>
					<th>新增玩家</th>
					<th>邀请玩家</th>
					<th>玩家充值</th>
					<th>代理充钻</th>
					<th>代理提现</th>
				</tr>
			</thead>
			<tbody>
				<{foreach name=user from=$m_Report item=i_Report}>
				<tr>
					<td><{$i_Report.date|mb_substr:-5:5:'utf-8'}></td>
					<td><{$i_Report.room}></td>
					<td><{$i_Report.cost}></td>
					<td><{$i_Report.agent}></td>
					<td><{$i_Report.gamer}></td>
					<td><{$i_Report.invite}></td>
					<td><{$i_Report.cash}></td>
					<td><{$i_Report.dlexcard}></td>
					<td><{$i_Report.pay}></td>
				</tr>
				<{/foreach}>
			</tbody>
		</table>
		<!-- START 分页模板 -->
        <{$page_html}>
		<!-- END -->
	</div>
</div>

<!--操作的确认层，相当于javascript:confirm函数-->
<{$osadmin_action_confirm}>

<!-- END 以下内容不需更改，请保证该TPL页内的标签匹配即可 -->
<{include file="ace/footer.tpl" }>
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
		$("#m_type option[value='<{$_REQUEST.month}>']").attr('selected',true);
		    
	});

	function GetRTime(){        
		var runtimes = getCookie('runtimes');        
	    var nMS = <{$diffrentTime}> - runtimes;
	    //页面时间为0 自动刷新
	    if(nMS < 0) return;             
		var nM=Math.floor(nMS/60);        
		var nS=Math.floor(nMS) % 60;               
		document.getElementById("RemainM").innerHTML=nM;        
		document.getElementById("RemainS").innerHTML=nS;                
		runtimes++;
		Setcookie('runtimes',runtimes); 
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
    		url: '/houtai/agent/financeReport.php',
    		type: 'POST',
    		dataType: '',
    		data: {
    			method: 'redealTimeRightNow'
    		},
    		success:function(res){
    			res = jQuery.parseJSON(res);
    			if(res['result']=='OK'){
    				Setcookie('runtimes',0); 
    				window.location.reload();
    			}
    		},
    		error:function(){}
	    });
	}

</script>