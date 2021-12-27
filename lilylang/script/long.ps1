add-type -AssemblyName System.Runtime

[System.IO.File]::WriteAllText((split-path -path ($MyInvocation.MyCommand.Path) -Parent) + "\long.lps", "")

[System.Collections.Generic.List[string]] $things = [System.Collections.Generic.List[string]]::new()
$etaget = [System.Diagnostics.Stopwatch]::new()

$j = 875
$k = 0; $l = 0
$etaget.Start()
for ($i = 1; $i -le $j + 1; $i++)
{
    $things.Add("Print `"Hello, world!`";")
    #[System.Console]::WriteLine(+ " (" + (($i / [uint16]::MaxValue) * 100).ToString() + "%)")
    $o = [uint64]::Parse((($etaget.Elapsed.Seconds / $i) * ($j - $i)).ToString("0"))
    $p = [uint64]::Parse((($i / $j) * 100).ToString("0"))
    Write-Progress -Activity ("Added " + $i.ToString() + " of " + $j) -Status $i.ToString() -SecondsRemaining $o -PercentComplete $p
    #[System.Console]::SetCursorPosition([System.Console]::CursorLeft, [System.Console]::CursorTop - 1)
}

[System.IO.File]::WriteAllLines((split-path -path ($MyInvocation.MyCommand.Path) -Parent) + "\long.lps", $things.ToArray())