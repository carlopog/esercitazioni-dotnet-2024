using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 

// using Razor.Models diventa indispensabile se uso dei namespace nei models

namespace Razor.Pages
{
  public class AggiungiProdottoModel: PageModel
  {
    public void OnGet()
    {
      // non fa niente
    }

    public IActionResult OnPost(string nome, decimal prezzo, string dettaglio, int id)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
      var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
      prodotti.Add(new Prodotto { Id = id, Nome = nome, Prezzo = prezzo, Dettaglio = dettaglio });
      // salva il file json formattato
      System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
      return RedirectToPage("Prodotti");
    }
  }
}