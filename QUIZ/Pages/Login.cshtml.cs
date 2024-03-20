using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace QUIZ.Pages;


public class LoginModel : PageModel
{
  public void OnGet(bool wrongName, bool wrongPassword)
  {
    if (wrongName)                              //se il nome inserito è inesistente
    {
      ViewData["ClasseNome"] = "form-control is-invalid";                   //assegno il valore form-control is-invalid alla key ClasseNome (per il bordo rosso)
      ViewData["MessaggioNome"] = "Non esiste alcun utente con il nome selezionato";        //faccio apparire questo messaggio 
    }
    else
    {
      ViewData["ClasseNome"] = "form-control";
      ViewData["MessaggioNome"] = "Confronteremo il tuo nome con quello degli utenti salvati";

    }
    if (wrongPassword)
    {
      ViewData["ClassePassword"] = "form-control is-invalid";
      ViewData["MessaggioPassword"] = "Password errata";
    }
    else
    {
      ViewData["ClassePassword"] = "form-control";
    }
  }

  public IActionResult OnPost(string nome, string password)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
    List<Utente>? utenti = JsonConvert.DeserializeObject<List<Utente>>(json);

    if (utenti != null)
    {
      if (utenti.Any(p => p.Nome == nome))
      {
        var utente = utenti.FirstOrDefault(p => p.Nome == nome);
        if (utente?.Password == password)
        {
          return RedirectToPage("Gioca", new { nome = utente.Nome });
          // pagina gioca
        }
        else
        {
          return RedirectToPage("Login",  new { wrongPassword = true });
        }
      }
      else
      {
        return RedirectToPage("Login", new { wrongName = true });
      }
    }

    else
    {
      return RedirectToPage("Registrati");
      // messaggio non esiste ancora nessun utente registrato
    }
  }
}
