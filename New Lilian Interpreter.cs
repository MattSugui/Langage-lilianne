#region Assembly references
using System;
using System. Collections. Generic;
using System. Collections. ObjectModel;
using System. Collections;
using System. Linq;
using System. Text;
using System. IO;
using System. Reflection;
using System. Text. RegularExpressions;
using System. Xml;
using System. Xml. Linq;
using System. Windows. Forms;
using fonder. Citrus. ApplicationDev. Lilian. IttyBitty;
using fonder. Citrus. ApplicationDev. Lilian. Martha;
#endregion

// 511 387 0991

#region Static class references
using static fonder. Citrus. ApplicationDev. Lilian. Constants;
using static fonder. Citrus. ApplicationDev. Lilian. Customisations;
using static fonder. Citrus. ApplicationDev. Lilian. Enumerations;
using static fonder. Citrus. ApplicationDev. Lilian. FileMechanisms;
using static fonder. Citrus. ApplicationDev. Lilian. Interpreter;
using static fonder. Citrus. ApplicationDev. Lilian. ObjectLists;
using static fonder. Citrus. ApplicationDev. Lilian. LilianEvents;
using static fonder. Citrus. ApplicationDev. Lilian. Objects;
using static fonder. Citrus. ApplicationDev. Lilian. Martha. Tabulator;
using static fonder. Citrus. ApplicationDev. Lilian. Martha. Objects;
#endregion

#region Open to see credits and info about this source code file
/* Open to see credits and info about this source code file ***************************************\
╔══════════════════════════════════════════════════════════════════════════════════════════════════╗
║   ╭╮╭╮                                                                                           ║
║  (._.) ... the ship is real                                                                      ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ Citrus Lilian Language Interpreter                                                               ║
║ Built upon the .NET Core 3 Common Language Infrastructure by Microsoft                           ║
║                                                                                                  ║
║ © 2019-2021 Aschsenland Incorporated (doing shit™ as Fonder-Sierra International). All rights    ║
║ reserved.                                                                                        ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ C#, .NET Core, Visual Studio and all related titles and subjects are registered trademarks of    ║
║ Microsoft Corporation.                                                                           ║
║ Lilian is the name of a rabbit character in the video game series Animal Crossing. Both are      ║
║ registered trademarks of Nintendo and all of its international affiliates.                       ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ In case you're wondering, this is the bytecode interpretation file. Every LML-related language   ║
║ is translated into this binary code (similar to how .NET languages get translated into CLR byte  ║
║ code) and then interpreted afterwards. This is so that if you want to bring the brackets into    ║
║ Lilian, you easily can with the Converter's token converter function.                            ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ ╭│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─│─╮ ║
║ │ Hello, viewer of this source code!                                                           │ ║
║ │                                                                                              │ ║
║ │     I have compressed my damned project into just one code file that can cause multiple      │ ║
║ │ performance issues for whoever has the balls to load this file in a laptop that's running at │ ║
║ │ a very, very measly 1 billion hertz, also known as 1 GHz and the speed of latter-day PC      │ ║
║ │ toasters (even MacBooks from 2004 can run faster than whatever dev-env I'm using to create   │ ║
║ │ this interpreter). This is for portability and easy redistribution of this open-source       │ ║
║ │ project.                                                                                     │ ║
║ │                                                                                              │ ║
║ │     This project is named after the famous Animal Crossing™ bunny character named, well,     │ ║
║ │ Bunnie. Well, her Japanese name, at least (Ririan, or Lilian in proper English). And this    │ ║
║ │ 'Markup Language' part. That's actually partially true, because this is mostly imperative,   │ ║
║ │ and it reeks of COBOL and Python influence in terms of syntax and lexicon if you sniff it    │ ║
║ │ hard enough, whilst having RTF conversion capabilities - which is something I've actually    │ ║
║ │ not inserted yet because I've been waiting for a week tryna install Visual Studio 2019 on my │ ║
║ │ Intel cElErOn celery with some Wi-Fi that's as fast as a broadband connection in 2005 after  │ ║
║ │ being cursed to only being able to use Visual Studio 2010 with the shit conditions I have.   │ ║
║ │                                                                                              │ ║
║ │     The way it interprets stuff differs from all the commonplace languages and even the more │ ║
║ │ obscure ones such as APL (aka lit. 'A Programming Language') wherein the dev has to even     │ ║
║ │ grab their own APL-compliant keyboard because the language has so many symbols that were     │ ║
║ │ actually added in Unicode a decade later after [its] conception because they weren't aware   │ ║
║ │ some speed-high (speed is a drug) shit like this actually co-existed with BASIC and          │ ║
║ │ FORTRAN. And you'll probably able to guess why with the 'it smells like COBOL' thing I've    │ ║
║ │ just said earlier. It's because it interprets the way English-language teachers evaluate     │ ║
║ │ works in students' linguistics courses. It looks for the first word in the line (also known  │ ║
║ │ as a sentence in this language) then either splits it (for inline statements) or 'expects'   │ ║
║ │ the next keywords (for code blocks). It also stores all variables and values in List <>s      │ ║
║ │ which is highly unusual for a programming language which usually directly stores them in the │ ║
║ │ memory of the computer rather than enumerables.                                              │ ║
║ │                                                                                              │ ║
║ │     So, yeah. I hope you'll understand the li'l XML doc comments and other shit I've placed  │ ║
║ │ in this single-file interpreter source code! Well, if your PC doesn't crash already from     │ ║
║ │ loading this thousand-line file. Look...it even fits in your 5.25" floppy...                 │ ║
║ │                                                                                              │ ║
║ │                                                                                              │ ║
║ │                                                                                              │ ║
║ │                                                                   Sincerely made with love,  │ ║
║ │                                                                                        Matt  │ ║
║ │                                                                                              │ ║
║ │                                                           P.S. I'm not gay. But Villager is. │ ║
║ │                PP.S. This is also where I try out the dirty C# 8.0 stuff. I'm sorry, Bunnie. │ ║
║ ╰──────────────────────────────────────────────────────────────────────────────────────────────╯ ║
╟──────────────────────────────────────────────────────────────────────────────────────────────────╢
║ Does this mean I can call you 'darling?'                                                         ║
║ Size goal: Sinclair Microdrive cassette (83/85 kB)                                               ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ 200811-1218: Binary LML construction began! Yay, Visual Studio 16!                               ║
║        1639: It can now only fit in a 'Magnetic core' onwards! (32 kB)                           ║
║        1708: Content from the original-revsion Fixed Interpreter now imported                    ║
║        1903: It can now only fit in a 'Commodore Datasette' onwards! (64 kB)                     ║
║ 200813-1838: Interpreter completely rewritten to better acommodate bytecode conversion.          ║
║ 200814-1401: Content from the original-revsion Fixed Interpreter now imported                    ║
║ 200816-1000: Size goal 'Magnetic core platter' reached, now on level 'Early Commodore 64 30-min  ║
║              datasette'! (65 kB)                                                                 ║
║        1252: 1000 lines of code goal reached! (Including comments)                               ║
║        1413: Size goal 'Early Commodore 64 30-min datasette' reached, now on level 'Sinclair     ║
║              Microdrive cassette'! (85 kB)                                                       ║
║        1803: File size taken over original Lilian LML interpreter!                               ║
║ 200817-1000: Project split into three files for better handling.                                 ║
║ 200821-0956: Interpreter completely rewritten to match with Kent's current interpretation        ║
║              methods.                                                                            ║
║ 200828-1042: Size goal 'Early Commodore 64 30-min datasette' reached, now on level 'Sinclair     ║
║              Microdrive cassette'! (85 kB)                                                       ║
║ 200914-1245: Lilian Itty-Bitty Code implementation began.                                        ║
║        1306: Size goal 'Sinclair Microdrive cassette' reached, now on level '5 1/4 floppy disk'! ║
║              (360 kB)                                                                            ║
║ 200916-1023: 100kB size reached!                                                                 ║
║ 200921-1124: Dotty Tables (Martha) implementation began                                          ║
║ 200922-1232: Rewrite                                                                             ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ Isabelle: Hello, toilet? (*>_<*)                                                                 ║
║ Tommy: « Извините, уборная в этом конкретном отделении, кстати, предназначена только для членов  ║
║        Социалистической Эгалитарной Рабочей Партии Хэштега Асксенленда; возможно, вам придется   ║
║        перейти в другое заведение. Извините правительство за неудобства, которые мы могли и можем║
║        причинить вам. » (ಥ_ಥ)                                                                   ║
║ Isabelle: Understandable, have a nice day (*^_^*)                                                ║
║                                                                                                  ║
║ Read the full story:                                                                             ║
║ http://www.omorashi.org/topic/43290-marking-her-territory-animal-crossing/                       ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ Requiescat in pace                                                                               ║
║ Longcat (Shiroi)                                                                                 ║
║ AD MMII - AD MMXX                                                                                ║
║ May you stretch far beyond into God's scratchingpost. Amen.                                      ║
╟╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╌╢
║ This week we commemorate the efforts of the citizens of the United States of America to raid the ║
║ secretive extraterrestrial intelligence research facility known as Area 51.                      ║
║ 21 September 2019                                                                                ║
╚══════════════════════════════════════════════════════════════════════════════════════════════════╝
\**************************************************************************************************/
#endregion

