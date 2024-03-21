using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;


namespace QUIZ.Pages;

public class ValidazioneModel : PageModel
{
  public Utente Utente { get; set; }

    public void OnGet(Utente utente, string[] values)
    {
    }

}