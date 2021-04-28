
var timer = document.getElementById("timer");
var startBtn = document.getElementById("startBtn");
var stopBtn = document.getElementById("stopBtn");
var gameLength = document.getElementById("gameLength");

function setGameTime(val) {
    var temp = val.options[val.selectedIndex].getAttribute('value');
    console.log(temp);
    gameLength = temp;
}

var stopWatch = new Timer(timer);

startBtn.addEventListener('click', function () {
    if (!stopWatch.isOn) {
        stopWatch.start();
    }
});

stopBtn.addEventListener('click', function () {
    stopWatch.stop();
});

stopBtn.addEventListener('dblclick', function () {
    stopWatch.reset();
});


function Timer(element) {
    var time = 0;
    var interval;
    var offset;
    var formattedTime;

    function update() {
        time += delta();
        formattedTime = timeFormatter(time);
/*        console.log(timeFormatter(10));
        if (formattedTime >= timeFormatter(gameLength) || formattedTime >= timeFormatter(gameLength/2) ) {
            stopWatch.stop();
        }*/
        element.textContent = formattedTime;
    }

    function delta() {
        var now = Date.now();
        var timePassed = now - offset;
        offset = now;
        return timePassed;
    }

    function timeFormatter(timeInMilliseconds) {
        var tempTime = new Date(timeInMilliseconds);
        var minutes = tempTime.getMinutes().toString();
        var seconds = tempTime.getSeconds().toString();

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

    this.stop = function () {
        if (this.isOn) {
            clearInterval(interval);
            interval = null;
            this.isOn = false;
        }
    };

    this.reset = function () {
        time = 0;
        var formattedTime = timeFormatter(time);
        element.textContent = formattedTime;
    };

    this.pause = function() {
        if (this.isOn) {
            clearInterval(interval);
            interval = null;
            this.isOn = false;
        }
    };
}