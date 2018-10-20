<{include file = "simple_header.tpl"}>

<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg5.png);">
    <div class="N_Header_title">代理商</div>
    
</div>
<div class="N_Wrap bottm60" style="margin-top: 50px">
    <div class="N_WrapAuto">
        <div class="N_bg">
            <div class="N_agentTop clearfix mgTp1A" style="background:url(/assets/images/agentCenter/bg9.png) no-repeat center top/100% auto;">
                <div class="C_wh50 floatL pd30">
                  <p class="ft25 c_fff"><{$agentCount}></p>
                  <p class="c_fff">下级代理</p>
                </div>
                <div class="C_wh50 floatL pd30">
                  <p class="ft25 c_fff"><{$playerCount}></p>
                  <p class="c_fff">绑定玩家</p>
                </div>
            </div>
            <div class="record_wrap clearfix wp_94 mgTp3A">
                <ul>
                </ul>
                <{$page_html}>
            </div>
        </div>
    </div>
</div>

<{include file = "simple_footer.tpl"}>

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
                  url: 'agents.php',
                  type: 'POST',
                  data:{'method':'loadData','page_no':1},
                  dataType: '',
                  success: function(data){
                      data = jQuery.parseJSON(data);
                      var arrLen = data.length;
                      var result = '';
                      result = dealData(data,arrLen);
                      // 为了测试，延迟1秒加载
                      setTimeout(function(){
                          $('.record_wrap>ul').html(result);
                          // 每次数据加载完，必须重置
                          me.resetload();
                          // // 重置页数，重新获取loadDownFn的数据
                          page = 1;
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
                  url: 'agents.php',
                  data:{'method':'loadData','page_no':page},
                  dataType: '',
                  success: function(data){
                      data = jQuery.parseJSON(data);
                      var arrLen = data.length;
                      if(arrLen > 0){
                         result = dealData(data,arrLen);
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

      function dealData(data,arrLen){
        result = "";
        for(var i = 0; i < arrLen; i++){
                          result +=   '<li class="relative C_wh_80 bgc_fff mgb2" style="border-radius: 5px"><img src="/assets/images/agentCenter/bg6cc.png"><div class="absolute N_IndexC3_tit">游戏ID:&nbsp;&nbsp;<i>'+data[i].userid+'</i></div><div class="wxavatar absolute left2 top20"><img src="'+data[i].picfile+'" width="45" height="45"></div><div class="absolute f_return left2 top74 inputbox2">'+data[i].nickname+'</div><div class="absolute ft20 left20 top43 inputbox1">'+data[i].name.substring(0,2)+'</div><div class="absolute f_return left20 top70 inputbox1">级别</div><div class="absolute ft20 top43 left50 inputbox1">'+data[i].binduser+'</div><div class="absolute f_return top70 left50 inputbox1">绑定玩家</div><div class="absolute left76 top39 bTn"><a class="c_fff" href="/agentCenter/sendmoney.php?gagentid='+data[i].userid+'">划拨</a></div><div class="absolute left89 top4"><a href="/agentCenter/agentsinfo.php?agentid='+data[i].agentid+'" style="height:80px;width:30px;display:block"><img src="/assets/images/agentCenter/singlearrow.svg" style="margin-top:29px" width="20" height="65"></a></div></li>';
                      }
        return result;
      }

  });
</script>