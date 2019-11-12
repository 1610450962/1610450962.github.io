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
})(window,undefined)

// var map = document.getElementById("map");
// var game = new Game(map);
// game.render();
// for(var i=0;i<2000;i++)
// {
//     var div=document.createElement("div");
//     div.style.float="left";
//     div.style.boxSizing="border-box";
//     div.style.border="1px solid #000"
//     div.style.height="20px";
//     div.style.width="20px";
//     // div.style.backgroundColor="pink"
//     map.appendChild(div);
// }