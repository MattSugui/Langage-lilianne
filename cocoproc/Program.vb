Imports System
Imports System.Reflection

Public Module Program
    Public Sub Main(args As String())
        Console.WriteLine(
                "Fonder Lilian Language Coco Environment" & vbCrLf &
                "Version " & Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", 2021" & vbCrLf)


        If args.Length > 0 Then
            If args(0) = "-p" Then
                Handshake()
            Else
                'Try
                LoadFile(args(0))
                'Else Throw New Lamentation("bruh!", 21)
                If CompilerErrors.Count > 0 OrElse CompilerErrors.Count <> 0 Then GoTo CompilationErrorMessages
            End If
        Else
            GoTo REPLMode
        End If

REPLMode:
        Console.WriteLine("Welcome to the REPL mode! Type EXIT if you've had your fun.")

        Console.WriteLine("This version is a test on contextualisation. Press Y to do incremental programming, or press N for classic REPL.")
        While True
            Dim kex = Console.ReadKey
            If kex.Key = ConsoleKey.Y Then
                EnableIncrementalContextualisation = True
                Exit While
            ElseIf kex.Key = ConsoleKey.N Then
                EnableIncrementalContextualisation = False
                Exit While
            Else
                Console.SetCursorPosition(0, Console.CursorTop)
                Continue While
            End If
        End While
        Console.WriteLine()


        While True
            Try
                Interpret(Console.ReadLine())
            Catch cry As Lamentation
                Console.WriteLine($"{cry.ErrorCode}: {cry.Message}")
            Catch ex As Exception
                Console.WriteLine($"1000: Internal compiler error. {ex}; {ex.Message}")
            End Try
        End While

CompilationErrorMessages:
        Console.WriteLine($"{CompilerErrors.Count} compiler {If(CompilerErrors.Count > 1, "errors were", "error was")} found. Press Y to view {If(CompilerErrors.Count > 1, "these errors", "this error")}, or press N to exit.")
        While True
            Dim key = Console.ReadKey
            If key.Key = ConsoleKey.Y Then
                Console.WriteLine()
                For Each lament As Lamentation In CompilerErrors
                    Console.WriteLine($"{lament.ErrorCode}: {lament.Message}")
                Next
                Exit While
            ElseIf key.Key = ConsoleKey.N Then
                End
            Else
                Console.SetCursorPosition(0, Console.CursorTop)
                Continue While
            End If
        End While
        Console.WriteLine("####################")
        Console.WriteLine("Execution failed. Press any key to exit.")
    End Sub
End Module
