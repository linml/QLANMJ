<?php /* Smarty version Smarty-3.1.15, created on 2018-08-13 16:03:37
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\players.tpl" */ ?>
<?php /*%%SmartyHeaderCode:201375b712d49443cf6-58717027%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'dcc0f719029951c7e3f7b5db08ea98f922e48cb2' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\players.tpl',
      1 => 1534143085,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '201375b712d49443cf6-58717027',
  'function' => 
  array (
  ),
  'variables' => 
  array (
    'players_num' => 0,
    '_REQUEST' => 0,
  ),
  'has_nocache_code' => false,
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b712d49453707_71346313',
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b712d49453707_71346313')) {function content_5b712d49453707_71346313($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>



<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg5.png);">
    <div class="N_Header_title">玩家</div>
</div>
<div class="N_Wrap bottm60" >
    <div class="N_WrapAuto">
        <div class="N_bg">
            <div class="N_agentTop" style="background:url(/assets/images/agentCenter/bg9.png) no-repeat center top/100% auto;">
                <div class="N_agentTopNum"><span id="usercount"><?php echo $_smarty_tpl->tpl_vars['players_num']->value;?>
</span></div>
                <div class="N_agentTopT1">我的玩家人数</div>
            </div>
            <div class="N_RecordTop wp_94 mgTp3A">
                <div class="clearfix">
                    <!-- <form action="" method="POST"> -->
                        <div class="clearfix">
                             <input type="text" class="N_agentIpt MyAgent_input fl" placeholder="请输入玩家ID"  id="userid" min="0" name="playerid" value="<?php echo $_smarty_tpl->tpl_vars['_REQUEST']->value['playerid'];?>
">
                             <div class="N_RecordSub MyAgent_search fl"><button id="search" type="submit">查询</button></div> 
                        </div>
                    <!-- </form>       -->
                </div>
            </div>

            <div class="record_wrap N_RecordBottom N_RecordBottom2 clearfix  wp_94 mgTp3A">
              <ul>

              </ul>
            </div>
        </div>

    </div>
</div>

<?php echo $_smarty_tpl->getSubTemplate ("simple_footer.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<script>
  $(function(){
      // 页数
      var page = 0;
      // 每页展示10个
      var size = 10;

      // dropload
      $('.record_wrap').dropload({
          scrollArea : window,
          domUp : {
              domClass   : 'dropload-up',
              domRefresh : '<div class="dropload-refresh">↓下拉刷新</div>',
              domUpdate  : '<div class="dropload-update">↑释放更新</div>',
              domLoad    : '<div class="dropload-load"><span class="loading"></span>加载中...</div>'
          },
          domDown : {
              domClass   : 'dropload-down',
              domRefresh : '<div class="dropload-refresh">↑上拉加载更多</div>',
              domLoad    : '<div class="dropload-load"><span class="loading"></span>加载中...</div>',
              domNoData  : '<div class="dropload-noData">暂无数据</div>'
          },
          loadUpFn : function(me){
              $.ajax({
                  url: 'players.php',
                  type: 'POST',
                  data:{'method':'loadData','page_no':1},
                  dataType: '',
                  success: function(data){
                      data = jQuery.parseJSON(data);
                      var arrLen = data.length;
                      var result = '';
                      for(var i = 0; i < arrLen; i++){
                          //result +=   '<li class="relative C_wh bgc_fff mgb10"><img src="/assets/images/agentCenter/bg6.png"><div class="absolute N_IndexC3_tit">游戏ID:&nbsp;&nbsp;<i>'+data[i].userid+'</i></div><div class="wxavatar absolute left5 top20"><img src="/assets/avatars/avatar3.png" width="45" height="45"><img src="'+data[i].picfile+'" width="45" height="45"></div><div class="absolute f_return left5 top97">'+data[i].nickname+'</div><div class="absolute ft20 left32<div class="absolute f_return left30 top97">游戏次数</div><div class="absolute ft20 top43 left49">'+data[i].diamond+'</div><div class="absolute f_return top97 left50">钻石</div><div class="absolute left70 top54 bTn"><a class="c_fff" href="/agentCenter/gemsrecharge.php?userid='+data[i].userid+'">充值</a></div><div class="absolute left89 top54"><a href="/agentCenter/playersinfo.php?playerid='+data[i].userid+'"><img src="/assets/images/agentCenter/doublearrow.svg" width="30" height="30"></a></div></li>';
                          result+="<li style='height:50px ;background-color:#cccc;margin-top:10px;'>"+i+"</li>";
                      }
                      // 为了测试，延迟1秒加载
                      setTimeout(function(){
                          $('.record_wrap>ul').html(result);
                          // 每次数据加载完，必须重置
                          me.resetload();
                          // // 重置页数，重新获取loadDownFn的数据
                          page = 0;
                          // 解锁loadDownFn里锁定的情况
                          me.unlock();
                          me.noData(false);
                      },500);
                  },
                  error: function(xhr, type){
                      alert('Ajax error!');
                      // 即使加载出错，也得重置
                      me.resetload();
                  }
              });
          },
          loadDownFn : function(me){
              page++;
              // 拼接HTML
              var result = '';
              $.ajax({
                  type: 'GET',
                  url: 'players.php',
                  data:{'method':'loadData','page_no':page},
                  dataType: '',
                  success: function(data){
                      data = jQuery.parseJSON(data);
                      var arrLen = data.length;
                      if(arrLen > 0){
                          for(var i=0; i<arrLen; i++){
                              //result +=   '<li class="relative C_wh bgc_fff mgb10"><img src="/assets/images/agentCenter/bg6.png"><div class="absolute N_IndexC3_tit">游戏ID:&nbsp;&nbsp;<i>'+data[i].userid+'</i></div><div class="wxavatar absolute left5 top20"><img src="/assets/avatars/avatar3.png" width="45" height="45"><img src="'+data[i].picfile+'" width="45" height="45"></div><div class="absolute f_return left5 top97">'+data[i].nickname+'</div><div class="absolute ft20 left32<div class="absolute f_return left30 top97">游戏次数</div><div class="absolute ft20 top43 left49">'+data[i].diamond+'</div><div class="absolute f_return top97 left50">钻石</div><div class="absolute left70 top54 bTn"><a class="c_fff" href="/agentCenter/gemsrecharge.php?userid='+data[i].userid+'">充值</a></div><div class="absolute left89 top54"><a href="/agentCenter/playersinfo.php?playerid='+data[i].userid+'"><img src="/assets/images/agentCenter/doublearrow.svg" width="30" height="30"></a></div></li>';
                              result+="<li style='height:50px ;background-color:#cccc;margin-top:10px;'>"+i+"</li>";
                          }
                      // 如果没有数据
                      }else{
                          // 锁定
                          me.lock();
                          // 无数据
                          me.noData();
                      }
                      // 为了测试，延迟1秒加载
                      setTimeout(function(){
                          // 插入数据到页面，放到最后面
                          $('.record_wrap>ul').append(result);
                          // 每次数据插入，必须重置
                          me.resetload();
                      },500);
                  },
                  error: function(xhr, type){
                      alert('Ajax error!');
                      // 即使加载出错，也得重置
                      me.resetload();
                  }
              });
          },
          threshold : 50
      });
  });
</script>

<script type="text/javascript">
  $(function(){
    var oHeight = $(document).height();
    $(window).resize(function(){
      if($(document).height() < oHeight){
        $('.N_Footer').css('height','0')
      }else{
        $('.N_Footer').css('height','50')
      }
    })
  })
</script>
<?php }} ?>
