namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// A compiler error to Lilian.
    /// </summary>
    public class Lamentation : Exception
    {
        /// <summary>
        /// Initialises the standard error code-string pairs for a lamentation.
        /// </summary>
        static Lamentation()
        {
            def = new();
            def.Add(0x0000, "All clear.");
            def.Add(0x0001, "Syntax error. A string was never terminated.");
            //
            def.Add(0x0002, "Syntax error. The pattern {0} does not exist in the current context.");
            //
            def.Add(0x0003, "The file '{0}' does not exist.");
            //
            def.Add(0x0004, "Implementation error. The token '{0}' does not exist. Did you forget to add the token first before using it?");
            def.Add(0x0005, "Implementation error. The predefined token '{0}' does not exist. Please reinstall Lilian, or send a bug report.");
            def.Add(0x0006, "Implementation error. There can be nothing at token {0} because the {1} sentence only has {2}.");
            def.Add(0x0007, "Implementation error. Some tokens of the {0} sentence have already been specified.");
            def.Add(0x0008, "Syntax error. The token '{0}' cannot exist in its current position of the {1} sentence.");
            //
            def.Add(0x0009, "Implementation error. The token '{0}' has an invalid predefined UUID. Leave the UUID field blank for a random one, or reformat your UUID.");
            //
            def.Add(0x000A, "Implementation error. Something happened.");
            def.Add(0x000B, "Implementation error. The opcode '{0}' does not exist. Did you forget to add the opcode first before using it?");
            def.Add(0x000C, "Implementation error. The predefined opcode '{0}' does not exist. Please reinstall Lilian, or send a bug report.");
            //
            def.Add(0x000D, "Implementation error. Right bracket {0} for left bracket {1} does not exist. Did you forget to add the token first before using it?");
            //
            def.Add(0x000E, "Implementation error. The opcode {0} does not exist. Did you forget to assign the operation to there?");
            def.Add(0x000F, "Implementation error. Sentence {0} has more pointers than the allocated parameters for the associated opcode {1} '{2}'.");
            def.Add(0x0010, "File operation error. {0}");
            def.Add(0x0011, "File operation error. The archive '{0}' does not exist.");
            def.Add(0x0012, "File operation error. Cannot export to an archive. This is not your fault; it's ours. Contact us lmao. ({0})");
            def.Add(0x0013, "File operation error. Cannot import from an archive. Either that you're a dumbarse and imported something not in an LPS format or it's our fault. If so, contact us. lMAO. ({0})");
            def.Add(0x0014, "Implementation error. The sentence structure {0} does not correspond with any of the available statements.");
            //
            def.Add(0x0015, "Handshake with Coco failed. {0}");
            //
            def.Add(0x0016, "{0} is an undefined feature in this version. Use a newer version of Lilian.");
            def.Add(0x0017, "Stack error. {0}");
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class.
        /// </summary>
        public Lamentation()
        {

        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class with a specified error message.
        /// </summary>
        /// <param name="msg">The error message.</param>
        public Lamentation(string msg)
        {
            Message = msg;
            ErrorCode = 0;
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class with a specified error message and error code.
        /// </summary>
        /// <param name="msg">The error message.</param>
        /// <param name="err">The error code.</param>
        public Lamentation(string msg, int err)
        {
            Message = msg;
            ErrorCode = err;
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class with a specified error code. The constructor
        ///will check for a code-message pair to find that error. Else, throw a Lamentation, whilst creating
        ///one.
        /// </summary>
        /// <param name="code">The error code.</param>
        public Lamentation(int code)
        {
            if (def.ContainsKey(code))
            {
                Message = def[code];
                ErrorCode = code;
            }
            else throw new InvalidOperationException($"Lamentation provider failed to retrieve error code {code} because it does not exist. How ironic.");
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class with a specified error code and appropriate
        ///data such as line numbers or current tokens. The constructor will check for a code-message pair
        ///to find that error. Else, throw a Lamentation, whilst creating one.
        /// </summary>
        /// <param name="code">The error code.</param>
        /// <param name="data">Related data such as line numbers or current tokens.</param>
        public Lamentation(int code, params string[] data)
        {
            if (def.ContainsKey(code))
            {
                Message = string.Format(def[code], data);
                ErrorCode = code;
            }
            else throw new InvalidOperationException($"Lamentation provider failed to retrieve error code {code} because it does not exist. How ironic.");
        }

        /// <summary>
        /// Gets the error code of the lamentation.
        /// </summary>
        public int ErrorCode { get; }

        /// <summary>
        /// Gets a message that describes the current lamentation.
        /// </summary>
        public override string Message { get; }

        /// <summary>
        /// An internal dictionary for getting a code-message pair.
        /// </summary>
        private static readonly Dictionary<int, string> def;

        /// <summary>
        /// Creates and returns a string representation of the current lamentation.
        /// </summary>
        public override string ToString() => string.Format("LP{0:0000}: {1}", ErrorCode, Message);
    }
}

