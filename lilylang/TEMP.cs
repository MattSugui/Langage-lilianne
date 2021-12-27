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
            CurrentTokens.Add(new() { Name = "PRNT", Value = "^print$" });
            CurrentTokens.Add(new() { Name = "QUOT", Value = @"^"".*""$" });
            CurrentTokens.Add(new() { Name = "INTL", Value = @"^[0-9]$", Look = true });
            CurrentTokens.Add(new() { Name = "SMCL", Value = @"^;$" });
            //CurrentTokens.Add(ne) { Name = w("ANY" Value =, @".", true));
            CurrentTokens.Add(new() { Name = "WTSP", Value = @"^\s$", Look = true, IgnoreOnRefinement = true });
            //CurrentTokens.Add(new("TOSL", @"\/\/"));

            CurrentSentenceStructures.Add(new() { Name = "PrintString", Code = 1, PointersToValues = new int[] { 1 }, TokenStruct = new string[] { "PRNT", "QUOT", "SMCL" } });
            //CurrentSentenceStructures.Add(new("PrintInteger", 1, new int[] {1}, new string[] { "PRNT", "INTL", "SMCL" }));

            CurrentActions.Add(1, (string val) => WriteLine(val));

            CurrentStatements.Add(new("PrintString", 1));
            //CurrentSentenceStructures.Add(new("SingleLineComm", "TOSL", "ANY?"));
        }

    }
}