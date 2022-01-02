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
                Process coco = Process.Start("cocoproc.exe", $"\"{data}\"");
                coco.WaitForExit();
            }
            catch (Exception e)
            {
                throw new Lamentation(0x15, e.Message);
            }
        }
    }
}
