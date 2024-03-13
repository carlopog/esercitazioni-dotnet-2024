using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages;
public class ProdottiModel : PageModel
{
  public required IEnumerable<Prodotto> Prodotti { get; set; }
  public void OnGet()
  {
    Prodotti = new List<Prodotto>
      {
        new Prodotto { Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "La descrizione del prodotto numero 1"},
        new Prodotto { Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "La descrizione del prodotto numero 2"},
        new Prodotto { Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "La descrizione del prodotto numero 3"}
      };
  }
}

