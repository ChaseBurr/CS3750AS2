"use strict";

// Create connection
var connection = new signalR.HubConnectionBuilder().withUrl("/gameHub").build();

// Start connection
connection.start().then(function () {
    console.log("connected");
});

// Variables
let canvas, ctx, cellSize;
let cellDensity = 16;
let canvasSize = 800;
let cells = [];

window.addEventListener('load', function () {
    canvas = document.getElementById('board');
    canvas.width = canvas.height = canvasSize;
    canvas.addEventListener('mousedown', function (e) {
        canvasClick(canvas, e);
    });

    ctx = canvas.getContext('2d');

    cellSize = canvas.width / cellDensity;
    drawGrid();
});

/* Client Display Start */
function drawGrid() {
    // Draw Vertical lines
    for (let x = 0; x <= canvasSize; x += cellSize) {
        ctx.moveTo(x, 0);
        ctx.lineTo(x, canvasSize);
    }

    // Draw Horizontal lines
    for (let x = 0; x <= canvasSize; x += cellSize) {
        ctx.moveTo(0, x);
        ctx.lineTo(canvasSize, x);
    }

    // Set color and display lines
    ctx.strokeStyle = "black";
    ctx.stroke();

    // Draws tiles
    for (let i = 0; i < cells.length; i++) cells[i].draw(ctx);
}

class cell {
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
            let cellBorder = 4;
            ctx.beginPath();
            ctx.rect((_this.x * cellSize) + cellBorder, (_this.y * cellSize) + cellBorder, cellSize - (cellBorder * 2), cellSize - (cellBorder * 2));
            ctx.fillStyle = "rgb(" + _this.red + ', ' + _this.green + ', ' + _this.blue + ")";
            ctx.fill();
        };
    }
}
/* Client Display End */


/* Server Interactions Start */
connection.on("UpdateCells", (test) => {
    // empty and fill cell array
    cells = [];
    test.forEach(element => cells.push(new cell(element.x, element.y, element.red, element.green, element.blue)));
    drawGrid();
});

function canvasClick(canvas, event) {
    // get click position within canvas element
    console.log(event.target);
    let rect = canvas.getBoundingClientRect();
    let x = Math.floor((event.clientX - rect.left) / cellSize);
    let y = Math.floor((event.clientY - rect.top) / cellSize);

    /*console.log(x + " - " + y);*/

    // Sends updated tile server side
    connection.invoke("SendNewTiles", x, y);
}
/* Server Interections End */