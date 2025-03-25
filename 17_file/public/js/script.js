document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("sendButton").addEventListener("click", fileSend);
    document.getElementById("downloadButton").addEventListener("click", fileDownload);
});

function fileSend() {
    let formData = new FormData(document.getElementById("fileForm"));
    fetch("/fsend", {
        method: "POST",
        body: formData
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('Az adatok küldése sikertelen volt.');
        }
        return response.json();
    })
    .then(data => {
        // Adatok kuldese SIKERES, mehet tablazatba
        displayDataInTable(data);
    })
    .catch(error => {
        console.log('hiba:', error);
    });
}

function fileDownload() {
    fetch("/download", {
        method: "POST"
    })
    .then(response => {
        if (!response.ok) {
            throw new Error('a fajl letoltese nem mukszik');
        }
        return response.blob();
    })
    .then(blob => {
        const objectUrl = URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = objectUrl;
        link.download = 'download.csv';
        link.click();
        URL.revokeObjectURL(objectUrl);
    })
    .catch(error => {
        console.error('hiba:', error);
    });
}

function displayDataInTable(data) {
    const tbody = document.getElementById("dataBody");
    tbody.innerHTML = ""; // tabla tartalma kukaba

    data.forEach(row => {
        const tr = document.createElement("tr");
        Object.values(row).forEach(value => {
            const td = document.createElement("td");
            td.textContent = value;
            tr.appendChild(td);
        });
        tbody.appendChild(tr);
    });

    // megjelenit tabla + letoltes gomb
    document.getElementById("tableContainer").style.display = "block";
    document.getElementById("downloadButtonContainer").style.display = "block";
}
