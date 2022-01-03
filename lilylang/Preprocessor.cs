using System.Xml.Serialization;

namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// Coco interop for preproc
    /// </summary>
    public static class Preprocessor
    {
        public static void FeedingTime(string data)
        {
            try
            {
                Clear();
                Process coco = Process.Start(new ProcessStartInfo() { FileName = "cocoproc.exe", Arguments = $"\"{data}\" -l", RedirectStandardOutput = true, });
                coco.EnableRaisingEvents = true;
                coco.OutputDataReceived += ReceiveOut;
                coco.BeginOutputReadLine();

                coco.WaitForExit();
                Thread.Sleep(5000); // display output for a while
                Clear(); // exit

                if (File.Exists("cocoadd.tmp"))
                {
                    using BinaryReader lectern = new(new FileStream("cocoadd.tmp", FileMode.Open));
                    int length = lectern.ReadInt32();
                    byte[] content = lectern.ReadBytes(length);

                    using MemoryStream mem = new(content);
                    XmlSerializer formatter = new(typeof(ProposedMod[]));
                    ProposedMod[] othings = formatter.Deserialize(mem) as ProposedMod[];
                    foreach (ProposedMod o in othings)
                    {
                        switch (o.WhatToDo)
                        {
                            case 1:
                                CurrentFile.Insert(0, o.ProposedStatement); break;
                            default:
                                throw new InvalidDataException("Invalid action.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Lamentation(0x15, e.Message);
            }
        }

        private static void ReceiveOut(object sender, DataReceivedEventArgs e) => WriteLine(e.Data);

        [Serializable]
        public class ProposedMod
        {
            public string ProposedStatement;
            public int WhatToDo;
        }
    }
}