#nullable enable // Makes sure that nullables are possible here; those that are marked with a ?

#region Basic assembly information
[assembly: AssemblyTitle                                     ("Citrus Lilian Language Interpreter")]
[assembly: AssemblyProduct                                               ("Citrus Lilian Language")]
[assembly: AssemblyDescription               ("An interpreter for the Lilian programming language")]
[assembly: AssemblyCopyright         ("© 2019-2021 Aschsenland Incorporated. All rights reserved.")]
[assembly: AssemblyCompany               ("Aschsenland Incorporated (Fonder-Sierra International)")]
[assembly: AssemblyVersion                                                                ("1.0.*")]
[assembly: AssemblyFileVersion                                                              ("1.0")]
#endregion

namespace fonder.Citrus.ApplicationDev.Lilian
{
    #region Interpreter
    /// <summary>
    /// Provides Lilian interpretation capabilities. She must have them, or else she's useless!
    /// </summary>
    public static class Interpreter
    {
        #region Flags
        /// <summary>
        /// Lower this flag to retain the invalid elements. All of them however will always return
        ///null when called, though. Useful for debugging databases.
        /// </summary>
        public static bool EmptyTheBin = true;
    
        // This field is useless; HospitalityLevel already does it.
/*      /// <summary>
        ///
        /// </summary>        
        public static bool EnableExtensibility = false;
*/

        /// <summary>
        /// The current hospitality level - or the current interpretation methods that Lilian will
        ///be using to evaluate a script.
        /// </summary>        
        public static LMLInterpretationHospitalityLevel HospitalityLevel = LMLInterpretationHospitalityLevel.Normal;
        /* Lilian Fonder Event Language Term Equivalents ******************************************\
        ┌──────────────────────────────┬──────────┬────────────────────────────────────────────┬───┐
        │ Original function            │ Normal   │ WFEL term                                  │ C │
        ├──────────────────────────────┼──────────┼────────────────────────────────────────────┼───┤
        │ Define variable              │ LET      │ LET                                        │ → │
        └──────────────────────────────┴──────────┴────────────────────────────────────────────┴───┘
        \******************************************************************************************/
        #endregion
        #region Programme details
        /// <summary>
        /// The name of the programme.
        /// </summary>
        public static string ProgrammeName { get; set; }

        /// <summary>
        /// The UUID of the programme. This is used for smart error handling wherein Lilian would 
        ///save the errors in a programme for future prevention.
        /// </summary>           
        public static string ProgrammeUUID
        {
            get { return prguuid; }
            set
            {
                Match UUIDConfirmation = Regex.Match(value, "[0-9a-fA-F]{8}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{4}-[0-9a-fA-F]{12}");

                if (UUIDConfirmation.Success || string.IsNullOrEmpty(value)) prguuid = value;
                else throw new ArgumentException("The provided universally-unique id (UUID) is invalid.");
            }
        }

        /// <summary>
        /// The internal storage for the programme's UUID.
        /// </summary>
        internal static string prguuid;

        /// <summary>
        /// The current schemata that this programme uses.
        /// </summary>
        public static List <string> ProgrammeSchema = new List <string> ();      
        #endregion   
        
