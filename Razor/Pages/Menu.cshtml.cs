using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 

namespace Razor.Pages;
public class MenuModel : PageModel
{
  public required IEnumerable<Piatto> Menu { get; set; }
  public void OnGet()
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/piatti.json"); 
    List<Piatto> Piatti = JsonConvert.DeserializeObject<List<Piatto>>(json); 
    Menu = Piatti.Where(p => p.Disponibile == true);
  }
}