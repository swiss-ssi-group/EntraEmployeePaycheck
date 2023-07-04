using VerifierInsuranceCompany;

namespace EmployeePaycheck;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<VerifierService>();

        builder.Services.Configure<CredentialSettings>(
             builder.Configuration.GetSection("CredentialSettings"));

        builder.Services.AddHttpClient();
        builder.Services.AddDistributedMemoryCache();

        // Add services to the container.
        builder.Services.AddRazorPages();

        var app = builder.Build();

        app.UseSecurityHeaders(
            SecurityHeadersDefinitions.GetHeaderPolicyCollection(
                app.Environment.IsDevelopment()));

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers();
        app.MapRazorPages();

        app.Run();
    }
}
