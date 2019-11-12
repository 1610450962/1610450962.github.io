//Tools
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
})(window,undefined);

//Food
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
        this.color = options.color || "green";
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

})(window,undefined);

//Snake
(function(window,undefined){
    //定位
    var position = "absolute"
    //蛇的每一个元素
    var element = [];
    //蛇的构造函数
    function Snake(options){
        options = options || {};
        this.width = options.width || 20;
        this.height = options.heifht || 20;
        //移动方向
        this.direction = options.direction || "right";
        //身体
        this.body=[
            {x : 3 , y : 2 , color : "red"},
            {x : 2 , y : 2 , color : "blue"},
            {x : 1 , y : 2 , color : "blue"},
        ];
    }

    //蛇的渲染
    Snake.prototype.render=function(map){
        //清除当前蛇
        clearSnake(element);
        //创建新位置的蛇
        for(var i=0 ; i < this.body.length ; i++)
        {
            var object = this.body[i];
            var div = document.createElement("div");
            element.push(div);
            map.appendChild(div);
            div.style.position = position;
            div.style.border = "1px solid yellow";
            div.style.height = this.height + "px";
            div.style.width = this.width + "px";
            div.style.left = object.x * this.width + "px";
            div.style.top = object.y * this.height + "px";
            div.style.backgroundColor = object.color;
        }
    }
    //清除蛇
    function clearSnake(element){
        var a=0;
        for(var i=element.length-1 ; i >=0 ; i--)
        {
            element[i].parentNode.removeChild(element[i]);
            element.splice(i , 1);
        }
    }

    //移动
    Snake.prototype.move=function(food , map , minute){
        //身体的移动
        for(var i=this.body.length - 1 ; i > 0 ; i--)
        {
            this.body[i].x = this.body[i-1].x;
            this.body[i].y = this.body[i-1].y;
        }
        //头
        var head = this.body[0];
        //头的移动
        //头移动的方向
        switch(this.direction)
        {
            case 'right':
                head.x += 1;
                break;
            case 'left':
                head.x -= 1;
                break;
            case 'top':
                head.y -= 1;
                break;
            case 'bottom':
                head.y += 1;
        }
        //蛇头吃到食物
        if(this.body[0].x == food.x && this.body[0].y == food.y)
        {
            this.body.push({x : this.body[this.body.length-1].x, y : this.body[this.body.length-1].y, color : this.body[this.body.length-1].color})
            food.render(map);
            minute.innerText="分数：" + (this.body.length - 3);
        }
    }

    window.Snake = Snake; 
})(window,undefined);

//Game
(function(window,undefined){
    var that;//记录游戏的对象
    
    function Game(map,minute){
        this.food = new Food();
        this.snake = new Snake();
        this.map = map;
        this.minute=minute;
        that = this;
    }

    
    Game.prototype.render = function(button){
        //1把蛇和食物渲染出来
        this.food.render(this.map);
        this.snake.render(this.map);
        
        //2开始游戏
        //2.1移动
        runSnake();
        //点击键盘控制方向
        preKey(button);
    }

    //移动
    function runSnake(){

        var timeId=setInterval(function(){
            //蛇移动
            this.snake.move(this.food,this.map,this.minute);

            //判断边界
            var headX = this.snake.body[0].x;
            var headY = this.snake.body[0].y;
            var maxX = this.map.offsetWidth / this.snake.width;
            var maxY = this.map.offsetHeight / this.snake.height;
            if(headX < 0 || headX >= maxX || headY < 0 || headY >= maxY)
            {
                clearTimeout(timeId);
                var a = confirm("是否重新开始？");
                if(a)
                {
                    minute.innerText="分数："+ 0;
                    this.snake.direction = "right";
                    this.snake.body = [
                        {x : 3 , y : 2 , color : "red"},
                        {x : 2 , y : 2 , color : "blue"},
                        {x : 1 , y : 2 , color : "blue"},
                    ];
                    this.render();
                }
            }
            else
            {
                this.snake.render(this.map);
            }
        }.bind(that), 150);
    }
    //键盘控制蛇的方向
    function preKey(button){
        if(document.body.offsetWidth < 760)
        {
            if(button)
            {
                button[0].addEventListener("click",function(){that.snake.direction = "left";});
                button[1].addEventListener("click",function(){that.snake.direction = "right";});
                button[2].addEventListener("click",function(){that.snake.direction = "top";});
                button[3].addEventListener("click",function(){that.snake.direction = "bottom";});
            }
        }
        document.addEventListener("keydown",function(e){
            switch(e.keyCode)
            {
                case 37:
                    this.snake.direction = "left";
                    break;
                case 38:
                    this.snake.direction = "top";
                    break;
                case 39:
                    this.snake.direction = "right";
                    break;
                case 40:
                    this.snake.direction = "bottom";
                    break;
            }
        }.bind(that))
    }

    //外部可以访问
    window.Game=Game;
})(window,undefined);

//Main
(function(window,undefined){
    var map = document.getElementById("map");
    var button = document.getElementById("control").children;
    var minute = document.getElementById("minute");
    var game = new Game(map,minute);
    game.render(button);
})(window,undefined);