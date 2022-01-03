'Option Compare Text ' useless since regex aint insensitive bru8h

#Const ContextualisationTesting = True

Imports System.Text
Imports System.Text.RegularExpressions
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq

''' <summary>
''' The main class for the interpeter.
''' </summary>
Partial Public Module Interpreter
    'Public CurrentLine As String
    ''' <summary>
    ''' Unused
    ''' </summary>
    Public CurrentRow As Integer

    ''' <summary>
    ''' Unused
    ''' </summary>
    Public CurrentColumn As Integer

    ''' <summary>
    ''' The current consummate file. This is a combination of all source files loaded into Coco.
    ''' </summary>
    Public CurrentFile As String

    ''' <summary>
    ''' The current consummate file.
    ''' </summary>
    Public CurrentSource As New List(Of String)

    ''' <summary>
    ''' The currently-collected list of compiler errors to regurgitate all at once after compilation.
    ''' </summary>
    Public CompilerErrors As New List(Of Lamentation)

    ''' <summary>
    ''' The main container of instructions.
    ''' </summary>
    Public MotherContext As New Context()

    ''' <summary>
    ''' The main stack.
    ''' </summary>
    Public MotherStack As New List(Of FELObject)

    ''' <summary>
    ''' Unused
    ''' </summary>
    Public TempStack As New Queue(Of FELObject)

    'Public Sub InterpretThread(LineCollection As String)
    '    Dim Collection As New List(Of String)

    '    'If Not LineCollection.Contains(";") Then Throw New Lamentation("no semicolon??", 420)

    '    For Each Item As String In LineCollection.Split(vbCrLf)
    '        Collection.Add(Item)
    '    Next

    '    CurrentRow = 0
    '    CurrentLine = Collection(CurrentRow)

    '    Do
    '        Interpret()
    '        CurrentRow += 1
    '        CurrentLine = If(CurrentRow <> Collection.Count, Collection(CurrentRow), Nothing)
    '    Loop Until CurrentLine Is Nothing
    'End Sub

    ''' <summary>
    ''' Loads a file and adds it to the consummate file.
    ''' </summary>
    ''' <param name="path">The path to the source file.</param>
    ''' <param name="zoom">If true, don't display the "Press any key to continue" notice. Used for when Lilian calls this program.</param>
    Public Sub LoadFile(path As String)
        If File.Exists(path) Then
            If Not Zoom Then EnableIncrementalContextualisation = True
            Dim doccy = File.ReadAllLines(path)
            For document As Integer = 0 To doccy.Length - 1
                Try
                    Interpret(doccy(document))
                    If Not Zoom Then
                        Console.WriteLine($"Parsing {document + 1} out of {doccy.Length}.")
                        Console.SetCursorPosition(0, Console.CursorTop - 1) ' comment after debug
                    Else Continue For : End If
                Catch cry As Lamentation
                    'Console.WriteLine($"{cry.ErrorCode}: {cry.Message}")
                    CompilerErrors.Add(cry)
                    Continue For
                Catch ex As Exception
                    Console.WriteLine($"1000: Internal compiler error. {ex.GetType}; {ex.Message}")
                    Exit Sub
                End Try
            Next
            If CompilerErrors.Count > 0 OrElse CompilerErrors.Count <> 0 Then Exit Sub ' gtfo
            If Not Zoom Then Console.WriteLine("Interpretation complete" & vbCrLf & "####################")
            Curse(MotherContext)
            If Not Zoom Then
                Console.WriteLine("####################" & vbCrLf & "End of execution. Press any key to exit.")
                Console.ReadKey()
            Else
                Console.WriteLine("End of preprocessing. Over to you, Lilian!")
            End If

            End
        Else
            Console.WriteLine("This file does not exist.")
            End
        End If
    End Sub

    ''' <summary>
    ''' Reads from a path.
    ''' </summary>
    ''' <param name="path">The path to the file.</param>
    Public Sub ReadFile(path As String)
        If File.Exists(path.Trim("""")) Then
            For Each line As String In File.ReadAllLines(path.Trim(""""))
                CurrentSource.Add(line)
            Next
        Else
            Throw New Lamentation(2, path.Trim(""""))
        End If
    End Sub

    Public Sub ReadDirect(thing As String())
        For Each line As String In thing
            CurrentSource.Add(line)
        Next
    End Sub

    ''' <summary>
    ''' The primary interpretation session.
    ''' </summary>
    ''' <param name="Line">One of the lines of the consummate text.</param>
    Public Sub Interpret(Line As String)
        Dim DataCollection As New List(Of String)

        Dim act As New Action(0)
        Dim obj As New FELObject()

        'Dim Quotation As Boolean

        'For Each Item As String In LineCollection
        If Not String.IsNullOrEmpty(Line) OrElse Not String.IsNullOrWhiteSpace(Line) Then
            For Each Feature As String In FeatureConstants
                If Regex.IsMatch(Line, Feature) Then
                    Select Case Array.IndexOf(FeatureConstants, Feature)
                        Case 0
                            'act = New Action(3, Regex.Match(Line, "^\s*Define\s(?<SymbolLiteral>.+)\s*$").Groups("SymbolLiteral").Value)

                            obj = New FELObject(Regex.Match(Line, "^\s*Define\s(?<SymbolLiteral>.+)\s*$").Groups("SymbolLiteral").Value)
                            MotherStack.Add(obj)
                        Case 1 To 3
                            Console.WriteLine("hey!")
                        Case 4
                            If Regex.IsMatch(Line, "^\s*(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|(?:\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>)=)\s(?<InnerLeft>[0-9A-Za-z]+|"".+"")\s(?<InnerOperator>\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>|And|Or|Xor|Is|IsNot|AndAlso|OrElse|SoundsLike)\s(?<InnerRight>[0-9A-Za-z]+|"".+"")\s*$") Then
                                Dim cont = Regex.Match(Line, "^\s*(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|(?:\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>)=)\s(?<InnerLeft>[0-9A-Za-z]+|"".+"")\s(?<InnerOperator>\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>|And|Or|Xor|Is|IsNot|AndAlso|OrElse|SoundsLike)\s(?<InnerRight>[0-9A-Za-z]+|"".+"")\s*$")
                                ManipulationTime(cont, act)
                            ElseIf Regex.IsMatch(Line, "^\s*(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|(?:\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>)=)\s(?<InnerLeft>[0-9A-Za-z]+|"".*"")\s*$") Then
                                Dim cont = Regex.Match(Line, "^\s*(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|(?:\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>)=)\s(?<InnerLeft>[0-9A-Za-z]+|"".*"")\s*$")
                                ManipulationTime(cont, act)
                            End If
                        Case 7
                            End
                        Case 8
#If Not ContextualisationTesting Then
                            If Regex.IsMatch(Line, "^\s*Print\s(?<Value>[0-9A-Za-z]+)\s*$") Then
                                Dim Number As Long
                                If Long.TryParse(Regex.Match(Line, "^\s*Print\s(?<Value>[0-9]+)\s*$").Groups("Value").Value, Number) Then
                                    act = New Action(1, Number)
                                Else
                                    Dim oop = Regex.Match(Line, "^\s*Print\s(?<Value>[0-9A-Za-z]+)\s*$")
                                    If MotherStack.Exists(Function(thing As FELObject) thing.Name = oop.Groups("Value").Value) Then
                                        act = New Action(1, CType(MotherStack.Find(Function(thing As FELObject) thing.Name = oop.Groups("Value").Value), FELObject).Value)
                                    Else Throw New Lamentation("bruh111234", 111234)
                                    End If
                                End If
                            ElseIf Regex.IsMatch(Line, "^\s*Print\s(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>|\<\>|\<|\>|\<=|\>=|Is|IsNot|Or|Or|Xor|IsLike)\s(?<RightOperand>[0-9A-Za-z]+|"".+"")\s*$") Then
                                Dim thing = Regex.Match(Line, "^\s*Print\s(?<LeftOperand>[0-9]+)\s(?<Operator>=|\+|-|\*|\/|%|&|`|^|~|\\|\$|<<|>>|\<\>|\<|\>|\<=|\>=|Is|IsNot|Or|Or|Xor|IsLike)\s(?<RightOperand>[0-9]+)\s*$")
                                Dim Number1, Number2 As Long
                                If Long.TryParse(thing.Groups("LeftOperand").Value, Number1) AndAlso Long.TryParse(thing.Groups("RightOperand").Value, Number2) Then
                                    Select Case thing.Groups("Operator").Value
                                        Case "+"
                                            act = New Action(1, Number1 + Number2)
                                        Case "-"
                                            act = New Action(1, Number1 - Number2)
                                        Case "*"
                                            act = New Action(1, Number1 * Number2)
                                        Case "/"
                                            act = New Action(1, Number1 / Number2)
                                        Case "`"
                                            act = New Action(1, CLng(Math.Pow(Number1, Number2)))
                                        Case "%"
                                            act = New Action(1, Number1 Mod Number2)
                                        Case "&", "Or"
                                            act = New Action(1, Number1 Or Number2)
                                        Case "|", "Or"
                                            act = New Action(1, Number1 Or Number2)
                                        Case "^\s*", "Xor"
                                            act = New Action(1, Number1 Xor Number2)
                                        Case "~"
                                            Throw New Lamentation("sorry, my bad")
                                        Case "$"
                                            act = New Action(1, Number1 & Number2)
                                        Case "<<"
                                            act = New Action(1, Number1 * 2 * Number2)
                                        Case ">>"
                                            act = New Action(1, Number1 / 2 * Number2)
                                        Case "<"
                                            act = New Action(1, Number1 < Number2)
                                        Case "<="
                                            act = New Action(1, Number1 <= Number2)
                                        Case ">"
                                            act = New Action(1, Number1 > Number2)
                                        Case ">="
                                            act = New Action(1, Number1 >= Number2)
                                        Case "<>"
                                            act = New Action(1, Number1 <> Number2)
                                        Case "=="
                                            act = New Action(1, Number1 = Number2)
                                        Case "Is", "IsNot", "IsLike"
                                            Throw New Lamentation("wrong", 2)
                                    End Select
                                ElseIf Regex.IsMatch(Line, "^\s*Print\s(?<LeftOperand>"".+"")\s(?<Operator>\$)\s(?<RightOperand>"".+"")\s*$") Then
                                    act = New Action(1, Regex.Match(Line, "^\s*Print\s(?<LeftOperand>"".+"")\s(?<Operator>\$)\s(?<RightOperand>"".+"")\s*$").Value.Trim("""") & Regex.Match(Line, "^\s*Print\s(?<LeftOperand>"".+"")\s(?<Operator>\$)\s(?<RightOperand>"".+"")\s*$").Groups("RightOperand").Value.Trim(""""))
                                End If
                            ElseIf Regex.IsMatch(Line, "^\s*Print\s(?<Value>"".*"")\s*$") Then
                                act = New Action(1, Regex.Match(Line, "^\s*Print\s(?<Value>"".*"")\s*$").Groups("Value").Value.Trim(""""))
                            End If
#Else
                            If MotherStack.Exists(Function(thing As FELObject) thing.Name = Regex.Match(Line, Feature).Groups("Value").ToString()) Then
                                act = New Action(1, MotherStack.Find(Function(thing As FELObject) thing.Name = Regex.Match(Line, Feature).Groups("Value").ToString()))
                            Else
                                If Regex.IsMatch(Line, "\s*Print\s(?<InnerLeft>[0-9A-Za-z]+|"".*"")\s(?<InnerOperator>\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>|And|Or|Xor|Is|IsNot|AndAlso|OrElse|SoundsLike)\s(?<InnerRight>[0-9A-Za-z]+|"".*"")\s*$") Then
                                    Dim cont = Regex.Match(Line, "\s*Print\s(?<InnerLeft>[0-9A-Za-z]+|"".*"")\s(?<InnerOperator>\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>|And|Or|Xor|Is|IsNot|AndAlso|OrElse|SoundsLike)\s(?<InnerRight>[0-9A-Za-z]+|"".*"")\s*$")
                                    ManipulationTime(cont, act, False, True)
                                ElseIf Regex.IsMatch(Line, "^\s*Print\s(?<Value>[0-9]+|"".*"")\s*$") Then
                                    Dim cont = Regex.Match(Line, "^\s*Print\s(?<Value>[0-9]+|"".*"")\s*$")
                                    act = New Action(1, cont.Groups("Value").Value.Trim(""""c))
                                    'ManipulationTime(Nothing, cont.Groups("Value").Value, Nothing, act, Nothing, Nothing, False, True)
                                End If

                            End If
#End If
                        Case 9
                            'Console.WriteLine("not implemented yet!")
                            act = New Action(0)
                        Case 10
                            Exit Sub
                            ' is just a comment! like this one
                        Case 11
                            Curse(MotherContext)
                            Exit Sub
                        Case 13
                        Case 14
                            Manipulation(Regex.Match(Line, Feature).Groups("Value").Value)
                        Case Else
                            Console.WriteLine("hey!")
                    End Select
                    Exit For
                Else
                    If Array.IndexOf(FeatureConstants, Feature) <> FeatureConstants.Length - 1 Then Continue For Else Throw New Lamentation(1, Line)
                End If
            Next
        Else GoTo Finished
        End If
        'Next


Finished:
        If EnableIncrementalContextualisation Then
            MotherContext.Append(act)
        ElseIf EmittedStatements.Count <> 0 Then
            ProposeMods()
        Else
            Curse(act)
        End If
    End Sub

    ''' <summary>
    ''' How the interpreter puts two and two together.
    ''' </summary>
    <Flags>
    Private Enum ManipulationType
        ''' <summary>
        ''' Doing nothing.
        ''' </summary>
        [Default] = 0

        ''' <summary>
        ''' Identifier to identifier.
        ''' </summary>
        NamedToNamed = 1

        ''' <summary>
        ''' Literal to identifier.
        ''' </summary>
        ValueToNamed = 2

        ''' <summary>
        ''' Operation to identifier.
        ''' </summary>
        OperationToNamed = 4

        ''' <summary>
        ''' Condition to identifier.
        ''' </summary>
        ConditionToNamed = 8


        ''' <summary>
        ''' String manipulation.
        ''' </summary>
        StringTo = 64

        ''' <summary>
        ''' Integral manipulation.
        ''' </summary>
        NumericalTo = 128

        ''' <summary>
        ''' Boolean manipulation.
        ''' </summary>
        BoolTo = 256


        ''' <summary>
        ''' The identifier is the left operand.
        ''' </summary>
        OnLeft = 512

        ''' <summary>
        ''' The identifier is the right operand.
        ''' </summary>
        OnRight = 1024
    End Enum

    ''' <summary>
    ''' Primary manipulation session.
    ''' </summary>
    ''' <param name="contenu">The match that has the values.</param>
    ''' <param name="activity">The action to be modified.</param>
    ''' <param name="onetime">If the manipulation is temporary.</param>
    ''' <param name="forprint">If the manipulation is for printing.</param>
    Private Sub ManipulationTime(contenu As Match, ByRef activity As Action, Optional onetime As Boolean = False, Optional forprint As Boolean = False)
        'On Error GoTo Oopsie

        Dim test, right, final, initial As Long
        Dim stest, sright, sfinal, sinitial As String
        Dim btest, bright, bfinal, binitial As Boolean
        Dim howto, useWhat As ManipulationType
        Dim TypeInference As Boolean
        Dim finalObj
        Dim ObjectToUse As FELObject

        test = 0 : right = 0 : final = 0 : initial = 0
        stest = String.Empty : sright = String.Empty : sfinal = String.Empty : sinitial = String.Empty
        btest = False : bright = False : bfinal = False : binitial = False
        finalObj = Nothing

        Try
            If Not forprint Then
                If MotherStack.Exists(Function(thing As FELObject) thing.Name = contenu.Groups("LeftOperand").Value) Then
                    Dim printi As FELObject = MotherStack.Find(Function(thing As FELObject) thing.Name = contenu.Groups("LeftOperand").Value)
                    If TypeOf printi.Value Is Long Then
                        initial = printi.Value
                    ElseIf TypeOf printi.Value Is Boolean Then
                        binitial = printi.Value
                    ElseIf TypeOf printi.Value Is String Then
                        sinitial = printi.Value
                    Else
                        TypeInference = True
                    End If
                    ObjectToUse = printi
                End If
            End If

            If MotherStack.Exists(Function(thing As FELObject) thing.Name = contenu.Groups("InnerLeft").Value) Then
                Dim printi As FELObject = MotherStack.Find(Function(thing As FELObject) thing.Name = contenu.Groups("InnerLeft").Value)
                If TypeOf printi.Value Is Long Then
                    test = printi.Value
                    useWhat = ManipulationType.NumericalTo
                ElseIf TypeOf printi.Value Is Boolean Then
                    btest = printi.Value
                    useWhat = ManipulationType.BoolTo
                ElseIf TypeOf printi.Value Is String Then
                    stest = printi.Value
                    useWhat = ManipulationType.StringTo
                End If
            Else
                Dim bruh = contenu.Groups("InnerLeft").Value
                If Long.TryParse(bruh, test) Then
                    useWhat = ManipulationType.NumericalTo
                ElseIf Boolean.TryParse(bruh, btest) Then
                    useWhat = ManipulationType.BoolTo
                ElseIf Regex.IsMatch(bruh, """(?<Value>.*)""") Then
                    stest = Regex.Match(bruh, """(?<Value>.*)""").Groups("Value").Value
                    useWhat = ManipulationType.StringTo
                Else Throw New Lamentation("KJSDGUUDOFG", 2454)
                End If
            End If

            If Not String.IsNullOrEmpty(contenu.Groups("InnerRight").Value) Then
                If MotherStack.Exists(Function(thing As FELObject) thing.Name = contenu.Groups("InnerRight").Value) Then
                    Dim printii As FELObject = MotherStack.Find(Function(thing As FELObject) thing.Name = contenu.Groups("InnerRight").Value)
                    If TypeOf printii.Value Is Long Then
                        right = printii.Value
                        howto = ManipulationType.NumericalTo
                    ElseIf TypeOf printii.Value Is Boolean Then
                        bright = printii.Value
                        howto = ManipulationType.BoolTo
                    ElseIf TypeOf printii.Value Is String Then
                        sright = printii.Value
                        howto = ManipulationType.StringTo
                    End If
                Else
                    Dim bruh = contenu.Groups("InnerRight").Value
                    If Long.TryParse(bruh, right) Then
                        howto = ManipulationType.NumericalTo
                    ElseIf Boolean.TryParse(bruh, bright) Then
                        howto = ManipulationType.BoolTo
                    ElseIf Regex.IsMatch(bruh, """(?<Value>.*)""") Then
                        sright = Regex.Match(bruh, """(?<Value>.*)""").Groups("Value").Value
                        howto = ManipulationType.StringTo
                    ElseIf String.IsNullOrEmpty(bruh) Then
                    Else Throw New Lamentation("KJSDGUUDOFG", 2454)
                    End If
                End If
            End If
            If howto = 0 Then howto = useWhat
            If useWhat = 0 Then useWhat = howto ' recursive ???
            If Not String.IsNullOrEmpty(contenu.Groups("InnerOperator").Value) Then
                Select Case howto
                    Case ManipulationType.NumericalTo
                        Select Case contenu.Groups("InnerOperator").Value
                            Case "+"
                                final = test + right
                            Case "-"
                                final = test - right
                            Case "*"
                                final = test * right
                            Case "/"
                                final = test / right
                            Case "`"
                                final = Math.Pow(test, right)
                            Case "%"
                                final = test Mod right
                            Case "&", "And"
                                final = test And right
                            Case "|", "Or"
                                final = test Or right
                            Case "^", "Xor"
                                final = test Xor right
                            Case "$"
                                sfinal = test & right
                                useWhat = ManipulationType.StringTo
                            Case "<<"
                                final = test << right
                            Case ">>"
                                final = test >> right
                            Case "<"
                                bfinal = test < right
                                useWhat = ManipulationType.BoolTo
                            Case "<="
                                bfinal = test <= right
                                useWhat = ManipulationType.BoolTo
                            Case ">"
                                bfinal = test > right
                                useWhat = ManipulationType.BoolTo
                            Case ">="
                                bfinal = test >= right
                                useWhat = ManipulationType.BoolTo
                            Case "<>"
                                bfinal = test <> right
                                useWhat = ManipulationType.BoolTo
                            Case "="
                                bfinal = test = right
                                useWhat = ManipulationType.BoolTo
                            Case Else
                                Throw New Lamentation("wrong", 2)
                        End Select
                    Case ManipulationType.BoolTo
                        Select Case contenu.Groups("InnerOperator").Value
                            Case "&", "And", "AndAlso"
                                bfinal = btest And bright
                            Case "|", "Or", "OrElse"
                                bfinal = btest Or bright
                            Case "^", "Xor"
                                bfinal = btest Xor bright
                            Case "$"
                                sfinal = btest & bright
                                useWhat = ManipulationType.StringTo
                            Case Else
                                Throw New Lamentation("wrong", 2)
                        End Select
                    Case ManipulationType.StringTo
                        Select Case contenu.Groups("InnerOperator").Value
                            Case "$"
                                sfinal = stest & sright
                            Case "<>"
                                bfinal = stest <> sright
                                useWhat = ManipulationType.BoolTo
                            Case "="
                                bfinal = stest = sright
                                useWhat = ManipulationType.BoolTo
                            Case Else
                                Throw New Lamentation("wrong", 2)
                        End Select
                End Select
            Else
                Select Case howto
                    Case ManipulationType.BoolTo
                        bfinal = btest
                    Case ManipulationType.NumericalTo
                        final = test
                    Case ManipulationType.StringTo
                        sfinal = stest
                End Select
            End If

            If Not forprint Then
                If TypeInference Then

                End If
                Select Case howto
                    Case ManipulationType.NumericalTo
                        Select Case contenu.Groups("Operator").Value
                            Case "+="
                                initial += final
                            Case "-="
                                initial -= final
                            Case "*="
                                initial *= final
                            Case "/="
                                initial /= final
                            Case "`="
                                initial = Math.Pow(initial, final)
                            Case "%="
                                initial = initial Mod final
                            Case "&=" ', "And"
                                initial = initial And final
                            Case "|=" ', "Or"
                                initial = initial Or final
                            Case "^=" ', "Xor"
                                initial = initial Xor final
                            Case "$="
                                sinitial &= sfinal
                                useWhat = ManipulationType.StringTo
                            Case "<<="
                                initial <<= final
                            Case ">>="
                                initial >>= final
                            Case "="
                                initial = final
                            Case Else
                                Throw New Lamentation("wrong", 2)
                        End Select
                    Case ManipulationType.BoolTo
                        Select Case contenu.Groups("Operator").Value
                            Case "&=" ', "And", "AndAlso"
                                binitial = binitial And bfinal
                            Case "|=" ', "Or", "OrElse"
                                binitial = binitial Or bfinal
                            Case "^=" ', "Xor"
                                binitial = binitial Xor bfinal
                            Case "$="
                                sinitial &= bfinal
                                useWhat = ManipulationType.StringTo
                            Case "="
                                binitial = bfinal
                            Case Else
                                Throw New Lamentation("wrong", 2)
                        End Select
                    Case ManipulationType.StringTo
                        Select Case contenu.Groups("Operator").Value
                            Case "$="
                                sinitial &= sfinal
                            Case "="
                                sinitial = sfinal
                            Case Else
                                Throw New Lamentation("wrong", 2)
                        End Select

                End Select
            End If

            If forprint Then
                Select Case useWhat
                    Case ManipulationType.BoolTo : finalObj = bfinal
                    Case ManipulationType.NumericalTo : finalObj = final
                    Case ManipulationType.StringTo : finalObj = sfinal
                End Select
            Else
                Select Case useWhat
                    Case ManipulationType.BoolTo : finalObj = binitial
                    Case ManipulationType.NumericalTo : finalObj = initial
                    Case ManipulationType.StringTo : finalObj = sinitial
                End Select
            End If

            If forprint Then
                activity = New Action(1, finalObj)
            Else
                activity = New Action(2, ObjectToUse.Name, finalObj)
            End If

            'Exit Sub ' should i keep this
        Catch cry As Lamentation
            Throw
        Catch ex As Exception
            Throw New Lamentation("internal compiler error!", 1000)
        End Try
    End Sub

    ''' <summary>
    ''' Gets or sets whether Coco is running as a REPL or as a compiler.
    ''' </summary>
    ''' <returns></returns>
    Public Property EnableIncrementalContextualisation As Boolean = False

End Module

''' <summary>
''' The grammatical feature constants.
''' </summary>
Public Module GrammarFeatureConstants
    'Public Const Condition As String = "(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|\<\>|\<|\>|\<=|\>=|Is|IsNot|Or|Or)\s(?<RightOperand>[0-9A-Za-z]+|"".+"")"
    ''' <summary>
    ''' The grammatical feature constants.
    ''' </summary>
    Public ReadOnly FeatureConstants As String() =
    {
        "^\s*Define\s(?<SymbolLiteral>.+)\s*$",
        "^\s*Create\s(?<SymbolLiteral>.+)\s*$",
        "^\s*If\s(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|\<\>|\<|\>|\<=|\>=|Is|IsNot|AndAlso|OrElse|SoundsLike)\s(?<RightOperand>[0-9A-Za-z]+|"".+"")\s*$",
        "^\s*ElseIf\s(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|\<\>|\<|\>|\<=|\>=|Is|IsNot|AndAlso|OrElse|SoundsLike)\s(?<RightOperand>[0-9A-Za-z]+|"".+"")\s*$",
        "^\s*(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|(?:\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>)=)\s(?<RightOperand>[0-9A-Za-z]+|"".+""|(?<InnerLeft>[0-9A-Za-z]+|"".+"")\s(?<InnerOperator>\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>|And|Or|Xor|Is|IsNot|AndAlso|OrElse|SoundsLike)\s(?<InnerRight>[0-9A-Za-z]+|"".+""))\s*$",
        "^\s*Option\s(?<Setting>)\s*$",
        "^\s*End(?<CurrentMode>(?:\s)[A-Za-z]+)?\s*$",
        "^\s*Exit\s*$",
        "^\s*Print\s(?<Value>[0-9A-Za-z]+|(?<InnerLeft>[0-9A-Za-z]+|"".+"")\s(?<InnerOperator>\+|-|\*|\/|%|&|`|^|!|~|\\|\$|<<|>>|And|Or|Xor|Is|IsNot|AndAlso|OrElse|SoundsLike)\s(?<InnerRight>[0-9A-Za-z]+|"".+""))\s*$",
        "^\s*Version\s(?<MajorVersion>[0-9]+).(?<MinorVersion>[0-9]+)\s*$",
        "^\s*'.*\s*$",
        "^\s*Run\s*$",
        "^\s*Destroy\s(?<LeftOperand>[0-9A-Za-z]+)\s*$",
        "^\s*Statement\s(?<Name>[0-9A-Za-z]*)\s*$",
        "^\s*Write\s(?<Value>"".*"")"
    }
End Module