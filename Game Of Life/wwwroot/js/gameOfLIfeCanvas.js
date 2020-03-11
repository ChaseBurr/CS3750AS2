"use strict";

// Create connection
var connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

// Start connection
connection.start().then(function () {
    console.log("connected");
});

// Variables
let canvas, ctx, tileSize;
let tiles = [];
let bw, bh;
bw = bh = 800;

window.addEventListener('load', function () {
    canvas = document.getElementById('board');
    canvas.width = canvas.height = 800;
    canvas.addEventListener('mousedown', onDown, false);

    ctx = canvas.getContext('2d');

    tileSize = canvas.width / 16;
    /*tiles.push(new tile(10, 10, 255, 0, 0));
    tiles.push(new tile(5, 10, 255, 0, 0));
    tiles.push(new tile(5, 5, 0, 255, 255));*/
    // tiles.push(new tile(5, 10, 300));
    drawGrid();
});

connection.on("AddTile", (x, y, r, g, b) => {
    tiles.push(new tile(x, y, r, g, b));
    console(tiles);
});

function drawGrid() {
    // Draw Vertical lines
    for (let x = 0; x <= bw; x += 40) {
        ctx.moveTo(x, 0);
        ctx.lineTo(x, bh);
    }

    // Draw Horizontal lines
    for (let x = 0; x <= bh; x += 40) {
        ctx.moveTo(0, x);
        ctx.lineTo(bw, x);
    }

    // Set color and display lines
    ctx.strokeStyle = "black";
    ctx.stroke();

    // Draws tiles
}

// Grabs X and Y cords
function onDown(event) {
    let cx = event.pageX;// - ((window.innerWidth - canvas.width) / 2);
    let cy = event.pageY;

    // Sends updated tile server side
    connection.invoke("SendNewTiles", 500, 500, 0, 255, 255);
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
