namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// The main class for the preprocessor.
    /// </summary>
    public static class Preprocessor
    {
        /// <summary>
        /// Takes a project file and processes it.
        /// </summary>
        /// <remarks>
        /// The project file is an XML-based file which contains the entire project including conditional
        /// compilation.
        /// </remarks>
        /// <param name="file">The file.</param>
        /// <exception cref="Lamentation"></exception>
        public static void Preprocess(XmlDocument file)
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
            if (titleNode is not null) CurrentFile.Add($"title \"{titleNode}\";");
            

            // get project contents
            XmlNodeList projContents = root.SelectNodes("descendant::Include");
            foreach (XmlNode projNode in projContents)
            {
                if (File.Exists(projNode.Attributes["Path"].Value)) foreach (string line in File.ReadAllLines(projNode.Attributes["Path"].Value)) CurrentFile.Add(line);
                else throw new Lamentation(0x3, projNode.Attributes["Path"].Value);
            }

            XmlNode condComp = root.SelectSingleNode("descendant::Compilation");
            if (condComp is null) return;
        }

        public enum LilianOutputType
        {
            LilianExe,
            WindowsExe
        }

        public static string outgoing = "";

    }
}
