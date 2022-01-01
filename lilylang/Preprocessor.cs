namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// Coco interop for preproc
    /// </summary>
    public static class Preprocessor
    {
        public static void FeedingTime()
        {
            try
            {
                Process.Start("cocoproc.exe", "");
            }
            catch (Exception e)
            {
                throw new Lamentation(0x15, e.Message);
            }
        }
    }
}
