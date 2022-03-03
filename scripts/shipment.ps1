<#
    Déplacement d'archive
    Créé en 2022 par Matt Sugui. CC-BY-SA-NC
#>

param
(
    [Parameter(Mandatory = $true)]
    [string] $ProjectName,
    [Parameter(Mandatory = $true)]
    [int] $ProjectType,
    [Parameter(Mandatory = $true)]
    [string] $Output

)

add-type -AssemblyName System.Runtime
add-type -AssemblyName System.Windows.Forms

write-host "Déplacement d'archive" 
write-host "Créé en 2022 par Matt Sugui. CC-BY-SA-NC"

try
{
    $filecont = ""
    $pathpart = get-location -Verbose
    $miscpath = ""
    if ([string]::IsNullOrWhiteSpace($ProjectName) -ne $true) { $miscpath = "\" + $ProjectName } else { throw [System.IO.FileNotFoundException]::new("")}

    $pathpart2 = (split-path -Path $pathpart) + $miscpath
    
    $projtype = -1
    if ([int]::TryParse($ProjectType, [ref] $projtype) -ne $true) { throw [System.InvalidCastException]::new("Invalid character.") }
    $projext = ""
    switch ($projtype)
    {
        0 {$projext = ".csproj"; break}
        1 {$projext = ".vbproj"; break}
        2 {$projext = ".vcxproj"; break}
        default {throw [System.InvalidCastException]::new("Invalid project type.")}
    }

    $fpath = $pathpart2 + "\" + $ProjectName + $projext
    $archivepath = $pathpart2 + "\archive\"

    #[System.Windows.Forms.MessageBox]::Show($fpath, "Check if avail!")

    $filematches = $null
    if ([System.IO.File]::Exists($fpath) -ne $true) { throw [System.IO.FileNotFoundException]::new("The project file doesn't exist.") }

    if ([System.IO.File]::Exists($archivepath) -ne $true) { throw [System.IO.FileNotFoundException]::new("ayo archive's inexistent.") }

    if ([System.IO.Directory]::EnumerateFiles($archivepath, "*.zip", [System.IO.SearchOption]::AllDirectories).Length -eq 0) { throw [System.IO.FileNotFoundException]::new("ayo archive's empty. let's roll out") }

    $outpath = $Output + "\" + $ProjectName

    if ([System.IO.File]::Exists($outpath) -ne $true) { [System.IO.Directory]::CreateDirectory($outpath) }

    copy-item -path ($archivepath + "*") -destination $outpath
    remove-item -path $archivepath
    mkdir $archivepath # bruh
}
catch [System.Exception]
{
    Write-host $PSItem.Exception.ToString()
}