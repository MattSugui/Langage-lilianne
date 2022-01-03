Partial Public Module Interpreter
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
                {0, "All clear."},
                {1, "Syntax error. This command does not exist. You typed in: {0}, and I don't know shit about it"},
                {2, "The file {0} does not exist."},
                {3, "Handshake with Lilian failed. {0}"},
                {4, "Invalid operation in handshake. {0}"}
            }
        End Sub

        ''' <summary>
        ''' Initialises a new instance of the Lamentation class.
        ''' </summary>
        Public Sub New()

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
                Throw New InvalidOperationException($"Lamentation provider failed to retrieve error code {errc} because it does not exist. How ironic.")
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
                Throw New InvalidOperationException($"Lamentation provider failed to retrieve error code {errc} because it does not exist. How ironic.")
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

End Module
