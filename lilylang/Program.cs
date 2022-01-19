namespace fonder.Lilian.New;

/// <summary>
/// The main flow.
/// </summary>
public static class Programme
{
    /// <summary>
    /// If true, Lilian will delete some data to save memory. Not helpful for debugging as it deletes the syntax tree and generated sentences.
    /// </summary>
    public static bool ConserveMemory = false;

    /// <summary>
    /// The main entry point.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        WriteLine(
            "Fonder Lilian Language Environment\n" +
            "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", " + (Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute).InformationalVersion.Replace("releaseman ", string.Empty) + "\n" +
            (Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyCopyrightAttribute)) as AssemblyCopyrightAttribute).Copyright + "\n"
        );

        if (args.Length == 0) goto REPLLoop;

        string filepath = args[0].Trim('"');
        string outpath = string.Empty;
        bool err = false;
        try
        {
            try
            {
                if (filepath.EndsWith(".lps"))
                {
                    WriteLine("TIP: Submit a Lilian project to compile several files into one executable!");
                    if (args.Length == 1)
                    {
                        WriteLine("Build: " + Path.GetFullPath(filepath));
                        WriteLine("Output: ...where?");
                        WriteLine("You must supply two arguments: the first one for the input, then the second one for the output, if you are going to supply a script file.");
                        WriteLine("Press any key to continue.");
                        ReadKey();
                        Environment.Exit(0);
                    }
                    else
                    {
                        outpath = args[1].Trim('"');
                        WriteLine("Build: " + Path.GetFullPath(filepath));
                        WriteLine("Output: " + Path.GetFullPath(outpath));
                        ReadFile(Path.GetFullPath(filepath));
                        if (args.Contains("-f")) ConserveMemory = true;
                        Interpret(true, false, string.Empty, Path.GetFullPath(outpath));
                        CurrentSentences = new();
                        CurrentWordPacks = new();
                        CurrentEffects = new();
                    }
                }
                else if (filepath.EndsWith(".lilianproj"))
                {
                    if (File.Exists(Path.GetFullPath(filepath)))
                    {
                        WriteLine("Build project: " + Path.GetFullPath(filepath));
                        tempCurrFile = new XmlDocument();
                        tempCurrFile.Load(Path.GetFullPath(filepath));
                        Interpret(true, false, string.Empty, string.Empty, true);
                        CurrentSentences = new();
                        CurrentWordPacks = new();
                        CurrentEffects = new();
                    }
                    else
                    {
                        WriteLine("File does not exist! Press any key to continue.");
                        ReadKey();
                        Environment.Exit(0);
                    }
                }
                else if (filepath.EndsWith(".lsa"))
                {
                    WriteLine("Run: " + Path.GetFullPath(filepath));
                    LoadBinary(Path.GetFullPath(filepath));
                    WriteLine("Load complete!");
                    Clear();
                    Execute();
                    Environment.Exit(0);
                }
            }
            catch (OutOfMemoryException)
            {
                throw new Lamentation(0x3a);
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
            LoadBinary(Path.GetFullPath(Outgoing));
            Execute();
            Environment.Exit(0);
        }
        else Environment.Exit(0);

        REPLLoop:
        WriteLine(
            "Hey! Restart the program and supply these arguments:\n" +
            "<input> [<output>] [-d] [-f]\n" +
            "\n" +
            "<input>\n" +
            "\tThe path to the file.\n" +
            "\t\n" +
            "\tFiles that end in LPS (Lilian Program Script) and LILIANPROJ (Lilian Project) will be loaded and compiled accordingly." +
            " Files that end in LSA (Lilian Script Application/Archive) will be run immediately and ignore all other arguments.\n" +
            "\n" +
            "[<output>]\n" +
            "\tThe path to the output of the compilation process for LPS and LILIANPROJ files.\n" +
            "\n" +
            "[-d]\n" +
            "\tAfter compilation, the program will be run after compilation.\n" +
            "[-f]\n" +
            "\tDuring compilation, the program will delete some of her data to conserve memory, since it has been proven that she will" +
            " inflate unbelievably large especially for codefiles or projects with a consummate size of more than 2.5 MB. If you're" +
            "building this application, enabling the -f switch will be less helpful for debugging as it deletes useful interpretation" +
            "data."
            );
    }
}