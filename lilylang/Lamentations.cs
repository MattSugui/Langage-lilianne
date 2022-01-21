namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// A compiler error to Lilian. However, it can also occur <em>during runtime</em>.
    /// </summary>
    public class Lamentation : Exception
    {
        /// <summary>
        /// Initialises the standard error code-string pairs for a lamentation.
        /// </summary>
        static Lamentation()
        {
            def = new();
            def.Add(0x0000, "Invalid state for the environment. If you don't know what happened, it's my fault. Contact ininemsn@gmail.com");
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
            def.Add(0x0018, "{0} does not exist in the current context.");
            def.Add(0x0019, "{0} is not a valid Int32 value.");
            def.Add(0x0020, "Index {0} goes beyond the current stream.");
            def.Add(0x0021, "Index {0} is in an incorrect format.");
            def.Add(0x0022, "'{0}': cannot be shrunk further.");
            def.Add(0x0023, "'{0}': cannot be grown further.");
            def.Add(0x0024, "'{0}': cannot shrink a string!");
            def.Add(0x0025, "'{0}': cannot grow a string!");
            def.Add(0x0026, "'{0}': cannot shrink a character!");
            def.Add(0x0027, "'{0}': cannot grow a character!");
            def.Add(0x0028, "'{0}': cannot shrink whatever this is!");
            def.Add(0x0029, "'{0}': cannot grow whatever this is!");
            def.Add(0x002A, "'{0}': cannot realise this string into an integral value.");
            def.Add(0x002B, "The following call doesn't lead to anywhere: '{0}'.");
            def.Add(0x002C, "Internal error: {0} {1}");
            def.Add(0x002D, "I've just got a letter. '{0}'");
            def.Add(0x002E, "aYO wat the fuk! Lamentation no. {0} does not exist!!!");
            def.Add(0x002F, "Hi!");
            def.Add(0x0030, "Preprocessing error. Invalid build number.");
            def.Add(0x0031, "Preprocessing error. The project does not use this build of Lilian. Use at least build {0}.");
            def.Add(0x0032, "Preprocessing error. Unknown directive.");
            def.Add(0x0033, "Preprocessing error. Unknown symbol '{0}'.");
            def.Add(0x0034, "Preprocessing error. Cannot redefine the previous 'if' statement.");
            def.Add(0x0035, "Preprocessing error. There was no 'if' statement to attach this 'else' statement to.");
            def.Add(0x0036, "Preprocessing error. There was no 'if' statement to attach this 'elseif' statement to.");
            def.Add(0x0037, "Preprocessing error. There was no 'if' statement to terminate.");
            def.Add(0x0038, "Preprocessing error. '{0}' already exists. Use 'defifn' if needed.");
            def.Add(0x0039, "Preprocessing error. '{0}' does not exist. Use 'undefife' if needed.");
            def.Add(0x003A, "Internal error. There is no more memory to work with on this compilation.");
            def.Add(0x003B, "Preprocessing error. '{0}' does not exist.");
            def.Add(0x003C, "Preprocessing error. There are references to the following inexistent symbols: {0}.");
            def.Add(0x003D, "Internal error. For this version of Lilian, you cannot declare types other than the standard 15 .NET types.");
            def.Add(0x003E, "Implementation error. The core grammar does not exist. Fall back to assembly syntax, or reinstall Lilian.");
        }

        /// <summary>
        /// Initialises a new instance of the Lamentation class.
        /// </summary>
        public Lamentation()
        {
            Message = def[0];
            ErrorCode = 0;
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
            else throw new Lamentation(0x2e, code.ToString());
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
            else throw new Lamentation(0x2e, code.ToString());
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

        /// <summary>
        /// Turns an exception name into a friendly one.
        /// </summary>
        /// <param name="e">The exception.</param>
        /// <returns>A friendly name version of the exception.</returns>
        public static string InterpretExceptionName(Exception e)
        {
            string[] name = Regex.Split(e.GetType().Name, "[A-Z][a-z]*");
            for(int i = 0; i < name.Length; i++) name[i] = name[i].ToLower();
            return string.Join(' ', name);
        }
    }
}

