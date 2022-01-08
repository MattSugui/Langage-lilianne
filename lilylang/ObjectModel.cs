namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// The current collection of objects.
    /// </summary>
    public static Stack<FELObject> CurrentObjects;

    /// <summary>
    /// The current X register.
    /// </summary>
    public static int CurrentObjectX;

    /// <summary>
    /// The current Y register.
    /// </summary>
    public static int CurrentObjectY;

    /// <summary>
    /// The current accumulator.
    /// </summary>
    public static int CurrentObjectA;

    public static partial class Actualiser
    {
        
    }
}



/// <summary>
/// Provides the implementation and methods for the object model.
/// </summary>
public static class ObjectModel
{
    /// <summary>
    /// A classic. This provides an ID on an object and allows manipulation to it.
    /// </summary>
    public record FELObject(int Address, string Name, object Value);

    /// <summary>
    /// later.
    /// </summary>
    public struct FELIntegralType
    {

    }
}