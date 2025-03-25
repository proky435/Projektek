//!Module-ok importálása
const express = require('express'); //?npm install express
const multer = require("multer");
const upload = multer({ dest: 'uploads/' });
const path = require('path');
const bodyParser = require('body-parser');
const fs = require('fs');
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
  database: "suli"
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

//!URL-ek kezelése
//?Főoldal:
router.get('/', (request, response) => {
  response.sendFile(path.join(__dirname + '/public/html/index.html'));
});

app.listen(port, ip, () => {
  console.log('Szerver figyelése a következő porton: ' + port + ' a következő ip címen: ' + ip);
});

//Végpont
router.post('/fsend', upload.single('file'), async (req, res) => {
  console.log(req.file);
  await fs.promises.rename(req.file.path, "public/download/" + req.file.originalname, function (err) {
    if (err) throw err;
    console.log('File Renamed!');
  });
  let csvData = await fs.promises.readFile("public/download/" + req.file.originalname, 'utf8', (err, data) => {
    if (err) {
      console.error(err);
    } else {
      console.log(data);
    }
  });
  let csvLines = csvData.split('\n');
  let csv = [];
  for (let i = 0; i < csvLines.length; i++) {
    csv.push(removeControlCharacters(csvLines[i]).split(';'));
  }
  res.send(JSON.stringify(csv));
});

function removeControlCharacters(text) {
  return text.replace(/\p{Cc}/gu, '');
}

router.post('/download', function (req, res) {
  pool.query('SELECT * FROM asd', function (error, results, fields) {
    if (error) {
      console.error(error);
      res.status(500).send('Adatbázis hiba.');
      return;
    }
    let data = results;
    let writeStream = fs.createWriteStream("public/download/download.csv");
    for (let i = 0; i < data.length; i++) {
      let row = data[i];
      writeStream.write(`${row.id};${row.name};${row.age};${row.email}\r\n`);
    }
    writeStream.end(() => {
      res.download("public/download/download.csv");
    });
  });
});

