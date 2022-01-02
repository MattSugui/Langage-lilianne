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
                
            }
            catch (Exception e)
            {
                throw new Lamentation(0x15, e.Message);
            }
        }

        private static void ReceiveOut(object sender, DataReceivedEventArgs e) => WriteLine(e.Data);
    }
}
