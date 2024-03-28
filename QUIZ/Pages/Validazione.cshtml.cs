using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class ValidazioneModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<Verifica> Verifiche { get; set; }

    public void OnGet(string nome, string[] ru, string[] rg)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome);
      
      var verificas = new List<Verifica>();
      int punteggio = 0;

      for (int i = 0; i < 4; i++)
      {
        if (ru[i] == rg[i])
        {
          verificas.Add(new Verifica{Id = i+1, RispostaUtente = ru[i], RispostaVerifica= rg[i], Uguali = true });
          punteggio++;
        }
        else
        {
          verificas.Add(new Verifica{Id = i+1, RispostaUtente = ru[i], RispostaVerifica= rg[i], Uguali = false });
        }
      }
    
      int record = Utente.Punteggi.Max();

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

      Verifiche = verificas;
    }

}


