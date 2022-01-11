namespace fonder.tests;

public static class SelfChangingRecord
{
    public static List<Test> records = new();
    public static void Main(string[] args)
    {
        for (int i = 0; i < 25; i++) records.Add(new Test(new Random().Next(0, int.MaxValue).ToString(), new Random().Next(0, int.MaxValue) > ushort.MaxValue * 2)); 

        foreach (Test test in records) Console.WriteLine($"{records.IndexOf(test)}: {test}");

        Console.ReadLine();

        int index = new Random().Next(0, 25);
        var selected = records[index];
        Console.WriteLine($"{records.IndexOf(selected)}: {selected}");
        Console.ReadLine();
        selected.Change(new Random().Next(0, int.MaxValue).ToString(), index);

        Console.WriteLine($"{index}: {records[index]}\n");
        Console.ReadLine();
        foreach (Test test in records) Console.WriteLine($"{records.IndexOf(test)}: {test}");
    }
    public record struct Test(string Yes, bool No)
    {
        public void Change(string newYes, int index)
        {
            records[index] = this with { Yes = newYes };
        }
    }
}

