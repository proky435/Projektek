//!Module-ok importálása
const express = require('express'); //?npm install express
const { request } = require('http');
const multer = require("multer");
const upload = multer({dest: 'uploads/'});
const path = require('path');
const bodyParser = require('body-parser');
const fs = require('fs');
const readline = require('readline');
const stream = require('stream');
const mysql = require('mysql');
const app = express();
const router = express.Router();
const pool = mysql.createPool({
  connectionLimit : 10,
  host: "127.0.0.1",
  user: "root",
  password: "",
  database: "test"
});
//!Beállítások
const ip = '127.0.0.1';
const port = 3000;

//!Változók
var obj = [];
var beolvfajl = [];


//!URL-ek kezelése
//?Főoldal:
router.get('/', (request, response) => {
    response.sendFile(path.join(__dirname+'/public/html/index.html'));
});
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.json());
//!Szerver futtatása
app.use(express.static('public')); //?CSS és JavaScript fájlok betöltése az oldal működéséhez
app.use('/', router);
app.get('/mq',async (req,res) => {
    fQuery(req.query.select,(r)=>{
      res.send(r);
    })
})
app.post('/form',upload.single('file'),async (req, res) => {
    let filed = [];
    
    const input = fs.createReadStream(req.file.path);
    async function feldolgozas(){
        for await (const line of readLines({ input })) {
            console.log(line);
            let t = line.split(';');
            let f = {};
            f.ev = t[0];
            f.tipus = t[1];
            f.knev = t[2];
            f.vnev = t[3];
            filed.push(f);
            console.log(line);
        }
        return filed;
      };
    obj=[];
    obj.push(await req.body);
    obj.push(await feldolgozas());
    fs.unlink(req.file.path, function (err) {
      if (err) throw err;
      console.log('File deleted!');
    });
    res.send(obj);
})
app.post('/fupload',upload.single('file'),async (req, res) => {
  //let filed = [];
  
  fs.rename(req.file.path, "public/img/"+req.file.originalname, function (err) {
    if (err) throw err;
    console.log('File Renamed!');
  });
  res.send(obj);
})
app.listen(port, ip, () => {
    console.log('Szerver figyelése a következő porton: ' + port + ' a következő ip címen: ' + ip);
});
function readLines({ input }) {
    const output = new stream.PassThrough({ objectMode: true });
    const rl = readline.createInterface({ input });
    rl.on("line", line => { 
      output.write(line);
    });
    rl.on("close", () => {
      output.push(null);
    }); 
    return output;
  }
 function fQuery(qdata,callback){
     pool.query(qdata, async function (err, result, fields) {
      if (err) throw err;
      //console.log(result);
      return callback(await result);
    });
 }