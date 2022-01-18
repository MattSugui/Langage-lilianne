#pragma warning disable CA2211

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

            /// <summary>
            /// If true, this token will end the scanning for that instruction and moves onto another.
            /// </summary>
            public bool Terminate;
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

        /// <summary>
        /// The result of a sentence.
        /// </summary>
        [Serializable]
        public class SentenceFruit
        {
            /// <summary>
            /// The associated sentence structure.
            /// </summary>
            public SentenceStructure AssociatedSentence;

            /// <summary>
            /// The tokens of the sentence for data collection.
            /// </summary>
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
        string bruh = line;
    Start:
        bool comment = false;
        if (string.IsNullOrWhiteSpace(line)) return;

        StringBuilder currentWord = new();

        for (int i = 0; i < bruh.Length; i++)
        {
            CurrentLine.Append(bruh[i]);
            currentWord.Append(bruh[i]);
            if (currentWord.ToString() == "//")
            {
                comment = true;
                break;
            }
            if (CurrentTokens.Locate(tok => Regex.IsMatch(currentWord.ToString(), tok.Value, RegexOptions.IgnoreCase), out Token token))
            {
                if (token.Look)
                {
                    if (i < bruh.Length - 1)
                    {
                        int j = i + 1;
                        string future = currentWord.ToString() + bruh[j];
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
                    CurrentWords.Add(new() { AssociatedToken = token, Value = currentWord.ToString() });
                    currentWord.Clear();
                    continue;
                }
            }
            else
            {
                if (CurrentLine.Length < bruh.Length) continue; else throw new Lamentation(2, currentWord.ToString());
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
        List<TokenFruit> tokenFruits = bunch;
        List<TokenFruit> otherFruits = new(tokenFruits);
        List<string> @struct = new();
        List<TokenFruit> other = new();
        int removed = 0;

    Start:
        tokenFruits = new(otherFruits);
        foreach (TokenFruit fruit in tokenFruits)
        {
            if (fruit.AssociatedToken.IgnoreOnRefinement) { removed++; continue; }
            @struct.Add(fruit.AssociatedToken.Name);
            other.Add(fruit);
            if (CurrentSentenceStructures.Exists(thing => thing.TokenStruct.SequenceEqual(@struct.ToArray())))
            {
                List<string> values = new();
                foreach (TokenFruit fruit1 in other)
                {
                    values.Add(fruit1.Value);
                    otherFruits.Remove(fruit1);
                }
                CurrentSentences.Add(new() { AssociatedSentence = CurrentSentenceStructures.Find(thing => thing.TokenStruct.SequenceEqual(@struct.ToArray())), Value = values.ToArray() });
            }
            else
            {
                if (@struct.Count - removed != bunch.Count) continue; else throw new Lamentation(2);
            }
        }

        if (tokenFruits.Count != 0) goto Start; else return;

    }

    /// <summary>
    /// Interprets a statement. (New stack-based method)
    /// </summary>
    /// <param name="sent">The sentence.</param>
    /// <exception cref="Lamentation"></exception>
    internal static FELAction InterpretSentenceNew(SentenceFruit sent)
    {
        switch (sent.Value[0])
        {
            case "think":
                return new();
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
                return new(FELActionType.push, val);
                //throw new Lamentation(0x16, "types other than int and string")
            case "print":
                return new(FELActionType.print);
            case "pop":
                return new(FELActionType.pop);
            case "add":
                return new(FELActionType.add);
            case "subtract":
                return new(FELActionType.sub);
            case "multiply":
                return new(FELActionType.mul);
            case "divide":
                return new(FELActionType.div);
            case "remainder":
                return new(FELActionType.mod);
            case "lshift":
                return new(FELActionType.lst);
            case "rshift":
                return new(FELActionType.rst);
            case "and":
                return new(FELActionType.and);
            case "or":
                return new(FELActionType.or);
            case "xor":
                return new(FELActionType.xor);
            case "store":
                return new(
                    FELActionType.store,
                    sent.Value[1].StartsWith('#') ? sent.Value[1].TrimStart('#') :
                    (sent.Value[1].StartsWith('&') ? 
                        (int.TryParse(sent.Value[1].TrimStart('&'), out int add) ? add : throw new Lamentation(0x21, sent.Value[1])) :
                        throw new Lamentation()
                    ));
            case "load":
                return new(
                    FELActionType.load,
                    sent.Value[1].StartsWith('#') ? sent.Value[1].TrimStart('#') :
                    (sent.Value[1].StartsWith('&') ?
                        (int.TryParse(sent.Value[1].TrimStart('&'), out int poi) ? poi : throw new Lamentation(0x21, sent.Value[1])) :
                        throw new Lamentation()
                    ));
            case "beq":
                return new(
                    FELActionType.beq,
                    int.TryParse(sent.Value[1], out int z1) ? z1 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "bne":
                return new(
                    FELActionType.bne,
                    int.TryParse(sent.Value[1], out int z2) ? z2 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "bgt":
                return new(
                    FELActionType.bgt,
                    int.TryParse(sent.Value[1], out int z3) ? z3 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "bge":
                return new(
                    FELActionType.bge,
                    int.TryParse(sent.Value[1], out int z4) ? z4 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "blt":
                return new(
                    FELActionType.blt,
                    int.TryParse(sent.Value[1], out int z5) ? z5 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "ble":
                return new(
                    FELActionType.beq,
                    int.TryParse(sent.Value[1], out int z6) ? z6 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "btr":
                return new(
                    FELActionType.btr,
                    int.TryParse(sent.Value[1], out int z7) ? z7 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "bfl":
                return new(
                    FELActionType.bfl,
                    int.TryParse(sent.Value[1], out int z8) ? z8 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "bsa":
                return new(
                    FELActionType.bsa,
                    int.TryParse(sent.Value[1], out int z9) ? z9 : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "bso":
                return new(
                    FELActionType.bso,
                    int.TryParse(sent.Value[1], out int zA) ? zA : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "goto":
                return new(
                    FELActionType.@goto,
                    int.TryParse(sent.Value[1], out int zB) ? zB : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "end":
                return new(FELActionType.end);
            case "take":
                return new(FELActionType.take);
            case "ask":
                return new(FELActionType.ask);
            case "narrow":
                return new(FELActionType.narrow);
            case "widen":
                return new(FELActionType.widen);
            case "realise":
                return new(FELActionType.realise);
            case "catch":
                return new(
                    FELActionType.@catch,
                    int.TryParse(sent.Value[1], out int zC) ? zC : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "call":
                if (sent.Value[1].StartsWith('@'))
                    return new(
                        FELActionType.gotolabel,
                        sent.Value[1].TrimStart('@')
                        );
                else return new(
                    FELActionType.@call,
                    int.TryParse(sent.Value[1], out int zD) ? zD : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "return":
                return new(FELActionType.@return);
            case "throw":
                dynamic exval = null;
                if (sent.Value.Length == 2)
                {
                    if (int.TryParse(sent.Value[1], out int exval6)) exval = exval6;
                    else if (sent.Value[1].Contains('"')) exval = sent.Value[1].Trim('"');
                }
                else exval = null;
                return new(exval is not null? FELActionType.@throwc : FELActionType.@throw, exval);
            case "title":
                return new(FELActionType.settitle, sent.Value[1].Trim('"'));
            case "pause":
                return new(
                    FELActionType.pause,
                    int.TryParse(sent.Value[1], out int zE) ? zE : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "wait":
                return new(FELActionType.wait);
            default:
                if (sent.Value[0].StartsWith('@'))
                    return new(
                        FELActionType.label,
                        sent.Value[0].TrimStart('@')
                        );
                else
                    throw new Lamentation(0x16, string.Join(' ', sent.Value));
        }
    }

    /// <summary>
    /// Places an action or effect intp the list.
    /// </summary>
    /// <param name="effect">The action.</param>
    /// <param name="index">The location.</param>
    /// <param name="overwrite">If false, the item will be inserted at that location. If true, the item at that location will be overwritten by the new one.</param>
    public static void PlaceEffect(FELAction effect, int index = -1, bool overwrite = true)
    {
        if (overwrite && index != -1)
        {
            if (index >= CurrentEffects.Count) CurrentEffects.Add(effect);
            else CurrentEffects[index] = effect;
        }
        else CurrentEffects.Insert(index != -1 ? index : CurrentEffects.Count, effect);
    }

    /// <summary>
    /// Checks the <see cref="CurrentEffects"/> list for any labels and replaces them with their physical addresses instead.
    /// </summary>
    internal static void CheckForFriendlyNames()
    {
        (FELAction label, FELAction pointer) = (default, default);
        (int labelloc, int pointerloc) = (0, 0);
        List<(int, int)> pairLocations = new();

        Dictionary<string, int> AssociatedLabels = new();

        int currentEffect = 0;
        while (CurrentEffects.Exists(a => a.ActionType == FELActionType.label) || CurrentEffects.Exists(a => a.ActionType == FELActionType.gotolabel))
        {
            switch (CurrentEffects[currentEffect].ActionType)
            {
                case FELActionType.label:
                    label = CurrentEffects[currentEffect];
                    labelloc = currentEffect;
                    CurrentEffects[labelloc] = new(FELActionType.nop);
                    AssociatedLabels.Add((string)label.Value!, currentEffect);
                    break;
                case FELActionType.gotolabel:
                    pointer = CurrentEffects[currentEffect];
                    pointerloc = currentEffect;
                    // if (AssociatedLabels.ContainsKey(pointerloc))
                    if (AssociatedLabels.ContainsKey((string)pointer.Value!))
                    {
                        CurrentEffects[pointerloc] = new(FELActionType.call, AssociatedLabels[(string)pointer.Value!]);
                        if (!CurrentEffects.Exists(a => a.ActionType == FELActionType.gotolabel && a.Value == (string)pointer.Value!)) AssociatedLabels.Remove((string)pointer.Value!);
                        break;
                    }
                    else
                    {
                        if (!CurrentEffects.Exists(a => a.ActionType == FELActionType.label)) throw new Lamentation(0x2b, CurrentEffects[pointerloc].ToString());
                        else break;
                    }
                default: break;
            }
            if (currentEffect < CurrentEffects.Count - 1) currentEffect++;
            else currentEffect = 0; // reset
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