var CompanyConfig = {
    flag: true,
    //查询配置信息
    Serarch: function (srcObj, configName) {
        $.ajax({
            type: "post",
            url: "/Config/GetConfigByName",
            data: { configName: configName },
            dataType: "json",
            error: function () {
                layer.alert("查询配置信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w30pen com_TextCenter'>" + data[i].ConfigName + "</td>";
                    str += "<td class='com_w25pen com_TextCenter'>" + data[i].IP + "</td>";
                    str += "<td class='com_w20pen com_TextCenter'>" + data[i].Port + "</td>";
                    str += "<td class='com_w25pen com_TextCenter'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('配置查看','38%','40%','25%','35%','Config/ShowOper?oper=Show&configId=" + data[i].ConfigId + "')>查看|</a>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('配置修改','38%','40%','25%','35%','Config/ShowOper?oper=Edit&configId=" + data[i].ConfigId + "')>修改|</a>";
                    str += "<a href='javascript:void(0)' onclick=CompanyConfig.Delete(" + data[i].ConfigId + ")>删除</a>";
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
                layer.alert("获取客户端信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                data = JSON.parse(data);
                for (var i = 0; i < data.length; i++) {
                    str += "<option value='" + data[i].Key + "'>" + data[i].Value + "</option>";
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
    //添加
    Add: function () {
        var model = CompanyConfig.GetData();
        CompanyConfig.CheckData();
        if (CompanyConfig.flag) {
            $.ajax({
                type: "post",
                url: "/Config/Add",
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
                        layer.alert(data, 8);
                    }
                }
            });
        }
    },
    //修改
    Update: function () {
        var model = CompanyConfig.GetData();
        CompanyConfig.CheckData();
        if (CompanyConfig.flag) {
            $.ajax({
                type: "post",
                url: "/Config/Update",
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
    //删除
    Delete: function (configId) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/Config/Delete",
                data: { configId: configId },
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
        var model = {
            ConfigId: $("#txtConfigName").attr("name"),
            ConfigName: $("#txtConfigName").val().trim(),
            ConfigDesc: $("#txtDesc").val().trim(),
            IP: $("#txtIP").val().trim(),
            Port: $("#txtPort").val().trim(),
            ClientNum: $("#txtClientNum").val().trim(),
            ClientType: $("#ddlClienType").val()
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        CompanyConfig.flag = true;
        if (!Validate.IsRequired($("#txtConfigName").val())) {
            CompanyConfig.flag = false;
            Stip("txtConfigName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtConfigName").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtIP").val())) {
            CompanyConfig.flag = false;
            Stip("txtIP").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtIP").focus();
            return;
        }
        if (!Validate.IsIPAddress($("#txtIP").val())) {
            CompanyConfig.flag = false;
            Stip("txtIP").show({ content: "格式错误", kind: "error", time: 3000 });
            $("#txtIP").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtPort").val())) {
            CompanyConfig.flag = false;
            Stip("txtPort").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtPort").focus();
            return;
        }
        if ($("#txtPort").val() == "0") {
            CompanyConfig.flag = false;
            Stip("txtPort").show({ content: "不能为0", kind: "error", time: 3000 });
            $("#txtPort").focus();
            return;
        }
    }
};