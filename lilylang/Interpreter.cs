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
using System.Diagnostics;

//using System.Management.Automation;
//using Microsoft.PowerShell;

using ShellProgressBar;

using static fonder.Lilian.New.Interpreter.Spellbook;
using static fonder.Lilian.New.Interpreter.IntegratedThirdPartyContent;
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
        static Interpreter()
        {
            TEMP.LOADPATTERNS();
        }

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
            string temp = path.Trim('"');
            if (File.Exists(temp)) foreach (string line in File.ReadAllLines(temp)) CurrentFile.Add(line); else throw new Lamentation(3, temp);
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
        public static void Interpret()
        {
            //foreach (string line in CurrentFile) ScanTokens(line);
            //Stopwatch watch = new();
            //ProgressRecord timerem = new(0, "Interpretation", "Interpreting");
            //PowerShell ps = PowerShell.Create();

            ProgressBarOptions opt = new()
            {
                ProgressBarOnBottom = false,
                //DenseProgressBar = true,
                ShowEstimatedDuration = true,
                ProgressCharacter = '\u2590',
                BackgroundCharacter = '\u2588',
                CollapseWhenFinished = false,
                DisplayTimeInRealTime = true,
            };

            //watch.Start();
            using (var pbm = new ProgressBar(CurrentFile.Count, "Scanning tokens", opt))
            {
                
                for (int i = 1; i < CurrentFile.Count + 1; i++)
                {
                    ScanTokens(CurrentFile[i - 1]);
                    /*
                    timerem.SecondsRemaining = (watch.Elapsed.Seconds / i) * (i - CurrentFile.Count);
                    timerem.PercentComplete = int.Parse($"{i / CurrentFile.Count:0}");
                    timerem.StatusDescription = $"{i} lines scanned";
                    timerem.CurrentOperation = "Scanning lines";
                    */
                    //ulong o = (ulong)((watch.Elapsed.Seconds / i) * (CurrentFile.Count - i));
                    //var p = (double)i / CurrentFile.Count;
                    //string stat = $"Scanning tokens. {o} seconds remaining ";
                    //pb.Report(p, stat);
                    /*WriteLine($"\n{o} seconds left*/
                    //pbm.EstimatedDuration = TimeSpan.FromSeconds(o);
                    pbm.Tick(TimeSpan.FromSeconds(((pbm.CurrentTick / 20) / i) * (CurrentFile.Count - i)), $"Scanning tokens");
                    
                }
            }
            //watch.Stop();
            WriteLine("complet");

            /*
            foreach (List<TokenFruit> toklist in CurrentWordPacks)
            {
                foreach (TokenFruit tok in toklist) WriteLine($"{tok.Value}");
            }
            */

            WriteLine("\n\n");
        }
         
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
