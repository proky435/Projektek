document.addEventListener("DOMContentLoaded",function(){
    document.getElementById("fsend").addEventListener("click",kuldf);
});

function kuldf() {
    let formData = new FormData(document.getElementById("file_move"));
    fetch("/fupload",{
        method: "POST",
        body: formData
    })
    .then(req=>req.text())
    .then(res=>{
        console.log(JSON.parse(res));
    })
}