document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("regB").addEventListener("click", sendReg);
})
function sendReg() {
    if (document.getElementById("pw").value == document.getElementById("pw_r").value) {
        let formData = new FormData(document.getElementById("reg"));
        formData.append("pw",CryptoJS.SHA512(document.getElementById("pw").value)+"")
        fetch("/reg", {
            method: "POST",
            body: formData,
            // headers: {
            //     //"Content-Type": "application/json",
            //     'Content-Type': 'application/x-www-form-urlencoded',
            // }
        })
            .then(req => req.text())
            .then(res => {
                if (res = "OK") {
                    document.location.href="/";
                    //window.location.href("/");
                }
            })
    }
    else{
        alert("Nem egyezik meg a két jelszó!");
    }

}