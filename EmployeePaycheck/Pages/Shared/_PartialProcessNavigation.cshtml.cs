using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EmployeePaycheck.Pages.Shared;

public class PartialProcessNavigationModel : PageModel
{
    public PartialProcessNavigationModel(int activeStep)
    {
        ActiveStep = activeStep;
    }

    [BindProperty]
    public int ActiveStep { get; set; }
}
