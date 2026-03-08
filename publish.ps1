$ErrorActionPreference = "Stop"

# Read version and target framework from csproj
$csproj = [xml](Get-Content "WebcamQuickProfiles.csproj")
$Version = $csproj.Project.PropertyGroup.Version
$TargetFramework = $csproj.Project.PropertyGroup.TargetFramework

$OutputDir = ".\publish"
if (-not (Test-Path $OutputDir)) { mkdir $OutputDir }

Write-Host "Publishing v$Version (TargetFramework: $TargetFramework)..." -ForegroundColor Green

dotnet restore
dotnet build --configuration Release --no-restore
dotnet publish --configuration Release --no-restore -r win-x64

$source = "bin\Release\$TargetFramework\win-x64\publish\WebcamQuickProfiles.exe"
$target = "$OutputDir\WebcamQuickProfiles`_$Version.exe"

if (Test-Path $source) {
    Copy-Item $source $target -Force
    Write-Host "✓ Published: $target" -ForegroundColor Green
} else {
    Write-Error "Exe not found at $source"
    exit 1
}
