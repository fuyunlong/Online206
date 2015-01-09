PreLevel = {
    flag: true,
    //获取压力等级列表
    GetLevelList: function () {
        var levelName = $("#txtLevelName").val().trim();
        $.ajax({
            type: "post",
            url: "/PreLevel/GetLevelList",
            data: { levelName: levelName },
            dataType: "json",
            error: function () {
                layer.alert("查询压力等级失败,请稍后再试！", 8);
            },
            success: function (data) {
                var str = "";
                for (var i = 0; i < data.length; i++) {
                    str += "<tr>";
                    str += "<td class='com_w30pen com_TextCenter'>" + data[i].PressureName + "</td>";
                    str += "<td class='com_w40pen com_TextCenter com_disnote'>" + data[i].PressureDesc + "</td>";
                    str += "<td class='com_w30pen com_TextCenter'>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('等级查看','38%','30%','25%','35%','PreLevel/ShowDetail?oper=Show&id=" + data[i].Id + "')>查看|</a>";
                    str += "<a href='javascript:void(0)' onclick=Common.WinTopBox('等级修改','38%','30%','25%','35%','PreLevel/ShowDetail?oper=Edit&id=" + data[i].Id + "')>修改|</a>";
                    str += "<a href='javascript:void(0)' onclick=PreLevel.Delete('" + data[i].Id + "')>删除</a>";
                    str += "</td>";
                    str += "</tr>";
                }
                $("#LevelList tbody").html(str);
            }
        });
    },
    //添加
    Add: function () {
        var model = PreLevel.GetData();
        PreLevel.CheckData();
        if (PreLevel.flag) {
            $.ajax({
                type: "post",
                url: "/PreLevel/Add",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("添加压力等级失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("添加压力等级成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else {
                        layer.alert("添加压力等级失败！", 8);
                    }
                }
            });
        }
    },
    //修改
    Update: function () {
        var model = PreLevel.GetData();
        PreLevel.CheckData();
        if (PreLevel.flag) {
            $.ajax({
                type: "post",
                url: "/PreLevel/Update",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("修改压力等级失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("修改压力等级成功！", 9, function () {
                            Common.layoutTopClose();
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    } else if (data == "4") {
                        layer.alert("没有修改权限！", 8);
                    }
                    else {
                        layer.alert("修改压力等级失败！", 8);
                    }
                }
            });
        }
    },
    //删除
    Delete: function (id) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/PreLevel/Delete",
                data: { id: id },
                dataType: "text",
                error: function () {
                    layer.alert("删除压力等级失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("删除压力等级成功！", 9, function () {
                            $("#framecenter iframe", parent.document).contents().find("#btnQuery").trigger("click");
                        });
                    }
                    else if (data == "4") {
                        layer.alert("没有删除权限！", 8);
                    }
                    else {
                        layer.alert("删除压力等级失败！", 8);
                    }
                }
            });
        });
    },
    //获取数据
    GetData: function () {
        var model = {
            Id: $("#txtLevelName").attr("name"),
            PressureName: $("#txtLevelName").val().trim(),
            PressureDesc: $("#txtLevelDesc").val().trim()
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        PreLevel.flag = true;
        if (!Validate.IsRequired($("#txtLevelName").val())) {
            PreLevel.flag = false;
            Stip("txtLevelName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtLevelName").focus();
            return;
        }
    }
};