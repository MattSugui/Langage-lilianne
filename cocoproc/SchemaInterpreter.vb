Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization
Imports System.Text.RegularExpressions

Partial Public Module Interpreter
    REM Schema
    ' 
    Friend Sub Diversion(Line As String)
        If Not String.IsNullOrEmpty(Line) OrElse Not String.IsNullOrWhiteSpace(Line) Then
            For Each Feature As String In FeatureConstants
                If Regex.IsMatch(Line, Feature) Then
                    Select Case Array.IndexOf(FeatureConstants, Feature)
                        Case 0
                    End Select
                    Exit For
                Else
                    If Array.IndexOf(FeatureConstants, Feature) <> FeatureConstants.Length - 1 Then Continue For Else Throw New Lamentation(1, Line)
                End If
            Next
        End If
    End Sub

    Public Sub RegisterToken()

    End Sub


    Public Class Statement
        Implements IXmlSerializable

        Public Sub ReadXml(reader As XmlReader) Implements IXmlSerializable.ReadXml
            Throw New NotImplementedException()
        End Sub

        Public Sub WriteXml(writer As XmlWriter) Implements IXmlSerializable.WriteXml
            Throw New NotImplementedException()
        End Sub

        Public Function GetSchema() As XmlSchema Implements IXmlSerializable.GetSchema
            Throw New NotImplementedException()
        End Function
    End Class
End Module
