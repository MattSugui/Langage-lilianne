#region Informations
/* Open to see credits and info about this source code file ***************************************\
╔══════════════════════════════════════════════════════════════════════════════════════════════════╗
║   ╭╮╭╮                                                                                           ║
║  (0_0) ... was that the bite of 87!                                                              ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ Fonder Lilian Language Interpreter 1.2                                                           ║
║ Built upon the .NET 6 Common Language Infrastructure by Microsoft                                ║
║                                                                                                  ║
║ Maintained 2019-2022 Matt Adrian P Sugui. Released under the GPU 3.0 General Public Licence.     ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ C#, .NET, Visual Studio and all related titles and subjects are registered trademarks of         ║
║ Microsoft Corporation.                                                                           ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ The minimum version of C# you can use is 10.0. The program uses record structs.                  ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ This program is free software: you can redistribute it and/or modify it under the terms of the   ║
║ GNU General Public License as published by the Free Software Foundation, either version 3 of the ║
║ License, or (at your option) any later version.                                                  ║
║                                                                                                  ║
║ This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without║
║ even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU    ║
║ General Public License for more details.                                                         ║
║                                                                                                  ║
║ https://www.gnu.org/licenses/                                                                    ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ ╭│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─╮ ║
║ │ Hello, viewer of this source code!                                                           │ ║
║ │                                                                                              │ ║
║ │     I have compressed my damned project into just one code file that can cause multiple      │ ║
║ │ performance issues for whoever has the balls to load this file in a laptop that's running at │ ║
║ │ a very, very measly 1 billion hertz, also known as 1 GHz and the speed of latter-day PC      │ ║
║ │ toasters. This is for portability and easy redistribution of this open-source project.       │ ║
║ │                                                                                              │ ║
║ │     This project is named after the famous Animal Crossing™ bunny character named, well,     │ ║
║ │ Bunnie. Well, her Japanese name, at least (Ririan, or Lilian in proper English). --------    │ ║
║ │ ----------------------- Ayo, Nintendo, I'm not stealing that name! In fact, it is a common   │ ║
║ │ name, so essentially putting a trademark on it is ridiculous anyway lmao.                    │ ║
║ │                                                                                              │ ║
║ │     The way it interprets stuff is in the LILYHELP PDF in the final product. Or, if you do   │ ║
║ │ not have that or just stumbled upon this for some reason, read the damn thing. You're probs  │ ║
║ │ advanced enough to interpret these weird problematic statements.                             │ ║
║ │                                                                                              │ ║
║ │     So, yeah. I hope you'll understand the li'l XML doc comments and other shit I've placed  │ ║
║ │ in this single-file interpreter source code! Well, if your PC doesn't crash already from     │ ║
║ │ loading this thousand-line file. Look...it even fits in your 5.25" floppy...                 │ ║
║ │                                                                                              │ ║
║ │                                                                                              │ ║
║ │                                                                                              │ ║
║ │                                                                   Sincerely made with love,  │ ║
║ │                                                                                        Matt  │ ║
║ │                                                                                              │ ║
║ │                                                           P.S. I'm not gay. But Villager is. │ ║
║ │    PP.S. This is also where I try out the dirty C# 10.0 stuff. Thank God for record structs! │ ║
║ ╰──────────────────────────────────────────────────────────────────────────────────────────────╯ ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ Vive l'Ukraine !                                                                                 ║
║ Size goal: IBM 33FD (208/242 kB)                                                                 ║
║ Build number is equal to: Windows NT 3.5 Beta 1 3.5.547.0                                        ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ Here are some fanfics that I found intriguing since 2013.                                        ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ Isabelle: Hello, toilet? (*>_<*)                                                                 ║
║ Tommy: « Извините, уборная в этом конкретном отделении, кстати, предназначена только для членов  ║
║        _______________________________________________________________; возможно, вам придется   ║
║        перейти в другое заведение. Извините правительство за неудобства, которые мы могли и можем║
║        причинить вам. » ( O_O;)                                                                  ║
║ Isabelle: Understandable, have a nice day (*^_^*)                                                ║
║                                                                                                  ║
║ Read the full story: (desperation, urination)                                                    ║
║ http://www.omorashi.org/topic/43290-marking-her-territory-animal-crossing/                       ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ In this fanfic, the red-shirted villager is named Damian.                                        ║
║                                                                                                  ║
║ Ness: haha loser sik that;s the wrong numba woooooooooooooooooooooooooooooooooooooooooooooooooo  ║
║ Damian (after defeat): * destruant l'arborescence en colère après étant farcée epiquement !! *   ║
║ Days later...                                                                                    ║
║ Ness: AYO STOP THE G   R   A   B                                                                 ║
║ Damian: imonna be all up in those feet oo imma just be * sucement des cinq doigts * sucking on   ║
║         each one of those tootsies                                                               ║
║                                                                                                  ║
║ Read the full story: (podophilie, chatouillements, homosexualité, possible voyeurisme, BDSM)     ║
║ https://archiveofourown.org/works/25838113                                                       ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ Pink Villager: ayo peach how to sex since i've hear ness did it once                             ║
║ Peach: * epicly converts the villy into a lesbian in the teaching process *                      ║
║                                                                                                  ║
║ Read the full story: (lesbianisme, exploration)                                                  ║
║ https://archiveofourown.org/works/30848492                                                       ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ I'm not going to post an oversimplification just read the link below it's just                   ║
║ Can't believe that one of the only villy x villy fanfics is a literal regression fanfic          ║
║                                                                                                  ║
║ Read the full story: (régression et BDSM, homosexualité)                                         ║
║ https://archiveofourown.org/works/12975051                                                       ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ Repose en paix.                                                                                  ║
║ Longcat (Shiroi)                                                                                 ║
║ AD MMII - AD MMXX                                                                                ║
║ Que vous vous étiriez au griffoir du Dieu en paradis. Amen.                                      ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ This large notice changes every major version. Don't worry - you can use the GitHub repo for     ║
║ previous commits that have this notice. Version 1.2 is the lowest version with the notice.       ║
╚══════════════════════════════════════════════════════════════════════════════════════════════════╝
\**************************************************************************************************/
#endregion

#region Warning suppressions

// serious possible nullability holes
#nullable enable
#pragma warning disable CS8618 // waaa, possible null even after construction
#pragma warning disable CS8604 // waaa, null!!!!
#pragma warning disable CS8601 // waaa, it could be null!!!!
#pragma warning disable CS8602 // waaa, 'as' can return null!!!!
#pragma warning disable CS8600 // waaa, possible null literal!
#pragma warning disable CS8625 // waaa, possible null argument!
#pragma warning disable CS8765 // nullability discongruence

// rants by the quality checker
#pragma warning disable CA1416 // platformist scum
#pragma warning disable CA1806 // unused methods (for funky user32 manipulations)
#pragma warning disable CA2211 // ayo! fields aint supposed to be public!
#endregion

#region Symbols that affect compilation
//#define COCOTESTS
// Runs Coco immediately with the input file without going through the interpretation process.
// Lilian will also display the output PCP.
#define COMPARAISON
// Runs a comparison (comparaison is the French translation of the word) test between a program
// that's saved in memory and the output. If both return true through and through, the test is
// obviously successful. sinon, il y a un bogue
#endregion

#region Imports
// corlibs
global using System;
global using System.Collections.ObjectModel;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Reflection;
global using System.IO;
global using System.Diagnostics;
global using System.Xml;
global using System.Xml.Serialization;
global using System.Runtime.InteropServices;
// nugets
global using ShellProgressBar;

// name simplification
global using static fonder.Lilian.New.Interpreter;
global using static fonder.Lilian.New.Interpreter.Spellbook;
global using static fonder.Lilian.New.Interpreter.Actualiser;
global using static fonder.Lilian.New.Coco.Preprocessor;
global using static fonder.Lilian.New.UserInterface;
global using static fonder.Lilian.New.ObjectModel;
global using static System.Threading.Thread;
global using static System.Console;

#endregion

namespace fonder.Lilian.New;

//#line 1

#region Programme

/// <summary>
/// The main flow.
/// </summary>
public static class Programme
{
    #region look, stuff
    /// <summary>
    /// Deletes a menu.
    /// </summary>
    /// <param name="hMenu">The menu of the window.</param>
    /// <param name="nPosition">The position of the menu item.</param>
    /// <param name="wFlag">Some flags i guess.</param>
    /// <returns>The HRESULT of the operation.</returns>
    [DllImport("user32.dll")]
    internal static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlag);

    /// <summary>
    /// Gets the menu of the window.
    /// </summary>
    /// <param name="hWnd">The window.</param>
    /// <param name="bRevert">I dunno.</param>
    /// <returns>The menu of the current window.</returns>
    [DllImport("user32.dll")]
    internal static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

    /// <summary>
    /// Gets the current window.
    /// </summary>
    /// <returns>The current window.</returns>
    [DllImport("kernel32.dll", ExactSpelling = true)]
    internal static extern IntPtr GetConsoleWindow();

    #endregion

    #region Switches
    /// <summary>
    /// If true, Lilian will delete some data to save memory. Not helpful for debugging as it deletes the syntax tree and generated sentences.
    /// </summary>
    public static bool ConserveMemory { get; set; }

    /// <summary>
    /// If true, Lilian will omit every detailed version reference and replaces them with simply the X.X version number.
    /// To invoke release mode, the build string must contain "releaseman" (release to manufacturing in short).
    /// </summary>
    public static bool ReleaseMode { get; set; }

    /// <summary>
    /// If true, Lilian will run the compiled program.
    /// </summary>
    public static bool RunAfterwards { get; set; }

    /// <summary>
    /// Checks after execution if an error has been raised. If it does, end immediately.
    /// </summary>
    public static bool ErrorRaised { get; set; }
    #endregion

    /// <summary>
    /// The main entry point.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        #region cock check1
        if ((Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute).InformationalVersion.Contains("releaseman"))
            ReleaseMode = true;
        #endregion

        #region funky user32
        IntPtr handle = GetConsoleWindow();
        IntPtr SystemMenu = GetSystemMenu(handle, false);

        if (handle != IntPtr.Zero)
        {
            DeleteMenu(SystemMenu, 0xf030, 0x00000000);
            DeleteMenu(SystemMenu, 0xf000, 0x00000000);
        }
        #endregion

        CurrentThread.CurrentUICulture = CurrentThread.CurrentCulture;

        #region yanderesim-style checks
        if (args.Length >= 2)
        {
            if (args[0] == "-p" && File.Exists(args[1])) // -p <program> (run program)
            {
                Clear();
                LoadBinary(args[1]);
                Execute();
                Environment.Exit(0); // gtfo
            }
            else if (args[0] == "-proj" && File.Exists(args[1])) // -proj <project> [<out>] (compile project)
            {
                string @out = string.Empty;
                if (args.Length == 3 && File.Exists(args[2])) @out = args[2];

                SingleOrProj = true;
                InterpretSilent(args[1], @out);

                Environment.Exit(0);
            }
            else if (args[0] == "-file" && File.Exists(args[1])) // -file <script> [<out>] (compile single file)
            {
                string @out = string.Empty;
                if (args.Length == 3 && File.Exists(args[2])) @out = args[2];

                SingleOrProj = false;
                InterpretSilent(args[1], @out);

                Environment.Exit(0);
            }
        }
        #endregion

        SetWindowSize(81, 25);
        SetBufferSize(81, 25);
        WriteLine(
            $"\n\n\n\n\n\n\n\n\n\n{Properties.CoreContent.ProgramName}\n" +
            "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + (ReleaseMode ? "" : ", " + (Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute).InformationalVersion) + "\n" +
            (Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute).Copyright + "\n"
        );

        Sleep(1000);
        Clear();

        ApplicationTitle = Properties.CoreContent.ProgramName;
        LaunchUI();

        // Welcome screen
        DisplayScreen(
            Properties.CoreContent.WelcomeScreenBody,
            Properties.CoreContent.WelcomeScreenHeader,
            null,
            null,
            new FELUIAction(ConsoleKey.Enter, () => {; }, Properties.CoreContent.WelcomeScreenChoice1),
            new FELUIAction(ConsoleKey.F3, () => Environment.Exit(0), Properties.CoreContent.WelcomeScreenChoice2),
            new FELUIAction(ConsoleKey.A, () => {; }, "Argument help")
            );

#if COCOTESTS
        {
            // hardcode AYO.CCN lol
            RegulateCompilation = true;
            string test = @"D:\multitest\ayo.ccn";
            try
            {
                WriteLine("First pass on preproc!");
                if (!File.Exists(test)) ErrorScreen(new Lamentation("This build only does one thing: preprocess this one specific file. It ain't here so gudbaii :)"));
                else Preprocess(File.ReadAllLines(test));
                WriteLine("tests done!!!!!!!!!!!!!");
                WriteLine("Second pass on preproc!");
                Preprocess(ConsummateSource.ToArray(), true);
                ReadKey(true);
            }
            catch (Exception e)
            {
                ErrorScreen(e);
            }
            return;
        }
#endif

        // Choice screen
        DisplayScreen(
            Properties.CoreContent.ChoiceScreenBody,
            null,
            null,
            null,
            new FELUIAction(ConsoleKey.P, () => SingleOrProj = true, Properties.CoreContent.ChoiceScreenChoice1),
            new FELUIAction(ConsoleKey.S, () => SingleOrProj = false, Properties.CoreContent.ChoiceScreenChoice2),
            new FELUIAction(ConsoleKey.F3, () => Environment.Exit(0), Properties.CoreContent.WelcomeScreenChoice2)
            );
        string filepath = AskingFileScreen(SingleOrProj ? Properties.CoreContent.InputAskVer1 : Properties.CoreContent.InputAskVer2); string outpath;
        if (SingleOrProj) outpath = AskingScreen(Properties.CoreContent.OutputAsk); else outpath = Regex.Match(filepath, @"(?<Name>.+)\..+").Groups["Name"].Value + ".lsa";

        InterpretNewGUI(filepath, outpath.Trim('"'));

        if (!ErrorRaised)
        {
            DisplayScreen(
                Properties.CoreContent.Hurrah,
                null,
                Properties.CoreContent.HurrahAny);
            ReadKey(true);
        }
#if DEBUG && COMPARAISON
        DisplayScreen("Hey! You've unlocked the bonus level! We're gon create a comparison in case " +
            "something happened to the output. This is mandatory.",
            null,
            Properties.CoreContent.HurrahAny
            );
        ReadKey(true);
        FELAction[] correct = CurrentEffects.ToArray();
        CurrentEffects.Clear();
        LoadBinary(Outgoing);
        FELAction[] guest = CurrentEffects.ToArray();
        CurrentEffects.Clear();

        bool succ = false;
        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.Black;
        Clear();
        try
        {
            WriteLine("Test 1: physical difference");
            Write("Size: "); if (correct.Length == guest.Length) WriteLine("yes"); else throw new Lamentation("incorrect size");
            WriteLine("Test 2: deeper difference");
            for (int i = 0; i < correct.Length; i++)
            {
                if (correct[i].Value == guest[i].Value) WriteLine($"{correct[i]}\nv.\n{guest[i]}:\n{i} of {correct.Length - 1} verified");
                else if (correct[i].Value is object[] cola && guest[i].Value is object[] soda)
                {
                    if (cola.Length != soda.Length) throw new Lamentation($"mismatch: {i} {correct[i]} v. {guest[i]}. Incorrect lengths.");
                    for (int j = 0; j < cola.Length; j++)
                    {
                        string a = cola[j].ToString(); string b = soda[j].ToString();
                        if (a!=b) throw new Lamentation($"mismatch: {i} {correct[i]} v. {guest[i]}. {cola[j]} v. {soda[j]}.");
                        else WriteLine("u-huh. yes.");
                    }
                }
                else throw new Lamentation($"mismatch: {i} {correct[i]} v. {guest[i]}");
            }

            succ = true;
        }
        catch (Exception ex)
        {
            ErrorScreen(ex);
            succ = false;
            ReadKey(true);
        }
        finally
        {
            if (succ)
                DisplayScreen("Congration You done it",
                    null,
                    Properties.CoreContent.HurrahAny
                    );
            else
                DisplayScreen("fail :(",
                    null,
                    Properties.CoreContent.HurrahAny
                    );
            ReadKey(true);
        }
