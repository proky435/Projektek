document.addEventListener("DOMContentLoaded", function () {
    const exportButton = document.getElementById("exportButton");

    exportButton.addEventListener("click", function () {
        fetch("/students")
            .then(response => response.json())
            .then(data => {
                const csvData = convertToCSV(data);
                downloadCSV(csvData);
            })
            .catch(error => console.error("Hiba történt a diákok lekérdezése közben:", error));
    });
    function convertToCSV(data) {
        const headers = Object.keys(data[0]).join(",");
        const rows = data.map(row => Object.values(row).join(","));
        //return ${headers}\n${rows.join("\n")};
        return headers+'\n'+rows.join('\n');
    }

    function downloadCSV(csvData) {
        const blob = new Blob([csvData], { type: "text/csv" });
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement("a");
        a.href = url;
        a.download = "diakok.csv";
        document.body.appendChild(a);
        a.click();
        window.URL.revokeObjectURL(url);
        document.body.removeChild(a);
    }
});
asd
document.addEventListener("DOMContentLoaded", function () {
    const exportButton = document.getElementById("exportButton");

    exportButton.addEventListener("click", function () {
        fetch("/students")
            .then(response => response.json())
            .then(data => {
                const csvData = convertToCSV(data);
                downloadCSV(csvData);
            })
            .catch(error => console.error("Hiba történt a diákok lekérdezése közben:", error));
    });

    function convertToCSV(data) {
        const headers = Object.keys(data[0]).join(",");
        const rows = data.map(row => Object.values(row).join(","));
        return headers + '\n'+rows.join('\n');
    }

    function downloadCSV(csvData) {
        const blob = new Blob([csvData], { type: "text/csv" });
        const url = window.URL.createObjectURL(blob);
        const a = document.createElement("a");
        a.href = url;
        a.download = "diakok.csv";
        document.body.appendChild(a);
        a.click();
        window.URL.revokeObjectURL(url);
        document.body.removeChild(a);
    }
});