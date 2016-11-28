var express = require('express');
var mysql = require('mysql');
var bodyParser = require('body-parser');
var Sequelize = require("sequelize");
var sequelize = new Sequelize('nanugong', 'root', '1234', {
    host: 'localhost',
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
                    )
            }
        })
});


app.delete("/user", function(req, res){
    User.destroy({
        where: {
            name: req.body.name
        }
    })
        .then(function(result){
            console.log(result);
            res.json(result);
        })
});

app.put("/user", function(req, res){
    var b = req.body;
    var updateObj = {
        pin : b.pin
    };
    var whereObj = {
        where : {
            name : b.name,
            phone : b.phone,
            email : b.email
        }
    };

    User.update(updateObj, whereObj)
        .then(function(result){
            if (result == 1) {
                res.json(new successMsg(200, "Sucess"));
            }else{
                res.json(new successMsg(404, "Failure"));
            }
        })
        .catch(function(err){
            console.log(err);
        })
});