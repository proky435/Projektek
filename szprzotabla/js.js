document.addEventListener("DOMContentLoaded", () => {
  

  let szorzotabla = [];
  let selectedRow = -1;
  let selectedColumn = -1;


  function initTable() {
    let table = document.getElementById("szorzotabla");

    for (let i = 0; i < 10; i++) {
      let row = table.insertRow();
      szorzotabla[i] = [];

      for (let j = 0; j < 10; j++) {
        let cell = row.insertCell();
        cell.textContent = i * j;
        szorzotabla[i][j] = i * j;

        cell.id = `cell_${i}_${j}`;

        cell.addEventListener("click", function() {
          selectRowColumn(i, j);
        });
      }
    }
  }




  function colorSelected() {
    for (let i = 0; i < 10; i++) {
      for (let j = 0; j < 10; j++) {
        let cell = document.getElementById(`cell_${i}_${j}`);
        if (i === selectedRow || j === selectedColumn) {
          cell.classList.add('selected');
        } else {
          cell.classList.remove('selected');
        }
      }
    }
  }

  function colorSelectedIntersection() {
    for (let i = 0; i < 10; i++) {
      for (let j = 0; j < 10; j++) {
        let cell = document.getElementById(`cell_${i}_${j}`);
        if (i === selectedRow && j === selectedColumn) {
          cell.classList.add('intersection-row', 'intersection-column');
        } else if (i === selectedRow) {
          cell.classList.add('intersection-row');
          cell.classList.remove('intersection-column');
        } else if (j === selectedColumn) {
          cell.classList.add('intersection-column');
          cell.classList.remove('intersection-row');
        } else {
          cell.classList.remove('intersection-row', 'intersection-column');
        }
      }
    }
  }

  function refreshTable() {
    let table = document.getElementById("szorzotabla");

    for (let i = 0; i < 10; i++) {
      for (let j = 0; j < 10; j++) {
        let cell = table.rows[i].cells[j];
        let value = szorzotabla[i][j];
        
        cell.textContent = (value !== 0) ? value : '';
      }
    }

    colorSelected();
    colorSelectedIntersection();
  }

  function clearSelection() {
    let selectedCells = document.querySelectorAll('.selected');
    selectedCells.forEach(cell => cell.classList.remove('selected'));
  }

  function selectRowColumn(row, column) {
    clearSelection();

    for (let i = 0; i < 10; i++) {
      let rowCell = document.getElementById(`cell_${i}_${column}`);
      let colCell = document.getElementById(`cell_${row}_${i}`);
      
      rowCell.classList.toggle('selected');
      colCell.classList.toggle('selected');
    }

    selectedRow = row;
    selectedColumn = column;

    colorSelected();
    colorSelectedIntersection();
  }

  function ChangeTable(direction) {
    if (window.selectedRow !== -1 && window.selectedColumn !== -1) {
      let change = (direction === 'fel') ? 1 : (direction === 'le') ? -1 : 0;
  
      for (let i = 0; i < 10; i++) {
        if (direction === 'bal' || direction === 'jobb') {
          let temp = szorzotabla[i][window.selectedColumn];
          szorzotabla[i][window.selectedColumn] = szorzotabla[i][window.selectedColumn + change];
          szorzotabla[i][window.selectedColumn + change] = temp;
        } else {
          szorzotabla[i][window.selectedColumn] += change;
          szorzotabla[window.selectedRow][i] += change;
        }
      }
  
      refreshTable();
    }
  }


  window.ChangeTable=function(direction) {
    if (window.selectedRow !== -1 && window.selectedColumn !== -1) {
      let change = (direction === 'fel') ? 1 : (direction === 'le') ? -1 : 0;
  
      for (let i = 0; i < 10; i++) {
        if (direction === 'bal' || direction === 'jobb') {
          let temp = szorzotabla[i][window.selectedColumn];
          szorzotabla[i][window.selectedColumn] = szorzotabla[i][window.selectedColumn + change];
          szorzotabla[i][window.selectedColumn + change] = temp;
        } else {
          szorzotabla[i][window.selectedColumn] += change;
          szorzotabla[window.selectedRow][i] += change;
        }
      }
      console.log("meg vagyok hivva")
  
      refreshTable();
    }
  }


initTable();



});


