using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace QUIZ.Pages;


public class RegistrazioneModel : PageModel
{
  public void OnGet(bool wrongName)
  {
    if (wrongName)
    {
      ViewData["ClasseNome"] = "form-control is-invalid";
      ViewData["MessaggioNome"] = "Esiste già un utente con il nome selezionato";
    }
    else
    {
      ViewData["ClasseNome"] = "form-control";
      ViewData["MessaggioNome"] = "Confronteremo il tuo nome con quello degli utenti salvati";

    }
  }

  public IActionResult OnPost(string nome, string password)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
    List<Utente>? utenti = JsonConvert.DeserializeObject<List<Utente>>(json);     //creo lista utenti coi dati del json

    
      if (utenti.Any(p => p.Nome == nome))    //controllo se esiste un utente col nome passato come parametro
      {
        return RedirectToPage("Registrazione", new {wrongName=true});     //ritorno alla pagina registrazione con messaggio d'errore perchè l'utente esiste gia
      }
      else
      {
        utenti.Add(new Utente {Nome = nome, Password=password, Record=0, Punteggi=[0]});
      
        System.IO.File.WriteAllText("wwwroot/json/utenti.json", JsonConvert.SerializeObject(utenti, Formatting.Indented));
      return RedirectToPage("Login");
      } 
  }
}
