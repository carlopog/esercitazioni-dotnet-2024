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

      ViewData["rg1"] = rg[0];
      ViewData["rg2"] = rg[1];
      ViewData["rg3"] = rg[2];
      ViewData["rg4"] = rg[3];
      ViewData["rg5"] = rg[4];
      ViewData["rg6"] = rg[5];
      ViewData["rg7"] = rg[6];
      ViewData["rg8"] = rg[7];
      ViewData["rg9"] = rg[8];
      ViewData["rg10"] = rg[9];

      ViewData["ru1"] = ru[0];
      ViewData["ru2"] = ru[1];
      ViewData["ru3"] = ru[2];
      ViewData["ru4"] = ru[3];
      ViewData["ru5"] = ru[4];
      ViewData["ru6"] = ru[5];
      ViewData["ru7"] = ru[6];
      ViewData["ru8"] = ru[7];
      ViewData["ru9"] = ru[8];
      ViewData["ru10"] = ru[9];

      if (ru[0] == rg[0])
      {
        ViewData["c1"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c1"] = "display: flex; border: 3px solid red; width: 300px";
      }

      if (ru[1] == rg[1])
      {
        ViewData["c2"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c2"] = "display: flex; border: 3px solid red; width: 300px";
      }

      if (ru[2] == rg[2])
      {
        ViewData["c3"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c3"] = "display: flex; border: 3px solid red; width: 300px";
      }
      if (ru[3] == rg[3])
      {
        ViewData["c4"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c4"] = "display: flex; border: 3px solid red; width: 300px";
      }
      if (ru[4] == rg[4])
      {
        ViewData["c5"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c5"] = "display: flex; border: 3px solid red; width: 300px";
      }
      if (ru[5] == rg[5])
      {
        ViewData["c6"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c6"] = "display: flex; border: 3px solid red; width: 300px";
      }
      if (ru[6] == rg[6])
      {
        ViewData["c7"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c7"] = "display: flex; border: 3px solid red; width: 300px";
      }
      if (ru[7] == rg[7])
      {
        ViewData["c8"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c8"] = "display: flex; border: 3px solid red; width: 300px";
      }
      if (ru[8] == rg[8])
      {
        ViewData["c9"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c9"] = "display: flex; border: 3px solid red; width: 300px";
      }
      if (ru[9] == rg[9])
      {
        ViewData["c10"] = "display: flex; border: 3px solid green; width: 300px";
      }
      else
      {
        ViewData["c10"] = "display: flex; border: 3px solid red; width: 300px";
      }
         
    }

}

