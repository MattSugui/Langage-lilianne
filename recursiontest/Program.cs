global using static System.Console;

string patttest = ".-...///./";

List<thing> profondeur = new(); int niveau = -1;

foreach (char lol in patttest)
{
    switch (lol)
    {
        case '.':
            profondeur.Add(new(new Random().Next().ToString())); niveau++;
            WriteLine($"Branch! - {profondeur[niveau]} @ {niveau}");
            break;
        case '-':
            profondeur[niveau] = profondeur[niveau] with { name = new Random().Next().ToString() };
            WriteLine($"Branch details - {profondeur[niveau]} @ {niveau}");

            break;
        case '/':
            profondeur[niveau - 1] = profondeur[niveau - 1] with { obj = profondeur[niveau] };
            WriteLine($"Adoption - parent: {profondeur[niveau - 1]} @ {niveau - 1}, child: parent: {profondeur[niveau]} @ {niveau}");
            profondeur.RemoveAt(niveau); niveau--;
            break;
        default: break;
    }
}

record thing (string name, dynamic? obj = null);