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
//SQL kapcsolat megadása
const pool = mysql.createPool({
  connectionLimit: 10,
  host: "127.0.0.1",
  user: "root",
  password: "",
  database: "tanfolyam"
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



//!URL-ek kezelése
//?Főoldal:
router.get('/', (request, response) => {
  response.sendFile(path.join(__dirname + '/public/html/index.html'));
});

app.listen(port, ip, () => {
  console.log('Szerver figyelése a következő porton: ' + port + ' a következő ip címen: ' + ip);
});

//Végpontok


//-------------------------------------------------

// diak select
app.get('/students', (req, res) => {
  try {
    pool.query('SELECT * FROM diakok', (error, results) => {
      if (error) throw error;
      res.json(results);
    });
  } catch (error) {
    console.error("Hiba történt a diákok lekérése közben:", error);
    res.status(500).send("Szerver hiba");
  }
});

// diak add
app.post('/students', (req, res) => {
  const { name, email, age } = req.body;
  try {
    pool.query('INSERT INTO jelentkezes (nev, email, kor) VALUES (?, ?, ?)', [name, email, age], (error, results) => {
      if (error) throw error;
      res.send('Diák hozzáadva.');
    });
  } catch (error) {
    console.error("Hiba történt a diák hozzáadása közben:", error);
    res.status(500).send("Szerver hiba");
  }
});

// tanfolyam all
app.get('/courses', (req, res) => {
  try {
    pool.query('SELECT * FROM tanfolyamok', (error, results) => {
      if (error) throw error;
      res.json(results);
    });
  } catch (error) {
    console.error("Hiba történt a tanfolyamok lekérése közben:", error);
    res.status(500).send("Szerver hiba");
  }
});

// add tanfolyam
app.post('/courses', (req, res) => {
  const { name, description, instructor } = req.body;
  try {
    pool.query('INSERT INTO tanfolyamok (nev, leiras, oktato) VALUES (?, ?, ?)', [name, description, instructor], (error, results) => {
      if (error) throw error;
      res.send('Tanfolyam hozzáadva.');
    });
  } catch (error) {
    console.error("Hiba történt a tanfolyam hozzáadása közben:", error);
    res.status(500).send("Szerver hiba");
  }
});