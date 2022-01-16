namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// Coco interop for preproc
    /// </summary>
    public static class Preprocessor
    {
        /// <summary>
        /// Preprocess the project into a single file.
        /// </summary>
        /// <param name="file">The project file.</param>
        public static void Preprocess(string[] file)
        {
            foreach (string line in file)
            {
                if (Regex.IsMatch(line, @"Lilian\s(?<MajorVersion>[0-9]+)\.(?<MinorVersion>[0-9]+)\.(?<Build>[0-9]+)\.(?<Revision>[0-9]+)"))
                {
                    var data = Regex.Match(line, @"Lilian\s(?<MajorVersion>[0-9]+)\.(?<MinorVersion>[0-9]+)\.(?<Build>[0-9]+)\.(?<Revision>[0-9]+)").Groups;
                    (int maj, int min, int build, int rev) = (int.Parse(data["MajorVersion"].Value), int.Parse(data["MinorVersion"].Value), int.Parse(data["Build"].Value), int.Parse(data["Revision"].Value));
                    if (Assembly.GetExecutingAssembly().GetName().Version.Build < build) throw new Lamentation(0x31, build.ToString());
                }
                else if (Regex.IsMatch(line, @"Title\s""(?<AppTitle>.*)""")) ConsummateSource.Add($"title \"{Regex.Match(line, @"Title\s""(?<AppTitle>.*)""").Groups["AppTitle"].Value}\";");
                else if (Regex.IsMatch(line, @"Append\s""(?<Filename>.*)"""))
                {
                    string fullpath = Regex.Match(line, @"Append\s""(?<Filename>.*)""").Groups["Filename"].Value;
                    if (File.Exists(fullpath)) foreach (string ligne in File.ReadAllLines(Path.GetFullPath(fullpath))) ConsummateSource.Add(ligne);
                    else throw new Lamentation(0x3, fullpath);
                }
                else if (Regex.IsMatch(line, @"Name\s(?<AppName>.*)")) outgoing = Regex.Match(line, @"Name\s(?<AppName>.*)").Groups["AppName"].Value + ".lsa";
                else if (string.IsNullOrWhiteSpace(line)) continue;
                else throw new Lamentation(0x32);
            }

            CurrentFile = ConsummateSource;
        }
        
        /// <summary>
        /// The complete compiled source.
        /// </summary>
        public static List<string> ConsummateSource = new();

        internal static string outgoing = "";
    }
}
