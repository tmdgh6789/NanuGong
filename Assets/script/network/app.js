var express = require('express');
var mysql = require('mysql');
var bodyParser = require('body-parser');
var Sequelize = require("sequelize");
var sequelize = new Sequelize('nanugong', 'n_admin', '1234', {
    host: '192.168.0.5',
    dialect: 'mysql',
    pool: {
        max: 5,
        min: 0,
        idle: 5
    }
});

var app = express();
app.locals.pretty = true;
app.set('port', (process.env.PORT || 5000));
app.use(express.static(__dirname + '/public'));
app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

var User = sequelize.define('user', {
    num : {
        type: Sequelize.INTEGER,
        primaryKey: true,
        autoIncrement: true
    },
    id : {
        type: Sequelize.STRING,
        unique: true,
        max: 10
    },
    password:{
        type: Sequelize.STRING,
        max: 10
    },
    nickname:{
        type: Sequelize.STRING,
        max: 10
    },
    bestScore:{
        type: Sequelize.INTEGER
    },
    coin:{
        type: Sequelize.INTEGER
    },
    myChar:{
        type: Sequelize.INTEGER
    }
}, {
    freezeTableName: true, // Model tableName will be the same as the model name
    timestamps: false
});

var Inventory = sequelize.define('inventory', {
    id : {
        type: Sequelize.STRING,
        primaryKey: true,
        max: 10
    },
    char1:{
        type: Sequelize.INTEGER
    },
    char2:{
        type: Sequelize.INTEGER
    },
    char3:{
        type: Sequelize.INTEGER
    },
    char4:{
        type: Sequelize.INTEGER
    }
}, {
    freezeTableName: true, // Model tableName will be the same as the model name
    timestamps: false
});

function successMsg(code, msg){
    this.code = code;
    this.msg = msg;
}

app.listen(app.get('port'), function() {
    console.log('Node app is running on port', app.get('port'));
});

app.get('/', function(req, res) {
    sequelize
        .authenticate()
        .then(function(err) {
            console.log('Connection has been established successfully.');
            res.json({
                name : "test"
            });
        })
        .catch(function (err) {
            console.log('Unable to connect to the database:', err);
            res.json({
                name : "test"
            });
        });
});


app.get('/user/:id', function(req, res) {
    var id = req.params.id;
    User.findAll({
        where: {
            id: id
        }
    })
        .then(function(results){
            res.json(results);
        })
});

app.get('/inventory/:id', function(req, res) {
    var id = req.params.id;
    Inventory.findAll({
        where: {
            id: id
        }
    })
        .then(function(results){
            res.json(results);
        })
});

app.get('/join/:id/:password/:nickname', function(req, res) {
    var id = req.params.id;
    var password = req.params.password;
    var nickname = req.params.nickname;
    User.findAll({
        where: {
            id: id
        }
    })
        .then(function(results){
            if (results.length == 0) {
                User.create({
                    id: id,
                    password: password,
                    nickname: nickname
                })
                    .then (function (results2) {
                        res.json(results2);
                        }
                    );
                Inventory.create({
                    id: id,
                    char1: 0,
                    char2: 0,
                    char3: 0,
                    char4: 0
                })
                    .then (function (results3) {
                        res.json(results3);
                        }
                    );
            }
        })
});

app.get("/finish/:id/:coin/:score", function(req, res){
    var id = req.params.id;
    var coin = req.params.coin;
    var score = req.params.score;

    User.update({
        coin: coin,
        bestScore: score
    }, {
        where: {
            id : id
        }
    }).then(function (result) {
        res.json(result);
    }).catch(function (err) {
        console.log("finish 에서 에러 : " + err);
    });
});

app.get("/coin/:id/:coin", function(req, res){
    var id = req.params.id;
    var coin = req.params.coin;

    User.update({
        coin: coin
    }, {
        where: {
            id : id
        }
    }).then(function (result) {
        res.json(result);
    }).catch(function (err) {
        console.log("coin 에서 에러 : " + err);
    });
});

app.get("/myRoom/:id/:coin/:myChar", function(req, res){
    var id = req.params.id;
    var coin = req.params.coin;
    var myChar = req.params.myChar;

    User.update({
        coin: coin,
        myChar: myChar
    }, {
        where: {
            id : id
        }
    }).then(function (result) {
        res.json(result);
    }).catch(function (err) {
        console.log("myRoom 에서 에러 : " + err);
    });
});

app.get("/myChar/:id/:myChar", function(req, res){
    var id = req.params.id;
    var myChar = req.params.myChar;

    User.update({
        myChar: myChar
    }, {
        where: {
            id : id
        }
    }).then(function (result) {
        res.json(result);
    }).catch(function (err) {
        console.log("myChar 에서 에러 : " + err);
    });
});

app.get("/buyChar/:id/:CharNum", function(req, res){
    var id = req.params.id;
    var CharNum = req.params.CharNum;

    if (CharNum == 1) {
        Inventory.update({
            char1: 1
        }, {
            where: {
                id : id
            }
        }).then(function (result) {
            res.json(result);
        }).catch(function (err) {
            console.log("buyChar 에서 에러 : " + err);
        });
    } else if (CharNum == 2) {
        Inventory.update({
            char2: 1
        }, {
            where: {
                id : id
            }
        }).then(function (result) {
            res.json(result);
        }).catch(function (err) {
            console.log("buyChar 에서 에러 : " + err);
        });
    } else if (CharNum == 3) {
        Inventory.update({
            char3: 1
        }, {
            where: {
                id : id
            }
        }).then(function (result) {
            res.json(result);
        }).catch(function (err) {
            console.log("buyChar 에서 에러 : " + err);
        });
    } else if (CharNum == 4) {
        Inventory.update({
            char4: 1
        }, {
            where: {
                id : id
            }
        }).then(function (result) {
            res.json(result);
        }).catch(function (err) {
            console.log("buyChar 에서 에러 : " + err);
        });
    }

});

app.get("/resetRecord/:id", function(req, res){
    var id = req.params.id;

    User.update({
        bestScore: 0
    }, {
        where: {
            id : id
        }
    }).then(function (result) {
        res.json(result);
    }).catch(function (err) {
        console.log("resetRecord 에서 에러 : " + err);
    });
});

app.get("/resetCoin/:id", function(req, res){
    var id = req.params.id;

    User.update({
        coin: 0
    }, {
        where: {
            id : id
        }
    }).then(function (result) {
        res.json(result);
    }).catch(function (err) {
        console.log("resetCoin 에서 에러 : " + err);
    });
});

app.get("/resetChar/:id", function(req, res){
    var id = req.params.id;

    User.update({
        myChar: 0
    }, {
        where: {
            id : id
        }
    }).then(function (result) {
        res.json(result);
    }).catch(function (err) {
        console.log("resetChar 에서 에러 : " + err);
    });

    Inventory.update({
        char1: 0,
        char2: 0,
        char3: 0,
        char4: 0
    }, {
        where: {
            id : id
        }
    }).then(function (result) {
        res.json(result);
    }).catch(function (err) {
        console.log("resetChar 에서 에러 : " + err);
    });
});