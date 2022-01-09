#nullable enable

namespace fonder.Lilian.New;

public static partial class Interpreter
{
    /// <summary>
    /// The current collection of objects.
    /// </summary>
    public static Stack<object> CurrentObjects = new();

    /// <summary>
    /// The current saved collection of objects.
    /// </summary>
    public static List<FELObject> CurrentStore = new();

    /// <summary>
    /// The stack pointer.
    /// </summary>
    public static int CurrentPointedObject;

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
        [Obsolete("Use CurrentEffects")]
        public static Queue<Delegate> CurrentActions = new();

        /// <summary>
        /// The current list of actions.
        /// </summary>
        /// <remarks>
        /// <em>I did not choose the name, Intellicode/Pilot did. This will be a meme from now on.</em>
        /// </remarks>
        public static Queue<FELAction> CurrentEffects = new();

        /// <summary>
        /// A form of delegate??? but not quite?? for use with the stack.
        /// </summary>
        /// <param name="ActionType">What to do.</param>
        /// <param name="Value">The value. Only valid for the Push operation.</param>
        public record struct FELAction(FELActionType ActionType, object? Value = null)
        {
            public void Invoke()
            {
                switch (ActionType)
                {
                    case FELActionType.nop:
                    case FELActionType.str:
                    case FELActionType.ste:
                    case FELActionType.nus:
                    case FELActionType.nue:
                        break;
                    case FELActionType.push:
                        if (Value is not null) CurrentObjects.Push(Value); // nah do nothing instead of crying atm
                        break;
                    case FELActionType.pop:
                        CurrentObjects.Pop();
                        break;
                    case FELActionType.print:
                        WriteLine(CurrentObjects.Peek());
                        break;
                    case FELActionType.add:
                        try
                        {
                            dynamic a = CurrentObjects.Pop();
                            dynamic b = CurrentObjects.Pop();
                            CurrentObjects.Push(a + b); // rely on implementation...
                        }
                        catch (Exception ex)
                        {
                            throw new Lamentation(0x17, ex.Message);
                        }
                        break;
                    case FELActionType.sub:
                        try
                        {
                            dynamic a = CurrentObjects.Pop();
                            dynamic b = CurrentObjects.Pop();
                            CurrentObjects.Push(a - b); // rely on implementation...
                        }
                        catch (Exception ex)
                        {
                            throw new Lamentation(0x17, ex.Message);
                        }
                        break;
                    case FELActionType.mul:
                        try
                        {
                            dynamic a = CurrentObjects.Pop();
                            dynamic b = CurrentObjects.Pop();
                            CurrentObjects.Push(a * b); // rely on implementation...
                        }
                        catch (Exception ex)
                        {
                            throw new Lamentation(0x17, ex.Message);
                        }
                        break;
                    case FELActionType.div:
                        try
                        {
                            dynamic a = CurrentObjects.Pop();
                            dynamic b = CurrentObjects.Pop();
                            CurrentObjects.Push(a / b); // rely on implementation...
                        }
                        catch (Exception ex)
                        {
                            throw new Lamentation(0x17, ex.Message);
                        }
                        break;
                    case FELActionType.mod:
                        try
                        {
                            dynamic a = CurrentObjects.Pop();
                            dynamic b = CurrentObjects.Pop();
                            CurrentObjects.Push(a % b); // rely on implementation...
                        }
                        catch (Exception ex)
                        {
                            throw new Lamentation(0x17, ex.Message);
                        }
                        break;
                    case FELActionType.lst:
                        try
                        {
                            dynamic a = CurrentObjects.Pop();
                            dynamic b = CurrentObjects.Pop();
                            CurrentObjects.Push(a << b); // rely on implementation...
                        }
                        catch (Exception ex)
                        {
                            throw new Lamentation(0x17, ex.Message);
                        }
                        break;
                    case FELActionType.rst:
                        try
                        {
                            dynamic a = CurrentObjects.Pop();
                            dynamic b = CurrentObjects.Pop();
                            CurrentObjects.Push(a >> b); // rely on implementation...
                        }
                        catch (Exception ex)
                        {
                            throw new Lamentation(0x17, ex.Message);
                        }
                        break;
                    case FELActionType.store:
                        dynamic x = CurrentObjects.Pop();
                        if (Value is string @string) CurrentStore.Add(new(CurrentStore.Count, @string, x));
                        else if (Value is int number) CurrentStore.Add(new(number, "", x));
                        break;
                    case FELActionType.load:
                        dynamic name = Value!;
                        if (
                            (name is string str && CurrentStore.Exists(obj => obj.Name == str)) ||
                            (name is int num && CurrentStore.Exists(obj => obj.Address == num))
                        )
                        {
                            FELObject selected = default;
                            if (name is string strn) selected = CurrentStore.Find(obj => obj.Name == strn);
                            else if (name is int numa) selected = CurrentStore.Find(obj => obj.Address == numa);
                            CurrentObjects.Push(selected.Value);
                            CurrentStore.Remove(selected);
                        }
                        else throw new Lamentation(0x18,
                            (
                                name switch
                                {
                                    string => name,
                                    int => name.ToString("h"),
                                }
                            ));
                        break;
                    default: throw new Lamentation(0x16, ActionType.ToString());
                }
            }
        }

