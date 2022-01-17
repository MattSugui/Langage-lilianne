namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// Coco interop for preproc
    /// </summary>
    public static class Preprocessor
    {
        public static void Preprocess(XmlDocument file)
        {
            XmlNode root = file.DocumentElement;

            // get version
            int build = int.TryParse(root.Attributes["MinimumBuild"].Value, out int i)? i: throw new Lamentation(0x30);
            if (Assembly.GetExecutingAssembly().GetName().Version.Build < build) throw new Lamentation(0x31, build.ToString());

            //get output path
            XmlNode outputPath = root.SelectSingleNode("descendants::Output");
            string outputType = outputPath.Attributes["Type"].Value; // use later
            outgoing = outputPath.Attributes["Path"].Value;
            

            // get project contents
            XmlNodeList projContents = root.SelectNodes("descendants::Include");
            foreach (XmlNode projNode in projContents)
            {
                if (File.Exists(projNode.Attributes["Path"].Value)) foreach (string line in File.ReadAllLines(projNode.Attributes["Path"].Value)) ConsummateSource.Add(line);
                else throw new Lamentation(0x3, projNode.Attributes["Path"].Value);
            }
        }

        public enum LilianOutputType
        {
            LilianExe,
            WindowsExe
        }

        /// <summary>
        /// The complete compiled source.
        /// </summary>
        public static List<string> ConsummateSource = new();

        public static string outgoing = "";

    }
}
