using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;

using static fonder.Lilian.New.Interpreter;
using static fonder.Lilian.New.Interpreter.Spellbook;
using static fonder.Lilian.New.Interpreter.Actualiser;
using static System.Console;

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New
{
    public static partial class Interpreter
    {
        /*
         * Opcode structure
         * 
         * FFFF,FFFF,FFFF
         * op   od1l od2l
         */

        /// <summary>
        /// The assembler module. This is for creating bytecode programs instead of creating huge XML-based programs.
        /// </summary>
        public static class Assembler
        {
            public abstract class Component
            {

            }

            /// <summary>
            /// A bytecode instruction.
            /// </summary>
            public class Instruction: Component
            {
                /// <summary>
                /// The bytecode.
                /// </summary>
                public Instructions RepByte;

                /// <summary>
                /// The left operand of the equation.
                /// </summary>
                public uint Left;

                /// <summary>
                /// The right operand of the equation.
                /// </summary>
                public uint? Right;
            }

            public class Label: Component
            {

            }

            /// <summary>
            /// The current instruction table that Lilian has.
            /// </summary>
            public enum Instructions: byte
            {
                /// <summary>
                /// No operation
                /// </summary>
                NOP,

                /// <summary>
                /// Break
                /// </summary>
                BRK,

                /// <summary>
                /// Add to X
                /// </summary>
                ADD,

                /// <summary>
                /// Subtract from X
                /// </summary>
                SUB,

                /// <summary>
                /// Multiply by X
                /// </summary>
                MUL,

                /// <summary>
                /// Divide by X
                /// </summary>
                DIV,

                /// <summary>
                /// Divide by X giving remainder
                /// </summary>
                MOD,

                /// <summary>
                /// Shift X to the left
                /// </summary>
                LSHIFT,

                /// <summary>
                /// Shift X to the right
                /// </summary>
                RSHIFT,

                /// <summary>
                /// Increment X
                /// </summary>
                INC,

                /// <summary>
                /// Decrement X
                /// </summary>
                DEC,

                /// <summary>
                /// Y AND X
                /// </summary>
                AND,

                /// <summary>
                /// Y OR X
                /// </summary>
                OR,

                /// <summary>
                /// Y XOR X
                /// </summary>
                XOR,

                /// <summary>
                /// Move X to some place
                /// </summary>
                MOV,

                /// <summary>
                /// Branch if equal
                /// </summary>
                BEQ,

                /// <summary>
                /// Branch if not equal
                /// </summary>
                BNE,

                /// <summary>
                /// Branch if less
                /// </summary>
                BLT,

                /// <summary>
                /// Branch if greater
                /// </summary>
                BGT,

                /// <summary>
                /// Goto/jump
                /// </summary>
                JMP,
                
                /// <summary>
                /// Sub
                /// </summary>
                JSL,

                /// <summary>
                /// Load X
                /// </summary>
                LDX,

                /// <summary>
                /// Store accumulator
                /// </summary>
                STA,

                /// <summary>
                /// Comment
                /// </summary>
                REM,

                /// <summary>
                /// Load into accumulator
                /// </summary>
                LDA,

                /// <summary>
                /// Print out the value
                /// </summary>
                OUT,

                /// <summary>
                /// Return
                /// </summary>
                RTS
            }
        }
    }
}