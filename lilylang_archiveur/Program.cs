using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;

using static System.Console;

namespace fonder.Lilian.New.Stuffer
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            WriteLine(
                "Fonder Lilian Language Environment: Archiver module\n" +
                "Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", 2021\n"
            );

            //File.Create("testbin.lfb"); /* in case */

            try
            {
                using (BinaryWriter quill = new(File.Open("testbin.lfb", FileMode.Create)))
                {
                    /* write the file */
                    quill.Write(10); WriteLine("Writing header...\n");
                    quill.Write("testForItems");
                    for (int i = 0; i < 10; i++)
                    {
                        SetCursorPosition(0, CursorTop - 1);
                        quill.Write("bruh" + i.ToString());
                        WriteLine("Writing item " + i + "of 10...");
                    }
                }
            }
            catch (Exception e)
            {
                Error.WriteLine("There was a snake in your boot. " + e.Message);
            }

            try
            {
                int amount;
                if (File.Exists("testbin.lfb"))
                {
                    using (BinaryReader lectern = new(File.Open("testbin.lfb", FileMode.Open)))
                    {
                        /* read the file */
                        amount = lectern.ReadInt32();
                        WriteLine($"Testing file: \"{lectern.ReadString()}\"");
                        for (int i = 0; i < amount; i++) WriteLine(lectern.ReadString());
                    }
                }
            }
            catch (Exception e)
            {
                Error.WriteLine("You hit the librarian villager. " + e.Message);
            }
        }
    }

    public static class Common
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
