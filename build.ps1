$ErrorActionPreference = "Stop"

$restoreArguments = @("restore", "build/build.csproj")

if (-not [string]::IsNullOrWhiteSpace($env:ACCESSTOKENVALIDATION_NUGET_CONFIG))
{
    $restoreArguments += @("--configfile", $env:ACCESSTOKENVALIDATION_NUGET_CONFIG)
}

dotnet @restoreArguments
if ($LASTEXITCODE -ne 0)
{
    exit $LASTEXITCODE
}

$runArguments = @("run", "--project", "build", "--no-restore", "--") + $args
dotnet @runArguments
exit $LASTEXITCODE
