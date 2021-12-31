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
        /// <summary>
        /// The communications table.
        /// </summary>
        /// <remarks>
        /// This mapped file is intentionally out here since it will be utilised until Lilian finishes processing the code with Coco in it.
        /// </remarks>
        public static MemoryMappedFile Commons; // initialise on handshake
        public static bool CooperationStarted;
        
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
            File.Create("lilycoco.tmp");
            Commons = MemoryMappedFile.CreateFromFile("lilycoco.tmp"); // 2 GB??
            Process.Start("cocoproc.exe", "-p");
            Mutex CommonsMutex = new(true, "liliancommune", out _);
            using (MemoryMappedViewStream stream = Commons.CreateViewStream())
            {
                BinaryWriter pen = new(stream);
                pen.Write(true);
            }
            CommonsMutex.ReleaseMutex();
            CommonsMutex.WaitOne();
            
            using (MemoryMappedViewStream stream = Commons.CreateViewStream())
            {
                BinaryReader glass = new(stream);
                glass.ReadBoolean(); // discard
                if (glass.ReadBoolean()) CooperationStarted = true;
            }

            Console.WriteLine("Hello there, Coco, teehee! Now, let's start!");
        }
    }
}