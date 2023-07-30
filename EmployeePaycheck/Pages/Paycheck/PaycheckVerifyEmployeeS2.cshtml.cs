using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Distributed;
using VerifierInsuranceCompany.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace EmployeePaycheck.Pages.Paycheck;

[AllowAnonymous]
public class PaycheckVerifyEmployeeS2Model : PageModel
{
    protected readonly IDistributedCache _distributedCache;

    public PaycheckVerifyEmployeeS2Model(IDistributedCache distributedCache)
    {
        _distributedCache = distributedCache;
    }

    [BindProperty(SupportsGet = true)]
    public string? PaycheckId { get; set; }

    [BindProperty]
    public string? AbortPortalUrl { get; set; } = "/Paycheck/PaycheckEnterIdS1";

    [BindProperty]
    public string? StatePresented { get; set; }

    public IActionResult OnGet()
    {
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (StatePresented == null)
        {
            ModelState.AddModelError("StatePresented", "no vc");
            return Page();
        }

        var credentialData = CacheData.GetFromCache(StatePresented, _distributedCache);

        var claims = new List<Claim> {
            new Claim("DisplayName", credentialData!.Employee.DisplayName, ClaimValueTypes.String, "damienbodsharepoint"),
            new Claim("JobTitle", credentialData!.Employee.JobTitle, ClaimValueTypes.String, "damienbodsharepoint"),
            new Claim("PreferredLanguage", credentialData!.Employee.PreferredLanguage, ClaimValueTypes.String, "damienbodsharepoint"),
            new Claim("RevocationId", credentialData!.Employee.RevocationId, ClaimValueTypes.String, "damienbodsharepoint"),
            new Claim("GivenName", credentialData!.Employee.GivenName, ClaimValueTypes.String, "damienbodsharepoint"),
            new Claim("Mail", credentialData!.Employee.Mail, ClaimValueTypes.String, "damienbodsharepoint"),
            new Claim("Surname", credentialData!.Employee.Surname, ClaimValueTypes.String, "damienbodsharepoint"),
            new Claim("Photo", credentialData!.Employee.Photo, ClaimValueTypes.String, "damienbodsharepoint"),
        };

        var userIdentity = new ClaimsIdentity(claims, "entraemployee");
        var userPrincipal = new ClaimsPrincipal(userIdentity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
            userPrincipal,
            new AuthenticationProperties
            {
                ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
                IsPersistent = false,
                AllowRefresh = false
            });

        CacheData.RemoveFromCache(StatePresented, _distributedCache);

        return Redirect($"~/Paycheck/PaycheckDetailsS3/{PaycheckId}");
    }
}
