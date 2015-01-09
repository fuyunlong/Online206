var SiteGroup = {
    flag: true,
    //查询分组列表
    Serarch: function (srcObj, companyId) {
        $.ajax({
            type: "post",
            url: "/SiteGroup/GetGroup",
            data: { id: companyId },
            dataType: "json",
            error: function () {
                layer.alert("查询分组信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w25pen' style='padding-left:80px;'>" + data[i].GroupName + "</td>";
                    str += "<td class='com_TextCenter com_w25pen com_disnote'>" + data[i].GroupDesc + "</td>";
                    str += "<td class='com_TextCenter com_w30pen'>" + (data[i].ParentName == "" ? "顶级目录" : data[i].ParentName) + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('分组查看','38%','35%','25%','35%','SiteGroup/ShowDetail?oper=Show&groupCode=" + data[i].GroupCode + "')>查看|</a>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('分组修改','38%','35%','25%','33%','SiteGroup/ShowDetail?oper=Edit&groupCode=" + data[i].GroupCode + "')>修改|</a>";
                    str += "<a href='javascript:void(0)' onclick=SiteGroup.Delete('" + data[i].GroupCode + "')>删除</a>";
                    str += "</td>";
                    str += "</tr>";
                }
                srcObj.html(str);
            }
        });
    },
    //获取父分组
    GetGroup: function (srcObj, companyId, callBack) {
        $.ajax({
            type: "post",
            url: "/SiteGroup/GetGroup",
            data: { id: companyId },
            dataType: "json",
            error: function () {
                layer.alert("获取分组信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "<option value=0>顶级目录</option>";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value=" + data[i].GroupCode + ">" + data[i].GroupName + "</option>";
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
        var model = SiteGroup.GetData();
        SiteGroup.CheckData();
        if (SiteGroup.flag) {
            $.ajax({
                type: "post",
                url: "/SiteGroup/Add",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("添加分组信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("添加分组信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert("添加分组信息失败！", 8);
                    }
                }
            });
        }
    },
    //修改
    Update: function () {
        var model = SiteGroup.GetData();
        if (model.GroupCode == model.ParentCode) {
            SiteGroup.flag = false;
            Stip("tdParentGroup").show({ content: "不能选自己", kind: "error", time: 3000 });
            $("#ddlParentGroup").focus();
            return;
        }
        SiteGroup.CheckData();
        if (SiteGroup.flag) {
            $.ajax({
                type: "post",
                url: "/SiteGroup/Update",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("修改分组信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("修改分组信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有修改权限！", 8);
                    }
                    else {
                        layeralert("修改分组信息失败！", 8);
                    }
                }
            });
        }
    },
    //删除
    Delete: function (groupCode) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/SiteGroup/Delete",
                data: { groupCode: groupCode },
                dataType: "text",
                error: function () {
                    layer.alert("删除分组信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("删除分组信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else if (data == "-1") {
                        layer.alert("该分组正在使用中！", 8);
                    }
                    else {
                        layer.alert("删除分组信息失败！", 8);
                    }
                }
            });
        });
    },
    //获取数据
    GetData: function () {
        var model = {
            GroupCode: $("#txtGroupName").attr("name"),
            GroupName: $("#txtGroupName").val().trim(),
            GroupDesc: $("#txtGroupDesc").val().trim(),
            ParentCode: $("#ddlParentGroup").val(),
            CompanyId: $("#ddlCompany").val()
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        SiteGroup.flag = true;
        if (!Validate.IsRequired($("#txtGroupName").val())) {
            SiteGroup.flag = false;
            Stip("txtGroupName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtGroupName").focus();
            return;
        }
    }
}