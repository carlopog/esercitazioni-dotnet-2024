using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json; 


namespace Razor.Pages;


public class ProdottoDettaglioModel : PageModel
{
  public required Prodotto Prodotto {get; set;}
  public void OnGet(int id)
  {
    var numero = id - 1;
    var json = System.IO.File.ReadAllText("wwwroot/json/prodotti.json"); 
    List<Prodotto> Prodotti = JsonConvert.DeserializeObject<List<Prodotto>>(json);
    Prodotto = Prodotti[numero];
  }
}