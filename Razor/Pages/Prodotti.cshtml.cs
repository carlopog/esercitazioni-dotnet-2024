using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 

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
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json"); 
    Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json); 
  
      if (minPrezzo.HasValue)
      {
        Prodotti = Prodotti.Where(p => p.Prezzo >= minPrezzo);
      }
      if (maxPrezzo.HasValue)
      {
        Prodotti = Prodotti.Where(p => p.Prezzo <= maxPrezzo);
      }
      numeroPagine = (int)Math.Ceiling(Prodotti.Count() / 5.0);
      Prodotti = Prodotti.Skip(((pageIndex ?? 1) - 1)*5).Take(5);
      // aggiungi un log
      _logger.LogInformation("Prodotti filtrati per prezzo");
  }
}
