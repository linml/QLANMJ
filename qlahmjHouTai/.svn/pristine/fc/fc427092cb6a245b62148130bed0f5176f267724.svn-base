!(function(win, doc) {
        function setFontSize() {
           var winWidth = window.innerWidth;		//对fontsize进行设置，屏幕宽度/10
           document.documentElement.style.fontSize = winWidth / 10 + 'px';
           if(winWidth>1024){		//设置最大宽度不超过1024px
           		document.documentElement.style.fontSize = 102.4+'px';
           }
        }
        var evt = 'onorientationchange' in win ? 'orientationchange' : 'resize';	//判断窗口是否方向有变或者是窗口大小有变化

        var timer = null;

        win.addEventListener(evt, function() {
            clearTimeout(timer);

            timer = setTimeout(setFontSize, 100);
        }, false);

        win.addEventListener("pageshow", function(e) {	//窗口初始化
            if (e.persisted) {
                clearTimeout(timer);

                timer = setTimeout(setFontSize, 100);
            }
            
        }, false);
		
        // 初始化
        setFontSize();

    }(window, document));