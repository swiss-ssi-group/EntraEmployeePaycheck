# See Employee Paycheck using Microsoft Entra Verified Employee credential

[![.NET](https://github.com/swiss-ssi-group/EntraEmployeePaycheck/actions/workflows/dotnet.yml/badge.svg)](https://github.com/swiss-ssi-group/EntraEmployeePaycheck/actions/workflows/dotnet.yml)

## History

- 2023-07-04 Initial version

## User secrets Issuer, Verify

```
{
  "CredentialSettings": {
    "Endpoint": "https://beta.did.msidentity.com/v1.0/{0}/verifiablecredentials/request",
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

## Local debugging, required for callback

```
ngrok http https://localhost:5002
```

## Links


https://docs.microsoft.com/en-us/azure/active-directory/verifiable-credentials/

https://docs.microsoft.com/en-us/azure/active-directory/verifiable-credentials/get-started-request-api

https://github.com/Azure-Samples/active-directory-verifiable-credentials-dotnet

https://www.microsoft.com/de-ch/security/business/identity-access-management/decentralized-identity-blockchain

https://didproject.azurewebsites.net/docs/issuer-setup.html

https://didproject.azurewebsites.net/docs/credential-design.html

https://github.com/Azure-Samples/active-directory-verifiable-credentials

https://identity.foundation/

https://www.w3.org/TR/vc-data-model/

https://daniel-krzyczkowski.github.io/Azure-AD-Verifiable-Credentials-Intro/

https://dotnetthoughts.net/using-node-services-in-aspnet-core/

https://identity.foundation/ion/explorer

https://www.npmjs.com/package/ngrok

https://github.com/microsoft/VerifiableCredentials-Verificatio
