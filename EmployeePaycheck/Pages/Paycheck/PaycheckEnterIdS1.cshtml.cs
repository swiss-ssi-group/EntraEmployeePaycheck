using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePaycheck.Pages.Paycheck;

[AllowAnonymous]
public class PaycheckEnterIdS1Model : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? PaycheckId { get; set; }

    [BindProperty]
    public string? AbortPortalUrl { get; set; } = "/Paycheck/PaycheckEnterIdS1";

    [BindProperty]
    public string PersonID { get; set; } = string.Empty;

    public IActionResult OnGet()
    {
        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        return Redirect($"~/Paycheck/PaycheckVerifyEmployeeS2/{PersonID}");
    }
}
