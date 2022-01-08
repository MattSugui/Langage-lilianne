using System.Xml.Schema;
using System.Xml;

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New;
public static partial class Interpreter
{
    public static partial class Actualiser
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
                if (CurrentActions.ContainsKey(AssociatedStatement.AssociatedAction))
                {
                    List<object> things = new();
                    foreach (int pointer in AssociatedFruit.AssociatedSentence.PointersToValues)
                        things.Add(AssociatedFruit.Value[pointer].Trim('"'));
                    CurrentActions[AssociatedStatement.AssociatedAction].GetMethodInfo().Invoke(this, things.ToArray());
                }
                else if (AssociatedFruit.AssociatedSentence.Code == -1) return; // do nothing
                else throw new Lamentation(0xe, AssociatedStatement.AssociatedAction.ToString());
            }
        }

        /// <summary>
        /// A version of the above <see cref="Instruction"/> type for XML serialisation.
        /// </summary>
        /// <remarks>
        /// However, since there is no way to guess the source <see cref="Token"/> or <see cref="SentenceStructure"/>
        /// with simply only an array of 32-bit integers and two strings,
        /// this is pretty much the end result of XML-based programme compilation and there is no turning back. If not
        /// using this serialisation method, the resulting XML file will be significantly bigger but
        /// will be reverse-engineerable.
        /// <br/>
        /// When the Coco preprocessor statement <c>Option Publish Strict</c> is present, this type will be used.
        /// </remarks>
        public class SerialisableInstruction : IXmlSerializable
        {
            /// <summary>
            /// The indices in the statement where the operation should get the parameters from.
            /// </summary>
            public int[] ParameterIndices;

            /// <summary>
            /// The statement itself.
            /// </summary>
            public string[] Statement;

            /// <summary>
            /// The name of the operation.
            /// </summary>
            public string Operation;

            public XmlSchema GetSchema() => null;

            public void ReadXml(XmlReader reader)
            {
                throw new NotImplementedException();
            }

            public void WriteXml(XmlWriter writer)
            {
                writer.WriteStartElement("inst");
                string csv = "";
                foreach (int index in ParameterIndices) csv += index.ToString() + ",";
                csv = csv.TrimEnd(',');
                writer.WriteAttributeString("indices", "");
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

                //MemoryStream newone = new();
                //GZipStream comp = new(stream, CompressionLevel.Optimal);
                //stream.CopyTo(comp);
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
                byte[] things = new byte[length];

                MemoryStream mem = new(data);
                //GZipStream decmp = new(mem, CompressionMode.Decompress);


                //decmp.Read(things, 0, length);

                //mem = new(things);

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

        internal static void Compress(string path)
        {

        }
    }

    public static Dictionary<int, Delegate> CurrentActions = new();
    public static Dictionary<int, Instruction> CurrentInstructions = new();
    public static List<Statement> CurrentStatements = new();

    public static void Execute()
    {
        foreach (KeyValuePair<int, Instruction> state in CurrentInstructions) state.Value.Invoke();
    }
}
