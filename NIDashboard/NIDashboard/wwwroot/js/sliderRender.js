var config = {
    effect: "",
    slices: 0,
    boxCols: 0,
    boxRows: 0,
    animSpeed: 0,
    pauseTime: 1000
}

var obj = config;

$(document).ready(function () {
    getBanners();
    getConfig();
    setTimeout(function () {
        startSlider();
    }, 1000);
});

function getBanners() {
    $.ajax({
        type: "GET",
        url: "/api/getbanner",
        contentType: "application/json; charset=utf-8",
        dataTye: "json",
        success: function (data) {
            let banners = "";
            $.each(data, function (i, item) {
                banners += "<img src='/banners/" + item.name + "'/>";
            });
            $(banners).appendTo("#slider");
        },
        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            alert(data.responseText);
        }
    });
}

function getConfig() {
    $.ajax({
        type: "GET",
        url: "/api/getconfig",
        contentType: "application/json; charset=utf-8",
        dataTye: "json",
        success: function (data) {
            obj.effect = data.effect;
            obj.animSpeed = data.animSpeed;
            obj.pauseTime = data.pauseTime;
        }
    });
}

let j = jQuery.noConflict();
function startSlider() {
    j("#slider").nivoSlider({
        effect: obj.effect,
        animSpeed: obj.animSpeed,
        pauseTime: obj.pauseTime
    });
}