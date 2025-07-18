# Download NuGet CLI if it doesn't exist
$nugetPath = ".\nuget.exe"
if (-not (Test-Path $nugetPath)) {
    Write-Host "Downloading NuGet CLI..."
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetPath
}

# Restore packages
Write-Host "Restoring NuGet packages..."
& $nugetPath restore 