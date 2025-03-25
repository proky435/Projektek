document.addEventListener("DOMContentLoaded",()=>{
    document.getElementById("logB").addEventListener("click",login);
})
function login() {
    let log={};
    log.user=document.getElementById("user").value;
    log.pw=CryptoJS.SHA512(document.getElementById("pw").value)+"";
    // console.log(document.getElementById("pw").value);
    // console.log(CryptoJS.SHA512("asd"));
    fetch("/log",{
        method:"POST",
        body: JSON.stringify(log),
        headers: {
                "Content-Type": "application/json",
                //'Content-Type': 'application/x-www-form-urlencoded',
            }
    })
    .then(req=>req.text())
    .then(res=>{
        if(res=="OK"){
            document.location.href="/";
        }
    })
}