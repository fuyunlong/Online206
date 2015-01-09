var RemoteControl = {
    getControlList: function () {
        $.ajax({
            type: "post",
            data: { Id: $("#ddlDtu").val() },
            url: "/RemoteControlSet/GetRemoteControlList",
            dataType: "json",
            error: function () {
                layer.alert("查询站点信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var a in data) {
                    str += "<tr>";
                    str += "<td class='com_w10pen'>" + data[a].Dtuid + "</td>";
                    str += "<td class='com_w25pen'>" + data[a].FieldName + "</td>";
                    str += "<td class='com_w12pen'>" + data[a].DO_Index + "</td>"
                    str += "<td class='com_w12pen'>" + data[a].DI_Index + "</td>";
                    str += "<td>" + data[a].ReturnState + "</td>";
                    str += "<td class='com_TextCenter com_w15pen'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('查看控制','50%','50%','20%','30%','/RemoteControlSet/ControlDetail?Oper=Show&Dtuid=" + data[a].Dtuid + "&FieldName=" + data[a].FieldName + "')>查看|</a>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('修改控制','50%','50%','20%','30%','/RemoteControlSet/ControlDetail?Oper=Edit&Dtuid=" + data[a].Dtuid + "&FieldName=" + data[a].FieldName + "')>修改|</a>";
                    str += "<a href='javascript:void(0)' onclick=RemoteControl.DelControl('" + data[a].Dtuid + "','" + data[a].FieldName + "')>删除</a>";
                    str += "</td>";
                    str += "</tr>";
                }
                $("#ComList").html(str);
            }
        });
    },
    DelControl: function (Dtuid, FieldName) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/RemoteControlSet/DeleteControl",
                data: { Dtuid: Dtuid, FieldName: FieldName },
                dataType: "text",
                error: function () {
                    layer.alert("删除站点信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("删除站点信息成功！", 9, function () {
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("删除站点信息失败！", 8);
                    }
                }
            });
        });
    },
    EditContrl: function () {
        var obj = RemoteControl.GetControlObj();
        if (obj != null) {
            $.ajax({
                type: "post",
                url: "/RemoteControlSet/UpdateControl",
                data: obj,
                dataType: "text",
                error: function () {
                    layer.alert("修改站点信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("修改站点信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有修改权限！", 8);
                    }
                    else {
                        layer.alert("修改站点信息失败！", 8);
                    }
                }
            });
        }
    },
    AddControl: function () {
        var obj = RemoteControl.GetControlObj();
        if (obj != null) {
            $.ajax({
                type: "post",
                url: "/RemoteControlSet/AddControl",
                data: obj,
                dataType: "text",
                error: function () {
                    layer.alert("添加站点信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("添加站点信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert("添加站点信息失败！", 8);
                    }
                }
            });
        }
    },
    ShowAddControlView: function () {
        var url = "/RemoteControlSet/AddControlSet?Id=" + $("#ddlCompany").val();
        Common.WinTopBox('添加控制', '50%', '40%', '20%', '30%', url);
    },
    GetControlObj: function () {
        if (!Validate.IsRequired($("#FieldName").val())) {
            Stip("FieldName").show({ content: "字段名称不能为空", kind: "error", time: 3000 });
            $("#FieldName").focus();
            return null;
        }
        if (!Validate.IsNumber($("#DI_Index").val())) {
            Stip("DI_Index").show({ content: "输入值不能为空且为数字", kind: "error", time: 3000 });
            $("#DI_Index").focus();
            return null;
        }
        if (!Validate.IsNumber($("#DO_Index").val())) {
            Stip("DO_Index").show({ content: "输出值不能为空且为数字", kind: "error", time: 3000 });
            $("#DO_Index").focus();
            return null;
        }
        if (!Validate.IsNumber($("#ReturnState").val())) {
            Stip("ReturnState").show({ content: "控制到位值不能为空，且为数字", kind: "error", time: 3000 });
            $("#ReturnState").focus();
            return null;
        }
        var ControlObj = {
            Dtuid: $("#DtuidList").val(),
            FieldName: $("#FieldName").val(),
            DI_Index: $("#DI_Index").val(),
            DO_Index: $("#DO_Index").val(),
            ReturnState: $("#ReturnState").val()
        };
        return ControlObj;
    }
}