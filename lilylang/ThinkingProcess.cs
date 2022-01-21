#pragma warning disable CA2211

namespace fonder.Lilian.New;

public static partial class Coco
{
    /// <summary>
    /// All grammar implementation processes.
    /// </summary>
    public static class Grammar
    {
        /// <summary>
        /// What Lilian should currently use.
        /// </summary>
        /// <remarks>
        /// If false, Lilian should use the grammar of the intermediate representation which is hardcoded
        /// into the <see cref="TEMP.LOADPATTERNS"/> method and actually still use an older form of the
        /// language's syntax checker. If true, Lilian should use the custom grammar, then use the IR.
        /// </remarks>
        public static bool GrammarType = false;

        /// <summary>
        /// Loads a grammar file.
        /// </summary>
        /// <param name="path">The path to the grammar file. By default it should load "core.lgf".</param>
        public static void LoadGrammar(string path = "core.lgf")
        {
            string temp = path.Trim('"');

            if (!File.Exists(temp))
            {
                if (path == "core.lgd") throw new Lamentation(0x3e);
                else throw new Lamentation(0x2, temp);
            }

            GrammarType = true;

            XmlDocument gram = new();
            gram.Load(temp);

            XmlNode root = gram.DocumentElement;

            XmlNodeList tokens = root.SelectNodes("descendant::Tokens/Token");
            foreach (XmlNode token in tokens) Tokens.Add(
                    new
                    (
                        token.Attributes["Name"].Value,
                        token.Attributes["Pattern"].Value,
                        Regex.IsMatch(token.Attributes["Pattern"].Value, @".*\*|.*\+"),
                        token.Attributes["IsValue"] is not null && bool.TryParse(token.Attributes["IsValue"]!.Value, out _),
                        token.Attributes["Ignore"] is not null && bool.TryParse(token.Attributes["Ignore"]!.Value, out _)
                    )
                );

            XmlNodeList sentences = root.SelectNodes("descendant::SentenceStructures/SentenceStructure");
            foreach (XmlNode sentence in sentences)
            {
                string name = sentence.Attributes["Name"].Value;
                MatchCollection col = Regex.Matches(sentence.Attributes["Pattern"].Value, @"\[[^\[\]]+\]");
                List<string> pattemp = new();
                foreach (Match match in col) pattemp.Add(match.Value);
                string[] pattern = pattemp.ToArray();

                string[] logic = sentence.Value.Split('\u003b');
                Sentences.Add(new(name, pattern, logic));
            }
#if DEBUG
            foreach (var item in Tokens) Debug.WriteLine(item.ToString());
            foreach (var item in Sentences) Debug.WriteLine(item.ToString());
#endif
        }

        /// <summary>
        /// The token registry.
        /// </summary>
        public static List<NewToken> Tokens = new();

        /// <summary>
        /// The sentence structure registry.
        /// </summary>
        public static List<NewSentenceStructure> Sentences = new();

        /// <summary>
        /// A token.
        /// </summary>
        /// <remarks>
        /// This is different from <see cref="Token"/>.
        /// </remarks>
        /// <param name="Name">The name of the token.</param>
        /// <param name="Pattern">The pattern of the token.</param>
        /// <param name="Seek">
        ///     If true, the interpreter will seek for more of the same type, if the pattern
        /// does not use brackets.
        /// </param>
        /// <param name="IsValue">If true, the interpreter will make use of the value of the resulting fruit.</param>
        /// <param name="Ignore">If true, the interpreter will ignore this token.</param>
        public record class NewToken(string Name, string Pattern, bool Seek, bool IsValue, bool Ignore);

        /// <summary>
        /// A captured token.
        /// </summary>
        /// <remarks>
        /// This is different from <see cref="TokenFruit"/>.
        /// </remarks>
        /// <param name="AssociatedToken">The name of the token that's associated with this value.</param>
        /// <param name="Value">The value itself.</param>
        public record struct NewTokenFruit(string AssociatedToken, string Value);

        /// <summary>
        /// A sentence structure.
        /// </summary>
        /// <remarks>
        /// This is different from <see cref="SentenceStructure"/>.
        /// </remarks>
        /// <param name="Name">The name of the structure.</param>
        /// <param name="Pattern">The pattern of the structure, made up of the names of the tokens.</param>
        /// <param name="AssociatedSub">The subroutine it converts to. It is not validated beforehand for certain case uses.</param>
        public record class NewSentenceStructure(string Name, string[] Pattern, string[] AssociatedSub);

        /// <summary>
        /// A captured sentence.
        /// </summary>
        /// <remarks>
        /// This is different from <see cref="SentenceFruit"/>.
        /// </remarks>
        /// <param name="AssociatedSentence">The name of the sentence that's associated with this value.</param>
        /// <param name="Value">The value itself.</param>
        public record struct NewSentence(string AssociatedSentence, string[] Value);

    }
}