        /// <summary>
        /// Runs the current code.
        /// </summary>
        public static void Play ()
        {
            if (EmptyTheBin) ObjectLists. RubbishBin. Clear (); // empty the bin, unless the user tells it not to.

        }
    }
    #endregion
    #region File mechanisms
    /// <summary>
    /// How Lilian deals with all the shit you make her read about.
    /// </summary>
    public static class FileMechanisms
    {
        /// <summary>
        /// Loads a file into place, and all its possible fields if necessary.
        /// </summary>
        /// <remarks>
        /// Evaluation of fields occur afterwards, as well as local subroutine variables.
        /// </remarks>
        /// <param name="Path">The path to the file.</param>
        /// <param name="IttyBittyMode">Raise this flag if the programme is in 'Itty-Bitty' simplification.</param>
        public static void LoadFile (string Path, bool IttyBittyMode)
        {
            #region Organiser initialisation
            bool ExpectingHeaderSection = false; // checks if the division's name is 'Identification' or something similar to that (carry-over from COBOL). If it didn't receive this section, the UUID will be null (meh) and the name will be the file's name.
            bool ExpectingSchemaSection = false; // checks if the division's name is 'Schemata' or something similar to that. If it didn't receive this section, no schemas will be used.
            bool ExpectingFieldTableSection = false; // checks if the division's name is 'Field_farm' (a pun on the different meaning of 'field', which could also mean 'farm' other than 'form'), 'Tabulation', 'Data' or something similar to that (carry-over from COBOL). If it didn't receive this section, no field tables will be used.

            StringBuilder Keyword = new StringBuilder (); // IDK why I put that here but okay
            
            #endregion
            foreach (string Line in File. ReadAllLines (Path))
            {
                if (Regex. IsMatch (Line, GeneralRegex)) switch (Regex. Match (Line, GeneralRegex). Groups ["Verb"]. Value. ToUpperInvariant ())
                {
                    #region Standard imperative sentences
                    case "LET": // Let DataType Name be Value
                        // oop looks like regex is confusion!
                        if (Line. Trim ('.', '!'). Equals ("Let user fiddle her breasts", StringComparison.InvariantCultureIgnoreCase)) // get line!!!!
                        {
                            // here add metaprogramme
                        }
                        else // awwwww. so close. DAMMIT
                        {
                            Match matchedSentence = Regex. Match (Line, LETRegex);
                            Sentences. Add (new Sentence (LMLSentenceType. Let, new FELObject (matchedSentence. Groups ["DataName"]. Value, matchedSentence. Groups ["DataValue"]. Value, matchedSentence. Groups ["DataType"]. Value)));
                        }
                    break;
                    case "PRINT": // Print Value
                        Match matchedSentence = Regex. Match (Line, PRINTRegex);
                        Sentences. Add (new Sentence (LMLSentenceType. Print, matchedSentence. Groups ["DataValue"]. Value));
                    break;
                    case "DEFINE": // Define AccessLevel DataType Name be Value
                        Match matchedSentence = Regex. Match (Line, DEFINERegex);
                        NewObjectList. Add (new FELObject ());
                    break;
                    case "CALL": // Call RoutineName with ValueList
                    break;
                    case "ASK": // Ask for DataType Name
                    break;
                    case "FORGET": // Forget Name (value|being DataType)
                        // removes object during runtime
                    break;
                    #endregion

                    #region Loop paragraphs
                    case "IF": // If (Condition|Bool) then:
                    break;
                    case "ELSE_IF": // Else_if (Condition|Bool) then:
                    break;
                    case "END": // End level
                    break;
                    case "WHEN": // When DataType:
                    break;
                    case "BECOMES": // Becomes Value then:
                    break;
                    case "OTHERWISE": // Otherwise:
                    break;
                    case "FOR": // For (until NumericVal|NumericType Name, Comparison, Action with Name) do:
                    break;
                    case "WHILE": // While (Condition) do:
                    break;
                    case "FOR_EACH": // For_each (Item in Enumerable) do:
                    break;
                    case "EXIT": // Exit level
                    break;
                    #endregion

                    #region Miscellaneous sentences
                    case "BREAK": // Break
                    break;
                    case "CONTINUE": // Continue [to level]
                    break;
                    case "GO_TO": // Go_to [level|line|LineNumber]
                    break;
                    case "RETURN": // Return (to level|value)
                    break;
                    case "YIELD": // Yield value
                    break;
                    #endregion

                    #region Exception and error handling paragraphs
                    case "THROW": // Throw (ErrorValue|ErrorName)
                    break;
                    case "DIE": // Die
                        // terminate app errorless (Environment.Exit(0))
                    break;
                    case "HALT": // Halt
                        // launch debugger (Debug.Assert(false))
                    break;
                    case "TRY": // Try:
                    break;
                    case "CATCH": // Catch (ErrorValue|ErrorName):
                    break;
                    case "FINALLY": // Finally:
                    break;
                    case "CONTROLLED": // Controlled:
                    break;
                    case "UNCONTROLLED": // Uncontrolled:
                    break;
                    #endregion

                    #region Miscellaneous paragraphs
                    case "FIXED": // Fixed:
                    break;
                    #endregion

                    #region Event sentences
                    case "EVENT": // Event EventName with EventArgs
                    break;
                    case "RAISE": // Raise EventName
                    break;
                    case "ASSOCIATE": // Associate (it|Name) with EventName
                    break;
                    case "DISASSOCIATE": // Disassociate (it|Name) from EventName
                    break;
                    #endregion

                    #region Genji pre-processor sentences

                    #endregion

                    #region Non-metaprogramming overloading/overriding sentences
                    case "OPERATOR": // Operator O dealing DataType:
                    break;
                    #endregion

                    #region Non-metaprogramming outside-referring sentences
                    case "DECLARE": // Declare (Namespace|Assembly) as Alias
                    break;
                    case "USING": // Using (Namespace)[:]
                    break;
                    #endregion

                    #region Paragraph-referring sentences
                    case "ITS": // Its ([optional [outgoing|internal|variable]] parameter|returning_value) is DataType Name
                    break;
                    case "IT": // It [returns (DataType Name|Name)]
                    break;
                    #endregion

                    #region Interpreter-referring sentences
                    case "HER": // Her (attitude|personality) is val
                    break;
                    case "SHE": // She
                    break;
                    #endregion

                    #region Genji pre-processor-referring sentences
                    case "HIS": // His (attitude|personality) is val
                    break;
                    case "HE": // He
                    break;
                    #endregion

                    #region Windows Forms sentences
                    case "FORM":
                    break;
                    #endregion

                    #region Structural paragraphs
                    case "BUNDLE":
                    break;
                    case "PROGRAMME": case "PROGRAM":
                    break;
                    case "SECTION":
                    break;
                    case "NAMESPACE":
                    break;
                    case "MODULE":
                    break;
                    case "METAPROGRAMME": case "METAPROGRAM":
                    break;
                    case "SUBROUTINE":
                    break;
                    case "CLASS":
                    break;
                    case "STRUCTURE":
                    break;
                    case "SIGNATURE":
                    break;
                    case "ENUMERATION":
                    break;
                    case "REGION":
                    break;
                    case "METHOD":
                    break;
                    case "FUNCTION":
                    break;
                    case "PROPERTY":
                    break;
                    case "FIELD":
                    break;
                    #endregion

                    #region Property accessor sentences
                    case "GET":
                    break;
                    case "SET":
                    break;
                    #endregion

                    case "REM": case "REMINDER":
                    break;

                    default: if (Regex.IsMatch (Line, UnderstoodSentenceRegex)) switch (Regex.Match (Line, UnderstoodSentenceRegex). Groups ["Sentence"]. Value. ToUpperInvariant () )
                    {
                        case "UNDERSTANDABLE, HAVE A NICE DAY":
                        break;
                        case "AND SHE OOP":
                        break;
                        case "I HAS APPERD":
                        break;
                        case "STAY HERE": // pauses operation until invoked (i.e. wait for a command)
                        break;
                        default: break;
                    }
                    break;
                }
                else ErrorList. Add (1.001, $"Syntax error : This is an ill-formed sentence.");
            }
        }

        public static void IterateOperation()
        {

        }
    }
    #endregion
    #region Objects
    #region Objects
    /// <summary>
    /// Lilian's objects.
    /// </summary>
    public static class Objects
    {
        #region Kent Object Handling System
        /// <summary>
        /// Adds a new object handled by the Kent Object Handling System.
        /// </summary>
        /// <remarks>
        /// Unlike LOHS objects, KOHS objects are evaluated only during performance and not during
        ///object addition.
        /// </remarks>
        /// <param name="ObjectKey">The name of the object.</param>
        /// <param name="ObjectValue">The value of the object.</param>
        public static void AddKentObject (string ObjectKey, object ObjectValue) => KentObjectList.Add (ObjectKey, ObjectValue);
        #endregion
        #region Lilian Object Handling System
        #region Internal interpreter objects
        /// <summary>
        /// Anything in Lilian. (Objects)
        /// </summary>
        public abstract class Instance
        {
            /// <summary>
            /// This is optional; this makes Lilian think that this object is garbage and she'll
            ///throw it into the bin if this object 'escapes' - i.e. get ignored by her.
            /// </summary>
            public bool Rubbish = false;

            public delegate void HandRaiseHandler (object Sender, HandRaiseEventArgs Args);

            public event HandRaiseHandler RaiseHandEvent;

            public void RaiseHand (Exception exc) => OnRaiseHand (new HandRaiseEventArgs(exc));

            protected virtual void OnRaiseHand (HandRaiseEventArgs e)
            {
                HandRaiseEventArgs raise = RaiseHandEvent;
                if (raise != null) raise (this, e);
            }

            public virtual void AnswerLilianQuestion (object sender, HandRaiseEventArgs e);
        }
        
        /// <summary>
        /// A sentence in Lilian.
        /// </summary>
        public class Sentence: Instance
        {
            /// <summary>
            /// Initialises a new sentence.
            /// </summary>
            /// <param name="sentenceType">The type of the sentence.</param>
            /// <param name="obj">The referenced objects in this sentence.</param>
            public Sentence (LMLSentenceType sentenceType, params Instance [] obj)
            {
                SentenceType = sentenceType;
                Objects = obj;
            }

            /// <summary>
            /// Initialises a new sentence.
            /// </summary>
            /// <param name="sentenceType">The type of the sentence.</param>
            /// <param name="stbp">The string referenced in this sentence.</param>
            public Sentence (LMLSentenceType sentenceType, string stbp)
            {
                SentenceType = sentenceType;
                StringToBePrinted = stbp;
            }

            /// <summary>
            /// The type of the sentence.
            /// </summary>
            public LMLSentenceType SentenceType;

            /// <summary>
            /// The referenced objects in this sentence.
            /// </summary>
            public Instance [] Objects;

            public string StringToBePrinted;
        }

        public class LoopingParagraphSet: Instance
        {
            public LoopingParagraphSet ();
            public LoopingParagraphSet (Condition[] conditions, bool HaveDefaultCase = true, params Paragraph paraCol)
            {
                if (conditions. Length == paraCol. Length) for (int i; i > conditions. Length; i++) Conditions. Add (conditions [i], paraCol [i]);
                else RaiseHand (new ArgumentOutOfRangeException ("The number of assigned paragraphs is not equal to the number of conditions including the default case, if it is included."));
                // else ErrorList. Add (0.01, "The number of assigned paragraphs is not equal to the number of conditions including the default case, if it is included.");
            }

            public Dictionary <Condition, Paragraph> Conditions = new Dictionary <Condition, Paragraph> ();
        }

        /// <summary>
        /// A condition in Lilian.
        /// </summary>
        public class Condition: InstanceImplementation
        {
            /// <summary>
            /// Initialises a new condition clause.
            /// </summary>
            public Condition ();

