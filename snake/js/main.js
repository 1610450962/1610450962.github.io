(function(window,undefined){
    var map = document.getElementById("map");
    var button = document.getElementById("control").children;
    var minute = document.getElementById("minute");
    var game = new Game(map,minute);
    game.render(button);
})(window,undefined)