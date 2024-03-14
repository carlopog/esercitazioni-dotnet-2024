using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages;
public class ProdottiModel : PageModel
{
  private readonly ILogger<ProdottiModel> _logger;

  public ProdottiModel(ILogger<ProdottiModel> logger)
  {
    _logger = logger;
  }
  public required IEnumerable<Prodotto> Prodotti { get; set; }
  public void OnGet(decimal? minPrezzo, decimal? maxPrezzo)
  {
    Prodotti = new List<Prodotto>
      {
        new Prodotto { Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "La descrizione del prodotto numero 1"},
        new Prodotto { Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "La descrizione del prodotto numero 2"},
        new Prodotto { Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "La descrizione del prodotto numero 3"}
      };

      if (minPrezzo.HasValue)
      {
        Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);
      }
      if (maxPrezzo.HasValue)
      {
        Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
      }
      // aggiungi un log
      _logger.LogInformation("Prodotti filtrati per prezzo");
  }
}

