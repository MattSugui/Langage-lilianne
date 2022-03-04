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
    <#
    [Parameter(Mandatory = $false)]
    [switch] $VisualBasicProj,
    #>
    [Parameter(Mandatory = $true)]
    [int] $ProjectType,
    [Parameter(Mandatory = $true)]
    [bool] $IsRelease,
    [Parameter(Mandatory = $true)]
    [int] $Platform,
    [Parameter(Mandatory = $false)]
    [string] $CopyExecToThisProject,
    [Parameter(Mandatory = $false)]
    [switch] $CheckIfOverflowing
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

    #[System.Windows.Forms.MessageBox]::Show($fpath, "Check if avail!")

    $filematches = $null
    if ([System.IO.File]::Exists($fpath) -ne $true) { throw [System.IO.FileNotFoundException]::new("The project file doesn't exist.") }
    
    $filecont = [System.IO.File]::ReadAllText($fpath)

    if ($Pre.IsPresent)
    {
        write-host "Evènements avant construction - mise à jour des dates"
        $filematch = [System.Text.RegularExpressions.Regex]::Match($filecont, "\<InformationalVersion\>(?<stage>[^\/\?\<\>\\\:\*\|`"]+)\s(?<stamp>[0-9]{6}-[0-9]{4})\<\/InformationalVersion\>")
        $currdate = [DateTime]::Now.ToString("yyMMdd-HHmm")
        $stage = ""
        if (![string]::IsNullOrWhiteSpace($NewVerName)) { $stage = $NewVerName } else { $stage = $filematch.Groups["stage"].Value }
        $filecont = [System.Text.RegularExpressions.Regex]::Replace($filecont, "\<InformationalVersion\>(?<stage>[^\/\?\<\>\\\:\*\|`"]+)\s(?<stamp>[0-9]{6}-[0-9]{4})\<\/InformationalVersion\>", [string]::Format("<InformationalVersion>{0} {1}</InformationalVersion>", $stage, $currdate))
        [System.IO.File]::WriteAllText($fpath, $filecont)
    }
    elseif ($IncrementBuild.IsPresent)
    {
        write-host "Evènements après construction - mise à jour des numéros de version pour la compilation suivante et l'archivage de l'application"
        $filematches = [System.Text.RegularExpressions.Regex]::Matches($filecont, "[0-9]+\.[0-9]+\.([0-9]+\.[0-9]+|\*)")
        $futureinfo = [System.Text.RegularExpressions.Regex]::Match($filecont, "\<InformationalVersion\>(?<stage>[^\/\?\<\>\\\:\*\|`"]+)\s(?<stamp>[0-9]{6}-[0-9]{4})\<\/InformationalVersion\>")

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
        if ($BigUpgrade.IsPresent) { $vernums[0]++; $vernums[1] = 0 } elseif ($SmallUpgrade.IsPresent) { $vernums[1]++ }

        #write-host $vernums

        $filecont = [System.Text.RegularExpressions.Regex]::Replace($filecont, "[0-9]+\.[0-9]+\.([0-9]+\.[0-9]+|\*)", [string]::Format("{0}.{1}.{2}.{3}", $vernums[0], $vernums[1], $vernums[2], $vernums[3]))
        
        # if present, clear any evidence of a name update for future builds for ease of use so i dont have to fucking do it myself
        $filecont = [System.Text.RegularExpressions.Regex]::Replace($filecont, "\s*-NewVerName\s*'.*'\s*", [string]::Empty)
        $filecont = [System.Text.RegularExpressions.Regex]::Replace($filecont, "\s*-SmallUpgrade\s*", [string]::Empty)
        $filecont = [System.Text.RegularExpressions.Regex]::Replace($filecont, "\s*-BigUpgrade\s*", [string]::Empty)

        # save
        [System.IO.File]::WriteAllText($fpath, $filecont)

        # copying files to place in archive

        $archivepath = $pathpart2 + "\archive\"
        if ([System.IO.File]::Exists($archivepath) -ne $true) { [System.IO.Directory]::CreateDirectory($archivepath) }

        $plat = "\net6.0\"
        switch ($Platform)
        {
            0 { $plat = "\net6.0\"; break}
            1 { $plat = "\net6.0-windows\"; break }
            2 { $plat = "\net6.0-macos\"; break }
            3 { $plat = "\net6.0-android\"; break }
            4 { $plat = "\net6.0-ios\"; break }
            5 { $plat = "\net6.0-maccatalyst\"; break }
            6 { $plat = "\net6.0-tvos\"; break }
            default { $plat = "\net6.0\" } 
        }

        $outpath = $pathpart2 + "\bin\"+ $(if ($IsRelease) {"Release"} else {"Debug"}) + $plat
        #cd $archivepath; dir $archivepath
        
        $dossier = $archivepath + [string]::Format("{0}.{1}", $vernums[0], $vernums[1])
        if ([System.IO.File]::Exists($dossier) -ne $true) { [System.IO.Directory]::CreateDirectory($dossier) }

        # lilylang\archive\0.1\0.1.2.3, 4, 5(.zip)
        $newdest = $dossier + "\" + [string]::Format("{0}.{1}.{2}.{3}, {4}, {5}", $vernums[0], $vernums[1], $vernums[2], $vernums[3], $futureinfo.Groups["stage"], $futureinfo.Groups["stamp"])
        $yo = $newdest + ".zip"

        [System.IO.Directory]::CreateDirectory($newdest)
        copy-item -path ($outpath + "*") -destination $newdest

        compress-archive -path ($newdest + "\*") -destinationpath $yo

        $size = (get-item -path $yo).Length # unused if not stared at

        #[System.Windows.Forms.MessageBox]::Show($newdest)
        remove-item $newdest -recurse -force

        #write-host $CheckIfOverflowing.IsPresent

        if ($CheckIfOverflowing.IsPresent)
        {
            $stuffs = (get-childitem $dossier -recurse | measure-object -sum Length).Sum
            $drivespace = (get-volume (get-item $dossier).PSDrive.Name).SizeRemaining + $stuffs
            $ratio = $stuffs / $drivespace
            $restant = 0
            while ($a -lt ($drivespace - $stuffs)) { $restant++ }
            write-host "Approximativement $($restant) recordes restante avec la même taille et votre condition actuelle. Allons-y !"
            # gets the ratio. e.g., 24 / 1024. The ratio is 3:128, or 2%. It's unnoticeable. 100 / 768 = 25:192, or 13%. Now we're getting somewhere.
            if ($ratio -ge 0.5) { write-host "RECOMMANDATION : L'archive est devenant gros ! (Le rapport est $($stuffs / 1mb) Mo d'éspace utilisé par l'archive : $($drivespace / 1mb) Mo d'éspace libre) Vous pouvez avoir le besoin de deplacer l'archive à ailleurs." }
        }
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
    write-host $PSItem.Exception.ToString()
}