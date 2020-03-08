//grid width and height
let bw = bh = 800;
let canvas, ctx;


window.onload = function () {
    canvas = document.getElementById('board');
    canvas.width = canvas.height = 801;

    ctx = canvas.getContext('2d');
    ctx.strokeStyle = 'black';

    canvas.addEventListener('mousedown', onDown, false);


    drawBoard();


}

// Grabs X and Y cords
function onDown(event) {
    let cx = event.pageX;
    let cy = event.pageY;

    alert("X =" + cx + ' Y: ' + cy);
}


function drawBoard() {
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
}


