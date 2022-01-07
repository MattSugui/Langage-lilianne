''' <summary>
''' The grammatical feature constants.
''' </summary>
Public Module GrammarFeatureConstants
    'Public Const Condition As String = "(?<LeftOperand>[0-9A-Za-z]+|"".+"")\s(?<Operator>=|\<\>|\<|\>|\<=|\>=|Is|IsNot|Or|Or)\s(?<RightOperand>[0-9A-Za-z]+|"".+"")"
    REM Mapping:
    ' 0 to 12: Coco statements as added in October 2021
    ' 13: uhh i don't know
    ' 14: Test for Lilian intercoms (the same as a string version of feature 8 "Print ""|0-9|Identifier"). It creates a "print" statement and sends it to Lilian.
    ' 15: Schema

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
        "^\s*Write\s(?<Value>"".*"")",
        "\s*Token\s(?<Name>[^\s]+)\s*$"
    }
End Module