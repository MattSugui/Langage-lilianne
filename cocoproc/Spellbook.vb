#Const OrbPonderingTime = False
#Const VERBOSE = False

Imports System.Text.RegularExpressions

Partial Public Module Interpreter

    ''' <summary>
    ''' An interface for declaring this object to be contextualisable.
    ''' </summary>
    Public Interface IContextualisable
    End Interface

    ''' <summary>
    ''' An interface for declaring this object to be manipulable.
    ''' </summary>
    Public Interface IManipulable
    End Interface

    ''' <summary>
    ''' An object in code.
    ''' </summary>
    Public Structure FELObject
        Implements IManipulable, IEquatable(Of FELObject)

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nm"></param>
        Public Sub New(nm As String)
            Name = nm
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="nm"></param>
        ''' <param name="val"></param>
        Public Sub New(nm As String, val As Object)
            Name = nm
            Value = val
        End Sub

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public ReadOnly Property Name As String

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Property Value As Object

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <param name="other"></param>
        ''' <returns></returns>
        Public Overloads Function Equals(other As FELObject) As Boolean Implements IEquatable(Of FELObject).Equals
            If Name = other.Name Then Return True Else Return False
        End Function

        Public Shared Operator =(obj1 As FELObject, obj2 As FELObject) As Boolean
            If obj1.Name = obj2.Name Then Return True Else Return False
        End Operator

        Public Shared Operator <>(obj1 As FELObject, obj2 As FELObject) As Boolean
            If obj1.Name <> obj2.Name Then Return True Else Return False
        End Operator

        ''' <summary>
        ''' 
        ''' </summary>
        ''' <returns></returns>
        Public Overrides Function ToString() As String
            Return Value.ToString()
        End Function

    End Structure

    Public Class FELObjectType
        Implements IManipulable

        Public Sub New(nm As String)
            Name = nm
            Contents = New List(Of IManipulable)
        End Sub

        Public Sub New(nm As String, ParamArray cont() As IManipulable)
            Name = nm
            Contents = New List(Of IManipulable)(cont)
        End Sub

        Public ReadOnly Property Name As String
        Public ReadOnly Property Contents As List(Of IManipulable)
    End Class

    Public Structure Action
        Implements IContextualisable

        Public Sub New(activity As WhatToDo)
            Act = activity
            WorkingValue = Nothing
            AssignmentValue = Nothing
            AssignmentType = Nothing
            RightAssignmentValue = Nothing
            OperationType = Nothing
        End Sub

        Public Sub New(activity As WhatToDo, val As Object)
            Act = activity
            WorkingValue = val
            AssignmentValue = Nothing
            AssignmentType = Nothing
            RightAssignmentValue = Nothing
            OperationType = Nothing
        End Sub

        Public Sub New(activity As WhatToDo, name As String, val As Object)
            Act = activity
            WorkingValue = name
            AssignmentValue = val
            AssignmentType = Nothing
            RightAssignmentValue = Nothing
            OperationType = Nothing
        End Sub

        Public Sub New(activity As WhatToDo, val As Object, assgn As Object, type As Operation)
            Act = activity
            WorkingValue = val
            AssignmentValue = assgn
            AssignmentType = type
            RightAssignmentValue = Nothing
            OperationType = 0
        End Sub

        Public Sub New(activity As WhatToDo, val As Object, assgn1 As Object, assgn2 As Object, type As Operation, optype As Operation)
            Act = activity
            WorkingValue = val
            AssignmentValue = assgn1
            AssignmentType = type
            RightAssignmentValue = assgn2
            OperationType = optype
        End Sub

        Public ReadOnly Property Act As WhatToDo

        Public Property WorkingValue As Object

        Public Property AssignmentValue As Object

        Public Property RightAssignmentValue As Object

        Public ReadOnly Property AssignmentType As Operation

        Public ReadOnly Property OperationType As Operation


        Public Enum WhatToDo As Byte
            NoOperation = 0
            Print = 1
            Assign = 2
            Define = 3
        End Enum

        Public Enum Operation As SByte
            [Nothing] = -1
            Assignment
            Addition
            Subtraction
            Multiplication
            Division
            Exponentation
            Modulo
            LeftShift
            RightShift
            [And]
            [Or]
            [Xor]
            Concatenation
            ProveThat
            ProveThatGreaterThan
            ProveThatLessThan
            ProveThatNot
            ProveThatGreaterOr
            ProveThatLessOr
            [Not]
            [AndAlso]
            [OrElse]
            PatternMatches
            TypeMatches
            TypeDoesNotMatch
        End Enum
    End Structure

    Public Class Context
        Implements IEnumerable, IContextualisable

        Friend ToDoList(0) As IContextualisable

        Public ReadOnly Property Count As Integer
            Get
                Return amount
            End Get
        End Property

        Friend amount As Integer

        Public Sub New(ParamArray actArray() As IContextualisable)
            ToDoList = New IContextualisable(actArray.Length - 1) {}

            If actArray.Length > ToDoList.Length Then Throw New Lamentation("bruh how the fuck", 10)

            'Dim i
            For i As Integer = 0 To actArray.Length - 1
                ToDoList(i) = actArray(i)
            Next

            amount = actArray.Length
        End Sub

        Public Sub Append(ParamArray actArray() As IContextualisable)
            If actArray.Length = 0 Then Exit Sub

            ' If actArray.Length + Count > ToDoList.Length Then Throw New Lamentation("bruh how the fuck", 10)

            ReDim Preserve ToDoList(Count + actArray.Length)

            For i As Integer = Count To (Count + actArray.Length) - 1
                ToDoList(i) = actArray(i - Count)
            Next

            amount += actArray.Length
        End Sub

        Public Sub RemoveAt(index As Integer)
            ToDoList(index) = Nothing
            amount -= 1
        End Sub

        Public Sub Clear()
            ToDoList = New IContextualisable(0) {}
            amount = 0
        End Sub

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return New Contextualisation(ToDoList, Count)
        End Function
    End Class

    Public Class Contextualisation
        Implements IEnumerator

        Public ActionListing() As IContextualisable
        Dim Position As Integer = -1
        Dim Count As Integer

        Public Sub New(list() As IContextualisable, cnt As Integer)
            ActionListing = list
            Count = cnt
        End Sub

        Public ReadOnly Property Current As Object Implements IEnumerator.Current
            Get
                Try
                    Return ActionListing(Position)
                Catch ex As IndexOutOfRangeException
                    Throw New Lamentation("how in the fuck", 10)
                End Try
            End Get
        End Property

        Public Sub Reset() Implements IEnumerator.Reset
            Position = -1
        End Sub

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            Position += 1
            Return (Position < Count)
        End Function
    End Class


    Public Sub Curse(act As IContextualisable)
        If TypeOf act Is Action Then
            Dim activite As Action = act
            With activite
                Select Case .Act
                    Case 0
                        Exit Sub
                    Case 1
                        Console.WriteLine(If(.WorkingValue, "This value is empty."))
                    Case 2
                        Dim Habilitated As FELObject = MotherStack.Find(Function(thing As FELObject) thing.Name = .WorkingValue)
                        Habilitated.Value = .AssignmentValue
                        MotherStack(MotherStack.FindIndex(Function(thing As FELObject) thing.Name = .WorkingValue)) = Habilitated
                    Case 3
                        Dim Habilitated As FELObject = MotherStack.Find(Function(thing As FELObject) thing = activite.WorkingValue)
                        Dim Whatever = Nothing
                        If TypeOf .AssignmentValue Is Long Then
                            If .RightAssignmentValue IsNot Nothing Then
                                If TypeOf .RightAssignmentValue Is Long Then
                                    Select Case .OperationType
                                        Case 1
                                            Whatever = .AssignmentValue + .RightAssignmentValue
                                        Case 2
                                            Whatever = .AssignmentValue - .RightAssignmentValue
                                        Case 3
                                            Whatever = .AssignmentValue * .RightAssignmentValue
                                        Case 4
                                            Whatever = .AssignmentValue / .RightAssignmentValue
                                        Case 5
                                            Whatever = Math.Pow(.AssignmentValue, .RightAssignmentValue)
                                        Case 6
                                            Whatever = .AssignmentValue Mod .RightAssignmentValue
                                        Case 7
                                            Whatever = .AssignmentValue << .RightAssignmentValue
                                        Case 8
                                            Whatever = .AssignmentValue >> .RightAssignmentValue
                                        Case 9
                                            Whatever = .AssignmentValue And .RightAssignmentValue
                                        Case 10
                                            Whatever = .AssignmentValue Or .RightAssignmentValue
                                        Case 11
                                            Whatever = .AssignmentValue Xor .RightAssignmentValue
                                        Case 12
                                            Whatever = .AssignmentValue & .RightAssignmentValue
                                        Case 13
                                            Whatever = .AssignmentValue = .RightAssignmentValue
                                        Case 14
                                            Whatever = .AssignmentValue > .RightAssignmentValue
                                        Case 15
                                            Whatever = .AssignmentValue < .RightAssignmentValue
                                        Case 16
                                            Whatever = .AssignmentValue <> .RightAssignmentValue
                                        Case 17
                                            Whatever = .AssignmentValue >= .RightAssignmentValue
                                        Case 18
                                            Whatever = .AssignmentValue <= .RightAssignmentValue
                                        Case Else
                                            Throw New Lamentation("bru", 1443)
                                    End Select
                                ElseIf TypeOf .RightAssignmentValue Is String Then
                                    Select Case .OperationType
                                        Case 12
                                            Whatever = .AssignmentValue & .RightAssignmentValue
                                        Case Else
                                            Throw New Lamentation("bru", 1443)
                                    End Select
                                End If
                            Else Throw New Lamentation("BSGFSGS", 1351) : End If
                        ElseIf TypeOf .AssignmentValue Is Boolean Then
                            If .RightAssignmentValue IsNot Nothing Then
                                If TypeOf .RightAssignmentValue Is Boolean Then
                                    Select Case .OperationType
                                        Case 9, 20
                                            Whatever = .AssignmentValue And .RightAssignmentValue
                                        Case 10, 21
                                            Whatever = .AssignmentValue Or .RightAssignmentValue
                                        Case 11
                                            Whatever = .AssignmentValue Xor .RightAssignmentValue
#If VERBOSE Then
                                        Case 20
                                            Whatever = .AssignmentValue AndAlso .RightAssignmentValue
                                        Case 21
                                            Whatever = .AssignmentValue OrElse .RightAssignmentValue
#End If
                                    End Select
                                End If
                            End If
                        ElseIf TypeOf .AssignmentValue Is String Then
                            If .RightAssignmentValue IsNot Nothing Then
                                If TypeOf .RightAssignmentValue Is String Then
                                    Select Case .OperationType
                                        Case 12
                                            Whatever = .AssignmentValue & .RightAssignmentValue
                                        Case 22
                                            Whatever = Regex.IsMatch(.AssignmentValue, .RightAssignmentValue)
                                        Case Else
                                            Throw New Lamentation("bru", 1443)
                                    End Select
                                Else
                                    If .OperationType = 12 Then Whatever = .AssignmentValue & .RightAssignmentValue.ToString() Else Throw New Lamentation("bruh", 6363)
                                End If
                            End If
                        End If
                        If TypeOf Habilitated.Value Is Long Then
                            If TypeOf Whatever Is Long Then
                                Select Case .AssignmentType

#If Not OrbPonderingTime Then
                                    Case 0
                                        Habilitated.Value = Whatever
                                    Case 1
                                        Habilitated.Value += Whatever
                                    Case 2
                                        Habilitated.Value -= Whatever
                                    Case 3
                                        Habilitated.Value *= Whatever
                                    Case 4
                                        Habilitated.Value /= Whatever
                                    Case 5
                                        Habilitated.Value = Math.Pow(Habilitated.Value, Whatever)
                                    Case 6
                                        Habilitated.Value = Habilitated.Value Mod Whatever
                                    Case 7
                                        Habilitated.Value <<= Whatever
                                    Case 8
                                        Habilitated.Value >>= Whatever
                                    Case 9
                                        Habilitated.Value = Habilitated.Value And Whatever
                                    Case 10
                                        Habilitated.Value = Habilitated.Value Or Whatever
                                    Case 11
                                        Habilitated.Value = Habilitated.Value Xor Whatever
                                    Case Else
                                        Throw New Lamentation("bsdfsdufuisduifgsuidfg", 1354)

#Else
                        Case Else
                            Console.WriteLine(.AssignmentType)
                            Console.WriteLine(.OperationType)
                            Console.WriteLine(.AssignmentValue.GetType().ToString() & ", " & activite.AssignmentValue.ToString())
                            Console.WriteLine(.RightAssignmentValue.GetType().ToString() & ", " & activite.RightAssignmentValue.ToString())
#End If
                                End Select
                            Else Throw New Lamentation("sdfsdf", 1243) : End If
                        ElseIf TypeOf Habilitated.Value Is String Then
                            Select Case .AssignmentType
                                Case 0
                                    Habilitated.Value = Whatever.ToString()
                                Case 12
                                    Habilitated.Value &= Whatever.ToString()
                                Case Else
                                    Throw New Lamentation("ouguofdgdfg", 1238)
                            End Select
                        Else
                            Habilitated.Value = Whatever
                            'Else Throw New Lamentation("sdfsdf", 1243) : End If
                        End If
                        MotherStack(MotherStack.IndexOf(activite.WorkingValue)) = Habilitated
                    Case Else
                        Throw New Lamentation("how the fucl", 42)
                End Select
            End With
        ElseIf TypeOf act Is Context Then
            Dim todo As Context = act
            For Each thing As IContextualisable In todo
                Curse(thing)
            Next
        End If
    End Sub

End Module