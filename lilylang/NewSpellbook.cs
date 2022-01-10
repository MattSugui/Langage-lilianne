//#define OrbPonderingTime
//#define TemporaryTokenTestingTime // test for recognising patterns

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New;

public static partial class Interpreter
{

    /// <summary>
    /// The lexer and parser components of the interpreter.
    /// </summary>
    public static partial class Spellbook
    {
        /// <summary>
        /// The currently-registered tokens.
        /// </summary>
        public static List<Token> CurrentTokens = new();

        /// <summary>
        /// The currently-registered sentence structures.
        /// </summary>
        public static List<SentenceStructure> CurrentSentenceStructures = new();

        /// <summary>
        /// A token.
        /// </summary>
        [Serializable]
        public class Token
        {
            /// <summary>
            /// The name of the token.
            /// </summary>
            public string Name;

            /// <summary>
            /// The token itself.
            /// </summary>
            public string Value;

            /// <summary>
            /// Looks for similar characters or instances that share the same pattern for solidification.
            /// </summary>
            public bool Look;

            /// <summary>
            /// If true, this token will be removed from the parse tree.
            /// </summary>
            public bool IgnoreOnRefinement;
        }

        /// <summary>
        /// A tokenised instance.
        /// </summary>
        [Serializable]
        public class TokenFruit
        {
            /// <summary>
            /// The token it is associated with.
            /// </summary>
            public Token AssociatedToken;

            /// <summary>
            /// The token itself.
            /// </summary>
            public string Value;

            /// <summary>
            /// Returns the string representation of the token.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString() => $"{AssociatedToken.Name}: '{Value}'";
        }

        /// <summary>
        /// A sentence structure.
        /// </summary>
        [Serializable]
        public class SentenceStructure
        {
            /// <summary>
            /// The name of the feature.
            /// </summary>
            public string Name;

            /// <summary>
            /// The arrangement of tokens in this structure.
            /// </summary>
            public string[] TokenStruct;

            /// <summary>
            /// Where the values are taken from.
            /// </summary>
            public int[] PointersToValues;

            /// <summary>
            /// Unused
            /// </summary>
            [Obsolete("Not used at the moment")]
            public int Code;
        }

        [Serializable]
        public class SentenceFruit
        {
            public SentenceStructure AssociatedSentence;
            public string[] Value;
        }
    }

    /// <summary>
    /// The current line as tokens.
    /// </summary>
    public static List<TokenFruit> CurrentWords = new();

    /// <summary>
    /// The current token bunches.
    /// </summary>
    public static List<List<TokenFruit>> CurrentWordPacks = new();

    /// <summary>
    /// The current sentences.
    /// </summary>
    public static List<SentenceFruit> CurrentSentences = new();

    /// <summary>
    /// Scans a line into tokens.
    /// </summary>
    /// <param name="line">The line.</param>
    /// <exception cref="Lamentation"></exception>
    internal static void ScanTokens(string line)
    {
    Start:
        bool comment = false;
        if (string.IsNullOrWhiteSpace(line)) return;

        StringBuilder currentWord = new();

        for (int i = 0; i < line.Length; i++)
        {
            CurrentLine.Append(line[i]);
            currentWord.Append(line[i]);
            if (currentWord.ToString() == "//")
            {
                comment = true;
                break;
            }
            if (CurrentTokens.Locate(tok => Regex.IsMatch(currentWord.ToString(), tok.Value, RegexOptions.IgnoreCase), out Token token))
            {
                if (token.Look)
                {
                    int j = i + 1;
                    string future = currentWord.ToString() + line[j];
                    bool confirm = 
                        CurrentTokens.Locate(tok => Regex.IsMatch(future, tok.Value, RegexOptions.IgnoreCase), out Token temp)
                        && temp.Name == token.Name;
                    if (confirm) continue;
                    else
                    {
                        CurrentWords.Add(new() { AssociatedToken = token, Value = currentWord.ToString() });
                        currentWord.Clear();
                        continue;
                    }
                }
                else
                {
                    CurrentWords.Add(new() { AssociatedToken = token, Value = currentWord.ToString() });
                    currentWord.Clear();
                    continue;
                }
            }
            else
            {
                if (CurrentLine.Length < line.Length) continue; else throw new Lamentation(2, currentWord.ToString());
            }
        }
        
        if (CurrentWords.Count > 0) CurrentWordPacks.Add(new(CurrentWords));
        CurrentWords.Clear();
        string temp2 = CurrentLine.ToString();
        CurrentLine.Clear();
        if (!string.IsNullOrWhiteSpace(line.Replace(temp2, string.Empty)) && !comment) goto Start; else return;
    }

