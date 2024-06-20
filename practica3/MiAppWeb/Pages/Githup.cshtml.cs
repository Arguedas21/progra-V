using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MiAppWeb.Pages;

public class GithupModel : PageModel
{
    private readonly ILogger<GithupModel> _logger;

    public GithupModel(ILogger<GithupModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}