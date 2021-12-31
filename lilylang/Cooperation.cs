using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.IO.MemoryMappedFiles;
using System.Diagnostics;

namespace fonder.Lilian.New
{
    /// <summary>
    /// Interprocess communication between Lilian and Coco.
    /// </summary>
    public static class Cooperation
    {
        public static void Handshake()
        {
            Console.WriteLine("Initialising the preprocessor");

            // bool = 1 B
            // sbyte = 127 B
            // byte = 255 B
            // short = 32 kB
            // ushort = 66 kB
            // int = 2 GB
            // uint = 4 GB
            // long = 8 EB
            // ulong = 16 EB
            // bruh how tf does a mapped file reach 8 exabytes???
            
            using (MemoryMappedFile Commons = MemoryMappedFile.CreateNew("lilycoco", 1024)) // 66 kB??
            {
                bool cree;
                Mutex CommonsMutex = new(true, "lilmutex", out cree);
                using (MemoryMappedViewStream stream = Commons.CreateViewStream())
                {
                    BinaryWriter pen = new(stream);
                    pen.Write(true);
                }
                CommonsMutex.ReleaseMutex();
                
                Process.Start("cocoproc.exe", "-p");
                
                CommonsMutex.WaitOne();
                using (MemoryMappedViewStream stream = Commons.CreateViewStream())
                {
                    BinaryReader glass = new(stream);
                    glass.ReadBoolean(); // discard
                    if (!glass.ReadBoolean()) return; // fail!
                }

                Console.WriteLine("Hello there, Coco, teehee! Now, let's start!");
                CommonsMutex.ReleaseMutex();
            }
        }
    
        public static void Deal()
        {
            using (FileStream stream = File.Create("lilycoco.tmp"))
            {
                using BinaryWriter pen = new(stream);
                pen.Write("Hey, Coco! Are you there?");
                Console.WriteLine("LILIAN: Hey, Coco! Are you there?");
            }

            using FileSystemWatcher watcher = new(Directory.GetCurrentDirectory());
            watcher.NotifyFilter = NotifyFilters.LastWrite;
            watcher.Filter = "lilycoco.tmp";
            watcher.Changed += NotifyChanges; // literally set up the trap

            Process.Start("cocoproc.exe", "-p");
        }

        internal static void NotifyChanges(object sender, FileSystemEventArgs e)
        {
            using (FileStream stream = File.Open("lilycoco.tmp", FileMode.Open))
            {
                using (BinaryReader glass = new(stream))
                {
                    string vibecheck = glass.ReadString();
                    if (vibecheck == "Yes! I'm here, bitch!")
                    {
                        Console.WriteLine("tested, it works");
                    }
                }
            }
        }
    }
}