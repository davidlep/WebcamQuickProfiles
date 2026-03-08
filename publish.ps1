$ErrorActionPreference = "Stop"

# Read version from csproj
$Version = ([xml](Get-Content "WebcamQuickProfiles.csproj")).Project.PropertyGroup.Version

$OutputDir = ".\publish"
if (-not (Test-Path $OutputDir)) { mkdir $OutputDir }

Write-Host "Publishing v$Version..." -ForegroundColor Green

dotnet restore
dotnet build --configuration Release --no-restore
dotnet publish --configuration Release --self-contained -r win-x64 --no-build

$source = "bin\Release\net7.0-windows\win-x64\publish\WebcamQuickProfiles.exe"
$target = "$OutputDir\WebcamQuickProfiles`_$Version.exe"

if (Test-Path $source) {
    Copy-Item $source $target -Force
    Write-Host "✓ Published: $target" -ForegroundColor Green
} else {
    Write-Error "Exe not found at $source"
    exit 1
}
