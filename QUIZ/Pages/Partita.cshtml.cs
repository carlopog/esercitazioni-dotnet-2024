
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class PartitaModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<Domanda> Domande { get; set; }
  public IEnumerable<DomandaAperta> DomandeAperte { get; set; }
  public IEnumerable<Verifica> Giuste { get; set; }

    public void OnGet(string nome, string difficolta)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome); // il nostro utente selezionato

      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedifficili.json"); 

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


    public IActionResult OnPost(string nome)
  {
        //creare risposte utente e risposte giuste come liste e paragonarle uno ad uno 
        //stiamo passando variabili che arrivano alla OnGet di Validazione.cshtml.cs


      var risposteUtente = new List<string>
      {
          Request.Form["1risposta"],
          Request.Form["2risposta"],
          Request.Form["3risposta"],
          Request.Form["4risposta"],
          Request.Form["5risposta"],
          Request.Form["6risposta"],
          Request.Form["7risposta"],
          Request.Form["8risposta"],
          Request.Form["9risposta"],
          Request.Form["10risposta"]
      };


      var risposteGiuste = new List<string>
      {
          Request.Form["1rispostaGiusta"],
          Request.Form["2rispostaGiusta"],
          Request.Form["3rispostaGiusta"],
          Request.Form["4rispostaGiusta"],
          Request.Form["5rispostaGiusta"],
          Request.Form["6rispostaGiusta"],
          Request.Form["7rispostaGiusta"],
          Request.Form["8rispostaGiusta"],
          Request.Form["9rispostaGiusta"],
          Request.Form["10rispostaGiusta"]
      };

      List<Verifica> giustino = new List<Verifica>(); // assegno all'enumerable Giuste il valore di una lista di Giusta
       
      for (int p = 0; p < 10; p++) // lng è la lunghezza dei miei array risposteGiuste e risposteUtente
      {
       bool uguali = false;  // creo un booleano uguaglianza settato falso 
       if (risposteGiuste[p] == risposteUtente[p]) // controllo l'uguaglianza
       {
         uguali = true; // se uguali setto true
       }
       var giusta = new Verifica{ Id = p+1, RispostaVerifica= risposteGiuste[p], RispostaUtente = risposteUtente[p], Uguali = uguali };
       // creo un oggetto Verificacon i dati qua sopra 
       giustino.Add(giusta);
       // lo aggiunga alla mia lista che poi e' l'enumerable che passo alla view
      }
      Giuste = giustino;
      return RedirectToPage("Validazione", new { nome, rG = risposteGiuste, ru = risposteUtente }); 
  }



}