using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class ValidazioneModel : PageModel
{
  public Utente Utente { get; set; }
  public IEnumerable<Giusta> Giuste { get; set; }

    public void OnGet(string nome, string[] ru, string[] rg)
    {

      var json = System.IO.File.ReadAllText("wwwroot/json/utenti.json");
      var utenti = JsonConvert.DeserializeObject<List<Utente>>(json);
      Utente = utenti.FirstOrDefault(u => u.Nome == nome);
      
      var giuste = new List<Giusta>();

      for (int i = 0; i < 10; i++)
      {
        if (ru[i] == rg[i])
        {
          giuste.Add(new Giusta {Id = i+1, RispostaUtente = ru[i], RispostaGiusta = rg[i], Uguali = true });
        }
        else
        {
          giuste.Add(new Giusta {Id = i+1, RispostaUtente = ru[i], RispostaGiusta = rg[i], Uguali = false });
        }
      }

      Giuste = giuste;

    }

}

