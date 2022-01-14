namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// Indicates that an error has been raised. This is used for branching operations that branch whenever an error occurs.
    /// </summary>
    public static bool ErrorRaised = false;

    /// <summary>
    /// Runs the currently-loaded binary.
    /// </summary>
    public static void Execute()
    {
        CurrentFrame.Add(new());
        CurrentFrameIndex = 0;
        CurrentPointedEffect = 0;

        while (CurrentPointedEffect < CurrentEffects.Count) CurrentEffects[CurrentPointedEffect].Invoke();
    }
}