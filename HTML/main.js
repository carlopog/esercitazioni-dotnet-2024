
function Add(id) {
  var numero = document.getElementById(id).innerHTML;
  var risultato = parseInt(numero) + 1;
  document.getElementById(id).innerHTML = risultato;
}
function Remove(id) {
  var numero = document.getElementById(id).innerHTML;
  if (numero == "0")
  {
    document.getElementById(id).innerHTML = 0;  
  }
  else 
  {
    var risultato = parseInt(numero) - 1;
    document.getElementById(id).innerHTML = risultato;
  }
}
