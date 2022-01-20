Imports System.IO

''' <summary>
''' Coco preprocessing interpreter module.
''' </summary>
Partial Public Module Interpreter

    ''' <summary>
    ''' The current file.
    ''' </summary>
    Public CurrentFile As String

    ''' <summary>
    ''' Loads the source file into the current consummate file.
    ''' </summary>
    ''' <param name="filepath">The path to the file.</param>
    Public Sub LoadFile(filepath As String)
        If File.Exists(filepath) Then

        End If
    End Sub
End Module
