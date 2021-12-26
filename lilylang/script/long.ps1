add-type -AssemblyName System.Runtime

[System.IO.File]::WriteAllText((split-path -path ($MyInvocation.MyCommand.Path) -Parent) + "\long.lps", "")

[System.Collections.Generic.List[string]] $things = [System.Collections.Generic.List[string]]::new()

for ($i = 0; $i -le [uint16]::MaxValue; $i++)
{
    $things.Add("Print `"Hello, world!`";")
    [System.Console]::WriteLine("Added " + $i.ToString() + " of " + [uint16]::MaxValue.ToString() + " (" + (($i / [uint16]::MaxValue) * 100).ToString() + "%)")
    #[System.Console]::SetCursorPosition([System.Console]::CursorLeft, [System.Console]::CursorTop - 1)
}

[System.IO.File]::WriteAllLines((split-path -path ($MyInvocation.MyCommand.Path) -Parent) + "\long.lps", $things.ToArray())