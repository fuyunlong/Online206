﻿//用于在全局显示加载效果
function LoadingEvent() {
    //设置全局请求超时时间
    // $.ajaxSetup({ timeout: 60000 });//一分钟

    // $("#loading").css({ position: "absolute", height: "100%", width: "100%", filter: " alpha(opacity = 40)", "-moz-opacity": "0.4", opacity: "0.4", background: "gray url(/Images/loading.gif) center center no-repeat", "z-index": "100000", top: "0px", left: "0px" });
    // $(document).ajaxStart(onStart).ajaxComplete(onComplete);
}
var loadi = null;
$(function () {
    //设置全局请求超时时间
    $.ajaxSetup({ timeout: 10000 });
    // $("#loading").css({ position: "absolute", height: "100%", display: "none", width: "100%", filter: " alpha(opacity = 40)", "-moz-opacity": "0.4", opacity: "0.4", background: "gray url(/Images/loading.gif) center center no-repeat", "z-index": "100000", top: "0px", left: "0px" });
    $(document).ajaxStart(onStart).ajaxComplete(onComplete);
});
function onStart() {
    loadi = layer.load('加载中…');
    //"#loading").show();
}
function onComplete() {
    layer.close(loadi)
    //("#loading").hide();
}