#else
        if (RunAfterwards)
        {
            Clear();
            Execute();
        }
        Environment.Exit(0);
#endif
    }
}

#endregion

#region Interpreter
/// <summary>
/// The main class for the interpeter.
/// </summary>
public static class Interpreter
{
    #region Static-field flags and data
    #region Execution
    /// <summary>
    /// Indicates that an error has been raised. This is used for branching operations that branch whenever an error occurs.
    /// </summary>
    public static bool ErrorRaised { get; set; }
    #endregion
    #region Compilation
    /// <summary>
    /// The unprocessed project file. (XML version)
    /// </summary>
    public static XmlDocument tempCurrFile;

    /// <summary>
    /// The unprocessed project file. (Coco version)
    /// </summary>
    public static string[] PreProcessFile { get; set; }

    /// <summary>
    /// The current file. Not exactly a single file, but a merger of all source files.
    /// </summary>
    public static List<string> CurrentFile = new();

    /// <summary>
    /// The files that are coming in through the <c>/include</c> command.
    /// </summary>
    public static List<string> IncomingFile = new();

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
    /// If <see langword="false"/>, the compiler will assume that everything is in one file.
    /// If <see langword="true"/>, the compiler will assume that a project file will be used.
    /// </summary>
    public static bool SingleOrProj { get; set; }

    /// <summary>
    /// The name of the project. Is also the name of the application unless stated otherwise.
    /// </summary>
    public static string ProjectTitle { get; set; }
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
    #region Operation
    /// <summary>
    /// The current collection of collection of objects relative to the current frame.
    /// </summary>
    public static List<FELFrame> CurrentFrame = new();

    /// <summary>
    /// The current saved collection of objects.
    /// </summary>
    public static List<FELObject> CurrentStore = new();

    /// <summary>
    /// The current struct being defined.
    /// </summary>
    public static FELStruct RawStructure { get; set; }

    /// <summary>
    /// The current frame being pointed to.
    /// </summary>
    public static int CurrentFrameIndex { get; set; }

    /// <summary>
    /// The stack pointer.
    /// </summary>
    public static int CurrentPointedObject { get; set; }

    /// <summary>
    /// The heap pointer.
    /// </summary>
    public static int CurrentPointedStruct { get; set; }

    /// <summary>
    /// The current instruction.
    /// </summary>
    public static int CurrentPointedEffect { get; set; }

    /// <summary>
    /// The current instruction relative to the current subroutine.
    /// </summary>
    public static int CurrentPointedSubEffect { get; set; }

    /// <summary>
    /// The current list of locations where the Call has left its footprint for returning.
    /// </summary>
    public static Stack<int> LocationHistoryForSubroutines = new();

    /// <summary>
    /// The current X register.
    /// </summary>
    public static int CurrentObjectX { get; set; }

    /// <summary>
    /// The current Y register.
    /// </summary>
    public static int CurrentObjectY { get; set; }

    /// <summary>
    /// The current accumulator.
    /// </summary>
    public static int CurrentObjectA { get; set; }
    #endregion
    #endregion

    #region Interpretation
    /// <summary>
    /// Static construction.
    /// </summary>
    static Interpreter() => TEMP.LOADPATTERNS();

    #region File operations
    /// <summary>
    /// Reads from a path.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    /// <exception cref="Lamentation"></exception>
    public static void ReadFile(string path)
    {
        if (File.Exists(path)) foreach (string line in File.ReadAllLines(path)) ConsummateSource.Add(line); else throw new Lamentation(3, path);
    }

    /// <summary>
    /// Adds any amount of lines to the current file.
    /// </summary>
    /// <param name="lines">Any amount of lines to be added.</param>
    public static void ReadFile(params string[] lines)
    {
        foreach (string line in lines) ConsummateSource.Add(line);
    }
    #endregion

    /// <summary>
    /// Do the whole thing.
    /// </summary>
    /// <param name="infile">The path to the input file.</param>
    /// <param name="outfile">The path to the output file.</param>
    public static void InterpretNewGUI(string infile, string outfile = "")
    {
        /*
         * Stages
         * 1. Checking the project file legibility - checking which version of the Coco preprocessor to use
         * 2. Passing to Coco                      - passing Coco preprocessor-compatible project file
         * 3. 
         */
        Stopwatch stopwatch = new();
        Outgoing = outfile;
        try
        {
            stopwatch.Start();

            int j;

            DisplayScreen(
                Properties.CoreContent.PleaseWait,
                null,
                $"{Properties.CoreContent.ReadingStatus} {infile}",
                null
                );

            if (SingleOrProj)
            {
                VersionSelector(infile);
                if (VersionOfCompilation)
                {
                    RegulateCompilation = false;
                    XmlDocument doc = new(); doc.Load(infile);
                    ReadProjectFile(doc);
                }
                else
                {
                    RegulateCompilation = true;
                    Preprocess(File.ReadAllLines(infile));
                }
                if (DoNotDoCompilation) return;
            }
            else
            {
                ReadFile(infile);
                ConsummateSource = CurrentFile;
            }
            DisplayScreen(
                Properties.CoreContent.PleaseWait,
                null,
                Properties.CoreContent.PreprocessStatus,
                null
                );
            Preprocess(ConsummateSource.ToArray(), true);


            DisplayScreen(
                Properties.CoreContent.PleaseWait,
                null,
                Properties.CoreContent.TranslationStatus
                );

            Clear();

            int k; // save to increm
            int p; // reserved for progress visualisation
            j = CurrentFile.Count + 1; p = j;
            for (int i = 1; i < j; i++)
            {
                ScanTokens(CurrentFile[i - 1]);
                TimeSpan dur = TimeSpan.FromMilliseconds((stopwatch.ElapsedMilliseconds / i) * (p - i));
                ProgressScreen((int)((decimal)i / (decimal)p * 100m), dur);
                p = j + CurrentWordPacks.Count;
            }
            k = j;
            j = k + CurrentWordPacks.Count; p = j;
            int l = 0;
            for (int i = k; i < j; i++)
            {
                ArrangeTokens(CurrentWordPacks[l]);
                TimeSpan dur = TimeSpan.FromMilliseconds((stopwatch.ElapsedMilliseconds / i) * (p - i));
                ProgressScreen((int)((decimal)i / (decimal)p * 100m), dur);
                l++; p = j + CurrentSentences.Count;
            }
            k = j; CurrentWordPacks = null;

            j = k + CurrentSentences.Count; p = j;
            CurrentPointedEffect = 0; l = 0;
            for (int i = k; i < j; i++)
            {
                PlaceEffect(InterpretSentenceNew(CurrentSentences[l]), CurrentPointedEffect, true);
                TimeSpan dur = TimeSpan.FromMilliseconds((stopwatch.ElapsedMilliseconds / i) * (p - i));
                ProgressScreen((int)((decimal)i / (decimal)p * 100m), dur);
                l++; CurrentPointedEffect++;
            }
            stopwatch.Stop();

            DisplayScreen(
                Properties.CoreContent.PleaseWaitFinal,
                null,
                Properties.CoreContent.LinkingStatus
                );
            CheckForFriendlyNames();
            CreateBinary(Outgoing);

            DisplayScreen(
                Properties.CoreContent.WannaRun,
                null,
                null,
                null,
                new FELUIAction(ConsoleKey.Y, () => Programme.RunAfterwards = true, Properties.CoreContent.Yes),
                new FELUIAction(ConsoleKey.N, () => Programme.RunAfterwards = false, Properties.CoreContent.No),
                new FELUIAction(ConsoleKey.F3, () => Environment.Exit(0), Properties.CoreContent.WelcomeScreenChoice2)
                );
            Programme.ErrorRaised = false;
        }
        catch (Lamentation lam)
        {
            stopwatch.Stop();
            ErrorScreen(lam);
            Programme.ErrorRaised = true;
            ReadKey(true);
        }
    }

    /// <summary>
    /// Do the whole thing. (Doesn't use the GUI)
    /// </summary>
    /// <param name="infile">The path to the input file.</param>
    /// <param name="outfile">The path to the output file.</param>
    public static void InterpretSilent(string infile, string outfile = "")
    {
        try
        {
            if (SingleOrProj)
            {
                VersionSelector(infile);
                if (VersionOfCompilation)
                {
                    RegulateCompilation = false;
                    XmlDocument doc = new(); doc.Load(infile);
                    ReadProjectFile(doc);
                }
                else
                {
                    RegulateCompilation = true;
                    Preprocess(File.ReadAllLines(infile));
                }
                if (DoNotDoCompilation) return;
            }
            else
            {
                ReadFile(infile);
                ConsummateSource = CurrentFile;
            }

            for (int i = 0; i < CurrentFile.Count; i++) ScanTokens(CurrentFile[i]);
            for (int i = 0; i < CurrentWordPacks.Count; i++) ArrangeTokens(CurrentWordPacks[i]);

            for (int i = 0; i < CurrentSentences.Count; i++)
            {
                PlaceEffect(InterpretSentenceNew(CurrentSentences[i]), CurrentPointedEffect, true);
                CurrentPointedEffect++;
            }
            CheckForFriendlyNames();
            CreateBinary(Outgoing);

            Programme.ErrorRaised = false;
        }
        catch (Lamentation lam)
        {
            ErrorScreen(lam);
            Programme.ErrorRaised = true;
            ReadKey(true);
        }

    }

    #endregion
    #region Spellbook
    /// <summary>
    /// The lexer and parser components of the interpreter.
    /// </summary>
    public static class Spellbook
    {
        /// <summary>
        /// The currently-registered tokens.
        /// </summary>
        public static List<Token> CurrentTokens = new();

        /// <summary>
        /// The currently-registered sentence structures.
        /// </summary>
        public static List<SentenceStructure> CurrentSentenceStructures = new();

        #region Stuffs
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

