var UserRole = {
    //查询用户角色
    SearchUserRole: function (roleName) {
        $.ajax({
            type: "post",
            url: "/UserRole/GetListByName",
            data: { roleName: roleName },
            dataType: "json",
            error: function () {
                layer.alert("查询角色信息失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w20pen com_TextCenter'>" + (data[i].RoleCode == null ? "" : data[i].RoleCode) + "</td>";
                    str += "<td class='com_w30pen com_TextCenter'>" + data[i].Name + "</td>";
                    str += "<td class='com_w30pen com_TextCenter'>" + data[i].Description + "</td>";
                    str += "<td class='com_w20pen com_TextCenter'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('角色查看','50%','40%','20%','30%','UserRole/RoleDetail?oper=Show&id=" + data[i].Id + "')>查看</a>";
                    //str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('角色修改','50%','40%','20%','30%','UserRole/RoleDetail?oper=Edit&id=" + data[i].Id + "')>修改|</a>";
                    //str += "<a href='javascript:void(0)' onclick=UserRole.DeleteUserRole('" + data[i].Id + "')>删除</a>";
                    str += "</td>";
                    str += "</tr>";
                }
                $("#UserRoleList tbody").html(str);
            }
        });
    },
    //添加角色
    AddUserRole: function () {
        var roleobj = UserRole.GetRoleObj();
        if (roleobj != null) {
            $.ajax({
                type: "post",
                url: "/UserRole/AddUserRole",
                data: roleobj,
                dataType: "text",
                error: function () {
                    layer.alert("添加角色信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "添加成功") {
                        layer.alert("添加角色信息成功！", 9, function () {
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
    //修改角色
    UpdateUserRole: function () {
        var roleobj = UserRole.GetRoleObj();
        if (roleobj != null) {
            $.ajax({
                type: "post",
                url: "/UserRole/UpdateUserRole",
                data: roleobj,
                dataType: "text",
                error: function () {
                    layer.alert("修改角色信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "更新成功") {
                        layer.alert("更新角色信息成功！", 9, function () {
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
    //删除角色
    DeleteUserRole: function (id) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/UserRole/DeleteUserRole",
                data: { id: id },
                dataType: "text",
                error: function () {
                    layer.alert("删除角色信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "1") {
                        layer.alert("删除角色信息成功！", 9, function () {
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "-1") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("删除角色信息失败！", 8);
                    }
                }
            });
        });
    },
    GetRoleObj: function () {
        if (!Validate.IsRequired($("#txtRoleCode").val())) {
            layer.alert("角色编码不能为空！", 8);
            return null;
        }
        if (!Validate.IsRequired($("#txtRoleName").val())) {
            layer.alert("角色名称不能为空！", 8);
            return null;
        }
        var RoleObj = {
            Id: $("#txtRoleName").attr("name"),
            RoleCode: $("#txtRoleCode").val(),
            Name: $("#txtRoleName").val(),
            Description: $("#txtRoleDesc").val()
        };
        return RoleObj;
    }
};