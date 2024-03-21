
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class PartitaModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<Domanda> Domande { get; set; }
  public IEnumerable<DomandaAperta> DomandeAperte { get; set; }
  public IEnumerable<Giusta> Giuste { get; set; }


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


    public IActionResult OnPost(string nome)
  {
        //creare risposte utente e risposte giuste come liste e paragonarle uno ad uno 
        //stiamo passando variabili che arrivano alla OnGet di Validazione.cshtml.cs

      var rispostaUtente1 = Request.Form["1risposta"];
      var rispostaUtente2 = Request.Form["2risposta"];
      var rispostaUtente3 = Request.Form["3risposta"];
      var rispostaUtente4 = Request.Form["4risposta"];
      var rispostaUtente5 = Request.Form["5risposta"];
      var rispostaUtente6 = Request.Form["6risposta"];
      var rispostaUtente7 = Request.Form["7risposta"];
      var rispostaUtente8 = Request.Form["8risposta"];
      var rispostaUtente9 = Request.Form["9risposta"];
      var rispostaUtente10 = Request.Form["10risposta"];

      List<string> risposteUtente = new List<string>();
      risposteUtente.Add(rispostaUtente1);
      risposteUtente.Add(rispostaUtente2);
      risposteUtente.Add(rispostaUtente3);
      risposteUtente.Add(rispostaUtente4);
      risposteUtente.Add(rispostaUtente5);
      risposteUtente.Add(rispostaUtente6);
      risposteUtente.Add(rispostaUtente7);
      risposteUtente.Add(rispostaUtente8);
      risposteUtente.Add(rispostaUtente9);
      risposteUtente.Add(rispostaUtente10);


      var rispostaGiusta1 = Request.Form["1rispostaGiusta"];
      var rispostaGiusta2 = Request.Form["2rispostaGiusta"];
      var rispostaGiusta3 = Request.Form["3rispostaGiusta"];
      var rispostaGiusta4 = Request.Form["4rispostaGiusta"];
      var rispostaGiusta5 = Request.Form["5rispostaGiusta"];
      var rispostaGiusta6 = Request.Form["6rispostaGiusta"];
      var rispostaGiusta7 = Request.Form["7rispostaGiusta"];
      var rispostaGiusta8 = Request.Form["8rispostaGiusta"];
      var rispostaGiusta9 = Request.Form["9rispostaGiusta"];
      var rispostaGiusta10 = Request.Form["10rispostaGiusta"];

      
      List<string> risposteGiuste = new List<string>();
      risposteGiuste.Add(rispostaGiusta1);
      risposteGiuste.Add(rispostaGiusta2);
      risposteGiuste.Add(rispostaGiusta3);
      risposteGiuste.Add(rispostaGiusta4);
      risposteGiuste.Add(rispostaGiusta5);
      risposteGiuste.Add(rispostaGiusta6);
      risposteGiuste.Add(rispostaGiusta7);
      risposteGiuste.Add(rispostaGiusta8);
      risposteGiuste.Add(rispostaGiusta9);
      risposteGiuste.Add(rispostaGiusta10);

      // List<bool> uguali = new List<bool>();

      /* for (int f = 0; f < 10; f++)
       {
        if (risposteUtente[f] == risposteGiuste[f])
          {
            uguali.Add(true)
          }
        else
          {
            uguali.Add(false)
          }
        }*/ 

      List<Giusta> giustino = new List<Giusta>(); // assegno all'enumerable Giuste il valore di una lista di Giusta
       
      for (int p = 0; p < 5; p++) // lng è la lunghezza dei miei array risposteGiuste e risposteUtente
      {
       bool uguali = false;  // creo un booleano uguaglianza settato falso 
       if (risposteGiuste[p] == risposteUtente[p]) // controllo l'uguaglianza
       {
         uguali = true; // se uguali setto true
       }
       var giusta = new Giusta { Id = p+1, RispostaGiusta = risposteGiuste[p], RispostaUtente = risposteUtente[p], Uguali = uguali };
       // creo un oggetto Giusta con i dati qua sopra 
       giustino.Add(giusta);
       // lo aggiunga alla mia lista che poi e' l'enumerable che passo alla view
      }
      Giuste = giustino;


       return RedirectToPage("Validazione", new { nome = nome, rG = risposteGiuste, ru = risposteUtente }); 
    
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