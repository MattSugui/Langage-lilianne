//#define Level0TestingMode
#define VERBOSE

using ShellProgressBar;

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New;

/// <summary>
/// The main class for the interpeter.
/// </summary>
public static partial class Interpreter
{
    /// <summary>
    /// Static construction.
    /// </summary>
    static Interpreter() => TEMP.LOADPATTERNS();

    /// <summary>
    /// The current file. Not exactly a single file, but a merger of all source files.
    /// </summary>
    public static List<string> CurrentFile = new();

    #region File operations
    /// <summary>
    /// Reads from a path.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <exception cref="Lamentation"></exception>
    public static void ReadFile(string path)
    {
        if (File.Exists(path)) foreach (string line in File.ReadAllLines(path)) CurrentFile.Add(line); else throw new Lamentation(3, path);
    }

    /// <summary>
    /// Adds any amount of lines to the current file.
    /// </summary>
    /// <param name="lines">Any amount of lines to be added.</param>
    public static void ReadFile(params string[] lines)
    {
        foreach (string line in lines) CurrentFile.Add(line);
    }
    #endregion

    #region End-user debug services
    /// <summary>
    /// The current line number.
    /// </summary>
    public static int CurrentIndex { get; set; }

    /// <summary>
    /// The current line.
    /// </summary>
    /// <remarks>
    /// This is used alongside the standard StringBuilder in the lexer. Instead of being cleared though, this will
    /// continue getting filled for the purpose of finding the exact column of any possible error that may happen.
    /// The line number is taken care of by the <c>CurrentIndex</c>.
    /// </remarks>
    public static StringBuilder CurrentLine = new();

    /// <summary>
    /// The current line column. Uses <c>CurrentLine</c> for the column.
    /// </summary>
    public static int CurrentColumn => CurrentLine.Length;
    #endregion