/*
window.onload = function() {
    let szorzotabla = [];
    let selectedRow = -1;
    let selectedColumn = -1;

   


    function initTable() {
      let table = document.getElementById("szorzotabla");

      for (let i = 0; i < 10; i++) {
        let row = table.insertRow();
        szorzotabla[i] = [];

        for (let j = 0; j < 10; j++) {
          let cell = row.insertCell();
          cell.textContent = i * j;
          szorzotabla[i][j] = i * j;

          cell.id = `cell_${i}_${j}`;

          cell.addEventListener("click", function() {
            selectRowColumn(i, j);
          });
        }
      }
    }

    function colorSelected() {
      for (let i = 0; i < 10; i++) {
        for (let j = 0; j < 10; j++) {
          let cell = document.getElementById(`cell_${i}_${j}`);
          if (i === selectedRow || j === selectedColumn) {
            cell.classList.add('selected');
          } else {
            cell.classList.remove('selected');
          }
        }
      }
    }

    function colorSelectedIntersection() {
      for (let i = 0; i < 10; i++) {
        for (let j = 0; j < 10; j++) {
          let cell = document.getElementById(`cell_${i}_${j}`);
          if (i === selectedRow && j === selectedColumn) {
            cell.classList.add('intersection-row', 'intersection-column');
          } else if (i === selectedRow) {
            cell.classList.add('intersection-row');
            cell.classList.remove('intersection-column');
          } else if (j === selectedColumn) {
            cell.classList.add('intersection-column');
            cell.classList.remove('intersection-row');
          } else {
            cell.classList.remove('intersection-row', 'intersection-column');
          }
        }
      }
    }

    function refreshTable() {
      let table = document.getElementById("szorzotabla");

      for (let i = 0; i < 10; i++) {
        for (let j = 0; j < 10; j++) {
          let cell = table.rows[i].cells[j];
          let value = szorzotabla[i][j];
          
          cell.textContent = (value !== 0) ? value : '';
        }
      }

      colorSelected();
      colorSelectedIntersection();
    }

    function clearSelection() {
      let selectedCells = document.querySelectorAll('.selected');
      selectedCells.forEach(cell => cell.classList.remove('selected'));
    }

    function selectRowColumn(row, column) {
      clearSelection();

      for (let i = 0; i < 10; i++) {
        let rowCell = document.getElementById(`cell_${i}_${column}`);
        let colCell = document.getElementById(`cell_${row}_${i}`);
        
        rowCell.classList.toggle('selected');
        colCell.classList.toggle('selected');
      }

      selectedRow = row;
      selectedColumn = column;

      colorSelected();
      colorSelectedIntersection();
    }

    function changeTable(direction) {
        if (window.selectedRow !== -1 && window.selectedColumn !== -1) {
          let change = (direction === 'fel') ? 1 : (direction === 'le') ? -1 : 0;
      
          for (let i = 0; i < 10; i++) {
            if (direction === 'bal' || direction === 'jobb') {
              let temp = szorzotabla[i][window.selectedColumn];
              szorzotabla[i][window.selectedColumn] = szorzotabla[i][window.selectedColumn + change];
              szorzotabla[i][window.selectedColumn + change] = temp;
            } else {
              szorzotabla[i][window.selectedColumn] += change;
              szorzotabla[window.selectedRow][i] += change;
            }
          }
      
          refreshTable();
        }
      }
    

    initTable();
  };

 */



  /* <script>
      let szorzotabla = [];
      let selectedRow = -1;
      let selectedColumn = -1;
  
      function initTable() {
        let table = document.getElementById("szorzotabla");
  
        for (let i = 0; i < 10; i++) {
          let row = table.insertRow();
          szorzotabla[i] = [];
  
          for (let j = 0; j < 10; j++) {
            let cell = row.insertCell();
            cell.textContent = i * j;
            szorzotabla[i][j] = i * j;
  
            cell.id = `cell_${i}_${j}`;
  
            cell.addEventListener("click", function() {
              selectRowColumn(i, j);
            });
          }
        }
      }
  
      function colorSelected() {
        for (let i = 0; i < 10; i++) {
          for (let j = 0; j < 10; j++) {
            let cell = document.getElementById(`cell_${i}_${j}`);
            if (i === selectedRow || j === selectedColumn) {
              cell.classList.add('selected');
            } else {
              cell.classList.remove('selected');
            }
          }
        }
      }
  
      function colorSelectedIntersection() {
        for (let i = 0; i < 10; i++) {
          for (let j = 0; j < 10; j++) {
            let cell = document.getElementById(`cell_${i}_${j}`);
            if (i === selectedRow && j === selectedColumn) {
              cell.classList.add('intersection-row', 'intersection-column');
            } else if (i === selectedRow) {
              cell.classList.add('intersection-row');
              cell.classList.remove('intersection-column');
            } else if (j === selectedColumn) {
              cell.classList.add('intersection-column');
              cell.classList.remove('intersection-row');
            } else {
              cell.classList.remove('intersection-row', 'intersection-column');
            }
          }
        }
      }
  
      function refreshTable() {
        let table = document.getElementById("szorzotabla");
  
        for (let i = 0; i < 10; i++) {
          for (let j = 0; j < 10; j++) {
            let cell = table.rows[i].cells[j];
            let value = szorzotabla[i][j];
            
            cell.textContent = (value !== 0) ? value : '';
          }
        }
  
        colorSelected();
        colorSelectedIntersection();
      }
  
      function clearSelection() {
        let selectedCells = document.querySelectorAll('.selected');
        selectedCells.forEach(cell => cell.classList.remove('selected'));
      }
  
      function selectRowColumn(row, column) {
        clearSelection();
  
        for (let i = 0; i < 10; i++) {
          let rowCell = document.getElementById(`cell_${i}_${column}`);
          let colCell = document.getElementById(`cell_${row}_${i}`);
          
          rowCell.classList.toggle('selected');
          colCell.classList.toggle('selected');
        }
  
        selectedRow = row;
        selectedColumn = column;
  
        colorSelected();
        colorSelectedIntersection();
      }
  
      function changeTable(direction) {
        if (selectedRow !== -1 && selectedColumn !== -1) {
          let change = (direction === 'fel') ? 1 : (direction === 'le') ? -1 : 0;
  
          for (let i = 0; i < 10; i++) {
            if (direction === 'bal' || direction === 'jobb') {
              let temp = szorzotabla[i][selectedColumn];
              szorzotabla[i][selectedColumn] = szorzotabla[i][selectedColumn + change];
              szorzotabla[i][selectedColumn + change] = temp;
            } else {
              szorzotabla[i][selectedColumn] += change;
              szorzotabla[selectedRow][i] += change;
            }
          }
  
          refreshTable();
        }
      }
  
      initTable();
    </script>*/ 
  