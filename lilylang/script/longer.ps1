add-type -AssemblyName System.Runtime

[System.IO.File]::WriteAllText((split-path -path ($MyInvocation.MyCommand.Path) -Parent) + "\nonsense.lps", "")

[System.Collections.Generic.List[string]] $things = [System.Collections.Generic.List[string]]::new()
$etaget = [System.Diagnostics.Stopwatch]::new()

$j = 1024*128
$k = 0; $l = 0
$etaget.Start()
for ($i = 1; $i -le $j + 1; $i++)
{
    $things.Add("// Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec non purus sit amet eros porta ante.")
    $things.Add("take; print; pop; take; print; pop;")
    $things.Add("push `"hello, world!`"; print; pop;")
    $things.Add("push 69; push 420; and; print;")
    $things.Add("push 9; push 10; xor; push 21; and; print; pause 1000;")
    #[System.Console]::WriteLine(+ " (" + (($i / [uint16]::MaxValue) * 100).ToString() + "%)")
    $o = [uint64]::Parse((($etaget.Elapsed.Seconds / $i) * ($j - $i)).ToString("0"))
    $p = [uint64]::Parse((($i / $j) * 100).ToString("0"))
    Write-Progress -Activity ("Added " + $i.ToString() + " of " + $j) -Status $i.ToString() -SecondsRemaining $o -PercentComplete $p
    #[System.Console]::SetCursorPosition([System.Console]::CursorLeft, [System.Console]::CursorTop - 1)
}
$etaget.Stop()

write-host ("Took " + $etaget.Elapsed.ToString())

[System.IO.File]::WriteAllLines((split-path -path ($MyInvocation.MyCommand.Path) -Parent) + "\nonsense.lps", $things.ToArray())