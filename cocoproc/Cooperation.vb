Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Reflection
Imports System.IO
Imports System.IO.MemoryMappedFiles
Imports System.Diagnostics

Public Module Cooperation
    Public Commons As MemoryMappedFile

    Public Sub Handshake()
        Try
            Commons = MemoryMappedFile.OpenExisting("C:\lilycoco.tmp")
            Dim mutex1 As Mutex = Mutex.OpenExisting("liliancommune")
            mutex1.WaitOne()

            Using stream As MemoryMappedViewStream = Commons.CreateViewStream()
                Dim pen As New BinaryWriter(stream)
                pen.Write(True)
            End Using
            mutex1.ReleaseMutex()

        Catch ex As Exception
            Throw New Lamentation(3, ex.Message)
        End Try
    End Sub
End Module