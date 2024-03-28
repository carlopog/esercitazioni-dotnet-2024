
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class PartitaModel : PageModel
{
  [BindProperty]
  public List<string> Risposte { get; set; }
  [BindProperty]
  public List<string> RisposteGiuste { get; set; }
  public Utente Utente { get; set; }
  public IEnumerable<Domanda> Domande { get; set; }
  public IEnumerable<DomandaAperta> DomandeAperte { get; set; }
  public IEnumerable<Verifica> Giuste { get; set; }


    private readonly ILogger<PartitaModel> _logger;

    public PartitaModel(ILogger<PartitaModel> logger)
    {
        _logger = logger;
    }


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

        foreach (var r in RisposteGiuste)
        {
        _logger.LogInformation("RisposteGiuste: { 0 }" ,  r);

        }
     
      List<Verifica> giustino = new List<Verifica>(); // assegno all'enumerable Giuste il valore di una lista di Giusta
       
      for (int p = 0; p < 4; p++) // lng è la lunghezza dei miei array risposteGiuste e risposteUtente
      {
       bool uguali = false;  // creo un booleano uguaglianza settato falso 
       if (RisposteGiuste[p] == Risposte[p]) // controllo l'uguaglianza
       {
         uguali = true; // se uguali setto true
       }
       var giusta = new Verifica{ Id = p+1, RispostaVerifica= RisposteGiuste[p], RispostaUtente = Risposte[p], Uguali = uguali };
       // creo un oggetto Verificacon i dati qua sopra 
       giustino.Add(giusta);
       // lo aggiunga alla mia lista che poi e' l'enumerable che passo alla view
      }
      Giuste = giustino;
      return RedirectToPage("Validazione", new { nome, rG = RisposteGiuste, ru = Risposte }); 
  }



}