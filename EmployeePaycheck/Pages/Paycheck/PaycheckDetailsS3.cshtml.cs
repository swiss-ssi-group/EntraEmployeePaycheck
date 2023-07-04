using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EmployeePaycheck.Pages.Paycheck;

[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
public class PaycheckDetailsS3Model : PageModel
{
    [BindProperty(SupportsGet = true)]
    public string? PaycheckId { get; set; }

    [BindProperty]
    public string? AbortPortalUrl { get; set; } = "/Paycheck/PaycheckEnterIdS1";

    public IActionResult OnGet()
    {
        return Page();
    }
}
