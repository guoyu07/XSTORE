window.onload = function () {
    document.getElementById("map1").onclick = show;
    document.getElementById("map2").onclick = hide;
};


function show() {
    var loadbox = document.getElementById("loadlayer");
    var overlayer = document.getElementById("overlayer");
    loadbox.style.display = "block";
    overlayer.style.display = "block";
}

function hide() {
    var loadbox = document.getElementById("loadlayer");
    var overlayer = document.getElementById("overlayer");
    loadbox.style.display = "none";
    overlayer.style.display = "none";
}  