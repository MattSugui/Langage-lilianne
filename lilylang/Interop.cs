namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// Provides access to the .NET libraries by reflection.
    /// </summary>
    public static class Interop
    {
        static Interop()
        {

        }

        /// <summary>
        /// Gets the type from the string.
        /// </summary>
        /// <param name="callToAction">The string from which the type's name is to be derived from.</param>
        public static void RetrieveType(string callToAction)
        {

        }
    }

    /// <summary>
    /// A checklist to determine if 
    /// </summary>
    public static bool[] ReferenceTheFollowing = new bool[]
    {
        false, // System.Windows.Forms
        false, // System.Collections.Generic
        false, // System.Text.RegularExpressions
    };
}

/// <summary>
/// Custom types for the simplification of the development of the Lilian language. Is also part of the shipped API.
/// </summary>
public partial class Custom
{
    /// <summary>
    /// A checklist.
    /// </summary>
    public class Checklist: Dictionary<string, bool>
    {
        /// <summary>
        /// Ticks or unticks a checklist item.
        /// </summary>
        /// <param name="index">The checklist item. If it doesn't exist, it will do nothing.</param>
        public void Tick(string index)
        {
            if (!ContainsKey(index)) return;
            this[index] = !this[index];
        }
    }
}