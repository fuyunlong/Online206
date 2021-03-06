﻿var AlertRecord = {
    //查询报警记录
    Search: function (srcObj, siteId, begain, end) {
        $.ajax({
            type: "post",
            url: "/AlearmRecord/GetRecordList",
            data: { siteId: siteId, begain: begain, end: end },
            dataType: "json",
            error: function () {
                layer.alert("查询报警记录失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
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