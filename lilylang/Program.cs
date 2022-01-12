﻿#define UseREPLAsFileLoader
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

			/*
			object bruh1 = null;
			object bruh2 = null;
			*/
			if (args.Length == 0) goto REPLLoop;

			WriteLine("Type in the full name of the file to be evaluated.");
			string filepath = ReadLine().Trim('"');
			try
			{
				if (filepath.EndsWith(".lps"))
				{
					ReadFile(path: filepath);
					Interpret();
					CurrentSentences.Clear();
					CurrentWordPacks.Clear();
					CurrentEffects.Clear();
				}
				else if (filepath.EndsWith(".lsa"))
				{
					Clear();
					LoadBinary();
					Execute();
				}
			}
			catch (Lamentation cry)
			{
				WriteLine(cry.ToString());
			}
			Write($"Compilation finished.\nPress any key to {(filepath.EndsWith(".lps") && args.Contains("-d")? "run this application" : "continue")}.");
			ReadKey();
			if (filepath.EndsWith(".lps") && args.Contains("-d"))
            {
				Clear();
				LoadBinary();
				Execute();
			}

		REPLLoop:
			WriteLine(
				"Welcome to the REPL mode! Type EXIT if you've had your fun.\n" +
				"ID\tOP\tPB\t\tINSTRUCTION"
			//	ID	OP	PB	INSTRUCTION
			//	01	2E	--	take;
			);

			while (true)
			{
				try
				{
					string st = ReadLine();
					if (st.StartsWith('.')) ;
					Interpret(false, false, st);
					SetCursorPosition(0, CursorTop - 1);
					WriteLine(
						$"{CurrentPointedEffect:X2}      " +
						$"{(byte)CurrentEffects[CurrentPointedEffect].ActionType:X2}      " +
						$"{(CurrentEffects[CurrentPointedEffect].Value is not null ? CurrentEffects[CurrentPointedEffect].Value!.GetTypeCode().ToString("X") : "        ")}        " +
						$"{st}");
					CurrentPointedEffect++;
				}
				catch (Lamentation e)
                {
					SetCursorPosition(0, CursorTop - 1);
					WriteLine(e.ToString());
					CurrentLine.Clear();
				}
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