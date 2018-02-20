using System;
using System.Text;

class Program
{
    public static void Main(string[] args)
    {
        //TrigramSet ts = new TrigramSet();

        DateTime start = DateTime.Now;
        Console.WriteLine(start);
        //TrigramSet ts = FileManager.CreateGraphemeSetFromFile<TrigramSet, Trigram>(@"C:\Users\Gaoura\Desktop\trigrammes.txt", Encoding.UTF8);
        DigramSet ts = FileManager.CreateGraphemeSetFromFile<DigramSet, Digram>(@"C:\Users\Gaoura\Desktop\liste_bigrammes.txt", Encoding.UTF8);
        /*
        //--------------------------------------
        string line;
        Encoding e = System.Text.Encoding.UTF8;
        // Read the file and display it line by line.  
        System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Gaoura\Desktop\trigrammes.txt", e);
        while ((line = file.ReadLine()) != null)
            ts.Add(new Trigram(line));

        file.Close();
        //--------------------------------------
        */
        TimeSpan end = DateTime.Now - start;
        Console.WriteLine(end.TotalSeconds);


        start = DateTime.Now;
        Console.WriteLine(start);

        string st = "nyrraido";


        foreach (VariableLetterGroup s in new VariableLetterGroup(st).SortedAndAnalyzedUniquePermutations(ts))
            //FileManager.CreateOrUpdateFileWithOneLine(s, @"C:\Users\Gaoura\Desktop\test_file_manager2.txt", Encoding.UTF8);
            FileManager.CreateOrUpdateFileWithOneLine(s, @"C:\Users\Gaoura\Desktop\test_bigrammes.txt", Encoding.UTF8);

        end = DateTime.Now - start;
        Console.WriteLine(end.TotalSeconds);

        //Console.ReadKey(true);
    }
}

