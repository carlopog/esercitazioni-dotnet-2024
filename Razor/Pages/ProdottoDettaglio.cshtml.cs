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

  public IActionResult OnPost()
  {
        // Esegui le operazioni necessarie con i dati del form

    // Memorizza un messaggio da visualizzare dopo il postback
    TempData["Message"] = "Operazione completata con successo!";

    // Effettua il redirect alla pagina di destinazione (GET)
    return RedirectToPage("NomePagina");
  }
}