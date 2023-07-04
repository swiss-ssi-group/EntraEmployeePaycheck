using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePaycheck.Pages.Paycheck;

[AllowAnonymous]
public class PaycheckVerifyEmployeeS2Model : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? PaycheckId { get; set; }

    [BindProperty]
    public string? AbortPortalUrl { get; set; } = "/Paycheck/PaycheckEnterIdS1";

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        return Redirect($"~/Paycheck/PaycheckDetailsS3/{PaycheckId}");
    }
}
