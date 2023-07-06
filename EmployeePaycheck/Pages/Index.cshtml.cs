using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePaycheck.Pages;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        return Redirect("/Paycheck/PaycheckEnterIdS1");
    }
}
