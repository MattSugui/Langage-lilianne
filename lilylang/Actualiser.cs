using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Reflection;
using System.Reflection.Emit;
using System.IO;

using static fonder.Lilian.New.Interpreter.Tokeniser;

using static System.Console;

// Guide to comments
// if the comments look like this line, they're omitted code.
/* if the comments look like this line, they're actual comments. */

namespace fonder.Lilian.New
{
    public static partial class Interpreter
    {
        public static List<Actualiser.IInstruction> CurrentInstructions = new();
        public static List<Actualiser.Opcode> CurrentOpcodes = new();

        public static Stack<Actualiser.IInstruction> ScopeMatryushka = new();

        static Interpreter() // temp
        {
            CurrentOpcodes.Add(new("PrintString", Guid.Parse("00000000-acee-2021-1216-174808000001"), temp.Print));
        }
        /// <summary>
        /// The main bytecode-Lilian code translator.
        /// </summary>
        public static class Actualiser
        {
            public struct Opcode
            {
                public Opcode(string name, Guid code, AssociatedInstructionDelegation accinst)
                {
                    Name = name;
                    cod = code;
                    AssociatedInstruction = accinst;
                }

                public Opcode(string name, string code, AssociatedInstructionDelegation accinst)
                {
                    Name = name;
                    if (!string.IsNullOrWhiteSpace(code))
                    {
                        if (!Guid.TryParse(code, out cod)) throw new Lamentation();
                    }
                    else throw new Lamentation();
                    AssociatedInstruction = accinst;

                }

                public string Name { get; }
                private readonly Guid cod;
                public Guid Code => cod;
                public delegate void AssociatedInstructionDelegation(string left, string rightleft, string rightright);
                public AssociatedInstructionDelegation AssociatedInstruction { get; }
            }

            public interface IInstruction
            {
                void Invoke();
            }

            public struct Instruction: IInstruction
            {
                public Instruction(Opcode code, params string[] @ref)
                {
                    InstructionCode = code;
                    ValueReference = @ref;
                }

                public Instruction(Guid code, params string[] @ref)
                {
                    if (CurrentOpcodes.Exists(test => test.Code == code)) InstructionCode = CurrentOpcodes.Find(test => test.Code == code); else throw new Lamentation();
                    ValueReference = @ref;
                }

                public void Invoke()
                {
                    switch (ValueReference.Length)
                    {
                        case 1: InstructionCode.AssociatedInstruction.Invoke(ValueReference[0], null, null); break;
                        case 2: InstructionCode.AssociatedInstruction.Invoke(ValueReference[0], ValueReference[1], null); break;
                        case 3: InstructionCode.AssociatedInstruction.Invoke(ValueReference[0], ValueReference[1], ValueReference[2]); break;
                        default: throw new Lamentation(0x000A);
                    }
                }

                public Opcode InstructionCode { get; }
                public string[] ValueReference { get; }

                public override string ToString() => $"{InstructionCode.Code} ({InstructionCode.AssociatedInstruction.Method.Name}): {ValueReference[0]}, ...";
            }

            public struct CardStraightener : IInstruction
            {
                public CardStraightener(bool end, int level)
                {
                    Endianness = end;
                    Level = level;
                }
                public bool Endianness { get; }
                public int Level { get; }
                public void Invoke() { ; }
            }

            public class InstructionGroup: IInstruction
            {
                public InstructionGroup(IInstruction[] inst)
                {
                    Instructions = inst;
                }

                public IInstruction[] Instructions { get; }

                public void Invoke()
                {
                    foreach (Instruction inst in Instructions) inst.Invoke();
                }
            }

            /// <summary>
            /// The translator module.
            /// </summary>
            public static class Translator
            {
                public static void Translate(SentenceFruit fruit)
                {
                    if (fruit.AssociatedSentence.Mingle)
                    {
                        CurrentLevel++;
                        CurrentInstructions.Add(new CardStraightener(false, CurrentLevel));
                    }
                    else if (fruit.AssociatedSentence.Ender)
                    {
                        CurrentInstructions.Add(new CardStraightener(true, CurrentLevel));
                        CurrentLevel--;
                    }
                    else
                    {
                        List<string> refs = new();
                        foreach (int index in fruit.AssociatedSentence.WorkingValues) refs.Add(fruit.Value[index]);
                        CurrentInstructions.Add(new Instruction(fruit.AssociatedSentence.InstanceId, refs.ToArray()));
                    }
                }

                internal static void Actualise(Guid opcode)
                {

                }
            }
        }

        public static class temp
        {
            public static void Print(string input, string input1, string input2) => WriteLine(input.Trim('"'));
        }
    }
}