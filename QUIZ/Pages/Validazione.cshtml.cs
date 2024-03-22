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

      for (int i = 0; i < 10; i++)
      {
        if (ru[i] == rg[i])
        {
          verificas.Add(new Verifica{Id = i+1, RispostaUtente = ru[i], RispostaVerifica= rg[i], Uguali = true });
        }
        else
        {
          verificas.Add(new Verifica{Id = i+1, RispostaUtente = ru[i], RispostaVerifica= rg[i], Uguali = false });
        }
      }

      Verifiche = verificas;

    }

}

