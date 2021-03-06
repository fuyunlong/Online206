﻿var HeartRecord = {
    //查询心跳记录
    Search: function (srcObj, site, date) {
        $.ajax({
            type: "post",
            url: "/HeartBeat/GetBeatRecordListByDTUId",
            data: { dtuId: site, date: date },
            dataType: "json",
            error: function () {
                layer.alert("查询心跳记录失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_TextCenter'>" + $("#ddlSite option:selected").text() + "</td>";
                    str += "<td class='com_TextCenter'>" + data[i] + "</td>";
                    str += "</tr>";
                }
                srcObj.html(str);
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
    }
};