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
        CurrentTokens.Add(new() { Name = "IDNT", Value = @"^#[A-Za-z][0-9A-Za-z]*$", Look = true });
        CurrentTokens.Add(new() { Name = "ADDR", Value = @"^\&[0-9]+$", Look = true });
        CurrentTokens.Add(new() { Name = "EQUL", Value = @"^=$" });

        CurrentTokens.Add(new() { Name = "PUSH", Value = @"^push$" });
        CurrentTokens.Add(new() { Name = "POP", Value = @"^pop$" });
        CurrentTokens.Add(new() { Name = "ADDO", Value = @"^add$" });
        CurrentTokens.Add(new() { Name = "SUBO", Value = @"^subtract$" });
        CurrentTokens.Add(new() { Name = "MULO", Value = @"^multiply$" });
        CurrentTokens.Add(new() { Name = "DIVO", Value = @"^divide$" });
        CurrentTokens.Add(new() { Name = "MODO", Value = @"^remainder$" });
        CurrentTokens.Add(new() { Name = "LSFT", Value = @"^lshift$" });
        CurrentTokens.Add(new() { Name = "RSFT", Value = @"^rshift$" });
        CurrentTokens.Add(new() { Name = "STOR", Value = @"^store$" });
        CurrentTokens.Add(new() { Name = "LOAD", Value = @"^load$" });

        //CurrentSentenceStructures.Add(new() { Name = "PrintString", Code = 1, PointersToValues = new int[] { 1 }, TokenStruct = new string[] { "PRNT", "QUOT", "SMCL" } });
        //CurrentSentenceStructures.Add(new() { Name = "PrintInteger", Code = 1, PointersToValues = new int[] { 1 }, TokenStruct = new string[] { "PRNT", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "StartPreprocess", Code = -1, PointersToValues = null, TokenStruct = new string[] { "PRPR", "COLN" } });
        CurrentSentenceStructures.Add(new() { Name = "EndPreprocess", Code = -1, PointersToValues = null, TokenStruct = new string[] { "STRT", "SMCL" } });
        //CurrentSentenceStructures.Add(new() { Name = "LetString", Code = 2, PointersToValues = new int[] { 1, 3 }, TokenStruct = new string[] { "LET", "IDNT", "EQUL", "QUOT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushString", TokenStruct = new string[] { "PUSH", "QUOT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushIntegral", TokenStruct = new string[] { "PUSH", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Pop", TokenStruct = new string[] { "POP", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Print", TokenStruct = new string[] { "PRNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Add", TokenStruct = new string[] { "ADDO", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Subtract", TokenStruct = new string[] { "SUBO", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Multiply", TokenStruct = new string[] { "MULO", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Divide", TokenStruct = new string[] { "DIVO", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Modulus", TokenStruct = new string[] { "MODO", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "LeftShift", TokenStruct = new string[] { "LSFT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "RightShift", TokenStruct = new string[] { "RSFT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "StoreIndex", TokenStruct = new string[] { "STOR", "ADDR", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "StoreNamed", TokenStruct = new string[] { "STOR", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "LoadIndex", TokenStruct = new string[] { "LOAD", "ADDR", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "LoadNamed", TokenStruct = new string[] { "LOAD", "IDNT", "SMCL" } });

        //CurrentActions.Add(1, new((object val, object ign) => WriteLine(val)));
        //CurrentActions.Add(2, new((object name, object val) => CurrentObjects.Push(new(CurrentObjects.Count - 1, (string)name, val))));

        CurrentStatements.Add(new() { AssociatedStructure = "PrintString", AssociatedAction = 1 });
        CurrentStatements.Add(new() { AssociatedStructure = "PrintInteger", AssociatedAction = 1 });
        CurrentStatements.Add(new() { AssociatedStructure = "LetString", AssociatedAction = 2 });
        //CurrentSentenceStructures.Add(new("SingleLineComm", "TOSL", "ANY?"));
    }

}

