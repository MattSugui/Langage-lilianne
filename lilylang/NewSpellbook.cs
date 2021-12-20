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
using static System.Console;

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New
{
    public static partial class Interpreter
    {
        /*
        public struct UniqueID
        {
            public UniqueID()
            {
                unchecked
                {
                    PrimaryDistinction = (ulong)(Math.Pow(new Random().Next(int.MinValue, int.MaxValue), new Random().Next(byte.MinValue, byte.MaxValue)));
                }
            }
            public ulong PrimaryDistinction { get; }
            public ulong SecondaryDistinction { get;}

        }
        */

        /// <summary>
        /// The main class for the tokeniser. Even though the actual tokeniser module is actually in the Interpreter class.
        /// </summary>
        public static class Tokeniser
        {
            /// <summary>
            /// Initialises the default tokens for Lilian. In a future update, the tokens will come from a file instead of being hard-coded in.
            /// </summary>
            static Tokeniser()
            {
#if OrbPonderingTime
                // CurrentTokens.Add(new Token("Word", @"^\b[^\s]+\b$"));

                //CurrentTokens.Add(new Token("PrintVerb", @"^print$"));

#else
                //
                CurrentTokens.Add(new Token("Catch-all", @"^.$", Token.InterpretationBracket.CatchAll));
                CurrentTokens.Add(new Token("Whitespace", @"^\s$", Token.InterpretationBracket.Character | Token.InterpretationBracket.Word | Token.InterpretationBracket.IgnoreAtSentenceLevel));
                CurrentTokens.Add(new Token("Letter", @"^[A-Za-z]$", Token.InterpretationBracket.Character, null, false, true));
                CurrentTokens.Add(new Token("Quotation mark", @"^""$", Token.InterpretationBracket.Character, null, true));
                CurrentTokens.Add(new Token("Terminator", @"^;$", Token.InterpretationBracket.Character | Token.InterpretationBracket.Word));
                CurrentTokens.Add(new Token("Print keyword", @"^print$", Token.InterpretationBracket.Word));
                //
                CurrentTokens.Add(new Token("String", @"^"".*""$", Token.InterpretationBracket.Word));
                //
                CurrentTokens.Add(new Token("Numeral", @"^[0-9]$", Token.InterpretationBracket.Character, null, false, true));
                //
                CurrentTokens.Add(new Token("Symbol", @"^[^0-9A-Za-z"";]$", Token.InterpretationBracket.Character));
                //
                CurrentTokens.Add(new Token("Number", @"^[0-9]+$", Token.InterpretationBracket.Word));
                CurrentTokens.Add(new Token("Identifier", @"^[A-Za-z][0-9A-Za-z]*$", Token.InterpretationBracket.Word));
                //
                CurrentTokens.Add(new Token("Comment", @"^\/\*.*\*\/$", Token.InterpretationBracket.Word, null, false, false, null, true));
                //CurrentTokens.Add(new Token("Comment line", @"^\/\/.*\n$", Token.InterpretationBracket.Word, null, false, false, null, true));
                //
                CurrentTokens.Add(new Token("Right bracket", @"^}$", Token.InterpretationBracket.Character));
                CurrentTokens.Add(new Token("Left bracket", @"^{$", Token.InterpretationBracket.Character));
                //
                CurrentTokens.Add(new Token("Begin keyword", @"^begin$", Token.InterpretationBracket.Word));
                CurrentTokens.Add(new Token("End keyword", @"^end$", Token.InterpretationBracket.Word));


                CurrentSentences.Add(new Sentence("Print statement with string", 0, "00000000-acee-2021-1216-174808000001", false, false, null, new int[] { 1 }, "Print keyword", "String", "Terminator"));
                CurrentSentences.Add(new Sentence("Print statement with integer", 0, "00000000-acee-2021-1216-174808000001", false, false, null, new int[] { 1 }, "Print keyword", "Number", "Terminator"));
                //
                //CurrentSentences.Add(new Sentence("Right bracket", 0, null, true, true, null, null, "Right bracket"));
                //CurrentSentences.Add(new Sentence("Left bracket", 0, null, true, false, "Right bracket", null, "Left bracket"));
                //CurrentSentences.Add(new Sentence("Print statement with identifier", 0, new int[] { 1 }, "Print keyword", "Identifier", "Terminator"));

                CurrentSentences.Add(new Sentence("Begin statement", 0, null, true, false, null, new int[] { 1 }, "Print keyword", "Number", "Terminator"));

                //CurrentScopes.Add(new Scope("Normal", null, new KindOfSentence(KindOfSentence.KindOfSentenceEnum.Anything | KindOfSentence.KindOfSentenceEnum.Unlimited)));
#endif
            }

            public interface ISentence
            {

            }

            /// <summary>
            /// The list of currently-loaded tokens.
            /// </summary>
            public static List<Token> CurrentTokens = new();

            /// <summary>
            /// The list of currently-loaded sentence tokens.
            /// </summary>
            public static List<Sentence> CurrentSentences = new();

            /// <summary>
            /// The list of currently-loaded scope types.
            /// </summary>
            public static List<Scope> CurrentScopes = new();

            /// <summary>
            /// The current level of the interpeter.
            /// </summary>
            #warning Currently the CurrentLevel field is useless in the current version.
            public static int CurrentLevel = 0;

            /// <summary>
            /// The currently-collected tokens from the tokeniser.
            /// </summary>
            public static List<TokenFruit> Orchard = new(); 

            /// <summary>
            /// what
            /// </summary>
            #warning I forgot what this does
            internal static List<TokenFruit> Basket = new();

            /// <summary>
            /// A character or word in code.
            /// </summary>
            public class Token : IEquatable<TokenFruit>, IEquatable<string>
            {
                /// <summary>
                /// Empty method for inheriters.
                /// </summary>
                public Token() { }
                
                /// <summary>
                /// Initialises a new token.
                /// </summary>
                /// <param name="name">The internal name for the token.</param>
                /// <param name="value">The regular expression of the token.</param>
                /// <param name="level">The level of the token.</param>
                /// <param name="origin">Where this token came from.</param>
                /// <param name="lock">If the token acts like a bracket character.</param>
                /// <param name="look">If the token is part of a word.</param>
                public Token(string name, string value, InterpretationBracket level, string origin = null, bool @lock = false, bool look = false, string id = null, bool ignore = false, bool mingle = false, string mingwith = null)
                {
                    Name = name;
                    Value = value;
                    Level = level;
                    SourceFile = origin;
                    LockUntilNextInstance = @lock;
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        bool result = Guid.TryParse(id, out instance);
                        if (!result) throw new Lamentation(9, Name);
                    }
                    else instance = Guid.NewGuid();                    
                    LookAhead = look;
                    Ignore = ignore;
                    Mingle = mingle;
                    MingleWith = mingwith;
                }
                /// <summary>
                /// The name of the token.
                /// </summary>
                public string Name { get; init; }

                /// <summary>
                /// The value of the token. It is a regular expression of the token.
                /// </summary>
                public string Value { get; set; }

                /// <summary>
                /// The current level this token is on.
                /// </summary>
                public InterpretationBracket Level { get; init; }

                /// <summary>
                /// Where this file is located. Unless marked as "default" in the implementation, this will return true if it is
                /// from somewhere else.
                /// </summary>
                public bool Original => !string.IsNullOrEmpty(SourceFile);

                /// <summary>
                /// Where this token was implemented.
                /// </summary>
                public string SourceFile { get; init; }

                /// <summary>
                /// If true, the tokeniser will look ahead for similar tokens, usually for grouping them into a single bigger token
                /// containing compatible smaller tokens. This one is for bracketed expressions.
                /// </summary>
                public bool LockUntilNextInstance { get; }

                /// <summary>
                /// Private field for InstanceID
                /// </summary>
                internal Guid instance;

                /// <summary>
                /// The ID of the token. Will either be randomly generated on runtime, or is defined from the implementation.
                /// </summary>
                internal Guid InstanceId => instance;

                /// <summary>
                /// If true, the tokeniser will look ahead for similar tokens, usually for grouping them into a single bigger token
                /// containing compatible smaller tokens. This one is for words such as identifiers and numbers.
                /// </summary>
                public bool LookAhead { get; }

                /// <summary>
                /// If true, this token will be disregarded and thrown away before the next stage starts. For comments.
                /// </summary>
                public bool Ignore { get; }

                /// <summary>
                /// If true, this token will act as a scope bracket (e.g., begin/end or {}).
                /// </summary>
                public bool Mingle { get; }

                /// <summary>
                /// The name of the token as named by this property will be the one that will unlock the scope.
                /// </summary>
                public string MingleWith { get; }

                /// <summary>
                /// The level of interpretation for the token.
                /// </summary>
                [Flags]
                public enum InterpretationBracket
                {
                    /// <summary>
                    /// The default token, used to organise all letters into tokens.
                    /// </summary>
                    CatchAll = 0b1000000,
                    
                    /// <summary>
                    /// Character tokens.
                    /// </summary>
                    Character = 0b0001,

                    /// <summary>
                    /// Tokens that are either keywords or expressions.
                    /// </summary>
                    Word = 0b0010,

                    /// <summary>
                    /// Tokens that are instructions.
                    /// </summary>
                    Sentence = 0b0100,

                    /// <summary>
                    /// Tokens such as brackets and/or BEGIN/END statements.
                    /// </summary>
                    Mingler = 0b1000,

                    /// <summary>
                    /// This token will be ignored if encountered.
                    /// </summary>
                    IgnoreAtSentenceLevel = 0b10000,
                }

                bool IEquatable<TokenFruit>.Equals(TokenFruit other)
                {
                    if (other == null) return false;
                    if (other.AssociatedToken == this) return true; else return false;
                }

                bool IEquatable<string>.Equals(string other) => Regex.IsMatch(other, Value);
            }

            /// <summary>
            /// An instruction.
            /// </summary>
            public class Sentence: Token, ISentence
            {
                /// <summary>
                /// Empty method for inheriters.
                /// </summary>
                public Sentence()
                {

                }

                /// <summary>
                /// Initialises a new sentence token.
                /// </summary>
                /// <param name="name">The name of the sentence.</param>
                /// <param name="level">The level of the sentence</param>
                /// <param name="locations">Which places in the sentence will be treated as value placeholders.</param>
                /// <param name="id">The ID of the sentence.</param>
                /// <param name="tokens">The pattern of the tokens.</param>
                /// <exception cref="Lamentation"></exception>
                public Sentence(string name, /*string value,*/ int level, string id, bool mingle, bool ender, string minglewith, int[] locations, params string[] tokens)
                {
                    Name = name;
                    Level = level;
                    /*Value = value;*/
                    if (tokens is null) { SentenceStructure = null; return; }
                    List<Token> ss = new();
                    foreach (string toknm in tokens)
                    {
                        if (CurrentTokens.Exists(tok => tok.Name == toknm)) ss.Add(CurrentTokens.Find(tok => tok.Name == toknm));
                        else throw new Lamentation(4);
                    }
                    SentenceStructure = ss.ToArray();

                    if (locations.Max() > SentenceStructure.Length - 1) throw new Lamentation(6, locations.Max().ToString(), Name, SentenceStructure.Length.ToString());
                    if (locations.Distinct().Count() < locations.Length) throw new Lamentation(7, Name);
                    WorkingValues = locations;
                    if (!string.IsNullOrWhiteSpace(id))
                    {
                        bool result = Guid.TryParse(id, out instance);
                        if (!result) throw new Lamentation(9, Name);
                    }
                    else instance = Guid.NewGuid();

                    Mingle = mingle;
                    MingleWith = minglewith;
                }

                /// <summary>
                /// The level this token is on. This is either determined by whether the sentence's pattern contains a
                /// sentence determiner or another sentence. By default this is 0.
                /// </summary>
                public new int Level { get; }

                /// <summary>
                /// The zero-based positions where the tokeniser will think the values in a sentence are. If the array is empty,
                /// the sentence does not have a location to grab from.
                /// </summary>
                public int[] WorkingValues { get; }

                /// <summary>
                /// The pattern of tokens or sentences the sentence has.
                /// </summary>
                public Token[] SentenceStructure { get; }

                /// <summary>
                /// If true, this token will act as a scope bracket (e.g., begin/end or {}).
                /// </summary>
                public new bool Mingle { get; }

                /// <summary>
                /// The name of the token as named by this property will be the one that will unlock the scope.
                /// </summary>
                public new string MingleWith { get; }

                /// <summary>
                /// If true, this instance will end a scope as started by the previous bracket. This is usually automatically
                /// done by the interpreter itself by storing the name of the closing bracket instead of relying on this value.
                /// </summary>
                public bool Ender { get; }

            }

            public class HeaderSentence: Sentence
            {
                
            }

            /// <summary>
            /// A captured sentence result.
            /// </summary>
            public class SentenceFruit
            {
                /// <summary>
                /// Empty method for inheriters.
                /// </summary>
                public SentenceFruit() { }

                /// <summary>
                /// Initialises a sentence fruit.
                /// </summary>
                /// <param name="sent">The sentence the tokeniser successfully associated this capture with.</param>
                /// <param name="value">The actual captured sentence.</param>
                public SentenceFruit(Sentence sent, string[] value)
                {
                    AssociatedSentence = sent;
                    Value = value;
                }

                /// <summary>
                /// The sentence the tokeniser successfully associated this capture with.
                /// </summary>
                public Sentence AssociatedSentence { get; }

                /// <summary>
                /// The actual captured sentence.
                /// </summary>
                public string[] Value { get; set; }

                /// <summary>
                /// Returns the instance of the sentence itself.
                /// </summary>
                /// <returns>A string representation using the format "Name: working on Values"</returns>
                public override string ToString() => $"({AssociatedSentence.Name}: working on '{Value[AssociatedSentence.WorkingValues[0]]}')";

            }

            /// <summary>
            /// A captured token result.
            /// </summary>
            public class TokenFruit: IEquatable<Token>
            {
                /// <summary>
                /// Initialises a token fruit.
                /// </summary>
                /// <param name="token">The token the tokeniser successfully associated this capture with.</param>
                /// <param name="value">The actual captured token.</param>
                public TokenFruit(Token token, string value)
                {
                    AssociatedToken = token;
                    Value = value;
                }

                /// <summary>
                /// The token the tokeniser successfully associated this capture with.
                /// </summary>
                public Token AssociatedToken { get; }

                /// <summary>
                /// Internal field for Value
                /// </summary>
                private string val;

                /// <summary>
                /// The actual captured token.
                /// </summary>
                public string Value
                {
                    get
                    {
                        return val switch
                        {
                            "\n" => "newline",
                            "\u0020" => "space",
                            _ => val,
                        };
                    }
                    set => val = value;
                }

                bool IEquatable<Token>.Equals(Token other)
                {
                    if (other == null) return false;
                    if (other == AssociatedToken) return true; else return false;
                }

                /// <summary>
                /// Returns the instance of the token itself.
                /// </summary>
                /// <returns>A string representation using the format "Name: Value"</returns>
                public override string ToString() => $"({AssociatedToken.Name}: '{Value}')";

                /// <summary>
                /// Returns the value itself.
                /// </summary>
                /// <returns>
                /// The value of the token. In the Value property, all invisible characters were given names and hence
                /// the Value property is unreliable for getting the actual token value. Hence, this is used to accurately
                /// get the tokens wherein the value is an invisible character.
                /// </returns>
                public string GetSeed() => Value switch
                {
                    "newline" => "\n",
                    "space" =>  "\u0020",
                    _ => Value
                };
            }

            /// <summary>
            /// A group of sentences.
            /// </summary>
            public class Scope: ISentence
            {
                public Scope(string name, ISentence head, params ISentence[] sentences)
                {
                    Name = name;
                    Header = head;
                    Contents = sentences;
                }
                public string Name { get; }
                public ISentence Header { get; }
                public ISentence[] Contents { get; }
            }

            /// <summary>
            /// A captured scope result.
            /// </summary>
            public class ScopeFruit: SentenceFruit
            {
                public ScopeFruit(Scope assc, SentenceFruit header, params SentenceFruit[] sentenceFruits)
                {
                    AssociatedScope = assc;
                    Header = header;
                    Contents = sentenceFruits;
                }
                public Scope AssociatedScope { get; }
                public SentenceFruit Header { get; }
                public SentenceFruit[] Contents { get; }
            }

            /// <summary>
            /// A marker to indicate a kind of sentence permissible in a scope.
            /// </summary>
            public struct KindOfSentence: ISentence
            {
                public KindOfSentence(KindOfSentenceEnum type, int count = 0, Sentence[] types = null)
                {
                    Kind = type;
                    SentenceCount = count;
                    SentenceTypes = types;
                }

                /// <summary>
                /// The kind and count of sentences.
                /// </summary>
                public KindOfSentenceEnum Kind { get; }
                
                /// <summary>
                /// If enabled, the allowed count of sentences.
                /// </summary>
                public int SentenceCount { get; }

                /// <summary>
                /// If enabled, the allowed kinds of sentences.
                /// </summary>
                public Sentence[] SentenceTypes { get; }

                /// <summary>
                /// Markers to indicate a kind of sentence permissible in a scope.
                /// </summary>
                [Flags] public enum KindOfSentenceEnum
                {
                    /// <summary>
                    /// Any sentence.
                    /// </summary>
                    Anything = 0b0001,

                    /// <summary>
                    /// Any sentence that has the form "keyword (expression)".
                    /// </summary>
                    Condition = 0b0010,

                    /// <summary>
                    /// Any sentence that has the types as defined in <c>SentenceTypes</c>.
                    /// </summary>
                    Specific = 0b0100,

                    /// <summary>
                    /// No limit on how many sentences are there.
                    /// </summary>
                    Unlimited = 0b1000,

                    /// <summary>
                    /// Limit as defined in <c>SentenceCount</c>.
                    /// </summary>
                    Limited = 0b10000
                }
            }

            /// <summary>
            /// Temporary scope type to test scopes
            /// </summary>
            public class TempScope: SentenceFruit
            {
                public TempScope(params SentenceFruit[] cont) => Contents = cont;
               
                public SentenceFruit[] Contents { get; }
            }

            /// <summary>
            /// Unused; use <c>Sentence</c>
            /// </summary>
            public class TokenPattern
            {
                public TokenPattern(string name, string pattern)
                {
                    Name = name;
                    Pattern = pattern;
                }

                public TokenPattern (string name, params Token[] tokencol)
                {
                    Name = name;
                    tokens = new(tokencol);
                }

                public string Name { get; }
                public string Pattern { get; set; }
                private readonly List<Token> tokens;
                public List<Token> Tokens => tokens;

            }

            /// <summary>
            /// Unused; use the main tokeniser module in <c>Interpreter</c>
            /// </summary>
            /// <param name="value"></param>
            /// <returns></returns>
            /// <exception cref="Lamentation"></exception>
            public static TokenFruit CheckToken(string value)
            {
                if (string.IsNullOrWhiteSpace(value)) return new TokenFruit(null, string.Empty);

                StringBuilder checker = new();

                int CurrentCharacter = 0;

                foreach (char character in value) // time-consuming?
                {


                    checker.Append(character);
                    
                    foreach (Token token in CurrentTokens)
                    {
                        if (Regex.IsMatch(checker.ToString(), token.Value)) return new TokenFruit(token, checker.ToString());
                        else
                        {
                            if (Array.IndexOf(CurrentTokens.ToArray(), token) != CurrentTokens.Count - 1) continue;
                            else
                            {
                                if (CurrentCharacter != value.Length - 1) continue; else throw new Lamentation("sdfsdtdtsg", 421);
                            }
                        }
                    }
                }

                return null;
            }
        }
    }
}