// creare la logica di una partita con domande
// che hanno 3 opzioni
// tutte e 3 selezionabili
// due su tre sono giuste
// o volendo una su tre (mettendo risposta1 e risposta2 uguali)
// se hai crocettato la risposta sbagliata un punto in meno
// se hai crocettato quella giusta 1 in piu'


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class PartitaDoppiaModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<DomandaDoppia> DomandeDoppie { get; set; }
  public IEnumerable<Verifica> Giuste { get; set; }

    public void OnGet(string nome, string difficolta)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome); // il nostro utente selezionato

      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedoppie.json"); 

      DomandeDoppie = JsonConvert.DeserializeObject<List<DomandaAperta>>(domandejson);
    }
    }


    public IActionResult OnPost(string nome)
  {
        //creare risposte utente e risposte giuste come liste e paragonarle uno ad uno 
        //stiamo passando variabili che arrivano alla OnGet di Validazione.cshtml.cs


      var risposteUtente = new List<string>
      {
          Request.Form["1risposta1"],
          Request.Form["1risposta2"],
          Request.Form["2risposta1"],
          Request.Form["2risposta2"],
          Request.Form["3risposta1"],
          Request.Form["3risposta2"]
          // inserire poi i value seguendo questi nomi
      };


      var risposteGiuste = new List<string>
      {
          Request.Form["1rispostaGiusta1"],
          Request.Form["1rispostaGiusta2"],
          Request.Form["2rispostaGiusta1"],
          Request.Form["2rispostaGiusta2"],
          Request.Form["3rispostaGiusta1"],
          Request.Form["3rispostaGiusta2"]
      };

      List<Verifica> giustino = new List<Verifica>(); // assegno all'enumerable Giuste il valore di una lista di Giusta
       
      for (int p = 0; p < 6; p++) // 6 è la lunghezza dei miei array risposteGiuste e risposteUtente
      {
       int uguali = 0;  // creo un booleano uguaglianza settato falso 
       if (risposteUtente[p] == risposteGiuste[p]  || risposteUtente[p] == risposteGiuste[p+1] ) // controllo l'uguaglianza
       {
         uguali++; // se uguali setto true
       }
       var giusta = new VerificaDoppia{ Id = p+1, RispostaVerifica= risposteGiuste[p], RispostaUtente = risposteUtente[p], Uguali = uguali };
       // creo un oggetto Verificacon i dati qua sopra 
       giustino.Add(giusta);
       // lo aggiunga alla mia lista che poi e' l'enumerable che passo alla view
      }
      Giuste = giustino;
      return RedirectToPage("Validazione", new { nome, rG = risposteGiuste, ru = risposteUtente }); 
  }



}