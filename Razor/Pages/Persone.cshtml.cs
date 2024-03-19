using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 

namespace Razor.Pages;
public class PersoneModel : PageModel
{
  public required IEnumerable<Persona> Persone { get; set; }
  public void OnGet()
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/persone.json"); 
    Persone = JsonConvert.DeserializeObject<List<Persona>>(json); 
  }
}
