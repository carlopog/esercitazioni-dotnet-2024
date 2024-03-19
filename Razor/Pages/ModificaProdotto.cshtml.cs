using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 


namespace Razor.Pages;


public class ModificaProdottoModel : PageModel
{

  public Prodotto Prodotto { get; set; }

  public void OnGet(int id)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    Prodotto = prodotti.FirstOrDefault(p => p.Id == id);
  }

  public IActionResult OnPost(int id, decimal prezzo, string nome, string dettaglio)
  {
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
    var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    var prodotto = prodotti.FirstOrDefault(p => p.Id == id);
    prodotto.Nome = nome;
    prodotto.Prezzo = prezzo;
    prodotto.Dettaglio = dettaglio;
    
    System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
    return RedirectToPage("Prodotti");
  }
  

}