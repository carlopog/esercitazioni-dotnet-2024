using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 


namespace Razor.Pages;


public class PiattoSingoloModel : PageModel
{
  public required Piatto Piatto {get; set;}
  public void OnGet(int id)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/piatti.json"); 
    List<Piatto> Piatti = JsonConvert.DeserializeObject<List<Piatto>>(json);
    Piatto = Piatti.FirstOrDefault(p => p.Id == id);
  }
}