            /// <summary>
            /// Returns the string representation of the token.
            /// </summary>
            /// <returns>The string representation.</returns>
            public override string ToString() => $"{AssociatedSentence.Name}.";
        }
        #endregion
    }

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

        if (tokenFruits.All(thing => thing.AssociatedToken.IgnoreOnRefinement)) return; // gtfo outta there

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
                break;
            }
            else
            {
                if (@struct.Count - removed != bunch.Count) continue; else throw new Lamentation(2);
            }
        }

        @struct.Clear();
        other.Clear();

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
                if (sent.Value[1] == "boolean" && bool.TryParse(sent.Value[2], out bool valF)) val = valF;
                else if (sent.Value[1] == "sbyte" && sbyte.TryParse(sent.Value[2], out sbyte valG)) val = valG;
                else if (sent.Value[1] == "byte" && byte.TryParse(sent.Value[2], out byte valH)) val = valH;
                else if (sent.Value[1] == "short" && short.TryParse(sent.Value[2], out short valI)) val = valI;
                else if (sent.Value[1] == "ushort" && ushort.TryParse(sent.Value[2], out ushort valJ)) val = valJ;
                else if (sent.Value[1] == "integer" && int.TryParse(sent.Value[2], out int valK)) val = valK;
                else if (sent.Value[1] == "uinteger" && uint.TryParse(sent.Value[2], out uint valL)) val = valL;
                else if (sent.Value[1] == "long" && long.TryParse(sent.Value[2], out long valM)) val = valM;
                else if (sent.Value[1] == "ulong" && ulong.TryParse(sent.Value[2], out ulong valN)) val = valN;
                else if (sent.Value[1] == "half" && Half.TryParse(sent.Value[2], out Half valO)) val = valO;
                else if (sent.Value[1] == "float" && float.TryParse(sent.Value[2], out float valP)) val = valP;
                else if (sent.Value[1] == "double" && double.TryParse(sent.Value[2], out double valQ)) val = valQ;
                else if (sent.Value[1] == "quadruple" && decimal.TryParse(sent.Value[2], out decimal valR)) val = valR;
                else if (sent.Value[1] == "character" && char.TryParse(sent.Value[2], out char valS)) val = valS;
                else if (sent.Value[1] == "string" && sent.Value[2].Contains('"')) val = sent.Value[2].Trim('"');
                else if (bool.TryParse(sent.Value[1], out bool val1)) val = val1;
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
                return new(exval is not null ? FELActionType.@throwc : FELActionType.@throw, exval);
            case "title":
                return new(FELActionType.settitle, sent.Value[1].Trim('"'));
            case "pause":
                return new(
                    FELActionType.pause,
                    int.TryParse(sent.Value[1], out int zE) ? zE : throw new Lamentation(0x21, sent.Value[1])
                    );
            case "wait":
                return new(FELActionType.wait);
            case "define":
                return new(
                    FELActionType.define,
                    sent.Value[1].TrimStart('&')
                    );
            case "furnish":
                string proposedType;
                if (sent.Value[1] == "boolean"
                    || sent.Value[1] == "sbyte"
                    || sent.Value[1] == "byte"
                    || sent.Value[1] == "short"
                    || sent.Value[1] == "ushort"
                    || sent.Value[1] == "integer"
                    || sent.Value[1] == "uinteger"
                    || sent.Value[1] == "long"
                    || sent.Value[1] == "ulong"
                    || sent.Value[1] == "half"
                    || sent.Value[1] == "float"
                    || sent.Value[1] == "double"
                    || sent.Value[1] == "quadruple"
                    || sent.Value[1] == "character"
                    || sent.Value[1] == "string") proposedType = sent.Value[1];
                else throw new Lamentation("Custom types are not yet supported for properties at this time.");
                return new(
                    FELActionType.furnish,
                    new object[]
                    {
                            proposedType,
                            sent.Value[2].TrimStart('#')
                    }
                    );
            case "finalise":
                return new(FELActionType.finalise);
            case "shelve":
                return new(FELActionType.shelve);
            case "create":
                return new(
                    FELActionType.create,
                    sent.Value[1].TrimStart('&')
                    );
            case "delete":
                return new(
                    FELActionType.delete,
                    sent.Value[1].TrimStart('*')
                    );
            case "present":
                return new(
                    FELActionType.present,
                    sent.Value[1].TrimStart('*')
                    );
            case "get":
                return new(
                    FELActionType.@get,
                    new object[]
                    {
                            sent.Value[1] == "!"? new FELCompilerFlag() : sent.Value[1].TrimStart('*'),
                            sent.Value[2].TrimStart('#')
                    }
                    );
            case "set":
                return new(
                    FELActionType.@set,
                    new object[]
                    {
                            sent.Value[1] == "!"? new FELCompilerFlag() : sent.Value[1].TrimStart('*'),
                            sent.Value[2].TrimStart('#')
                    }
                    );
            case "save":
                return new(
                    FELActionType.save,
                    sent.Value[1].TrimStart('*')
                    );
            case "put":
                object ident = sent.Value[1] == "!"? new FELCompilerFlag() : sent.Value[1].TrimStart('*');
                object newname = sent.Value[2] == "!" ? new FELCompilerFlag() : sent.Value[2].TrimStart('#');
                return new(
                    FELActionType.put,
                    new object[] { ident, newname }
                    );
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
    #endregion
    #region Execution
    /// <summary>
    /// Runs the currently-loaded binary.
    /// </summary>
    public static void Execute()
    {
        CurrentFrame.Add(new(new(), new()));
        CurrentFrameIndex = 0;
        CurrentPointedEffect = 0;

        while (CurrentPointedEffect < CurrentEffects.Count) CurrentEffects[CurrentPointedEffect].Invoke();
    }
    #endregion
    #region Lamentation
    /// <summary>
    /// A compiler error to Lilian. However, it can also occur <em>during runtime</em>.
    /// </summary>
    public class Lamentation : Exception
    {
        /// <summary>
        /// Initialises the standard error code-string pairs for a lamentation.
        /// </summary>
        static Lamentation()
        {
            def = new();
            def.Add(0x0000, Properties.CoreContent.Lamentation1);
            def.Add(0x0001, Properties.CoreContent.Lamentation2);
            def.Add(0x0002, Properties.CoreContent.Lamentation3);
            def.Add(0x0003, Properties.CoreContent.Lamentation4);
            def.Add(0x0004, Properties.CoreContent.Lamentation5);
            def.Add(0x0005, Properties.CoreContent.Lamentation6);
            def.Add(0x0006, Properties.CoreContent.Lamentation7);
            def.Add(0x0007, Properties.CoreContent.Lamentation8);
            def.Add(0x0008, Properties.CoreContent.Lamentation9);
            def.Add(0x0009, Properties.CoreContent.Lamentation10);
            def.Add(0x000A, Properties.CoreContent.Lamentation11);
            def.Add(0x000B, Properties.CoreContent.Lamentation12);
            def.Add(0x000C, Properties.CoreContent.Lamentation13);
            def.Add(0x000D, Properties.CoreContent.Lamentation14);
            def.Add(0x000E, Properties.CoreContent.Lamentation15);
            def.Add(0x000F, Properties.CoreContent.Lamentation16);
            def.Add(0x0010, Properties.CoreContent.Lamentation17);
            def.Add(0x0011, Properties.CoreContent.Lamentation18);
            def.Add(0x0012, Properties.CoreContent.Lamentation19);
            def.Add(0x0013, Properties.CoreContent.Lamentation20);
            def.Add(0x0014, Properties.CoreContent.Lamentation21);
            def.Add(0x0015, Properties.CoreContent.Lamentation22);
            def.Add(0x0016, Properties.CoreContent.Lamentation23);
            def.Add(0x0017, Properties.CoreContent.Lamentation24);
            def.Add(0x0018, Properties.CoreContent.Lamentation25);
            def.Add(0x0019, Properties.CoreContent.Lamentation26);
            def.Add(0x0020, Properties.CoreContent.Lamentation27);
            def.Add(0x0021, Properties.CoreContent.Lamentation28);
            def.Add(0x0022, Properties.CoreContent.Lamentation29);
            def.Add(0x0023, Properties.CoreContent.Lamentation30);
            def.Add(0x0024, Properties.CoreContent.Lamentation31);
            def.Add(0x0025, Properties.CoreContent.Lamentation32);
            def.Add(0x0026, Properties.CoreContent.Lamentation33);
            def.Add(0x0027, Properties.CoreContent.Lamentation34);
            def.Add(0x0028, Properties.CoreContent.Lamentation35);
            def.Add(0x0029, Properties.CoreContent.Lamentation36);
            def.Add(0x002A, Properties.CoreContent.Lamentation37);
            def.Add(0x002B, Properties.CoreContent.Lamentation38);
            def.Add(0x002C, Properties.CoreContent.Lamentation39);
            def.Add(0x002D, Properties.CoreContent.Lamentation40);
            def.Add(0x002E, Properties.CoreContent.Lamentation41);
            def.Add(0x002F, Properties.CoreContent.Lamentation42);
            def.Add(0x0030, Properties.CoreContent.Lamentation43);
            def.Add(0x0031, Properties.CoreContent.Lamentation44);
            def.Add(0x0032, Properties.CoreContent.Lamentation45);
            def.Add(0x0033, Properties.CoreContent.Lamentation46);
            def.Add(0x0034, Properties.CoreContent.Lamentation47);
            def.Add(0x0035, Properties.CoreContent.Lamentation48);
            def.Add(0x0036, Properties.CoreContent.Lamentation49);
            def.Add(0x0037, Properties.CoreContent.Lamentation50);
            def.Add(0x0038, Properties.CoreContent.Lamentation51);
            def.Add(0x0039, Properties.CoreContent.Lamentation52);
            def.Add(0x003A, Properties.CoreContent.Lamentation53);
            def.Add(0x003B, Properties.CoreContent.Lamentation54);
            def.Add(0x003C, Properties.CoreContent.Lamentation55);
            def.Add(0x003D, Properties.CoreContent.Lamentation56);
            def.Add(0x003E, Properties.CoreContent.Lamentation57);
            def.Add(0x003F, Properties.CoreContent.Lamentation58);
            def.Add(0x0040, Properties.CoreContent.Lamentation59);
            def.Add(0x0041, Properties.CoreContent.Lamentation60);
            def.Add(0x0042, Properties.CoreContent.Lamentation61);
            def.Add(0x0043, Properties.CoreContent.Lamentation62);
            def.Add(0x0044, Properties.CoreContent.Lamentation63);
            def.Add(0x0045, Properties.CoreContent.Lamentation64);
            def.Add(0x0046, Properties.CoreContent.Lamentation65);
            def.Add(0x0047, Properties.CoreContent.Lamentation66);
            def.Add(0x0048, Properties.CoreContent.Lamentation67);
            def.Add(0x0049, Properties.CoreContent.Lamentation68);
            def.Add(0x004A, Properties.CoreContent.Lamentation69);
            def.Add(0x004B, Properties.CoreContent.Lamentation70);
            def.Add(0x004C, Properties.CoreContent.Lamentation71);
            def.Add(0x004D, Properties.CoreContent.Lamentation72);
            def.Add(0x004E, Properties.CoreContent.Lamentation73);
            def.Add(0x004F, Properties.CoreContent.Lamentation74);
            def.Add(0x0050, Properties.CoreContent.Lamentation75);
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class.
        /// </summary>
        public Lamentation()
        {
            Message = def[0];
            ErrorCode = 0;
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class with a specified error message.
        /// </summary>
        /// <param name="msg">The error message.</param>
        public Lamentation(string msg)
        {
            Message = msg;
            ErrorCode = 0;
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class with a specified error message and error code.
        /// </summary>
        /// <param name="msg">The error message.</param>
        /// <param name="err">The error code.</param>
        public Lamentation(string msg, int err)
        {
            Message = msg;
            ErrorCode = err;
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class with a specified error code. The constructor
        ///will check for a code-message pair to find that error. Else, throw a Lamentation, whilst creating
        ///one.
        /// </summary>
        /// <param name="code">The error code.</param>
        public Lamentation(int code)
        {
            if (def.ContainsKey(code))
            {
                Message = def[code];
                ErrorCode = code;
            }
            else throw new Lamentation(0x2e, code.ToString());
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class with a specified error code and appropriate
        ///data such as line numbers or current tokens. The constructor will check for a code-message pair
        ///to find that error. Else, throw a Lamentation, whilst creating one.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="data">Related data such as line numbers or current tokens.</param>
        public Lamentation(int code, params string[] data)
        {
            if (def.ContainsKey(code))
            {
                Message = string.Format(def[code], data);
                ErrorCode = code;
            }
            else throw new Lamentation(0x2e, code.ToString());
        }

        /// <summary>
        /// Gets the error code of the lamentation.
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// Gets a message that describes the current lamentation.
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// An internal dictionary for getting a code-message pair.
        /// </summary>
        private static readonly Dictionary<int, string> def;

        /// <summary>
        /// Creates and returns a string representation of the current lamentation.
        /// </summary>
        public override string ToString() => string.Format("LP{0:0000}: {1}", ErrorCode, Message);

        /// <summary>
        /// Turns an exception name into a friendly one.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <returns>A friendly name version of the exception.</returns>
        public static string InterpretExceptionName(Exception e)
        {
            var mtc = Regex.Matches(e.GetBaseException().GetType().Name, @"[A-Z][a-z]*");

            List<string> conts = new();

            foreach (Match capt in mtc) { conts.Add(capt.Value); }
            for (int i = 1; i < conts.Count; i++) conts[i] = conts[i].ToLower();

            return string.Join(" ", conts.ToArray());
        }
    }

    #endregion
    #region Operation
    /// <summary>
    /// The main opcode interpretation class.
    /// </summary>
    public static partial class Actualiser
    {
        /// <summary>
        /// The current list of actions.
        /// </summary>
        /// <remarks>
        /// <em>I did not choose the name, Intellicode/Pilot did. This will be a meme from now on.</em>
        /// </remarks>
        public static List<FELAction> CurrentEffects = new();

        /// <summary>
        /// A form of delegate??? but not quite?? for use with the stack.
        /// </summary>
        /// <param name="ActionType">What to do.</param>
        /// <param name="Value">The value. Only valid for operations that .</param>
        public record struct FELAction(FELActionType ActionType, dynamic? Value = null)
        {
            /// <summary>
            /// Returns the string representation of this action.
            /// </summary>
            /// <returns>The action in a string format. Does not return the original statement though.</returns>
            public override string ToString() => $"{ActionType}: {Value ?? "void"}";

            /// <summary>
            /// Invokes the action.
            /// </summary>
            public void Invoke()
            {
                try
                {
                    switch (ActionType)
                    {
                        #region Default
                        case FELActionType.nop:
                            goto GoForward;
                        #endregion
                        #region Stack operations
                        case FELActionType.push:
                            if (Value is not null) CurrentFrame[CurrentFrameIndex].StackFrame.Push(Value); // nah do nothing instead of crying
                            goto GoForward;
                        case FELActionType.pop:
                            if (CurrentFrame[CurrentFrameIndex].StackFrame.Count != 0) CurrentFrame[CurrentFrameIndex].StackFrame.Pop(); // do nothing if the stack is empty
                            goto GoForward;
                        #endregion
                        #region Print
                        case FELActionType.print:
                            WriteLine(CurrentFrame[CurrentFrameIndex].StackFrame.Count != 0 ? CurrentFrame[CurrentFrameIndex].StackFrame.Peek() : "There is nothing to print.");
                            goto GoForward;
                        #endregion
                        #region Arithmetic operations
                        case FELActionType.add:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a + b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.sub:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a - b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.mul:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a * b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.div:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a / b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.mod:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a % b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.lst:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a << b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.rst:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a >> b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.and:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a & b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.or:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a | b); // rely on implementation...
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.xor:
                            try
                            {
                                dynamic a = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                dynamic b = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                if (a is FELStruct || b is FELStruct) throw new Lamentation(0x50);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(a ^ b); // rely on implementation...
                            }
                            catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                            {
                                throw;
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        #endregion
                        #region Variable management operations
                        case FELActionType.store:
                            dynamic x = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                            if (Value is string @string) CurrentStore.Add(new(CurrentStore.Count, @string, x));
                            else if (Value is int number) CurrentStore.Add(new(number, "", x));
                            goto GoForward;
                        case FELActionType.load:
                            dynamic name = Value!;
                            if (
                                (name is string str && CurrentStore.Exists(obj => obj.Name == str)) ||
                                (name is int num && CurrentStore.Exists(obj => obj.Address == num))
                            )
                            {
                                FELObject selected = default;
                                if (name is string strn) selected = CurrentStore.Find(obj => obj.Name == strn);
                                else if (name is int numa) selected = CurrentStore.Find(obj => obj.Address == numa);
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(selected.Value);
                                //CurrentStore.Remove(selected);
                            }
                            else throw new Lamentation(0x18,
                                (
                                    name switch
                                    {
                                        string => name,
                                        int => name.ToString(),
                                        _ => string.Empty,
                                    }
                                ));
                            goto GoForward;
                        #endregion
                        #region Branching operations
                        case FELActionType.beq:
                            dynamic z = Value!;
                            if (z is int index)
                            {
                                if (index < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        dynamic var2 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct || var2 is FELStruct) throw new Lamentation(0x50);
                                        if (var1 == var2) CurrentPointedEffect = index; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index.ToString());
                            }
                            else throw new Lamentation(0x19, z.ToString());
                            return;
                        case FELActionType.bne:
                            dynamic bne = Value!;
                            if (bne is int index2)
                            {
                                if (index2 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        dynamic var2 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct || var2 is FELStruct) throw new Lamentation(0x50);
                                        if (var1 != var2) CurrentPointedEffect = index2; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index2.ToString());
                            }
                            else throw new Lamentation(0x19, bne.ToString());
                            return;
                        case FELActionType.bgt:
                            dynamic z3 = Value!;
                            if (z3 is int index3)
                            {
                                if (index3 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        dynamic var2 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct || var2 is FELStruct) throw new Lamentation(0x50);
                                        if (var1 > var2) CurrentPointedEffect = index3; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index3.ToString());
                            }
                            else throw new Lamentation(0x19, z3.ToString());
                            return;
                        case FELActionType.bge:
                            dynamic z4 = Value!;
                            if (z4 is int index4)
                            {
                                if (index4 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        dynamic var2 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct || var2 is FELStruct) throw new Lamentation(0x50);
                                        if (var1 >= var2) CurrentPointedEffect = index4; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index4.ToString());
                            }
                            else throw new Lamentation(0x19, z4.ToString());
                            return;
                        case FELActionType.blt:
                            dynamic z5 = Value!;
                            if (z5 is int index5)
                            {
                                if (index5 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        dynamic var2 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct || var2 is FELStruct) throw new Lamentation(0x50);
                                        if (var1 < var2) CurrentPointedEffect = index5; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index5.ToString());
                            }
                            else throw new Lamentation(0x19, z5.ToString());
                            return;
                        case FELActionType.ble:
                            dynamic z6 = Value!;
                            if (z6 is int index6)
                            {
                                if (index6 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        dynamic var2 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct || var2 is FELStruct) throw new Lamentation(0x50);
                                        if (var1 == var2) CurrentPointedEffect = index6; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index6.ToString());
                            }
                            else throw new Lamentation(0x19, z6.ToString());
                            return;
                        case FELActionType.btr:
                            dynamic z7 = Value!;
                            if (z7 is int index7)
                            {
                                if (index7 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct) throw new Lamentation(0x50);
                                        if (var1) CurrentPointedEffect = index7; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index7.ToString());
                            }
                            else throw new Lamentation(0x19, z7.ToString());
                            return;
                        case FELActionType.bfl:
                            dynamic z8 = Value!;
                            if (z8 is int index8)
                            {
                                if (index8 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct) throw new Lamentation(0x50);
                                        if (!var1) CurrentPointedEffect = index8; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index8.ToString());
                            }
                            else throw new Lamentation(0x19, z8.ToString());
                            return;
                        case FELActionType.@goto:
                            dynamic z9 = Value!;
                            if (z9 is int index9)
                            {
                                if (index9 < CurrentEffects.Count) CurrentPointedEffect = index9;
                                else throw new Lamentation(0x20, index9.ToString());
                            }
                            else throw new Lamentation(0x19, z9.ToString());
                            return;
                        default: throw new Lamentation(0x16, ActionType.ToString());
                        case FELActionType.bsa:
                            dynamic zA = Value!;
                            if (zA is int indexA)
                            {
                                if (indexA < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        dynamic var2 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct || var2 is FELStruct) throw new Lamentation(0x50);
                                        if (var1 && var2) CurrentPointedEffect = indexA; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, indexA.ToString());
                            }
                            else throw new Lamentation(0x19, zA.ToString());
                            return;
                        case FELActionType.bso:
                            dynamic zB = Value!;
                            if (zB is int indexB)
                            {
                                if (indexB < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        dynamic var2 = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                                        if (var1 is FELStruct || var2 is FELStruct) throw new Lamentation(0x50);
                                        if (var1 || var2) CurrentPointedEffect = indexB; else goto GoForward;
                                    }
                                    catch (Lamentation bruhMoment) when (bruhMoment.ErrorCode == 0x50)
                                    {
                                        throw;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, indexB.ToString());
                            }
                            else throw new Lamentation(0x19, zB.ToString());
                            return;
                        case FELActionType.end:
                            Environment.Exit(0);
                            return;
                        #endregion
                        #region User interaction operations
                        case FELActionType.take:
                            Write("-> ");
                            string? asked = ReadLine();
                            dynamic content;
                            if (!string.IsNullOrEmpty(asked)) content = asked!; else goto GoForward;
                            // automatic conversion
                            string prim = (string)content;
                            if (bool.TryParse(prim, out bool val1)) content = val1;
                            else if (sbyte.TryParse(prim, out sbyte val2)) content = val2;
                            else if (byte.TryParse(prim, out byte val3)) content = val3;
                            else if (short.TryParse(prim, out short val4)) content = val4;
                            else if (ushort.TryParse(prim, out ushort val5)) content = val5;
                            else if (int.TryParse(prim, out int val6)) content = val6;
                            else if (uint.TryParse(prim, out uint val7)) content = val7;
                            else if (long.TryParse(prim, out long val8)) content = val8;
                            else if (ulong.TryParse(prim, out ulong val9)) content = val9;
                            else if (Half.TryParse(prim, out Half valA)) content = valA;
                            else if (float.TryParse(prim, out float valB)) content = valB;
                            else if (double.TryParse(prim, out double valC)) content = valC;
                            else if (decimal.TryParse(prim, out decimal valD)) content = valD;
                            else if (char.TryParse(prim, out char valE)) content = valE;
                            CurrentFrame[CurrentFrameIndex].StackFrame.Push(content!);
                            goto GoForward;
                        case FELActionType.ask:
                            Write("=> ");
                            string? asked2 = ReadLine();
                            string content2 = string.Empty;
                            if (!string.IsNullOrEmpty(asked2)) content2 = asked2!;
                            CurrentFrame[CurrentFrameIndex].StackFrame.Push(content2);
                            goto GoForward;
                        #endregion
                        #region Data manipulation operations
                        case FELActionType.narrow:
                            dynamic narrowand = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                            unchecked
                            {
                                dynamic result1 = narrowand switch
                                {
                                    string => throw new Lamentation(0x24, narrowand.ToString()),
                                    bool => throw new Lamentation(0x22, narrowand.ToString()),
                                    sbyte => narrowand > 0 ? 1 : 0,
                                    byte => (sbyte)narrowand,
                                    short => (byte)narrowand,
                                    ushort => (short)narrowand,
                                    int => (ushort)narrowand,
                                    uint => (int)narrowand,
                                    long => (uint)narrowand,
                                    ulong => (long)narrowand,
                                    Half => throw new Lamentation(0x22, narrowand.ToString()),
                                    float => (Half)narrowand,
                                    double => (float)narrowand,
                                    decimal => (double)narrowand,
                                    char => throw new Lamentation(0x26, narrowand.ToString()),
                                    _ => throw new Lamentation(0x28, narrowand.ToString()),
                                };
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(result1);
                            }
                            goto GoForward;
                        case FELActionType.widen:
                            dynamic widand = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                            unchecked
                            {
                                dynamic result1 = widand switch
                                {
                                    string => throw new Lamentation(0x25, widand.ToString()),
                                    bool => (sbyte)widand,
                                    sbyte => (byte)widand,
                                    byte => (short)widand,
                                    short => (ushort)widand,
                                    ushort => (int)widand,
                                    int => (uint)widand,
                                    uint => (long)widand,
                                    long => (ulong)widand,
                                    ulong => throw new Lamentation(0x23, widand.ToString()),
                                    Half => (float)widand,
                                    float => (double)widand,
                                    double => (decimal)widand,
                                    decimal => throw new Lamentation(0x23, widand.ToString()),
                                    char => throw new Lamentation(0x27, widand.ToString()),
                                    _ => throw new Lamentation(0x29, widand.ToString()),
                                };
                                CurrentFrame[CurrentFrameIndex].StackFrame.Push(result1);
                            }
                            goto GoForward;
                        case FELActionType.realise:
                            string rel = (string)CurrentFrame[CurrentFrameIndex].StackFrame.Pop()!;
                            dynamic? realisand = null;

                            if (string.IsNullOrEmpty(rel)) goto GoForward;

                            if (bool.TryParse(rel, out bool valR1)) realisand = valR1;
                            else if (sbyte.TryParse(rel, out sbyte valR2)) realisand = valR2;
                            else if (byte.TryParse(rel, out byte valR3)) realisand = valR3;
                            else if (short.TryParse(rel, out short valR4)) realisand = valR4;
                            else if (ushort.TryParse(rel, out ushort valR5)) realisand = valR5;
                            else if (int.TryParse(rel, out int valR6)) realisand = valR6;
                            else if (uint.TryParse(rel, out uint valR7)) realisand = valR7;
                            else if (long.TryParse(rel, out long valR8)) realisand = valR8;
                            else if (ulong.TryParse(rel, out ulong valR9)) realisand = valR9;
                            else if (Half.TryParse(rel, out Half valRA)) realisand = valRA;
                            else if (float.TryParse(rel, out float valRB)) realisand = valRB;
                            else if (double.TryParse(rel, out double valRC)) realisand = valRC;
                            else if (decimal.TryParse(rel, out decimal valRD)) realisand = valRD;
                            else if (char.TryParse(rel, out char valRE)) realisand = valRE;
                            else throw new Lamentation(0x24, rel);

                            CurrentFrame[CurrentFrameIndex].StackFrame.Push(realisand!);

                            goto GoForward;
                        #endregion
                        #region Lamentations
                        case FELActionType.@catch:
                            if (!ErrorRaised) goto GoForward;
                            ErrorRaised = false;
                            CurrentPointedEffect = Value!;
                            return;
                        #endregion
                        #region Branching operations
                        case FELActionType.call:
                            dynamic zC = Value!;
                            if (zC is int indexC)
                            {
                                if (indexC < CurrentEffects.Count)
                                {
                                    LocationHistoryForSubroutines.Push(CurrentPointedEffect);
                                    CurrentPointedEffect = indexC;
                                    CurrentFrame.Add(new(new(), new()));
                                    CurrentFrameIndex++;
                                    // carry over the variables in the previous context
                                    foreach (object item in CurrentFrame[CurrentFrameIndex - 1].StackFrame) CurrentFrame[CurrentFrameIndex].StackFrame.Push(item);
                                    foreach (FELStruct item in CurrentFrame[CurrentFrameIndex - 1].HeapFrame) CurrentFrame[CurrentFrameIndex].HeapFrame.Add(item);
                                }
                                else throw new Lamentation(0x20, indexC.ToString());
                            }
                            else throw new Lamentation(0x19, zC.ToString());
                            return;
                        case FELActionType.@return:
                            if (LocationHistoryForSubroutines.Count > 0)
                            {
                                CurrentPointedEffect = LocationHistoryForSubroutines.Pop();
                                if (CurrentFrame[CurrentFrameIndex].StackFrame.Count > 0) CurrentFrame[CurrentFrameIndex - 1].StackFrame.Push(CurrentFrame[CurrentFrameIndex].StackFrame.Pop()); // carry over
                                CurrentFrame[CurrentFrameIndex].StackFrame.Clear();
                                CurrentFrame[CurrentFrameIndex].HeapFrame.Clear();
                                CurrentFrame.RemoveAt(CurrentFrameIndex); // get rid of frame
                                CurrentFrameIndex--; // go back
                            }
                            else goto case FELActionType.end; // redirect to end
                            goto GoForward;
                        #endregion
                        #region Lamentations
                        case FELActionType.@throw:
                            throw new Lamentation(0x2F);
                        case FELActionType.throwc:
                            dynamic? bruh = Value;
                            if (bruh is string msg) throw new Lamentation(0x2D, msg);
                            else if (bruh is int code) throw new Lamentation(code);
                            goto GoForward;
                        #endregion
                        #region Cosmetics
                        case FELActionType.settitle:
                            Title = Value!;
                            goto GoForward;
                        #endregion
                        #region User interaction operations
                        case FELActionType.pause:
                            dynamic pause = Value!;
                            if (pause is int duration) Thread.Sleep(duration);
                            else throw new Lamentation(0x19, pause.ToString());
                            goto GoForward;
                        case FELActionType.wait:
                            ReadKey(true);
                            goto GoForward;
                        #endregion
                        #region Object model operations
                        case FELActionType.define:
                            string Name = Value!;
                            TypeRegistry.Insert(CurrentType, new(Name, new()));
                            goto GoForward;
                        case FELActionType.furnish:
                            string TypeName = Value![0]!; // lol it's in the form of object?[x]?
                            string PropName = Value![1]!;

                            TypeRegistry[CurrentType].PropertyList.Add(PropName,
                                TypeName switch
                                {
                                    "string" => typeof(string),
                                    "boolean" => typeof(bool),
                                    "sbyte" => typeof(sbyte),
                                    "byte" => typeof(byte),
                                    "short" => typeof(short),
                                    "ushort" => typeof(ushort),
                                    "integer" => typeof(int),
                                    "uinteger" => typeof(uint),
                                    "long" => typeof(long),
                                    "ulong" => typeof(ulong),
                                    "half" => typeof(Half),
                                    "float" => typeof(float),
                                    "double" => typeof(double),
                                    "quadruple" => typeof(decimal),
                                    "character" => typeof(char),
                                    _ => throw new Lamentation("Custom types are not yet supported for properties at this time.")
                                }
                                );
                            goto GoForward;
                        case FELActionType.finalise:
                            CurrentType++;
                            goto GoForward;
                        case FELActionType.create:
                            string BruhName = Value!;
                            FELStructType AssociatedType = TypeRegistry.Find(t => t.Name == BruhName);
                            if (AssociatedType is null) throw new Lamentation(0x49, BruhName);

                            RawStructure = new(0, string.Empty, AssociatedType, new());
                            foreach ((string objn, Type bruh1) in AssociatedType.PropertyList)
                                RawStructure.Values.Add(objn, default);

                            List<object> supposedProps = new();
                            foreach ((string objname, Type type) in RawStructure.Type.PropertyList)
                            {
                                dynamic supposed = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();

                                if (supposed.GetType() == type || supposed is null)
                                    RawStructure.Values[objname] = new(-1, objname, supposed);
                                else throw new Lamentation(0x4A, supposed.GetType().Name, objname, type.Name);
                            }
                            goto GoForward;
                        case FELActionType.save:
                            string newName = Value!;
                            CurrentFrame[CurrentFrameIndex].HeapFrame.Add(RawStructure with { Name = newName, Address = CurrentFrame[CurrentFrameIndex].HeapFrame.Count });
                            RawStructure = null;
                            goto GoForward;
                        case FELActionType.delete:
                            string ayoName = Value!;
                            if (!CurrentFrame[CurrentFrameIndex].HeapFrame.Exists(t => t.Name == ayoName)) throw new Lamentation(0x49, ayoName);
                            CurrentFrame[CurrentFrameIndex].HeapFrame.Remove(CurrentFrame[CurrentFrameIndex].HeapFrame.Find(t => t.Name == ayoName));
                            goto GoForward;
                        case FELActionType.storestruct:
                            throw new Lamentation(0x4F);
                        case FELActionType.get:
                            string getName = Value![1]!;
                            bool presentation = false; string unpresent = string.Empty;

                            if (Value![0] is FELCompilerFlag) presentation = true;
                            else if (Value![0] is string suppParName)
                            {
                                if (!CurrentFrame[CurrentFrameIndex].HeapFrame.Exists(t => t.Name == suppParName)) throw new Lamentation(0x49, suppParName);
                                presentation = false; unpresent = suppParName;
                            }

                            FELStruct getThing = presentation ? (RawStructure ?? throw new Lamentation(0x4B)) : CurrentFrame[CurrentFrameIndex].HeapFrame.Find(t => t.Name == unpresent);

                            if (!getThing.Values.ContainsKey(getName)) throw new Lamentation(0x4C, getName, getThing.Type.Name);

                            CurrentFrame[CurrentFrameIndex].StackFrame.Push(getThing.Values[getName]);
                            goto GoForward;
                        case FELActionType.set:
                            string setName = Value![1]!;
                            bool spresentation = false; string unspresent = string.Empty;

                            if (Value![0] is FELCompilerFlag) spresentation = true;
                            else if (Value![0] is string suppParName)
                            {
                                if (!CurrentFrame[CurrentFrameIndex].HeapFrame.Exists(t => t.Name == suppParName)) throw new Lamentation(0x49, suppParName);
                                spresentation = false; unspresent = suppParName;
                            }

                            FELStruct setThing = spresentation ? (RawStructure ?? throw new Lamentation(0x4B)) : CurrentFrame[CurrentFrameIndex].HeapFrame.Find(t => t.Name == unspresent);

                            if (!setThing.Values.ContainsKey(setName)) throw new Lamentation(0x4C, setName, setThing.Type.Name);

                            dynamic shit = CurrentFrame[CurrentFrameIndex].StackFrame.Pop();
                            Type comparaison = setThing.Type.PropertyList[setName];

                            if (!shit.GetType() != comparaison) throw new Lamentation(0x4D, shit.GetType(), setName, comparaison.Name);

                            setThing.Values[setName] = setThing.Values[setName] with { Value = shit };
                            goto GoForward;
                        case FELActionType.present:
                            string presenterName = Value!;
                            if (!CurrentFrame[CurrentFrameIndex].HeapFrame.Exists(t => t.Name == presenterName)) throw new Lamentation(0x4E, presenterName);
                            RawStructure = CurrentFrame[CurrentFrameIndex].HeapFrame.Find(t => t.Name == presenterName);
                            CurrentFrame[CurrentFrameIndex].HeapFrame.Remove(RawStructure);
                            goto GoForward;
                        case FELActionType.shelve:
                            CurrentFrame[CurrentFrameIndex].HeapFrame.Insert(RawStructure.Address, RawStructure);
                            RawStructure = null;
                            goto GoForward;
                        case FELActionType.put:
                            FELStruct thing = default;
                            if (Value![0] is FELCompilerFlag)
                                thing = RawStructure ?? throw new Lamentation(0x4b);
                            else if (Value![0] is string ayoname)
                            {
                                if (!CurrentFrame[CurrentFrameIndex].HeapFrame.Exists(t => t.Name == ayoname)) throw new Lamentation(0x4E, ayoname);
                                thing = CurrentFrame[CurrentFrameIndex].HeapFrame.Find(t => t.Name == ayoname);
                            }

                            if (Value![1] is FELCompilerFlag) CurrentStore.Add(thing);
                            else if (Value![1] is string newnamee) CurrentStore.Add(thing with { Name = newnamee});
                            goto GoForward;
                        #endregion
                    }
                }
                catch (Lamentation cry)
                {
                    WriteLine(cry.ToString());
                    ErrorRaised = true;
                }
                catch (Exception ex)
                {
                    try
                    {
                        throw new Lamentation(0x17, ex.Message); // mould
                    }
                    catch (Lamentation cry)
                    {
                        WriteLine(cry.ToString()); ErrorRaised = true;
                    }
                }
            GoForward: CurrentPointedEffect++;
            }
        }

        /// <summary>
        /// Creates a binary with the code.
        /// </summary>
        /// <param name="path">The path to the file. If it does not exist, the file will be created.</param>
        /// <exception cref="Lamentation"></exception>
        public static void CreateBinary(string path)
        {
            if (File.Exists(path.Trim('"'))) File.WriteAllBytes(path.Trim('"'), new byte[] { 0 });

            using FileStream stream = File.Exists(path.Trim('"')) ? File.OpenWrite(path.Trim('"')) : File.Create(path.Trim('"'));
            using BinaryWriter writer = new(stream);

#if DEBUG
            int counter = -1;
#endif
            foreach (FELAction act in CurrentEffects)
            {
#if DEBUG
                counter++;
#endif
                if (act.ActionType == FELActionType.push ||
                    act.ActionType == FELActionType.store ||
                    act.ActionType == FELActionType.load ||
                    (act.ActionType >= FELActionType.beq &&
                    act.ActionType <= FELActionType.bso) ||
                    act.ActionType == FELActionType.@catch ||
                    act.ActionType == FELActionType.call ||
                    (act.ActionType >= FELActionType.label &&
                    act.ActionType <= FELActionType.gotolabel) ||
                    (act.ActionType >= FELActionType.throwc &&
                    act.ActionType <= FELActionType.pause) ||
                    act.ActionType == FELActionType.define ||
                    (act.ActionType >= FELActionType.create &&
                    act.ActionType <= FELActionType.carry) ||
                    act.ActionType == FELActionType.present
                    )
                {
                    writer.Write((byte)act.ActionType);
                    byte marker = act.Value! switch
                    {
                        string => 11,
                        bool => 15,
                        sbyte => 16,
                        byte => 17,
                        short => 18,
                        ushort => 19,
                        int => 20,
                        uint => 21,
                        long => 22,
                        ulong => 23,
                        Half => 24,
                        float => 25,
                        double => 26,
                        decimal => 27,
                        char => 28,
                        FELCompilerFlag => 73,
                        _ => throw new Lamentation(0x3d)
                    };

                    writer.Write(marker);
                    if (act.Value is not FELCompilerFlag) writer.Write(act.Value!);
                    //writer.Write((byte)14);
                }
                else if (act.ActionType == FELActionType.furnish ||
                    act.ActionType == FELActionType.@get ||
                    act.ActionType == FELActionType.@set ||
                    act.ActionType == FELActionType.put
                    ) // more shit needed for typename and prop name
                {
                    writer.Write((byte)act.ActionType);
                    if (act.Value![0] is FELCompilerFlag) writer.Write((byte)73);
                    else
                    {
                        writer.Write((byte)11);
                        writer.Write(act.Value![0]!); // type name
                    }
                    if (act.Value![1] is FELCompilerFlag) writer.Write((byte)73);
                    else
                    {
                        writer.Write((byte)11);
                        writer.Write(act.Value![1]!); // type name
                    }

                }
                else writer.Write((byte)act.ActionType); // only one byte is needed
            }
        }

        /// <summary>
        /// Loads in a binary.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        public static void LoadBinary(string path)
        {
            if (!File.Exists(path.Trim('"'))) throw new Lamentation(3, path.Trim('"'));

            using FileStream stream = File.OpenRead(path.Trim('"'));
            using BinaryReader reader = new(stream);

            reader.BaseStream.Position = 0; // bruh stay there!!!

            CurrentPointedEffect = 0;

            while (reader.PeekChar() != -1)
            {
                byte opcode = reader.ReadByte();
                dynamic? thing = null;
                if (
                    opcode == 1 ||
                    opcode == 29 ||
                    opcode == 30 ||
                    (opcode >= 34 &&
                    opcode <= 44) ||
                    opcode == 51 ||
                    opcode == 52 ||
                    (opcode >= 54 &&
                    opcode <= 55) ||
                    (opcode >= 57 &&
                    opcode <= 59) ||
                    opcode == 61 ||
                    (opcode >= 64 &&
                    opcode <= 68) ||
                    opcode == 71
                    )
                {
                    byte marker = reader.ReadByte();
                    switch (marker)
                    {
                        case 11:
                            thing = reader.ReadString();
                            break;
                        case 15:
                            thing = reader.ReadBoolean();
                            break;
                        case 16:
                            thing = reader.ReadSByte();
                            break;
                        case 17:
                            thing = reader.ReadByte();
                            break;
                        case 18:
                            thing = reader.ReadInt16();
                            break;
                        case 19:
                            thing = reader.ReadUInt16();
                            break;
                        case 20:
                            thing = reader.ReadInt32();
                            break;
                        case 21:
                            thing = reader.ReadUInt32();
                            break;
                        case 22:
                            thing = reader.ReadInt64();
                            break;
                        case 23:
                            thing = reader.ReadUInt64();
                            break;
                        case 24:
                            thing = reader.ReadHalf();
                            break;
                        case 25:
                            thing = reader.ReadSingle();
                            break;
                        case 26:
                            thing = reader.ReadDouble();
                            break;
                        case 27:
                            thing = reader.ReadDecimal();
                            break;
                        case 28:
                            thing = reader.ReadChar();
                            break;
                        case 73:
                            thing = new FELCompilerFlag();
                            break;
                    }
                }
                else if (opcode == 62 ||
                    opcode == 69 ||
                    opcode == 70 ||
                    opcode == 74
                    ) // special
                {
                    byte marker = reader.ReadByte(); // byte 11/73 to mark type name
                    object TypeName = marker == 73 ? new FELCompilerFlag() : reader.ReadString();
                    byte secondmarker = reader.ReadByte(); // another byte to mark prop name
                    object PropName = secondmarker == 73 ? new FELCompilerFlag() : reader.ReadString();
                    thing = new object[] { TypeName, PropName };
                }
                PlaceEffect(new((FELActionType)opcode, thing), CurrentPointedEffect, true);
                CurrentPointedEffect++;
            }
        }

        /// <summary>
        /// What to do. For operation correctness some marker bytes (11, 15-28 & 73) are also included in the table
        /// even though they don't do anything.
        /// </summary>
        public enum FELActionType : byte
        {
            /// <summary>
            /// No operation
            /// </summary>
            nop,

            /// <summary>
            /// Push to stack
            /// </summary>
            push,

            /// <summary>
            /// Pop from stack
            /// </summary>
            pop,

            /// <summary>
            /// Print top item
            /// </summary>
            print,

            /// <summary>
            /// Add two values on top
            /// </summary>
            add,

            /// <summary>
            /// Subtract with two values on top
            /// </summary>
            sub,

            /// <summary>
            /// Multiply with two values on top
            /// </summary>
            mul,

            /// <summary>
            /// Divide with two values on top
            /// </summary>
            div,

            /// <summary>
            /// Divide with two values on top, pop these then return the remainder
            /// </summary>
            mod,

            /// <summary>
            /// Shift a value on top to the left
            /// </summary>
            lst,

            /// <summary>
            /// Shift a value on top to the right
            /// </summary>
            rst,

            /// <summary>
            /// String byte marker
            /// </summary>
            str,

            /// <summary>
            /// Terminates a string
            /// </summary>
            [Obsolete("The language does not rely on a terminator byte anymore")]
            ste,

            /// <summary>
            /// Starts an integral value
            /// </summary>
            [Obsolete("This is bullshit")]
            nus,

            /// <summary>
            /// Terminates an integral value
            /// </summary>
            [Obsolete("This is bullshit")]
            nue,

            /// <summary>
            /// Bool byte marker
            /// </summary>
            @bool,

            /// <summary>
            /// Signed byte byte marker
            /// </summary>
            @sbyte,

            /// <summary>
            /// Byte byte marker
            /// </summary>
            @byte,

            /// <summary>
            /// Short byte marker
            /// </summary>
            @short,

            /// <summary>
            /// Unsigned short byte marker
            /// </summary>
            @ushort,

            /// <summary>
            /// Int byte marker
            /// </summary>
            @int,

            /// <summary>
            /// Unsigned int byte marker
            /// </summary>
            @uint,

            /// <summary>
            /// Long byte marker
            /// </summary>
            @long,

            /// <summary>
            /// Unsigned long byte marker
            /// </summary>
            @ulong,

            /// <summary>
            /// Half byte marker
            /// </summary>
            half,

            /// <summary>
            /// Single byte marker
            /// </summary>
            @float,

            /// <summary>
            /// Double byte marker
            /// </summary>
            @double,

            /// <summary>
            /// "Quadruple" byte marker
            /// </summary>
            @decimal,

            /// <summary>
            /// Character byte marker
            /// </summary>
            @char,

            /// <summary>
            /// Store the value on top to a place
            /// </summary>
            store,

            /// <summary>
            /// Loads a value from a place on top
            /// </summary>
            load,

            /// <summary>
            /// Bitwise AND
            /// </summary>
            and,

            /// <summary>
            /// Bitwise OR
            /// </summary>
            or,

            /// <summary>
            /// Bitwise XOR
            /// </summary>
            xor,

            /// <summary>
            /// <see langword="if"/> ==
            /// </summary>
            beq,

            /// <summary>
            /// <see langword="if"/> !=
            /// </summary>
            bne,

            /// <summary>
            /// <see langword="if"/> &gt;
            /// </summary>
            bgt,

            /// <summary>
            /// <see langword="if"/> &gt;=
            /// </summary>
            bge,

            /// <summary>
            /// <see langword="if"/> &lt;
            /// </summary>
            blt,

            /// <summary>
            /// <see langword="if"/> &lt;=
            /// </summary>
            ble,

            /// <summary>
            /// <see langword="goto"/>
            /// </summary>
            @goto,

            /// <summary>
            /// <see langword="if"/> <see langword="true"/>
            /// </summary>
            btr,

            /// <summary>
            /// <see langword="if"/> <see langword="false"/>
            /// </summary>
            bfl,

            /// <summary>
            /// <see langword="if"/> <see langword="true"/> <see langword="and"/> <see langword="true"/>
            /// </summary>
            bsa,

            /// <summary>
            /// <see langword="if"/> <see langword="true"/> <see langword="or"/> <see langword="true"/>
            /// </summary>
            bso,

            /// <summary>
            /// <see cref="Environment.Exit(int)"/> (<see langword="End"/> in Visual Basic.)
            /// </summary>
            end,

            /// <summary>
            /// Ask for a value. If convenient, Lilian will immediately convert the value to an appropriate type.
            /// </summary>
            take,

            /// <summary>
            /// Ask for a value. This will never automatically convert to other types.
            /// </summary>
            ask,

            /// <summary>
            /// Shrink the value on top to its nearest smaller type.
            /// </summary>
            narrow,

            /// <summary>
            /// Grow the value on top to its nearest larger type.
            /// </summary>
            widen,

            /// <summary>
            /// Turns a string or character to an appropriate type. Throws a lamentation if it fails.
            /// </summary>
            realise,

            /// <summary>
            /// <see langword="catch"/> (<see cref="Exception"/>) { } (<see langword="On"/> <see langword="Error"/> <see langword="GoTo"/>
            /// in Visual Basic.)
            /// </summary>
            @catch,

            /// <summary>
            /// Goes to a location in the stream but it saves the current position and is hence some form of subroutine.
            /// (<see langword="Call"/> in Visual Basic)
            /// </summary>
            call,

            /// <summary>
            /// <see langword="return"/>
            /// </summary>
            @return,

            /// <summary>
            /// This action is just a label in code. Any action associated with this code will be removed from the binary and turned into
            /// a no-op.
            /// </summary>
            label,

            /// <summary>
            /// This action will be turned into a standard goto if the label is found later on.
            /// </summary>
            gotolabel,

            /// <summary>
            /// <see langword="throw"/>
            /// </summary>
            @throw,

            /// <summary>
            /// <see langword="throw"/> with an exception.
            /// </summary>
            @throwc,

            /// <summary>
            /// Sets the title of the console.
            /// </summary>
            /// <remarks>
            /// This is added to the top of the source file if a project file has a Title directive.
            /// </remarks>
            settitle,

            /// <summary>
            /// <see cref="Thread.Sleep(int)"/>
            /// </summary>
            pause,

            /// <summary>
            /// <see cref="ReadKey(bool)"/>
            /// </summary>
            wait,

            /// <summary>
            /// Starts a definition of a structure type.
            /// </summary>
            define,

            /// <summary>
            /// Declares a property in a structure.
            /// </summary>
            furnish,

            /// <summary>
            /// Finishes a definition of a structure type.
            /// </summary>
            finalise,

            /// <summary>
            /// Instantiation of a structure type.
            /// </summary>
            create,

            /// <summary>
            /// Deinstantiation?? is that a word? Anyways, a structure instance is removed from the heap.
            /// </summary>
            delete,

            /// <summary>
            /// Names a structure type. By default, a structure is unnamed as it is created, so this
            /// opcode will give the struct a name.
            /// </summary>
            save,

            /// <summary>
            /// Stores a structure along with the other normal <see cref="FELObject"/>s.
            /// </summary>
            [Obsolete("Use put")]
            storestruct,

            /// <summary>
            /// Puts a structure on the stack. (You can't do anything with it currently, though.)
            /// </summary>
            carry,

            /// <summary>
            /// Gets a property from a structure.
            /// </summary>
            @get,

            /// <summary>
            /// Sets a value to a property from a structure.
            /// </summary>
            @set,

            /// <summary>
            /// Puts a structure on the tray (internally <see cref="RawStructure"/>).
            /// </summary>
            present,

            /// <summary>
            /// Removes the structure from the tray (internally <see cref="RawStructure"/>).
            /// </summary>
            shelve,

            /// <summary>
            /// A context-sensitive compiler flag byte marker.
            /// </summary>
            compflag,

            /// <summary>
            /// Stores a structure along with the other normal <see cref="FELObject"/>s.
            /// </summary>
            put
        }

        /* example:
         * push 10;
         * push 20;
         * add;
         * pop;
         */
    }
    #endregion
}
#endregion

