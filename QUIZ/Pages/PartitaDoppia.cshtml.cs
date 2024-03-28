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
          Request.Form["1opzioneA"], 
          Request.Form["1opzioneB"], 
          Request.Form["1opzioneC"], 

          Request.Form["2opzioneA"],
          Request.Form["2opzioneB"],
          Request.Form["2opzioneC"],

          Request.Form["3opzioneA"],
          Request.Form["3opzioneB"],
          Request.Form["3opzioneC"]
          // inserire poi i value seguendo questi nomi
      };

     var risposteGiuste1 = new List<string>
      {
          Request.Form["1rispostaGiusta1"],
          Request.Form["2rispostaGiusta1"],
          Request.Form["3rispostaGiusta1"]
       
      };

     var risposteGiuste2 = new List<string>
      {
          Request.Form["1rispostaGiusta2"],
          Request.Form["2rispostaGiusta2"],
          Request.Form["3rispostaGiusta2"]
      };



      var domandejson = System.IO.File.ReadAllText("wwwroot/json/domandedoppie.json"); 
      List<DomandaDoppia> domandeDoppie = JsonConvert.DeserializeObject<List<DomandaDoppia>>(domandejson);


      int punteggio = 0;
      int counter = 0;
      int salto = 0;
      string rg2;
      string risposta;

      List<VerificaDoppia> giustino = new List<VerificaDoppia>(); // assegno all'enumerable Giuste il valore di una lista di Giusta


      foreach (var rg in risposteGiuste1)
      {
        for (int e = 0; e < 3; e++) 
        {
          risposta = risposteUtente[e + salto];
          rg2 = risposteGiuste2[counter];
          bool uguali = false;

          if (risposta != null)
          {

          if (risposta == rg || risposta == rg2)
          {
            punteggio++;
            uguali = true;
          }
          else
          {
            punteggio--;
          }
          var giusta = new VerificaDoppia{ Id = e+salto+1, RispostaGiusta1= rg, RispostaGiusta2 = rg2, RispostaUtente = risposta, Uguali = uguali };
          giustino.Add(giusta);
          }
        }
        counter++;
        salto = salto + 3;
      }
        Giuste = giustino;


      return RedirectToPage("ValidazioneDoppia", new { nome, Giuste, punteggio }); 
  }

}
