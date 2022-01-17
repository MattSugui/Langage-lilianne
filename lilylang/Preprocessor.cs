#nullable enable
#pragma warning disable CS8600
#pragma warning disable CS8602

namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// The main class for the preprocessor.
    /// </summary>
    public static class Preprocessor
    {
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
            outgoing = outputPath.Attributes["Path"].Value;
            XmlNode titleNode = outputPath.Attributes["Title"];
            if (titleNode is not null) ConsummateSource.Add($"title \"{titleNode}\";");
            

            // get project contents
            XmlNodeList projContents = root.SelectNodes("descendant::Include");
            foreach (XmlNode projNode in projContents)
            {
                if (File.Exists(projNode.Attributes["Path"].Value)) foreach (string line in File.ReadAllLines(projNode.Attributes["Path"].Value)) ConsummateSource.Add(line);
                else throw new Lamentation(0x3, projNode.Attributes["Path"].Value);
            }

            XmlNode condComp = root.SelectSingleNode("descendant::RegulateCompilation");
            if (condComp is null) return;
        }
        #endregion

        /// <summary>
        /// The resulting consummate or arranged source file.
        /// </summary>
        public static List<string> ConsummateSource = new();

        public enum LilianOutputType
        {
            LilianExe,
            WindowsExe
        }

        public static string outgoing = "";

        #region Coco

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

                if (Regex.IsMatch(preprocline, @"define\s+(?<SymbolName>[^\s]+)"))
                    symbols.Add(Regex.Match(preprocline, @"define\s+(?<SymbolName>[^\s]+)").Groups["SymbolName"].Value, string.Empty);
                else if (Regex.IsMatch(preprocline, @"let\s+(?<SymbolName>[^\s]+)\s+be\s+\[(?<Value>.*)\]"))
                {
                    var mat = Regex.Match(preprocline, @"let\s+(?<SymbolName>[^\s]+)\s+be\s+\[(?<Value>.*)\]").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                        symbols[symbolname] = val;
                    else throw new Lamentation(0x33, symbolname);
                }
                else if (Regex.IsMatch(preprocline, @"if\s+(?<SymbolName>[^\s]+)\s+is\s+\[(?<Value>.*)\]"))
                {
                    var mat = Regex.Match(preprocline, @"if\s+(?<SymbolName>[^\s]+)\s+is\s+\[(?<Value>.*)\]").Groups;
                    string symbolname = mat["SymbolName"].Value;
                    string val = mat["Value"].Value;
                    if (symbols.ContainsKey(symbolname))
                    { currval = val; currsym = symbolname; }
                    else throw new Lamentation(0x33, symbolname);
                    lignes.Add((val, new()));
                    currindx++;

                    if (!inseq) { inseq = true; collect = true; } else throw new Lamentation(0x34);
                    
                }
                else if (Regex.IsMatch(preprocline, @"elseif\s+(?<SymbolName>[^\s]+)\s+is\s+\[(?<Value>.*)\]"))
                {
                    if (!inseq) throw new Lamentation(0x36);

                    var mat = Regex.Match(preprocline, @"elseif\s+(?<SymbolName>[^\s]+)\s+is\s+\[(?<Value>.*)\]").Groups;
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
                    foreach ((string?, List<string>) item in lignes)
                    {
                        if (symbols[currsym] == item.Item1)
                        {
                            found = true;
                            foreach (string val in item.Item2) CurrentFile.Add(val);
                            break;
                        }
                        else continue;
                    }
                    if (!found) foreach (string val in lignes.Find(x => x.symval == null).lines) CurrentFile.Add(val);
                }
                else throw new Lamentation(0x32);
            }
        }

        #endregion
    }
}
