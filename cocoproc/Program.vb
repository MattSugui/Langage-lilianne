Imports System
Imports System.Reflection
Imports System.IO

Public Module Program
    Public Zoom As Boolean = False
    Public Sub Main(args As String())
        If Not args.Contains("-nobanner") Then
            Console.WriteLine(
                "Fonder Lilian Language Coco Environment" & vbCrLf &
                "Version " & Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", 2021" & vbCrLf)
        End If

        If args.Length > 0 Then
            If args(0) = "-p" Then
                Deal()
            ElseIf args(0) = "-d" Then
                If args.Length >= 2 AndAlso args(1).Length <> 0 Then

                Else
                    Console.WriteLine("You must supply a fragment or file!")
                    End
                End If
            ElseIf args(0) = "-l" Then
                If File.Exists("cocotmp.ccn") Then
                    Zoom = True
                    LoadFile("cocotmp.ccn")
                    If CompilerErrors.Count > 0 OrElse CompilerErrors.Count <> 0 Then GoTo CompilationErrorMessages
                Else
                    Console.WriteLine("Temp file does not exist. Belayed and backing off.")
                    Exit Sub
                End If
            Else
                Zoom = args.Length > 1 AndAlso args(1) = "-l"
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
        If Not Zoom Then
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
        Else
            Console.WriteLine($"{CompilerErrors.Count} compiler {If(CompilerErrors.Count > 1, "errors were", "error was")} found.")
            Console.WriteLine()
            For Each lament As Lamentation In CompilerErrors
                Console.WriteLine($"{lament.ErrorCode}: {lament.Message}")
            Next
            Console.WriteLine("Preprocessing failed; no changes are to be made to your Lilian code. Over to you, Lilian.")
        End If
    End Sub
End Module
