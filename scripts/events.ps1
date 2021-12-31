<#
    Evènements pour la compilation - increments de numéro de vérsion,
    l'archivage des apps et la contrôle du source

    Créé en 2021 par Matt Sugui
#>

param
(
    [Parameter(Mandatory = $false)]
    [switch] $Pre,
    [Parameter(Mandatory = $false)]
    [switch] $IncrementBuild,
    [Parameter(Mandatory = $false)]
    [switch] $BigUpgrade,
    [Parameter(Mandatory = $false)]
    [switch] $SmallUpgrade,
    [Parameter(Mandatory = $false)]
    [string] $NewVerName,
    [Parameter(Mandatory = $false)]
    [switch] $Copy,
    <#
    [Parameter(Mandatory = $false)]
    [switch] $GoDeeper,
    #>
    [Parameter(Mandatory = $true)]
    [string] $ProjectName,
    [Parameter(Mandatory = $false)]
    [switch] $VisualBasicProj,
    [Parameter(Mandatory = $true)]
    [bool] $IsRelease,
    [Parameter(Mandatory = $false)]
    [string] $CopyExecToThisProject
)

add-type -AssemblyName System.Runtime
add-type -AssemblyName System.Windows.Forms

write-host "Evènements pour la compilation" 
write-host "Créé en 2021 par Matt Sugui. CC-BY-SA-NC"

try
{   
    $filecont = ""
    $pathpart = get-location -Verbose
    $miscpath = ""
    if ([string]::IsNullOrWhiteSpace($ProjectName) -ne $true) { $miscpath = "\" + $ProjectName }

    $pathpart2 = (split-path -Path $pathpart) + $miscpath
    
    [string] $fpath = $pathpart2 + "\" + $ProjectName + $(if ($VisualBasicProj.IsPresent) {".vbproj"} else {".csproj"})

    #[System.Windows.Forms.MessageBox]::Show($fpath, "Check if avail!")

    $filematches = $null
    if ([System.IO.File]::Exists($fpath) -ne $true) { throw [System.IO.FileNotFoundException]::new("The project file doesn't exist.") }
    
    $filecont = [System.IO.File]::ReadAllText($fpath)

    if ($Pre.IsPresent)
    {
        write-host "Evènements avant construction - mise à jour des dates"
        $filematch = [System.Text.RegularExpressions.Regex]::Match($filecont, "\<InformationalVersion\>(?<stage>[0-9A-Za-z\s]+)\s(?<stamp>[0-9]{6}-[0-9]{4})\<\/InformationalVersion\>")
        $currdate = [DateTime]::Now.ToString("yyMMdd-HHmm")
        $stage = ""
        if (![string]::IsNullOrWhiteSpace($NewVerName)) { $stage = $NewVerName } else { $stage = $filematch.Groups["stage"].Value }
        $filecont = [System.Text.RegularExpressions.Regex]::Replace($filecont, "\<InformationalVersion\>(?<stage>[0-9A-Za-z\s]+)\s(?<stamp>[0-9]{6}-[0-9]{4})\<\/InformationalVersion\>", [string]::Format("<InformationalVersion>{0} {1}</InformationalVersion>", $stage, $currdate))
        [System.IO.File]::WriteAllText($fpath, $filecont)
    }
    elseif ($IncrementBuild.IsPresent)
    {
        write-host "Evènements après construction - mise à jour des numéros de version pour la compilation suivante et l'archivage de l'application"
        $filematches = [System.Text.RegularExpressions.Regex]::Matches($filecont, "[0-9]+\.[0-9]+\.([0-9]+\.[0-9]+|\*)")
        $futureinfo = [System.Text.RegularExpressions.Regex]::Match($filecont, "\<InformationalVersion\>(?<stage>[0-9A-Za-z\s]+)\s(?<stamp>[0-9]{6}-[0-9]{4})\<\/InformationalVersion\>")

        $asmver = [System.Collections.Generic.List[string]]::new($filematches[0].Value.Split('.'))
        $filever = $filematches[1].Value.Split('.')

        if ($asmver[2] -eq "*")
        {
            $filecont = [System.Text.RegularExpressions.Regex]::Replace($filecont, "[0-9]+\.[0-9]+\.\*", [string]::Format("{0}.{1}.{2}.{3}", $filever[0], $filever[1], $filever[2],$filever[3]))
            $filematches = [System.Text.RegularExpressions.Regex]::Matches($filecont, "[0-9]+\.[0-9]+\.([0-9]+\.[0-9]+|\*)")

            $asmver = $filematches[0].Value.Split('.')
        }

        $vernums = @(0,0,0,0)

        for ($i = 0; $i -lt $filever.Count; $i++) { $vernums[$i] = [int]::Parse($asmver[$i]) }
        
        $vernums[2]++
        if ($BigUpgrade.IsPresent) { $vernums[0]++ } elseif ($SmallUpgrade.IsPresent) { $vernums[1]++ }

        #write-host $vernums

        $filecont = [System.Text.RegularExpressions.Regex]::Replace($filecont, "[0-9]+\.[0-9]+\.([0-9]+\.[0-9]+|\*)", [string]::Format("{0}.{1}.{2}.{3}", $vernums[0], $vernums[1], $vernums[2], $vernums[3]))
        [System.IO.File]::WriteAllText($fpath, $filecont)
        

        # copying files to place in archive

        $archivepath = $pathpart2 + "\archive\"
        if ([System.IO.File]::Exists($archivepath) -ne $true) { [System.IO.Directory]::CreateDirectory($archivepath) }

        $outpath = $pathpart2 + "\bin\"+ $(if ($IsRelease) {"Release"} else {"Debug"}) +"\net6.0\"
        #cd $archivepath; dir $archivepath
        
        $dossier = $archivepath + [string]::Format("{0}.{1}", $vernums[0], $vernums[1])
        if ([System.IO.File]::Exists($dossier) -ne $true) { [System.IO.Directory]::CreateDirectory($dossier) }

        # lilylang\archive\0.1\0.1.2.3, 4, 5(.zip)
        $newdest = $dossier + "\" + [string]::Format("{0}.{1}.{2}.{3}, {4}, {5}", $vernums[0], $vernums[1], $vernums[2], $vernums[3], $futureinfo.Groups["stage"], $futureinfo.Groups["stamp"])
        $yo = $newdest + ".zip"

        [System.IO.Directory]::CreateDirectory($newdest)
        copy-item -path ($outpath + "*") -destination $newdest

        compress-archive -path ($newdest + "\*") -destinationpath $yo

        if ($CopyExecToThisProject.IsPresent)
        {
            
        }

        [System.Windows.Forms.MessageBox]::Show($newdest)
        remove-item $newdest -recurse -force
    }    
    else
    {
        write-host "Aucun argument correct défini. Utilisez cette moment pour essayer une commande qui pointe à ici pour tous erreurs de référence. Si vous pouvez ce voir, félicitations ! C'est fonctionnant."
    }
}
<# redundant
catch [System.IO.FileNotFoundException]
{
    write-host $PSItem.Exception.Message
}
#>
catch [System.Exception]
{
    Write-host $PSItem.Exception.ToString()
}