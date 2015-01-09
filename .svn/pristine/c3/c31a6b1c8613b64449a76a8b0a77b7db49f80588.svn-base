var FiledMng = {
    //获取字段列表
    GetFiledList: function () {
        $.ajax({
            type: "POST",
            data: { Company: $("#ddlCompany").val(), Group: $("#ddlGroup").val(), SiteName: "" },
            url: "/FieldInfo/GetFiledList",
            dataType: "json",
            error: function () {
                layer.alert("查询字段信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var Str = "";
                for (var i = 0; i < data.length; i++) {
                    Str += "<tr><td class='com_TextCenter com_disnote'>" + data[i].Dtuid + "</td>";
                    Str += "<td class=' com_TextCenter com_disnote'>" + data[i].ColName + "</td>";
                    Str += "<td class=' com_TextCenter com_disnote'>" + data[i].FieldName + "</td>";
                    Str += "<td class=' com_TextCenter com_disnote'>" + data[i].FieldUnit + "</td>";
                    Str += "<td class=' com_TextRight com_disnote'>" + data[i].ValueMin + "</td>";
                    Str += "<td class=' com_TextRight com_disnote'>" + data[i].ValueMax + "</td>";
                    Str += "<td class=' com_TextRight com_disnote'>" + data[i].Lowlimit + "</td>";
                    Str += "<td class=' com_TextRight com_disnote'>" + data[i].Highlimit + "</td>";
                    Str += "<td class=' com_TextCenter com_disnote'>" + (data[i].IsAlert == 1 ? "是" : "否") + "</td>";
                    Str += "<td class=' com_TextCenter com_disnote'>" + (data[i].IsCollect == 1 ? "是" : "否") + "</td>";
                    Str += "<td class='com_TextCenter com_w15pen'>";
                    Str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('字段查看','80%','50%','15%','10%','FieldInfo/FieldInfoDetail?Oper=Show&ComId=" + data[i].Dtuid + "&FieldName=" + data[i].FieldName + "')>查看|</a> ";
                    Str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('字段修改','80%','50%','15%','10%','FieldInfo/FieldInfoDetail?Oper=Edit&ComId=" + data[i].Dtuid + "&FieldName=" + data[i].FieldName + "')>修改|</a> ";
                    Str += "<a href='javascript:void(0)' onclick=FiledMng.DeleteFiled(" + data[i].Id + ")>删除</a> ";
                    Str += "</tr>";
                }
                $("#ComList tbody").html(Str);
            }
        });
    },
    //显示添加字段View
    ShowAddFiledView: function () {
        var url = '/FieldInfo/ShowAddFiled?CompanyId=' + $("#ddlCompany").val() + "&Group=" + $("#ddlGroup").val();
        Common.WinTopBox('添加字段', '80%', '60%', '15%', '10%', url);
    },
    //添加字段
    AddFiled: function () {
        var obj = FiledMng.GetFiledObj(FiledMng.GetFieldName($("#ss").val(), $("#FiledName").val()));
        if (obj != null) {
            $.ajax({
                type: "POST",
                data: obj,
                url: "/FieldInfo/AddFiled",
                dataType: "text",
                error: function () {
                    layer.alert("添加字段信息失败，请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        alert("添加字段信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert("添加字段信息失败！", 8);
                    }
                }
            });
        }
    },
    //修改字段
    EditFiled: function () {
        var obj = FiledMng.GetFiledObj($("#FieldName").val());
        if (obj != null) {
            $.ajax({
                type: "POST",
                data: obj,
                url: "/FieldInfo/EditFiled",
                dataType: "text",
                error: function () {
                    layer.alert("修改字段信息失败，请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("修改字段信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    } else if (data == "4") {
                        layer.alert("没有修改权限！", 8);
                    }
                    else {
                        layer.alert("修改字段信息失败！", 8);
                    }

                }
            });
        }
    },
    GetFieldName: function (Index, fieldType) {
        var rslt = "";
        switch (fieldType) {
            case "QB":
            case "Q":
            case "VB":
            case "V":
            case "P":
            case "T":
                rslt = "M" + Index + fieldType;
                break;
            case "AI":
            case "DI":
                rslt = fieldType + Index;
                break;
            default:
                rslt = fieldType + Index;
                break;
        }
        return rslt;
    },
    //删除字段
    DeleteFiled: function (id) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "POST",
                data: { id: id },
                url: "/FieldInfo/DeleteFiled",
                dataType: "text",
                error: function () {
                    layer.alert("删除字段信息失败，请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("删除字段信息成功！", 9, function () {
                            //Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("删除字段信息失败！", 8);
                    }
                }
            });
            //FiledMng.GetFiledList();
        });
    },
    GetFiledObj: function (FieldName) {
        if (!Validate.IsRequired($("#FiledUint").val())) {
            Stip("FiledUint").show({ content: "单位不能为空", kind: "error", time: 3000 });
            $("#FiledUint").focus();
            return null;
        }
        if (!Validate.IsRequired($("#FieldShortDesc").val())) {
            Stip("FieldShortDesc").show({ content: "短描述不能为空", kind: "error", time: 3000 });
            $("#FieldShortDesc").focus();
            return null;
        }
        if (!Validate.IsRequired($("#FieldDesc").val())) {
            Stip("FieldDesc").show({ content: "描述不能为空", kind: "error", time: 3000 });
            $("#FieldDesc").focus();
            return null;
        }

        if (!Validate.IsRequired($("#ValueMax").val())) {
            Stip("ValueMax").show({ content: "最大值不能为空", kind: "error", time: 3000 });
            $("#ValueMax").focus();
            return null;
        }
        if (!Validate.IsRequired($("#ValueMin").val())) {
            Stip("ValueMin").show({ content: "最小值不能为空", kind: "error", time: 3000 });
            $("#ValueMin").focus();
            return null;
        }

        if (!Validate.IsRequired($("#Lowlimit").val())) {
            Stip("Lowlimit").show({ content: "最低报警值不能为空", kind: "error", time: 3000 });
            $("#Lowlimit").focus();
            return null;
        }
        if (!Validate.IsRequired($("#Hihilimit").val())) {
            Stip("Hihilimit").show({ content: "高报警值不能为空", kind: "error", time: 3000 });
            $("#Hihilimit").focus();
            return null;
        }

        var FiledObj = {
            Id: $("#FiledId").val(),
            Dtuid: $("#Dtuid").val(),
            ColName: "OPC_WINFO",
            FieldName: FieldName,
            FieldShortDesc: $("#FieldShortDesc").val(),
            FieldDesc: $("#FieldDesc").val(),
            FieldUnit: $("#FiledUint").val(),
            ValueMin: $("#ValueMin").val(),
            ValueMax: $("#ValueMax").val(),
            Lowlimit: $("#Lowlimit").val(),
            Highlimit: $("#Highlimit").val(),
            Lololimit: $("#Lololimit").val(),
            Hihilimit: $("#Hihilimit").val(),
            ValueInOrOut: $("#ValueInOrOut").val(),
            IsAlert: $(":radio[name='IsAlearm']:checked").val(),
            IsCollect: $(":radio[name='IsCollect']:checked").val(),
            IsShow: $(":radio[name='IsShow']:checked").val(),
            OrderId: $("#OrderId").val(),
            ParentId: $("#ParentId").val(),
            KeyValues: $("#KeyValues").val(),
            FieldType: $("#CountType").val()
        };
        return FiledObj;
    },
    AddFiledBatch: function () {
        var FiledArr = [];
        $("#ComList tbody tr").each(function (i, item) {
            var fileds = item.cells;
            var model = {
                "Id": 0,
                "ColName": "OPC_WINFO",
                "Dtuid": $(fileds[0]).text(),
                "FieldName": $(fileds[1]).text(),
                "FieldShortDesc": $(fileds[2]).children("input").val(),
                "FieldDesc": $(fileds[3]).children("input").val(),
                "FieldUnit": $(fileds[4]).children("input").val(),
                "ValueMin": $(fileds[5]).children("input").val(),
                "ValueMax": $(fileds[6]).children("input").val(),
                "Lowlimit": $(fileds[7]).children("input").val(),
                "Highlimit": $(fileds[8]).children("input").val(),
                "Lololimit": $(fileds[9]).children("input").val(),
                "Hihilimit": $(fileds[10]).children("input").val(),
                "ValueInOrOut": 0,
                "IsAlert": 1,
                "IsCollect": 1,
                "IsShow": 1,
                "UpdateFlag": 0,
                "OrderId": 0,
                "ParentId": 0,
                "KeyValues": "",
                "FieldType": 0
            }
            FiledArr.push(model);
        });

        $.ajax({
            type: "POST",
            data: "FiledArr=" + JSON.stringify(FiledArr),
            url: "/FieldInfo/AddFieldDescBatchOper",
            dataType: "text",
            error: function ()
            { layer.alert("请求失败，请稍后再试！", 8); },
            success: function (data) {
                if (data == "true") {
                    layer.confirm('批量添加字段信息成功，是否进行下一步？', function () {
                        window.location.href = "/UserInfo/AddUserV2";
                    }, function () {
                        Common.layoutTopClose();
                        $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                    });
                } else if (data == "4") {

                    layer.alert("当前用户无权限！", 8);
                }
                else {
                    layer.alert("批量添加字段信息失败！", 8);
                }
            }
        });
    },
    UpdateFiledBatch: function () {
        var FiledArr = [];
        $("#ComList tbody tr").each(function (i, item) {
            var fileds = $(item).children();
            var model = {
                "Id": 0,
                "Dtuid": $(fileds[0]).text(),
                "ColName": null,
                "FieldName": $(fileds[1]).text(),
                "FieldShortDesc": $(fileds[2]).text(),
                "FieldDesc": $(fileds[3]).text(),
                "FieldUnit": $(fileds[4]).text(),
                "ValueMin": $(fileds[5]).text(),
                "ValueMax": $(fileds[6]).text(),
                "Lowlimit": $(fileds[7]).text(),
                "Highlimit": $(fileds[8]).text(),
                "Lololimit": $(fileds[9]).text(),
                "Hihilimit": $(fileds[10]).text(),
                "ValueInOrOut": 0,
                "IsAlert": 1,
                "IsCollect": 1,
                "IsShow": 1,
                "UpdateFlag": 0,
                "OrderId": 0,
                "ParentId": 0,
                "KeyValues": "",
                "FieldType": 0
            }
            FiledArr.push(model);
        });
        $.ajax({
            type: "POST",
            data: "FiledArr=" + JSON.stringify(FiledArr),
            url: "/FieldInfo/AddFieldDescBatchOper",
            dataType: "text",
            error: function ()
            { layer.alert("请求失败，请稍后再试", 8); },
            success: function (data) {
                if (data == "true") {
                    layer.alert("批量修改成功", 8);
                    Common.layoutTopClose();
                    $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                } else if (data == "4") {
                    layer.alert("当前用户无权限", 8);
                }
                else {
                    layer.alert("删除失败", 8);
                }
            }
        });
    }
}