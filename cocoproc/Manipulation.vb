Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Partial Public Module Interpreter
    ' Manipulation time
    ''' <summary>
    ''' Turn a command into a Lilian instance or statement. For schemas, it is the job of the SchemaInterpreter file portion of the <see cref="Interpreter"/> module.
    ''' </summary>
    ''' <param name="text"></param>
    Public Sub Manipulation(text As String)
        EmittedStatements.Add($"print ""{text.Trim(""""c)}"";")
    End Sub

    Public EmittedStatements As New List(Of String)

    ''' <summary>
    ''' Write all proposed mods to disk.
    ''' </summary>
    Public Sub ProposeMods()
        Dim Unconverted As New List(Of ProposedMod)
        Try
            For Each line As String In EmittedStatements
                Unconverted.Add(New ProposedMod() With {.ProposedStatement = line, .WhatToDo = 1})
            Next

            Dim ReturningValue As Byte()

            Dim Formatter As New XmlSerializer(GetType(ProposedMod()))
            Dim Stream As New MemoryStream
            Formatter.Serialize(Stream, Unconverted.ToArray())
            'ReDim ReturningValue(Stream.ToArray().Length)
            ReturningValue = Stream.ToArray()

            Using Pen As New BinaryWriter(New FileStream("cocoadd.tmp", FileMode.Create))
                Pen.Write(ReturningValue.Length)
                Pen.Write(ReturningValue)
            End Using
        Catch e As Exception
            Throw New Lamentation(4, e.Message)
        End Try
    End Sub

    <Serializable> Public Class ProposedMod
        Public ProposedStatement As String
        Public WhatToDo As Integer
    End Class
End Module