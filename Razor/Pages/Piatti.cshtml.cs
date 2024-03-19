using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 

namespace Razor.Pages;
public class PiattiModel : PageModel
{
  public required IEnumerable<Piatto> Piatti { get; set; }
  public void OnGet()
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/piatti.json"); 
    Piatti = JsonConvert.DeserializeObject<List<Piatto>>(json); 
  }
}