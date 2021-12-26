add-type -AssemblyName System.Windows.Forms

[System.Windows.Forms.Form] $newform = [System.Windows.Forms.Form]::new()

$newform.Show()