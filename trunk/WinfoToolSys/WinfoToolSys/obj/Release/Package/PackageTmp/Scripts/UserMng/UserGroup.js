﻿var UserGroup = {
    flag: true,
    //查询
    Search: function (srcObj, companyId) {
        $.ajax({
            type: "post",
            url: "/UserGroup/GetGroup",
            data: { companyId: companyId },
            dataType: "json",
            error: function () {
                layer.alert("查询分组信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w25pen' style='padding-left:80px;'>" + data[i].DepartName + "</td>";
                    str += "<td class='com_w25pen com_TextCenter'>" + data[i].Remark + "</td>";
                    str += "<td class='com_w30pen com_TextCenter'>" + $("#ddlCompany option:selected").text() + "</td>";
                    str += "<td class='com_w20pen com_TextCenter'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('分组查看','38%','35%','25%','33%','UserGroup/Operation?oper=Show&departId=" + data[i].DepartID + "')>查看|</a>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('分组修改','38%','35%','25%','33%','UserGroup/Operation?oper=Edit&departId=" + data[i].DepartID + "')>修改|</a>";
                    str += "<a href='javascript:void(0)' onclick=UserGroup.Delete(" + data[i].DepartID + ")>删除</a>";
                    str += "</td>";
                    str += "</tr>";
                }
                srcObj.html(str);
            }
        });
    },
    //树形展开
    //Collapse: function (obj) {
    //    if ($(obj).attr("src") == "/Images/tag_plus.png") {
    //        $(obj).attr("src", "/Images/tag_add.png");
    //    }
    //    else {
    //        $(obj).attr("src", "/Images/tag_plus.png");
    //    }

    //    var pCode = $(obj).attr("isHide");
    //    var nextTR = $(obj).parents('tr').next();
    //    var cCode = nextTR.attr("isHide");
    //    var childCode = "aaa", imgobj = null;
    //    while (pCode == cCode || childCode == cCode) {
    //        imgobj = nextTR.children(":first").children("img");
    //        if (imgobj.length > 0 && imgobj.attr("src") == "/Images/tag_plus.png") {
    //            childCode = imgobj.attr("isHide");
    //        }
    //        if (nextTR.is(":visible")) {
    //            nextTR.hide();
    //        }
    //        else {
    //            nextTR.show();
    //        }
    //        nextTR = nextTR.next();
    //        cCode = nextTR.attr("isHide");
    //    }
    //},
    //获取父分组
    GetGroup: function (srcObj, companyId, callBack) {
        $.ajax({
            type: "post",
            url: "/UserGroup/GetGroup",
            data: { companyId: companyId },
            dataType: "json",
            error: function () {
                layer.alert("获取分组信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "<option value=0>顶级目录</option>";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value=" + data[i].DepartID + ">" + data[i].DepartName + "</option>";
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
    //添加用户
    Add: function () {
        var model = UserGroup.GetData();
        UserGroup.CheckData();
        if (UserGroup.flag) {
            $.ajax({
                type: "post",
                url: "/UserGroup/Add",
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
    //修改用户分组
    Update: function () {
        var model = UserGroup.GetData();
        if (model.DepartID == model.ParentCode) {
            UserGroup.flag = false;
            Stip("tdParentGroup").show({ content: "不能选自己", kind: "error", time: 3000 });
            $("#ddlParentGroup").focus();
            return;
        }
        UserGroup.CheckData();
        if (UserGroup.flag) {
            $.ajax({
                type: "post",
                url: "/UserGroup/Update",
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
                    else if (data == "没有权限") {
                        layer.alert("没有修改权限！", 8);
                    }
                    else {
                        layer.alert("修改分组信息失败！", 8);
                    }
                }
            });
        }
    },
    //删除分组
    Delete: function (departId) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/UserGroup/Delete",
                data: { departId: departId },
                dataType: "text",
                error: function () {
                    layer.alert("删除分组信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("删除分组信息成功！", 9, function () {
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "没有权限") {
                        layer.alert("没有删除权限！", 8);
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
            DepartID: $("#txtGroupName").attr("name"),
            DepartName: $("#txtGroupName").val().trim(),
            Remark: $("#txtGroupDesc").val().trim(),
            ParentCode: $("#ddlParentGroup").val(),
            CompanyID: $("#ddlCompany").val()
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        UserGroup.flag = true;
        if (!Validate.IsRequired($("#txtGroupName").val())) {
            UserGroup.flag = false;
            Stip("txtGroupName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtGroupName").focus();
            return;
        }
    },
    //根据用户公司Id获取用户分组
    GetUserGroupByCompanyId: function (companyId) {
        $.ajax({
            type: "post",
            url: "/UserGroup/GetGroup",
            data: { companyId: companyId },
            dataType: "json",
            error: function () {
                layer.alert("查询分组信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "<option value=0>全部</option>";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value=" + data[i].DepartID + ">" + data[i].DepartName + "</option>"
                }
                $("#ddlGroup").html(str);
            }
        });
    }
};