param(
    [Parameter(Mandatory = $true)][string]$address,
    [Parameter(Mandatory = $true)][int]$port,
    [string]$filepath = '.\Devices.txt',
    [int]$numberOfDevices = 10
)
#-----------------------------------------------------------
#               Function Declarations
#-----------------------------------------------------------
class Device {
    [string]$SerialNumber
    [string]$Secret
    [string]$FirmwareVersion
    [string]$Token

    Device([string]$sn, [string]$s) {
        $this.SerialNumber = $sn
        $this.Secret = $s
        $this.FirmwareVersion = "1"
    }
}

Function LoadDevices {
    write-host "Loading mock devices..."
    $num = 0;
    $devicestreamreader = New-Object System.IO.StreamReader($filepath)
    while ($devicestreamreader.Peek() -ge 1 ) {
        [Device]$device = [Device]::new($devicestreamreader.ReadLine(), $devicestreamreader.ReadLine())
        $device
        $num++
        if ($num -ge $numberOfDevices) {
            break;
        }
    }
    write-host "...Loaded $num devices"
    $devicestreamreader.Dispose()
}

Function Register-Device {
    Param(
        [Parameter(Mandatory = $true)][Device]$device,
        [Parameter()][bool]$wait = $true
    )
    Process {
        Write-Host "Registering $($device.SerialNumber) with $($device.Secret)..."
        if ($wait) { HoldUp }
        $slug = "/Registration/Register"
        $uri = New-Object System.UriBuilder('https', $address, $port, $slug)
        $body = @{
            Credentials     = @{
                SerialNumber = $device.SerialNumber
                Secret       = $device.Secret
            }
            FirmwareVersion = $device.FirmwareVersion
        } | ConvertTo-Json
        $response = Invoke-WebRequest -Uri $uri.Uri.AbsoluteUri -Method Post -Body $body -ContentType 'application/json'
        Write-Host "...Complete. Saving authentication token"
        $device.Token = $response
    }
}

Function SubmitSensorData {
    Param(
        [Parameter(Mandatory = $true)][Device]$device,
        [Parameter()][bool]$alert = $false,
        [Parameter()][bool]$wait = $true
    )
    Process {
        Write-Host "Submitting data for $($device.SerialNumber) with $($device.Secret)..."
        if ($wait) { HoldUp }
        $slug = "/Sensors/SubmitReading"
        $uri = New-Object System.UriBuilder('https', $address, $port, $slug)
        $data = GetFakeSensorData $device  $alert | ConvertTo-Json
        $headers = @{
            "Authorization" = "Bearer $($device.Token)"
        }
        $response = Invoke-RestMethod -Uri $uri.Uri.AbsoluteUri -Method Post -Body $data -ContentType 'application/json' -Headers $headers
        write-host $response
    }
}

Function GetFakeSensorData {
    Param(
        [Parameter(Mandatory = $true)][Device]$device,
        [Parameter()][bool]$alert = $false
    )
    Process {
        $minCO = If ($alert) { 9 } Else { 0 }
        $data = @{
            SerialNumber   = $device.SerialNumber
            SensorReadings = (@{
                    Time         = Get-Date ([datetime]::UtcNow) -UFormat %Y-%m-%dT%H:%M:%S
                    Temperature  = Get-Random -Minimum -50 -Maximum 50
                    Humidity     = Get-Random -Minimum 0 -Maximum 100
                    COLevel      = Get-Random -Minimum $minCO -Maximum 12
                    HealthStatus = "This is a status"
                })
        }
        $data 
    }
}

Function HoldUp {
    Write-Host "Press any key to continue..."
    $Host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
}

#-----------------------------------------------------------
#               Function Declarations
#-----------------------------------------------------------

$devices = LoadDevices


Register-Device $devices[0]

SubmitSensorData $devices[0]

Register-Device $devices[1]
SubmitSensorData $devices[0] -wait $false

SubmitSensorData $devices[1] $true

Write-Host "Entering Loop..."
HoldUp

$gap = 60 / $devices.Count
$i = 0
$timeout = New-TimeSpan -Minutes 10
$sw = [Diagnostics.StopWatch]::StartNew()
while ($sw.Elapsed -lt $timeout) {
    $i = $i % $devices.Count
    SubmitSensorData $devices[$i] (Get-Random -InputObject ([bool]$true, [bool]$false)) $false
    $i++
    Start-Sleep -Seconds $gap
}