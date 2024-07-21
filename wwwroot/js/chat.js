< !--chat.js -->
<script src="https://cdnjs.cloudflare.com/ajax/libs/microsoft-signalr/5.0.9/signalr.min.js"></script>
<script>
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/chathub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.start().then(function () {
        console.log("SignalR connected");
    }).catch(function (err) {
        return console.error(err.toString());
    });

    connection.on("ReceiveMessage", function (user, message) {
        // Handle received message
        console.log(`${user}: ${message}`);
    });

    // Example function to send message
    function sendMessage(user, message) {
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
    }
</script>
