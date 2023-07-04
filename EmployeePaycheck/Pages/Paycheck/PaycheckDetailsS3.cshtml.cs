using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePaycheck.Pages.Paycheck;

[AllowAnonymous]
public class PaycheckDetailsS3Model : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? PaycheckId { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }
}
