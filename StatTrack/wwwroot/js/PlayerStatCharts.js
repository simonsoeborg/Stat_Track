
var ctx1 = document.getElementById("StatChart1").getContext("2d");
var goals = document.getElementById("amountOfGoalsCurrent").innerHTML;
var assists = document.getElementById("amountOfAssistsCurrent").innerHTML;
var games = document.getElementById("amountOfPlayedGamesCurrent").innerHTML;
var attempts = document.getElementById("amountOfGoalAttemptsCurrent").innerHTML;

var ctx1OverAll = document.getElementById("StatChartOverall").getContext("2d");
var goalsOverall = document.getElementById("amountOfGoalsOverAll").innerHTML;
var assistsOverall = document.getElementById("amountOfAssistsOverAll").innerHTML;
var gamesOverall = document.getElementById("amountOfPlayedGamesOverAll").innerHTML;
var attemptsOverall = document.getElementById("amountOfGoalAttemptsOverAll").innerHTML;

if (document.getElementById("playerPosition").innerHTML === "Målvogter") {
    var saves = document.getElementById("amountOfSavesCurrent").innerHTML;
    var ctx2 = document.getElementById("StatChartKeeper").getContext("2d");
    var savesOverAll = document.getElementById("amountOfSavesOverAll").innerHTML;
    var ctx2OverAll = document.getElementById("StatChartKeeperOverall").getContext("2d");
}

var StatChart1 = new Chart(ctx1,
    {
        type: "line",
        data: {
            labels: ["Kampe", "Assists", "Mål", "Skudforsøg"],
            datasets: [
                {
                    label: "Performance af spiller",
                    data: [games, assists, goals, attempts],
                    backgroundColor: [
                        "rgba(255, 99, 132, 0.2)",
                        "rgba(54, 162, 235, 0.2)",
                        "rgba(255, 206, 86, 0.2)",
                        "rgba(255, 159, 64, 0.2)"
                    ],
                    borderColor: [
                        "rgba(255, 99, 132, 1)",
                        "rgba(54, 162, 235, 1)",
                        "rgba(255, 206, 86, 1)",
                        "rgba(255, 159, 64, 1)"
                    ],
                    borderWidth: 1
                }
            ]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

var StatChartKeeper = new Chart(ctx2,
    {
        type: "line",
        data: {
            labels: ["Kampe", "Redninger", "Assists", "Mål", "Skudforsøg"],
            datasets: [
                {
                    label: "Performance af Målvogter",
                    data: [games, saves, assists, goals, attempts],
                    backgroundColor: [
                        "rgba(255, 99, 132, 0.2)",
                        "rgba(54, 162, 235, 0.2)",
                        "rgba(255, 206, 86, 0.2)",
                        "rgba(153, 102, 255, 1)",
                        "rgba(255, 159, 64, 0.2)"
                    ],
                    borderColor: [
                        "rgba(255, 99, 132, 1)",
                        "rgba(54, 162, 235, 1)",
                        "rgba(255, 206, 86, 1)",
                        "rgba(153, 102, 255, 1)",
                        "rgba(255, 159, 64, 1)"
                    ],
                    borderWidth: 1
                }
            ]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

var StatChartOverall = new Chart(ctx1OverAll,
    {
        type: "line",
        data: {
            labels: ["Kampe", "Assists", "Mål", "Skudforsøg"],
            datasets: [
                {
                    label: "Performance af spiller",
                    data: [gamesOverall, assistsOverall, goalsOverall, attemptsOverall],
                    backgroundColor: [
                        "rgba(255, 99, 132, 0.2)",
                        "rgba(54, 162, 235, 0.2)",
                        "rgba(255, 206, 86, 0.2)",
                        "rgba(255, 159, 64, 0.2)"
                    ],
                    borderColor: [
                        "rgba(255, 99, 132, 1)",
                        "rgba(54, 162, 235, 1)",
                        "rgba(255, 206, 86, 1)",
                        "rgba(255, 159, 64, 1)"
                    ],
                    borderWidth: 1
                }
            ]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });

var StatChartKeeperOverall = new Chart(ctx2OverAll,
    {
        type: "line",
        data: {
            labels: ["Kampe", "Redninger", "Assists", "Mål", "Skudforsøg"],
            datasets: [
                {
                    label: "Performance af Målvogter",
                    data: [gamesOverall, savesOverall, assistsOverall, goalsOverall, attemptsOverall],
                    backgroundColor: [
                        "rgba(255, 99, 132, 0.2)",
                        "rgba(54, 162, 235, 0.2)",
                        "rgba(255, 206, 86, 0.2)",
                        "rgba(153, 102, 255, 1)",
                        "rgba(255, 159, 64, 0.2)"
                    ],
                    borderColor: [
                        "rgba(255, 99, 132, 1)",
                        "rgba(54, 162, 235, 1)",
                        "rgba(255, 206, 86, 1)",
                        "rgba(153, 102, 255, 1)",
                        "rgba(255, 159, 64, 1)"
                    ],
                    borderWidth: 1
                }
            ]
        },
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });