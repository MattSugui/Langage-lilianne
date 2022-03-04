#Region "Informations"
'* Open to see credits And info about this source code file *
'╔══════════════════════════════════════════════════════════════════════════════════════════════════╗
'║   ╭╮╭╮                                                                                           ║
'║  (0_0) ... was that the bite of 87!                                                              ║
'╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
'║ Fonder Lilian Language Interpreter 1.2                                                           ║
'║ Coco Module                                                                                      ║
'║ Built upon the .NET 6 Common Language Infrastructure by Microsoft                                ║
'║                                                                                                  ║
'║ Maintained 2019-2022 Matt Adrian P Sugui. Released under the GPU 3.0 General Public Licence.     ║
'╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
'║ Visual Basic, .NET, Visual Studio and all related titles and subjects are registered trademarks  ║
'║ of Microsoft Corporation.                                                                        ║
'╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
'║ The minimum version of VB you can use is 16.0.                                                   ║
'╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
'║ This program is free software: you can redistribute it and/or modify it under the terms of the   ║
'║ GNU General Public License as published by the Free Software Foundation, either version 3 of the ║
'║ License, or (at your option) any later version.                                                  ║
'║                                                                                                  ║
'║ This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without║
'║ even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU    ║
'║ General Public License for more details.                                                         ║
'║                                                                                                  ║
'║ https://www.gnu.org/licenses/                                                                    ║
'╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
'║ ╭│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─╮ ║
'║ │ Hello, viewer of this source code!                                                           │ ║
'║ │                                                                                              │ ║
'║ │     I have compressed my damned project into just one code file that can cause multiple      │ ║
'║ │ performance issues for whoever has the balls to load this file in a laptop that's running at │ ║
'║ │ a very, very measly 1 billion hertz, also known as 1 GHz and the speed of latter-day PC      │ ║
'║ │ toasters. This is for portability and easy redistribution of this open-source project.       │ ║
'║ │                                                                                              │ ║
'║ │     This project is named after the famous Animal Crossing™ bunny character named, well,     │ ║
'║ │ Coco. Ayo, Nintendo, I'm not stealing that name! In fact, it is a common name, so            │ ║
'║ │ essentially putting a trademark on it is ridiculous anyway lmao.                             │ ║
'║ │                                                                                              │ ║
'║ │     The way it interprets stuff is in the LILYHELP PDF in the final product. Or, if you do   │ ║
'║ │ not have that or just stumbled upon this for some reason, read the damn thing. You're probs  │ ║
'║ │ advanced enough to interpret these weird problematic statements. Especially this one. This   │ ║
'║ │ is already in English so I don't know how you would mix shit up in this bich.                │ ║
'║ │                                                                                              │ ║
'║ │     So, yeah. I hope you'll understand the li'l XML doc comments and other shit I've placed  │ ║
'║ │ in this single-file interpreter source code! Well, if your PC doesn't crash already from     │ ║
'║ │ loading this thousand-line file. Look...it even fits in your 5.25" floppy...                 │ ║
'║ │                                                                                              │ ║
'║ │                                                                                              │ ║
'║ │                                                                                              │ ║
'║ │                                                                   Sincerely made with love,  │ ║
'║ │                                                                                        Matt  │ ║
'║ │                                                                                              │ ║
'║ │                                                           P.S. I'm not gay. But Villager is. │ ║
'║ ╰──────────────────────────────────────────────────────────────────────────────────────────────╯ ║
'╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
'║ More trolls mean more idiots you stupid fucking cunt                                             ║
'║ Size goal: IBM 23FD (17/80 kB)                                                                   ║
'╚══════════════════════════════════════════════════════════════════════════════════════════════════╝
#End Region

#Region "Warning suppressions"
' rants by the quality checker
#Disable Warning CA2211 ' ayo! fields aint supposed To be public!
#End Region

#Region "Imports"
' corlibs
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Reflection
Imports System.IO
Imports System.Diagnostics
Imports System.Xml
Imports System.Xml.Serialization
#End Region


#Region "Programme"
''' <summary>
''' The main flow.
''' </summary>
Public Module Programme
    ''' <summary>
    ''' The main entry point.
    ''' </summary>
    ''' <param name="args">The command-line arguments.</param>
    Public Sub Main(args As String())
        If File.Exists("coco.gift") Then ' assumes that the 0th argument is a filepath
            ReadFile(File.ReadAllLines("coco.gift"))
#If DEBUG Then
            Thread.Sleep(2500)
            Console.WriteLine("Reading shit")
#End If
            Interpret(CurrentFile)
#If DEBUG Then
            Thread.Sleep(2500)
            Console.WriteLine(String.Join("'"c, OutputFile.ToArray()))
#End If

            ExportFile()
#If DEBUG Then
            Thread.Sleep(2500)
            Console.WriteLine("Exportation")
#End If
            Console.WriteLine(String.Join(Environment.NewLine, File.ReadAllLines("cocotmp.pcp")))
            Environment.Exit(0)
        Else
            Console.WriteLine("Please input an actual CCN file.")
        End If
    End Sub
End Module
#End Region
#Region "Interpreter"
''' <summary>
''' The main class for the interpeter.
''' </summary>
Public Module Interpreter
#Region "Interpretation"
    ''' <summary>
    ''' The current file.
    ''' </summary>
    Public CurrentFile As List(Of String)

    ''' <summary>
    ''' The resulting project.
    ''' </summary>
    Public OutputFile As List(Of String)

    ''' <summary>
    ''' Loads in the file.
    ''' </summary>
    ''' <param name="input">The entire file.</param>
    Public Sub ReadFile(input As String())
        For Each line As String In input
            CurrentFile.Add(line)
        Next
    End Sub

    ''' <summary>
    ''' Interprets the entire file.
    ''' </summary>
    ''' <param name="input">The entire file.</param>
    Public Sub Interpret(input As List(Of String))
        Dim AlreadyVersioned As Boolean = False
        Dim InProject As Boolean = False
        Dim AlreadyProjected As Boolean = False

        For Each Line As String In input
            If Regex.IsMatch(Line, "Use\s+(Version\s+(?<MajorVersion>[0-9]+)\.(?<MinorVersion>[0-9]+)(\.(?<Build>[0-9]+)\.(?<Revision>[0-9]+))?)") Then
                If Not AlreadyVersioned Then
                    Dim result As Match = Regex.Match(Line, "Use\s+(Version\s+(?<MajorVersion>[0-9]+)\.(?<MinorVersion>[0-9]+)(\.(?<Build>[0-9]+)\.(?<Revision>[0-9]+))?)")
                    Dim prelim As Match = Regex.Match(Line, "Use\s+(Version\s+(?<MajorVersion>[0-9]+)\.(?<MinorVersion>[0-9]+))")
                    AlreadyVersioned = True
                    Dim Maj, Min As Integer
                    Dim HasBuild As Boolean = False
                    Dim Build, Rev As Integer
                    Maj = Integer.Parse(prelim.Groups("MajorVersion").Value)
                    Min = Integer.Parse(prelim.Groups("MinorVersion").Value)
                    If Regex.IsMatch(Line, "Use\s+(Version\s+(?<MajorVersion>[0-9]+)\.(?<MinorVersion>[0-9]+)\.(?<Build>[0-9]+)\.(?<Revision>[0-9]+))") Then
                        Dim sec As Match = Regex.Match(Line, "Use\s+(Version\s+(?<MajorVersion>[0-9]+)\.(?<MinorVersion>[0-9]+)\.(?<Build>[0-9]+)\.(?<Revision>[0-9]+))")
                        Build = Integer.Parse(sec.Groups("Build").Value)
                        Rev = Integer.Parse(sec.Groups("Revision").Value)
                        HasBuild = True
                    End If

                    Dim CurrVersion As Version = Assembly.GetExecutingAssembly().GetName().Version

                    If CurrVersion.Major < Maj OrElse CurrVersion.Minor < Min Then
                        If HasBuild AndAlso (CurrVersion.Build < Build OrElse CurrVersion.Revision < Rev) Then
                            Throw New Lamentation(11, $"{CurrVersion.Major}.{CurrVersion.Minor}.{CurrVersion.Build}.{CurrVersion.Revision}")
                        Else
                            Throw New Lamentation(10, $"{CurrVersion.Major}.{CurrVersion.Minor}")
                        End If
                    End If
                    OutputFile.Add($"Using version {Maj}.{Min}.{Build}.{Rev}!")
                    Continue For
                Else
                    Throw New Lamentation(7)
                End If
            ElseIf Regex.IsMatch(Line, "Project\s+""(?<Name>[^""\r\n]*)""") Then
                If Not InProject Then
                    If Not AlreadyProjected Then
                        InProject = True
                        OutputFile.Add($"a proj")
                    Else
                        Throw New Lamentation(8)
                    End If
                Else
                    Throw New Lamentation(9)
                End If
            End If
        Next
    End Sub

    ''' <summary>
    ''' Writes the project to disk.
    ''' </summary>
    ''' <param name="Path">The path to the result. By default it just creates a temp file instead.</param>
    Public Sub ExportFile(Optional Path As String = "cocotmp.pcp")
        File.WriteAllLines(Path, OutputFile.ToArray())
    End Sub
