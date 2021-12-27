using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using static System.Console;

using static fonder.Lilian.New.Interpreter;
using static fonder.Lilian.New.Interpreter.Spellbook;

namespace fonder.Lilian.New
{
    public static class TEMP
    {
        public static void LOADPATTERNS()
        {
            CurrentTokens.Add(new("PRNT", "^print$"));
            CurrentTokens.Add(new("QUOT", @"^"".*""$"));
            CurrentTokens.Add(new("INTL", @"^[0-9]$", true));
            CurrentTokens.Add(new("SMCL", @"^;$"));
            //CurrentTokens.Add(new("ANY", @".", true));
            CurrentTokens.Add(new("WTSP", @"^\s$", true, true));
            //CurrentTokens.Add(new("TOSL", @"\/\/"));

            CurrentSentenceStructures.Add(new("PrintString", 1, new int[] {1}, new string[] { "PRNT", "QUOT", "SMCL" }));
            CurrentSentenceStructures.Add(new("PrintInteger", 1, new int[] {1}, new string[] { "PRNT", "INTL", "SMCL" }));

            CurrentActions.Add(1, (string val) => WriteLine(val));

            CurrentStatements.Add(new("PrintString", 1));
            //CurrentSentenceStructures.Add(new("SingleLineComm", "TOSL", "ANY?"));
        }

    }
}