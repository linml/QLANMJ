<{include file = "simple_header.tpl"}>

<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg5.png);">
   <a href="javascript:history.go(-1);" class="ReturnUp">返回首页</a>

    <div class="N_Header_title">代理</div>
   <!--  <a href="/dlIndex.php?m=Index&c=toMyAgent&a=toAddMyAgent" class="N_czMore">开通</a> -->
</div>
<div class="N_Wrap bottm60">
    <div class="N_WrapAuto">
        <div class="N_bg" >
            <div class="N_agentTop" style="background:url(/assets/images/agentCenter/bg9.png) no-repeat center top/100% auto;">
                <div class="N_agentTopNum"><span><?echo $allData_count?></span>人</div>
                <div class="N_agentTopT1">我绑定的代理</div>
            </div>
            <div class="N_Pad" style="margin-top: 17px">
                <div class="N_RecordTop wp_94 mgTp3A">
                    <div class="clearfix">
                    <form action="toRecommendedAward#">
                        <!-- <div class="clearfix"></div> -->
                        <div class="clearfix">
                            <!-- <input type="text" class="N_RecordTime" name="start_date" id="startDate" placeholder="选择开始日期" readonly="readonly" />
                            <input type="text" class="N_RecordTime" name="end_date" id="endDate" placeholder="选择结束日期" readonly="readonly" /> -->
                            <input type="number" class="N_agentIpt MyAgent_input fl" placeholder="请输入代理ID"  id="gameUserId" min="0">
                            <div class="N_RecordSub MyAgent_search fl"><button id="search" type="button">查询</button></div> 
                        </div>
                    </form>     
                    </div>
                </div>
                <div class="record_wrap N_RecordBottom N_RecordBottom2 wp_94 mgTp3A">
                    <ul class="wp_full record_tit clearfix">
                        <li class="wp_25 borderBox fl textLeft">代理</li>
                        <li class="wp_20 borderBox fl textLeft">级别</li>
                        <li class="wp_35 borderBox fl textLeft">登录账号</li>
                        <li class="wp_20 borderBox fl textRight">邀请</li>
                    </ul>
                    <table id="example" class="fourCol" aria-describedby="example_info" role="grid">
                        <tbody role="alert" aria-live="polite" aria-relevant="all">
                        <tr>
                            <!-- 金牌颜色class：c_ff5d20；铂金颜色class：c_039cfe -->
                        </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    </div>
</div>

<{include file = "simple_footer.tpl"}>