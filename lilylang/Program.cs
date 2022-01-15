namespace fonder.Lilian.New;

/// <summary>
/// The main flow.
/// </summary>
public static class Programme
{
    /// <summary>
    /// The main entry point.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        WriteLine(
            "Fonder Lilian Language Environment\n" +
            "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", " + (Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute).InformationalVersion.Replace("releaseman ", string.Empty) + "\n"
        );

        if (args.Length == 0) goto REPLLoop;
        if (args.Length == 1)
        {
            WriteLine("You must supply two arguments: the first one for the input, then the second one for the output.");
            Environment.Exit(0);
        }

        string filepath = args[0].Trim('"');
        string outpath = args[1].Trim('"');
        bool err = false;
        try
        {
            if (filepath.EndsWith(".lps"))
            {
                WriteLine("Build: " + Path.GetFullPath(filepath));
                WriteLine("Output: " + Path.GetFullPath(outpath));
                ReadFile(Path.GetFullPath(filepath));
                Interpret(true, false, string.Empty, Path.GetFullPath(outpath));
                CurrentSentences.Clear();
                CurrentWordPacks.Clear();
                CurrentEffects.Clear();
            }
            else if (filepath.EndsWith(".lsa"))
            {
                WriteLine("Run: " + Path.GetFullPath(filepath));
                LoadBinary(Path.GetFullPath(filepath));
                Clear();
                Execute();
            }
        }
        catch (Lamentation cry)
        {
            WriteLine(cry.ToString());
            err = true;
        }
        
        if (err)
        {
            WriteLine("Compilation failed because of the above error. There could be more errors, but this is the one that ended it.\nPress any key to continue.");
            ReadKey();
            Environment.Exit(1);
        }

        Write($"Compilation finished.\nPress any key to {(args.Contains("-d") ? "run this application" : "continue")}.");
        ReadKey();
        
        if (args.Contains("-d"))
        {
            Clear();
            LoadBinary(Path.GetFullPath(outpath));
            Execute();
            Environment.Exit(0);
        }
        else Environment.Exit(0);

        REPLLoop:
        WriteLine(
            "Welcome to the monitor mode! Type EXIT if you've had your fun.\n" +
            "ID\tOP\tSL\tVT\tINSTRUCTION"
        //	ID	OP	SL	VT	INSTRUCTION
        //	01	2E	01	--	take;
        );
        CurrentPointedEffect = 0;
        while (true)
        {
            try
            {
                string st = ReadLine().TrimStart();
                if (string.IsNullOrWhiteSpace(st)) continue;
                if (st.StartsWith('.'))
                {
                    string dir = st.TrimStart('.');
                    switch (dir.Split(' ')[0])
                    {
                        case "exit":
                            Environment.Exit(0);
                            break;
                        case "run":
                            Clear();
                            Execute();
                            continue;
                        case "save":
                            string pth = Regex.Match(dir, @"save\s+(?<path>"".*"")").Groups["path"].Value.Trim('"');
                            CreateBinary(pth);
                            WriteLine("Saved!");
                            break;
                        case "load":
                            string pth2 = Regex.Match(dir, @"load\s+(?<path>"".*"")").Groups["path"].Value.Trim('"');
                            Write("WARNING: This will overwrite your current session! Continue? [Y/N]> ");
                            var key = ReadKey();
                            if (key.Key == ConsoleKey.Y)
                            {
                                WriteLine();
                                CurrentEffects.Clear();
                                CurrentPointedEffect = 0;
                                LoadBinary(pth2);
                                for (; CurrentPointedEffect < CurrentEffects.Count - 1; CurrentPointedEffect++)
                                {
                                    WriteLine(
                                        $"{CurrentPointedEffect:X4}      " +
                                        $"{(byte)CurrentEffects[CurrentPointedEffect].ActionType:X2}      " +
                                        $"{(CurrentEffects[CurrentPointedEffect].Value is not null ? (CurrentEffects[CurrentPointedEffect].Value! switch { bool => 1, byte => 1, sbyte => 1, short => 2, ushort => 2, Half => 2, int => 4, uint => 4, float => 4, long => 8, ulong => 8, double => 8, decimal => 16, char => 2, string str => Encoding.ASCII.GetByteCount(str, 0, str.Length) } + 1).ToString("x2") : 1.ToString("x2"))}      " +
                                        $"{(CurrentEffects[CurrentPointedEffect].Value is not null ? (CurrentEffects[CurrentPointedEffect].Value! switch { bool => 3, byte => 6, sbyte => 5, short => 7, ushort => 8, Half => 17, int => 9, uint => 10, float => 13, long => 11, ulong => 12, double => 14, decimal => 15, char => 4, string => 8, _ => 1 }).ToString("x2") : 0.ToString("x2"))}      " +
                                        $"(unreconstructable -- {pth2})");
                                }
                                break;
                            }
                            else break;
                    }
                }
                else
                {
                    Interpret(false, false, st);
                    SetCursorPosition(0, CursorTop - 1);
                    WriteLine(
                        $"{CurrentPointedEffect:X4}    " +
                        $"{(byte)CurrentEffects[CurrentPointedEffect].ActionType:X2}      " +
                        $"{(CurrentEffects[CurrentPointedEffect].Value is not null ? (CurrentEffects[CurrentPointedEffect].Value! switch { bool => 1, byte => 1, sbyte => 1, short => 2, ushort => 2, Half => 2, int => 4, uint => 4, float => 4, long => 8, ulong => 8, double => 8, decimal => 16, char => 2, string str => Encoding.ASCII.GetByteCount(str, 0, str.Length) } + 1).ToString("x2") : 1.ToString("x2"))}      " +
                        $"{(CurrentEffects[CurrentPointedEffect].Value is not null ? (CurrentEffects[CurrentPointedEffect].Value! switch { bool => 3, byte => 6, sbyte => 5, short => 7, ushort => 8, Half => 17, int => 9, uint => 10, float => 13, long => 11, ulong => 12, double => 14, decimal => 15, char => 4, string => 8, _ => 1 }).ToString("x2") : 0.ToString("x2"))}      " +
                        $"{st}");
                    CurrentPointedEffect++;
                }
            }
            catch (Lamentation e)
            {
                SetCursorPosition(0, CursorTop - 1);
                WriteLine(e.ToString());
                CurrentLine.Clear();
            }
        }
    }
}