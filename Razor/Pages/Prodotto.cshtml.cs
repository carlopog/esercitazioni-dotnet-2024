using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Razor.Pages;

public class ProdottoModel : PageModel
{
    private readonly ILogger<ProdottoModel> _logger;

    public ProdottoModel(ILogger<ProdottoModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}

