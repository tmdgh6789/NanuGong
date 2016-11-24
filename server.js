var io = require("socket.io").listen(999);

io.socket.on("connection", function (socket) {
    console.log("connected!");

    socket.on("Msg", function (data) {
        console.log(data);
        socket.emit("MsgRes", data);
    });
});