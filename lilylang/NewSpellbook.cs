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

            public override string ToString() => $"{AssociatedToken.Name}: '{Value}'";
        }

        [Serializable]
        public class SentenceStructure
        {
            public string Name;
            public string[] TokenStruct;
            public int[] PointersToValues;
            public int Code;
        }

        [Serializable]
        public class SentenceFruit
        {
            public SentenceStructure AssociatedSentence;
            public string[] Value;
        }
    }

    public static List<TokenFruit> CurrentWords = new();
    public static List<List<TokenFruit>> CurrentWordPacks = new();
    public static List<SentenceFruit> CurrentSentences = new();

    internal static void ScanTokens(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return;

        StringBuilder currentWord = new();



        for (int i = 0; i < line.Length; i++)
        {
            CurrentLine.Append(line[i]);
            currentWord.Append(line[i]);
#if TemporaryTokenTestingTime
                WriteLine(currentWord.ToString());
#endif

            if (currentWord.ToString() == "//") break; // comment!

            /*
            foreach (Token tok in CurrentTokens)
            {
                if (Regex.IsMatch(currentWord.ToString(), tok.Value, RegexOptions.IgnoreCase))
                {
                    CurrentWords.Add(new(tok, currentWord.ToString()));
                    currentWord.Clear();
                    break;
                }
                else
                {
                    if ((CurrentTokens.IndexOf(tok) != CurrentTokens.Count - 1) || (CurrentLine.Length < line.Length)) continue;
                    else throw new Lamentation(2, currentWord.ToString());
                }

            }*/

            if (CurrentTokens.Locate(tok => Regex.IsMatch(currentWord.ToString(), tok.Value, RegexOptions.IgnoreCase), out Token token))
            {
                if (token.Look)
                {
                    int j = i + 1;
                    string future = currentWord.ToString() + line[j];
                    bool confirm = 
                        CurrentTokens.Locate(tok => Regex.IsMatch(future, tok.Value, RegexOptions.IgnoreCase), out Token temp)
                        && temp.Name == token.Name;
#if DEBUG
                    Debug.Write(future + "\n");
                    Debug.Write(temp?.Name ?? "The current token doesn't match anything (yet)\n");
                    Debug.Write(confirm);
#endif

                    if (confirm)
                    {
                        continue;
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
                if (CurrentLine.Length < line.Length) continue; else throw new Lamentation(2, currentWord.ToString());
            }
        }

        CurrentLine.Clear();
#if TemporaryTokenTestingTime
            foreach (TokenFruit token in CurrentWords) WriteLine(token.ToString());
#endif
        if (CurrentWords.Count > 0) CurrentWordPacks.Add(new(CurrentWords));
        CurrentWords.Clear();
    }

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

    internal static void InterpretSentence(SentenceFruit sent)
    {
        if (CurrentStatements.Exists(state => state.AssociatedStructure == sent.AssociatedSentence.Name))
        {
            CurrentInstructions.Add(CurrentInstructions.Count - 1, new() { AssociatedFruit = sent, AssociatedStatement = CurrentStatements.Find(state => state.AssociatedStructure == sent.AssociatedSentence.Name) });
        }
        else if (sent.AssociatedSentence.Code == -1) return; //skip
        else throw new Lamentation(14, sent.AssociatedSentence.Name);
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

    public static bool IsEmpty<T>(this List<T> list) => list.Count == 0;
}