    /// <summary>
    /// Arranges tokens into sentences.
    /// </summary>
    /// <param name="bunch">The bunch.</param>
    /// <exception cref="Lamentation"></exception>
    internal static void ArrangeTokens(List<TokenFruit> bunch)
    {
        List<string> @struct = new();
        List<TokenFruit> other = new();
        int removed = 0;

        foreach (TokenFruit fruit in bunch)
        {
            if (fruit.AssociatedToken.IgnoreOnRefinement) { removed++; continue; }
            @struct.Add(fruit.AssociatedToken.Name);
            other.Add(fruit);
            if (CurrentSentenceStructures.Exists(thing => thing.TokenStruct.SequenceEqual(@struct.ToArray())))
            {
                List<string> values = new();
                foreach (TokenFruit fruit1 in other) values.Add(fruit1.Value);
                CurrentSentences.Add(new() { AssociatedSentence = CurrentSentenceStructures.Find(thing => thing.TokenStruct.SequenceEqual(@struct.ToArray())), Value = values.ToArray() });
            }
            else
            {
                if (@struct.Count - removed != bunch.Count) continue; else throw new Lamentation(2);
            }
        }
    }

    /// <summary>
    /// Obsolete. Use InterpretSentenceNew.
    /// </summary>
    /// <param name="sent">no.</param>
    /// <exception cref="NotImplementedException"></exception>
    [Obsolete("Use InterpretSentenceNew.")]
    internal static void InterpretSentence(SentenceFruit sent)
    {
        throw new NotImplementedException("Use InterpretSentenceNew.");
    }

