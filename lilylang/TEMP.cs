namespace fonder.Lilian.New;

public static class TEMP
{
    public static void LOADPATTERNS()
    {
        CurrentTokens.Add(new() { Name = "PRNT", Value = "^print$" });
        CurrentTokens.Add(new() { Name = "QUOT", Value = @"^"".*""$" });
        CurrentTokens.Add(new() { Name = "INTL", Value = @"^[0-9]+$", Look = true });
        CurrentTokens.Add(new() { Name = "SMCL", Value = @"^;$" });
        CurrentTokens.Add(new() { Name = "COLN", Value = @"^:$" });
        //CurrentTokens.Add(ne) { Name = w("ANY" Value =, @".", true));
        CurrentTokens.Add(new() { Name = "WTSP", Value = @"^\s$", Look = true, IgnoreOnRefinement = true });
        CurrentTokens.Add(new() { Name = "PRPR", Value = @"^preprocess$" });
        CurrentTokens.Add(new() { Name = "STRT", Value = @"^start$" });
        //CurrentTokens.Add(new("TOSL", @"\/\/"));
        CurrentTokens.Add(new() { Name = "LET",  Value = @"^let$" });

        CurrentSentenceStructures.Add(new() { Name = "PrintString", Code = 1, PointersToValues = new int[] { 1 }, TokenStruct = new string[] { "PRNT", "QUOT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PrintInteger", Code = 1, PointersToValues = new int[] { 1 }, TokenStruct = new string[] { "PRNT", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "StartPreprocess", Code = -1, PointersToValues = null, TokenStruct = new string[] { "PRPR", "COLN" } });
        CurrentSentenceStructures.Add(new() { Name = "EndPreprocess", Code = -1, PointersToValues = null, TokenStruct = new string[] { "STRT", "SMCL" } });

        CurrentActions.Add(1, (string val) => WriteLine(val));

        CurrentStatements.Add(new() { AssociatedStructure = "PrintString", AssociatedAction = 1 });
        //CurrentSentenceStructures.Add(new("SingleLineComm", "TOSL", "ANY?"));
    }

}

