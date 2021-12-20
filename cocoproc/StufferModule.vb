Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports System.Drawing

Partial Public Module Interpreter
    Public Class Library
        Public Property Name As String

        Public Property CodeSection As String

        Private imgs As List(Of String)
        Public Property ImageFiles As List(Of String)
            Get
                Return imgs
            End Get
            Set(value As List(Of String))
                imgs = value
            End Set
        End Property

        Private majVer As Integer
        Private minVer As Integer
        Private build As Integer
        Private revision As Integer
        Private buildTag As String
        Public Property Version As (Integer, Integer, Integer, Integer, String)
            Get
                Return (majVer, minVer, build, revision, buildTag)
            End Get
            Set(value As (Integer, Integer, Integer, Integer, String))
                majVer = value.Item1
                minVer = value.Item2
                build = value.Item3
                revision = value.Item4
                buildTag = value.Item5
            End Set
        End Property

        Public Sub AddToImages(Path As String)
            If File.Exists(Path) Then
                imgs.Add(Convert.ToBase64String(File.ReadAllBytes(Path)))
            Else Throw New Lamentation("Cannot add resource to the list. Path does not exist: " & Path, 7546) : End If
        End Sub

        Default Public ReadOnly Property Item(index As Integer) As Bitmap
            Get
                Dim ReturningValue As Bitmap = Nothing
                Dim Buffer As Byte() = Convert.FromBase64String(imgs(index))
                Using MemStream As New MemoryStream(Buffer)
                    MemStream.Position = 0
                    ReturningValue = CType(Bitmap.FromStream(MemStream), Bitmap)
                End Using
                Return ReturningValue
            End Get
        End Property
    End Class

    Public Sub Stuff(Thing As Byte(), Optional Path As String = "package.lfb", Optional Title As String = "")
        Try
            Using Quill As New BinaryWriter(File.Open(Path, FileMode.Create))
                Console.WriteLine("Writing the header of the archive.")
                With Quill
                    .Write(Title)
                    .Write(Thing.Length)
                    .Write(Thing)
                End With
            End Using
        Catch ex As Exception
            Throw New Lamentation($"Error compiling archive: {vbCrLf} {ex}", 2352)
            Exit Sub
        End Try

        Crumple(Path)
    End Sub

    Public Function Unbox(Path As String) As Byte()
        Dim Amount As Integer
        Dim ReturningValue As Byte() = Nothing
        Try
            If File.Exists(Path) Then
                Using Lectern As New BinaryReader(File.Open(Path, FileMode.Open))
                    With Lectern
                        Console.WriteLine($"Testing archive ""{ .ReadString()}""")
                        Amount = .ReadInt32()
                        ReturningValue = .ReadBytes(Amount)
                    End With
                End Using
            Else Throw New FileNotFoundException("bruh") : End If
        Catch ex As Exception
            Throw New Lamentation($"Error opening archive: {vbCrLf} {ex}", 2353)
        End Try
        Return ReturningValue
    End Function

    Public Function Unbox(Contents As Stream) As Byte()
        Dim Amount As Integer
        Dim ReturningValue As Byte() = Nothing
        Try
            Using Lectern As New BinaryReader(Contents)
                With Lectern
                    Console.WriteLine($"Testing archive ""{ .ReadString()}""")
                    Amount = .ReadInt32()
                    ReturningValue = .ReadBytes(Amount)
                End With
            End Using
        Catch ex As Exception
            Throw New Lamentation($"Error opening archive: {vbCrLf} {ex}", 2353)
        End Try
        Return ReturningValue
    End Function

    Public Function GetCode(Thing As Byte()) As String
        Return Encoding.Default.GetString(Thing)
    End Function

    Public Sub Crumple(Path As String)
        Try
            If File.Exists(Path) Then
                Dim Output As FileStream = File.Create(Path.Replace(".lfb", ".lpe"))
                Dim Input As FileStream = File.OpenRead(Path)
                Using Crumpler As New GZipStream(Output, CompressionMode.Compress)
                    Input.CopyTo(Crumpler)
                End Using
            Else Throw New FileNotFoundException("bruh") : End If
        Catch ex As Exception
            Throw New Lamentation($"Error trimming archive: {vbCrLf} {ex}", 2353)
        End Try
    End Sub

    Public Sub Uncrumple(Path As String)
        Dim ReturningValue As MemoryStream = Nothing
        Try
            If File.Exists(Path) Then
                Using Restorer As New GZipStream(ReturningValue, CompressionMode.Decompress)
                    ReturningValue.CopyTo(Restorer)
                End Using
            Else Throw New FileNotFoundException("bruh") : End If
        Catch ex As Exception
            Throw New Lamentation($"Error reconstructing archive: {vbCrLf} {ex}", 2353)
            Exit Sub
        End Try

        Unbox(ReturningValue)
    End Sub
End Module
