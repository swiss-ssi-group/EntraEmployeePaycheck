using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace EmployeePaycheck.Pages.Paycheck;

[Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
public class PaycheckDetailsS3Model : PageModel
{
    public readonly ValidateUserAndPaycheckIdService _validateUserAndPaycheckIdService;

    [BindProperty(SupportsGet = true)]
    public string? PaycheckId { get; set; }

    public PaycheckDetailsS3Model(ValidateUserAndPaycheckIdService validateUserAndPaycheckIdService)
    {
        _validateUserAndPaycheckIdService = validateUserAndPaycheckIdService;
    }

    [BindProperty]
    public string? AbortPortalUrl { get; set; } = "/Paycheck/PaycheckEnterIdS1";

    public async Task<IActionResult> OnGetAsync()
    {
        var upn = HttpContext.User.FindFirst("RevocationId");
        if (!_validateUserAndPaycheckIdService.PaycheckIdAndUserAreValid(upn!.Value, PaycheckId))
        {
            await HttpContext.SignOutAsync();
            return Redirect($"~/Paycheck/PaycheckError");
        }

        // Data should be fetched from a DB or an ERP service etc.

        return Page();
    }
}
