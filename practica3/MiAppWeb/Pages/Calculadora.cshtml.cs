using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MathLibrary;
using System.Numerics;

namespace MiAppWeb.Pages;

public class CalculadoraModel : PageModel
{
         private readonly ILogger<PrivacyModel> _logger;
      public CalculadoraModel (ILogger<PrivacyModel> logger)
    {
        _logger = logger;
       
    }       
    public string Message { get; private set;}= "PageModel in C#";
    [BindProperty]
     public double Fnumber { get; set; } = 0;
    [BindProperty]
     public double Snumber { get; set; }= 0;
    public double Resultado { get; private set;}= 0;
     

    public void OnGet()
    {
        Message += $" Server time is { DateTime.Now }";
    }

    public void OnPostAdd()
    {
     MathOperations mathOps = new MathOperations();
      Resultado = mathOps.Sumar(Fnumber,Snumber);
    }

     public void OnPostSubs()
    {
      MathOperations mathOps = new MathOperations();
      Resultado = mathOps.Restar(Fnumber,Snumber);
    }

     public void OnPostMultiplication()
    {
      
      Resultado = Fnumber * Snumber;
    }

     public void OnPostDivision()
    {
      
      Resultado = Fnumber / Snumber;
    }
    
}