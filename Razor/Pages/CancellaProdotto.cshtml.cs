using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 

// using Razor.Models diventa indispensabile se uso dei namespace nei models

namespace Razor.Pages
{
  public class CancellaProdottoModel: PageModel
  {
    public Prodotto Prodotto { get; set; }
    public void OnGet(int id)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
      var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
      Prodotto = prodotti.FirstOrDefault(p => p.Id == id);
      // se vogliamo trasmettere alla post il prezzo e il dettaglio per poi essere mandati alla view
      ViewData["Prezzo"] = Prodotto.Prezzo;
      ViewData["Dettaglio"] = Prodotto.Dettaglio;
      ViewData["Nome"] = Prodotto.Nome;
      // nel cshtml possiamo usare ViewData["Prezzo"] e ViewData["Dettaglio"]
    }

    public IActionResult OnPost(int id)
    {
      var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json");
      var prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
      var prodotto = prodotti.FirstOrDefault(p => p.Id == id);
      prodotti.Remove(prodotto);
      // salva il file json formattato
      System.IO.File.WriteAllText("wwwroot/json/prodotti.json", JsonConvert.SerializeObject(prodotti, Formatting.Indented));
      return RedirectToPage("Prodotti");
    }
  }
}