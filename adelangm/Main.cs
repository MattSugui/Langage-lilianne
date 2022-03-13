global using System;
global using System.Collections.ObjectModel;
global using System.Collections.Generic;
global using System.Linq;
global using System.Text;
global using System.Text.RegularExpressions;
global using System.Threading;
global using System.Threading.Tasks;
global using System.Reflection;
global using System.IO;
global using System.Diagnostics;
global using System.Xml;
global using System.Xml.Serialization;
global using System.Runtime.InteropServices;

namespace fonder.Adelaide;

public static partial class Main
{
    public static List<FELAction> CurrentEffects { get; set; } = new();
}