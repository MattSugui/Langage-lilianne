//#define Level0TestingMode
#define VERBOSE

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using static fonder.Lilian.New.Interpreter.Tokeniser;
using static fonder.Lilian.New.Interpreter.Actualiser;
using static fonder.Lilian.New.Interpreter.Actualiser.Translator;

using static System.Console;

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New
{
    /// <summary>
    /// The main class for the interpeter.
    /// </summary>
    public static partial class Interpreter
    {
        /// <summary>
        /// Gets or sets whether Lilian is running as a REPL or as a compiler.
        /// </summary>
        public static bool EnableIncrementalContextualisation { get; set; }

        /// <summary>
        /// The current consummate file. This is a combination of all source files loaded into Lilian.
        /// </summary>
        public static List<string> CurrentFile = new();

        /// <summary>
        /// Gets or sets the current status of the interpreter.
        /// </summary>
        public static InterpreterStatus Status { get; set; }

        /// <summary>
        /// A status for the interpreter.
        /// </summary>
        public enum InterpreterStatus
        {
            /// <summary>
            /// The interpreter is currently doing nothing. This is almost never used.
            /// </summary>
            Idle,                    // doing nothing

            /// <summary>
            /// The interpreter is resetting all data she probably generated.
            /// </summary>
            CleaningEnvironment,     // initialisation

            /// <summary>
            /// The interpreter is removing all lines that are just comments and/or part of some.
            /// </summary>
            LookingForComments,

            /// <summary>
            /// The interpreter is turning all characters into catch-all tokens.
            /// </summary>
            CatchingCharacters,      // level -1 tokens (catch-all)

            /// <summary>
            /// The interpreter is sorting all characters according to their appearance.
            /// </summary>
            OrganisingCharacters,    // level 0 tokens (letters, numbers, symbols, spaces)

            /// <summary>
            /// The interpreter is sorting all characters into appropriate words.
            /// </summary>
            DifferentiatingThings,   // level 1 tokens (keywords, operators, values)

            /// <summary>
            /// The interpreter is forming sentences from the words.
            /// </summary>
            ComprehendingStatements, // level 2 tokens (statements)

            /// <summary>
            /// The interpreter is sorting scopes.
            /// </summary>
            DefiningBoundaries,

            /// <summary>
            /// The interpreter is generating bytecodes for the programme.
            /// </summary>
            InterpretingStatements,  // run implementations of language constructs

            /// <summary>
            /// The interpreter is creating a file of all the bytecodes.
            /// </summary>
            CompilingInstructions,   // if compilation, turn everything into bytecode

            /// <summary>
            /// The interpreter is creating an archive of the bytecode file and the resources it references.
            /// </summary>
            PackagingArchive         // creating archive
        }

        //public static void InterpretThread(string LineCollection)
        //      {
        //	List<string> Collection = new();

        //	if (!LineCollection.Contains(';')) throw new Lamentation("Test for errors. Damn bruh you failed to terminate the damn thing?", 420);

        //	foreach (string item in LineCollection.Split(';')) Collection.Add(item + ";");

        //	CurrentRow = 0;
        //          CurrentLine = Collection[CurrentRow];

        //	while (true) // motherfucking traditional sensorless floppydisk sector scanner
        //	{
        //		Interpret();
        //		CurrentRow++;
        //		CurrentLine = !(CurrentRow == Collection.Count) ? Collection[CurrentRow] : null;
        //		if (CurrentLine is null) break; // advanced technology
        //	}

        //      }

        // #bruh 

        /// <summary>
        /// Loads a file and adds it to the consummate file.
        /// </summary>
        /// <param name="path">The path to the source file.</param>
        /// <exception cref="Lamentation"></exception>
        public static void LoadFile(string path)
        {
            string TEMP = path.Trim('"');
            if (File.Exists(TEMP)) foreach (string line in File.ReadAllLines(TEMP)) CurrentFile.Add(line);
            else throw new Lamentation(3, TEMP);
        }

        /// <summary>
        /// Clear all current data for new compilations.
        /// </summary>
        private static void InitialiseInterpretation()
        {
            // refresh old data if in REPL or using multiple sources or application files if Lilian is
            // not allowed to compress every file into one huge source before interpretation
            Orchard = new();
            // initialising grammars
            LoadGrammars();
        }

        /// <summary>
        /// Load the grammar features.
        /// </summary>
        /// <param name="path">The path to the Coco preprocessing file which has the grammar implementations.</param>
        public static void LoadGrammars(string path = null)
        {
            if (path == null) return;
        }

        /// <summary>
        /// The primary interpretation session.
        /// </summary>
        /// <param name="LineCollection">The consummate text.</param>
        /// <exception cref="Lamentation"></exception>
        public static void Interpret(string[] LineCollection)
        {
            InitialiseInterpretation();

            Token[] CurrentContext;
            StringBuilder Collector = new();
            List<TokenFruit> SmallBasket = new();

            List<string> deconst = new();

            foreach (string line in LineCollection) deconst.Add(line);

            //bool Escape = false;

            // remove comments
            Status = InterpreterStatus.LookingForComments;
            WriteLine("Removing comments...");
            #region Looking for comments
            List<int> removalPositions = new();
            bool multiline = false;
            for (int i = 0; i < deconst.Count; i++)
            {
                if (Regex.IsMatch(deconst[i], @"^\s*\/\/.*$")) removalPositions.Add(i);
                else if (Regex.IsMatch(deconst[i], @"^\s*\/\*.*$"))
                {
                    removalPositions.Add(i);
                    multiline = true;
                    continue;
                }
                else if (Regex.IsMatch(deconst[i], @"^.*\*\/\s*$"))
                {
                    removalPositions.Add(i);
                    multiline = false;
                    continue;
                }
                else if (multiline) removalPositions.Add(i);
                else continue;
            }
            foreach (int pos in removalPositions) deconst[pos] = "COMMENT; PLEASE REMOVE";
            deconst.RemoveAll(str => str == "COMMENT; PLEASE REMOVE");

            // reassemble doc
            StringBuilder reassembler = new();
            foreach (string line in deconst)
            {
                reassembler.AppendLine(line);
            }
            #endregion

            // print "hello, world!"; 
            // ||||||||||||||||||||||
            Status = InterpreterStatus.CatchingCharacters; CurrentLevel = -1;
            WriteLine("Scanning document...");
            #region Catching characters
            foreach (char character in reassembler.ToString()) Orchard.Add(new TokenFruit(CurrentTokens.Find(tok => tok.Level == Token.InterpretationBracket.CatchAll), character.ToString()));
            #endregion

            // print "hello, world!"; 
            // LLLLLSQLLLLLMSLLLLLMQT
            Status = InterpreterStatus.OrganisingCharacters; CurrentLevel++; // 0
            WriteLine("Differentiating characters...");
            #region Organising characters
            CurrentContext =
            (
                from token in CurrentTokens
                where (token.Level & Token.InterpretationBracket.Character) == Token.InterpretationBracket.Character
                //orderby token.Name ascending
                select token
            ).ToArray();

            foreach (TokenFruit fruit in Orchard)
            {
                Collector.Clear();
                Collector.Append(fruit.GetSeed());
                foreach (Token token in CurrentContext)
                {
                    if (Regex.IsMatch(Collector.ToString(), token.Value))
                    {
                        SmallBasket.Add(new(token, Collector.ToString()));
                        Collector.Clear();
                        break;
                    }
                    else
                    {
                        if (CurrentContext.IndexOf(token) != CurrentContext.Length - 1) continue;
                        else
                        {
                            if (Orchard.IndexOf(fruit) != Orchard.Count - 1) continue;
                            else throw new Lamentation(0x0002, Collector.ToString());
                        }
                    }
                }
            }
            Orchard.Clear();
            Orchard = new(SmallBasket);

#if VERBOSE
            foreach (var item in Orchard) WriteLine(item.ToString());
#endif
            #endregion

            // print "hello, world!"; 
            // [   ]![             ].
            Status = InterpreterStatus.DifferentiatingThings; CurrentLevel++; // 1
            WriteLine("Differentiating words...");
            #region Differentiating things
            CurrentContext =
            (
                from token in CurrentTokens
                where (token.Level & Token.InterpretationBracket.Word) == Token.InterpretationBracket.Word
                //orderby token.Name ascending
                select token
            ).ToArray();
            SmallBasket.Clear(); // reinitialise for next level

            List<TokenFruit> smallerBasket = new();
            bool lookfor = false;
            bool locked = false;

            foreach (TokenFruit fruit in Orchard)
            {
                Collector.Append(fruit.GetSeed());
                if (fruit.AssociatedToken.LockUntilNextInstance) if (!locked) locked = true; else locked = false;
                if (locked) continue;
                foreach (Token token in CurrentContext)
                {
                    if (Regex.IsMatch(Collector.ToString(), token.Value))
                    {
                        if (fruit.AssociatedToken.LookAhead)
                        {

                            if (Orchard[Orchard.IndexOf(fruit) + 1].AssociatedToken.Name == fruit.AssociatedToken.Name)
                            {
                                if (!lookfor) lookfor = true;
                                break;
                            }
                            else lookfor = false;
                        }
                        SmallBasket.Add(new(token, Collector.ToString()));
                        Collector.Clear();
                        break;
                    }
                    else
                    {
                        if (CurrentContext.IndexOf(token) != CurrentContext.Length - 1) continue;
                        else
                        {
                            if (Orchard.IndexOf(fruit) != Orchard.Count - 1) continue;
                            else throw new Lamentation(0x0002, Collector.ToString());
                        }
                    }
                }
                if (lookfor) continue;
            }
            Orchard.Clear();
            // ignore all whitespaces
            SmallBasket.RemoveAll(tok => (tok.AssociatedToken.Level & Token.InterpretationBracket.IgnoreAtSentenceLevel) == Token.InterpretationBracket.IgnoreAtSentenceLevel);
            Orchard = new(SmallBasket);

#if VERBOSE
            foreach (var item in Orchard) WriteLine(item.ToString());
#endif
            #endregion

            #region Remove all ignorables
            var ignored =
                from token in Orchard
                where token.AssociatedToken.Ignore
                select token;

            foreach (TokenFruit tokenFruit in ignored) Orchard.Remove(tokenFruit);
            #endregion

            // print "hello, world!"; 
            // [                    ]
            Status = InterpreterStatus.ComprehendingStatements; CurrentLevel++;
            WriteLine("Forming sentences...");
            #region Comprehending statements
            List<TokenFruit> Comparator = new();
            List<SentenceFruit> LargeBasket = new();
            SmallBasket.Clear();
            bool IsOkay = false;
            foreach (TokenFruit fruit in Orchard)
            {
                /*
                if (fruit.AssociatedToken.Mingle)
                {
                    Comparator.Add(fruit);
                    continue;
                }
                */
                Comparator.Add(fruit);
                foreach (Sentence sent in CurrentSentences)
                {
                    List<string> names = new();
                    List<string> others = new();
                    foreach (Token tknms in sent.SentenceStructure) names.Add(tknms.Name);
                    foreach (TokenFruit tknms in Comparator) others.Add(tknms.AssociatedToken.Name);
                    if (names.SequenceEqual(others))
                    {
                        List<string> vals = new();
                        foreach (TokenFruit tkn in Comparator) vals.Add(tkn.Value);
                        LargeBasket.Add(new(sent, vals.ToArray()));
                        IsOkay = true;
                        Comparator.Clear(); // remove to prevent confusion
                        //Orchard.RemoveRange(0, others.Count); // remove to prevent confusion
                        break;
                    }
                    else
                    {
                        if (CurrentSentences.IndexOf(sent) != CurrentSentences.Count - 1) continue;
                        else
                        { if (Orchard.IndexOf(fruit) != Orchard.Count - 1) break; else throw new Lamentation(0x0008, others.ToArray()[0], sent.Name); }
                    }

                }
                if (IsOkay)
                {
                    if (Orchard.IndexOf(fruit) != Orchard.Count - 1) continue; else break;
                }
                else continue;
            }
            /*
                if (CurrentContext.IndexOf(token) != CurrentContext.Length - 1) continue;
                else
                {
                    if (Orchard.IndexOf(fruit) != Orchard.Count - 1) continue;
                    else throw new Lamentation(0x0002, Collector.ToString());
                }
            }*/


#if !VERBOSE
            foreach (var item in LargeBasket) WriteLine(item.ToString());
#endif

            #endregion

            /*
            Status = InterpreterStatus.DefiningBoundaries;
            WriteLine("Organising scopes...");
            #region Defining boundaries
            string scopekey = null;
            List<SentenceFruit> sentences = new();
            List<ScopeFruit> scopes = new();
            List<TempScope> matryushka = new();
            int currentlev = 0;
            //ScopeFruit CurrentScope;

            foreach (SentenceFruit sent in LargeBasket)
            {
                SentenceFruit thing = sent;
                if (sent.AssociatedSentence.Mingle)
                {
                    if (CurrentSentences.Exists(token => token.Name == sent.AssociatedSentence.MingleWith)) scopekey = sent.AssociatedSentence.MingleWith; else throw new Lamentation(0x000D, sent.AssociatedSentence.MingleWith, sent.AssociatedSentence.Name);
                    currentlev++;
                    continue;
                }
                if (sent.AssociatedSentence.Name == scopekey)
                {
                    currentlev--;
                    TempScope hmm = new(sentences.ToArray());
                    matryushka.Add(hmm);
                    thing = hmm;
                }
                sentences.Add(thing);
                /*
                foreach (Scope scp in CurrentScopes)
                {

                }
                
            }

#if VERBOSE
            foreach (TempScope tem in matryushka)
            foreach (SentenceFruit sent in tem.Contents)
            WriteLine(sent.ToString());
#endif
        #endregion
        */
            // -> print "hello, world!";
            // (invoke)
            Status = InterpreterStatus.InterpretingStatements;
            WriteLine("Interpreting sentences...");
#region Interpreting statements

            foreach (SentenceFruit fruit in LargeBasket) Translate(fruit);
#if VERBOSE
            foreach (Instruction inst in CurrentInstructions) WriteLine(inst.ToString());
#endif
#endregion

            // -> 00000000-ACEE...
            // (invoke)
            Status = InterpreterStatus.CompilingInstructions;
            WriteLine("Executing sentences...");
#region Compiling instructions
            WriteLine("Lilian output starts here =====");
            foreach (IInstruction inst in CurrentInstructions)
            {
                if (inst is Instruction) inst.Invoke();
            }
            WriteLine("* Lilian output ends here =====");
#endregion
        }

    }


    /// <summary>
    /// Unused
    /// </summary>
    public enum ManipulationType
    {

    }

}
/// <summary>
/// Extensions for simplification of development of the Lilian language.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Simplification of the <c>Char.IsWhiteSpace(char)</c> method.
    /// </summary>
    /// <param name="character">The Unicode character to evaluate.</param>
    /// <returns></returns>
    public static bool IsWhiteSpace(this char character)
    {
        if (char.IsWhiteSpace(character)) return true; else return false;
    }

    /// <summary>
    /// Simplification of the <c>Char.IsLetterOrDigit(char)</c> method.
    /// </summary>
    /// <param name="character">The Unicode character to evaluate.</param>
    /// <returns></returns>

    public static bool IsAlphanumeric(this char character)
    {
        if (char.IsLetterOrDigit(character)) return true; else return false;
    }

    public static int IndexOf(this Array enumerable, object thing) => Array.IndexOf(enumerable, thing);
}
