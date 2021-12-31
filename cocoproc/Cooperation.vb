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
    Public Sub Handshake()
        Try
            Using Commons As MemoryMappedFile = MemoryMappedFile.OpenExisting("lilycoco")
                Dim mutex1 As Mutex = Mutex.OpenExisting("lilmutex")
                mutex1.WaitOne()

                Using stream As MemoryMappedViewStream = Commons.CreateViewStream(1, 0)
                    Console.WriteLine("Oh, hello, Lilian! I'm Coco!")
                    Dim pen As New BinaryWriter(stream)
                    pen.Write(True)
                End Using
                mutex1.ReleaseMutex()
            End Using
        Catch ex As Exception
            Throw New Lamentation(3, ex.Message)
        End Try
    End Sub
End Module