using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;
using System.IO.Compression;

using static fonder.Lilian.New.Interpreter.Spellbook;
using static fonder.Lilian.New.Interpreter.Actualiser;

using static System.Console;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New
{
    public static partial class Interpreter
    {
        public static class Actualiser
        {
            [Serializable]
            public class Statement
            {
                public string AssociatedStructure;
                public int AssociatedAction;
            }

            [Serializable]
            public class Instruction
            {
                public SentenceFruit AssociatedFruit;
                public Statement AssociatedStatement;

                public void Invoke()
                {
                    if (CurrentActions.ContainsKey(AssociatedStatement.AssociatedAction)) CurrentActions[AssociatedStatement.AssociatedAction].Invoke(AssociatedFruit.Value[AssociatedFruit.AssociatedSentence.PointersToValues[0]].Trim('"'));
                    else throw new Lamentation(0xe, AssociatedStatement.AssociatedAction.ToString());
                }
            }
        }

        public static class Bureau
        {
            [Serializable]
            public class MalleableInst
            {
                public int Index;
                public Instruction Inst;
            }
            internal static (byte[], int) Package()
            {
                if (CurrentInstructions.Count == 0) return (null, 0);

                try
                {
                    List<MalleableInst> things = new();
                    foreach (KeyValuePair<int, Instruction> state in CurrentInstructions) things.Add(new() { Index = state.Key, Inst = state.Value });

                    byte[] returningvalue;

                    XmlSerializer formatter = new(typeof(MalleableInst[]));
                    MemoryStream stream = new();
                    formatter.Serialize(stream, things.ToArray());
                    returningvalue = new byte[stream.ToArray().Length]; // hold?
                    returningvalue = stream.ToArray();

                    //GZipStream comp = new(stream, CompressionLevel.Optimal);
                    //comp.Write(returningvalue, 0, stream.ToArray().Length);

                    //stream.Close(); comp.Close();


                    return (returningvalue, returningvalue.Length);
                }
                catch (Exception e)
                {
                    throw new Lamentation(0x12, e.Message);
                }
            }

            internal static void Experience(byte[] data, int length)
            {
                if (data.Length == 0 | data is null) return;

                try
                {
                    //byte[] things = new byte[length];

                    MemoryStream mem = new(data);
                    //GZipStream decmp = new(mem, CompressionMode.Decompress);


                    //decmp.Read(things, 0, length);

                    XmlSerializer formatter = new(typeof(MalleableInst[]));
                    MalleableInst[] othings = formatter.Deserialize(mem) as MalleableInst[];
                    foreach (MalleableInst malleableInst in othings) CurrentInstructions.Add(malleableInst.Index, malleableInst.Inst);
                }
                catch (Exception e)
                {
                    throw new Lamentation(0x13, e.Message);
                }
            }

            internal static void Publish((byte[], int) contents, string path, string name)
            {
                try
                {
                    using BinaryWriter pen = new(new FileStream(path, FileMode.Create));
                    pen.Write(name); // the name of the programme
                    pen.Write(contents.Item2); // full size
                    pen.Write(contents.Item1.Length); // the compressed size
                    pen.Write(contents.Item1); // the thing itself
                }
                catch (Exception e)
                {
                    throw new Lamentation(0x10, e.Message);
                }
            }

            internal static void Read(string path, out string progname, out (byte[], int) contents)
            {
                try
                {
                    using BinaryReader lectern = new(new FileStream(path, FileMode.Open));
                    progname = lectern.ReadString();
                    int length = lectern.ReadInt32();
                    int thingsize = lectern.ReadInt32();
                    byte[] content = lectern.ReadBytes(thingsize);

                    contents = (content, length);
                }
                catch (FileNotFoundException)
                {
                    throw new Lamentation(0x11, path);
                }
                catch (Exception e)
                {
                    throw new Lamentation(0x10, e.Message);
                }
            }
        }

        public static Dictionary<int, Action<string>> CurrentActions = new();
        public static Dictionary<int, Instruction> CurrentInstructions = new();
        public static List<Statement> CurrentStatements = new();

        public static void Execute()
        {
            foreach (KeyValuePair<int, Instruction> state in CurrentInstructions) state.Value.Invoke();
        }
    }
}