#region Object model
/// <summary>
/// Provides the implementation and methods for the object model.
/// </summary>
public static class ObjectModel
{
    /// <summary>
    /// A classic. This provides an ID on an object and allows manipulation to it.
    /// </summary>
    /// <param name="Address">The location of the thing in the saved objects list.</param>
    /// <param name="Name">The name of the object.</param>
    /// <param name="Value">The value of the object.</param>
    public record class FELObject(int Address, string Name, object Value);

    /// <summary>
    /// A frame.
    /// </summary>
    /// <param name="StackFrame">The current stack.</param>
    /// <param name="HeapFrame">The current heap (collection of structs).</param>
    public record struct FELFrame(Stack<object> StackFrame, List<FELStruct> HeapFrame);

    /// <summary>
    /// A structure type.
    /// </summary>
    /// <param name="Name">The name of the value type.</param>
    /// <param name="PropertyList">The list of properties in the thing.</param>
    public record class FELStructType(string Name, Dictionary<string, Type> PropertyList);

    /// <summary>
    /// A structure in Lilian.
    /// </summary>
    /// <param name="Address">The location of the thing in the saved objects list.</param>
    /// <param name="Name">The name of the object.</param>
    /// <param name="Values">The list of properties in the thing.</param>
    /// <param name="Type">The kind of structure this object is.</param>
    public record class FELStruct(int Address, string Name, FELStructType Type, Dictionary<string, FELObject> Values)
        : FELObject(Address, Name, Values)
    {
        /// <summary>
        /// Returns an array version of the <see cref="Values"/> dictionary.
        /// </summary>
        /// <returns>An array of <see cref="string"/>-<see cref="FELObject"/> key-value pairs turned tuples.</returns>
        public (string PropertyName, FELObject PropertyValue)[] Summarise()
        {
            List<(string, FELObject)> tupletime = new();
            foreach (var thing in Values) tupletime.Add((thing.Key, thing.Value));

            return tupletime.ToArray();
        }
    }


