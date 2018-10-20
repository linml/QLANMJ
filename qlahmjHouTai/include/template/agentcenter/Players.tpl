<{include file = "simple_header.tpl"}>


<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg5.png);">
    <div class="N_Header_title">玩家</div>
</div>
<div class=" N_Wrap bottm60" >
    <div class="N_WrapAuto">
        <div class="N_bg">
            <div class="N_agentTop" style="background:url(/assets/images/agentCenter/bg9.png) no-repeat center top/100% auto;">
                <div class="N_agentTopNum"><span id="usercount"><{$players_num}></span></div>
                <div class="N_agentTopT1">我的玩家人数</div>
            </div>
            <div class="N_RecordTop wp_94 mgTp3A">
                <div class="clearfix">
                    <form action="" method="POST">
                        <div class="clearfix">
                             <input type="text" class="N_agentIpt MyAgent_input fl" placeholder="请输入玩家ID"  id="userid" min="0" name="userid" value="<{$_REQUEST['userid']}>">
                             <div class="N_RecordSub MyAgent_search fl"><button id="search" type="submit">查询</button></div>
                        </div>
                    </form>
                </div>
            </div>

            <div class="record_wrap N_RecordBottom N_RecordBottom2 clearfix  wp_94 mgTp3A">
             <ul>
                
             </ul>
           </div>
        </div>
        
    </div>
</div>

 
<{include file = "simple_footer.tpl"}>

<script>
  $(function(){
      dropload();

      $("#search").click(function(){
        // 删选条件已经到后台
        // dropload();
        $.ajax({
            url: 'players.php',
            type: 'POST',
            data:{'method':'loadData','page_no':1,'userid':$('#userid').val()},
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
                },500);
            },
            error: function(xhr, type){
                alert('Ajax error!');
            }
        });
      });
    function dropload(){
      // 页数
      var page = 0;
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
                  data:{'method':'loadData','page_no':1,'userid':$('#userid').val()},
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
                      },100);
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
                  data:{'method':'loadData','page_no':page,'userid':$('#userid').val()},
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
                      },100);
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
    }

    function dealData(data,arrLen){
      result = "";
      for(var i=0; i<arrLen; i++){
                              result +=   '<li class="relative C_wh_80 bgc_fff mgb2" style="border-radius: 5px"><img src="/assets/images/agentCenter/bg6cc.png"><div class="absolute N_IndexC3_tit">游戏ID:&nbsp;&nbsp;<i>'+data[i].userid+'</i></div><div class="wxavatar absolute left2 top20"><img src="'+data[i].picfile+'" width="45" height="45"></div><div class="absolute f_return left2 top74 inputbox2">'+data[i].nickname+'</div><div class="absolute ft20 left20 top43 inputbox1">'+data[i].cnt+'</div><div class="absolute f_return left20 top70 inputbox1">游戏次数</div><div class="absolute ft20 top43 left50 inputbox1">'+Math.round(data[i].diamond)+'</div><div class="absolute f_return top70 left50 inputbox1">钻石</div><div class="absolute left76 top39 bTn"><a class="c_fff" href="/agentCenter/gemsrecharge.php?userid='+data[i].userid+'">充钻</a></div><div class="absolute left89 top4"><a href="/agentCenter/playersinfo.php?userid='+data[i].userid+'" style="height:80px;width:30px;display:block"><img src="/assets/images/agentCenter/singlearrow.svg" style="margin-top:29px" width="20" height="65"></a></div></li>';
                          }
      return result;
    }
    
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