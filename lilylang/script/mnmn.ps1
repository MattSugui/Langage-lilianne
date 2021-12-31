param
(
    [Parameter(Mandatory = $true)]
    [string] $Expression
)

add-type -AssemblyName System.Runtime

write-host "Générateur des mnémoniques de langage d'assemblage pour Lilian (en anglais)"

$ReturningValue = ""

if ($Expression.Length -le 3) { $ReturningValue = $Expression.ToUpperInvariant() }
elseif ($Expression.Split(' ').Count -ge 3)
{
    $Expression = $Expression.Replace("of ", [string]::Empty)

    $inits = [System.Collections.Generic.List[string]]::new()
    foreach ($thing in $Expression.Split(' '))
    {
        $inits.Add($thing[0])
    }

    foreach ($bruh in $inits)
    {
        $ReturningValue += $bruh.ToUpperInvariant()
    }
}

write-output $ReturningValue

<#
    Guide


    Add => ADD
    Add number => AN
    Add square of number => ASN

    all verbs that end in:
        ate ify ise/ize
    
    and the following verbs:
        do add subtract divide multiply move push pop branch

    are all verbs and will be given further 
#>