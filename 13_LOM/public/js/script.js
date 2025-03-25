document.addEventListener("DOMContentLoaded", function () {
    //először meghivni
    inditas();
    document.getElementById("teszt_b").addEventListener("click",()=>{
        document.getElementById("teszt_v").innerHTML=CryptoJS.SHA512(document.getElementById("teszt").value);
    })
    document.getElementById("logout").addEventListener("click",logout);
    document.getElementById("save").addEventListener("click",save);
});
function save(){
    fetch("/save", {
        method: "POST",
        body: JSON.stringify({"kId":document.getElementById("kerdes").dataset.id}),
        headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
        }
    })
        .then(req => req.json())
        .then(res => {
            if(res=="OK"){
                alert("Mentés sikeres!");
            }
            else
            {
                alert("Hiba a mentésben!");
            }
        })
}
function logout() {
    fetch("/logout", {
        method: "POST",
    })
        .then(req => req.text())
        .then(res => {
            if(res="OK"){
                document.location.href="/";
            }
        })
}
function inditas() {
    fetch("/jatek", {
        method: "POST",
        body: JSON.stringify({ valasz: null }),
        headers: {
            "Content-Type": "application/json",
            // 'Content-Type': 'application/x-www-form-urlencoded',
        }
    })
        .then(req => req.json())
        .then(res => {
            console.log(res);
            felulet(res);
        })
}
function felulet(adatok) {
    let kerdes = document.getElementById("kerdes");
    kerdes.innerHTML = adatok.kerdes.kerdes;
    kerdes.dataset.id=adatok.kerdes.id;
    let valaszok = document.getElementsByClassName("valasz");
    for (let i = 0; i < adatok.valasz.length; i++) {
        valaszok[i].innerHTML = adatok.valasz[i].valasz;
        valaszok[i].dataset.id = adatok.valasz[i].id;
        valaszok[i].addEventListener("click", kovetkezo);
    }
}
function kovetkezo() {
    let elem = this;
    this.style.backgroundColor = "green";
    for (let i = 0; i < document.getElementsByClassName("valasz").length; i++) {
        document.getElementsByClassName("valasz")[i].removeEventListener("click", kovetkezo);
    }
    setTimeout(() => {
        fetch("/jatek", {
            method: "POST",
            body: JSON.stringify({ valasz: this.dataset.id }),
            headers: {
                "Content-Type": "application/json",
                // 'Content-Type': 'application/x-www-form-urlencoded',
            }
        })
            .then(req => req.json())
            .then(res => {
                console.log(res);
                switch (res.allapot) {
                    case 1:
                        let ism=0;
                        setInterval(function villog(){
                            ism++;
                            if (elem.style.backgroundColor == "green") {
                                elem.style.backgroundColor = "";
                            }
                            else {
                                elem.style.backgroundColor = "green"
                            }
                            if (ism == 9) {
                                clearInterval(villog);
                                elem.style.backgroundColor = "";
                                felulet(res);
                            }
                        },500)
                        break;
                    case 2:
                        alert("Nyertél!");
                        break;
                    case 0:
                        this.style.backgroundColor = "red";
                        alert("Vesztettél!");
                        break;
                    default:
                        alert("Hiba!");
                        break;
                }


            })
    }, 2000)

}
