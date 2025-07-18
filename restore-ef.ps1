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

# Clean any existing EntityFramework package
if (Test-Path "packages\EntityFramework.6.5.0") {
    Remove-Item -Recurse -Force "packages\EntityFramework.6.5.0"
}

# Install EntityFramework package with specific version
Write-Host "Installing EntityFramework package..."
& $nugetPath install EntityFramework -Version 6.5.0 -OutputDirectory packages -Source https://api.nuget.org/v3/index.json

# Verify the package structure
Write-Host "Verifying package structure..."
if (Test-Path "packages\EntityFramework.6.5.0\build\EntityFramework.props") {
    Write-Host "EntityFramework.props found successfully!"
} else {
    Write-Host "Warning: EntityFramework.props not found in expected location"
    Write-Host "Checking package contents..."
    Get-ChildItem -Recurse "packages\EntityFramework.6.5.0" | Select-Object FullName
} 