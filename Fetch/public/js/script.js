document.addEventListener("DOMContentLoaded",function(){
    document.getElementById("send").addEventListener("click",kuld);
});
function kuld() {
    let formData = new FormData(document.getElementById("alap_form"));
    formData.append("pipa",document.getElementById("cb").checked)
    fetch("/form",{
        method: "POST",
        body: formData
    })
    .then(req=>req.text())
    .then(res=>{
        console.log(JSON.parse(res));
    })
}