using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages; // namespace già predisposto col nome della cartella.Pages

public class IndexModel : PageModel // IndexModel è una classe che eredita da PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet() 
    {
      ViewData["Message"] = "Hello from Razor";
    }
}
