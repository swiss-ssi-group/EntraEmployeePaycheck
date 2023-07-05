namespace EmployeePaycheck;

public class ValidateUserAndPaycheckIdService
{
    public bool PaycheckIdAndUserAreValid(string? userPrincipalName, string? paycheckId)
    {
        if (userPrincipalName == null || paycheckId == null)
            return false;

        // Get paycheck data using id and validate that upn matches user in packcheckId
        // This can be specific to your ERP system etc.

        // simi check, only accept requests for "P12345" and any upn
        if(paycheckId == "P12345")
            return true;

        return false;
    }
}
