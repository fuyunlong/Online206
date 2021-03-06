﻿var UserFee = {
    flag: true,
    //添加
    Add: function () {
        var model = UserFee.GetData();
        UserFee.CheckData();
        if (UserFee.flag) {
            $.ajax({
                type: "post",
                url: "/UserFee/Insert",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("添加计费信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("添加计费信息成功！", 9, function () {
                            //关闭窗口
                            Common.layoutTopClose();
                            //刷新
                            $("#framecenter iframe", parent.document).attr("src", "UserFee/Index");
                        });
                    }
                    else {
                        layer.alert("添加计费信息失败！", 8);
                    }
                }
            });
        }
    },
    //修改
    Update: function () {
        var model = UserFee.GetData();
        UserFee.CheckData();
        if (UserFee.flag) {
            $.ajax({
                type: "post",
                url: "/UserFee/Update",
                data: model,
                dataType: "text",
                error: function () {
                    layer.alert("修改计费信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("修改计费信息成功！", 9, function () {
                            //关闭窗口
                            Common.layoutTopClose();
                            //刷新
                            $("#framecenter iframe", parent.document).attr("src", "UserFee/Index");
                        });
                    }
                    else {
                        layer.alert("修改计费信息失败！", 8);
                    }
                }
            });
        }
    },
    //删除
    Delete: function (billCode) {
        layer.confirm('你确定要删除吗？', function () {
            $.ajax({
                type: "post",
                url: "/UserFee/DeleteFee",
                data: { billCode: billCode },
                dataType: "text",
                error: function () {
                    layer.alert("删除计费信息失败,请稍后再试！", 8);
                },
                success: function (data) {
                    if (data == "true") {
                        layer.alert("删除计费信息成功！", 9, function () {
                            //关闭窗口
                            Common.layoutTopClose();
                            //刷新
                            $("#framecenter iframe", parent.document).attr("src", "UserFee/Index");
                        });
                    }
                    else {
                        layer.alert("删除计费信息失败！", 8);
                    }
                }
            });
        });
    },
    //获取数据
    GetData: function () {
        var model = {
            BillCode: $("#txtFeeName").attr("name"),
            BillName: $("#txtFeeName").val().trim(),
            AlertFee: $("#txtAlertFee").val().trim(),
            DataFee: $("#txtDataFee").val().trim(),
            BookFee: $("#txtBookFee").val().trim(),
            RptFee: $("#txtRptFee").val().trim(),
            OtherFee: $("#txtOtherFee").val().trim(),
            DayMax: $("#txtDayMax").val().trim(),
            MonthMax: $("#txtMonthMax").val().trim()
        };
        return model;
    },
    //数据验证
    CheckData: function () {
        UserFee.flag = true;
        if (!Validate.IsRequired($("#txtFeeName").val())) {
            UserFee.flag = false;
            Stip("txtFeeName").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtFeeName").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtAlertFee").val())) {
            UserFee.flag = false;
            Stip("txtAlertFee").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtAlertFee").focus();
            return;
        }
        if (!Validate.IsNumber($("#txtAlertFee").val())) {
            UserFee.flag = false;
            Stip("txtAlertFee").show({ content: "输入数字", kind: "error", time: 3000 });
            $("#txtAlertFee").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtDataFee").val())) {
            UserFee.flag = false;
            Stip("txtDataFee").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtDataFee").focus();
            return;
        }
        if (!Validate.IsNumber($("#txtDataFee").val())) {
            UserFee.flag = false;
            Stip("txtDataFee").show({ content: "输入数字", kind: "error", time: 3000 });
            $("#txtDataFee").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtBookFee").val())) {
            UserFee.flag = false;
            Stip("txtBookFee").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtBookFee").focus();
            return;
        }
        if (!Validate.IsNumber($("#txtBookFee").val())) {
            UserFee.flag = false;
            Stip("txtBookFee").show({ content: "输入数字", kind: "error", time: 3000 });
            $("#txtBookFee").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtRptFee").val())) {
            UserFee.flag = false;
            Stip("txtRptFee").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtRptFee").focus();
            return;
        }
        if (!Validate.IsNumber($("#txtRptFee").val())) {
            UserFee.flag = false;
            Stip("txtRptFee").show({ content: "输入数字", kind: "error", time: 3000 });
            $("#txtRptFee").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtDayMax").val())) {
            UserFee.flag = false;
            Stip("txtDayMax").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtDayMax").focus();
            return;
        }
        if (!Validate.IsInt($("#txtDayMax").val())) {
            UserFee.flag = false;
            Stip("txtDayMax").show({ content: "输入整数", kind: "error", time: 3000 });
            $("#txtDayMax").focus();
            return;
        }
        if (!Validate.IsRequired($("#txtMonthMax").val())) {
            UserFee.flag = false;
            Stip("txtMonthMax").show({ content: "不能为空", kind: "error", time: 3000 });
            $("#txtMonthMax").focus();
            return;
        }
        if (!Validate.IsInt($("#txtMonthMax").val())) {
            UserFee.flag = false;
            Stip("txtMonthMax").show({ content: "输入整数", kind: "error", time: 3000 });
            $("#txtMonthMax").focus();
            return;
        }
        if ($("#txtOtherFee").val() != "" && !Validate.IsNumber($("#txtOtherFee").val())) {
            UserFee.flag = false;
            Stip("txtOtherFee").show({ content: "输入数字", kind: "error", time: 3000 });
            $("#txtOtherFee").focus();
            return;
        }
    }
};
