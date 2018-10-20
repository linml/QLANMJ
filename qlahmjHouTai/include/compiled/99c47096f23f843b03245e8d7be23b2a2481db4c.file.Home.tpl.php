<?php /* Smarty version Smarty-3.1.15, created on 2018-10-10 12:17:43
         compiled from "F:\project\QLAHMJ\qlahmjHouTai\include\template\agentcenter\Home.tpl" */ ?>
<?php /*%%SmartyHeaderCode:289745bbd6f5733f7d9-04305187%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '99c47096f23f843b03245e8d7be23b2a2481db4c' => 
    array (
      0 => 'F:\\project\\QLAHMJ\\qlahmjHouTai\\include\\template\\agentcenter\\Home.tpl',
      1 => 1538044605,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '289745bbd6f5733f7d9-04305187',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'AgentsInfo' => 0,
    'agentMaidData' => 0,
    'agentBindData' => 0,
    'dateidArr' => 0,
    'activeData' => 0,
    'returnData' => 0,
    'maxReturn' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5bbd6f573e7776_49866044',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5bbd6f573e7776_49866044')) {function content_5bbd6f573e7776_49866044($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="N_Header">
    <div class="N_Header_title">代理首页</div>
</div>

<div class="N_Wrap">
    <div class="N_WrapAuto">
        <div class="N_Pad" style="margin-top: 54px">
            <div class="N_IndexC1">
                <div class="N_IndexC1Top">
                    <div class="N_IndexC1TopPad clearfix">
                        <div class="N_IndexC1TopImg fl">
                            <a href="/agentCenter/mine.php"><img src="<?php echo (($tmp = @$_smarty_tpl->tpl_vars['AgentsInfo']->value['picfile'])===null||$tmp==='' ? '/assets/avatars/tark.png' : $tmp);?>
"></a>
                        </div>
                        <div class="N_IndexC1TopName fl">
                            <div>
                                <ul>
                                    <li class="clearfix">
                                        <!-- <div class="fl">ID：</div> -->
                                        <div class="fl"><span class="text" id="gameId"><?php echo $_smarty_tpl->tpl_vars['AgentsInfo']->value['wechatname'];?>
</span></div>
                                    </li>
                                    <li class="clearfix ft10">
                                        <div class="fl">ID：</div>
                                        <div class="fl"><span class="text" id="fx_userid"><?php echo $_smarty_tpl->tpl_vars['AgentsInfo']->value['userid'];?>
</span></div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        
                    </div>
                </div>
                <div class="N_IndexC1Bottom clearfix">
                    <ul>
                        <li class="N_IndexC1BottomBox1">
                            <a href="/agentCenter/drawmoney.php">
                                <div class="N_IndexC1BottomT1">可提现余额</div>
                                <div class="N_IndexC1BottomT2">
                                    <span style="display: inline;"><?php echo (($tmp = @$_smarty_tpl->tpl_vars['AgentsInfo']->value['rmb'])===null||$tmp==='' ? 0 : $tmp);?>
&nbsp;&nbsp;</span>
                                    <span class="ft12 c_fff bq" style="display: inline;line-height: 16px">&nbsp;提现&nbsp;</span>
                                </div>
                            </a>
                        </li>
                        <li class="N_IndexC1BottomBox2">
                            <a href="/agentCenter/purchase.php">
                                <div class="N_IndexC1BottomT1">库存钻石</div>
                                <div class="N_IndexC1BottomT2">
                                    <span style="display: inline;"><?php echo round((($tmp = @$_smarty_tpl->tpl_vars['AgentsInfo']->value['diamond'])===null||$tmp==='' ? 0 : $tmp));?>
&nbsp;&nbsp;</span>
                                    <span class="ft12 c_fff bq" style="display: inline;line-height: 16px">&nbsp;进钻&nbsp;</span>
                                </div>
                            </a>
                        </li>
                    </ul>
                </div>
            </div>
            <div class="N_IndexC3">
                <ul>
                    <li class="relative N_IndexC3_li">
                        <img src="/assets/images/agentCenter/bg6c.png">
                        <div class="absolute N_IndexC3_tit" style="top:3%">我的收益</div>
                        <a href="javascript:void(0)">
                            <div class="absolute N_IndexC3_f1"><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agentMaidData']->value['todayMaid'])===null||$tmp==='' ? 0 : $tmp);?>
</div>
                            <div class="absolute N_IndexC3_btn1">今日返佣</div>
                         </a>
                        <a href="javascript:void(0)">
                            <div class="absolute N_IndexC3_f2"><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agentMaidData']->value['weeksMaid'])===null||$tmp==='' ? 0 : $tmp);?>
</div>
                            <div class="absolute N_IndexC3_btn2">本周返佣</div>
                        </a>
                        <a href="javascript:void(0)">
                            <div class="absolute N_IndexC3_f3"><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agentMaidData']->value['monthsMaid'])===null||$tmp==='' ? 0 : $tmp);?>
</div>
                            <div class="absolute N_IndexC3_btn3">本月返佣</div>
                        </a>
                    </li>
                    <!-- <li class="relative N_IndexC3_li" >
                        <a href="/agentCenter/inviteplayers.php" class="N_IndexC3_btn">邀请玩家</a>
                        <a href="/agentCenter/openagents.php" class="N_IndexC3_btn">开通代理</a>
                        <a href="/agentCenter/players.php" class="N_IndexC3_btn">玩家充钻</a>
                    </li> -->
                     <li class="relative N_IndexC3_li" >
                        <a href="/agentCenter/inviteplayers.php" class="N_IndexC3_btn" style="width:45%;margin-left: 3%">邀请玩家</a>
                        <a href="/agentCenter/players.php" class="N_IndexC3_btn" style="width:45%;margin-left: 3%">玩家充钻</a>
                    </li>
                     <li class="relative N_IndexC3_li">
                        <img src="/assets/images/agentCenter/bg6c.png">
                        <div class="absolute N_IndexC3_tit" style="top:3%">推广能力</div>
                                                <a href="javascript:void(0)">
                            <div class="absolute N_IndexC3_num1"></div>
                            <div class="absolute N_IndexC3_f1"><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agentBindData']->value['playerCount'])===null||$tmp==='' ? 0 : $tmp);?>
</div>
                            <div class="absolute N_IndexC3_btn1">绑定玩家</div>
                         </a>
                        <a href="javascript:void(0)">
                            
                            <div class="absolute N_IndexC3_f2"><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agentBindData']->value['agentCount'])===null||$tmp==='' ? 0 : $tmp);?>
</div>
                            <div class="absolute N_IndexC3_btn2">下级代理</div>
                        </a>
                        <a href="javascript:void(0)">
    
                            <div class="absolute N_IndexC3_f3"><?php echo (($tmp = @$_smarty_tpl->tpl_vars['agentBindData']->value['indirectPlayerCount'])===null||$tmp==='' ? 0 : $tmp);?>
</div>
                            <div class="absolute N_IndexC3_btn3">间接玩家</div>
                        </a>
                    </li> 
                    <!-- 此处放图 -->

                          <div id="container" style="height: 300px;width: 100%;background-color: #fff"></div>
                          <!-- <div id="echartu" style="height: 400px;width: 100%"></div> -->

                </ul>
            </div>
        </div>
    </div>
</div> 
</div>

<?php echo $_smarty_tpl->getSubTemplate ("simple_footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>

<script type="text/javascript">
var dateid = <?php echo $_smarty_tpl->tpl_vars['dateidArr']->value;?>
;
var activeData = <?php echo $_smarty_tpl->tpl_vars['activeData']->value;?>
;
var returnData = <?php echo $_smarty_tpl->tpl_vars['returnData']->value;?>
;
var maxReturn = <?php echo $_smarty_tpl->tpl_vars['maxReturn']->value;?>
;
var dom = document.getElementById("container");
var myChart = echarts.init(dom);
var app = {};
option = null;
option = {
    tooltip: {
        trigger: 'axis'
    },
    legend: {
        left:['left'],
        data:['日桌数','日返佣']
    },
    toolbox: {
        show: true,
        feature: {
            dataZoom: {
                yAxisIndex: 1
            },
            dataView: {readOnly: true},
            magicType: {type: ['bar']},
            restore: {},
        }
    },
    xAxis:  {
        type: 'category',        
        boundaryGap: false,
        data:dateid,
        axisLabel:{
            interval:0,
            rotate:-30,
        },
        axisLine:{
            lineStyle:{
                color:'#0087ed',
                width:1,
            }
        }
    },
    yAxis : [
                    {
                             type: 'value',
                             name: '日桌数',
                             position: 'left',
                             min:0,
                             max:'dataMax',
                                axisLabel: {
                                    formatter: '{value}'
                                }
                    },
                    {
                        type: 'value',
                        name: '日返佣',
                        min: 0,
                        max: maxReturn,
                        position: '',
                        axisLabel: {
                            formatter: '{value}'
                        }
                    },
                ],
    series: [
        {
            name:'日桌数',
            type:'line',
            data:activeData,
            markLine: {
                data: [
                    {type: 'average', name: '平均值'}
                ]
            }
        },
        {
            name:'日返佣',
            type:'line',
            data:returnData,
            markLine: {
                data: [
                    {type: 'average', name: '平均值'},
                    [{
                        symbol: 'none',
                        x: '90%',
                        yAxis: 'max'
                    }, {
                        symbol: 'circle',
                        label: {
                            normal: {
                                position: 'start',
                            }
                        },
                    }]
                ]
            }
        }
    ]
};
;
if (option && typeof option === "object") {
    myChart.setOption(option, true);
}
</script><?php }} ?>
