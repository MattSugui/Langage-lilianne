param
(
    [Parameter(Mandatory = $false)]
    [switch] $TimeIt,
    [Parameter(Mandatory = $true)]
    [double] $Duration
)

add-type -AssemblyName System.Runtime

function InOneSecond
{
    $i = 0
    $watch.Start()
    do
    {
        $i++
        write-host $i    
    }
    until ($watch.ElapsedMilliseconds -eq 1000)
    $watch.Stop()
}

function MillionLines
{
    $etaget = [System.Diagnostics.Stopwatch]::new()
    $j = $Duration
    $k = 0; $l = 0
    $watch.Start()
    $etaget.Start()
    write-host lmao pls wait...
    do
    {
        $i++
        $l = ($i / $j) * 100
        $o = [uint64]::Parse((($etaget.Elapsed.Seconds / $i) * ($j - $i)).ToString("0"))
        $p = [uint64]::Parse((($i / $j) * 100).ToString("0"))
        Write-Progress -Activity "Counting to $j" -Status $i.ToString() -SecondsRemaining $o -PercentComplete $p
    }
    until ($i -eq $j)
    $watch.Stop()
    write-host ("`nIn " + $watch.Elapsed.Seconds.ToString() + " seconds, " + $j)
}

$watch = [System.Diagnostics.Stopwatch]::new()

if ($TimeIt.IsPresent) {InOneSecond} else {MillionLines}