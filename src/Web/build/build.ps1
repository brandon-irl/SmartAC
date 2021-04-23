param([Parameter()][bool]$production = $false,
    [Parameter(Mandatory = $true)][string]$key,
    [Parameter(Mandatory = $true)][string]$certname,
    [Parameter(Mandatory = $true)][string]$certpw)

$configuration = if ($production) { "Release" } else { "Debug" }

Write-Host "BUILDING DOTNET"
# Build publish files
dotnet publish -c $configuration

Write-Host "BUILDING DOCKER"
#Build Image
docker build -t theorem-smartac .

Write-Host "RUNNING DOCKER"
# Run container just to test
docker run --rm -it -p 8000:80 -p 8001:443 `
    -e AppSettings__EncryptionKey='$configuration' `
    -e ASPNETCORE_URLS="https://+;http://+" `
    -e ASPNETCORE_HTTPS_PORT=8001 `
    -e ASPNETCORE_Kestrel__Certificates__Default__Password=$certpw `
    -e ASPNETCORE_Kestrel__Certificates__Default__Path=/https/$($certname).pfx `
    -v ${HOME}/.aspnet/https:/https/ `
    theorem-smartac