#End Region
#Region "Lamentation"
    ''' <summary>
    ''' A compiler error to Coco.
    ''' </summary>
    Public Class Lamentation
        Inherits Exception

        ''' <summary>
        ''' Initialises the standard error code-string pairs for a lamentation.
        ''' </summary>
        Shared Sub New()
            err = New Dictionary(Of Integer, String) From {
                {0, "Invalid state for the environment. If you don't know what happened, it's my fault. Contact ininemsn@gmail.com"},
                {1, "Syntax error. This command does not exist. You typed in: {0}, and I don't know shit about it"},
                {2, "The file {0} does not exist."},
                {3, "Handshake with Lilian failed. {0}"},
                {4, "Invalid operation in handshake. {0}"},
                {5, "Implementation error. This command does not exist. You typed in: {0}, and I don't know shit about it"},
                {6, "aYO wat the fuk! Lamentation no. {0} does not exist!!!"},
                {7, "Compiler version already determined - cannot use a different version within the same file."},
                {8, "Project already defined - use a different file for a different project, or use the solution syntax."},
                {9, "Project already in definition."},
                {10, "Compiler version as determined is too high for the current compiler. Use version {0}."},
                {11, "Compiler version as determined is too high for the current compiler. Use build {0}."},
                {12, "Compiler version as determined is too low for the current compiler. Some features are unavailable in this version. Reformat the program or install the older version."}
            }
        End Sub

        ''' <summary>
        ''' Initialises a new instance of the Lamentation class.
        ''' </summary>
        Public Sub New()
            Message = err(0)
            ErrorCode = 0
        End Sub

        ''' <summary>
        ''' Initialises a new instance of the Lamentation class with a specified error message.
        ''' </summary>
        ''' <param name="msg">The error message.</param>
        Public Sub New(msg As String)
            Message = msg
        End Sub

        ''' <summary>
        ''' Initialises a new instance of the Lamentation class with a specified error message and error code.
        ''' </summary>
        ''' <param name="msg">The error message.</param>
        ''' <param name="err">The error code.</param>
        Public Sub New(msg As String, err As Integer)
            Message = msg
            ErrorCode = err
        End Sub

        ''' <summary>
        ''' Initialises a new instance of the Lamentation class with a specified error code. The constructor
        ''' will check for a code-message pair to find that error. Else, throw a Lamentation, whilst creating
        ''' one.
        ''' </summary>
        ''' <param name="errc">The error code.</param>
        Public Sub New(errc As Integer)
            If err.ContainsKey(errc) Then
                Message = err(errc)
                ErrorCode = errc
            Else
                Throw New Lamentation(6, errc.ToString())
            End If
        End Sub

        ''' <summary>
        '''  Initialises a new instance of the Lamentation class with a specified error code and appropriate
        ''' data such as line numbers or current tokens. The constructor will check for a code-message pair
        ''' to find that error. Else, throw a Lamentation, whilst creating one.
        ''' </summary>
        ''' <param name="errc">The error code.</param>
        ''' <param name="data">Related data such as line numbers or current tokens.</param>
        Public Sub New(errc As Integer, ParamArray data As String())
            If err.ContainsKey(errc) Then
                Message = String.Format(err(errc), data)
                ErrorCode = errc
            Else
                Throw New Lamentation(6, errc.ToString())
            End If
        End Sub


        ''' <summary>
        ''' Gets a message that describes the current lamentation.
        ''' </summary>
        ''' <returns>A message that describes the current lamentation.</returns>
        Public Overrides ReadOnly Property Message As String

        ''' <summary>
        ''' Gets the error code of the lamentation.
        ''' </summary>
        ''' <returns>The error code of the lamentation.</returns>
        Public ReadOnly Property ErrorCode As Integer

        ''' <summary>
        ''' An internal dictionary for getting a code-message pair.
        ''' </summary>
        Private Shared ReadOnly err As Dictionary(Of Integer, String)

        ''' <summary>
        ''' Creates and returns a string representation of the current lamentation.
        ''' </summary>
        ''' <returns>A string representation of the current lamentation.</returns>
        Public Overrides Function ToString() As String
            Return String.Format("LP{0:0000}: {1}", ErrorCode, Message)
        End Function
    End Class
#End Region
End Module
#End Region