console.log("Javascript is being ran....")

const months = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
function tableCreate(){
    event.preventDefault();
    var body = document.getElementsByTagName("body")[0];
    
    
 
 
  var ourTable     = document.createElement("table");
  var ourTableBody = document.createElement("tbody");
  for (var i = 0; i < 1; i++) {
 
    var row = document.createElement("tr");
 
    for (var j = 0; j <12; j++) {
 
 
      var cell = document.createElement("td");
      var cellText = document.createTextNode(months[j]);
      cell.appendChild(cellText);
      row.appendChild(cell);
    }
 
 
    ourTableBody.appendChild(row);
  }
 
 
  for (var i = 0; i <1; i++) {
 
    var row = document.createElement("tr");
 
    for (var j = 0; j <12; j++) {
 
 
      var cell = document.createElement("td");
      

      var cellText = document.createTextNode("Yearly Salary: "   + getYearlySalary() + '\n' );
     
      
      
      cell.appendChild(cellText); 
      
     
      row.appendChild(cell);
    }
 
 
    ourTableBody.appendChild(row);
  }
  for (var i = 0; i <1; i++) {
    var row = document.createElement("tr");
    for (var j = 0; j <12; j++) {
      var cell = document.createElement("td");
      var cellText1 = document.createTextNode("Money Available Per Month: " + getAmonth().toFixed(3) + '\n');
      cell.appendChild(cellText1);
      row.appendChild(cell);
    }
    ourTableBody.appendChild(row);
  }
  for (var i = 0; i <1; i++) {
    var row = document.createElement("tr");
    for (var j = 0; j <12; j++) {
      var cell = document.createElement("td");
      var cellText3 = document.createTextNode("Money Leftover: " + calcAvMonth().toFixed(3) + '\n');
      cell.appendChild(cellText3);
      row.appendChild(cell);
    }
    ourTableBody.appendChild(row);
  }
  
  ourTable.appendChild(ourTableBody);
  body.appendChild(ourTable);
  ourTable.setAttribute("border", "2");
}
function getYearlySalary(){
    var yearlySalary = $('#yearlySalary').val(); 
    return yearlySalary; 
}
function getAmonth(){
    var year = getYearlySalary(); 
    var aMonth = year / 12; 
    return aMonth; 
}
function getAmountSpent(){
    var amountSpend = $('#amountSpend').val(); 
    return amountSpend;
}
// function getAmountSave(){
//     var amountSave = $('#amountSave').val(); 
//     return amountSave; 
// }
// function calcSaved(){
//     ySalary = getYearlySalary(); 
//     spent = getAmountSpent(); 
//     save = getAmountSave(); 
//     var saved = ((ySalary / 12) - spent) - save; 
//     return saved; 
// }
function calcAvMonth(){
    var ySalary = getYearlySalary(); 
    var spend = getAmountSpent(); 
    var amountAvPM = (ySalary / 12) - spend; 
    return amountAvPM; 

}
function login() {
    event.preventDefault(); //Prevents information from trying to be sent to server
    var yearlySalary = $('#yearlySalary').val(); 
    var amountSpend = $('#amountSpend').val(); 
    var amountSave = $('#amountSave').val(); 
    return yearlySalary + " " +amountSpend + " " +  amountSave;
}

$('#loginform').submit(function (event) { 
    event.preventDefault();
    $('#table').empty();
    //$('#info').append(login);
    $('#table').append(tableCreate);  

}) 
$('#math').submit(function(event) {
    event.preventDefault(); 
    $('#info').empty(); 
    $('#info').append(randomMAth); 


}) 