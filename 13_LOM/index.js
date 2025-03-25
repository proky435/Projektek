//!Module-ok importálása
const express = require('express'); //?npm install express
const { request } = require('http');
const multer = require("multer");
const upload = multer({ dest: 'uploads/' });
const path = require('path');
const bodyParser = require('body-parser');
const fs = require('fs');
const readline = require('readline');
const stream = require('stream');
const mysql = require('mysql');
const app = express();
const router = express.Router();
const session = require('express-session');
const pool = mysql.createPool({

  connectionLimit: 10,
  host: "127.0.0.1",
  user: "root",
  password: "",
  database: "lom"
});
//!Beállítások
const ip = '127.0.0.1';
const port = 3000;
router.use(session({
  secret: 'my-secret-key',
  resave: false,
  saveUninitialized: true,
  cookie: { secure: false }
}))
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.json());
//!Szerver futtatása
app.use(express.static('public')); //?CSS és JavaScript fájlok betöltése az oldal működéséhez
app.use('/', router);
//!Változók
var obj = [];
var beolvfajl = [];


//!URL-ek kezelése
//?Főoldal:
router.get('/', (request, response) => {
  if (request.session.logged) {
    response.sendFile(path.join(__dirname + '/public/html/index.html'));
  }
  else {
    response.sendFile(path.join(__dirname + '/public/html/login.html'));
  }
});

router.get('/regisztracio', (request, response) => {
  response.sendFile(path.join(__dirname + '/public/html/regisztracio.html'));
});
app.listen(port, ip, () => {
  console.log('Szerver figyelése a következő porton: ' + port + ' a következő ip címen: ' + ip);
});
router.post("/save", async (req,res) => {
  console.log(req.body);
  SqlSave([req.session.uid,req.session.nehezseg,req.body.kId],r=>{
    if(r.affectedRows==1){
      res.send("OK");
    }
    else
    {
      res.send("ERROR");
    }
  })
})
router.post("/logout", async (req,res) => {
  req.session.logged=false;
  res.send("OK");
})
router.post("/log", async (req, res) => {
  let adatok = [];
  req.session.uid=null;
  adatok.push(req.body.user);
  
  adatok.push(req.body.pw);
  SqlLogin(req.session,adatok, r => {
    switch (r[0].db) {
      case 0:
        req.session.logged=false;
        res.send("NO");
        break;
      case 1:
        req.session.logged=true;
        SqlUserId([req.body.user],r=>{
          console.log(r);
          req.session.uid=r[0].id;
          //console.log(req.session);
          res.send("OK");
        })
        
        break;

      default:
        req.session.logged=false;
        res.send("ERROR");
        break;
    }
  })
})
router.post("/reg", upload.single('file'), async (req, res) => {
  let adatok = [];
  console.log(req.body);
  adatok.push(req.body.user);
  adatok.push(req.body.pw);
  adatok.push(req.body.name);
  adatok.push(req.body.bday);
  adatok.push(req.body.email);
  pool.query("INSERT INTO felhasznalo(felhasznalonev,jelszo,nev,szuld,email) VALUES(?,?,?,?,?)", adatok, async function (err, result, fields) {
    if (err) throw err;
    console.log(result);
  });
  res.send("OK");
})
router.post('/jatek', async (req, res) => {
  console.log(req.session);
  if(req.session.logged){
    if (req.body.valasz == null) {
      if(req.session.nehezseg==undefined){
        req.session.nehezseg = 1;
      }
      SqlKerdes(req.session.nehezseg, (r) => {
        let vel = Math.floor(Math.random() * r.length);
        let resValasz = {};
        resValasz.allapot = 1;
        resValasz.kerdes = r[vel];
        SqlValasz(resValasz, (r) => {
          resValasz.valasz = r;
          res.send(resValasz);
        })
      })
    }
    else {
      SqlEllenorzes(req.body.valasz, (r) => {
        if (r[0].helyes) {
          if (req.session.nehezseg == 15) {
            let resValasz = {};
            resValasz.allapot = 2;
            res.send(resValasz);
          }
          else {
            req.session.nehezseg++;
            SqlKerdes(req.session.nehezseg, (r) => {
              let vel = Math.floor(Math.random() * r.length);
              let resValasz = {};
              resValasz.allapot = 1;
              resValasz.kerdes = r[vel];
              SqlValasz(resValasz, (r) => {
                resValasz.valasz = r;
                res.send(resValasz);
              })
            })
          }
  
        }
        else {
          let resValasz = {};
          resValasz.allapot = 0;
          res.send(resValasz);
        }
      })
    }
  }
  else{
    res.sendStatus(404);
  }
  
})

function SqlKerdes(adatok, callback) {
  //console.log(adatok);
  pool.query("SELECT id, kerdes FROM kerdesek WHERE nehezseg=?", [adatok], async function (err, result, fields) {
    if (err) throw err;
    //console.log(result);
    return callback(await result);
  });
}
function SqlValasz(adatok, callback) {

  pool.query("SELECT id, valasz FROM valaszok WHERE kid=?", [adatok.kerdes.id], async function (err, result, fields) {
    if (err) throw err;
    //console.log(result);
    return callback(await result);
  });
}
function SqlEllenorzes(adatok, callback) {

  pool.query("SELECT helyes FROM valaszok WHERE id=?", [adatok], async function (err, result, fields) {
    if (err) throw err;
    //console.log(result);
    return callback(await result);
  });
}
function SqlLogin(rSession, adatok, callback) {
  pool.query("SELECT COUNT(*) AS db FROM felhasznalo WHERE felhasznalonev=? AND jelszo=?", adatok, async function (err, result, fields) {
    if (err) throw err;
    //console.log(result);
    return callback(await result);
  });
}
function SqlUserId(adatok, callback) {
  pool.query("SELECT id FROM felhasznalo WHERE felhasznalonev=?" , adatok, async function (err, result, fields) {
    if (err) throw err;
    //console.log(result);
    return callback(await result);
  });
}
function SqlSave(adatok, callback){
  console.log(adatok);
  pool.query("INSERT INTO mentes(fId,kor,kId) VALUES(?,?,?)" , adatok, async function (err, result, fields) {
    if (err) throw err;
    //console.log(result);
    return callback(await result);
  });
}