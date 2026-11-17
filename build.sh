#!/usr/bin/env bash
set -euo pipefail

restore_arguments=(restore build/build.csproj)

if [[ -n "${ACCESSTOKENVALIDATION_NUGET_CONFIG:-}" ]]; then
    restore_arguments+=(--configfile "$ACCESSTOKENVALIDATION_NUGET_CONFIG")
fi

dotnet "${restore_arguments[@]}"
dotnet run --project build --no-restore -- "$@"
