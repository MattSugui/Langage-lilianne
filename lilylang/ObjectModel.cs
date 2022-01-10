﻿#nullable enable // oh boy here we go, we in sport mode now

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
    /// The current instruction.
    /// </summary>
    public static int CurrentPointedEffect;

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
        public static List<FELAction> CurrentEffects = new();

        /// <summary>
        /// A form of delegate??? but not quite?? for use with the stack.
        /// </summary>
        /// <param name="ActionType">What to do.</param>
        /// <param name="Value">The value. Only valid for the Push, Load, Store and branching operations.</param>
        public record struct FELAction(FELActionType ActionType, dynamic Value = null)
        {
            /// <summary>
            /// Invokes the action.
            /// </summary>
            public void Invoke()
            {
                try
                {
                    switch (ActionType)
                    {
                        case FELActionType.nop:
                        case FELActionType.str:
                        case FELActionType.ste:
                        case FELActionType.nus:
                        case FELActionType.nue:
                            goto GoForward;
                        case FELActionType.push:
                            if (Value is not null) CurrentObjects.Push(Value); // nah do nothing instead of crying atm
                            goto GoForward;
                        case FELActionType.pop:
                            CurrentObjects.Pop();
                            goto GoForward;
                        case FELActionType.print:
                            WriteLine(CurrentObjects.Peek());
                            goto GoForward;
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
                            goto GoForward;
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
                            goto GoForward;
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
                            goto GoForward;
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
                            goto GoForward;
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
                            goto GoForward;
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
                            goto GoForward;
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
                            goto GoForward;
                        case FELActionType.and:
                            try
                            {
                                dynamic a = CurrentObjects.Pop();
                                dynamic b = CurrentObjects.Pop();
                                CurrentObjects.Push(a & b); // rely on implementation...
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.or:
                            try
                            {
                                dynamic a = CurrentObjects.Pop();
                                dynamic b = CurrentObjects.Pop();
                                CurrentObjects.Push(a | b); // rely on implementation...
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.xor:
                            try
                            {
                                dynamic a = CurrentObjects.Pop();
                                dynamic b = CurrentObjects.Pop();
                                CurrentObjects.Push(a ^ b); // rely on implementation...
                            }
                            catch (Exception ex)
                            {
                                throw new Lamentation(0x17, ex.Message);
                            }
                            goto GoForward;
                        case FELActionType.store:
                            dynamic x = CurrentObjects.Pop();
                            if (Value is string @string) CurrentStore.Add(new(CurrentStore.Count, @string, x));
                            else if (Value is int number) CurrentStore.Add(new(number, "", x));
                            goto GoForward;
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
                                        int => name.ToString(),
                                    }
                                ));
                            goto GoForward;
                        case FELActionType.beq:
                            dynamic z = Value!;
                            if (z is int index)
                            {
                                if (index < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        dynamic var2 = CurrentObjects.Pop();
                                        if (var1 == var2) CurrentPointedEffect = index; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index.ToString());
                            }
                            else throw new Lamentation(0x19, z.ToString());
                            return;
                        case FELActionType.bne:
                            dynamic bne = Value!;
                            if (bne is int index2)
                            {
                                if (index2 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        dynamic var2 = CurrentObjects.Pop();
                                        if (var1 != var2) CurrentPointedEffect = index2; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index2.ToString());
                            }
                            else throw new Lamentation(0x19, bne.ToString());
                            return;
                        case FELActionType.bgt:
                            dynamic z3 = Value!;
                            if (z3 is int index3)
                            {
                                if (index3 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        dynamic var2 = CurrentObjects.Pop();
                                        if (var1 > var2) CurrentPointedEffect = index3; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index3.ToString());
                            }
                            else throw new Lamentation(0x19, z3.ToString());
                            return;
                        case FELActionType.bge:
                            dynamic z4 = Value!;
                            if (z4 is int index4)
                            {
                                if (index4 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        dynamic var2 = CurrentObjects.Pop();
                                        if (var1 >= var2) CurrentPointedEffect = index4; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index4.ToString());
                            }
                            else throw new Lamentation(0x19, z4.ToString());
                            return;
                        case FELActionType.blt:
                            dynamic z5 = Value!;
                            if (z5 is int index5)
                            {
                                if (index5 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        dynamic var2 = CurrentObjects.Pop();
                                        if (var1 < var2) CurrentPointedEffect = index5; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index5.ToString());
                            }
                            else throw new Lamentation(0x19, z5.ToString());
                            return;
                        case FELActionType.ble:
                            dynamic z6 = Value!;
                            if (z6 is int index6)
                            {
                                if (index6 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        dynamic var2 = CurrentObjects.Pop();
                                        if (var1 == var2) CurrentPointedEffect = index6; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index6.ToString());
                            }
                            else throw new Lamentation(0x19, z6.ToString());
                            return;
                        case FELActionType.btr:
                            dynamic z7 = Value!;
                            if (z7 is int index7)
                            {
                                if (index7 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        if (var1) CurrentPointedEffect = index7; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index7.ToString());
                            }
                            else throw new Lamentation(0x19, z7.ToString());
                            return;
                        case FELActionType.bfl:
                            dynamic z8 = Value!;
                            if (z8 is int index8)
                            {
                                if (index8 < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        if (!var1) CurrentPointedEffect = index8; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, index8.ToString());
                            }
                            else throw new Lamentation(0x19, z8.ToString());
                            return;
                        case FELActionType.@goto:
                            dynamic z9 = Value!;
                            if (z9 is int index9)
                            {
                                if (index9 < CurrentEffects.Count) CurrentPointedEffect = index9;
                                else throw new Lamentation(0x20, index9.ToString());
                            }
                            else throw new Lamentation(0x19, z9.ToString());
                            return;
                        default: throw new Lamentation(0x16, ActionType.ToString());
                        case FELActionType.bsa:
                            dynamic zA = Value!;
                            if (zA is int indexA)
                            {
                                if (indexA < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        dynamic var2 = CurrentObjects.Pop();
                                        if (var1 && var2) CurrentPointedEffect = indexA; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, indexA.ToString());
                            }
                            else throw new Lamentation(0x19, zA.ToString());
                            return;
                        case FELActionType.bso:
                            dynamic zB = Value!;
                            if (zB is int indexB)
                            {
                                if (indexB < CurrentEffects.Count)
                                {
                                    try
                                    {
                                        dynamic var1 = CurrentObjects.Pop();
                                        dynamic var2 = CurrentObjects.Pop();
                                        if (var1 || var2) CurrentPointedEffect = indexB; else goto GoForward;
                                    }
                                    catch (Exception ex)
                                    {
                                        throw new Lamentation(0x17, ex.Message);
                                    }
                                }
                                else throw new Lamentation(0x20, indexB.ToString());
                            }
                            else throw new Lamentation(0x19, zB.ToString());
                            return;
                        case FELActionType.end:
                            Environment.Exit(0);
                            return;
                        case FELActionType.take:
                            Write("The programme needs some input > ");
                            string? asked = ReadLine();
                            dynamic content;
                            if (!string.IsNullOrEmpty(asked)) content = asked!; else goto GoForward;
                            // automatic conversion
                            string prim = (string)content;
                            if (bool.TryParse(prim, out bool val1)) content = val1;
                            else if (sbyte.TryParse(prim, out sbyte val2)) content = val2;
                            else if (byte.TryParse(prim, out byte val3)) content = val3;
                            else if (short.TryParse(prim, out short val4)) content = val4;
                            else if (ushort.TryParse(prim, out ushort val5)) content = val5;
                            else if (int.TryParse(prim, out int val6)) content = val6;
                            else if (uint.TryParse(prim, out uint val7)) content = val7;
                            else if (long.TryParse(prim, out long val8)) content = val8;
                            else if (ulong.TryParse(prim, out ulong val9)) content = val9;
                            else if (Half.TryParse(prim, out Half valA)) content = valA;
                            else if (float.TryParse(prim, out float valB)) content = valB;
                            else if (double.TryParse(prim, out double valC)) content = valC;
                            else if (decimal.TryParse(prim, out decimal valD)) content = valD;
                            else if (char.TryParse(prim, out char valE)) content = valE;
                            CurrentObjects.Push(content!);
                            goto GoForward;
                        case FELActionType.ask:
                            Write("The programme needs some input > ");
                            string? asked2 = ReadLine();
                            string content2 = string.Empty;
                            if (!string.IsNullOrEmpty(asked2)) content2 = asked2!;
                            CurrentObjects.Push(content2);
                            goto GoForward;
                        case FELActionType.narrow:
                            dynamic narrowand = CurrentObjects.Pop();
                            unchecked
                            {
                                dynamic result1 = narrowand switch
                                {
                                    string => throw new Lamentation(0x24, narrowand.ToString()),
                                    bool => throw new Lamentation(0x22, narrowand.ToString()),
                                    sbyte => narrowand > 0 ? 1 : 0,
                                    byte => (sbyte)narrowand,
                                    short => (byte)narrowand,
                                    ushort => (short)narrowand,
                                    int => (ushort)narrowand,
                                    uint => (int)narrowand,
                                    long => (uint)narrowand,
                                    ulong => (long)narrowand,
                                    Half => throw new Lamentation(0x22, narrowand.ToString()),
                                    float => (Half)narrowand,
                                    double => (float)narrowand,
                                    decimal => (double)narrowand,
                                    char => throw new Lamentation(0x26, narrowand.ToString()),
                                    _ => throw new Lamentation(0x28, narrowand.ToString()),
                                };
                                CurrentObjects.Push(result1);
                            }
                            goto GoForward;
                        case FELActionType.widen:
                            dynamic widand = CurrentObjects.Pop();
                            unchecked
                            {
                                dynamic result1 = widand switch
                                {
                                    string => throw new Lamentation(0x25, widand.ToString()),
                                    bool => (sbyte)widand,
                                    sbyte => (byte)widand,
                                    byte => (short)widand,
                                    short => (ushort)widand,
                                    ushort => (int)widand,
                                    int => (uint)widand,
                                    uint => (long)widand,
                                    long => (ulong)widand,
                                    ulong => throw new Lamentation(0x23, widand.ToString()),
                                    Half => (float)widand,
                                    float => (double)widand,
                                    double => (decimal)widand,
                                    decimal => throw new Lamentation(0x23, widand.ToString()),
                                    char => throw new Lamentation(0x27, widand.ToString()),
                                    _ => throw new Lamentation(0x29, widand.ToString()),
                                };
                                CurrentObjects.Push(result1);
                            }
                            goto GoForward;
                    }
                }
                catch (Lamentation cry)
                {
                    WriteLine(cry.ToString());
                }
                catch (Exception ex)
                {
                    try
                    {
                        throw new Lamentation(0x17, ex.Message); // mould
                    }
                    catch (Lamentation cry)
                    {
                        WriteLine(cry.ToString());
                    }
                }
            GoForward: CurrentPointedEffect++;
            }
        }

        public static void CreateBinary()
        {
            using FileStream stream = File.Create("test.lsa");
            using BinaryWriter writer = new(stream);

            foreach (FELAction act in CurrentEffects)
            {
                if (act.ActionType == FELActionType.push ||
                    act.ActionType == FELActionType.store ||
                    act.ActionType == FELActionType.load ||
                    (act.ActionType >= FELActionType.beq &&
                    act.ActionType <= FELActionType.bso))
                {
                    writer.Write((byte)act.ActionType);
                    byte marker = act.Value! switch
                    {
                        string => 11,
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
                        _ => throw new Lamentation($"Marker seeks a(n) {act.Value?.GetType()}")
                    };

                    writer.Write(marker);
                    writer.Write(act.Value!);
                    //writer.Write((byte)14);
                }
                else writer.Write((byte)act.ActionType); // only one byte is needed
            }
        }

        public static void LoadBinary()
        {
            using FileStream stream = File.OpenRead("test.lsa");
            using BinaryReader reader = new(stream);

            reader.BaseStream.Position = 0; // bruh stay there!!!

            while (reader.PeekChar() != -1)
            {
                byte opcode = reader.ReadByte();
                dynamic thing = null;
                if (opcode == 1 || opcode == 29 || opcode == 30 || (opcode >= 34 && opcode <= 44))
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
                CurrentEffects.Add(new((FELActionType)opcode, thing)); 
            }
        }

        /// <summary>
        /// What to do. For operation correctness some marker bytes (11 and 15-28) are also included in the table
        /// even though they don't do anything.
        /// </summary>
        public enum FELActionType: byte
        {
            /// <summary>
            /// No operation
            /// </summary>
            nop,

            /// <summary>
            /// Push to stack
            /// </summary>
            push,

            /// <summary>
            /// Pop from stack
            /// </summary>
            pop,

            /// <summary>
            /// Print top item
            /// </summary>
            print,

            /// <summary>
            /// Add two values on top
            /// </summary>
            add,

            /// <summary>
            /// Subtract with two values on top
            /// </summary>
            sub,

            /// <summary>
            /// Multiply with two values on top
            /// </summary>
            mul,

            /// <summary>
            /// Divide with two values on top
            /// </summary>
            div,

            /// <summary>
            /// Divide with two values on top, pop these then return the remainder
            /// </summary>
            mod,

            /// <summary>
            /// Shift a value on top to the left
            /// </summary>
            lst,

            /// <summary>
            /// Shift a value on top to the right
            /// </summary>
            rst,

            /// <summary>
            /// String byte marker
            /// </summary>
            str,

            /// <summary>
            /// Terminates a string
            /// </summary>
            [Obsolete("The language does not rely on a terminator byte anymore")]
            ste,

            /// <summary>
            /// Starts an integral value
            /// </summary>
            [Obsolete("This is bullshit")]
            nus,

            /// <summary>
            /// Terminates an integral value
            /// </summary>
            [Obsolete("This is bullshit")]
            nue,

            /// <summary>
            /// Bool byte marker
            /// </summary>
            @bool,

            /// <summary>
            /// Signed byte byte marker
            /// </summary>
            @sbyte,

            /// <summary>
            /// Byte byte marker
            /// </summary>
            @byte,

            /// <summary>
            /// Short byte marker
            /// </summary>
            @short,

            /// <summary>
            /// Unsigned short byte marker
            /// </summary>
            @ushort,

            /// <summary>
            /// Int byte marker
            /// </summary>
            @int,

            /// <summary>
            /// Unsigned int byte marker
            /// </summary>
            @uint,

            /// <summary>
            /// Long byte marker
            /// </summary>
            @long,

            /// <summary>
            /// Unsigned long byte marker
            /// </summary>
            @ulong,

            /// <summary>
            /// Half byte marker
            /// </summary>
            half,

            /// <summary>
            /// Single byte marker
            /// </summary>
            @float,

            /// <summary>
            /// Double byte marker
            /// </summary>
            @double,

            /// <summary>
            /// "Quadruple" byte marker
            /// </summary>
            @decimal,

            /// <summary>
            /// Character byte marker
            /// </summary>
            @char,

            /// <summary>
            /// Store the value on top to a place
            /// </summary>
            store,

            /// <summary>
            /// Loads a value from a place on top
            /// </summary>
            load,

            /// <summary>
            /// Bitwise AND
            /// </summary>
            and,

            /// <summary>
            /// Bitwise OR
            /// </summary>
            or,

            /// <summary>
            /// Bitwise XOR
            /// </summary>
            xor,

            /// <summary>
            /// <see langword="if"/> ==
            /// </summary>
            beq,

            /// <summary>
            /// <see langword="if"/> !=
            /// </summary>
            bne,

            /// <summary>
            /// <see langword="if"/> &gt;
            /// </summary>
            bgt,

            /// <summary>
            /// <see langword="if"/> &gt;=
            /// </summary>
            bge,

            /// <summary>
            /// <see langword="if"/> &lt;
            /// </summary>
            blt,

            /// <summary>
            /// <see langword="if"/> &lt;=
            /// </summary>
            ble,

            /// <summary>
            /// <see langword="goto"/>
            /// </summary>
            @goto,

            /// <summary>
            /// <see langword="if"/> <see langword="true"/>
            /// </summary>
            btr,

            /// <summary>
            /// <see langword="if"/> <see langword="false"/>
            /// </summary>
            bfl,

            /// <summary>
            /// <see langword="if"/> <see langword="true"/> <see langword="and"/> <see langword="true"/>
            /// </summary>
            bsa,

            /// <summary>
            /// <see langword="if"/> <see langword="true"/> <see langword="or"/> <see langword="true"/>
            /// </summary>
            bso,

            /// <summary>
            /// <see cref="Environment.Exit(int)"/> (<see langword="End"/> in Visual Basic.)
            /// </summary>
            end,

            /// <summary>
            /// Ask for a value. If convenient, Lilian will immediately convert the value to an appropriate type.
            /// </summary>
            take,

            /// <summary>
            /// Ask for a value. This will never automatically convert to other types.
            /// </summary>
            ask,

            /// <summary>
            /// Shrink the value on top to its nearest smaller type.
            /// </summary>
            narrow,

            /// <summary>
            /// Grow the value on top to its nearest larger type.
            /// </summary>
            widen
        }


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