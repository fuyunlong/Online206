var ClientMng = {
    flag: true,
    //查询
    Serarch: function (srcObj, cityId) {
        $.ajax({
            type: "post",
            url: "/Company/GetComany",
            data: { cityId: cityId },
            dataType: "json",
            error: function () {
                layer.alert("查询公司信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_TextLeft com_w25pen'>" + data[i].CompanyName + "</td>";
                    str += "<td class='com_TextCenter com_w10pen'>" + data[i].LinkPerson + "</td>";
                    str += "<td class='com_TextCenter com_w10pen'>" + data[i].MobilePhone + "</td>";
                    str += "<td class='com_TextLeft com_w17pen'>" + data[i].CmpWebSite + "</td>";
                    str += "<td class='com_TextLeft com_w18pen'>" + data[i].Email + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('公司查看','80%','80%','12%','10%','ClientInfo/ClientDetail?oper=Show&companyId=" + data[i].CompanyID + "')>查看|</a>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('公司修改','80%','80%','12%','10%','ClientInfo/ClientDetail?oper=Edit&companyId=" + data[i].CompanyID + "')>修改|</a>";
                    str += "<a href='javascript:void(0)' onclick=ClientMng.Delete(" + data[i].CompanyID + ")>删除</a>";
                    str += "</td>";
                    str += "</tr>";
                }
                srcObj.html(str);
            }
        });
    },
    //省份改变
    ProvinceChange: function () {
        Common.GetCity($("#ddlCity"), $("#ddlProvice").val(), null);
    },
    //获取所有母公司
    GetParentCompany: function (srcObj, callBack) {
        $.ajax({
            type: "post",
            url: "/Company/GetComany",
            dataType: "json",
            error: function () {
                layer.alert("获取公司信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "<option value=0>--无母公司--</option>";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value=" + data[i].CompanyID + ">" + data[i].CompanyName + "</option>";
                }
                srcObj.append(str);
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
    //获取所有公司配置信息
    GetCompanyConfig: function (srcObj, callBack) {
        $.ajax({
            type: "post",
            url: "/Config/GetConfigList",
            dataType: "json",
            error: function () {
                layer.alert("获取公司配置信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<input type=checkbox value=" + data[i].ConfigId + ">" + data[i].ConfigName + "<br/>";
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
    //获取指定公司的配置信息
    GetCompanyConfigByCompanyId: function (companyId) {
        $.ajax({
            type: "post",
            url: "/Config/GetCompanyConfig",
            dataType: "json",
            data: { companyId: companyId },
            error: function () {
                layer.alert("获取公司配置信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                for (var i = 0; i < data.length; i++) {
                    for (var j = 0; j < $("#divComCoinfig input[type=checkbox]").length; j++) {
                        if (data[i].ConfigId == $("#divComCoinfig input[type=checkbox]")[j].value) {
                            $("#divComCoinfig input[type=checkbox]")[j].checked = true;
                            continue;
                        }
                    }
                }
            }
        });
    },
    //添加
    Add: function () {
        var model = ClientMng.GetData();
        ClientMng.CheckData();
        if (ClientMng.flag) {
            $.ajax({
                type: "post",
                url: "/ClientInfo/Add",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("添加公司信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "注册失败!") {
                        layer.alert("添加公司信息失败！", 8);
                    }
                    else {
                        layer.confirm('添加成功，是否进行下一步？', function () {
                            location.href = "/SiteInfo/AddSite?companyId=" + data;
                        }, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                }
            });
        }
    },
    //修改
    Update: function () {
        var model = ClientMng.GetData();
        ClientMng.CheckData();
        if (ClientMng.flag) {
            $.ajax({
                type: "post",
                url: "/ClientInfo/Update",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("修改公司信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "更新成功") {
                        layer.alert("修改公司信息成功！", 9, function () {
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
    Delete: function (companyId) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/ClientInfo/Delete",
                data: { companyID: companyId },
                dataType: "text",
                error: function () {
                    layer.alert("删除公司信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "删除成功") {
                        layer.alert("删除公司信息成功！", 9, function () {
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
        var checkeds = $("#divComCoinfig input[type=checkbox]:checked");
        var config = [];
        $.each(checkeds, function (i, n) {
            config.push($(n).val());
        });
        var model = {
            CompanyID: $("#txtCompanyName").attr("name"),
            CompanyName: $("#txtCompanyName").val().trim(),
            LinkPerson: $("#txtLinkMan").val().trim(),
            Telphone: $("#txtPhone").val().trim(),
            Email: $("#txtEmail").val().trim(),
            FaxTel: $("#txtFax").val().trim(),
            CmpWebSite: $("#txtWebSite").val().trim(),
            CmpAddress: $("#txtAddress").val().trim(),
            MobilePhone: $("#txtMobile").val().trim(),
            Remark: $("#txtComDesc").val().trim(),
            ParentCompanyID: $("#ddlMonCompany option:selected").text(),
            CityID: $("#ddlCity").val(),
            CityName: $("#ddlCity option:selected").text(),
            Province: config.toString()//to do：用这个字段保存公司配置信息，实际添加过程没有用到这个字段
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        ClientMng.flag = true;
        if (!Validate.IsRequired($("#txtCompanyName").val())) {
            ClientMng.flag = false;
            Stip("txtCompanyName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtCompanyName").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtLinkMan").val())) {
            ClientMng.flag = false;
            Stip("txtLinkMan").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtLinkMan").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtPhone").val())) {
            ClientMng.flag = false;
            Stip("txtPhone").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtPhone").focus();
            return;
        }
        if (!Validate.IsTelePhone($("#txtPhone").val())) {
            ClientMng.flag = false;
            Stip("txtPhone").show({ content: "号码错误", kind: "error", time: 3000 });
            $("#txtPhone").focus();
            return;
        }
        if ($("#txtMobile").val() != "" && !Validate.IsCellPhone($("#txtMobile").val())) {
            ClientMng.flag = false;
            Stip("txtMobile").show({ content: "号码错误", kind: "error", time: 3000 });
            $("#txtMobile").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtEmail").val())) {
            ClientMng.flag = false;
            Stip("txtEmail").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtEmail").focus();
            return;
        }
        if (!Validate.IsEmail($("#txtEmail").val())) {
            ClientMng.flag = false;
            Stip("txtEmail").show({ content: "格式错误", kind: "error", time: 3000 });
            $("#txtEmail").focus();
            return;
        }
        if ($("#txtFax").val() != "" && !Validate.IsTelePhone($("#txtFax").val())) {
            ClientMng.flag = false;
            Stip("txtFax").show({ content: "格式错误", kind: "error", time: 3000 });
            $("#txtFax").focus();
            return;
        }
        if ($("#txtWebSite").val() != "" && !Validate.IsUrl($("#txtWebSite").val())) {
            ClientMng.flag = false;
            Stip("txtWebSite").show({ content: "格式错误", kind: "error", time: 3000 });
            $("#txtWebSite").focus();
            return;
        }
        if ($("#divComCoinfig input[type=checkbox]:checked").size() == 0) {
            ClientMng.flag = false;
            Stip("divComCoinfig").show({ content: "请选择配置", kind: "error", time: 3000 });
            return;
        }
    }
}