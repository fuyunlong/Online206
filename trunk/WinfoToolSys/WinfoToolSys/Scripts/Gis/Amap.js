var Amap = {
    mapObj: null,
    markId: null,
    lineArr: [],
    cluster: null,
    InitMap: function () {
        var height = $(window).height() - 10;
        $("#iCenter").css("height", height);
        Amap.mapObj = new AMap.Map("iCenter", {
            center: new AMap.LngLat(104.06, 30.67), //地图中心点,成都
            level: 5  //地图显示的缩放级别  
        });
        //地图中添加地图操作ToolBar插件,聚合插件 
        //Amap.mapObj.plugin(["AMap.ToolBar"], function () {
        //    toolBar = new AMap.ToolBar();
        //    Amap.mapObj.addControl(toolBar);
        //});
        window.onresize = function () {
            height = $(window).height() - 10;
            $("#iCenter").css("height", height);
        }
       // var buildings = new AMap.Buildings(); //实例化3D楼块图层
        //var a = buildings.setMap(Amap.mapObj);
    }
};