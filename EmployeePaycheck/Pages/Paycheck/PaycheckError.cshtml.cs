using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePaycheck.Pages.Paycheck;

[AllowAnonymous]
public class PaycheckErrorModel : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? PaycheckId { get; set; }

    public string? ErrorMessage { get; set; }

    public IActionResult OnGet()
    {
        ErrorMessage = $"Something went wrong: your paycheck ID: '{PaycheckId}', only paycheck ID 'P12345' works for the demo";
        return Page();
    }
}
