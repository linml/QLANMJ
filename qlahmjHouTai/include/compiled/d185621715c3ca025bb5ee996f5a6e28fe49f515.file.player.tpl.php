<?php /* Smarty version Smarty-3.1.15, created on 2018-08-13 16:06:16
         compiled from "F:\project\qlahmjHouTai\include\template\agentcenter\player.tpl" */ ?>
<?php /*%%SmartyHeaderCode:199985b712d5deac963-74629004%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_valid = $_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    'd185621715c3ca025bb5ee996f5a6e28fe49f515' => 
    array (
      0 => 'F:\\project\\qlahmjHouTai\\include\\template\\agentcenter\\player.tpl',
      1 => 1534143973,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '199985b712d5deac963-74629004',
  'function' => 
  array (
  ),
  'version' => 'Smarty-3.1.15',
  'unifunc' => 'content_5b712d5df06705_19596545',
  'has_nocache_code' => false,
),false); /*/%%SmartyHeaderCode%%*/?>
<?php if ($_valid && !is_callable('content_5b712d5df06705_19596545')) {function content_5b712d5df06705_19596545($_smarty_tpl) {?><?php echo $_smarty_tpl->getSubTemplate ("simple_header.tpl", $_smarty_tpl->cache_id, $_smarty_tpl->compile_id, 0, null, array(), 0);?>


<div class="header">
    <h1>就当我是新闻页吧</h1>
</div>
<div class="content">
    <div class="lists">
       
    </div>
</div>
<div class="footer">
    <a href="#1" class="item">测试菜单</a>
    <a href="#2" class="item">只做展示</a>
    <a href="#3" class="item">无功能</a>
    <a href="#4" class="item">不用点</a>
</div>

<script>
    $(function(){
        // 页数
        var page = 0;
        // 每页展示10个
        var size = 10;

        // dropload
        $('.content').dropload({
            scrollArea : window,
            domUp : {
                domClass   : 'dropload-up',
                domRefresh : '<div class="dropload-refresh">↓下拉刷新-自定义内容</div>',
                domUpdate  : '<div class="dropload-update">↑释放更新-自定义内容</div>',
                domLoad    : '<div class="dropload-load"><span class="loading"></span>加载中-自定义内容...</div>'
            },
            domDown : {
                domClass   : 'dropload-down',
                domRefresh : '<div class="dropload-refresh">↑上拉加载更多-自定义内容</div>',
                domLoad    : '<div class="dropload-load"><span class="loading"></span>加载中-自定义内容...</div>',
                domNoData  : '<div class="dropload-noData">暂无数据-自定义内容</div>'
            },
            loadUpFn : function(me){
                $.ajax({
                    type: 'GET',
                    url: 'json/update.json',
                    dataType: 'json',
                    success: function(data){
                        var result = '';
                        for(var i = 0; i < data.lists.length; i++){
                            result +=   '<a class="item opacity" href="'+data.lists[i].link+'">'
                                            +'<img src="'+data.lists[i].pic+'" alt="">'
                                            +'<h3>'+data.lists[i].title+'</h3>'
                                            +'<span class="date">'+data.lists[i].date+'</span>'
                                        +'</a>';
                        }
                        // 为了测试，延迟1秒加载
                        setTimeout(function(){
                            $('.lists').html(result);
                            // 每次数据加载完，必须重置
                            me.resetload();
                            // 重置页数，重新获取loadDownFn的数据
                            page = 0;
                            // 解锁loadDownFn里锁定的情况
                            me.unlock();
                            me.noData(false);
                        },1000);
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
                    url: 'http://ons.me/tools/dropload/json.php?page='+page+'&size='+size,
                    dataType: 'json',
                    success: function(data){
                        var arrLen = data.length;
                        if(arrLen > 0){
                            for(var i=0; i<arrLen; i++){
                                result +=   '<a class="item opacity" href="'+data[i].link+'">'
                                                +'<img src="'+data[i].pic+'" alt="">'
                                                +'<h3>'+data[i].title+'</h3>'
                                                +'<span class="date">'+data[i].date+'</span>'
                                            +'</a>';
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
                            $('.lists').append(result);
                            // 每次数据插入，必须重置
                            me.resetload();
                        },1000);
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
<?php }} ?>
