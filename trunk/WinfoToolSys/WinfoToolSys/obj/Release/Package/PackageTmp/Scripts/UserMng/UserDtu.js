﻿var UserDTU = {
    //加载公司列表
    LoadCompanys: function (callBack) {
        $.ajax({
            type: "post",
            url: "/Company/GetComany",
            dataType: "json",
            async: false,
            error: function () {
                layer.alert("获取公司信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value=" + data[i].CompanyID + ">" + data[i].CompanyName + "</option>";
                }
                $("#ddlCompany").append(str);
                $("#ddlCompanyV2").append(str);
                if (!callBack) {
                    return;
                }
                if (typeof callBack.constructor == "string") {
                    callBack = new Function(callBack);
                }
                callBack.call();
                UserDTU.GetGroupsByComId($("#ddlCompany").val());
            }
        });
    },
    //LoadCompanysV2: function () {
    //    $.ajax({
    //        type: "post",
    //        url: "/Company/GetComany",
    //        dataType: "json",
    //        async: false,
    //        error: function () {
    //            layer.alert("获取公司信息失败,请稍后再试！", 8);
    //        },
    //        success: function (data) {
    //            var str = "";

    //            for (var i = 0; i < data.length; i++) {
    //                str += "<option value=" + data[i].CompanyID + ">" + data[i].CompanyName + "</option>";
    //            }
    //            $("#ddlCompanyV2").append(str);
    //        }
    //    });
    //},
    //加载分组
    GetGroupsByComId: function (compId) {
        $.ajax({
            type: "post",
            data: { id: compId },
            url: "/SiteGroup/GetGroup",
            dataType: "json",
            async: false,
            error: function () {
                layer.alert("获取分组信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                str += "<option value=0>全部</option>";
                for (var i = 0; i < data.length; i++) {
                    str += '<option value="' + data[i].GroupCode + '">' + data[i].GroupName + '</option>';
                }
                $("#ddlGroup").html(str);
                UserDTU.GetDTUByGroupCode();
            }
        });
    },
    //根据分组编码查询站点
    GetDTUByGroupCode: function () {
        var companyId = $("#ddlCompany").val();
        var groupCode = $("#ddlGroup").val();
        $.ajax({
            type: "post",
            url: "/UserInfo/GetDTUByGroupCode",
            data: { companyId: companyId, groupCode: groupCode },
            dataType: "json",
            error: function () {
                layer.alert("获取站点信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += '<option value="' + data[i].Dtuid + '">' + data[i].DtuidName + '</option>';
                }
                $("#ddlDtu").html(str);
            }
        });
    },
    //查询站点用户
    SaerchSiteUser: function (srcObj, dtuId) {
        $.ajax({
            type: "post",
            url: "/UserInfo/GetUserInfoByDtuId",
            data: { dtuId: dtuId },
            dataType: "json",
            error: function () {
                layer.alert("查询用户信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w15pen com_TextCenter' >" + data[i].UserId + "</td>";
                    str += "<td class='com_w15pen com_TextCenter'>" + data[i].TrueName + "</td>";
                    str += "<td class='com_w15pen com_TextCenter'>" + data[i].UserPosition + "</td>";
                    str += "<td class='com_w15pen com_TextCenter'>" + data[i].UserPhone + "</td>";
                    str += "<td class='com_w20pen com_TextCenter'>" + data[i].UserMail + "</td>";
                    str += "<td class='com_w20pen com_TextCenter '>";
                    str += "<a href='javascript:void(0)' onclick=UserDTU.DeleteDtuidUser('" + data[i].UserId + "','" + dtuId + "')>删除</a> ";
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
    //查询用户
    SearchUser: function () {
        $.ajax({
            type: "post",
            url: "/UserInfo/GetUserList",
            data: { CompanyId: $("#ddlCompany").val(), GroupCode: $("#ddlGroup").val() },
            dataType: "json",
            error: function () {
                layer.alert("查询用户信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w20pen com_TextLeft'>" + data[i].UserId + "</td>";
                    str += "<td class='com_w20pen com_TextLeft'>" + data[i].TrueName + "</td>";
                    str += "<td class='com_w20pen com_TextLeft'>" + data[i].UserPosition + "</td>";
                    str += "<td class='com_w20pen com_TextCenter'>" + data[i].UserPhone + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('查看信息','80%','80%','10%','10%','UserInfo/UserDeatail?Oper=Show&UserId=" + data[i].UserId + "')>查看|</a> ";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('修改信息','80%','80%','10%','10%','UserInfo/UserDeatail?Oper=Edit&UserId=" + data[i].UserId + "')>修改|</a> ";
                    str += "<a href='javascript:void(0)' onclick=UserDTU.DeleteUserV2('" + data[i].UserId + "','" + data[i].EmployeeID + "')>删除</a> ";
                    str += "</td></tr>";
                }
                $("#UserList tbody").html(str);
            }
        });
    },
    //删除用户信息
    DeleteUser: function (dtuid) {
        $.ajax({
            type: "post",
            url: "/UserInfo/GetUserList",
            data: { CompanyId: $("#ddlCompany").val(), GroupCode: $("#ddlGroup").val() },
            dataType: "json",
            error: function () {
                layer.alert("获取用户信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w15pen com_TextLeft com_disnote' >" + data[i].UserId + "</td>";
                    str += "<td class='com_w15pen com_TextLeft com_disnote'>" + data[i].TrueName + "</td>";
                    str += "<td class='com_w15pen com_TextLeft com_disnote'>" + data[i].UserPosition + "</td>";
                    str += "<td class='com_w15pen com_TextCenter com_disnote'>" + data[i].UserPhone + "</td>";
                    str += "<td class='com_TextCenter com_w20pen'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('查看信息','80%','80%','10%','10%','UserInfo/UserDeatail?Oper=Show&UserId=" + data[i].UserId + "')>查看|</a> ";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('修改信息','80%','80%','10%','10%','UserInfo/UserDeatail?Oper=Edit&UserId=" + data[i].UserId + "')>修改|</a> ";
                    str += "<a href='javascript:void(0)' onclick=UserDTU.DeleteUserV2(" + data[i].UserId + "," + data[i].EmployeeId + ")>删除|</a> ";
                    str += "</td></tr>";
                }
                $("#UserList tbody").html(str);
            }
        });
    },
    DeleteUserV2: function (UserId, EmployeeId) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/UserInfo/DeleteUserInfo",
                data: { UserId: UserId, EmployeeId: EmployeeId },
                dataType: "json",
                error: function () {
                    layer.alert("删除用户信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("删除用户信息成功！", 9, function () {
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("删除用户信息失败！", 8);
                    }
                }
            });
        });
    },
    //添加站点用户
    AddDtuidUser: function () {
        var userId = "";
        var dtuId = $("input[type=checkbox]:first").attr("name");
        for (var i = 0; i < $("input[type=checkbox]:checked").length; i++) {
            if (i != $("input[type=checkbox]:checked").length - 1) {
                userId += $("input[type=checkbox]:checked")[i].value + ",";
            }
            else {
                userId += $("input[type=checkbox]:checked")[i].value;
            }
        }
        $.ajax({
            type: "post",
            url: "/UserInfo/Add",
            data: { userId: userId, dtuId: dtuId },
            dataType: "text",
            error: function () {
                layer.alert("添加用户信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                if (data == "true") {
                    layer.alert("添加用户信息成功！", 9, function () {
                        Common.layoutTopClose();
                        $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                    });
                }
                else {
                    layer.alert(data, 8);
                }
            }
        });
    },
    //删除站点用户
    DeleteDtuidUser: function (uid, did) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/UserInfo/Delete",
                data: { userId: uid, dtuId: did },
                dataType: "text",
                error: function () {
                    layer.alert("删除用户信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "删除成功") {
                        layer.alert("删除用户信息成功！", 9, function () {
                            Common.layoutTopClose();
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
    //加载用户
    CheckData: function () {
        Common.WinTopBox("用户添加", "80%", "80%", "10%", "10%", "UserInfo/AddUserV2?companyId=-1");
    },
    //添加用户
    AddUser: function (companyId, dtuId) {
        if (!dtuId) {
            layer.alert("请先选择站点！", 8);
            return;
        }
        Common.WinTopBox("用户添加", "80%", "80%", "10%", "10%", "UserInfo/AddUser?companyId=" + companyId + "&dtuId=" + dtuId);
    },
    GetDTUListByComanyId: function (company) {
        $.ajax({
            type: "post",
            url: "/VipDevice/GetDTUListByComanyId",
            data: { companyId: company },
            dataType: "json",
            error: function () {
                layer.alert("获取站点信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<p><input type='checkBox' onchange='UserDTU.CreateSiteList(this)' name='checkSite'   value='" + data[i].Key + "' >" + data[i].Value + "</input></p>";
                }
                $("#AreaSite").html(str);
            }
        });
    },
    GetDTUListByComanyIdV2: function (company) {
        $.ajax({
            type: "post",
            url: "/VipDevice/GetDTUListByComanyIdV2",
            data: { companyId: company },
            dataType: "json",
            error: function () {
                layer.alert("获取站点信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<p><input type='checkBox' onchange='UserDTU.CreateSiteList(this)' name='checkSite'   value='" + data[i].Key + "' >" + data[i].Value + "</input></p>";
                }
                $("#AreaSite").html(str);
            }
        });
    },
    GetUserRole: function () {
        $.ajax({
            type: "post",
            url: "/UserRole/GetListByName",
            dataType: "json",
            error: function () {
                layer.alert("获取角色信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += " <option value=" + data[i].RoleCode + ">" + data[i].Name + "</option>";
                }
                $("#UserRole").html(str);
            }
        });
    },
    GetUserFeeType: function () {
        $.ajax({
            type: "post",
            url: "/UserFee/GetFeeList",
            dataType: "json",
            error: function () {
                layer.alert("获取费用信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var Str = "";
                for (var i = 0; i < data.length; i++) {
                    Str += " <option value=" + data[i].BillCode + ">" + data[i].BillName + "</option>";
                }
                $("#UserFee").html(Str);
            }
        });
    },
    DeleteSiteToRoute: function (IsAll) {
        if (IsAll) {
            this.arr = [];
            $("#RouteSite").html("");
        }
        else {
            var inputs = $("#RouteSite>p>input");
            var count = 0;
            for (var i = 0; i < inputs.length; i++) {
                if ($(inputs[i]).attr("checked") == "checked") {
                    count++;
                    $(inputs[i]).parents("p").remove();
                    for (var c = 0; c < this.arr.length; c++) {
                        if ($(inputs[i]).val() == this.arr[c].code) {
                            this.arr.splice(c, 1);
                            break;
                        }
                    }
                }
            }
            if (count == 0) {
                layer.alert("请选择要删除的站点！", 8);
            }
        }
    },
    AddChousedInArr: function () {
        var inputs = $("#RouteSite>p>input");
        for (var i = 0; i < inputs.length; i++) {
            UserDTU.arr.push({ code: $(inputs[i]).val(), name: $(inputs[i].nextSibling).text() });
        }
    },
    AddSiteToRoute: function (IsAll) {
        var sites = [];
        if (IsAll) {
            sites = $("#AreaSite>p").children("input");
        }
        else {
            sites = $("#AreaSite>p").children("input[checked=checked]");
        }
        if (sites.length == 0) {
            layer.alert("请选择要添加的站点！", 8);
            return;
        }
        for (var i = 0; i < sites.length; i++) {
            var a = $("#RouteSite>p").children("input[value=" + $(sites[i]).val() + "]").length;
            if (a == 0) {
                $("#RouteSite").append("<p><input type=checkbox  value=" + $(sites[i]).val() + "><font>" + $(sites[i].nextSibling).text() + "</font></p>");
                UserDTU.arr.push({ code: $(sites[i]).val(), name: $(sites[i].nextSibling).text() });
            }
        }
        for (var i = 0; i < sites.length; i++) {
            $(sites[i]).removeAttr("checked");
        }

    },
    arr: [], //要添加的巡点集合
    CreateSiteList: function (obj) {
        var checked = false;
        if ($(obj).attr("checked") == "checked") {
            checked = true;
        }
        if (checked) {
            $(obj).attr("checked", "checked");
            for (var i = 0; i < UserDTU.arr.length; i++) {
                if (UserDTU.arr[i].code == $(obj).val()) {
                    layer.alert("已经存在该站点！");
                    return;
                }
            }
            UserDTU.arr.push({ code: $(obj).val(), name: $(obj)[0].nextSibling.textContent });
        }
        else {
            for (var i = 0; i < RouteMng.arr.length; i++) {
                if (UserDTU.arr[i].code == $(obj).val()) {
                    UserDTU.arr.splice(i, 1);
                    return;
                }
            }
        }
    },
    GetConfigList: function () {
        $.ajax({
            type: "post",
            url: "/Config/GetConfigByName",
            data: { configName: "" },
            dataType: "json",
            error: function () {
                layer.alert("获取配置信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<option value=" + data[i].CCode + ">" + data[i].ConfigName + "</option>";
                }
                $("#Config").html(str);
            }
        });
    },
    //添加用户
    AddUserV2: function () {
        var obj = UserDTU.GetObj();
        if (obj != null) {
            $.ajax({
                type: "post",
                url: "/UserInfo/AddUserV2Oper",
                data: obj,
                dataType: "text",
                error: function () {
                    layer.alert("添加用户信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("添加用户信息成功！", 9);
                    }
                    else {
                        layer.alert("添加用户信息失败！", 8);
                    }
                }
            });
        }
    },
    GetObj: function () {
        var Sites = [];
        for (var a in UserDTU.arr) {
            Sites.push(UserDTU.arr[a].code);
        }
        var obj = {
            UserId: $("#UserId").val(),
            EmployeeID: $("#EmployeeID").val(),
            EmpName: $("#TrueName").val(),
            UserName: $("#UserId").val(),
            UserPwd: $("#UserPwd").val(),
            EmpTelphone: $("#UserPhone").val(),
            EmpAddress: $("#LinkAddr").val(),
            LinkAddr: $("#LinkAddr").val(),
            BirthDay: $("#BirthDay").val(),
            CompanyId: $("#ddlCompany").val(),
            CCode: $("#UserConfig").val(),
            BillCode: $("#UserFee").val(),
            DepartName: Sites.toString(),//用部门存用户站点列表
            DepartID: $("#Departs").val(),
            PosID: $("#Position").val(),
            EmpSex: $("#ddlGroup").val()//用性别存用户分组信息
        };
        if (!Validate.IsRequired($("#UserId").val())) {
            layer.alert("用户编号不能为空！", 8);
            return null;
        }
        if (!Validate.IsRequired($("#TrueName").val())) {
            layer.alert("用户名不能为空！", 8);
            return null;
        }
        if (!Validate.IsRequired($("#UserPhone").val())) {
            layer.alert("用户号码不能为空！", 8);
            return null;
        }
        return obj;
    },
    UpdateUser: function () {
        var obj = UserDTU.GetObj();
        if (obj != null) {
            $.ajax({
                type: "post",
                url: "/UserInfo/UpdateUser",
                data: obj,
                dataType: "text",
                error: function () {
                    layer.alert("修改用户信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("修改用户信息成功！", 9);
                    } else if (data == "4") {
                        layer.alert("无修改权限！", 8);
                    }
                    else {
                        layer.alert("修改用户信息失败！", 8);
                    }
                }
            });
        }
    },
    GetUserInfo: function () {
        $.ajax({
            type: "post",
            url: "/UserInfo/GetUserInfo",
            data: obj,
            dataType: "text",
            error: function () {
                layer.alert("获取用户信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                if (data == "1") {
                    layer.alert("修改用户信息成功！", 9);
                }
                else {
                    layer.alert("修改用户信息失败！", 8);
                }
            }
        });
    }
}