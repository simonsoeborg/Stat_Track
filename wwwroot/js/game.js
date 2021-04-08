/* Main functions */

var timer = document.getElementById("timer");
var startBtn = document.getElementById("startBtn");
var stopBtn = document.getElementById("stopBtn");

var stopWatch = new Timer(timer);

startBtn.addEventListener('click', function() {
    if (!stopWatch.isOn) {
        stopWatch.start();
    }
});

stopBtn.addEventListener('click', function () {
    stopWatch.stop();
});

stopBtn.addEventListener('dblclick', function() {
    stopWatch.reset();
});

/* Timer */

function Timer(element) {
    var time = 0;
    var interval;
    var offset;

    function update() {
        time += delta();
        var formattedTime = timeFormatter(time);
        element.textContent = formattedTime;
    }

    function delta() {
        var now = Date.now();
        var timePassed = now - offset;
        offset = now;
        return timePassed;
    }

    function timeFormatter(timeInMilliseconds) {
        var time = new Date(timeInMilliseconds);
        var minutes = time.getMinutes().toString();
        var seconds = time.getSeconds().toString();

        if (minutes.length < 2) {
            minutes = '0' + minutes;
        }

        if (seconds.length < 2) {
            seconds = '0' + seconds;
        }

        return minutes + ':' + seconds;
    }

    this.isOn = false;

    this.start = function () {
        if (!this.isOn) {
            interval = setInterval(update, 10);
            offset = Date.now();
            this.isOn = true;
        }
    };

    this.stop = function() {
        if (this.isOn) {
            clearInterval(interval);
            interval = null;
            this.isOn = false;
        }
    };

    this.reset = function() {
        time = 0;
        var formattedTime = timeFormatter(time);
        element.textContent = formattedTime;
    };
}
