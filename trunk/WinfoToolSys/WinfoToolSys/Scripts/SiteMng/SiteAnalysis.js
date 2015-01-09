﻿var SiteAnalysis = {
    power: 0,
    heart: "",
    hasAlert: false,
    //获取电量
    GetLastPower: function (siteId, callBack) {
        $.ajax({
            type: "post",
            url: "/SiteProblem/GetPower",
            data: { siteId: siteId },
            dataType: "text",
            error: function () {
                layer.alert("查询电量信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                $("#div_power").html("电量:" + (data == "" ? 0 : data) + "%");
                SiteAnalysis.power = data;
                if (parseInt(data) <= 10) {
                    $("#div_power").css({
                        background: "red",
                        opacity: 0.6
                    });
                }
                else {
                    $("#div_power").css({
                        background: "#fff",
                        opacity: 1
                    });
                }
                if (!callBack) {//没有回调函数
                    return;
                }
                if (typeof callBack.constructor == "string") {
                    callBack = new Function(callBack);
                }
                callBack.call();
            }
        });
    },
    //获取最后一次心跳记录
    GetLastHeartRecord: function (siteId, callBack) {
        $.ajax({
            type: "post",
            url: "/SiteProblem/GetLastHeartRecord",
            data: { siteId: siteId },
            dataType: "text",
            error: function () {
                layer.alert("查询心跳记录失败,请稍后再试！", 8);
            },
            success: function (data) {
                $("#div_Heart").html(data == "" ? "没有心跳" : "心跳:" + data.split(",")[1]);
                SiteAnalysis.heart = data;
                var timespan = "";
                var arr = data.split(",");
                timespan = Date.parse(arr[0]) - Date.parse(arr[1]);
                if (Math.abs(timespan) >= 180000 || data == "") {//没有心跳或大于3分钟
                    $("#div_Heart").css({
                        background: "red",
                        opacity: 0.6
                    });
                }
                else {
                    $("#div_Heart").css({
                        background: "#fff",
                        opacity: 1
                    });
                }
                if (!callBack) {//没有回调函数
                    return;
                }
                if (typeof callBack.constructor == "string") {
                    callBack = new Function(callBack);
                }
                callBack.call();
            }
        });
    },
    //获取最新2条报警记录
    GetTop2AlertRecord: function (siteId) {
        $.ajax({
            type: "post",
            url: "/SiteProblem/GetTop2AleartRecord",
            data: { siteId: siteId },
            dataType: "json",
            error: function () {
                layer.alert("查询报警记录失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "<table id='AlertList' class='ui-com-tab' rules='all' >";
                str += "<thead>";
                str += "<tr align='left' class='panel-header'>";
                str += "<th class='com_TextCenter com_w10pen'>总警告次数</th>";
                str += "<th class='com_TextCenter com_w20pen'>站点名称</th>";
                str += "<th class='com_TextCenter com_w20pen'>告警简述</th>";
                str += "<th class='com_TextCenter com_w10pen'>告警状态</th>";
                str += "<th class='com_TextCenter com_w15pen'>最新告警时间</th>";
                str += "<th class='com_TextCenter com_w15pen'>告警时间</th>";
                str += "<th class='com_TextCenter com_w10pen'>当前警告次数</th>";
                str += "</tr>";
                str += "</thead>";
                str += "<tbody>";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_TextCenter com_w10pen'>" + data[i].AlertCount + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>" + $("#ddlSite option:selected").text() + "</td>";
                    str += "<td class='com_TextCenter com_w20pen com_disnote'>" + data[i].AlertDesc + "</td>";
                    str += "<td class='com_TextCenter com_w10pen'>" + (data[i].AlertState == 1 ? "已恢复" : "未查看") + "</td>";
                    str += "<td class='com_TextCenter com_w15pen'>" + Common.ChangeDate(data[i].RecentTime) + "</td>";
                    str += "<td class='com_TextCenter com_w15pen'>" + Common.ChangeDate(data[i].AlertTime) + "</td>";
                    str += "<td class='com_TextCenter com_w10pen'>" + data[i].CurAlertCount + "</td>";
                    str += "</tr>";
                }
                str += "</tbody>";
                str += "</table>";
                if (data.length > 0) {
                    SiteAnalysis.hasAlert = true;
                    $("#AlertList").remove();
                    $("#tbDiv").prepend(str);
                }
            }
        });
    },
    //获取5条最新原始数据
    GetTop5Data: function (siteId) {
        $.ajax({
            type: "post",
            url: "/SiteProblem/GetTop5OriginalData",
            data: { siteId: siteId },
            dataType: "json",
            error: function () {
                layer.alert("查询原始数据失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "<table id='RecordList' class='ui-com-tab' rules='all' style='height: 150px'>";
                str += "<thead>";
                str += "<tr align='left' class='panel-header'>";
                str += "<th class='com_TextCenter com_w87pen'>采集数据（最新5条）</th>";
                str += "<th class='com_TextCenter com_w13pen'>采集时间</th>";
                str += "</tr>";
                str += "</thead>";
                str += "<tbody>";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_TextCenter com_w87pen com_disnote'>" + data[i].CollectData + "</td>";
                    str += "<td class='com_TextCenter com_w13pen'>" + Common.ChangeDate(data[i].COLLECTTIME) + "</td>";
                    str += "</tr>";
                }
                str += "</tbody>";
                str += "</table>";
                if (data.length > 0) {
                    $("#RecordList").remove();
                    $("#tbDiv").prepend(str);
                }
            }
        });
    },
    //公司改变
    CompanyChange: function () {
        Common.GetGroup($("#ddlGroup"), $("#ddlCompany").val(), function () { Common.GetSite($("#ddlSite"), $("#ddlCompany").val(), $("#ddlGroup").val(), null); });
    },
    //分组改变
    GroupChange: function () {
        Common.GetSite($("#ddlSite"), $("#ddlCompany").val(), $("#ddlGroup").val(), null);
    },
    //分析结果
    GetResult: function () {
        var str = "<div id='result' style='border:1px solid rgb(145, 215, 255);border-top:none;'font-size:14px'><span style='font-size:16px;margin-left:10px;'>分析结果：</span><br/>";
        if (SiteAnalysis.power <= 10) {
            str += "<p style='color:red;margin-left:80px;'>电量低于10%！</p>";
        }
        else {
            str += "<p style='color:green;margin-left:80px;'>电量正常</p>";
        }

        if (SiteAnalysis.heart == "") {
            str += "<p style='color:red;margin-left:80px;'>没有心跳！</p>";
        }
        else {
            var arr = SiteAnalysis.heart.split(",");
            var timespan = Date.parse(arr[0]) - Date.parse(arr[1]);
            if (Math.abs(timespan) >= 180000) {
                str += "<p style='color:red;margin-left:80px;'>心跳超过3分钟！</p>";
            }
            else {
                str += "<p style='color:green;margin-left:80px;'>心跳正常</p>";
            }
        }
        if (SiteAnalysis.hasAlert) {
            str += "<p style='color:red;margin-left:80px;'>最近5小时以内有报警信息！</p>";
        }
        str += "</div>";
        $("#result").remove();
        $("#tbDiv").append(str);
    }
}