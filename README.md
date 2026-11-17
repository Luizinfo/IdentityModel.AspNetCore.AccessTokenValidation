# ZinfoFramework IdentityModel ASP.NET Core Access Token Validation

> Independent continuation maintained under ZinfoFramework. This project is not affiliated with or supported by the historical upstream maintainers.

ASP.NET Core helpers that select access-token validation between JWT bearer authentication and OAuth 2.0 token introspection. Version 10.0.0 targets only .NET 10 (`net10.0`).

## Package transition

| Historical package ID | Current package ID |
| --- | --- |
| `IdentityModel.AspNetCore.AccessTokenValidation` | `ZinfoFramework.IdentityModel.AspNetCore.AccessTokenValidation` |

The assembly name and public namespaces remain `IdentityModel.AspNetCore.AccessTokenValidation`, so application `using` directives do not change.

## Installation

```shell
dotnet add package ZinfoFramework.IdentityModel.AspNetCore.AccessTokenValidation --version 10.0.0
```

## Purpose and usage

The package provides helpers such as `Selector.ForwardReferenceToken()` and scope-claim transformation for ASP.NET Core authentication. Configure JWT bearer authentication and, when reference tokens are accepted, the independently maintained `ZinfoFramework.IdentityModel.AspNetCore.OAuth2Introspection` package. Keep using the preserved `IdentityModel.AspNetCore.AccessTokenValidation` namespace in source code.

## Migrating from the historical package

1. Change only the NuGet package reference to `ZinfoFramework.IdentityModel.AspNetCore.AccessTokenValidation` version `10.0.0`.
2. Target .NET 10.
3. Keep existing assembly references, namespaces, and API usage.
4. If the application uses introspection, migrate that package reference to `ZinfoFramework.IdentityModel.AspNetCore.OAuth2Introspection` version `10.0.0` as well.

The leastprivilege article associated with the historical project remains useful as historical context, but it is not a current support channel: [Flexible access token validation in ASP.NET Core](https://leastprivilege.com/2020/07/06/flexible-access-token-validation-in-asp-net-core/).

## Project links

- [Repository](https://github.com/Luizinfo/IdentityModel.AspNetCore.AccessTokenValidation)
- [Issues and documentation](https://github.com/Luizinfo/IdentityModel.AspNetCore.AccessTokenValidation/issues)
- [License](https://github.com/Luizinfo/IdentityModel.AspNetCore.AccessTokenValidation/blob/main/LICENSE)
- [Notice](https://github.com/Luizinfo/IdentityModel.AspNetCore.AccessTokenValidation/blob/main/NOTICE.md)
- [Support policy](https://github.com/Luizinfo/IdentityModel.AspNetCore.AccessTokenValidation/blob/main/SUPPORT.md)
- [Security policy](https://github.com/Luizinfo/IdentityModel.AspNetCore.AccessTokenValidation/blob/main/SECURITY.md)

## Build and pull-request validation

Install the exact .NET SDK **10.0.401** selected by `global.json`. Run `./build.ps1` on Windows or `./build.sh` on Linux/macOS from the repository root. The default build compiles the solution, runs its tests, and creates local validation packages. CI installs the same SDK from `global.json` and checks Windows, Linux, and macOS. It runs for pull requests and correction/release branches without publishing packages.

Unreleased build changes do not replace the existing NuGet release. A future publication requires a new package version and validation of the final artifacts.
