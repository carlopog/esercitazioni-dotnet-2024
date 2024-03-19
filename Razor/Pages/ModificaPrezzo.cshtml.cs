using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 


namespace Razor.Pages;


public class ModificaPrezzoModel : PageModel
{

  public required Prodotto Prodotto { get; set; }

  public void OnGet(int id)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    Prodotto = prodotti.FirstOrDefault(p => p.Id == id);
  }

  public IActionResult OnPost(int id, decimal prezzo)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    var prodotto = prodotti.FirstOrDefault(p => p.Id == id);
    prodotto.Prezzo = prezzo;
    
    System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
    return RedirectToPage("Prodotti");
  }
  

}