
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class PartitaModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<Domanda> Domande { get; set; }

    public void OnGet(string nome, string difficolta)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome);

      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domande.json");

    if (difficolta == "difficile")
    {
      domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedifficili.json");
    }
    else if (difficolta == "facile")
    {
      domandejson = System.IO.File.ReadAllText("wwwroot/json/domandefacili.json");
    }
      Domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);
    }


}