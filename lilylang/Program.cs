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
				Environment.Exit(0);
			}

		REPLLoop:
			WriteLine(
				"Welcome to the REPL mode! Type EXIT if you've had your fun.\n" +
				"ID\tOP\tSL\tVT\tINSTRUCTION"
			//	ID	OP	SL	VT	INSTRUCTION
			//	01	2E	01	--	take;
			);
			CurrentPointedEffect = 0;
			while (true)
			{
				try
				{
					string st = ReadLine().TrimStart();
					if (string.IsNullOrWhiteSpace(st)) continue;
					if (st.StartsWith('.'))
                    {
						string dir = st.TrimStart('.');
						switch (dir.Split(' ')[0])
                        {
							case "exit":
								Environment.Exit(0);
								break;
							case "run":
								Clear();
								Execute();
								continue;
							case "save":
								string pth = Regex.Match(dir, @"save\s+(?<path>"".*"")").Groups["path"].Value.Trim('"');
								CreateBinary(pth);
								WriteLine("Saved!");
								break;
							case "load":
								string pth2 = Regex.Match(dir, @"load\s+(?<path>"".*"")").Groups["path"].Value.Trim('"');
								Write("WARNING: This will overwrite your current session! Continue? [Y/N]> ");
								var key = ReadKey();
								if (key.Key == ConsoleKey.Y)
								{
									WriteLine();
									CurrentEffects.Clear();
									CurrentPointedEffect = 0;
									LoadBinary(pth2);
									for (; CurrentPointedEffect < CurrentEffects.Count - 1; CurrentPointedEffect++)
									{
										WriteLine(
											$"{CurrentPointedEffect:X4}      " +
											$"{(byte)CurrentEffects[CurrentPointedEffect].ActionType:X2}      " +
											$"{(CurrentEffects[CurrentPointedEffect].Value is not null ? (CurrentEffects[CurrentPointedEffect].Value! switch { bool => 1, byte => 1, sbyte => 1, short => 2, ushort => 2, Half => 2, int => 4, uint => 4, float => 4, long => 8, ulong => 8, double => 8, decimal => 16, char => 2, string str => Encoding.ASCII.GetByteCount(str, 0, str.Length) } + 1).ToString("x2") : 1.ToString("x2"))}      " +
											$"{(CurrentEffects[CurrentPointedEffect].Value is not null ? (CurrentEffects[CurrentPointedEffect].Value! switch { bool => 3, byte => 6, sbyte => 5, short => 7, ushort => 8, Half => 17, int => 9, uint => 10, float => 13, long => 11, ulong => 12, double => 14, decimal => 15, char => 4, string => 8, _ => 1 }).ToString("x2") : 0.ToString("x2"))}      " +
											$"(unreconstructable -- {pth2})");
									}
									break;
								}
								else break;
						}
					}
					else
					{
						Interpret(false, false, st);
						SetCursorPosition(0, CursorTop - 1);
						WriteLine(
							$"{CurrentPointedEffect:X4}    " +
							$"{(byte)CurrentEffects[CurrentPointedEffect].ActionType:X2}      " +
							$"{(CurrentEffects[CurrentPointedEffect].Value is not null ? (CurrentEffects[CurrentPointedEffect].Value! switch { bool => 1, byte => 1, sbyte => 1, short => 2, ushort => 2, Half => 2, int => 4, uint => 4, float => 4, long => 8, ulong => 8, double => 8, decimal => 16, char => 2, string str => Encoding.ASCII.GetByteCount(str, 0, str.Length) } + 1).ToString("x2") : 1.ToString("x2"))}      " +
							$"{(CurrentEffects[CurrentPointedEffect].Value is not null ? (CurrentEffects[CurrentPointedEffect].Value! switch { bool => 3, byte => 6, sbyte => 5, short => 7, ushort => 8, Half => 17, int => 9, uint => 10, float => 13, long => 11, ulong => 12, double => 14, decimal => 15, char => 4, string => 8, _ => 1 }).ToString("x2") : 0.ToString("x2"))}      " +
							$"{st}");
						CurrentPointedEffect++;
					}
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