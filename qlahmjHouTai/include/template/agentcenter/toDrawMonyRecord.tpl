<{include file = "simple_header.tpl"}>
<style type="text/css">
    .demo {
        height: 35px;
        margin: 15px 0;
        display: flex;
        display: -webkit-flex;
        display: -moz-flex;
    }
    
    .demo >input {
        display: block;
        border: 0;
        border-radius: 3px;
        padding: 0 8px;
        height: 75%;
        flex: 1;
        -webkit-flex: 1;
        -moz-flex: 1;
        font-size: 14px;
        width:75%;
        background-color: transparent;
    }
    
    .demo >button {
        background-color: #00c599;
        color: #fff;
        border: 0;
        height: 100%;
        margin-left: 8px;
        padding: 0 15px;
        border-radius: 3px;
        font-size: 14px;
    }
    </style>
<div class="" style="margin-top: 50px">
<div class="N_Header" style="background-image:url( /assets/images/agentCenter/headerBg4.png );">
    <a href="/agentCenter/mine.php" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">提现记录</div>
</div>

<div class="CM">
  <div class="C_wh pdT15 relative">
    <p class="ft20 mgB10" id="dateTime" style="margin-left: 20px"></p>
    <div class="relative S_wh bgc_0d86e6 round absolute top22 right6" id="dateSelectorOne">

      <div class="demo">
                <form id="form" method="POST" action="">
          <input class="absolute left12 top12"  type="hidden" name="endDate" id="endDate">
                </form>
          <img class="absolute mCenter mg_lt" src="/assets/images/agentCenter/date.svg" width="30" height="30" id="">
      </div>
    </div>
  </div>
    <div class="record_wrap">
  <ul class="bgc_fff">
  </ul>
</div>
</div>
<script type="text/javascript">
    $(document).ready(function(){
       
       result = new Mdate(
           "dateSelectorOne",
            {
                //"dateSelectorOne"为你点击触发Mdate的id，必填项
                acceptId:'endDate',
                //此项为你要显示选择后的日期的input，不填写默认为上一行的"dateShowBtn"
                beginYear: "2017",
                //此项为Mdate的初始年份，不填写默认为2000
                beginMonth: "1",
                //此项为Mdate的初始月份，不填写默认为1
                beginDay: "1",
                //此项为Mdate的初始日期，不填写默认为1
                endYear: "",
                //此项为Mdate的结束年份，不填写默认为当年
                endMonth: "",
                //此项为Mdate的结束月份，不填写默认为当月
                endDay: "",
                //此项为Mdate的结束日期，不填写默认为当天
                format: "-"
                //此项为Mdate需要显示的格式，可填写"/"或"-"或".",不填写默认为年月日
            }
        );

    });
</script>

<script>
  $(function(){
    dropload();
     $(document).on('click','#dateSure',function(){
      //到这里删选条件还没到后台
        var endDate = $('#endDate').val()
        $.ajax({
          url:'drawmoneyrecord.php',
          type:'GET',
          data:{'method':'loadData','endDate':endDate},
          dataType :'',
          success:function(data){
            data = jQuery.parseJSON(data);
            recordData =  data['recordData'];
            result ="";
            arrLen = recordData.length
              
            result = dealData(recordData,arrLen)
            $('.record_wrap>ul').html(result);
            $('#dateTime').text(data['DateTime']);
          },
          error : function(){
            console.log('error')
          }
        })
        // dropload();
      })
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
            var endDate = $('#endDate').val()
              $.ajax({
                  url: 'drawmoneyrecord.php',
                  type: 'POST',
                  data:{'method':'loadData','page_no':1,'endDate':endDate},
                  dataType: '',
                  success: function(data){
                      data = jQuery.parseJSON(data); 
                      recordData = data['recordData'];

                      var arrLen = recordData.length;
                      var result = '';
                      result = dealData(recordData,arrLen);
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
                      },200);
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
              var endDate = $('#endDate').val()
              $.ajax({
                  type: 'GET',
                  url: 'drawmoneyrecord.php',
                  data:{'method':'loadData','page_no':page,'endDate':endDate},
                  dataType: '',
                  success: function(data){
                    data = jQuery.parseJSON(data);
                    recordData = data['recordData'];
                    arrLen = recordData.length;
                      if(arrLen > 0){
                      result = dealData(recordData,arrLen);      
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
                          $('#dateTime').text(data['DateTime']);
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


    function dealData(recordData,arrLen){
      var result ="";
      var status = "";
      for(var i=0; i<arrLen; i++){
              if(recordData[i].status == 0){
                status = '<p class="c_039cfe ft12" style="position:absolute;left:81%;top:66%;">等待审核</p>';
              }else if(recordData[i].status == 1){
                status = '<p class="c_4baf43 ft12" style="position:absolute;left:81%;top:66%;">已完成</p>';
              }else if(recordData[i].status == 2){
                status = '<p class="c_ff0000 ft12" style="position:absolute;left:81%;top:66%;">提现失败</p>';
              }
              result += '<li class="relative C_wh bgc_fff"><div class="S_wh round bgc_1296db f_get absolute top15 left5">提</div><div class="C_wh80 floatR B_b_bfbfbf"><div class="floatL"><p class="f_shop">提现金额</p><p class="f_return" style="text-align: left">'+recordData[i].addtime+'</p></div><div class="floatR"><input class="f_money" style="position: absolute;left:40%;top:10%; color:red;background-color: transparent;color:#1296db" value="'+recordData[i].rmb+'" disabled>'+status+'</div></div></li>';
        }
      return result;
    }
  });
</script>