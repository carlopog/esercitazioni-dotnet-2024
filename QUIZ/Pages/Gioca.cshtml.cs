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

}