    /// <summary>
    /// The currently registered structure types.
    /// </summary>
    public static List<FELStructType> TypeRegistry = new();

    /// <summary>
    /// An empty struct that just meant to mean something in whereever this is sent to.
    /// </summary>
    public struct FELCompilerFlag
    {
        /// <summary>
        /// Something to show up in debug
        /// </summary>
        /// <returns>helo, i'm a flag</returns>
        public override string ToString() => "helo, i'm a flag";

        /// <summary>
        /// Requirement to satisfy shit
        /// </summary>
        /// <param name="obj">The right operand</param>
        /// <returns>
        /// If <paramref name="obj"/> is not a <see cref="FELCompilerFlag"/>, return <see langword="false"/>.
        /// If <paramref name="obj"/> is a fellow <see cref="FELCompilerFlag"/>, return <see langword="true"/>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj is not FELCompilerFlag) return false; else return true;
        }

        /// <summary>
        /// Always returns <see langword="true"/>, as the two parameters are always <see cref="FELCompilerFlag"/>s.
        /// </summary>
        /// <returns><see langword="true"/></returns>
        public static bool operator ==(FELCompilerFlag left, FELCompilerFlag right) => true;

        /// <summary>
        /// Always returns <see langword="false"/>, as the two parameters are always <see cref="FELCompilerFlag"/>s.
        /// </summary>
        /// <returns><see langword="false"/></returns>
        public static bool operator !=(FELCompilerFlag left, FELCompilerFlag right) => false;

