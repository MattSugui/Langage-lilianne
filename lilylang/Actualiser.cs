namespace fonder.Lilian.New;
public static partial class Interpreter
{
    /// <summary>
    /// Runs the currently-loaded binary.
    /// </summary>
    public static void Execute()
    {
        CurrentPointedEffect = 0;
        while (CurrentPointedEffect < CurrentEffects.Count)
            CurrentEffects[CurrentPointedEffect].Invoke();
    }
}