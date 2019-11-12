//创建一个自调用函数    产生一个作用域
(function(window,undefined){
    //定位
    position="absolute";
    //存放食物
    var element=[];
    //食物的构造函数
    function Food(options){
        options = options || {};
        this.x = options.x || 0;
        this.y = options.y || 0;
        this.height = options.height || 20;
        this.width = options.width || 20;
        this.color = options.color || "red";
    }
    //在食物构造函数的原型里添加一个随机添加食物
    Food.prototype.render=function(map){
        //创建食物之前先删除之前的食物
        clearFood(element);

        var food=document.createElement("div");
        map.appendChild(food);
        element.push(food);
        this.x = Tools.getRandom(0 , (map.offsetWidth / this.width - 1));
        this.y = Tools.getRandom(0 , (map.offsetHeight / this.height -1));
        food.style.position = position;
        food.style.left = this.x  * this.width + "px";
        food.style.top = this.y  * this.height + "px";
        food.style.height = this.height + "px";
        food.style.width = this.width + "px";
        food.style.backgroundColor = this.color;
    }

    //清除食物
    function clearFood(element){
        for(var i=element.length-1 ; i >= 0 ; i--)
        {
            element[i].parentNode.removeChild(element[i]);
            element.splice(i , 1);
        }
    }

    //让里面创建的构造函数外部可以访问,加到window里
    window.Food=Food;

})(window,undefined)