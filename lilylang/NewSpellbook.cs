//#define OrbPonderingTime
//#define TemporaryTokenTestingTime // test for recognising patterns

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using static fonder.Lilian.New.Interpreter;
using static fonder.Lilian.New.Interpreter.Spellbook;
using static fonder.Lilian.New.Interpreter.Actualiser;
using static System.Console;

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New
{
    public static partial class Interpreter
    {

        /// <summary>
        /// The lexer and parser components of the interpreter.
        /// </summary>
        public static partial class Spellbook
        {
            public static List<Token> CurrentTokens = new();
            public static List<SentenceStructure> CurrentSentenceStructures = new();

            [Serializable]
            public class Token
            {
                public Token(string name, string value, bool lookahead = false, bool ignore = false)
                {
                    Name = name;
                    Value = value;
                    Look = lookahead;
                    IgnoreOnRefinement = ignore;
                }
                public string Name;
                public string Value;
                public bool Look;
                public bool IgnoreOnRefinement;
            }

            [Serializable]
            public class TokenFruit
            {
                public TokenFruit(Token assc, string value)
                {
                    AssociatedToken = assc;
                    Value = value;
                }
                public Token AssociatedToken;
                public string Value;

                public override string ToString() => $"{AssociatedToken.Name}: '{Value}'";
            }

            [Serializable]
            public class SentenceStructure
            {
                public SentenceStructure(string name, int code, int[] points, string[] tokenstruct)
                {
                    Name = name;
                    TokenStruct = tokenstruct;
                    Code = code;
                    PointersToValues = points;
                }

                public string Name;
                public string[] TokenStruct;
                public int[] PointersToValues;
                public int Code;
            }

            [Serializable]
            public class SentenceFruit
            {
                public SentenceFruit(SentenceStructure structure, string[] tokens)
                {
                    AssociatedSentence = structure;
                    Value = tokens;
                }

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
            
            foreach (char character in line)
            {
                CurrentLine.Append(character);
                currentWord.Append(character);
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

                if (CurrentTokens.Exists(tok => Regex.IsMatch(currentWord.ToString(), tok.Value, RegexOptions.IgnoreCase)))
                {
                    CurrentWords.Add(new(CurrentTokens.Find(tok => Regex.IsMatch(currentWord.ToString(), tok.Value, RegexOptions.IgnoreCase)), currentWord.ToString()));
                    currentWord.Clear();
                    continue;
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
                    CurrentSentences.Add(new(CurrentSentenceStructures.Find(thing => thing.TokenStruct.SequenceEqual(@struct.ToArray())), values.ToArray()));
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
                CurrentInstructions.Add(CurrentInstructions.Count - 1, new(sent, CurrentStatements.Find(state => state.AssociatedStructure == sent.AssociatedSentence.Name)));
            }
            else throw new Lamentation(14, sent.AssociatedSentence.Name);
        }
    }
}