<{include file = "simple_header.tpl"}>

<div class="N_Header" style="background-image:url(/assets/images/agentCenter/headerBg5.png);">
    <a href="javascript:history.back(-1)" class="ReturnUp">返回首页</a>
    <div class="N_Header_title">提现</div>
</div>
<!-- <div class="btn_invite fixed top8 right0">开通代理</div> -->
<div class="N_Wrap bottm60" style="margin-top:50px;">
    <div class="N_WrapAuto">
        <div class="N_bg">
            <div class="N_agentTop clearfix mgTp1A" style="background:url(/assets/images/agentCenter/bg9.png) no-repeat center top/100% auto;">
                <div class="C_wh50 floatL pd30">
                  <p class="ft25 c_fff"><{$agentInfo.diamond}>个</p>
                  <p class="c_fff">所拥有钻石</p>
                </div>
                <div class="C_wh50 floatL pd30">
                  <p class="ft25 c_fff"><{$agentInfo.rmb}></p>
                  <p class="c_fff">可提现余额</p>
                </div>
            </div>
            <form>
          <div class="clearfix mgTp3A borderR5 pd05" id="discountType">
          <ul>
            <li class="relative C_wh bgc_fff mgb3 borderR5">
              <div class="absolute f_return left6 top4">进钻金额</div>
              <div class="absolute f_return top4 left38">进货折扣</div>
              <div class="absolute f_return left59 top4">获得钻石</div>
              <div class="absolute f_return left86 top4">操作</div>
              <div class="absolute bTn1 left82 top42" id ="btn_tocoverRmbForDiamod">确定</div>
              <div class="absolute f_return left40 top50"><{$discount*100}>%</div>
              <div class="absolute left26 top46" id='addDiscountDiamond'>
                <img src="/assets/images/agentCenter/add.svg" width="25" height="25">
              </div>
              <span class="absolute inputbox left4 top43" type="" name="money" id="money" style="text-indent: 6px">100</span>
              <span class="absolute inputbox left56 top43"  name="diamondCount" id="diamondCount" style="padding:0 0 0 6px"></span>
            </li>
            <li class="relative wp_100 h50 bgc_fff mgb3 borderR5">
              <span class="f_return absolute left3 top25">余额提现</span>
              <input class="absolute left top18 left35 f_money  c_008f00" id ='txmoney' type="" name="" style="font-size: 14px;" placeholder="请输入提现金额！">

            </li>
              <li class="relative wp_100 h50 bgc_fff mgb3 borderR5">
              <span class="f_return absolute left3 top25">提现手续费</span>
              <span class="absolute left top25 h30 f_return"  type="" name="" style="">免费</pan>
            </li>
            <li class="bTn mgTp6A" id = 'wxcash' style="width: 50%; height: 40px; line-height: 40px">
              确认提现
            </li>
            <li class="f_return mgTp6A floatL">
              <p class="floatL">提现说明:</p><br>
              <p class="floatL">1:余额可按级别折扣进站</p><br>
              <p class="floatL">2:提现最低为100元起,每天最多3次</p><br>
              <p class="floatL">3:手续费为扣除系统免费送钻及活动送钻部分</p>
            </li>
          </ul>

        </div>
        </form>
        </div>
        
    </div>
</div>


<script>
  $(function(){
      //获取焦点清楚数据
      $("#money").focus(function(event) {
          $(this).val('');
          $("#diamondCount").text('');
      });

      //按钮添加
      $('#addDiscountDiamond').click(function(){
        var money =  parseInt(100) + parseInt($("#money").text()?$("#money").text():0);
        if(!money) return;
        $('#addDiscountDiamond').attr('disabled', "true");
        $.ajax({
          url: 'drawmoney.php', 
          type: 'POST',
          dataType: '',
          data: {'method': 'getOnvertedDiamonds','money':money},
          success:function(data){
            data = jQuery.parseJSON(data);
            if(data&&data['diamond']){
              $('#addDiscountDiamond').removeAttr("disabled");
              $('#money').text(parseInt(data['money']));
              $('#diamondCount').text(data['diamond']);
            }
            else alert('折扣转换出现问题,请稍后重试！');
          },
          error:function(error){}
        });
      })

      //金额转钻石换算
      var money =  parseInt($("#money").text()?$("#money").text():0);
      if(!money) return;
      $('#addDiscountDiamond').attr('disabled', "true");
      $.ajax({
        url: 'drawmoney.php',
        type: 'POST',
        dataType: '',
        data: {'method': 'getOnvertedDiamonds','money':money},
        success:function(data){
          data = jQuery.parseJSON(data);
          if(data&&data['diamond']){
            $('#addDiscountDiamond').removeAttr("disabled");
            $('#money').text(parseInt(data['money']));
            $('#diamondCount').text(data['diamond']);
          }
          else alert('折扣转换出现问题,请稍后重试！');
        },
        error:function(error){}
      });


      //设置只能输入数字
      $("#discountType>ul>li>input").keyup(function(eve){
          // if(eve.keyCode<48||eve.keyCode>57) eve.preventDefault();
          var thisdiscount = $(this).val().replace(/[^\d]/g,'');
          $(this).val(thisdiscount);
      })

      //金额转换钻石按钮
      $("#btn_tocoverRmbForDiamod").click(function(eve){
        var money = parseInt($("#money").text()?$("#money").text():0);
        if(!money) return;
        $.ajax({
          url: 'drawmoney.php',
          type: 'POST',
          dataType: '',
          data: {'method': 'toOnvertedDiamonds','money':money},
          success:function(data){
            if(data){
              if(data==-1){
                alert('交易失败！');
                window.location.href= window.location.href
              }else if(data ==0){
                alert('余额不足！')
                window.location.href= window.location.href
              }else if(data ==1){
                alert('交易成功！');
                window.location.href= window.location.href
              }
            }else{
              alert('异常错误！');
            }
          },
          error:function(error){}
        });
      });

      $("#wxcash").click(function(){
          var money = $("#txmoney").val();
          if(money<=0){alert('提现金额必须大于零！'); return;}
          if(money<100){alert("单笔提现金额必须大于100(元)！"); return;}
          if(confirm("请确认提现"+money+"(元)")){
            //实现下单功能
            /*$.ajax({
              url: 'drawmoney.php',
              type: 'POST',
              dataType: '',
              data: {'method': 'toCashOrder','money':money},
              success:function(data){
                if(data){
                  if(data==-1){
                    alert('交易失败！');
                  }else if(data==1){
                    alert('单笔提现金额必须大于100(元)！');
                  }else if(data==2){
                    alert('提现金额不能大于账户余额！');
                  }else{
                    alert('提现成功，请等待审核！');
                  }
                }else{
                  alert('未知错误！');
                }
                window.location.reload();
              },
              error:function(error){alert('error:'+error)}
            });*/
            window.location.href="../pay/wxCashOrder.php?money="+ money;
          }
      });
  });

</script>

<script type="text/javascript">
  $(function(){
    $('#money').on('click',function(){
      var target = this;
      setTimeout(function(){
        target.scrollIntoView(true);
      },100)
    })
  })
</script>