            /// <summary>
            /// Initialises a new condition clause.
            /// </summary>
            /// <param name="equalityComparisonMode">The type of the condition.</param>
            /// <param name="l">The referenced object in this condition's left hand.</param>
            /// <param name="r">The referenced object in this condition's right hand.</param>
            public Condition (LMLEqualityComparisonMode equalityComparisonMode, Instance l, Instance r)
            {
                EqualityComparisonMode = equalityComparisonMode;
                Left = l;
                Right = r;
            }

            /// <summary>
            /// The type of the condition.
            /// </summary>
            public LMLEqualityComparisonMode EqualityComparisonMode;

            /// <summary>
            /// The referenced object in this condition's left hand.
            /// </summary>
            public Instance Left;

            /// <summary>
            /// The referenced object in this condition's right hand.
            /// </summary>
            public Instance Right;
        }

        /// <summary>
        /// A operation in Lilian.
        /// </summary>
        public class Operation: InstanceImplementation
        {
            /// <summary>
            /// Initialises a new operation clause.
            /// </summary>
            public Operation ();

            /// <summary>
            /// Initialises a new operation clause.
            /// </summary>
            /// <param name="operationType">The type of the operation.</param>
            /// <param name="l">The referenced object in this operation's left hand.</param>
            /// <param name="r">The referenced object in this operation's right hand.</param>
            public Operation (LMLOperationType operationType, Instance l, Instance r)
            {
                OperationType = operationType;
                Left = l;
                Right = r;
            }

            /// <summary>
            /// The type of the operation.
            /// </summary>
            public LMLOperationType OperationType;

            /// <summary>
            /// The referenced object in this operation's left hand.
            /// </summary>
            public Instance Left;

            /// <summary>
            /// The referenced object in this operation's right hand.
            /// </summary>
            public Instance Right;
        }

        /// <summary>
        /// A group of sentences.
        /// </summary>
        public class Paragraph: Instance
        {
            /// <summary>
            /// Initialises a new group of sentences known as a paragraph.
            /// </summary>
            public Paragraph();

            /// <summary>
            /// Initialises a new group of sentences known as a paragraph.
            /// </summary>
            /// <param name="paraName">The name of the paragraph.</param>
            /// <param name="paraContents">The contents of the paragraph.</param>
            public Paragraph (string paraName, params Sentence [] paraContents)
            {
                ParagraphName = paraName;
                ParagraphContents = new List <Sentence> (paraContents);
            }

            /// <summary>
            /// The name of the paragraph.
            /// </summary>
            public string ParagraphName;

            /// <summary>
            /// The contents of the paragraph.
            /// </summary>
            public List <Sentence> ParagraphContents = new List <Sentence> ();
        }

        /// <summary>
        /// An object in Lilian.
        /// </summary>
        public class FELObject: InstanceImplementation, Instance
        {
            /// <summary>
            /// Initialises a new object.
            /// </summary>
            public FELObject();

            /// <summary>
            /// Initialises a new object.
            /// </summary>
            /// <param name="name">The name of the object.</param>
            /// <param name="obj">The value of the object.</param>
            /// <param name="objtype">The type of the object.</param>
            /// <param name="Undesirable">When this object runs into an error, this becomes undesirable and must be disposed of.</param>
            public FELObject(string name, object obj, FELObjectType objtype, out bool Undesirable)
            {
                ObjectName = name;
                ObjectValue = obj;
                ObjectType = objtype;
                Undesirable = false; Rubbish = false;
            }

            /// <summary>
            /// Initialises a new object.
            /// </summary>
            /// <param name="name">The name of the object.</param>
            /// <param name="obj">The value of the object.</param>
            /// <param name="assumedobjtype">The assumed type of the object. Lilian will decide if it is valid or not.</param>
            /// <param name="Undesirable">When this object runs into an error, this becomes undesirable and must be disposed of.</param>
            /// <param name="Evaluated">Raise this flag to enable evaluation. By default it is.</param>
            public FELObject(string name, object obj, string assumedobjtype, out bool Undesirable, bool Evaluated = true)
            {
                ObjectName = name;
                string AssumedObjectType = assumedobjtype.ToUpperInvariant ();
                bool OOPSIE = false;
                UnevaluatedObject = obj;

                if (!Evaluated) UnevaluatedObjectType = AssumedObjectType; else Evaluate(out OOPSIE);
                if (OOPSIE)
                {
                    Undesirable = true; Rubbish = true; ObjectLists.RubbishBin.Add(this);
                }
                else
                {
                    Undesirable = false; Rubbish = false; ObjectLists.NewObjectList.Add(this);
                }

            }

