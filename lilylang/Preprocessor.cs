#nullable enable
#pragma warning disable CS8600
#pragma warning disable CS8602
#pragma warning disable CA2211

namespace fonder.Lilian.New;

/// <summary>
/// The entire Coco processing implementation.
/// </summary>
public static partial class Coco
{
    /// <summary>
    /// The main class for the preprocessor.
    /// </summary>
    public static class Preprocessor
    {
        /// <summary>
        /// If true, enable the preprocessor. If false, all directive lines will be ignored.
        /// </summary>
        public static bool RegulateCompilation = false;

        /// <summary>
        /// If true, the compiler will report that nothing has been added and hence nothing will happen.
        /// The only preserved elements are the grammar and output path, if the build is a debug build.
        /// </summary>
        public static bool DoNotDoCompilation = false;

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
            int build = int.TryParse(root.Attributes["MinimumBuild"].Value, out int i)? i: throw new Lamentation(0x30);
            if (Assembly.GetExecutingAssembly().GetName().Version.Build < build) throw new Lamentation(0x31, build.ToString());

            //get output path
            XmlNode outputPath = root.SelectSingleNode("descendant::Output");
            string outputType = outputPath.Attributes["Type"].Value; // use later
            Outgoing = outputPath.Attributes["Path"].Value;
            XmlNode titleNode = outputPath.Attributes["Title"];
            if (titleNode is not null) ConsummateSource.Add($"title \"{titleNode.Value}\";");
            
            XmlNode grammarPath = root.SelectSingleNode("descendant::Grammar");
            if (grammarPath is not null)
            {
                GrammarType = true;
                LoadGrammar(grammarPath.Attributes["Path"].Value);
            }
            else GrammarType = false;

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
        public static string Outgoing = "";

        #region Vrai Coco

        /// <summary>
        /// Preprocesses the file.
        /// </summary>
        /// <param name="file">The raw file.</param>
        public static void Preprocess(string[] file /*, ref int progress*/)
        {
            //progress = file.Length;

            Dictionary<string, string> symbols = new();
            List<(string? symval, List<string> lines)> lignes = new();

            string currval = string.Empty;
            string currsym = string.Empty;

            int currindx = -1;

            bool collect = false;
            bool inseq = false;
            bool togglefind = false;

            if (!Array.Exists(file, s => s.TrimStart().StartsWith('.')))
            {
                CurrentFile = new(file);
                return;
            }

            if (!RegulateCompilation)
            {
                foreach (string line in file)
                {
                    if (!line.TrimStart().StartsWith('.')) CurrentFile.Add(line); else continue;
                }

                return;
            }

            foreach (string line in file)
            {
                if (!line.TrimStart().StartsWith('.'))
                {
                    if (collect)
                        lignes[currindx].lines.Add(line);
                    else
                        CurrentFile.Add(line);
                    continue;
                }

                string preprocline = line.TrimStart().TrimStart('.');

                if (Regex.IsMatch(preprocline, @"define\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    var mat = Regex.Match(preprocline, @"define\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;

                    if (!symbols.ContainsKey(symbolname)) symbols.Add(symbolname, string.Empty);
                    else throw new Lamentation(0x38, symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"defifn\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    var mat = Regex.Match(preprocline, @"defifn\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;

                    if (!symbols.ContainsKey(symbolname)) symbols.Add(symbolname, string.Empty);
                }
                else if (Regex.IsMatch(preprocline, @"undef\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    var mat = Regex.Match(preprocline, @"undef\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;

                    if (symbols.ContainsKey(symbolname)) symbols.Remove(symbolname);
                    else throw new Lamentation(0x39, symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"undefife\s+(?<SymbolName>[0-9A-Za-z]+)"))
                {
                    var mat = Regex.Match(preprocline, @"undefife\s+(?<SymbolName>[0-9A-Za-z]+)").Groups;
                    string symbolname = mat["SymbolName"].Value;

                    if (symbols.ContainsKey(symbolname)) symbols.Remove(symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"let\s+(?<SymbolName>[0-9A-Za-z]+)\s+be\s+\[(?<Value>.*)\]"))
                {
                    var mat = Regex.Match(preprocline, @"let\s+(?<SymbolName>[0-9A-Za-z]+)\s+be\s+\[(?<Value>.*)\]").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                        symbols[symbolname] = val;
                    else throw new Lamentation(0x33, symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"if\s+(?<SymbolName>[0-9A-Za-z]+)\s+is\s+\[(?<Value>.*)\]\s+then"))
                {
                    var mat = Regex.Match(preprocline, @"if\s+(?<SymbolName>[0-9A-Za-z]+)\s+is\s+\[(?<Value>.*)\]\s+then").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                    { currval = val; currsym = symbolname; }
                    else throw new Lamentation(0x33, symbolname);
                    lignes.Add((val, new()));
                    currindx++;

                    if (!inseq) { inseq = true; collect = true; } else throw new Lamentation(0x34);
                }
                else if (Regex.IsMatch(preprocline, @"ifdef\s+(?<SymbolName>[0-9A-Za-z]+)\s+then"))
                {
                    var mat = Regex.Match(preprocline, @"ifdef\s+(?<SymbolName>[0-9A-Za-z]+)\s+then").Groups;
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
                else if (Regex.IsMatch(preprocline, @"ifndef\s+(?<SymbolName>[0-9A-Za-z]+)\s+then"))
                {
                    var mat = Regex.Match(preprocline, @"ifndef\s+(?<SymbolName>[0-9A-Za-z]+)\s+then").Groups;
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
                else if (Regex.IsMatch(preprocline, @"elseif\s+(?<SymbolName>[0-9A-Za-z]+)\s+is\s+\[(?<Value>.*)\]\s+then"))
                {
                    if (!inseq) throw new Lamentation(0x36);

                    var mat = Regex.Match(preprocline, @"elseif\s+(?<SymbolName>[0-9A-Za-z]+)\s+is\s+\[(?<Value>.*)\]\s+then").Groups;
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
                    if (!inseq) throw new Lamentation(0x35);
                    lignes.Add((null, new()));
                    currindx++;
                }
                else if (Regex.IsMatch(preprocline, "endif"))
                {
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
        }

        #endregion
    }
}
