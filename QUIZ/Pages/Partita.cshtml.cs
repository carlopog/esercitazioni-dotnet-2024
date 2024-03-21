
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class PartitaModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<Domanda> Domande { get; set; }
  public IEnumerable<DomandaAperta> DomandeAperte { get; set; }

  private List<string> selectedValues = new List<string>();

    public void OnGet(string nome, string difficolta)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome); // il nostro utente selezionato

      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandeintermedie.json"); 

    if (difficolta == "difficile")
    {
      domandejson =  System.IO.File.ReadAllText("wwwroot/json/domandeaperte.json");
      DomandeAperte = JsonConvert.DeserializeObject<List<DomandaAperta>>(domandejson);
      ViewData["difficolta"] = "difficile";
    }
    else if (difficolta == "facile")
    {
      domandejson = System.IO.File.ReadAllText("wwwroot/json/domandefacili.json");
      Domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);
      ViewData["difficolta"] = "facile";
    }
    else
    {
      Domande = JsonConvert.DeserializeObject<List<Domanda>>(domandejson);
      ViewData["difficolta"] = "intermedia";
    }
    }


    public IActionResult OnPost(string nome, string[] formvalues)
  {
     var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome);

        //creare risposte utente e risposte giuste come liste e paragonarle uno ad uno 
        //stiamo passando variabili che arrivano alla OnGet di Validazione.cshtml.cs
       return RedirectToPage("Validazione", new { utente = Utente, values = formvalues }); 
    
  }


// static bool Validazione(string rispostaAperta, string[] risposte)
// {
//    // string rispostaAperta = 'boh'
//    // string[] risposte = ['a', 'A', 'boh']


//    bool giusto = false;
//    int lunghezza = risposte.Length;
//    for (int i = 0; i < lunghezza; i++)
//    {
//      if (rispostaAperta == risposte[i])
//      {
//       giusto = true;
//      }
//    };
//    return giusto;

// }

}