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
  public int numeroPagine { get; set; }
  public void OnGet(decimal? minPrezzo, decimal? maxPrezzo, int? pageIndex)
  {
    Prodotti = new List<Prodotto>
      {
        new Prodotto { Nome = "Prodotto 1", Prezzo = 100, Dettaglio = "Dettaglio 1"},
        new Prodotto { Nome = "Prodotto 2", Prezzo = 200, Dettaglio = "Dettaglio 2"},
        new Prodotto { Nome = "Prodotto 3", Prezzo = 300, Dettaglio = "Dettaglio 3"},
        new Prodotto { Nome = "Prodotto 4", Prezzo = 400, Dettaglio = "Dettaglio 4"},
        new Prodotto { Nome = "Prodotto 5", Prezzo = 500, Dettaglio = "Dettaglio 5"},
        new Prodotto { Nome = "Prodotto 6", Prezzo = 600, Dettaglio = "Dettaglio 6"},
        new Prodotto { Nome = "Prodotto 7", Prezzo = 700, Dettaglio = "Dettaglio 7"},
        new Prodotto { Nome = "Prodotto 8", Prezzo = 800, Dettaglio = "Dettaglio 8"},
        new Prodotto { Nome = "Prodotto 9", Prezzo = 900, Dettaglio = "Dettaglio 9"},
        new Prodotto { Nome = "Prodotto 10", Prezzo = 1000, Dettaglio = "Dettaglio 10"},
        new Prodotto { Nome = "Prodotto 11", Prezzo = 1100, Dettaglio = "Dettaglio 11"}
      };

      if (minPrezzo.HasValue)
      {
        Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);
      }
      if (maxPrezzo.HasValue)
      {
        Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
      }
      numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 2.0);
      Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1)*2).Take(2);
      // aggiungi un log
      _logger.LogInformation("Prodotti filtrati per prezzo");

  }
}

