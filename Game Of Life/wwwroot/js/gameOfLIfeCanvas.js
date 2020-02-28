let canvas, ctx, tileSize;
let tiles = [];

window.addEventListener('load', function () {
    canvas = document.getElementById('board');
    canvas.width = canvas.height = 800;
    ctx = canvas.getContext('2d');
    tileSize = canvas.width / 16;
    tiles.push(new tile(10, 10, 255, 0, 0));
    tiles.push(new tile(5, 10, 255, 0, 0));
    tiles.push(new tile(5, 5, 0, 255, 255));
    // tiles.push(new tile(5, 10, 300));
    drawGrid();
});

function drawGrid() {
    ctx.clearRect(0, 0, canvas.width, canvas.height);
    for (let i = 0; i < tiles.length; i++) tiles[i].draw(ctx);
}

class tile {
    constructor(x, y, red, green, blue) {
        var _this = this;
        (function () {
            _this.x = x || null;
            _this.y = y || null;
            _this.red = red || 0;
            _this.green = green || 0;
            _this.blue = blue || 0;
        })();

        console.log(this);

        this.draw = function (ctx) {
            if (!_this.x || !_this.y) {
                console.log('error');
                return;
            }
            ctx.beginPath();
            ctx.rect(_this.x * tileSize, _this.y * tileSize, tileSize, tileSize);
            ctx.fillStyle = "rgb(" + _this.red + ', ' + _this.green + ', ' + _this.blue + ")";
            ctx.fill();
        };
    }
}
