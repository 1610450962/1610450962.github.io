(function(window,undefined){
    var Tools={
        //随机数
        getRandom:function(min,max){
            min=Math.ceil(min);
            max=Math.floor(max);
            return Math.floor(Math.random()*(max-min+1)+min);
        }
    }
    window.Tools = Tools;
})(window,undefined)