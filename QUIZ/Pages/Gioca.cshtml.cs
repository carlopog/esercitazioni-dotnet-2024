using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class GiocaModel : PageModel
{
  public Utente Utente { get; set; }

    public void OnGet(string nome)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome);
    }

    public IActionResult OnPost(string difficolta)
  {
    if (difficolta == "difficile")
    {
      return RedirectToPage("Partita", new { difficolta = "difficile" });
    }
    else if (difficolta == "facile")
    {
      return RedirectToPage("Partita", new { difficolta = "facile" });
    }
    else
    {
      return RedirectToPage("Partita", new { difficolta = "intermedia" });
    }
  }
}