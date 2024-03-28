using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class ValidazioneDoppiaModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<VerificaDoppia> Giuste { get; set; }

    public void OnGet(string nome, List<VerificaDoppia> giustino, int punteggio)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome);
      
      Giuste = giustino;
      int record = Utente.Record;
      
      if (punteggio > record)
      {
        record = punteggio;
      }

      int vecchiPunteggi = Utente.Punteggi.Length;
      int[] scores = new int[vecchiPunteggi + 1];
      
      for (int s = 0; s < vecchiPunteggi; s++)
      {
        scores[s] = Utente.Punteggi[s];
      }

      scores[vecchiPunteggi] = punteggio;
      Utente.Punteggi = scores;
      Utente.Record = record;
      System.IO.File.WriteAllText("wwwroot/json/utenti.json", JsonConvert.SerializeObject(utenti, Formatting.Indented));
    }

}




