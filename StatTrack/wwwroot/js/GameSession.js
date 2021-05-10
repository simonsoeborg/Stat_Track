
function saveSession(playerId, event) {
    var playerName = document.getElementById('playerName_' + playerId).value;
    var playerPos = document.getElementById('playerPosition_' + playerId).value;
    var playerCurrentAttempts = parseInt(document.getElementById('amountOfShots_' + playerId).value, 10);
    var playerGoals = parseInt(document.getElementById('goals_' + playerId).value, 10);
    var playerAssists = parseInt(document.getElementById('assists_' + playerId).value, 10);
    var playerSaves = parseInt(document.getElementById('saves_' + playerId).value, 10);
    var currentTeamScore = parseInt(document.getElementById("myTeamScore").value, 10);
    var currentAwayTeamScore = parseInt(document.getElementById("AwayTeamScore").value, 10);
    var currentTime = document.getElementById("timer").textContent;

    // Save to DB
    var dataObj = JSON.stringify({
        PlayerId: playerId,
        Tidspunkt: currentTime,
        Attempts: playerCurrentAttempts,
        Goals: playerGoals,
        KeeperSaves: playerSaves,
        Assists: playerAssists
    });

    $.ajax({
        type: 'POST',
        url: '/Game/PlayerStatToDB',
        dataType: 'json',
        contentType: 'application/json',
        data: dataObj,
        success: function (response) {
            console.log("Send to PlayerStatToDB(): ", response);
        },
        error: function () {
            console.log("Could not send Data to PostGameToDB()");
        }
    });

    // Save DataString to DB for Kamp Historik
}

function createDataString(playerName, event, time) {
    var data = "";

    if (event === "goal") {
        data = time + ": " + playerName + getEvent(event);
    } else {
        data = time + ": " + getEvent(event) + playerName;
    }

    return data;
}

function getEvent(event) {
    var eventValue = "";
    switch (event) {
        case "2min":
            eventValue = "2 Minutters Udvisning til: ";
            break;
        case "yCard":
            eventValue = "Gult kort til: ";
            break;
        case "rCard":
            eventValue = "Rødt kort til: ";
            break;
        case "goal":
            var currentScore = parseInt(document.getElementById("myTeamScore").value, 10);
            var currentAwayTeamScore = parseInt(document.getElementById("AwayTeamScore").value, 10);
            eventValue = " score til " + currentScore + ":" + currentAwayTeamScore;
            break;
        case "redning":
            eventValue = "Redning af ";
            break;
    }

    return eventValue;
}


function saveGameToDB() {
    var teamIdLabel = $("#myTeamId").text();
    var teamId = parseInt(teamIdLabel, 10);
    var awayTeamName = document.getElementById('AwayTeamName').value;
    var teamGoals = parseInt(document.getElementById('myTeamScore').value, 10);
    var awayGoals = parseInt(document.getElementById('AwayTeamScore').value, 10);

    if (teamGoals == null) {
        teamGoals = parseInt(0, 10);
    }

    if (awayGoals == null) {
        awayGoals = parseInt(0, 10);
    }

    var GameObj = JSON.stringify({
        CreatorTeamId: teamId,
        Modstander: awayTeamName,
        CreatorTeamGoals: teamGoals,
        ModstanderGoals: awayGoals
    });
    console.log(GameObj);
    $.ajax({
        type: 'POST',
        url: '/Game/RePostGameToDb',
        dataType: 'json',
        contentType: 'application/json',
        data: GameObj,
        success: function (response) {
        },
        error: function() {
            console.log("Could not send Data to PostGameToDB()");
        }
    });
}

var kId = 0;
function getKampId() {
    $.ajax({
        type: 'GET',
        url: '/Game/HTTPGetKampId',
        dataType: "json",
        success: function(response) {
            kId = response;
            console.log("Response: " + response);
        },
        error: function() {
            console.log("Could not fetch Kamp ID!");
        }
    });
}