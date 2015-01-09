//用于在全局显示加载效果
function LoadingEvent() {
    //设置全局请求超时时间
    $.ajaxSetup({ timeout: 10000 });
    $("#loading").css({ position: "absolute", height: "100%", width: "100%", filter: " alpha(opacity = 40)", "-moz-opacity": "0.4", opacity: "0.4", background: "gray url(../../Style/imgs/loading.gif) center center no-repeat", "z-index": "10000", top: "0px", left: "0px" });
    $(document).ajaxStart(onStart).ajaxComplete(onComplete);
}
$(function () {
    //设置全局请求超时时间
    $.ajaxSetup({ timeout: 10000 });
    $("#loading").css({ position: "absolute", height: "100%", display: "none", width: "100%", filter: " alpha(opacity = 40)", "-moz-opacity": "0.4", opacity: "0.4", background: "gray url(../../Style/imgs/loading.gif) center center no-repeat", "z-index": "10000", top: "0px", left: "0px" });
    $(document).ajaxStart(onStart).ajaxComplete(onComplete);

});
function onStart() {
    $("#loading").show();
  }
function onComplete()
{ $("#loading").hide(); }
//表格排序
function TableOrder() {
    //表格排序说明
    //页面需要有一个id 为loading的div,配合使用遮挡层
    $(function ()
    {
        //存入点击列的每一个TD的内容；
        var aTdCont = [];
        //点击列的索引值
        var thi = 0
        //重新对TR进行排序
        var setTrIndex = function (tdIndex, id)
        {
            for (i = 0; i < aTdCont.length; i++)
            {
                var trCont = aTdCont[i];
                $("#" + id + " tbody tr").each(function ()
                {
                    var thisText = $(this).children("td:eq(" + tdIndex + ")").text();
                    if (thisText.toLowerCase() == trCont)
                    {
                        $("#" + id + " tbody").append($(this));
                    }
                });
                $("#loading").fadeOut(1000);
            }
        }
        //比较函数的参数函数
        var compare_down = function (a, b)
        {
            return a - b;
        }
        var compare_up = function (a, b)
        {
            return b - a;
        }
        //比较函数
        var fSort = function (compare)
        {
            aTdCont.sort(compare);
        }
        //取出TD的值，并存入数组,取出前二个TD值；
        var fSetTdCont = function (thIndex, id)
        {
            $("#" + id + " tbody tr").each(function ()
            {
                var tdCont = $(this).children("td:eq(" + thIndex + ")").text();
                aTdCont.push(tdCont.toLowerCase());
            });
        }
        //点击时需要执行的函数
        var clickFun = function (thindex, id)
        {
            aTdCont = [];
            //获取点击当前列的索引值
            var nThCount = thindex;
            //调用sortTh函数 取出要比较的数据
            fSetTdCont(nThCount, id);
        }
        var tableid = 0;
        //点击事件绑定函数
        $("table th").toggle(function ()
        {
            $("#loading").show();
            thi = $(this).index();
            tableid = $(this).parents("table").attr("id");
            clickFun(thi, tableid);
            //调用比较函数,降序
             fSort(compare_up);
            //aTdCont.sort(function compare(a, b) { if (a > b) { return 1; } else { return -1; } });
            //重新排序行
            setTrIndex(thi, tableid);

        }, function ()
        {
            $("#loading").show();
            thi = $(this).index();
            tableid = $(this).parents("table").attr("id");
            clickFun(thi, tableid);
            //调用比较函数 升序
            fSort(compare_down);
            //aTdCont.sort(function compare(a, b) { if (a > b) { return -1; } else { return 1; } });
            //重新排序行
            setTrIndex(thi, tableid);
        })
    });
}