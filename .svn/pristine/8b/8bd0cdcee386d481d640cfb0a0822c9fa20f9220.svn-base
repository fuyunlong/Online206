/*-----------------------------------------------------------------------------------------------------
 *   Company:   Chengdu Winfotian Infomation Technology Co.,Ltd
 *    Author:   yuanyang@winfotian.com
 *  DateTime:   2014-10-16 10:20:00 
 *   Purpose:
 *           Version           DateTime                    Author               Description
 *            v1.0       2014-10-16 10:20:00       yuanyang@winfotian.com       通用表格布局
 *----------------------------------------------------------------------------------------------------*/
/*
* <summary>通用表格样式、事件
* <example>
* new comTab().fnInit(); 适用于一次性初始化所有表格
* var objTab = new comTab(); objTab.fnInit('#tbList');适用于单个表格初始化
* </example>
*/
var comTab = function () {
    var _fnWriteLog = function (msg, place) {
        console.log("[OccurPlace]comTab." + (place || "") + "\n[msg]" + msg);
    }
    var _fnJqTabIds = function (tabIds) {
        if (!tabIds) return ".ui-com-tab";
        if (tabIds.toString().match(/#/g))
            return tabIds.toString();
        return "#" + tabIds.toString().replace(/,/g, ",#");
    }
    var _fnImportCSS = function () {
        if (document.getElementById("css-ui-table")) return;
        var _css = document.createElement('link');
        _css.setAttribute('rel', 'stylesheet');
        _css.setAttribute('type', 'text/css');
        _css.setAttribute("id","css-ui-table");
        _css.setAttribute('href', '../../Style/ui-com-table.css?ver=1.0.0');
        document.head.appendChild(_css);
    }
    var _fnRowHover = function (tabId) {
        $(_fnJqTabIds(tabId)).delegate("td", "mouseover", function () {
            $(this.parentNode).children().removeClass("ui-com-td-bg").addClass("ui-com-td-bg-hover");
        }).delegate("td", "mouseout", function () {
            $(this.parentNode).children().removeClass("ui-com-td-bg-hover").addClass("ui-com-td-bg");
        });
    }
    var _fnAddThead = function (tabId) {
        var tbs = $(_fnJqTabIds(tabId)), newTab = null;
        for (var i = 0; i < tbs.length; i++) {
            tbs[i].parentNode.style.overflowY = "auto";
            tbs[i].style.marginTop = 31 + "px";
            newTab = $('<table class="ui-com-thead"/>');
            newTab.css({ width: tbs[i].offsetWidth });
            newTab.append(tbs[i].firstElementChild);
            newTab.insertBefore(tbs[i]);
        }
    }
    var _fnResizeOfWin = function () {
        var tbs = $(".ui-com-thead");
        for (var i = 0; i < tbs.length; i++) {
            if (!tbs[i].nextElementSibling) continue;
            tbs[i].style.width = tbs[i].nextElementSibling.offsetWidth + "px";
        }
    }
    /**
    * <summary>调整表头行宽大小
    **/
    this.fnResizeTable = function () {
        setTimeout(_fnResizeOfWin, 800);
    }
    /**
    * <summary>初始化表格样式
    * <param:tabIds>['tab1']|['#tab1']|'tab1,tab2',#号可有可无
    * <remarks>tabIds-若无就当前所有，有就指定某些表
    **/
    this.fnInit = function (tabIds) {
        _fnRowHover(tabIds);
        setTimeout(function () { _fnAddThead(tabIds); }, 1000);
    }
    /*
    * <summary>实例化时运行
    */
    _fnImportCSS();
    window.onresize = _fnResizeOfWin;
}