        /// <summary>
        /// Another requirement to satisfy shit
        /// </summary>
        /// <returns>0x075AC211</returns>
        public override int GetHashCode() => (69420 ^ 123456789) & (555-678-4084);
    }

    /// <summary>
    /// The currently-pointed registered structure type in <see cref="TypeRegistry"/>.
    /// </summary>
    public static int CurrentType { get; set; }

}
#endregion

#region User interface
/// <summary>
/// The main class for the user interface that appears in Lilian.
/// </summary>
/// <remarks>
/// The user interface resembles that of MSDOS/Windows setup.
/// </remarks>
public static class UserInterface
{
    /// <summary>
    /// The most recent textbox value during execution.
    /// </summary>
    public static string CurrentTextboxValue { get; set; }

    /// <summary>
    /// The title that is displayed on the upper-left of the screen, usually with a bar underneath it.
    /// </summary>
    public static string ApplicationTitle { get; set; }

    /// <summary>
    /// The body of text displayed on the screen.
    /// </summary>
    public static string[] ScreenBody { get; set; }

    /// <summary>
    /// The absolute-white piece of text on top of the content on-screen.
    /// </summary>
    public static string HeaderText { get; set; }

    /// <summary>
    /// The text in the grey box at the bottom of the screen.
    /// </summary>
    private static string footer;

    /// <summary>
    /// The text in the grey box at the bottom of the screen.
    /// </summary>
    public static string FooterText
    {
        get
        {
            if (string.IsNullOrEmpty(footer))
            {
                StringBuilder str = new();
                foreach (FELUIAction act in Actions)
                {
                    string item = act.ToString();
                    str.Append(item + "  ");
                }
                return str.ToString();
            }
            else return footer;
        }
        set => footer = value;
    }

    /// <summary>
    /// The list of possible key combinations. By default, if there are such combinations,
    /// the footer will display the available actions instead of what was set in its
    /// backing field.
    /// </summary>
    public static List<FELUIAction> Actions = new();

    /// <summary>
    /// A key-bound event.
    /// </summary>
    /// <param name="Key">The key.</param>
    /// <param name="Action">The associated method to invoke.</param>
    /// <param name="Description">The text that will be displayed in the footer to describe the action.</param>
    public record struct FELUIAction(ConsoleKey Key, Delegate Action, string Description)
    {
        /// <summary>
        /// Returns the info about this action.
        /// </summary>
        /// <returns>The key-description pair in the format &lt;key&gt;=&lt;description&gt;.</returns>
        public override string ToString() => $"{Key}={Description}";

        /// <summary>
        /// Invokes the associated method.
        /// </summary>
        public void Invoke() => Action.DynamicInvoke();
    }

    /// <summary>
    /// Fits the text into the screen and places it into <see cref="ScreenBody"/>.
    /// </summary>
    /// <param name="input">The input text.</param>
    /// <param name="Fill">
    ///     If true, the text will be stretched across the screen, until column 76.
    ///     Otherwise, the text will be wrapped at around columns 4 to 63.
    ///     
    ///     As for vertical wrapping, if the resulting lines are more than 19 lines,
    ///     or 17 if there's a heading, the text will be cut.
    /// </param>
    /// <returns></returns>
    internal static void WrapContent(string input, bool Fill)
    {
        StringBuilder currentLine = new();
        List<string> content = new();
        int width = Fill ? 72 : 59;
        int limit = HeaderText is not null || !string.IsNullOrEmpty(HeaderText) ? 17 : 19;

        string[] whole = input.Split(' ');

        string reserve = "";

        for (int i = 0; i < whole.Length; i++)
        {
            if (currentLine.Length + (whole[i].Length + 1) <= width)
            {
                reserve = i + 1 < whole.Length ? whole[i + 1] : string.Empty;
                currentLine.Append(whole[i] + ' ');
                if (i == whole.Length - 1)
                {
                    content.Add(currentLine.ToString());
                    currentLine.Clear();
                    break;
                }
            }
            else
            {
                if (content.Count + 1 <= limit)
                {
                    content.Add(currentLine.ToString());
                    currentLine.Clear();
                    currentLine.Append(reserve + ' ');
                }
                else break;
            }
        }

        ScreenBody = content.ToArray();
    }

    /// <summary>
    /// ayo pull up the MSDOS
    /// </summary>
    public static void LaunchUI()
    {
        Clear();
        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.DarkBlue;
        WriteLine("                                                                                ");
        WriteLine(" " + ApplicationTitle.PadRight(79));
        WriteLine("════════════════════════════════                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        WriteLine("                                                                                ");
        ForegroundColor = ConsoleColor.Black; BackgroundColor = ConsoleColor.Gray;
        Write(" Please wait while the application loads.                                       ");
        SetCursorPosition(0, 0); //ReadKey(true);
        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.Black;
    }

    /// <summary>
    /// Launches a screen.
    /// </summary>
    /// <param name="content">The content.</param>
    /// <param name="header">The header.</param>
    /// <param name="footer">The footer./param>
    /// <param name="progress">
    ///     If not null, a progress bar will be displayed at the bottom with the progress as
    ///     stated in the parameter. 100 steps.
    /// </param>
    /// <param name="actions">If possible, the keyboard shortcuts at the current screen.</param>
    public static void DisplayScreen(string content, string header = "", string footer = "", int? progress = null, params FELUIAction[] actions)
    {
        Clear();

        HeaderText = header; FooterText = footer;
        bool head = !string.IsNullOrEmpty(HeaderText);
        bool foot = !string.IsNullOrEmpty(FooterText);

        WrapContent(content, head);

        bool activate = false;
        bool dispprog = false;

        int limit = 20;

        if (progress is not null)
        {
            limit -= 6;
            dispprog = true;
        }

        if (actions.Length > 0)
        {
            activate = true;
            foreach (FELUIAction act in actions) Actions.Add(act);
        }

        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.DarkBlue;
        WriteLine(Programme.ReleaseMode ? new string(' ', 80) : ("Dev " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", " + (Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute).InformationalVersion).PadLeft(80));
        WriteLine(" " + ApplicationTitle.PadRight(79));
        WriteLine((new string('═', ApplicationTitle.Length + 1) + '═').PadRight(80));
        WriteLine("                                                                                ");
        for (int i = 0; i < limit; i++)
        {
            if (i == 0 && head)
            {
                ForegroundColor = ConsoleColor.White;
                WriteLine("   " + HeaderText.PadRight(77));
                continue;
            }
            else if (i == 1 && head)
            {
                WriteLine("                                                                                ");
                i = -1; head = false; limit -= 2; ForegroundColor = ConsoleColor.Gray;
                continue;
            }

            if (i < ScreenBody.Length) WriteLine("   " + ScreenBody[i].PadRight(77));
            else WriteLine("                                                                                ");
        }

        if (dispprog)
        {
            WriteLine(" ╔════════════════════════════════════════════════════════════════════════════╗ ");
            WriteLine(" ║ " + (progress.ToString() + "%").PadRight(74) + " ║ ");
            WriteLine(" ║ ┌────────────────────────────────────────────────────────────────────────┐ ║ ");
            WriteLine(" ║ ╞" + new string('═', (int)((progress! / 100m) * 72m)).PadRight(72) + "╡ ║ ");
            WriteLine(" ║ └────────────────────────────────────────────────────────────────────────┘ ║ ");
            WriteLine(" ╚════════════════════════════════════════════════════════════════════════════╝ ");
        }

        ForegroundColor = ConsoleColor.Black; BackgroundColor = ConsoleColor.Gray;
        Write(" " + (FooterText ?? "").PadRight(79));
        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.Black;
        SetCursorPosition(0, 0);
        Sleep(1);
        if (activate)
        {
            while (true)
            {
                SetCursorPosition(0, 0);

                ConsoleKey pressed = ReadKey(true).Key;
                if (Actions.Exists(x => x.Key == pressed))
                {
                    Actions.Find(x => x.Key == pressed).Invoke();
                    Actions.Clear();
                    return;
                }
                else continue;
            }
        }
        else return;
    }

    /// <summary>
    /// Presents a screen wherein user input is needed. (Text)
    /// </summary>
    /// <param name="Description">The text to be displayed before the prompt.</param>
    /// <param name="Required">If true, the screen will not move until it is satisfied with an input.</param>
    /// <returns>The input.</returns>
    public static string? AskingScreen(string Description, bool Required = false)
    {
    Start:
        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.DarkBlue;

        Clear();
        WriteLine(Description);
        Write("> ");
        string input = ReadLine();
        if (Required) { if (!string.IsNullOrEmpty(input)) return input; else goto Start; } else return input;
    }

    /// <summary>
    /// Presents a screen wherein user input is needed. (Text that validates if inputted path exists)
    /// </summary>
    /// <param name="Description">The text to be displayed before the prompt.</param>
    /// <returns>The input.</returns>
    public static string? AskingFileScreen(string Description)
    {
    Start:
        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.DarkBlue;

        Clear();
        WriteLine(Description + "\n");
        WriteLine(Properties.CoreContent.ThisProgIsAsk);
        Write("> ");
        string input = ReadLine();
        if (File.Exists(input.Trim('"'))) return input.Trim('"');
        else
        {
            ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.DarkRed;

            Clear();
            WriteLine($"{Properties.CoreContent.FileDoesNotExist}\n");
            WriteLine($"{Properties.CoreContent.PressAny}\n");
            ReadKey(true);
            goto Start;
        }
    }

    /// <summary>
    /// Displays a progress bar with some strange animations and a time remaining parameter.
    /// </summary>
    /// <param name="progress">The amount of progress made.</param>
    /// <param name="remaining">The time remaining.</param>
    public static void ProgressScreen(int progress, TimeSpan remaining)
    {
        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.Black;
        SetCursorPosition(0, 0);
        if (prog_dur == 48)
        {
            prog_dur = 0;
            if (prog_anim == prog_anim_modules.Length - 1) prog_anim = 0; else prog_anim++;
        }
        else prog_dur++;
        WriteLine(prog_anim_modules[prog_anim]);
        WriteLine((int)((decimal)progress / 100m) + "%");
        WriteLine(($"{(remaining.Days > 0 ? remaining.Days.ToString() + Properties.CoreContent.Days : "")}{(remaining.Hours > 0 ? remaining.Hours.ToString() + Properties.CoreContent.Hours : "")}{(remaining.Minutes > 0 ? remaining.Minutes.ToString() + Properties.CoreContent.Minutes : "")}{(remaining.Seconds > 0 ? remaining.Seconds.ToString() + Properties.CoreContent.Seconds : "")}" + Properties.CoreContent.Remaining).PadLeft(80));
    }

    private static int prog_anim = 0; private static int prog_dur = 0;
    private static readonly string[] prog_anim_modules =
    {
        "#                                                                               ",
        "##                                                                              ",
        "####                                                                            ",
        "########                                                                        ",
        " ################                                                               ",
        "  ################################                                              ",
        "    ################################################################            ",
        "        ####################################################################    ",
        "                ############################################################### ",
        "                                ################################################",
        "                                                                ################",
        "                                                                        ########",
        "                                                                            ####",
        "                                                                              ##",
        "                                                                                ",
        "#                                                                               ",
        "####                                                                            ",
        " ################                                                               ",
        "    ################################################################            ",
        "                ############################################################### ",
        "                                                                ################",
        "                                                                            ####",
        "                                                                                ",
        "#                                                                               ",
        "####                                                                            ",
        " ################                                                               ",
        "    ################################################################            ",
        "                ############################################################### ",
        "                                                                ################",
        "                                                                            ####",
        "                                                                                ",
    };

    /// <summary>
    /// Brings up a purple screen of death (because why not) that displays an error.
    /// </summary>
    /// <param name="error">The exception.</param>
    public static void ErrorScreen(Exception error)
    {
        ForegroundColor = ConsoleColor.Gray; BackgroundColor = ConsoleColor.DarkMagenta;
        Clear();

        string err = Lamentation.InterpretExceptionName(error);

        WriteLine($"{Properties.CoreContent.PSODHead}\n");

        if (error is Lamentation) WriteLine($"LP{(error as Lamentation).ErrorCode:0000}: {(error as Lamentation).Message}\n\n");
        else WriteLine(error.Message);

        WriteLine(Properties.CoreContent.PSODFoot);
    }
}
#endregion

#region Coco
/// <summary>
/// The entire Coco processing implementation.
/// </summary>
public static class Coco
{
    #region Coco preprocessor
    /// <summary>
    /// The main class for the preprocessor.
    /// </summary>
    public static class Preprocessor
    {
        #region Flags
        /// <summary>
        /// If true, enable the preprocessor. If false, all directive lines will be ignored.
        /// </summary>
        public static bool RegulateCompilation { get; set; }

        /// <summary>
        /// If true, the compiler will report that nothing has been added and hence nothing will happen.
        /// The only preserved elements are the grammar and output path, if the build is a debug build.
        /// </summary>
        public static bool DoNotDoCompilation { get; set; }

        /// <summary>
        /// If true, the compiler will use the individual Coco interpreter for the project. Otherwise,
        /// the compiler will use the previous build system from version 1.1.
        /// </summary>
        public static bool VersionOfCompilation { get; set; }

        /// <summary>
        /// If true, the compiler will report that there was no output path specified.
        /// </summary>
        public static bool NoOutputFound { get; set; }
        #endregion

        /// <summary>
        /// Determines the project version to use.
        /// </summary>
        /// <param name="projectFile">
        /// The entire file itself. If it is parsable XML, the older XML method
        /// will be used; otherwise, this will be sent to Coco.
        /// </param>
        public static void VersionSelector(string projectFile)
        {
            bool? ver = null;
            XmlDocument bruh = new();

            try { bruh.LoadXml(projectFile); }
            catch (XmlException) { ver = false; }
            finally { if (ver! == true) VersionOfCompilation = true; else VersionOfCompilation = false; }
        }

