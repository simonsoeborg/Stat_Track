
function saveSession(playerId, event) {
    var playerName = document.getElementById("playerName_" + playerId).value;
    var playerPos = document.getElementById("playerPosition_" + playerId).value;
    var playerCurrentAttempts = parseInt(document.getElementById("amountOfShots_" + playerId).value, 10);
    var playerGoals = parseInt(document.getElementById("goals_" + playerId).value, 10);
    var playerAssists = parseInt(document.getElementById("assists_" + playerId).value, 10);
    var playerSaves = parseInt(document.getElementById("saves_" + playerId).value, 10);
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
        type: "POST",
        url: "/Game/PlayerStatToDB",
        dataType: "json",
        contentType: "application/json",
        data: dataObj,
        success: function(response) {
        },
        error: function() {
        }
    });
}

function createDataString(playerName, event, time) {
    var data = "";

    if (event === "goal") {
        data = time + " - " + playerName + getEvent(event);
    } else {
        data = time + " - " + getEvent(event) + playerName;
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
    var awayTeamName = document.getElementById("AwayTeamName").value;
    var teamGoals = parseInt(document.getElementById("myTeamScore").value, 10);
    var awayGoals = parseInt(document.getElementById("AwayTeamScore").value, 10);

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
    $.ajax({
        type: "POST",
        url: "/Game/RePostGameToDb",
        dataType: "json",
        contentType: "application/json",
        data: GameObj,
        success: function(response) {
        },
        error: function() {
        }
    });
}

var homeEventPlayerId = 0;
var homeEventPlayerName = "";
document.getElementById("newEventHomeTeamBtn").disabled = true;

function setHomeEventPlayer(val) {
    homeEventPlayerId = parseInt(val.options[val.selectedIndex].id, 10);
    homeEventPlayerName = val.options[val.selectedIndex].text;
    document.getElementById("newEventHomeTeamBtn").disabled = false;
}

function newGoalOrSaveEvent(event, playerId, Time) {

}

function newEventHomeTeam() {
    var playerId = homeEventPlayerId;
    var playerName = homeEventPlayerName;
    var Time = document.getElementById("timer").textContent;
    var eventName = "";
    var eventType = "";
    if (document.getElementById("Home2minEvent").checked) {
        eventName = "2min";
        eventType = "2 Minutters Udvisning";
    }

    if (document.getElementById("HomeYellowCardEvent").checked) {
        eventName = "yCard";
        eventType = "Gult Kort";
    }

    if (document.getElementById("HomeRedCardEvent").checked) {
        eventName = "rCard";
        eventType = "Rødt Kort";
    }

    // Add Event to DB
    addNewEventDataToDB(eventType, playerId, Time);
}


function addNewEventDataToDB(EventType, PlayerId, Time) {
    var dataObj = "";

    switch (EventType) {
    case "goal":
        var data = "Scoring";
        dataObj = JSON.stringify({
            EventType: data,
            PlayerId: PlayerId,
            Time: Time
        });
        break;
    case "save":
        var data = "Redning";
        dataObj = JSON.stringify({
            EventType: data,
            PlayerId: PlayerId,
            Time: Time
        });
        break;
    default:
        dataObj = JSON.stringify({
            EventType: EventType,
            PlayerId: PlayerId,
            Time: Time
        });
        break;
    }

    $.ajax({
        type: "POST",
        url: "/Game/EventToDb",
        dataType: "json",
        contentType: "application/json",
        data: dataObj,
        success: function(response) {
        },
        error: function() {
        }
    });
}

function deleteGameId() {
    $.ajax({
        type: "POST",
        url: "/Game/EmptyGameId",
        dataType: "json",
        contentType: "application/json",
        data: 0,
        success: function(response) {
        },
        error: function() {
        }
    });
}