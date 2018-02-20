using System.Collections.Generic;
using System.IO;
using System.Text;

public class FileManager
{
    public static T CreateGraphemeSetFromFile<T, S>(string path, Encoding encoding)
        where T : GraphemeSet<S>, new()
        where S : Grapheme, new()
    {
        T grapheme_set = new T();
        string line;
        StreamReader file = new StreamReader(path, encoding);

        while ((line = file.ReadLine()) != null)
        {
            S grapheme = new S();
            grapheme.SetGrapheme(line);
            grapheme_set.Add(grapheme);
        }

        file.Close();

        return grapheme_set;
    }

    public static void CreateFileFromList(List<VariableLetterGroup> list, string path, Encoding encoding)
    {
        StreamWriter file = new StreamWriter(path, false, encoding);

        foreach (VariableLetterGroup line in list)
            file.WriteLine(line.ToString());
        
        file.Close();
    }

    public static void CreateOrUpdateFileWithOneLine(VariableLetterGroup vlg, string path, Encoding encoding)
    {
        StreamWriter file = new StreamWriter(path, true, encoding);
        file.WriteLine(vlg.ToString());
        file.Close();
    }
}