        #region Faux Coco
        /// <summary>
        /// Takes a project file and processes it.
        /// </summary>
        /// <remarks>
        /// The project file is an XML-based file which contains the entire project including conditional
        /// compilation.
        /// </remarks>
        /// <param name="file">The file.</param>
        /// <exception cref="Lamentation"></exception>
        public static void ReadProjectFile(XmlDocument file)
        {
            XmlNode root = file.DocumentElement;

            // get version
            int build = int.TryParse(root.Attributes["MinimumBuild"].Value, out int i) ? i : throw new Lamentation(0x30);
            if (Assembly.GetExecutingAssembly().GetName().Version.Build < build) throw new Lamentation(0x31, build.ToString());

            //get output path
            XmlNode outputPath = root.SelectSingleNode("descendant::Output");
            string outputType = outputPath.Attributes["Type"].Value; // use later
            Outgoing = outputPath.Attributes["Path"].Value;
            XmlNode titleNode = outputPath.Attributes["Title"];
            if (titleNode is not null) ConsummateSource.Add($"title \"{titleNode.Value}\";");

            // get project contents
            XmlNodeList projContents = root.SelectNodes("descendant::Include");
            if (projContents.Count != 0)
            {
                foreach (XmlNode projNode in projContents)
                {
                    if (File.Exists(projNode.Attributes["Path"].Value)) foreach (string line in File.ReadAllLines(projNode.Attributes["Path"].Value)) ConsummateSource.Add(line);
                    else throw new Lamentation(0x3, projNode.Attributes["Path"].Value);
                }
            }
            else
            {
                DoNotDoCompilation = true;
                return;
            }

            XmlNode condComp = root.SelectSingleNode("descendant::RegulateCompilation");
            if (condComp is not null)
                RegulateCompilation = true;
            else
                RegulateCompilation = false;
        }
        #endregion

        /// <summary>
        /// The resulting consummate or arranged source file.
        /// </summary>
        public static List<string> ConsummateSource = new();

        /// <summary>
        /// The kind of output.
        /// </summary>
        public enum LilianOutputType
        {
            /// <summary>
            /// Lilian bytecode.
            /// </summary>
            LilianExe,

            /// <summary>
            /// The entire bytecode is parsed into IL instructions then compiled into a Windows executable.
            /// </summary>
            WindowsExe
        }

        /// <summary>
        /// The path of the output.
        /// </summary>
        public static string Outgoing { get; set; }

        #region Vrai Coco

