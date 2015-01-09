var objShowPreLevel = {
    oComm: parent.Common,
    fnLoad: function () {
        $("#OperArea").click(function (evt) {
            var target = evt.target || evt;
            if (target.name == "cancel")
                parent.Common.layoutClose();
            if (target.name == "add")
                objShowPreLevel.fnAddPreLevel();
        });
        var oper = objShowPreLevel.fnUrlGetName("Oper");
        var name = objShowPreLevel.fnUrlGetName("id");
        objShowPreLevel.fnGetOnePreLevel(unescape(name));
        if (oper == "Show") {
            $("#PreLevelName,#PreLevelDesc,input[name=Status]").attr({ disabled: "disabled" });
        }
    },
    fnAddPreLevel: function () {
        var json = { Oper: null, ConfigId: null };
        json.Oper = PreLevelName.value;
        json.ConfigId = PreLevelDesc.value;
        if (!json.Oper || json.Oper.length == 0) {
            parent.alert("警告！压力名称不能为空");
            return null;
        }
        if (!json.ConfigId || json.ConfigId.length == 0) {
            parent.alert("警告！压力描述不能为空");
            return null;
        }

        $.ajax({
            type: "POST",
            dataType: "text",
            url: "/PreLevel/AddLevel",
            data: json,
            error: function (ex) { console.dir(ex); },
            success: function (back) {
                if (back == "True") {
                    var call = function () {
                        parent.Common.layoutClose();
                        var doc = $("#framecenter iframe", parent.document);
                        if (doc.length == 0)
                            return;
                        doc = doc[0].contentDocument.body;
                        $("#LevelName", doc).val(json.Oper);
                        $("input[name=query]", doc).click();
                    }
                    parent.alert("恭喜，添加成功！<br /><br />选择绿色√查询添加项，选择红色×继续添加", { isOk: call });
                    return;
                }
                parent.alert("对不起，添加失败！");
            }
        });
    },
    fnGetOnePreLevel: function (id) {
        if (isNaN(id)) return;
        $.ajax({
            type: "POST",
            dataType: "json",
            url: "/PreLevel/GetOneLevel",
            data: { id: id },
            error: function (ex) { console.dir(ex); },
            success: function (back) {
                if (back) {
                    $("#PreLevelName").val(back.PressureName);
                    $("#PreLevelDesc").val(back.PressureDesc);
                    var radio = $("input[name=Status]");
                    radio[back.Status].checked = true;
                }
            }
        });
    },
    //获取get方式url地址参数
    fnUrlGetName: function (name) {
        var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
        var r = window.location.search.substr(1).match(reg);
        if (r != null) return unescape(r[2]); return null;
    }
};
window.onload = objShowPreLevel.fnLoad;