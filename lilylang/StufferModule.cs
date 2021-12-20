using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using static fonder.Lilian.New.Interpreter;
using static System.Console;

namespace fonder.Lilian.New
{
    public static partial class Interpreter
    {
        public static void Stuff(byte[] thing, string path = "package.lfb", string title = "")
        {
            try
            {
                using (BinaryWriter quill = new(File.Open(path, FileMode.Create)))
                {
                    /* write the file */
                    WriteLine("Writing header...\n");
                    quill.Write(title);
                    quill.Write(thing.Length);
                    quill.Write(thing);
                }
            }
            catch (Exception e)
            {
                Error.WriteLine("There was a snake in your boot. " + e.Message);
            }

            WriteLine("Packaging successfull");
        }

        public static byte[] Unbox(string path)
        {
            int amount;
            byte[] returningvalue = null;
            try
            {
                if (File.Exists(path))
                {
                    using (BinaryReader lectern = new(File.Open(path, FileMode.Open)))
                    {
                        /* read the file */
                        WriteLine($"Testing library: \"{lectern.ReadString()}\"");
                        amount = lectern.ReadInt32();
                        returningvalue = lectern.ReadBytes(amount);
                    }
                }
                else throw new FileNotFoundException();
            }
            catch (Exception e)
            {
                Error.WriteLine("You hit the librarian villager. " + e.Message);
            }

            return returningvalue;

        }
    }
}