    /// <summary>
    /// Interprets a statement. (New stack-based method)
    /// </summary>
    /// <param name="sent">The sentence.</param>
    /// <exception cref="Lamentation"></exception>
    internal static void InterpretSentenceNew(SentenceFruit sent)
    {
        switch (sent.Value[0])
        {
            case "push":
                dynamic val;
                if (bool.TryParse(sent.Value[1], out bool val1)) val = val1;
                else if (sbyte.TryParse(sent.Value[1], out sbyte val2)) val = val2;
                else if (byte.TryParse(sent.Value[1], out byte val3)) val = val3;
                else if (short.TryParse(sent.Value[1], out short val4)) val = val4;
                else if (ushort.TryParse(sent.Value[1], out ushort val5)) val = val5;
                else if (int.TryParse(sent.Value[1], out int val6)) val = val6;
                else if (uint.TryParse(sent.Value[1], out uint val7)) val = val7;
                else if (long.TryParse(sent.Value[1], out long val8)) val = val8;
                else if (ulong.TryParse(sent.Value[1], out ulong val9)) val = val9;
                else if (Half.TryParse(sent.Value[1], out Half valA)) val = valA;
                else if (float.TryParse(sent.Value[1], out float valB)) val = valB;
                else if (double.TryParse(sent.Value[1], out double valC)) val = valC;
                else if (decimal.TryParse(sent.Value[1], out decimal valD)) val = valD;
                else if (char.TryParse(sent.Value[1], out char valE)) val = valE;
                else if (sent.Value[1].Contains('"')) val = sent.Value[1].Trim('"');
                else val = null;
                CurrentEffects.Add(new(FELActionType.push, val));
                //throw new Lamentation(0x16, "types other than int and string")
                break;
            case "print":
                CurrentEffects.Add(new(FELActionType.print));
                break;
            case "pop":
                CurrentEffects.Add(new(FELActionType.pop));
                break;
            case "add":
                CurrentEffects.Add(new(FELActionType.add));
                break;
            case "subtract":
                CurrentEffects.Add(new(FELActionType.sub));
                break;
            case "multiply":
                CurrentEffects.Add(new(FELActionType.mul));
                break;
            case "divide":
                CurrentEffects.Add(new(FELActionType.div));
                break;
            case "remainder":
                CurrentEffects.Add(new(FELActionType.mod));
                break;
            case "lshift":
                CurrentEffects.Add(new(FELActionType.lst));
                break;
            case "rshift":
                CurrentEffects.Add(new(FELActionType.rst));
                break;
            case "and":
                CurrentEffects.Add(new(FELActionType.and));
                break;
            case "or":
                CurrentEffects.Add(new(FELActionType.or));
                break;
            case "xor":
                CurrentEffects.Add(new(FELActionType.xor));
                break;
            case "store":
                CurrentEffects.Add(new(
                    FELActionType.store,
                    sent.Value[1].StartsWith('#') ? sent.Value[1].TrimStart('#') :
                    (sent.Value[1].StartsWith('&') ? 
                        (int.TryParse(sent.Value[1].TrimStart('&'), out int add) ? add : throw new Lamentation(0x21, sent.Value[1])) :
                        throw new Lamentation()
                    )));
                break;
            case "load":
                CurrentEffects.Add(new(
                    FELActionType.load,
                    sent.Value[1].StartsWith('#') ? sent.Value[1].TrimStart('#') :
                    (sent.Value[1].StartsWith('&') ?
                        (int.TryParse(sent.Value[1].TrimStart('&'), out int poi) ? poi : throw new Lamentation(0x21, sent.Value[1])) :
                        throw new Lamentation()
                    )));
                break;
            case "beq":
                CurrentEffects.Add(new(
                    FELActionType.beq,
                    int.TryParse(sent.Value[1], out int z1) ? z1 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "bne":
                CurrentEffects.Add(new(
                    FELActionType.bne,
                    int.TryParse(sent.Value[1], out int z2) ? z2 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "bgt":
                CurrentEffects.Add(new(
                    FELActionType.bgt,
                    int.TryParse(sent.Value[1], out int z3) ? z3 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "bge":
                CurrentEffects.Add(new(
                    FELActionType.bge,
                    int.TryParse(sent.Value[1], out int z4) ? z4 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "blt":
                CurrentEffects.Add(new(
                    FELActionType.blt,
                    int.TryParse(sent.Value[1], out int z5) ? z5 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "ble":
                CurrentEffects.Add(new(
                    FELActionType.beq,
                    int.TryParse(sent.Value[1], out int z6) ? z6 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "btr":
                CurrentEffects.Add(new(
                    FELActionType.btr,
                    int.TryParse(sent.Value[1], out int z7) ? z7 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "bfl":
                CurrentEffects.Add(new(
                    FELActionType.bfl,
                    int.TryParse(sent.Value[1], out int z8) ? z8 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "bsa":
                CurrentEffects.Add(new(
                    FELActionType.bsa,
                    int.TryParse(sent.Value[1], out int z9) ? z9 : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "bso":
                CurrentEffects.Add(new(
                    FELActionType.bso,
                    int.TryParse(sent.Value[1], out int zA) ? zA : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "goto":
                CurrentEffects.Add(new(
                    FELActionType.@goto,
                    int.TryParse(sent.Value[1], out int zB) ? zB : throw new Lamentation(0x21, sent.Value[1])
                    ));
                break;
            case "end":
                CurrentEffects.Add(new(FELActionType.end));
                break;
            case "take":
                CurrentEffects.Add(new(FELActionType.take));
                break;
            case "ask":
                CurrentEffects.Add(new(FELActionType.ask));
                break;
            case "narrow":
                CurrentEffects.Add(new(FELActionType.narrow));
                break;
            case "widen":
                CurrentEffects.Add(new(FELActionType.widen));
                break;
            case "realise":
                CurrentEffects.Add(new(FELActionType.realise));
                break;
        }
    }
}

public static partial class Extensions
{
    /// <summary>
    /// Does the <see cref="List{T}.Exists(Predicate{T})"/> method on a list and also returns the object found.
    /// This is essentially a <see cref="List{T}"/> version of the TryParse method which returns bool but also
    /// returns the result.
    /// </summary>
    /// <typeparam name="T">The type of the objects that the list has.</typeparam>
    /// <param name="list">The list itself.</param>
    /// <param name="match">The predicate for use with the <see cref="List{T}.Exists(Predicate{T})"/> method used in this method.</param>
    /// <param name="obj"></param>
    /// <returns><see langword="true"/> if the object exists, otherwise, false.<br/>
    /// Returns <paramref name="obj"/> that is found in the list if true, otherwise, the <see langword="default"/> value.</returns>
    public static bool Locate<T>(this List<T> list, Predicate<T> match, out T obj)
    {
        if (list.Count == 0) { obj = default; return false; }

        if (list.Exists(match)) { obj = list.Find(match); return true; } else { obj = default; return false; }
    }

    /// <summary>
    /// Checks if a <see cref="List{T}"/> is empty.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">The list.</param>
    /// <returns>true if empty, false if it contains something.</returns>
    public static bool IsEmpty<T>(this List<T> list) => list.Count == 0;
}