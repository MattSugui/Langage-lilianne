namespace fonder.Adelaide;

public static partial class Main
{
    /// <summary>
    /// What to do. For operation correctness some marker bytes (11, 15-28 &amp; 73) are also included in the table
    /// even though they don't do anything.
    /// </summary>
    public enum FELActionType : byte
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
        /// Goes to a location in the stream but it saves the current position and is hence some form of subroutine.
        /// (<see langword="Call"/> in Visual Basic)
        /// </summary>
        call,

        /// <summary>
        /// <see langword="return"/>
        /// </summary>
        @return,

        /// <summary>
        /// This action is just a label in code. Any action associated with this code will be removed from the binary and turned into
        /// a no-op.
        /// </summary>
        label,

        /// <summary>
        /// This action will be turned into a standard goto if the label is found later on.
        /// </summary>
        gotolabel,

        /// <summary>
        /// A context-sensitive compiler flag byte marker.
        /// </summary>
        compflag,
    }

    public struct FELAction
    {
        public FELAction(FELActionType act, dynamic? val = null, bool flagged = false)
        {
            Type = act;
            Value = val;
            Flag = flagged;
        }

        public FELActionType Type { get; } = FELActionType.nop;

        public bool Flag { get; } = false;

        public dynamic? Value { get; }
    }

    public record class FELObject(string Name, dynamic? Value);

    public class Frame
    {
        public Stack<FELObject> ObjectStack { get; set; } = new();
    }
}