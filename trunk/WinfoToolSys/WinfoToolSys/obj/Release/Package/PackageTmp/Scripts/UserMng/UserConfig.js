﻿var UserConfig = {
    flag: true,
    //查询
    Search: function (srcObj, configName) {
        $.ajax({
            type: "post",
            url: "/UserSetting/GetUserConfigByName",
            data: { configName: configName },
            dataType: "json",
            error: function () {
                layer.alert("查询配置信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w25pen com_TextCenter'>" + data[i].ConfigName + "</td>";
                    str += "<td class='com_w25pen com_TextCenter com_disnote'>" + data[i].ConfigDesc + "</td>";
                    str += "<td class='com_w10pen com_TextCenter'>" + data[i].SoftInterval + "</td>";
                    str += "<td class='com_w10pen com_TextCenter'>" + (data[i].IsAlert == 0 ? "否" : "是") + "</td>";
                    str += "<td class='com_w10pen com_TextCenter'>" + (data[i].IsRpt == 0 ? "否" : "是") + "</td>";
                    str += "<td class='com_w20pen com_TextCenter'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('配置查看','38%','50%','25%','35%','UserSetting/Operation?oper=Show&configId=" + data[i].CCode + "')>查看|</a>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('配置修改','38%','50%','25%','35%','UserSetting/Operation?oper=Edit&configId=" + data[i].CCode + "')>修改|</a>";
                    str += "<a href='javascript:void(0)' onclick=UserConfig.Delete('" + data[i].CCode + "')>删除</a>";
                    str += "</td>";
                    str += "</tr>";
                }
                srcObj.html(str);
            }
        });
    },
    //获取客户端类型
    GetClienType: function (srcObj, callBack) {
        $.ajax({
            type: "post",
            url: "/UserSetting/GetUsers",
            dataType: "text",
            error: function () {
                layer.alert("获取客户端类型失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                data = JSON.parse(data);
                for (var i = 0; i < data.length; i++) {
                    str += "<input class='oper' type=checkbox value=" + data[i].Key + ">" + data[i].Value + "<br/>";
                }
                srcObj.html(str);
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
    //获取用户配置
    GetUserConfigList: function (srcObj, configName) {
        $.ajax({
            type: "post",
            url: "/UserSetting/GetUserConfigByName",
            data: { configName: configName },
            dataType: "json",
            error: function () {
                layer.alert("获取配置信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value='" + data[i].CCode + "'>" + data[i].ConfigName + "</option>";
                }
                $(srcObj).html(str);
            }
        });
    },
    GetUserConfigListVer2: function (srcObj, configName) {
        $.ajax({
            type: "post",
            url: "/UserSetting/GetUserConfigByNameV2",
            data: { configName: configName },
            dataType: "json",
            error: function () {
                layer.alert("获取配置信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value='" + data[i].CCode + "'>" + data[i].ConfigName + "</option>";
                }
                $(srcObj).html(str);
            }
        });
    },
    //添加配置
    Add: function () {
        var model = UserConfig.GetData();
        UserConfig.CheckData();
        if (UserConfig.flag) {
            $.ajax({
                type: "post",
                url: "/UserSetting/Add",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("添加配置信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("添加配置信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert("添加配置信息失败！", 8);
                    }
                }
            });
        }
    },
    //修改配置
    Update: function () {
        var model = UserConfig.GetData();
        UserConfig.CheckData();
        if (UserConfig.flag) {
            $.ajax({
                type: "post",
                url: "/UserSetting/Update",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("修改配置信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "修改成功") {
                        layer.alert("修改配置信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert(data, 8);
                    }
                }
            });
        }
    },
    //删除配置
    Delete: function (cCode) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/UserSetting/Delete",
                data: { cCode: cCode },
                dataType: "text",
                error: function () {
                    layer.alert("删除配置信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "删除成功") {
                        layer.alert("删除配置信息成功！", 9, function () {
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert(data, 8);
                    }
                }
            });
        });
    },
    //获取数据
    GetData: function () {
        var popCode = "";
        for (var i = 0; i < $("input[type=checkbox]:checked").length; i++) {
            if (i == $("input[type=checkbox]:checked").length - 1) {
                popCode += $("input[type=checkbox]:checked")[i].value;
            }
            else {
                popCode += $("input[type=checkbox]:checked")[i].value + ",";
            }
        }
        var model = {
            CCode: $("#txtConfigName").attr("name"),
            ConfigName: $("#txtConfigName").val().trim(),
            ConfigDesc: $("#txtDesc").val().trim(),
            SoftInterval: $("#txtInterval").val().trim(),
            IsAlert: $("input[type=radio][name=IsAlert]:checked").val(),
            IsRpt: $("input[type=radio][name=IsRpt]:checked").val(),
            PopCode: popCode
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        UserConfig.flag = true;
        if (!Validate.IsRequired($("#txtConfigName").val())) {
            UserConfig.flag = false;
            Stip("txtConfigName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtConfigName").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtInterval").val())) {
            UserConfig.flag = false;
            Stip("txtInterval").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtInterval").focus();
            return;
        }
    }
};