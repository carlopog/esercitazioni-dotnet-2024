
function Add(id) {
  var numero = document.getElementById(id).innerHTML;
  var quantita = parseInt(numero) + 1;
  document.getElementById(id).innerHTML =  quantita;
  console.log(quantita, id)
}
function Remove(id) {
  var numero = document.getElementById(id).innerHTML;
  if (numero == "0")
  {
    document.getElementById(id).innerHTML = 0;  
  }
  else 
  {
    var  quantita = parseInt(numero) - 1;
    document.getElementById(id).innerHTML =  quantita;
  }
}
