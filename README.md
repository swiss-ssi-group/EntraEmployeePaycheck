# See Employee Paycheck using Microsoft Entra Verified Employee credential

[![.NET](https://github.com/swiss-ssi-group/EntraEmployeePaycheck/actions/workflows/dotnet.yml/badge.svg)](https://github.com/swiss-ssi-group/EntraEmployeePaycheck/actions/workflows/dotnet.yml)

## Deployment testing

### Get onboarded to the Azure AD tenant

Contact the HR, or your IT admin and ask nicely for an account.

### Get your verified employee credential

https://issueverifiableemployee.azurewebsites.net

### View your paycheck using the verified employee credential

https://employeepaycheck.azurewebsites.net

## History

- 2023-07-27 Updated packages
- 2023-07-06 Update flows and added deployment
- 2023-07-04 Initial version

## User secrets and verify configuration

```
{
  "CredentialSettings": {
    "Endpoint": "https://verifiedid.did.msidentity.com/v1.0/verifiableCredentials/createPresentationRequest",
    "VCServiceScope": "bbb94529-53a3-4be5-a069-7eaf2712b826/.default",
    "Instance": "https://login.microsoftonline.com/{0}",
    "TenantId": "YOURTENANTID",
    "ClientId": "APPLICATION CLIENT ID",
    "VcApiCallbackApiKey": "SECRET",
    "Authority": "YOUR authority",
    "ClientSecret": "[client secret or instead use the prefered certificate in the next entry]",
    // "CertificateName": "[Or instead of client secret: Enter here the name of a certificate (from the user cert store) as registered with your application]",
    "IssuerAuthority": "YOUR VC SERVICE DID",
    "VerifierAuthority": "YOUR VC SERVICE DID",
    "CredentialManifest":  "THE CREDENTIAL URL FROM THE VC PORTAL"
  }
}

```

## Issue Entra Verified ID Employee credentials

https://github.com/swiss-ssi-group/EntraVerifiedEmployee

## Local debugging, required for callback

```
ngrok http https://localhost:5002
```

## Links


https://github.com/swiss-ssi-group/AzureADVerifiableCredentialsAspNetCore

https://learn.microsoft.com/en-us/azure/active-directory/verifiable-credentials/decentralized-identifier-overview

https://ssi-start.adnovum.com/data

https://github.com/e-id-admin/public-sandbox-trustinfrastructure#14

https://openid.net/specs/openid-connect-self-issued-v2-1_0.html

https://identity.foundation/jwt-vc-presentation-profile/

https://learn.microsoft.com/en-us/azure/active-directory/verifiable-credentials/verifiable-credentials-standards

https://github.com/Azure-Samples/active-directory-verifiable-credentials-dotnet

https://aka.ms/mysecurityinfo

https://fontawesome.com/

https://developer.microsoft.com/en-us/graph/graph-explorer?tenant=damienbodsharepoint.onmicrosoft.com

https://learn.microsoft.com/en-us/graph/api/overview?view=graph-rest-1.0

https://github.com/Azure-Samples/VerifiedEmployeeIssuance

https://github.com/Azure-Samples/active-directory-verifiable-credentials-dotnet

https://github.com/AzureAD/microsoft-identity-web/blob/jmprieur/Graph5/src/Microsoft.Identity.Web.GraphServiceClient/Readme.md#replace-the-nuget-packages

https://docs.microsoft.com/azure/app-service/deploy-github-actions#configure-the-github-secret

https://issueverifiableemployee.azurewebsites.net/

https://datatracker.ietf.org/doc/draft-ietf-oauth-selective-disclosure-jwt/

## Links eIDAS and EUDI standards

Draft: OAuth 2.0 Attestation-Based Client Authentication
https://datatracker.ietf.org/doc/html/draft-looker-oauth-attestation-based-client-auth-00

Draft: OpenID for Verifiable Presentations
https://openid.net/specs/openid-4-verifiable-presentations-1_0.html

Draft: OAuth 2.0 Demonstrating Proof-of-Possession at the Application Layer (DPoP)
https://datatracker.ietf.org/doc/html/draft-ietf-oauth-dpop

Draft: OpenID for Verifiable Credential Issuance
https://openid.bitbucket.io/connect/openid-4-verifiable-credential-issuance-1_0.html

Draft: OpenID Connect for Identity Assurance 1.0
https://openid.net/specs/openid-connect-4-identity-assurance-1_0-13.html

Draft: SD-JWT-based Verifiable Credentials (SD-JWT VC)
https://vcstuff.github.io/draft-terbu-sd-jwt-vc/draft-terbu-oauth-sd-jwt-vc.html
