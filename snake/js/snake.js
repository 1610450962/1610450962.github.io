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
            {x : 3 , y : 2 , color : "red" , src : "url(img/head.png) center"},
            {x : 2 , y : 2 , color : "green"},
            {x : 1 , y : 2 , color : "green"},
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
            div.style.background = object.color;
            if(i==0)
            {
                div.style.background=object.src;
                div.style.backgroundSize="contain";
            }
            // div.style.border = "1px solid yellow";
            div.style.height = this.height + "px";
            div.style.width = this.width + "px";
            div.style.left = object.x * this.width + "px";
            div.style.top = object.y * this.height + "px";
            // div.style.backgroundColor = object.color;
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
})(window,undefined)