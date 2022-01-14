namespace fonder.Lilian.New;

/// <summary>
/// Hard-coded structures.
/// </summary>
public static class TEMP
{
	/// <summary>
	/// Load patterns.
	/// </summary>
	public static void LOADPATTERNS()
	{
		//----------------------- Name              Value                               Look            IgnoreOnRefinement          Terminate
		CurrentTokens.Add(new() { Name = "PRNT",	Value = "^print$"																				});
		CurrentTokens.Add(new() { Name = "QUOT",	Value = @"^"".*""$"																				});
		CurrentTokens.Add(new() { Name = "INTL",	Value = @"^[0-9]+$",				Look = true													});
		CurrentTokens.Add(new() { Name = "SMCL",	Value = @"^;$",																	Terminate = true});
		CurrentTokens.Add(new() { Name = "COLN",	Value = @"^:$",																	Terminate = true	});
		CurrentTokens.Add(new() { Name = "WTSP",	Value = @"^\s$",					Look = true,	IgnoreOnRefinement = true					});
		CurrentTokens.Add(new() { Name = "PRPR",	Value = @"^preprocess$"																			});
		CurrentTokens.Add(new() { Name = "STRT",	Value = @"^start$"																				});
		CurrentTokens.Add(new() { Name = "LET",		Value = @"^let$"																				});
		CurrentTokens.Add(new() { Name = "IDNT",	Value = @"^#[A-Za-z][0-9A-Za-z]*$",	Look = true													});
		CurrentTokens.Add(new() { Name = "ADDR",	Value = @"^\&[0-9]+$",				Look = true													});
		CurrentTokens.Add(new() { Name = "EQUL",	Value = @"^=$"																					});
		CurrentTokens.Add(new() { Name = "PUSH",	Value = @"^push$"																				});
		CurrentTokens.Add(new() { Name = "POP",		Value = @"^pop$"																				});
		CurrentTokens.Add(new() { Name = "ADDO",	Value = @"^add$"																				});
		CurrentTokens.Add(new() { Name = "SUBO",	Value = @"^subtract$"																			});
		CurrentTokens.Add(new() { Name = "MULO",	Value = @"^multiply$"																			});
		CurrentTokens.Add(new() { Name = "DIVO",	Value = @"^divide$"																				});
		CurrentTokens.Add(new() { Name = "MODO",	Value = @"^remainder$"																			});
		CurrentTokens.Add(new() { Name = "LSFT",	Value = @"^lshift$"																				});
		CurrentTokens.Add(new() { Name = "RSFT",	Value = @"^rshift$"																				});
		CurrentTokens.Add(new() { Name = "STOR",	Value = @"^store$"																				});
		CurrentTokens.Add(new() { Name = "LOAD",	Value = @"^load$"																				});
		CurrentTokens.Add(new() { Name = "BEQ",		Value = @"^beq$"																				});
		CurrentTokens.Add(new() { Name = "BNE",		Value = @"^bne$"																				});
		CurrentTokens.Add(new() { Name = "BGT",		Value = @"^bgt$"																				});
		CurrentTokens.Add(new() { Name = "BGE",		Value = @"^bge$"																				});
		CurrentTokens.Add(new() { Name = "BLT",		Value = @"^blt$"																				});
		CurrentTokens.Add(new() { Name = "BLE",		Value = @"^ble$"																				});
		CurrentTokens.Add(new() { Name = "GOTO",	Value = @"^goto$"																				});
		CurrentTokens.Add(new() { Name = "AND",		Value = @"^and$"																				});
		CurrentTokens.Add(new() { Name = "OR",		Value = @"^or$"																					});
		CurrentTokens.Add(new() { Name = "XOR",		Value = @"^xor$"																				});
		CurrentTokens.Add(new() { Name = "BTRU",	Value = @"^btr$"																				});
		CurrentTokens.Add(new() { Name = "BFLS",	Value = @"^bfl$"																				});
		CurrentTokens.Add(new() { Name = "END",		Value = @"^end$"																				});
		CurrentTokens.Add(new() { Name = "ASKN",	Value = @"^take$"																				});
		CurrentTokens.Add(new() { Name = "ASKL",	Value = @"^ask$"																				});
		CurrentTokens.Add(new() { Name = "NARW",	Value = @"^narrow$"																				});
		CurrentTokens.Add(new() { Name = "WIDN",	Value = @"^widen$"																				});
		CurrentTokens.Add(new() { Name = "REAL",	Value = @"^realise$"																			});
		CurrentTokens.Add(new() { Name = "CTCH",	Value = @"^catch$"																				});
		CurrentTokens.Add(new() { Name = "CALL",	Value = @"^call$"																				});
		CurrentTokens.Add(new() { Name = "RETN",	Value = @"^return$"																				});
		CurrentTokens.Add(new() { Name = "LABL",	Value = @"^@[A-Za-z][0-9A-Za-z]*$",	Look = true													});
		CurrentTokens.Add(new() { Name = "THNK",	Value = @"^think$"																				});

		//----------------------------------- Name                      TokenStruct ----------------                            -----
		CurrentSentenceStructures.Add(new() { Name = "StartPreprocess",	TokenStruct = new string[] {	"PRPR",	"COLN"			} });
		CurrentSentenceStructures.Add(new() { Name = "EndPreprocess",	TokenStruct = new string[] {	"STRT",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "PushString",		TokenStruct = new string[] {	"PUSH",	"QUOT",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "PushIntegral",	TokenStruct = new string[] {	"PUSH",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "Pop",				TokenStruct = new string[] {	"POP",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Print",			TokenStruct = new string[] {	"PRNT",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Add",				TokenStruct = new string[] {	"ADDO",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Subtract",		TokenStruct = new string[] {	"SUBO",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Multiply",		TokenStruct = new string[] {	"MULO",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Divide",			TokenStruct = new string[] {	"DIVO",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Modulus",			TokenStruct = new string[] {	"MODO",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "LeftShift",		TokenStruct = new string[] {	"LSFT",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "RightShift",		TokenStruct = new string[] {	"RSFT",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "StoreIndex",		TokenStruct = new string[] {	"STOR",	"ADDR",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "StoreNamed",		TokenStruct = new string[] {	"STOR",	"IDNT",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "LoadIndex",		TokenStruct = new string[] {	"LOAD",	"ADDR",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "LoadNamed",		TokenStruct = new string[] {	"LOAD",	"IDNT",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "IfThen",			TokenStruct = new string[] {	"BEQ",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "UnlessThen",		TokenStruct = new string[] {	"BNE",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "GreaterThan",		TokenStruct = new string[] {	"BGT",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "GreaterEqual",	TokenStruct = new string[] {	"BGE",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "LessThan",		TokenStruct = new string[] {	"BLT",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "LessEqual",		TokenStruct = new string[] {	"BLE",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "Goto",			TokenStruct = new string[] {	"GOTO",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "And",				TokenStruct = new string[] {	"AND",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Or",				TokenStruct = new string[] {	"OR",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Xor",				TokenStruct = new string[] {	"XOR",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "IfTrue",			TokenStruct = new string[] {	"BTRU",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "IfFalse",			TokenStruct = new string[] {	"BFLS",	"INTL",	"SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "End",				TokenStruct = new string[] {	"END",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "AskString",		TokenStruct = new string[] {	"ASKN",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Ask",				TokenStruct = new string[] {	"ASKL",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Narrowing",		TokenStruct = new string[] {	"NARW",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Widening",		TokenStruct = new string[] {	"WIDN",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Realisation",		TokenStruct = new string[] {	"REAL",	"SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "Catch",			TokenStruct = new string[] {	"CTCH", "INTL", "SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "Call",			TokenStruct = new string[] {	"CALL", "INTL", "SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "Return",			TokenStruct = new string[] {	"RETN", "SMCL"			} });
		CurrentSentenceStructures.Add(new() { Name = "CallNamed",		TokenStruct = new string[] {	"CALL", "LABL", "SMCL"	} });
		CurrentSentenceStructures.Add(new() { Name = "SubroutineName",	TokenStruct = new string[] {	"LABL", "COLN"			} });
		CurrentSentenceStructures.Add(new() { Name = "NoOperation",		TokenStruct = new string[] {	"THNK", "SMCL"			} });
	}
}