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
				<{foreach name=user from=$m_Report item=i_Report}>
				<tr>
					<td><{$i_Report.date|mb_substr:-5:5:'utf-8'}></td>
					<td><{$i_Report.open}></td>
					<td><{$i_Report.gems}></td>
					<td><{$i_Report.register}></td>
					<td>---</td>
					<td><{$i_Report.active}></td>
					<td><{$i_Report.s_retention}></td>
					<td><{$i_Report.t_retention}></td>
					<td><{$i_Report.se_retention}></td>
					<td><{$i_Report.rechargeCount}></td>
					<td><{$i_Report.rechargeMoney}></td>
					<td><{$i_Report.n_rechargeCount}></td>
					<td><{$i_Report.n_rechargeMoney}></td>
					<td><{$i_Report.rate}>%</td>
					<td><{$i_Report.n_rate}>%</td>
					<td><{$i_Report.diamondThree}></td>
					<td><{$i_Report.diamondTwo}></td>
					<td><{$i_Report.diamondOne}></td>
					<td><{$i_Report.diamondFive}></td>
					<td><{$i_Report.n_diamondOne}></td>
					<td><{$i_Report.n_diamondFive}></td>
					<td><{$i_Report.n_diamondZero}></td>
					<td>---</td>
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
		var runtimes = getCookie('cencusReport');        
	    var nMS = <{$diffrentTime}> - runtimes;
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

</script>