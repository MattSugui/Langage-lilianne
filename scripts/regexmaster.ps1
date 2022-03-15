<#
    Offline regex checker
    Matt Sugui, 2022
#>

add-type -assemblyname System.Runtime
add-type -assemblyname System.Windows.Forms

class Form1: System.Windows.Forms.Form
{
    Form1()
    {
        $this.InitialiseComponent()
    }

    InitialiseComponent()
    {
        $this.AutoScaleMode = [System.Windows.Forms.AutoScaleMode]::Font
        $this.ClientSize = [System.Drawing.Size]::new(800, 450)
        $this.Text = "Form1"
    }
}

[System.Windows.Forms.Application]::EnableVisualStyles()
[System.Windows.Forms.Application]::SetCompatibleTextRenderingDefault($false)
[System.Windows.Forms.Application]::Run([Form1]::new())
