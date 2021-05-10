

// Toggle Game button when Data is filled in and create Kamp in DB
var isAllReady = false;
var MTName = document.getElementById("myTeamName");
var MTYear = document.getElementById("team1_yearBtn");
var MTLeague = document.getElementById("team1_leagueBtn");
var ATName = document.getElementById("AwayTeamName");
var ATYear = document.getElementById("team2_yearBtn");
var ATLeague = document.getElementById("team2_leagueBtn");
var btn1, btn2;
btn1 = document.getElementById("startBtn");
btn2 = document.getElementById("stopBtn");
btn1.disabled = true;
btn2.disabled = true;

MTName.addEventListener("change", checkGameIsReady);
MTYear.addEventListener("change", checkGameIsReady);
MTLeague.addEventListener("change", checkGameIsReady);
ATName.addEventListener("change", checkGameIsReady);
ATYear.addEventListener("change", checkGameIsReady);
ATLeague.addEventListener("change", checkGameIsReady);

function checkGameIsReady() {
    if (MTName.value !== "" ||
        MTName.value != null &&
        MTYear.value !== "Vælg Årgang" &&
        MTLeague.value !== "Vælg Række" &&
        ATName.value !== "" ||
        ATName.value != null &&
        ATYear.value !== "Vælg Årgang" &&
        ATLeague.value !== "Vælg Række") {
        btn1.disabled = false;
        btn2.disabled = false;
        isAllReady = true;
    }
}

// Incrementations

function incrementMyTeamGoal(player) {
    var myTeamPlayerGoals = parseInt(document.getElementById("goals_" + player).value, 10);
    var myTeamScore = parseInt(document.getElementById("myTeamScore").value, 10);
    var amountOfShots = parseInt(document.getElementById("amountOfShots_" + player).value, 10);
    myTeamScore = isNaN(myTeamScore) ? 0 : myTeamScore;
    myTeamScore++;
    myTeamPlayerGoals = isNaN(myTeamPlayerGoals) ? 0 : myTeamPlayerGoals;
    myTeamPlayerGoals++;
    amountOfShots = isNaN(amountOfShots) ? 0 : amountOfShots;
    amountOfShots++;

    document.getElementById("goals_" + player).value = myTeamPlayerGoals;
    document.getElementById("myTeamScore").value = myTeamScore;
    document.getElementById("amountOfShots_" + player).value = amountOfShots;
}

function decrementMyTeamGoal(player) {
    var myTeamPlayerGoals = parseInt(document.getElementById("goals_" + player).value, 10);
    var myTeamScore = parseInt(document.getElementById("myTeamScore").value, 10);
    var amountOfShots = parseInt(document.getElementById("amountOfShots_" + player).value, 10);
    myTeamScore = isNaN(myTeamScore) ? 0 : myTeamScore;
    amountOfShots = isNaN(amountOfShots) ? 0 : amountOfShots;
    myTeamPlayerGoals = isNaN(myTeamPlayerGoals) ? 0 : myTeamPlayerGoals;

    if (myTeamPlayerGoals > 0) {
        myTeamPlayerGoals--;
        document.getElementById("goals_" + player).value = myTeamPlayerGoals;
    } else {
        document.getElementById("goals_" + player).value = 0;
    }

    if (myTeamScore > 0) {
        myTeamScore--;
        document.getElementById("myTeamScore").value = myTeamScore;
    } else {
        document.getElementById("myTeamScore").value = 0;
    }

    if (amountOfShots > 0) {
        amountOfShots--;
        document.getElementById("amountOfShots_" + player).value = amountOfShots;
    } else {
        document.getElementById("amountOfShots_" + player).value = 0;
    }

}

function incrementMyTeamAttempts(player) {
    var amountOfShots = parseInt(document.getElementById("amountOfShots_" + player).value, 10);
    amountOfShots = isNaN(amountOfShots) ? 0 : amountOfShots;
    amountOfShots++;

    document.getElementById("amountOfShots_" + player).value = amountOfShots;
}

function decrementMyTeamAttempts(player) {
    var amountOfShots = parseInt(document.getElementById("amountOfShots_" + player).value, 10);
    amountOfShots = isNaN(amountOfShots) ? 0 : amountOfShots;

    if (amountOfShots > 0) {
        amountOfShots--;
        document.getElementById("amountOfShots_" + player).value = amountOfShots;
    } else {
        document.getElementById("amountOfShots_" + player).value = 0;
    }
}

function incrementMyTeamAssists(player) {
    var amountOfAssists = parseInt(document.getElementById("assists_" + player).value, 10);
    amountOfAssists = isNaN(amountOfAssists) ? 0 : amountOfAssists;
    amountOfAssists++;

    document.getElementById("assists_" + player).value = amountOfAssists;
}

function decrementMyTeamAssists(player) {
    var amountOfAssists = parseInt(document.getElementById("assists_" + player).value, 10);
    amountOfAssists = isNaN(amountOfAssists) ? 0 : amountOfAssists;

    if (amountOfAssists > 0) {
        amountOfAssists--;
        document.getElementById("assists_" + player).value = amountOfAssists;
    } else {
        document.getElementById("assists_" + player).value = 0;
    }
}

function incrementMyTeamSaves(player) {
    var amountOfSaves = parseInt(document.getElementById("saves_" + player).value, 10);
    amountOfSaves = isNaN(amountOfSaves) ? 0 : amountOfSaves;
    amountOfSaves++;

    document.getElementById("saves_" + player).value = amountOfSaves;
}

function decrementMyTeamSaves(player) {
    var amountOfSaves = parseInt(document.getElementById("saves_" + player).value, 10);
    amountOfSaves = isNaN(amountOfSaves) ? 0 : amountOfSaves;

    if (amountOfSaves > 0) {
        amountOfSaves--;
        document.getElementById("saves_" + player).value = amountOfSaves;
    } else {
        document.getElementById("saves_" + player).value = 0;
    }
}

function incrementPlayerTable() {
    var table = document.getElementById("playertable");
    var rowCount = table.rows.length;

    if (rowCount < 17) {

    }
}

function incrementAwayTeam() {
    var awayTeamScore = parseInt(document.getElementById("AwayTeamScore").value, 10);
    awayTeamScore = isNaN(awayTeamScore) ? 0 : awayTeamScore;
    awayTeamScore++;
    document.getElementById("AwayTeamScore").value = awayTeamScore;
}

function decrementAwayTeam() {
    var awayTeamScore = parseInt(document.getElementById("AwayTeamScore").value, 10);
    awayTeamScore = isNaN(awayTeamScore) ? 0 : awayTeamScore;
    if (awayTeamScore > 0) {
        awayTeamScore--;
        document.getElementById("AwayTeamScore").value = awayTeamScore;
    } else {
        document.getElementById("AwayTeamScore").value = 0;
    }
}