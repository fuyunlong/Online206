var VipDevice = {
    flag: true,
    //加载公司列表
    LoadCompanys: function () {
        $.ajax({
            type: "post",
            async: false,
            url: "/Company/GetComany",
            dataType: "json",
            error: function () {
                layer.alert("获取公司信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value=" + data[i].CompanyID + ">" + data[i].CompanyName + "</option>";
                }
                $("#ddlCompany").append(str);
            }
        });
    },
    //查询了站点列表
    GetDTUList: function () {
        var companyId = $("#ddlCompany").val() || "";
        $.ajax({
            type: "post",
            async: false,
            url: "/VipDevice/GetDTUListByComanyIdV2",
            data: { companyId: companyId },
            dataType: "json",
            error: function () {
                layer.alert("获取站点信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value='" + data[i].Key + "'>" + data[i].Value + "</option>"
                }
                if (str.length == 0) {
                    layer.alert(Common.SiteErrorMsg, 8);
                }
                $("#ddlSite").html(str);
            }
        });
    },
    GetDTUListV2: function () {
        var companyId = $("#ddlCompany").val() || "";
        $.ajax({
            type: "post",
            async: false,
            url: "/VipDevice/GetDTUListByComanyId",
            data: { companyId: companyId },
            dataType: "json",
            error: function () {
                layer.alert("获取站点信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value='" + data[i].Key + "'>" + data[i].Value + "</option>"
                }
                if (str.length == 0) {
                    layer.alert(Common.SiteErrorMsg, 8);
                }
                $("#ddlSite").html(str);
            }
        });
    },
    //查询设备信息
    GetVipDevice: function () {
        var dtuId = $("#ddlSite").val() || "";
        if (dtuId.length == 0) {
            layer.alert("请选择站点！", 8);
            return;
        }
        $.ajax({
            type: "post",
            url: "/VipDevice/GetVipDeviceList",
            data: { dtuId: dtuId },
            dataType: "json",
            error: function () {
                layer.alert("查询重要设备失败,请稍后再试！", 8);
            },
            success: function (data) {
                var html = "";
                for (var a in data) {
                    html += "<tr>";
                    html += "<td class='com_w20pen com_TextCenter'>" + data[a].DeviceName + "</td>";
                    html += "<td class='com_w20pen com_TextCenter'>" + data[a].DeviceBrand + "</td>";
                    html += "<td class='com_w20pen com_TextCenter'>" + data[a].ModelCode + "</td>";
                    html += "<td class='com_w20pen com_TextCenter'>" + Common.ChangeDate(data[a].ProduceDate) + "</td>";
                    html += "<td class='com_w20pen com_TextCenter'>";
                    html += "<a href='javascript:void(0)' onclick=Common.WinTopBox('设备查看','40%','62%','12%','30%','VipDevice/VipDeviceDetail?oper=Show&Id=" + data[a].Id + "')>查看|</a> ";
                    html += "<a href='javascript:void(0)' onclick=Common.WinTopBox('设备修改','40%','62%','12%','30%','VipDevice/VipDeviceDetail?oper=Edit&Id=" + data[a].Id + "')>修改|</a> ";
                    html += "<a href='javascript:void(0)' onclick=VipDevice.Delete('" + data[a].Id + "')>删除</a> ";
                    html += "</td>";
                    html += "</tr>";
                }
                $("#DeviceList tbody").html(html);
            }
        });
    },
    //添加设备
    Add: function () {
        var model = VipDevice.GetData();
        VipDevice.CheckData();
        if (VipDevice.flag) {
            $.ajax({
                type: "post",
                url: "/VipDevice/AddDevice",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("添加设备信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("添加设备信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert("添加设备信息失败！", 8);
                    }
                }
            });
        }
    },
    //修改设备
    Update: function () {
        var model = VipDevice.GetData();
        VipDevice.CheckData();
        if (VipDevice.flag) {
            $.ajax({
                type: "POST",
                url: "/VipDevice/UpdateDevice",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("修改设备信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("修改设备信息成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有修改权限！", 8);
                    }
                    else {
                        layer.alert("修改设备信息失败！", 8);
                    }
                }
            });
        }
    },
    //删除设备
    Delete: function (id) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/VipDevice/DeleteDevice",
                data: { id: id },
                dataType: "text",
                error: function () {
                    layer.alert("删除设备信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("删除设备信息成功！", 9, function () {
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("删除设备信息失败！", 8);
                    }
                }
            });
        });
    },
    //获取数据
    GetData: function () {
        var model = {
            Id: $("#txtDeviceName").attr("name"),
            DeviceName: $("#txtDeviceName").val().trim(),
            Dtuid: $("#ddlSite").val(),
            DeviceBrand: $("#txtBrand").val().trim(),
            DeviceSN: $("#txtDeviceSN").val().trim(),
            ModelCode: $("#txtModelCode").val().trim(),
            DeviceParams: $("#txtParams").val().trim(),
            ProduceDate: $("#txtDate").val(),
            Memo: $("#txtDesc").val().trim()
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        VipDevice.flag = true;
        if (!Validate.IsRequired($("#txtDeviceName").val())) {
            VipDevice.flag = false;
            Stip("txtDeviceName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtDeviceName").focus();
            return;
        }
        if (!$("#ddlSite").val()) {
            VipDevice.flag = false;
            Stip("tdSite").show({ content: "请选择站点", kind: "error", time: 3000 });
            $("#ddlSite").focus();
            return;
        }
    }
}