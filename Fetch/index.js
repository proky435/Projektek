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

const app = express();
const router = express.Router();

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
app.post('/form',upload.single('file'),async (req, res) => {
    //let stream = await fs.createReadStream(req.file.path);
    // let rl = await readline.createInterface({
    //     input:stream,
    //     crlfDelay: Infinity
    // })
    let filed = [];
    const input = fs.createReadStream(req.file.path);
    async function aaa(){
        for await (const line of readLines({ input })) {
            console.log(line);
            let t = line.split(';');
            let f = {};
            f.ev = t[0];
            f.tipus = t[1];
            f.knev = t[2];
            f.vnev = t[3];
            // console.log(f);
            filed.push(f);
            console.log(line);
        }
        return filed;
      };
    obj=[];
    // console.log(req.body,req.file);
    obj.push(await req.body);
    obj.push(await aaa());
    // obj.push(await rlF2(stream));
    // console.log(await rlF2(stream));
    res.send(obj);
})

app.post('/szorzat',(req, res) => {
    console.log(req.body);
    let a = parseInt(req.body.szam3);
    let b = parseInt(req.body.szam4);
    res.send(a+b+"");
})
app.listen(port, ip, () => {
    console.log('Szerver figyelése a következő porton: ' + port + ' a következő ip címen: ' + ip);
});
async function rlF2(stream){
    let i = 0;
    let filed = [];
    for await (const line of readLines({stream})) {
        if (i !=0) {
            let t = line.split(';');
            let f = {};
            f.ev = t[0];
            f.tipus = t[1];
            f.knev = t[2];
            f.vnev = t[3];
            // console.log(f);
            filed.push(f);
            console.log(line);
        }
        i++;
    }
    return filed;
  }
async function rlF(rl){
    let i = 0;
    let filed = [];
    rl.on('line', (line)=>{
        if (i !=0) {
            let t = line.split(';');
            let f = {};
            f.ev = t[0];
            f.tipus = t[1];
            f.knev = t[2];
            f.vnev = t[3];
            // console.log(f);
            filed.push(f);
            console.log(line);
        }
        i++;
    });
    return filed;
}
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
  