        /// <summary>
        /// Preprocesses the file. This only works if the submitted file is primarily in Lilian.
        /// If the file is primarily in Coco (i.e., no dot delimiter), this will think that all lines are normal Lilian.
        /// </summary>
        /// <param name="file">The raw file.</param>
        /// <param name="Pass">If true, the project macros are not checked. (Second-pass)</param>
        public static void Preprocess(string[] file /*, ref int progress*/, bool Pass = false)
        {
            //progress = file.Length;

            Dictionary<string, string> symbols = new();
            List<(string? symval, List<string> lines)> lignes = new();
            List<string> IncludeFilepaths = new();

            string currval = string.Empty;
            string currsym = string.Empty;
            string OutputPath = string.Empty;

            int currindx = -1;

            bool collect = false;
            bool inseq = false;
            bool togglefind = false;

            bool ProjectSection = false;
            bool ProjectDefined = false;
            bool GrammarSection = false;
            bool GrammarDefined = false;

            bool? OutputPresent = null;
            bool? InputPresent = null;
            bool? GrammarPresent = null;

            Version ver = new();

            if (!Array.Exists(file, s => s.TrimStart().StartsWith('/')))
            {
                CurrentFile = new(file);
                return;
            }

            if (Array.Exists(file, s => s.TrimStart().StartsWith('.'))) throw new Lamentation(0x3f);

            if (!RegulateCompilation && !Pass)
            {
                foreach (string line in file)
                {
                    if (!line.TrimStart().StartsWith('/')) CurrentFile.Add(line); else continue;
                }
                return;
            }

            foreach (string line in file)
            {
                if (line.TrimStart().StartsWith("//")) continue; // comment

                if (!line.TrimStart().StartsWith('/'))
                {
                    if ((Pass && !string.IsNullOrWhiteSpace(line)) && collect) // pass GO; collect $200
                        lignes[currindx].lines.Add(line);
                    else if (Pass && !string.IsNullOrWhiteSpace(line)) // just visiting
                        CurrentFile.Add(line);

                    continue;
                }

                string preprocline = line.TrimStart().TrimStart('/');

                #region Original macros
                if (Regex.IsMatch(preprocline, @"define\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    var mat = Regex.Match(preprocline, @"define\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;

                    if (!symbols.ContainsKey(symbolname)) symbols.Add(symbolname, string.Empty);
                    else throw new Lamentation(0x38, symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"defifn\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    var mat = Regex.Match(preprocline, @"defifn\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;

                    if (!symbols.ContainsKey(symbolname)) symbols.Add(symbolname, string.Empty);
                }
                else if (Regex.IsMatch(preprocline, @"undef\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    var mat = Regex.Match(preprocline, @"undef\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;

                    if (symbols.ContainsKey(symbolname)) symbols.Remove(symbolname);
                    else throw new Lamentation(0x39, symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"undefife\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    var mat = Regex.Match(preprocline, @"undefife\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;

                    if (symbols.ContainsKey(symbolname)) symbols.Remove(symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"let\s+(?<SymbolName>[0-9A-Za-z]+)\s+\[(?<Value>.*)\]"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    var mat = Regex.Match(preprocline, @"let\s+(?<SymbolName>[0-9A-Za-z]+)\s+\[(?<Value>.*)\]").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                        symbols[symbolname] = val;
                    else throw new Lamentation(0x33, symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"if\s+(?<SymbolName>[0-9A-Za-z]+)\s+\[(?<Value>.*)\]"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    var mat = Regex.Match(preprocline, @"if\s+(?<SymbolName>[0-9A-Za-z]+)\s+\[(?<Value>.*)\]").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                    { currval = val; currsym = symbolname; }
                    else throw new Lamentation(0x33, symbolname);
                    lignes.Add((val, new()));
                    currindx++;

                    if (!inseq) { inseq = true; collect = true; } else throw new Lamentation(0x34);
                }
                else if (Regex.IsMatch(preprocline, @"ifdef\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    var mat = Regex.Match(preprocline, @"ifdef\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                    { currval = symbolname; currsym = null; }
                    else throw new Lamentation(0x33, symbolname);
                    lignes.Add((symbolname, new()));
                    currindx++;
                    togglefind = true;

                    if (!inseq) { inseq = true; collect = true; } else throw new Lamentation(0x34);
                }
                else if (Regex.IsMatch(preprocline, @"ifndef\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    var mat = Regex.Match(preprocline, @"ifndef\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                    { currval = symbolname; currsym = null; }
                    else throw new Lamentation(0x33, symbolname);
                    lignes.Add((symbolname, new()));
                    currindx++;
                    togglefind = false;

                    if (!inseq) { inseq = true; collect = true; } else throw new Lamentation(0x34);
                }
                else if (Regex.IsMatch(preprocline, @"elseif\s+(?<SymbolName>[0-9A-Za-z]+)\s+\[(?<Value>.*)\]"))
                {
                    if (!inseq) throw new Lamentation(0x36);

                    var mat = Regex.Match(preprocline, @"elseif\s+(?<SymbolName>[0-9A-Za-z]+)\s+\[(?<Value>.*)\]").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                    { currval = val; currsym = symbolname; }
                    else throw new Lamentation(0x33, symbolname);
                    lignes.Add((val, new()));
                    currindx++;
                }
                else if (Regex.IsMatch(preprocline, "else"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    if (!inseq) throw new Lamentation(0x35);
                    lignes.Add((null, new()));
                    currindx++;
                }
                else if (Regex.IsMatch(preprocline, "endif"))
                {
                    if (ProjectSection) throw new Lamentation(0x42);

                    if (!inseq) throw new Lamentation(0x37);
                    inseq = false;
                    collect = false;

                    // equation time!
                    bool found = false;
                    if (currsym is not null)
                    {
                        foreach ((string?, List<string>) item in lignes)
                        {
                            if (symbols[currsym] == item.Item1!)
                            {
                                found = true;
                                foreach (string val in item.Item2) CurrentFile.Add(val);
                                break;
                            }
                            else continue;
                        }
                        if (!found)
                        {
                            if (lignes.Exists(x => x.symval == null)) foreach (string val in lignes.Find(x => x.symval == null).lines) CurrentFile.Add(val);
                            else continue;
                        }
                    }
                    else
                    {
                        if (togglefind)
                        {
                            foreach ((string?, List<string>) item in lignes)
                            {
                                if (symbols.ContainsKey(item.Item1!))
                                {
                                    found = true;
                                    foreach (string val in item.Item2) CurrentFile.Add(val);
                                    break;
                                }
                                else continue;
                            }
                            if (!found)
                            {
                                if (lignes.Exists(x => x.symval == null)) foreach (string val in lignes.Find(x => x.symval == null).lines) CurrentFile.Add(val);
                                else continue;
                            }
                        }
                        else
                        {
                            foreach ((string?, List<string>) item in lignes)
                            {
                                if (!symbols.ContainsKey(item.Item1!))
                                {
                                    found = true;
                                    foreach (string val in item.Item2) CurrentFile.Add(val);
                                    break;
                                }
                                else continue;
                            }
                            if (!found)
                            {
                                if (lignes.Exists(x => x.symval == null)) foreach (string val in lignes.Find(x => x.symval == null).lines) CurrentFile.Add(val);
                                else continue;
                            }
                        }
                    }

                    lignes = new();
                    currindx = -1;
                }
                #endregion
                else if (!Pass)
                {
                    #region Project macros
                    if (Regex.IsMatch(preprocline, @"use\s+(?<Major>[0-9]+)\.(?<Minor>[0-9]+)"))
                    {
                        var mat = Regex.Match(preprocline, @"use\s+(?<Major>[0-9]+)\.(?<Minor>[0-9]+)");

                        if (Regex.IsMatch(preprocline, @"use\s+(?<Major>[0-9]+)\.(?<Minor>[0-9]+)\.(?<Build>[0-9]+)"))
                            mat = Regex.Match(preprocline, @"use\s+(?<Major>[0-9]+)\.(?<Minor>[0-9]+)\.(?<Build>[0-9]+)");
                        if (Regex.IsMatch(preprocline, @"use\s+(?<Major>[0-9]+)\.(?<Minor>[0-9]+)\.(?<Build>[0-9]+)\.(?<Revision>[0-9]+)"))
                            mat = Regex.Match(preprocline, @"use\s+(?<Major>[0-9]+)\.(?<Minor>[0-9]+)\.(?<Build>[0-9]+)\.(?<Revision>[0-9]+)");

                        int maj, min, bld, rev;
                        maj = int.Parse(mat.Groups["Major"].Value);
                        min = int.Parse(mat.Groups["Minor"].Value);
                        bld = int.Parse(!string.IsNullOrEmpty(mat.Groups["Build"].Value) ? mat.Groups["Build"].Value : "-1");
                        rev = int.Parse(!string.IsNullOrEmpty(mat.Groups["Revision"].Value) ? mat.Groups["Revision"].Value : "-1");

                        ver = new(maj, min);
                        if (bld != -1 && rev != -1) ver = new(maj, min, bld, rev);
                        else if (bld != -1) ver = new(maj, min, bld);

                        if (Assembly.GetExecutingAssembly().GetName().Version < ver) throw new Lamentation(0x31);
                    }
                    else if (Regex.IsMatch(preprocline, @"project\s+\[(?<SymbolName>.+)\]"))
                    {
                        if (ProjectSection) throw new Lamentation(0x40);
                        if (ProjectDefined) throw new Lamentation(0x41);
#if COCOTESTS
                        WriteLine("Project!!!");
#endif

                        var mat = Regex.Match(preprocline, @"project\s+\[(?<SymbolName>.+)\]").Groups;

                        ProjectTitle = mat["SymbolName"].Value;

                        ProjectSection = true;
                    }
                    else if (Regex.IsMatch(preprocline, "endproject"))
                    {
                        if (!ProjectSection) throw new Lamentation(0x42); else ProjectSection = false;

                        if (OutputPresent == false) NoOutputFound = true;
                        if (InputPresent == false) DoNotDoCompilation = true;
                    }
                    else if (Regex.IsMatch(preprocline, @"include\s+\[(?<FileName>.+)\]"))
                    {
                        if (!ProjectSection) throw new Lamentation(0x43);

                        var mat = Regex.Match(preprocline, @"include\s+\[(?<FileName>.+)\]").Groups;

                        if (!File.Exists(mat["FileName"].Value)) throw new Lamentation(0x3);

                        ReadFile(mat["FileName"].Value);
                        IncludeFilepaths.Add(mat["FileName"].Value);

                        InputPresent = true;
                    }
                    else if (Regex.IsMatch(preprocline, @"output\s+\[(?<FileName>.+)\]"))
                    {
                        if (!ProjectSection) throw new Lamentation(0x44);
                        if (OutputPresent == true) throw new Lamentation(); // l8r

                        var mat = Regex.Match(preprocline, @"output\s+\[(?<FileName>.+)\]").Groups;

                        Outgoing = mat["FileName"].Value;

                        OutputPresent = true;
                    }
                    #endregion
                    #region Grammar definition macros
                    else if (Regex.IsMatch(preprocline, "grammar"))
                    {
                        if (GrammarSection) throw new Lamentation();
                    }
                    #endregion
                    else throw new Lamentation(0x32);
                }
                else throw new Lamentation(0x32);
            }

            foreach ((string symb, string val) in symbols)
                for (int i = 0; i < CurrentFile.Count; i++)
                    CurrentFile[i] = Regex.Replace(CurrentFile[i], @$"\%{symb}", val);

            if (Regex.IsMatch(string.Join('\n', CurrentFile), @"%[0-9A-Za-z]+"))
            {
                List<string> avail = new();
                for (int i = 0; i < CurrentFile.Count; i++)
                    foreach (Match bruh in Regex.Match(CurrentFile[i], @"%[0-9A-Za-z]+").Captures)
                        avail.Add(bruh.Value.TrimStart('%'));
                throw new Lamentation(0x3c, string.Join(", ", avail.ToArray()));
            }

#if COCOTESTS && DEBUG
            WriteLine($"Project requests version: {ver} (currently on {Assembly.GetExecutingAssembly().GetName().Version})");
            WriteLine($"Project is called: {ProjectTitle}");
            WriteLine($"Project is {string.Join('\n', ConsummateSource).Length} bytes long");
            WriteLine("Project needs:");
            foreach (string path in IncludeFilepaths) WriteLine($"{path}: {(int)(((decimal)File.ReadAllBytes(path).Length/(decimal)string.Join('\n', ConsummateSource).Length)*100m)}% ({File.ReadAllBytes(path).Length} bytes)");
            
            WriteLine($"Project goes into:\n{Outgoing}");
            WriteLine("Project contents:");
            for (int i = 0; i < ConsummateSource.Count; i++)
            {
                WriteLine($"{i:0000} {ConsummateSource[i]}");
                Sleep(1000);
            }
            WriteLine("Project emissions:");
            for (int i = 0; i < CurrentFile.Count; i++)
            {
                WriteLine($"{i:0000} {CurrentFile[i]}");
                Sleep(1000);
            }
#endif
        }

        #endregion
    }
    #endregion
}
#endregion

#region Preloader
/// <summary>
/// Hard-coded structures.
/// </summary>
public static class TEMP
{
    /// <summary>
    /// Load patterns.
    /// </summary>
    public static void LOADPATTERNS()
    {
        //----------------------- Name              Value                               Look            IgnoreOnRefinement          Terminate
        // Keywords
        CurrentTokens.Add(new() { Name = "PRNT", Value = "^print$" });
        CurrentTokens.Add(new() { Name = "PRPR", Value = @"^preprocess$" });
        CurrentTokens.Add(new() { Name = "STRT", Value = @"^start$" });
        CurrentTokens.Add(new() { Name = "LET", Value = @"^let$" });
        CurrentTokens.Add(new() { Name = "EXCL", Value = @"^\!$" });
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
        CurrentTokens.Add(new() { Name = "BEQ", Value = @"^beq$" });
        CurrentTokens.Add(new() { Name = "BNE", Value = @"^bne$" });
        CurrentTokens.Add(new() { Name = "BGT", Value = @"^bgt$" });
        CurrentTokens.Add(new() { Name = "BGE", Value = @"^bge$" });
        CurrentTokens.Add(new() { Name = "BLT", Value = @"^blt$" });
        CurrentTokens.Add(new() { Name = "BLE", Value = @"^ble$" });
        CurrentTokens.Add(new() { Name = "GOTO", Value = @"^goto$" });
        CurrentTokens.Add(new() { Name = "AND", Value = @"^and$" });
        CurrentTokens.Add(new() { Name = "OR", Value = @"^or$" });
        CurrentTokens.Add(new() { Name = "XOR", Value = @"^xor$" });
        CurrentTokens.Add(new() { Name = "BTRU", Value = @"^btr$" });
        CurrentTokens.Add(new() { Name = "BFLS", Value = @"^bfl$" });
        CurrentTokens.Add(new() { Name = "END", Value = @"^end$" });
        CurrentTokens.Add(new() { Name = "ASKN", Value = @"^take$" });
        CurrentTokens.Add(new() { Name = "ASKL", Value = @"^ask$" });
        CurrentTokens.Add(new() { Name = "NARW", Value = @"^narrow$" });
        CurrentTokens.Add(new() { Name = "WIDN", Value = @"^widen$" });
        CurrentTokens.Add(new() { Name = "REAL", Value = @"^realise$" });
        CurrentTokens.Add(new() { Name = "CTCH", Value = @"^catch$" });
        CurrentTokens.Add(new() { Name = "CALL", Value = @"^call$" });
        CurrentTokens.Add(new() { Name = "RETN", Value = @"^return$" });
        CurrentTokens.Add(new() { Name = "THNK", Value = @"^think$" });
        CurrentTokens.Add(new() { Name = "THRW", Value = @"^throw$" });
        CurrentTokens.Add(new() { Name = "TITL", Value = @"^title$" });
        CurrentTokens.Add(new() { Name = "PAUS", Value = @"^pause$" });
        CurrentTokens.Add(new() { Name = "WAIT", Value = @"^wait$" });
        CurrentTokens.Add(new() { Name = "TRUE", Value = @"^true$" });
        CurrentTokens.Add(new() { Name = "FAUX", Value = @"^false$" });
        CurrentTokens.Add(new() { Name = "DEFN", Value = @"^define$" });
        CurrentTokens.Add(new() { Name = "FRNS", Value = @"^furnish$" });
        CurrentTokens.Add(new() { Name = "FINS", Value = @"^finalise$" });
        CurrentTokens.Add(new() { Name = "CREA", Value = @"^create$" });
        CurrentTokens.Add(new() { Name = "BOOL", Value = @"^boolean$" });
        CurrentTokens.Add(new() { Name = "BYTE", Value = @"^byte$" });
        CurrentTokens.Add(new() { Name = "SBYT", Value = @"^sbyte$" });
        CurrentTokens.Add(new() { Name = "SHRT", Value = @"^short$" });
        CurrentTokens.Add(new() { Name = "USHT", Value = @"^ushort$" });
        CurrentTokens.Add(new() { Name = "INTG", Value = @"^integer$" });
        CurrentTokens.Add(new() { Name = "UINT", Value = @"^uinteger$" });
        CurrentTokens.Add(new() { Name = "LONG", Value = @"^long$" });
        CurrentTokens.Add(new() { Name = "ULNG", Value = @"^ulong$" });
        CurrentTokens.Add(new() { Name = "HALF", Value = @"^half$" });
        CurrentTokens.Add(new() { Name = "FLOT", Value = @"^float$" });
        CurrentTokens.Add(new() { Name = "STRG", Value = @"^string$" });
        CurrentTokens.Add(new() { Name = "CHAR", Value = @"^character$" });
        CurrentTokens.Add(new() { Name = "DECM", Value = @"^quadruple$" });
        CurrentTokens.Add(new() { Name = "DOUB", Value = @"^double$" });
        CurrentTokens.Add(new() { Name = "SAVE", Value = @"^save$" });
        CurrentTokens.Add(new() { Name = "DELT", Value = @"^delete$" });
        CurrentTokens.Add(new() { Name = "GET", Value = @"^get$" });
        CurrentTokens.Add(new() { Name = "SET", Value = @"^set$" });
        CurrentTokens.Add(new() { Name = "PUT", Value = @"^put$" });
        CurrentTokens.Add(new() { Name = "PRSN", Value = @"^present$" });
        CurrentTokens.Add(new() { Name = "RECL", Value = @"^shelve$" });

        // More sensitive things
        CurrentTokens.Add(new() { Name = "QUOT", Value = @"^""[^""\n]*""$" });
        CurrentTokens.Add(new() { Name = "SQUT", Value = @"^'[^'\n]'$|^'`.'$" });
        CurrentTokens.Add(new() { Name = "INTL", Value = @"^[0-9]+$", Look = true });
        CurrentTokens.Add(new() { Name = "FPIN", Value = @"^[0-9]+\.[0-9]+$", Look = true });
        CurrentTokens.Add(new() { Name = "SMCL", Value = @"^;$", Terminate = true });
        CurrentTokens.Add(new() { Name = "COLN", Value = @"^:$", Terminate = true });
        CurrentTokens.Add(new() { Name = "WTSP", Value = @"^\s$", Look = true, IgnoreOnRefinement = true });
        CurrentTokens.Add(new() { Name = "LABL", Value = @"^@[A-Za-z][A-Za-z0-9]*$", Look = true });
        CurrentTokens.Add(new() { Name = "STRC", Value = @"^&[A-Za-z][A-Za-z0-9]*$", Look = true });
        CurrentTokens.Add(new() { Name = "HEAP", Value = @"^\*[A-Za-z][A-Za-z0-9]*$", Look = true });
        CurrentTokens.Add(new() { Name = "ADDR", Value = @"^\&[0-9]+$", Look = true });
        CurrentTokens.Add(new() { Name = "EQUL", Value = @"^=$" });
        CurrentTokens.Add(new() { Name = "IDNT", Value = @"^#[A-Za-z][A-Za-z0-9]*$", Look = true });
        CurrentTokens.Add(new() { Name = "HSST", Value = @"^#\*$" });



        //----------------------------------- Name                      TokenStruct ----------------                            -----
        CurrentSentenceStructures.Add(new() { Name = "StartPreprocess", TokenStruct = new string[] { "PRPR", "COLN" } });
        CurrentSentenceStructures.Add(new() { Name = "EndPreprocess", TokenStruct = new string[] { "STRT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushString", TokenStruct = new string[] { "PUSH", "QUOT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushIntegral", TokenStruct = new string[] { "PUSH", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushTrueBoolean", TokenStruct = new string[] { "PUSH", "TRUE", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushFalseBoolean", TokenStruct = new string[] { "PUSH", "FAUX", "SMCL" } });
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
        CurrentSentenceStructures.Add(new() { Name = "IfThen", TokenStruct = new string[] { "BEQ", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "UnlessThen", TokenStruct = new string[] { "BNE", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "GreaterThan", TokenStruct = new string[] { "BGT", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "GreaterEqual", TokenStruct = new string[] { "BGE", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "LessThan", TokenStruct = new string[] { "BLT", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "LessEqual", TokenStruct = new string[] { "BLE", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Goto", TokenStruct = new string[] { "GOTO", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "And", TokenStruct = new string[] { "AND", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Or", TokenStruct = new string[] { "OR", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Xor", TokenStruct = new string[] { "XOR", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "IfTrue", TokenStruct = new string[] { "BTRU", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "IfFalse", TokenStruct = new string[] { "BFLS", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "End", TokenStruct = new string[] { "END", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "AskString", TokenStruct = new string[] { "ASKN", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Ask", TokenStruct = new string[] { "ASKL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Narrowing", TokenStruct = new string[] { "NARW", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Widening", TokenStruct = new string[] { "WIDN", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Realisation", TokenStruct = new string[] { "REAL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Catch", TokenStruct = new string[] { "CTCH", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Call", TokenStruct = new string[] { "CALL", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Return", TokenStruct = new string[] { "RETN", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "CallNamed", TokenStruct = new string[] { "CALL", "LABL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "SubroutineName", TokenStruct = new string[] { "LABL", "COLN" } });
        CurrentSentenceStructures.Add(new() { Name = "NoOperation", TokenStruct = new string[] { "THNK", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "ThrowGeneric", TokenStruct = new string[] { "THRW", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "ThrowMessage", TokenStruct = new string[] { "THRW", "QUOT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "ThrowCode", TokenStruct = new string[] { "THRW", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "SetTitle", TokenStruct = new string[] { "TITL", "QUOT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "ThreadSleep", TokenStruct = new string[] { "PAUS", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "Pause", TokenStruct = new string[] { "WAIT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushTrueBooleanExpl", TokenStruct = new string[] { "PUSH", "BOOL", "TRUE", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushFalseBooleanExpl", TokenStruct = new string[] { "PUSH", "BOOL", "FAUX", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushByteExpl", TokenStruct = new string[] { "PUSH", "BYTE", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushSByteExpl", TokenStruct = new string[] { "PUSH", "SBYT", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushIntegerExpl", TokenStruct = new string[] { "PUSH", "INTG", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushUIntegerExpl", TokenStruct = new string[] { "PUSH", "UINT", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushLongExpl", TokenStruct = new string[] { "PUSH", "LONG", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushULongExpl", TokenStruct = new string[] { "PUSH", "ULNG", "INTL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushStringExpl", TokenStruct = new string[] { "PUSH", "STRG", "QUOT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushCharExpl", TokenStruct = new string[] { "PUSH", "CHAR", "SQUT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushHalfExpl", TokenStruct = new string[] { "PUSH", "HALF", "FPIN", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushFloatExpl", TokenStruct = new string[] { "PUSH", "FLOT", "FPIN", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushDoubleExpl", TokenStruct = new string[] { "PUSH", "DOUB", "FPIN", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PushDecimalExpl", TokenStruct = new string[] { "PUSH", "DECM", "FPIN", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishBooleanExpl", TokenStruct = new string[] { "FRNS", "BOOL", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishByteExpl", TokenStruct = new string[] { "FRNS", "BYTE", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishSByteExpl", TokenStruct = new string[] { "FRNS", "SBYT", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishIntegerExpl", TokenStruct = new string[] { "FRNS", "INTG", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishUIntegerExpl", TokenStruct = new string[] { "FRNS", "UINT", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishLongExpl", TokenStruct = new string[] { "FRNS", "LONG", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishULongExpl", TokenStruct = new string[] { "FRNS", "ULNG", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishStringExpl", TokenStruct = new string[] { "FRNS", "STRG", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishCharExpl", TokenStruct = new string[] { "FRNS", "CHAR", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishHalfExpl", TokenStruct = new string[] { "FRNS", "HALF", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishFloatExpl", TokenStruct = new string[] { "FRNS", "FLOT", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishDoubleExpl", TokenStruct = new string[] { "FRNS", "DOUB", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FurnishDecimalExpl", TokenStruct = new string[] { "FRNS", "DECM", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "DefineStructure", TokenStruct = new string[] { "DEFN", "STRC", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "FinaliseStructure", TokenStruct = new string[] { "FINS", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "CreateStructure", TokenStruct = new string[] { "CREA", "STRC", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "DeleteStructure", TokenStruct = new string[] { "DELT", "HEAP", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "SaveStructure", TokenStruct = new string[] { "SAVE", "HEAP", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "PresentStructure", TokenStruct = new string[] { "PRSN", "HEAP", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "GetStructureProperty", TokenStruct = new string[] { "GET", "HEAP", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "SetStructureProperty", TokenStruct = new string[] { "SET", "HEAP", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "GetCurrentStructureProperty", TokenStruct = new string[] { "GET", "EXCL", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "SetCurrentStructureProperty", TokenStruct = new string[] { "SET", "EXCL", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "ShelveStructure", TokenStruct = new string[] { "RECL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "StoreStructure", TokenStruct = new string[] { "PUT", "HEAP", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "StoreCurrentStructure", TokenStruct = new string[] { "PUT", "EXCL", "IDNT", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "StoreStructureSameName", TokenStruct = new string[] { "PUT", "HEAP", "EXCL", "SMCL" } });
        CurrentSentenceStructures.Add(new() { Name = "StoreCurrentStructureSameName", TokenStruct = new string[] { "PUT", "EXCL", "EXCL", "SMCL" } });
    }
}
#endregion

#region Help on arguments
/// <summary>
/// Some help.
/// </summary>
public static class Help
{
    /// <summary>
    /// Help module on program arguments.
    /// </summary>
    public static class OnArguments
    {
        /// <summary>
        /// Displays the entire help on program arguments.
        /// </summary>
        public static void ReadRiotAct()
        {
            BackgroundColor = ConsoleColor.DarkGreen;
            Clear();
            WriteLine(
                "Program arguments\n\n" +

                "Instead of going through the entire spiel of doing shit with the GUI, you can\n" +
                "start a compilation process using the following arguments.\n\n" +

                "lilylang {-p <program file>} {-proj <project file> [<output path>]}\n" +
                "{-file <script file> [<output path>]}\n\n" +

                "-p: Runs a program. By default, if you've installed this program, launching an\n" +
                "LSA file will launch this program with these arguments, as if they're normal\n" +
                "programs. Otherwise, you might have to manually launch LSA files. LSA files, by\n" +
                "the way, are binaries created by this compiler.\n\n" +

                "-proj: Compiles a project file. The input file must preferrably end in CCN\n" +
                "(Coco scripts). The output path is optional, and if left blank, the compiler\n" +
                "will rely on what's in the project file.\n\n" +

                "-file: Compiles a single file. The input file must preferrably end in LPS\n" +
                "(Lilian program script). The output path is optional, and if left blank\n" +
                "the compiler will compile to the same path by default but with the LSA\n" +
                "extension.\n\n" +

                "Now press any key to exit and relaunch this compiler with these apples!"
                );
        }
    }
}
#endregion

#region Extensions
/// <summary>
/// Extensions for simplification of development of the Lilian language.
/// </summary>
public static class Extensions
{
    /// <summary>
    /// <see cref="Array.IndexOf(Array, object?)"/>
    /// </summary>
    /// <param name="enumerable">The array.</param>
    /// <param name="thing">The item to be searched for.</param>
    /// <returns></returns>
    public static int IndexOf(this Array enumerable, object thing) => Array.IndexOf(enumerable, thing);

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
#endregion