    /// <summary>
    /// Do the whole thing.
    /// </summary>
    /// <param name="GUI">If true, the progress bars will be enabled. True by default.</param>
    /// <param name="REPL">If true, a single line will be interpreted. False by default.</param>
    /// <param name="line">The individual line to be parsed. If empty, the entire currently-loaded file will be parsed.</param>
    public static void Interpret(bool GUI = true, bool REPL = false, string line = "")
    {
        //foreach (string line in CurrentFile) ScanTokens(line);
        Stopwatch watch = new();
        //ProgressRecord timerem = new(0, "Interpretation", "Interpreting");
        //PowerShell ps = PowerShell.Create();

        if (GUI)
        {
            ProgressBarOptions opt = new()
            {
                ProgressBarOnBottom = false,
                //DenseProgressBar = true,
                ProgressCharacter = '\u2588',
                BackgroundCharacter = '\u2590',
                CollapseWhenFinished = false,
                ForegroundColor = ForegroundColor // what
                                                  //DisplayTimeInRealTime = true,
            };

            ProgressBarOptions opt1 = new()
            {
                ProgressBarOnBottom = false,
                //DenseProgressBar = true,
                ProgressCharacter = '\u2588',
                BackgroundCharacter = '\u2590',
                CollapseWhenFinished = false,
                ForegroundColor = ConsoleColor.Red
                //DisplayTimeInRealTime = true,
            };

            ProgressBarOptions opt2 = new()
            {
                ProgressBarOnBottom = false,
                //DenseProgressBar = true,
                ProgressCharacter = '\u2588',
                BackgroundCharacter = '\u2590',
                CollapseWhenFinished = false,
                ForegroundColor = ConsoleColor.Yellow
                //DisplayTimeInRealTime = true,
            };

            ProgressBarOptions opt3 = new()
            {
                ProgressBarOnBottom = false,
                //DenseProgressBar = true,
                ProgressCharacter = '\u2588',
                BackgroundCharacter = '\u2590',
                CollapseWhenFinished = false,
                ForegroundColor = ConsoleColor.Green
                //DisplayTimeInRealTime = true,
            };

            ProgressBarOptions opt4 = new()
            {
                ProgressBarOnBottom = false,
                //DenseProgressBar = true,
                ProgressCharacter = '\u2588',
                BackgroundCharacter = '\u2590',
                CollapseWhenFinished = false,
                ForegroundColor = ConsoleColor.Blue
                //DisplayTimeInRealTime = true,
            };

            ProgressBarOptions opt5 = new()
            {
                ProgressBarOnBottom = false,
                //DenseProgressBar = true,
                ProgressCharacter = '\u2588',
                BackgroundCharacter = '\u2590',
                CollapseWhenFinished = false,
                ForegroundColor = ConsoleColor.Magenta
                //DisplayTimeInRealTime = true,
            };

            ProgressBarOptions opt6 = new()
            {
                ProgressBarOnBottom = false,
                //DenseProgressBar = true,
                ProgressCharacter = '\u2588',
                BackgroundCharacter = '\u2590',
                CollapseWhenFinished = false,
                ForegroundColor = ConsoleColor.Cyan
                //DisplayTimeInRealTime = true,
            };

            watch.Start();
            Clear();
            using (var pbm = new ProgressBar(4, "Interpretation process", opt))
            {
                using (var pbz = pbm.Spawn(CurrentFile.Count, "Calling Coco for help", opt5))
                {
                    bool cocotext = false;
                    List<int> CodePositionsWhereCoco = new();
                    string FirstLine = string.Empty;
                    string LastLine = string.Empty;
                    for (int i = 1; i < CurrentFile.Count + 1; i++)
                    {
                        //int offset = 0;
                        pbz.Tick();
                        if (CurrentFile[i - 1].StartsWith("preprocess:"))
                        {
                            cocotext = true;
                            goto RemoveDeclarationIfCocoStartsImmediatelyAfter;
                        }
                        else if (CurrentFile[i - 1] == "preprocess:")
                        {
                            cocotext = true;
                        }
                        else if (CurrentFile[i - 1].EndsWith("start;"))
                        {
                            cocotext = false;
                            goto SaveCodeBeforeEndDeclaration;
                        }
                        else if (CurrentFile[i - 1] == "start;")
                        {
                            cocotext = false;
                        }
                        else goto Otherwise;

                        RemoveDeclarationIfCocoStartsImmediatelyAfter:
                        {
                            CurrentFile[i - 1] = Regex.Replace(CurrentFile[i - 1], @"^\s*preprocess:\s*", string.Empty);
                            if (!string.IsNullOrWhiteSpace(CurrentFile[i - 1])) CodePositionsWhereCoco.Add(i - 1);
                            else CurrentFile.RemoveAt(i - 1);
                            i--;
                            continue;
                        }

                    SaveCodeBeforeEndDeclaration:
                        {
                            CurrentFile[i - 1] = Regex.Replace(CurrentFile[i - 1], @"\s*start;\s*$", string.Empty);
                            if (!string.IsNullOrWhiteSpace(CurrentFile[i - 1])) CodePositionsWhereCoco.Add(i - 1);
                            else CurrentFile.RemoveAt(i - 1);
                            break;
                        }


                    Otherwise:
                        {
                            if (cocotext) CodePositionsWhereCoco.Add(i - 1); else continue;
                        }
                    }
                    List<string> CocoCode = new();
                    pbz.MaxTicks += CodePositionsWhereCoco.Count; // you can do this?
                    foreach (int i in CodePositionsWhereCoco)
                    {
                        CocoCode.Add(CurrentFile[i].TrimStart());
                        CurrentFile.RemoveAt(i);
                        pbz.Tick();
                    }
                    if (CocoCode.Count != 0)
                    {
                        using (TextWriter pen = File.CreateText("cocotmp.ccn"))
                        {
                            foreach (string line1 in CocoCode)
                            {
                                pen.WriteLine(line1);
                                pbz.Tick();
                            }
                        }
                        FeedingTime("cocotmp.ccn");
                    }
                }
                using (var pba = pbm.Spawn(CurrentFile.Count, "Scanning tokens", opt1))
                {
                    for (int i = 1; i < CurrentFile.Count + 1; i++)
                    {
                        //pba.WriteLine(CurrentFile[i - 1]);
                        ScanTokens(CurrentFile[i - 1]);
                        pba.Tick();
                    }
                    pbm.Tick();
                }
                using (var pbb = pbm.Spawn(CurrentWordPacks.Count, "Parsing tokens", opt2))
                {
                    foreach (List<TokenFruit> fruits in CurrentWordPacks)
                    {
                        //pbb.WriteLine(string.Join('¬', from fruit in fruits select fruit.AssociatedToken.Name)); // bruh
                        ArrangeTokens(fruits);
                        pbb.Tick();
                    }
                    pbm.Tick();
                }
                using (var pbc = pbm.Spawn(CurrentSentences.Count, "Assigning operations", opt3))
                {
                    CurrentPointedEffect = 0;
                    foreach (SentenceFruit sent in CurrentSentences)
                    {

                        //pbc.WriteLine($"A{(Regex.IsMatch(sent.AssociatedSentence.Name, "^[AEIOUaeiou].*") ? "n" : string.Empty)} {sent.AssociatedSentence.Name}");
                        PlaceEffect(InterpretSentenceNew(sent), CurrentPointedEffect, false);
                        CurrentPointedEffect++;
                        pbc.Tick();
                    }
                    pbm.Tick();
                }
                using (var pbe = pbm.Spawn(1, "Pointing labels to correct places", opt6))
                {
                    CheckForFriendlyNames();
                    pbe.Tick();
                    pbm.Tick();
                }
                using (var pbd = pbm.Spawn(1, "Writing to file", opt4))
                {
                    CreateBinary();
                    pbd.Tick();
                    pbm.Tick();
                }
            }
            Clear();
            watch.Stop();
            WriteLine($"Took {watch.ElapsedMilliseconds} ms.");
        }
        else
        {
            try
            {
                ScanTokens(line);
                ArrangeTokens(CurrentWordPacks[0]);
                PlaceEffect(InterpretSentenceNew(CurrentSentences[0]), CurrentPointedEffect, false);

                CurrentWordPacks.Clear();
                CurrentSentences.Clear();
            }
            catch (Exception ex)
            {
                throw new Lamentation(
                    0x2c,
                    Regex.IsMatch(Lamentation.InterpretExceptionName(ex.InnerException)[0].ToString(), @"[AEIOU]") ? "an" : "a",
                    Lamentation.InterpretExceptionName(ex.InnerException)
                    );
            }
        }
        //WriteLine("complet");

        /*
        foreach (List<TokenFruit> toklist in CurrentWordPacks)
        {
            foreach (TokenFruit tok in toklist) WriteLine($"{tok.Value}");
        }
        */

        //WriteLine("\n\n");
    }

}

/// <summary>
/// Extensions for simplification of development of the Lilian language.
/// </summary>
public static partial class Extensions
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

    /// <summary>
    /// <see cref="Array.IndexOf(Array, object?)"/>
    /// </summary>
    /// <param name="enumerable">The array.</param>
    /// <param name="thing">The item to be searched for.</param>
    /// <returns></returns>
    public static int IndexOf(this Array enumerable, object thing) => Array.IndexOf(enumerable, thing);
}



