

function incrementMyTeamGoal(player) {
    var myTeamScore = parseInt(document.getElementById("myTeamScore").value, 10);
    var amountOfShots = parseInt(document.getElementById("amountOfShots_" + player).value, 10);
    myTeamScore = isNaN(myTeamScore) ? 0 : myTeamScore;
    myTeamScore++;
    amountOfShots = isNaN(amountOfShots) ? 0 : amountOfShots;
    amountOfShots++;

    document.getElementById("myTeamScore").value = myTeamScore;
    document.getElementById("amountOfShots_" + player).value = amountOfShots;
}

function incrementPlayerTable() {
    var table = document.getElementById("playertable");
    var rowCount = table.rows.length;

    if (rowCount < 17) {

    }
}