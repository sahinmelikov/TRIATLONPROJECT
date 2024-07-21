// operator.js
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (user, message) {
    var msg = user + ": " + message;
    var div = document.createElement("div");
    div.textContent = msg;
    document.getElementById("messages").appendChild(div);
});

connection.start().catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("send-button").addEventListener("click", function (event) {
    var user = document.getElementById("user-list").value;
    var message = document.getElementById("message-input").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});

function updateUserList(users) {
    var userList = document.getElementById("user-list");
    userList.innerHTML = "";
    users.forEach(function (user) {
        var option = document.createElement("option");
        option.value = user;
        option.textContent = user;
        userList.appendChild(option);
    });
}

connection.on("UserListUpdated", function (users) {
    updateUserList(users);
});
