"use strict";
const connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (user, message) {
    if (user === "server" && message === "refresh") {
        window.location.reload();
    }
});

connection
    .start()
    .then(function () {
        console.log("Connection with server established.")
    })
    .catch(function (err) {
        return console.error(err.toString());
    });