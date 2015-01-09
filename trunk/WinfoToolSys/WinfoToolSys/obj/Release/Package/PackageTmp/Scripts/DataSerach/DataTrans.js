//数据转发
var DataTrans = {
    //获取转发列表
    GetTransList: function () {
        $.ajax({
            type: "POST",
            data: { Company: $("#ddlCompany").val() },
            url: "/DataTrans/GetTransSetList",
            dataType: "json",
            error: function () {
                layer.alert("查询转发信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var Str = "";
                for (var a in data) {
                    Str += "<tr>";
                    Str += "<td class=' com_w10pen'>" + data[a].Dtuid + "</td>";
                    Str += "<td class='com_w25pen'>" + data[a].DtuidName + "</td>";
                    Str += "<td class='com_w12pen'>" + data[a].TransDesc + "</td>";
                    Str += "<td class='com_w12pen com_TextCenter'>";
                    Str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('查看','50%','60%','20%','30%','DataTrans/DataTransDetail?Oper=Show&TransId=" + data[a].Id + "')>查看|</a> ";
                    Str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('修改','50%','60%','20%','30%','DataTrans/DataTransDetail?Oper=Edit&TransId=" + data[a].Id + "')>修改|</a> ";
                    Str += "<a href='javascript:void(0)' onclick=DataTrans.DeleteTrans(" + data[a].Id + ")>删除</a> ";
                    Str += "</td>";
                    Str += "</tr>";
                }
                $("#ComList tbody").html(Str);
            }
        });
    },
    GetVerList: function () {
        $.ajax({
            type: "POST",
            async: false,
            url: "/DataTrans/GetVerList",
            dataType: "json",
            error: function () {
                layer.alert("获取版本信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var a in data) {
                    str += "<option tt=" + data[a].TransDesc + " value=" + data[a].TargetVersion + ">" + data[a].TargetVersion + "</option>";
                    $("#box").val(data[a].TargetVersion);
                }
                $("#TargetVersion").html(str);
                $("#TransDesc").html($("#TargetVersion :selected").attr("tt"));
            }
        });
    },
    AddTrans: function () {
        var model = DataTrans.GetModel();
        if (model != null) {
            $.ajax({
                type: "POST",
                data: model,
                url: "/DataTrans/AddTransOper",
                dataType: "text",
                error: function () {
                    layer.alert("添加转发信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("添加转发信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert("添加转发信息失败！", 8);
                    }
                }
            });
        }
    },
    EditTrans: function () {
        var model = DataTrans.GetModel();
        if (model != null) {
            $.ajax({
                type: "POST",
                data: model,
                url: "/DataTrans/EditTrans",
                dataType: "text",
                error: function () {
                    layer.alert("修改转发信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("修改转发信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有修改权限！", 8);
                    }
                    else {
                        layer.alert("修改转发信息失败！", 8);
                    }
                }
            });
        }
    },
    DeleteTrans: function (Id) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "POST",
                data: "Id=" + Id,
                url: "/DataTrans/DeleteTrans",
                dataType: "text",
                error: function () {
                    layer.alert("删除转发信息失败，请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("删除转发信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("删除转发信息失败！", 8);
                    }
                }
            });
        });
    },
    GetModel: function () {
        if (!Validate.IsIPAddress($("#TargetIP").val())) {
            Stip("TargetIP").show({ content: "不是有效的IP地址", kind: "error", time: 3000 });
            $("#TargetIP").focus();
            return null;
        }

        if (!Validate.IsCellPhone($("#TargetPhoneNum").val())) {
            Stip("TargetPhoneNum").show({ content: "手机号码格式错误", kind: "error", time: 3000 });
            $("#TargetPhoneNum").focus();
            return null;
        }
        if (!Validate.IsRequired($("#TransDesc").val())) {
            Stip("TransDesc").show({ content: "配置描述不能为空", kind: "error", time: 3000 });
            $("#TransDesc").focus();
            return null;
        }
        if (!Validate.IsRequired($("#TargetPort").val())) {
            Stip("TargetPort").show({ content: "端口号不能必填，且为1到65535的整数", kind: "error", time: 3000 });
            $("#TargetPort").focus();
            return null;
        }
        if ($("#ddlGroup").val() == "0") {
            Stip("TargetPort").show({ content: "请选择用户分组", kind: "error", time: 3000 });
            $("#TargetPort").focus();
            return null;
        }
        var model = {
            Dtuid: $("#ddlDtu").val(),
            TargetIP: $("#TargetIP").val(),
            TargetPort: $("#TargetPort").val(),
            TargetVersion: $("#box").val(),
            TargetPhoneNum: $("#TargetPhoneNum").val(),
            TargetId: $("#TargetId").val(),
            OrderNum: $("#OrderNum").val(),
            TransProtocol: $("#TransProtocol").val(),
            TargetPhoneNum: $("#TargetPhoneNum").val(),
            IsTransmit: $("#IsTransmit").val(),
            TransDesc: $("#TransDesc").val(),
            Id: $("#TransId").val()
        };
        return model;
    }
};