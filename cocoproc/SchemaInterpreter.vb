Imports System.IO
Imports System.Xml
Imports System.Xml.Schema
Imports System.Xml.Serialization

Partial Public Module Interpreter
    REM Schema
    ' 
    ' Statement "Print"
    '     Procedures
    ' 
    ' 
    ' 
    ' 
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
