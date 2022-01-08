#define UseREPLAsFileLoader

using System;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

using static fonder.Lilian.New.Interpreter;
using static fonder.Lilian.New.Interpreter.Actualiser;
using static fonder.Lilian.New.Interpreter.Bureau;

using static System.Console;

namespace fonder.Lilian.New
{
	/// <summary>
	/// The main flow.<br/>
	/// L'écoulement primaire.
	/// </summary>
	public static class Programme
	{
		public static void Main(string[] args)
		{
			WriteLine(
				"Fonder Lilian Language Environment\n"+
				"Version " + Assembly.GetExecutingAssembly().GetName().Version.ToString() + ", " + (Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute)) as AssemblyInformationalVersionAttribute).InformationalVersion + "\n"
			);

			WriteLine(
				"Welcome to the REPL mode! Type EXIT if you've had your fun."
			)//
			;

			/*
			object bruh1 = null;
			object bruh2 = null;
			*/
#if !UseREPLAsFileLoader
			while (true)
			{
				try
				{
					Write("> ");
					string input = ReadLine();
					input.Replace("\\n", "\n");
					Interpreter.Interpret(input);
					if (input.ToUpper() == "EXIT") break; else continue;
				}
				catch (Interpreter.Lamentation e)
                {
					WriteLine($"{e.ErrorCode}: {e.Message}");
					continue;
                }

				//leave: break;
			}
#else
			WriteLine("Type in the full name of the file to be evaluated.");
			string filepath = ReadLine().Trim('"');
			try
            {
				if (filepath.EndsWith(".lps"))
				{
					ReadFile(path: filepath);
					Interpret();
					CurrentInstructions.Clear();
					CurrentSentences.Clear();
					CurrentWordPacks.Clear();
				}
				else if (filepath.EndsWith(".lprg"))
                {
					(byte[], int) things;
					string yes;
					Read(filepath.Trim('"'), out yes, out things);
					Title += " - " + yes;
					Experience(things.Item1, things.Item2);
					Execute();
					ReadKey();
				}

			}
			catch (Lamentation cry)
            {
				WriteLine(cry.ToString());
            }
#endif
			CurrentEffects.Clear();
			Write($"Compilation finished.\nFun fact: You've saved up {(double)(File.ReadAllBytes("test.lsa").Length / File.ReadAllBytes(filepath.Trim('"')).Length)*100}%! Press any key to continue.");
			ReadKey();
			if (filepath.EndsWith(".lps") && args.Contains("-d"))
            {
				Clear();
				LoadBinary();
				Execute();
			}
		}
	}

	static class TEMPORARY
	{
		//static void BIN(string input)
		//{
		//	string bruh1 = "", bruh2 = "";
		//	switch (input.Split(" ")[0].ToUpper())
		//	{
		//		case "EXIT": /*goto leave; */ break;
		//		case "HELP":
		//			WriteLine(
		//   "Help about the columns:\n" +
		//   "CTXT   = ConTeXT; the current place in the code. Includes classes, if you want to do shit structurally.\n" +
		//   "INST   = INSTruction; the current instruction to perform. In non-object oriented situations, it will default to individual characters or opcodes/opcode number similar to ASM.\n" +
		//   "OPRD   = OPeRanD; the values to be passed in the current instruction. It can be a direct (hex/dec) or a colloquial (name) reference.\n\n" +
		//   "For a test of the rendering function, type \"TRY <val1> <val2>\" (type your own values) if you haven't already then type \"& @^\" (& = print; @ = point to; ^ = aforementioned). Surprise for you over there."
	 //  ); /*continue;*/ break;
		//		case "TRY":
		//			string[] tester = input.Split(" ");
		//			string @new = "";
		//			for (int i = 1; i > tester.Length; i++) @new += (tester[i] + ",").TrimEnd(',');

		//			bruh1 = tester[1];
		//			for (int i = 2; i > tester.Length; i++) bruh2 = (tester[i] + ",").TrimEnd(',');

		//			SetCursorPosition(0, CursorTop - 1);
		//			WriteLine();
		//			SetCursorPosition(0, CursorTop - 1);
		//			WriteLine($"{Interpreter.Common.CurrentContext}\t{input.ToUpper()}\t{@new}");
		//			/*continue;*/ break;
		//		case "&":
		//			string[] tester2 = input.Split(" ");
		//			string @new2 = "";
		//			for (int i = 1; i > tester2.Length; i++) @new2 += (tester2[i] + ",").TrimEnd(',');

		//			SetCursorPosition(0, CursorTop - 1);
		//			WriteLine();
		//			SetCursorPosition(0, CursorTop - 1);
		//			WriteLine($"{Interpreter.Common.CurrentContext}\t{input.ToUpper()}\t{@new2}");
		//			WriteLine($"{bruh1} has {bruh2}! oop!");
		//			/*continue;*/ break;
		//		default: /*continue;*/ break;
		//	}

		//}
	}
}