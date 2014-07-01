(function ($) {
    var page;
    function login(userName, pwd, complete, success) {
        $.ajax({
            url: '../Handler/LoginHandler.ashx',
            data: { 'method': 'login', 'userName': userName, 'pwd': pwd },
            type: "POST",
            success: success,
            complete: function () {
                complete();
            }
        });
    }

    function showLogin(callBack) {
        var div = $("<div data-role='page'><div data-role='header'><h2>请登录</h2><div data-role='content'><input type='text' id='loginUserName' placeholder='用户名' data-clear-btn='true' /><input type='password' id='loginUserPwd' value='' placeholder='密码' autocomplete='off' data-clear-btn='true' /><button class='ui-shadow ui-btn ui-corner-all' id='btnLogin'>登录</button></div></div></div>");
        div.page();
        div.addClass("ui-page-active");
        div.appendTo($("body"));
        
        $.mobile.loading('hide');

        $("#btnLogin").click(function () {
            //mobile-button-disabled
            $.mobile.loading("show", {
                text: "加载中",
                textVisible: true,
                theme: "z",
                html: ""
            });

            var userName = $.trim($("#loginUserName").val());
            var pwd = $.trim($("#loginUserPwd").val());
            if (userName != "" && pwd != "") {
                login(userName, pwd, function () {
                    //$("#btnLogin").button("option", "disabled", false);
                }, function (msg) {
                    if (msg == "1") {
                        //登录成功
                        window.localStorage.setItem("wxLoginName", userName);
                        window.loginName = userName;
                        div.remove();
                        page.addClass("ui-page-active");
                        callBack();
                    }
                    else {
                        //登录失败
                        alert("用户名或密码错误");
                    }
                });
            }
        });
    }

    $.checkLogin = function (callBack) {

        page = $(".ui-page-active");
        page.removeClass("ui-page-active");

        var loginName = window.localStorage.getItem("wxLoginName");
        if (loginName) {
            //有账号
            window.loginName = loginName;
            page.addClass("ui-page-active");
            callBack();
        }
        else {
            showLogin(callBack);
        }
    }
})(jQuery);