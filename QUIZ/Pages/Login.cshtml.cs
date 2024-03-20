using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;


public class LoginModel : PageModel
{
  public void OnGet()
  {
    // per ora niente
  }

  public IActionResult OnPost(string nome, string password)
  {

    var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
    List<Utente> utenti = JsonConvert.DeserializeObject<List<Utente>>(json);

    if (utenti.Any(p => p.Nome == nome))
    {
      var utente = utenti.FirstOrDefault(p => p.Nome == nome);
      if (utente.Password == password)
      {
        return RedirectToPage("Privacy");
        // pagina gioca
      }
      else
      {
        return RedirectToPage("Index");
        // pagina wrong password
      }
    }
    else
    {
      return RedirectToPage("Privacy");
      // pagina wrong name (no user with this name)
    }
  }
}