            /// <summary>
            /// Evaluate the unevaluated object.
            /// </summary>
            /// <param name="Oopsie">If anything goes wrong this becomes true.</param>
            public void Evaluate(out bool Oopsie)
            {
                Type RealObjectType = ObjectValue.GetType();
                switch (AssumedObjectType)
                {
                    case "STRING": case "TEXT": ObjectValue = UnevaluatedObject. ToString (). Trim('"', '\''). AllowEscapees (); break;
                    case "INTEGER":
                        int parseTest;
                        if (int.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "BYTEVAL": case "BYTE":
                        sbyte parseTest;
                        if (sbyte.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "SHORTINT": case "SHORT":
                        short parseTest;
                        if (short.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "LONGINT": case "LONG":
                        long parseTest;
                        if (long.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "UNSIGNEDINTEGER": case "UNSIGNED_INTEGER":
                        uint parseTest;
                        if (uint.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "UNSIGNEDBYTEVAL": case "UNSIGNED_BYTE":
                        byte parseTest;
                        if (byte.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "UNSIGNEDSHORTINT": case "UNSIGNED_SHORT":
                        ushort parseTest;
                        if (ushort.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "UNSIGNEDLONGINT": case "UNSIGNED_LONG":
                        ulong parseTest;
                        if (ulong.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "SINGLEFLOAT": case "FLOATING_INTEGER": case "SINGLE-PRECISION_FLOATING_INTEGER":
                        float parseTest;
                        if (float.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "DOUBLEFLOAT": case "DOUBLE-PRECISION_FLOATING_INTEGER":
                        double parseTest;
                        if (double.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
                    case "DECIMALFLOAT": case "DECIMAL":
                        decimal parseTest;
                        if (decimal.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
                        break;
/*                  case "HALFFLOAT":
                        Half parseTest;
                        if (Half.TryParse(UnevaluatedObject. ToString (), out parseTest)) ObjectValue = parseTest;
                        else Oopsie = true;
*/                  case "BOOLEAN": case "BOOL":
                        string FlagRaiseType = UnevaluatedObject. ToString (). ToUpperInvariant ();
                        bool parseTest;
                        if (bool.TryParse(FlagRaiseType, out parseTest)) ObjectValue = parseTest;
                        else  /* if the parse is unsuccess for whatever reason */ switch (FlagRaiseType)
                        {
                            case "TRUE": case "YES": case "T": case "Y": case "1":
                                ObjectValue = true;
                                break;
                            case "FALSE": case "NO": case "F": case "N": case "0":
                                ObjectValue = false;
                                break;
                            default: Oopsie = true; break;
                        }
                        break;
                    case "MIXED_BOOL": case "THREEBOOL": case "MIXEDBOOL":
                        string FlagRaiseType = UnevaluatedObject. ToString (). ToUpperInvariant ();
                        switch (FlagRaiseType)
                        {
                            case "TRUE": case "YES": case "T": case "Y": case "1": case "m2":
                                ObjectValue = true;
                                FormalBooleanValue = LMLBoolStates.True;
                                break;
                            case "FALSE": case "NO": case "F": case "N": case "0": case "m0":
                                ObjectValue = false;
                                FormalBooleanValue = LMLBoolStates.False;
                                break;
                            case "HALF": case "MAYBE": case "H": case "M": case "½": case "m1": // yes try to write ½ in the code
                                FormalBooleanValue = LMLBoolStates.Half;
                                break;
                            default: Oopsie = true; break;
                        }
                        break;
                    case "FIVEBOOL": case "MIXED_BOOL5":
                        string FlagRaiseType = UnevaluatedObject. ToString (). ToUpperInvariant ();
                        switch (FlagRaiseType)
                        {
                            case "TRUE": case "YES": case "T": case "Y": case "1": case "m2": case "f4":
                                ObjectValue = true;
                                FormalBooleanValue = LMLBoolStates.True;
                                break;
                            case "FALSE": case "NO": case "F": case "N": case "0": case "m0": case "f0":
                                ObjectValue = false;
                                FormalBooleanValue = LMLBoolStates.False;
                                break;
                            case "HALFTRUE": case "MAYBEYES": case "HT": case "MY": case "f3":
                                FormalBooleanValue = LMLBoolStates.HalfTrue;
                                break;
                            case "HALFFALSE": case "MAYBENO": case "HF": case "MN": case "f1":
                                FormalBooleanValue = LMLBoolStates.HalfFalse;
                                break;
                            case "HALF": case "MAYBE": case "H": case "M": case "½": case "m1": case "f2": // yes try to write ½ in the code
                                FormalBooleanValue = LMLBoolStates.Half;
                                break;
                            default: Oopsie = true; break;
                        }
                        break;
                    default: Oopsie = true; break;
                }
            }

            /// <summary>
            /// The name of the object.
            /// </summary>
            public string ObjectName;

            /// <summary>
            /// The value of the object.
            /// </summary>
            public object ObjectValue;

            /// <summary>
            /// The type of the object.
            /// </summary>
            public FELObjectType ObjectType;

            /// <summary>
            /// The type of the object. At least that's what it is.
            /// </summary>
            public string UnevaluatedObjectType;

            /// <summary>
            /// The value of the object. At least that's what it is.
            /// </summary>
            public string UnevaluatedObject;

            /// <summary>
            /// The official boolean value of this object.
            /// </summary>
            public LMLBoolStates FormalBooleanValue = LMLBoolStates.Null;
        }
        #endregion
        #region Miscellaneous objects
        /// <summary>
        /// The current accumulated number of undesirables.
        /// </summary>
        public static int NumberOfUndesirables = 0;
        #endregion
        #region Script customisations
        /// <summary>
        /// The script customisation modules for Lilian.
        /// </summary>
        public static class SchemaSupport
        {
            /// <summary>
            /// The list of macros in the schema.
            /// </summary>
            public static List <Macro> MacroFunctions = new List <Macro> ();
        }
        #endregion 
        #endregion
    }
    #endregion
    #region Object lists
    /// <summary>
    /// The tabulation of objects in memory. Lilian keeps a journal of what can be used, and what
    ///would be tossed into the bin.
    /// </summary>
    public static class ObjectLists
    {  
        /// <summary>
        /// The list of objects handled by the Lilian Object Handling System.
        /// </summary>
        public static List <FELObject> NewObjectList = new List <FELObject> ();

        /// <summary>
        /// The list of sentences that Lilian understood from the current code.
        /// </summary>
        public static List <Sentence> Sentences = new List <Sentence> ();

        /// <summary>
        /// The list of paragraphs that Lilian understood from the current code.
        /// </summary>
        public static List <Paragraph> Paragraphs = new List <Paragraph> ();

        /// <summary>
        /// The list of objects handled by the Kent Object Handling System.
        /// </summary>
        public static Dictionary <string, object> KentObjectList = new Dictionary <string, object> ();

        /// <summary>
        /// The current list of errors that Lilian encountered during interpretation.
        /// </summary>
        public static Dictionary <double, string> ErrorList = new Dictionary <double, string> ();

        /// <summary>
        /// This is where all the discarded objects go. Usually these have the 'Rubbish' flag up. Everytime the script is
        ///run, this is cleared.
        /// </summary>
        public static List <object> RubbishBin = new List <object> ();

        /// <summary>
        /// This is where all the discarded Kent objects go. They go here when evaluation says that they have an invalid
        ///value type and value. Everytime the script is run, this is cleared.
        /// </summary>
        public static Dictionary <string, object> KentObjectListBin = new Dictionary <string, object> ();

        /// <summary>
        /// The list of characters that are reserved in the current command set. These are added in 
        ///by the other snap-ins that would be snapped in later on.
        /// </summary>
        public static Dictionary <string, char> Escapees = new Dictionary <string, char> ();
        
        /// <summary>
        /// A list of objects created by DEFINE statements to be evaluated once the interpreter 
        ///enters evaluation mode.
        /// </summary>
        public static List <FELObject> ToBeEvaluated = new List <FELObject> ();
    }
    #endregion
    #endregion
    #region Events
    /// <summary>
    /// When something happens to Lilian, info must be provided about it here.
    /// </summary>
    public static class LilianEvents
    {
        /// <summary>
        /// The arguments for an event where Lilian raises her hand about something that might have went wrong.
        /// </summary>
        public class HandRaiseEventArgs: EventArgs
        {
            /// <summary>
            /// Initialises a new HandRaiseEvent argument.
            /// </summary>
            public HandRaiseEventArgs (Exception reason) => ReasonForHandRaise = reason;

            /// <summary>
            /// The reason for the handraise.
            /// </summary>
            public Exception ReasonForHandRaise { get; set; }
        }
    }
    #endregion
    #region Script customisation and macros
    /// <summary>
    /// The script customisation modules for Lilian to understand your own language.
    /// </summary>
    public static class Customisations
    {
        /// <summary>
        /// The current schema for Lilian scripts. This is ironically an XML file.
        /// </summary>
        public static XDocument CurrentSchema = new XDocument();
        
        /// <summary>
        /// The path of the current schema for Lilian scripts.
        /// </summary>
        public static string CurrentSchemaPath = "";
        
        /// <summary>
        /// Loads a schema into place.
        /// </summary>
        /// <param name="Path">The path to the schema file.</param>
        public static void LoadSchema(string Path)
        {
            CurrentSchema = XDocument.Load(Path);
            CurrentSchemaPath = Path;
            
            var MoodEntry = from entry in CurrentSchema.Descendants("SentenceMoods") select new
            {
                Keyword = entry.Element("Entry").Attribute("Name").Value,
                LinkedFunction = entry.Element("Entry").Attribute("Function").Value,
            };
            
            var Macros = from entry in CurrentSchema.Descendants("Functions") select new
            {
                Name = entry.Element("Function").Attribute("Name").Value,
                Function = entry.Element("Function").Value,
            };
            
            
        }
    }
    #endregion
    #region Itty-Bitty Code (compresser)
    namespace IttyBitty
    {
        
    }
    #endregion
    #region Extensions
    public static class Extensions
    {
        /// <summary>    
        /// Converts all escaped characters into their rightful ones.      
        /// </summary>
        /// <remarks>
        /// The following characters are reserved in Lilian Kent: <br/>
        /// _ - this is the command split operator, used to split the commands into workable
        ///     string arrays. <br/>
        /// " - this is the text quotation mark. <br/> 
        /// ' - this is the string quotation mark. <br/>
        /// $ - this is the escape sequence. <br/>
        /// % - this calls a variable's value; e.g. %User. <br/>
        /// ‰ - this calls a new anon type; e.g. ‰(string 'Hey.static'). <br/>
        /// <br/>
        /// The following sequences are recognised:
        /// n - newline <br/>
        /// ¬ - intentionally splits a text or string into substrings. This is based off of the
        ///     original operator in standard Lilian wherein ¬ was its command split operator. <br/>
        ///
        /// Other miscellaneous characters may be reserved by custom command snap-ins.
        /// </remarks>
        /// <param name="inputText">The input string.</param>
        public static string AllowEscapees(this string inputText)
        {
            string returningValue = inputText;

            returningValue.Replace("$ct", "_");
            returningValue.Replace("$qt", "\"");
            returningValue.Replace("$sq", "'");
            returningValue.Replace("$ds", "$");
            returningValue.Replace("$pc", "%");
            returningValue.Replace("$pm", "‰");
            
            returningValue.Replace("$n", "\n");

            // Custom escapees
            foreach (KeyValuePair escapee in ObjectLists.Escapees) inputText.Replace($"${ escapee.Key }", (string)escapee.Value);

            return returningValue;
        }

        /// <summary>
        /// Splits the string into some substrings.
        /// </summary>
        /// <param name="inputText">The input string.</param>
        public static string[] AllowSplitting(this string inputText)
        {
            string[] returningValue = inputText.Split("$¬"); return returningValue;
        }
    }
    #endregion
    #region Enumerations
    /// <summary>
    /// Lilian's current mindset.
    /// </summary>
    public static class Enumerations
    {
        /// <summary>
        /// The type of object Lilian is adding to the lists.
        /// </summary>
        public enum FELObjectType
        {
            /// <summary>
            /// Nothing. CLI equivalent is type Null or Nothing.
            /// </summary>
            Null = -1,

            /// <summary>
            /// A class instantiation.
            /// </summary>
            Whatever = 0,

            /// <summary>
            /// Strings of text that are marked with double quotation marks. CLI equivalent is the object in Console.Write/WriteLine(object value).
            /// </summary>
            ExternalString = 1,

            /// <summary>
            /// Strings of text that are marked with single quotation marks. CLI equivalent is type String.
            /// </summary>
            InternalString = 2,

            /// <summary>
            /// Signed integers. CLI equivalent is type Int32 (from -2147483648 to 2147483647).
            /// </summary>
            Integer = 3,

            /// <summary>
            /// True or False, Yes or No. CLI equivalent is type Bool.
            /// </summary>
            Boolean = 4,

            /// <summary>
            /// Structures. CLI equivalent are classes.
            /// </summary>
            Structure = 5,

            /// <summary>
            /// Bytes, or signed integers in other contexts. CLI equivalent is type SByte (signed byte; from -128 to 127).
            /// </summary>
            ByteVal = 6,

            /// <summary>
            /// Signed integers. CLI equivalent is type Int16 (from -32768 to 32767).
            /// </summary>
            ShortInt = 7,

            /// <summary>
            /// Signed integers. CLI equivalent is type Int64 (from -9223372036854775808 to 9223372036854775807).
            /// </summary>
            LongInt = 8,

            /// <summary>
            /// A Unicode, ASCII or whatever-codepage-standard character. CLI equivalent is type Char. However, unlike the CLI
            ///Char, which allows even the mere character itself, Characters in FEL are only written in HEX (e.g. FFFF.) but
            ///there is no limit to how many digits are on there (as of now there're 10FFFF or 1,048,576 unique characters in
            ///the Unicode Standard, 13.0), but technically speaking, CLI can only take up to FFFF.
            /// </summary>
            Character = 9,

            /// <summary>
            /// Anything that has a list in it.
            /// </summary>
            List = 10,

            /// <summary>
            /// An enumeration with a predefined set of values that can't be removed or added to. CLI equivalent is System.Enum.
            /// </summary>
            Enumeration = 11,

            /// <summary>
            /// A tri-state bool that utilises the randomiser of the interpreter to determine its state when in
            ///the middle state. CLI equivalent is the three-state function for checkboxes. 'Yes,' 'Maybe,' 'No,'
            ///'True,' 'Uncertain,' 'False.' Incompatible with CLI.
            /// </summary>
            ThreewayBool = 12,

            /// <summary>
            /// A 'biased' bool that goes either from 'No,' 'Maybe no,' 'Don't know,' 'Maybe yes,' and 'Yes' which
            ///utilises the randomiser of the interpreter to determine its state when in the middle three values.
            ///Incompatible with CLI.
            /// </summary>
            FivewayBool = 13,

            /// <summary>
            /// Unsigned integers. CLI equivalent is type UInt32 (from 0 to 4294967295).
            /// </summary>
            UnsignedInteger = 14,

            /// <summary>
            /// Bytes, or unsigned integers in other contexts. CLI equivalent is type Byte (from 0 to 255).
            /// </summary>
            UnsignedByteVal = 15,

            /// <summary>
            /// Unsigned integers. CLI equivalent is type UInt16 (from 0 to 65535).
            /// </summary>
            UnsignedShortInt = 16,

            /// <summary>
            /// Unsigned integers. CLI equivalent is type UInt64 (from 0 to 18446744073709551614).
            /// </summary>
            UnsignedLongInt = 17,

            /// <summary>
            /// Integers that have the maximum and mininum values completely depndent on what the processor of the computer that
            ///is currently harbouring the code can handle. CLI equivalent is type BigInteger. 
            /// </summary>
            /// <remarks>
            /// This is the integer type used in CALC.exe to be able to handle numbers as large as 1E+9999, or one
            ///trimillitrecentitrigintitrillion, in its scientific calculator function.
            /// </remarks>
            ProcessorDependentInt = 18,

            /// <summary>
            /// A single-precision floating integer that can do almost 6 to 9 digits at a time,
            ///occupying 32 bits. CLI equivalent is type float (from +-1.5*10e-45 to +-3.4*10e+38).
            /// </summary>
            SingleFloatie = 19,

            /// <summary>
            /// A double-precision floating integer that can do almost 15 to 17 digits at a time,
            ///occupying 64 bits. CLI equivalent is type double (from -5e*10e-324 to 3.4*10e+308).
            /// </summary>
            DoubleFloatie = 20,

            /// <summary>
            /// A single-precision floating integer that can do 28-29 digits at a time.
            ///CLI equivalent is type decimal (from -1e-29 to 7.9228*10e+28).
            /// </summary>
            DecimalFloatie = 21,

            /// <summary>
            /// This is a planned halving of the standard single-precision floating integer.
            ///It can do almost approximately 10 digits at a time. CLI equivalent is type
            ///Half.
            /// </summary>
            /// <remarks>
            /// I'm not currently sure about the true upper and lower bounds of both the
            ///significands and physical value, but we'll see once .NET 5 is out and we've
            ///migrated to it.
            /// </remarks>
            HalfFloatie = 22,

        }

        /// <summary>
        /// The type of sentence Lilian is now processing.
        /// </summary>
        /// <remarks>
        /// Any structural sentence is ignored since it will tell the interpreter to make a new 
        ///paragraph instead right on the spot. Place statements are also ignored since they also
        ///activate on the spot.
        /// </remarks>
        public enum LMLSentenceType
        {
            /// <summary>
            /// Anything that was recognised by the regular expression.
            /// </summary>
            Anything = -1,

            Print = 1,
            Let = 2,
            Call = 3,
            AskFor = 4,
            Break = 5,
            Continue = 6,
            GoTo = 7,
            Return = 8,
            ReturnVal = 8,
            YieldReturnVal = 8,
            Throw = 9,
            Die = 9,
            CatchGoto = 7,
            It = 10,
            Its = 11,
            Her = 12,
            WindowsForms = 13,
            WindowsFormsInitialisation = 13,
            WindowsFormsControl = 13,
            WindowsFormsControlControl = 13,
            GoBackToParentRoutine = 7,
            GoBackToMainstream = 7,
            EventAssign = 14,
            EventRemove = 14,
            EventRaise = 14,
            She = 12,


        }

        /// <summary>
        /// The type of interjection that Lilian is now processing.
        /// </summary>
        public enum LMLInterjectionType
        {
            /// <summary>
            /// Nothing.
            /// </summary>
            None = 0,

            /// <summary>
            /// Forcefully ends the interpretation at the current sentence with error 0.
            /// </summary>
            Fuck = 1,

            /// <summary>
            /// Repeats the previous sentence. Much better than using GOTO N-1.
            /// </summary>
            What = 2,

            /// <summary>
            /// Ends the current paragraph. If in the mainstream paragraph, it's the same as FUCK.
            /// </summary>
            Nope = 3,

            /// <summary>
            /// Saves the current field and paragraphs to an LBJX comma-separated value file named exactly the
            ///same as the current code file.
            /// </summary>
            Remember = 4,
        }
    
        /// <summary>
        /// The type of Windows Forms-related sentence Lilian is now processing.
        /// </summary>
        public enum LMLWindowsFormsSentenceMode
        {
            /// <summary>
            /// Adds or configures a control in a form.
            /// </summary>
            Control = 0,

            /// <summary>
            /// Adds or configures a form.
            /// </summary>
            Form = 1,

            /// <summary>
            /// Initialises the Windows Forms implementation.
            /// </summary>
            /// <remarks>    
            /// The code for a standard Windows Forms application initialiser is usually like this:<br />
            /// Application.EnableVisualStyles(); <br />
            /// Application.SetCompatibleTextRenderingDefault(false); <br />
            /// Application.Run(new Form()); <br />
            /// The programme will run these things when <c>FORM_INITIALISE_STARTS_(form)</c> is run. If it is
            ///run again, an error would occur. 
            /// </remarks>    
            Initialiser = 2,
        }

        /// <summary>
        /// The comparison type in a condition statement.
        /// </summary>
        public enum LMLComparisonType
        {
            /// <summary>
            /// The left and right hands are compared by their values using standard unary comparison.
            /// </summary>
            DefaultEqualityComparison = 0,

            /// <summary>
            /// The left hand is evaluated if it is null. It is equivalent to a DEC but with 'null'
            ///as the right hand. This is a carry-over from the null forgivers in C#.
            /// </summary>
            NullForgivingComparison = 1, 
        }
        
        /// <summary>
        /// How Lilian would compare the hands in a condition statement.
        /// </summary>
        public enum LMLEqualityComparisonMode
        {
            /// <summary>
            /// Equal. (=/EQUALTO)
            /// </summary>
            Equal = 0,

            /// <summary>
            /// Greater than. (&gt;/GREATERTHAN)
            /// </summary>
            GreaterThan = 1,

            /// <summary>
            /// Greater than or equal to. (≥/GREATERTHANOREQUALTO)
            /// </summary>
            GreaterEqual = 2,

            /// <summary>
            /// Less than. (&lt;/LESSTHAN)
            /// </summary>
            LessThan = 3,

            /// <summary>
            /// Less than or equal to. (≤/LESSTHANOREQUALTO)
            /// </summary>
            LessEqual = 4,

            /// <summary>
            /// Object type is a(n).... (≡/IS)
            /// </summary>
            TypeIs = 5,

            /// <summary>
            /// Unequal. (≠/UNEQUALTO)
            /// </summary>
            Unequal = 6,

            /// <summary>
            /// Object type isn't a(n).... (≢/ISNT)
            /// </summary>
            TypeIsnt = 7,
        }

        /// <summary>
        /// The type of binary operation.
        /// </summary>    
        public enum LMLOperationType
        {
            /// <summary>
            /// None.
            /// </summary>
            Implication = 0,

            /// <summary>
            /// x + y = z
            /// </summary>
            Addition = 1,

            /// <summary>
            /// x - y = z
            /// </summary>
            Subtraction = 2,

            /// <summary>
            /// x * y = z
            /// </summary>
            Multiplication = 3,

            /// <summary>
            /// x / y = z
            /// </summary>
            Division = 4,

            /// <summary>
            /// x \ y = x - (y * (int)(x/y)) = z. On other languages it is either 'mod' or %.
            /// </summary>
            Modulo = 5,

            /// <summary>
            /// x &lt;&lt; y = x * (2 * y) = z
            /// </summary>
            LeftShift = 6,

            /// <summary>
            /// x &gt;&gt; y = x / (2 * y) = z
            /// </summary>
            RightShift = 7,

            /// <summary>
            /// e.g. 0101 &amp; 1010 = 0000 (0101 = 5 and 1010 = 10; so 5 &amp; 10 is 0)
            /// </summary>
            And = 8,

            /// <summary>
            /// e.g. 0101 | 1010 = 1111 (0101 = 5 and 1010 = 10; so 5 | 10 is 15; similar to 5 + 10 = 15;
            ///but eventually it will be not like a + b = c.)
            /// </summary>
            Or = 9,

            /// <summary>
            /// e.g. 0111 _ 1010 = 1101 (0111 = 7 and 1010 = 10; so 7 _ 10 is 13)
            /// </summary>
            Xor = 10,

            /// <summary>
            /// x . y = xy, literally (e.g.true 19 . 4 = 194, "Hello, " . 'world!' = "Hello, world!").
            ///This is a direct carry-over from PHP's string concatenation operation.
            /// </summary>
            DirectConcatenation = 11,

            /// <summary>
            /// e.g. 1245000 $ 6 = 1.245. It gets the significant digits of a floating point.
            /// </summary>
            Signification = 12,
        }

        /// <summary>
        /// The type of Boolean-algebraic binary operation.
        /// </summary>
        public enum LMLLogicalOperationType
        {
            /// <summary>
            /// Only either A or B.
            /// </summary>
            Statement = 0,

            /// <summary>
            /// A &amp; B will return true if and only if both variables are individually true.
            /// </summary>
            And = 1,

            /// <summary>
            /// Except if both false, A | B will always return true when at least one of the variables is true.
            /// </summary>
            Or = 2,

            /// <summary>
            /// A ^ B will return true if and only if one of the variables are false whilst the other one is true.
            /// </summary>
            Xor = 3,

            /// <summary>
            /// A ↓ B will always be false unless they are both false and only then it will be true.
            /// </summary>
            Nor = 4,

            /// <summary>
            /// A ↑ B will always be true unless they are both true and only then it will be false.
            /// </summary>
            Nand = 5,

            /// <summary>
            /// A ↔ B will return true if and only if they are either both true or false.
            /// </summary>
            Xnor = 6,

            /// <summary>
            /// ¬(A → B) will return true if and only if A is true and B is false. Any other inputs will be false.
            /// </summary>
            Nonimplication = 7,

            /// <summary>
            /// ¬(A ← B) will return true if and only if A is false and B is true. Any other inputs will be false.
            /// </summary>
            ConverseNonimplication = 8,

            /// <summary>
            /// A → B will return true if at least B is true. If only A is true, it is false; if both are false it is true.
            /// </summary>
            Implication = 9,

            /// <summary>
            /// A ← B will return true if at least A is true. If only B is true, it is false; if both are false it is true.
            /// </summary>
            ConverseImplication = 10,
        }
        
        /// <summary>
        /// How Lilian handles the code.
        /// </summary>
        public enum LMLInterpretationHospitalityLevel
        {
            /// <summary>
            /// Normal hospitality, custom macros must be described by a schema.
            /// </summary>
            Normal = 0,

            /// <summary>
            /// There's almost no such thing as a syntax error, and imperative sentences must end in
            ///an exclamation mark to get recognised.
            /// </summary>
            Extensible = 1,
            
            /// <summary>
            /// All sentences will act like separate commands in a batch script.
            /// </summary>
            EventLanguage = 2,
            
            /// <summary>
            /// The same as EventLanguage but in a much more difficult "line marker"
            ///setting wherein separate characters are used as function keywords.
            ///This is a carry-over of FEL. 
            /// </summary>
            EventLanguageAbbr = 3,
        }

        /// <summary>
        /// The boolean states used alongside normal CLI boolean values.
        /// <summary>
        public enum LMLBoolStates
        {
            /// <summary>
            /// Nothing.
            /// </summary>
            Null = -1,

            /// <summary>
            /// False, No, F, N, 0, m0, f0.
            /// </summary>
            False = 0,

            /// <summary>
            /// HalfFalse, MaybeNo, HF, MN, f1.
            /// </summary>
            HalfFalse = 1,

            /// <summary>
            /// Half, Maybe, H, M, m1, f2.
            /// </summary>
            Half = 2,

            /// <summary>
            /// HalfTrue, MaybeYes, HT, MY, f3.
            /// </summary>
            HalfTrue = 3,

            /// <summary>
            /// True, Yes, T, Y, 1, m2, f4.
            /// </summary>
            True = 4,
        }
        /// <summary>
        /// The type of code division that Lilian is now processing.
        /// </summary>
        public enum LMLDivisionType
        {
            /// <summary>
            /// Either a condition, operation or anonymous initialisation. Aesthetic purposes only.
            /// </summary>
            Phrase = -1,

            /// <summary>
            /// A sentence.
            /// </summary>
            GenericSentence = 0,

            /// <summary>
            /// A sentence with multiple clauses or phrases in it.
            /// </summary>
            ComplexSentence = 0,

            /// <summary>
            /// A region that just serves as an aesthetic feature to fold some code in a Lilian 
            ///editor, specifically Lilian Studio. Aesthetic purposes as this statement is 
            ///intentionally ignored.
            /// </summary>
            PragmaRegion = 1,

            /// <summary>
            /// A region where GO_TO labels can lead Lilian to.
            /// </summary>
            Region = 1,

            /// <summary>
            /// A region where overflowing or eternally-looping code can go unchecked. Literally.
            /// </summary>
            ContainmentUnit = 1,
            
            /// <summary>
            /// A region that depends on a condition to loop or run.
            /// </summary>
            Loop = 1,

            /// <summary>
            /// A region where code that could potentially throw or result in a runtime error could ///be stopped in time. Also includes the FINALLY block.
            /// </summary>
            Catcher = 1,

            /// <summary>
            /// A region where fields and subroutines are named the same as a means of signature 
            ///simplification.
            /// </summary>
            Signature = 2,

            /// <summary>
            /// A type of field that can evaluate values that are sent to it.
            /// </summary>
            Property = 2,

            /// <summary>
            /// A generic paragraph.
            /// </summary>
            Subroutine = 3,

            /// <summary>
            /// A paragraph that returns nothing. (void)
            /// </summary>
            Method = 3,

            /// <summary>
            /// A paragraph that at least returns something.
            /// </summary>
            Function = 3,

            /// <summary>
            /// A generic field and method and signature collection.
            /// </summary>
            Mother = 4,

            /// <summary>
            /// A collection of methods/functions and fields/properties.
            /// </summary>
            Class = 4,

            /// <summary>
            /// A collection of methods.
            /// </summary>
            Module = 4,

            /// <summary>
            /// A collection of fields.
            /// </summary>
            Structure = 4,

            /// <summary>
            /// A generic collection of various mothers (collections).
            /// </summary>
            Chapter = 5,

            /// <summary>
            /// A collection of various mothers (collections).
            /// </summary>
            Namespace = 5,

            /// <summary>
            /// A collection of symbols and chapters. Symbols are fields defined by a schema rather ///than the code itself.
            /// </summary>
            Section = 6,

            /// <summary>
            /// A section defined by a schema.
            /// </summary>
            ReservedSection = 6,

            /// <summary>
            /// A collection of sections.
            /// </summary>
            Division = 7,

            /// <summary>
            /// A division defined by a schema.
            /// </summary>
            ReservedDivision = 7,

            /// <summary>
            /// A programme.
            /// </summary>
            Programme = 8,
            
            /// <summary>
            /// A collection of programmes.
            /// </summary>
            Bundle = 9,
        }
    }
    #endregion
    #region Interpreter constants
    public static class Constants
    {
        #region Regular expression constants
        #region Shared constants
        /// <summary>
        /// The substring of multiple regexes that require the reference of a field's type.
        /// </summary>
        public const string DataTypeSwitches = @"(?i)(?<DataTypeSwitch>string|text|integer|unsignedinteger|unsigned_integer|shortint|short|unsignedshortint|unsigned_short|longint|long|unsignedlongint|unsigned_long|byteval|byte|unsignedbyteval|unsigned_byte|boolean|bool|threebool|mixedbool|mixed_bool|fivebool|mixed_bool5|singlefloat|floating_integer|single-precision_floating_integer|doublefloat|double-precision_floating_integer|decimalfloat|decimal|character|variable|halffloat|half-precision_floating_integer|instantiation_of\s.+)";

        /// <summary>
        /// The substring of multiple regexes that require the reference of a field's access level.
        /// </summary>
        public const string DataAccessLevelSwitches = "(?i)(?<DataAccessLevelSwitch>public|private|internal|friendly|protected)?"; 

        /// <summary>
        /// The substring of multiple regexes that require the reference of a field's value.
        /// </summary>
        public const string DataValueEx = @"(?<DataValue>(?i)null|nothing|empty|true|false|half|halftrue|halffalse|yes|no|maybe|maybeyes|maybeno|b0|b1|m0|m1|m2|f0|f1|f2|f3|f4|t|f|h|ht|hf|y|n|m|my|mn|\"".*\""|'.*'|\#.|\#[0-9a-fA-F]{6}|\$.|\$[0-9a-fA-F]{4}|[0-9]+)";

        /// <summary>
        /// The substring of multiple regexes that require the reference of a data type's name.
        /// </summary>
        public const string DataNameEx = "(?<DataName>[a-zA-Z0-9]+)";

        /// <summary>
        /// The punctuation mark that ends a sentence. This will be sought after when the 
        ///hospitality level is set to 'Extensible.'
        /// </summary>
        public const string Punctuation = @"(?<Punctuation>\.|!)";
        #endregion

        /// <summary>
        /// The standard sentence formation. It would get the first word before anything else. This 
        ///is much more efficient than splitting a sentence in half respective to the whitespace 
        ///characters.
        /// </summary>
        public const string GeneralRegex = @"(?:\n\s*)?(?<Verb>[A-z]+|#)\s((?i)(.*))" + Punctuation; // https://regex101.com/r/YQmplC/1

        public const string UnderstoodSentenceRegex = @"(?:\n\s*)?(?<Sentence>.+)" + Punctuation;

        /// <summary>
        /// The regular expression for a LET sentence.
        /// </summary>
        public const string LETRegex = @"(?:\n\s*)?(?i)let\s" + DataTypeSwitches + @"\s" + DataNameEx + @"\s(?:be|=)?\s" + DataValueEx + Punctuation;
        
        /// <summary>
        /// The regular expression for a PRINT sentence.
        /// </summary>
        public const string PRINTRegex = @"(?:\n\s*)?(?i)print\s" + DataValueEx + Punctuation;

        /// <summary>
        /// The regular expression for a DEFINE sentence.
        /// </summary>
        public const string DEFINERegex = @"(?:\n\s*)?(?i)define\s" + /* DataAccessLevelSwitches + @"\s?"*/ + DataTypeSwitches + @"\s" + DataNameEx + @"\s(?:as|=)?\s" + DataValueEx + Punctuation;

        /// <summary>
        /// The regular expression for a TURN sentence.
        /// </summary>
        public const string TURNRegex = @"(?:\n\s*)?(?i)turn\s" + DataNameEx + @"\s(?i)into\s" + DataValueEx + Punctuation;
        #endregion
        #region Miscellaneous constants
        /// <summary>
        /// The list of delimiters in Lilian.
        /// </summary>
        /// <remarks>
        /// Every other character in a string will be ignored, except for quotes, which would be 
        ///replaced from $qt or $sq to ' and ", respectively, and $ which is treated as an escape 
        ///character as probably stated before.
        /// </remarks>
        public static ReadOnlyCollection<char> Delimiters = new ReadOnlyCollection<char>(new List <char>(new char[]{'\'', '"', '<', '>', '(', ')', '[', ']', '{', '}', '@', '#', '$', '%', '‰', '&', '¬', '~'})); // yes, anonymous type in anonymous type
        #endregion
    }
    #endregion
    #region Dotty Tables
    namespace Martha
    {
        /// <summary>
        /// The tabulator for Dotty Tables
        /// </summary>
        public static class Tabulator
        {
            /// <summary>
            /// Tables
            /// </summary>
            public static Dictionary <string, Dictionary <string, List <Column>>> Tables = new Dictionary <string, Dictionary <string, List <Column>>> ();
        }
        /// <summary>
        /// Dotty's objects
        /// </summary>
        public static class Objects
        {
            /// <summary>
            /// A column in a table
            /// </summary>
            public class Column: Instance
            {
                /// <summary>
                /// Initialises a new table column.
                /// </summary>
                public Column();

                /// <summary>
                /// Initialises a new table column.
                /// </summary>
                /// <param name="name">The name of the column.</param>
                /// <param name="objTypeRestr">The only object type permitted in this column. Set 
                ///to 0 or FELObjectType.Whatever for whatever type.</param>
                /// <param name="colRows">The item of this column.</param>
                public Column(string name, FELObjectType objTypeRestr = FELObjectType.Whatever, FELObject colItem)
                {
                    Name = name;
                    ObjectTypeRestriction = objTypeRestr;
                    ColItem = colItem;
                }

                /// <summary>
                /// The name of the column.
                /// </summary>
                public string Name;

                /// <summary>
                /// The only object type permitted in this column. Set to 0 or FELObjectType.
                ///Whatever for whatever type.
                /// </summary>
                public FELObjectType ObjectTypeRestriction;

                /// <summary>
                /// The item of this column.
                /// </summary>
                public FELObject ColItem;
            }
        }
    }
    #endregion
}