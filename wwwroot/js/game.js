// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

var timeDisplay = document.getElementById('#timer');
var startBtn = document.getElementById('#startBtn');
var stopBtn = document.getElementById('#stopBtn');
var stime = 0;
var mtime = 0;
var timeIsStopped = true;

function initGame() {
    var currentTime = document.getElementById('#timer');
    stime = 0;
    mtime = 0;
    timeIsStopped = true;
}

function startTimer() {
    initGame();
    if (timeIsStopped) {
        timeIsStopped = false;
    }

    while (!timeIsStopped) {
        setInterval(function () {

                if (stime >= 59) {
                    mtime += 1;
                    stime = 0;
                }
                timeDisplay.innerHTML = mtime + ":" + stime;
                stime += 1;
            },
            1000);
    }
}

function stopTimer() {
    timeIsStopped = true;
}
