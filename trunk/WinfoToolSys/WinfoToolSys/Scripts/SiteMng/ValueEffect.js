var ValueEffect = {
    flag: true,
    //查询列表
    GetValueEffectList: function (srcObj, siteId) {
        if (!siteId) {
            layer.alert("请选择站点！", 8);
            return;
        }
        $.ajax({
            type: "post",
            url: "/ValveInfluence/GetInfluencList",
            data: { siteId: siteId },
            dataType: "json",
            error: function () {
                layer.alert("查询阀门影响失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_TextCenter com_w20pen'>" + data[i].ValveName + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>" + Common.ChangeDate(data[i].ClosedTime) + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>" + data[i].EffctArea + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>" + data[i].EffctUserNum + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('影响查看','50%','28%','30%','30%','ValveInfluence/ShowDetail?oper=Show&valveCode=" + data[i].ValveCode + "')>查看|</a> ";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('影响修改','50%','28%','30%','30%','ValveInfluence/ShowDetail?oper=Edit&valveCode=" + data[i].ValveCode + "')>修改|</a> ";
                    str += "<a href='javascript:void(0)' onclick=ValueEffect.Delete('" + data[i].ValveCode + "')>删除</a> ";
                    str += "</td>";
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
    },
    //新增
    Add: function () {
        var model = ValueEffect.GetData();
        ValueEffect.CheckData();
        if (ValueEffect.flag) {
            $.ajax({
                type: "post",
                url: "/ValveInfluence/Add",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("添加影响信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("添加影响信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert("添加影响信息失败！", 8);
                    }
                }
            });
        }
    },
    //更改配置
    Update: function () {
        var model = ValueEffect.GetData();
        ValueEffect.CheckData();
        if (ValueEffect.flag) {
            $.ajax({
                type: "post",
                url: "/ValveInfluence/Update",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("修改影响信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("修改影响信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("修改影响信息失败！", 8);
                    }
                }
            });
        }
    },
    //删除配置
    Delete: function (valveCode) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/ValveInfluence/Delete",
                data: { valveCode: valveCode },
                dataType: "text",
                error: function () {
                    layer.alert("删除影响信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("删除影响信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("删除影响信息失败！", 8);
                    }
                }
            });
        });
    },
    //获取数据
    GetData: function () {
        var model = {
            ValveCode: $("#txtValveName").attr("name"),
            ValveName: $("#txtValveName").val().trim(),
            ClosedTime: $("#txtDate").val(),
            EffctArea: $("#txtEffctArea").val().trim(),
            EffctUserNum: $("#txtEffctUserNum").val().trim(),
            Dtuid: $("#ddlSite").val()
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        ValueEffect.flag = true;
        if (!$("#ddlSite").val()) {
            ValueEffect.flag = false;
            Stip("tdSite").show({ content: "请选择站点", kind: "error", time: 3000 });
            $("#ddlSite").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtValveName").val())) {
            ValueEffect.flag = false;
            Stip("txtValveName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtValveName").focus();
            return;
        }
        if ($("#txtEffctUserNum").val() != "" && !Validate.IsInt($("#txtEffctUserNum").val())) {
            ValueEffect.flag = false;
            Stip("txtEffctUserNum").show({ content: "输入整数", kind: "error", time: 3000 });
            $("#txtEffctUserNum").focus();
            return;
        }
    }
};