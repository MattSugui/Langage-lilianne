//#define OrbPonderingTime
#define TemporaryTokenTestingTime // test for recognising patterns

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

            public struct Token
            {
                public Token(string name, string value, bool lookahead = false, bool ignore = false)
                {
                    Name = name;
                    Value = value;
                    Look = lookahead;
                    IgnoreOnRefinement = ignore;
                }
                public string Name { get; }
                public string Value { get; }
                public bool Look { get; }
                public bool IgnoreOnRefinement { get; }
            }

            public struct TokenFruit
            {
                public TokenFruit(Token assc, string value)
                {
                    AssociatedToken = assc;
                    Value = value;
                }
                public Token AssociatedToken { get; }
                public string Value { get; }
            }

            public class SentenceStructure
            {
                public SentenceStructure(string name, params string[] tokenstruct)
                {
                    Name = name;
                    TokenStruct = tokenstruct;
                }

                public virtual string Name { get; }
                public virtual string[] TokenStruct { get; }
            }
            public sealed class SentenceCollectionStructure: SentenceStructure
            {
                public SentenceCollectionStructure(string name, params string[] tokenstruct): base(name, tokenstruct) { }
            }
        }

        public static List<TokenFruit> CurrentWords = new();
        public static List<List<TokenFruit>> CurrentWordPacks = new();
    
        internal static void ScanTokens(string line)
        {
            if (string.IsNullOrWhiteSpace(line)) return;

            StringBuilder currentWord = new();
            
            foreach (char character in line)
            {
                CurrentLine.Append(character);
                currentWord.Append(character);
                WriteLine(currentWord.ToString());

                if (currentWord.ToString() == "//") break; // comment!
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
                }
            }

            CurrentLine.Clear();
#if TemporaryTokenTestingTime
            foreach (TokenFruit token in CurrentWords) WriteLine(token.ToString());
#endif 
            if (CurrentWords.Count > 0) CurrentWordPacks.Add(CurrentWords);
            CurrentWords.Clear();
        }

        internal static void ArrangeTokens()
        {

        }
    }
}