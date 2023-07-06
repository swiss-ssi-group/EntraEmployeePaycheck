using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace EmployeePaycheck.Pages.Paycheck;

[AllowAnonymous]
public class PaycheckEnterIdS1Model : PageModel
{
    [BindProperty]
    public string? AbortPortalUrl { get; set; } = "/Paycheck/PaycheckEnterIdS1";

    [Required]
    [BindProperty]
    public string PaycheckId { get; set; } = string.Empty;

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

        return Redirect($"~/Paycheck/PaycheckVerifyEmployeeS2/{PaycheckId}");
    }
}
