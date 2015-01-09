﻿//自定义检测类
var Validate = {
    IsRequired: function (obj) {
        if (obj.length == 0 || obj == "" || typeof (obj) == "undefined") {
            return false;
        }
        else { return true; }
    },
    IsCellPhone: function (obj) {
        var PhonePatten = new RegExp("^(((13|18|15)[0-9]{9})|147[0-9]{8}|145[0-9]{8})$");
        if (!PhonePatten.test(obj))
        { return false; }
        else
        { return true; }
    },
    IsIPAddress: function (obj) {
        var exp = /^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$/;
        var reg = exp.exec(obj);
        if (reg == null) {
            return false;
        }
        else { return true; }
    },
    IsEmail: function (obj) {
        var myreg = /^([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+@([a-zA-Z0-9]+[_|\_|\.]?)*[a-zA-Z0-9]+\.[a-zA-Z]{2,3}$/;
        if (myreg.test(obj))
        { return true; }
        else
        { return false; }
    },
    IsNumber: function (obj) {
        if (isNaN(obj))
        { return false; }
        else
        { return true; }
    },
    IsInt: function (str) {
        var r = /^\+?[1-9][0-9]*$/; //正整数 
        if (r.test(str))
        { return true; }
        else
        { return false; }
    },
    IsNumberAndCode: function (obj) {
        var Regx = /^[A-Za-z0-9]*$/;
        if (Regx.test(obj)) {
            return true;
        }
        else {
            return false;
        }
    },
    CheckBeginAndEndTime: function (begin, end) {
        if (begin > end)
        { return false; }
        else
        { return true; }
    },
    IsTelePhone: function (obj) {//固话，带区号
        var exp = new RegExp("^[0][1-9]{2,3}-[0-9]{5,10}$");
        if (!exp.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    },
    IsUrl: function (obj) {
        var exp = new RegExp("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&=]*)?");
        if (!exp.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    },
    IsPositiveInteger: function (obj) {//0或正整数
        var exp = new RegExp("^(0|[1-9][0-9]*)$");
        if (!exp.test(obj)) {
            return false;
        }
        else {
            return true;
        }
    },
    //判断只能输入数字和Backspace
    funOnlyNumber: function (obj) {
        var e = window.event || obj;
        if ((e.keyCode >= 48 && e.keyCode <= 57) || (e.keyCode >= 96 && e.keyCode <= 105) || e.keyCode == 8) {
            e.returnValue = true;
        }
        else {
            e.returnValue = false;
        }
    }
}