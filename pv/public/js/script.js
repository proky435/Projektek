document.addEventListener("DOMContentLoaded", function () {
    // diakok kijelol
    const studentTableRows = document.querySelectorAll("#tbody-diak tr");
    studentTableRows.forEach(row => {
        row.addEventListener("click", function () {
            toggleRowSelection(row);
        });
    });

    // tanfolyam megjelit
    const courseTableRows = document.querySelectorAll("#tbody-tanfolyam tr");
    courseTableRows.forEach(row => {
        row.addEventListener("click", function () {
            toggleRowSelection(row);
        });
    });

    // diak hozzada
    const addStudentForm = document.getElementById("diak-hozzaadas");
    addStudentForm.addEventListener("diakSubmit", function (event) {
        event.preventDefault();
        const name = document.getElementById("nev").value;
        const email = document.getElementById("email").value;
        const age = document.getElementById("kor").value;
        addStudent(name, email, age);
    });

    // tanfolyam hozzada
    const addCourseForm = document.getElementById("tanfolyam-hozzaadas");
    addCourseForm.addEventListener("tanfolyamSubmit", function (event) {
        event.preventDefault();
        const name = document.getElementById("nev").value;
        const description = document.getElementById("leiras").value;
        const instructor = document.getElementById("oktato").value;
        addCourse(name, description, instructor);
    });
});

function toggleRowSelection(row) {
    let tr_element = row;
    let tbody = row.parentElement;
    if (tr_element.dataset.selected == "true") {
        tr_element.dataset.selected = false;
        tr_element.style.cssText = '';
    } else {
        for (let i = 0; i < tbody.children.length; i++) {
            tbody.children[i].dataset.selected = false;
            tbody.children[i].style.cssText = '';
        }
        tr_element.dataset.selected = true;
        tr_element.style.backgroundColor = '#CCCCCC';
    }
}