        public static void CreateBinary()
        {
            using FileStream stream = File.Create("test.lsa");
            using BinaryWriter writer = new(stream);

            foreach (FELAction act in CurrentEffects)
            {
                if (act.ActionType == FELActionType.push)
                {
                    writer.Write((byte)act.ActionType);
                    if (act.Value is string @string)
                    {
                        writer.Write((byte)11);
                        writer.Write(@string);
                        //writer.Write((byte)12);
                    }
                    else
                    {
                        byte marker = act.Value! switch
                        {
                            bool => 15,
                            sbyte => 16,
                            byte => 17,
                            short => 18,
                            ushort => 19,
                            int => 20,
                            uint => 21,
                            long => 22,
                            ulong => 23,
                            Half => 24,
                            float => 25,
                            double => 26,
                            decimal => 27,
                            char => 28,
                            _ => throw new Lamentation()
                        };

                        writer.Write(marker);
                        writer.Write((int)act.Value!);
                        //writer.Write((byte)14);
                    }
                }
                else writer.Write((byte)act.ActionType); // only one byte is needed
            }
        }

        public static void LoadBinary()
        {
            using FileStream stream = File.OpenRead("test.lsa");
            using BinaryReader reader = new(stream);

            while (reader.PeekChar() != -1)
            {
                byte opcode = reader.ReadByte();
                dynamic thing = null;
                if (opcode == (byte)FELActionType.push)
                {
                    byte marker = reader.ReadByte();
                    switch (marker)
                    {
                        case 11:
                            thing = reader.ReadString();
                            break;
                        case 15:
                            thing = reader.ReadBoolean();
                            break;
                        case 16:
                            thing = reader.ReadSByte();
                            break;
                        case 17:
                            thing = reader.ReadByte();
                            break;
                        case 18:
                            thing = reader.ReadInt16();
                            break;
                        case 19:
                            thing = reader.ReadUInt16();
                            break;
                        case 20:
                            thing = reader.ReadInt32();
                            break;
                        case 21:
                            thing = reader.ReadUInt32();
                            break;
                        case 22:
                            thing = reader.ReadInt64();
                            break;
                        case 23:
                            thing = reader.ReadUInt64();
                            break;
                        case 24:
                            thing = reader.ReadHalf();
                            break;
                        case 25:
                            thing = reader.ReadSingle();
                            break;
                        case 26:
                            thing = reader.ReadDouble();
                            break;
                        case 27:
                            thing = reader.ReadDecimal();
                            break;
                        case 28:
                            thing = reader.ReadChar();
                            break;
                    }
                }
                CurrentEffects.Enqueue(new((FELActionType)opcode, thing)); 
            }
        }

        public enum FELActionType: byte
        {
            nop,
            push,
            pop,
            print,
            add,
            sub,
            mul,
            div,
            mod,
            lst,
            rst,
            str,
            ste,
            nus,
            nue,
            @bool,
            @sbyte,
            @byte,
            @short,
            @ushort,
            @int,
            @uint,
            @long,
            @ulong,
            half,
            @float,
            @double,
            @decimal,
            @char,
            store,
            load,
        }


        #region Method implementations
        /// <summary>
        /// A push operation. Places a value on top of the stack. (Method to be attached to <see cref="PushOperation"/>)
        /// </summary>
        /// <param name="value">The value to push onto the stack.</param>
        public static void Push(object value) => CurrentObjects.Push(value);


        /// <summary>
        /// A pop operation. Removes the value from the top of the stack. (Method to be attached to <see cref="PopOperation"/>)
        /// </summary>
        public static void Pop() => _ = CurrentObjects.Pop();


        /// <summary>
        /// A print operation. Displays the value on top of the stack to the screen. (Method to be attached to <see cref="PrintOperation"/>)
        /// </summary>
        public static void Print() => WriteLine(CurrentObjects.Peek());
        #endregion

        /* example:
         * push 10;
         * push 20;
         * add;
         * pop;
         */
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
    public record struct FELObject(int Address, string Name, object Value);

    /// <summary>
    /// later.
    /// </summary>
    public struct FELIntegralType
    {

    }
}