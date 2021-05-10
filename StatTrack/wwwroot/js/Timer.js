document.getElementById("GameFinished").style.visibility = "hidden";
document.getElementById("GameHalvleg").style.visibility = "hidden";
var timer = document.getElementById("timer");
var startBtn = document.getElementById("startBtn");
var halfTimeBtn = document.getElementById("halfTimeBtn");
var stopBtn = document.getElementById("stopBtn");
var gameLength;
var boolFlag = false;

function setGameTime(val) {
    //var temp = val.options[val.selectedIndex].getAttribute('value');
    var temp = val.options[val.selectedIndex].text;
    console.log(temp);
    gameLength = temp;
}

function getHalfTime() {
    var result;
    switch (gameLength) {
    case "20:00":
        result = "10:00";
        break;
    case "30:00":
        result = "15:00";
        break;
    case "50:00":
        result = "25:00";
            break;
    case "00:10":
        result = "00:05";
        break;
    default:
        result = "30:00";
        break;
    }
    return result;
}

var stopWatch = new Timer(timer);

startBtn.addEventListener('click', function () {
    if (!stopWatch.isOn) {
        stopWatch.start();
        document.getElementById("SetGameTimeSelectionBar").style.visibility = 'hidden';
        saveGameToDB();
    }
});

halfTimeBtn.addEventListener('click', function () {
    if (!stopWatch.isOn) {
        stopWatch.start();
        document.getElementById("primaryTimerBtnsRow").style.visibility = 'visible';
        document.getElementById("halfTimeRow").style.visibility = 'hidden';
        document.getElementById("GameHalvleg").style.visibility = "hidden";
    }

});

stopBtn.addEventListener('click', function () {
    stopWatch.stop();
    document.getElementById("SetGameTimeSelectionBar").style.visibility = 'visible';
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
            interval = setInterval(update, 500);
            setInterval(checkIfHalftime, 500);
            setInterval(checkIfFulltime, 500);
            offset = Date.now();
            this.isOn = true;
            console.log("Timer Started");
            console.log("isOn status: " + this.isOn);
        }
    };

    this.stop = function () {
        if (this.isOn) {
            clearInterval(interval);
            interval = null;
            this.isOn = false;
            console.log("Timer Stopped");
            console.log("isOn status: " + this.isOn);
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

function checkIfHalftime() {
    if (timer.textContent === getHalfTime() && stopWatch.isOn && !boolFlag) {
        console.log("Halftime");
        document.getElementById("primaryTimerBtnsRow").style.visibility = 'hidden';
        document.getElementById("halfTimeRow").style.visibility = 'visible';
        boolFlag = true;
        stopWatch.stop();
        gameHalfTime();
    }
};

var x = 0;
function checkIfFulltime() {
    var time = document.getElementById("timer").textContent;
    if (time === gameLength && x === 0) {
        document.getElementById("primaryTimerBtnsRow").style.visibility = 'hidden';
        document.getElementById("halfTimeRow").style.visibility = 'hidden';
        stopWatch.stop();
        gameEnded();
        x++;
    }
};

function gameHalfTime() {
    var titel = document.getElementById("GameHalvlegTitel");
    var result = document.getElementById("GameHalvlegResult");
    var scoreTeam1 = document.getElementById("myTeamScore").value;
    var scoreTeam2 = document.getElementById("AwayTeamScore").value;

    result.textContent = scoreTeam1 + "\t:\t" + scoreTeam2;
    titel.textContent = "Halvleg";

    document.getElementById("GameHalvleg").style.visibility = "visible";
    saveGameToDB();
}

var i = 0;
function gameEnded() {
    if (i === 0) {
        var paragraphTitel = document.getElementById("GameFinishedResultTitel");
        var paragraph = document.getElementById("GameFinishedResult");
        var team1 = document.getElementById("myTeamName").value;
        var scoreTeam1 = parseInt(document.getElementById("myTeamScore").value, 10);
        var team2 = document.getElementById("AwayTeamName").value;
        var scoreTeam2 = parseInt(document.getElementById("AwayTeamScore").value, 10);

        paragraphTitel.textContent = "Kamp Resultat:";
        if (scoreTeam1 > scoreTeam2) {
            paragraph.textContent = team1 + " vinder " + scoreTeam1 + ":" + scoreTeam2 + " over " + team2;
        } else if (scoreTeam2 > scoreTeam1) {
            paragraph.textContent = team2 + " vinder " + scoreTeam2 + ":" + scoreTeam1 + " over " + team1;
        } else {
            paragraph.textContent = team1 + " spiller uafgjort mod " + team2 + "\n" + scoreTeam1 + ":" + scoreTeam2;
        }

        document.getElementById("GameFinished").style.visibility = "visible";
        saveGameToDB();
        i++;
    }
}
