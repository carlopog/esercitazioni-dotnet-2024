using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;


public class LoginModel : PageModel
{
  public void OnGet(bool wrongName, bool wrongPassword)
  {
    if (wrongName)
    {
      ViewData["ClasseNome"] = "form-control is-invalid";
      ViewData["MessaggioNome"] = "Non esiste alcun utente con il nome selezionato";
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
          return RedirectToPage("Privacy");
          // pagina gioca
        }
        else
        {
          return RedirectToPage("Login",  new { wrongPassword = true });
          // pagina wrong password
        }
      }
      else
      {
        return RedirectToPage("Login", new { wrongName = true });
        // pagina wrong name (no user with this name)
      }
    }

    else
    {
      return RedirectToPage("Privacy");
      // pagina non ci sono utenti registrati
    }
  }
}
