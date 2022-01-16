Imports System.Reflection

''' <summary>
''' The main program.
''' </summary>
Public Module Program
    ''' <summary>
    ''' The main entry point.
    ''' </summary>
    ''' <param name="args">Command-line arguments</param>
    Public Sub Main(args As String())
        Console.WriteLine(
            "Fonder Lilian Language Environment Coco Preprocessor\n" +
            "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", " +
            (CType(Assembly.GetExecutingAssembly().GetCustomAttribute(GetType(AssemblyInformationalVersionAttribute)), AssemblyInformationalVersionAttribute).InformationalVersion.Replace("releaseman ", String.Empty) + "\n"))

        If args.Length = 0 Then
            Console.WriteLine("Supply a file!")
            Environment.Exit(0)
        End If
    End Sub
End Module
