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
  public IEnumerable<VerificaDoppia> Giuste { get; set; }

    public void OnGet(string nome)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome); // il nostro utente selezionato

      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedoppie.json"); 
      DomandeDoppie = JsonConvert.DeserializeObject<List<DomandaDoppia>>(domandejson);
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

      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedoppie.json"); 
      List<DomandaDoppia> domandeDoppie = JsonConvert.DeserializeObject<List<DomandaDoppia>>(domandejson);

      string[] risposteGiuste = new string[20];

      // foreach (var dd in domandeDoppie)
      for (int r = 0; r < 20; r++)
      {
        risposteGiuste[r] = r + "risposta";
      }

      int punteggio = 0;
      int counter = 1;
      string rg1;
      string rg2;

      List<VerificaDoppia> giustino = new List<VerificaDoppia>(); // assegno all'enumerable Giuste il valore di una lista di Giusta

      foreach (var risposta in risposteUtente) // per ogni risposta utente la confronto alle sue 2 risposte giuste
      {
        rg1 = risposteGiuste[counter];
        rg2 = risposteGiuste[counter+1];
        bool uguali = false;

        if (risposta == rg1 || risposta == rg2)
        {
          punteggio++;
          uguali = true;
          // creo un oggetto Verificacon i dati qua sopra 
        }
        else
        {
          punteggio--;
        }
        var giusta = new VerificaDoppia{ Id = counter+1, RispostaGiusta1= rg1, RispostaGiusta2 = rg2, RispostaUtente = risposta, Uguali = uguali };
        giustino.Add(giusta);
        counter = counter + 2;
      }

      Giuste = giustino;
      return RedirectToPage("ValidazioneDoppia", new { nome, giustino, punteggio }); 
  }

}
