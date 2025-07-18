# Create packages directory if it doesn't exist
if (-not (Test-Path "packages")) {
    New-Item -ItemType Directory -Path "packages"
}

# Download NuGet CLI if it doesn't exist
$nugetPath = ".\nuget.exe"
if (-not (Test-Path $nugetPath)) {
    Write-Host "Downloading NuGet CLI..."
    Invoke-WebRequest -Uri "https://dist.nuget.org/win-x86-commandline/latest/nuget.exe" -OutFile $nugetPath
}

# Install EntityFramework package
Write-Host "Installing EntityFramework package..."
& $nugetPath install EntityFramework -Version 6.5.0 -OutputDirectory packages 