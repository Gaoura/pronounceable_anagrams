using System.Collections.Generic;
using System.IO;
using System.Text;

public class FileManager 
{
    public GraphemeRuleSet CreateGraphemeSetFromFile(string path, Encoding encoding)
    {
        var rules = new GraphemeRuleSet();
        LetterPool pool = new LetterPool();

        using (StreamReader file = new StreamReader(path, encoding))
        {
            string line = file.ReadLine();

            while (line != null)
            {
                Word rule = pool.GetLetters(line.ToLower());
                rules.AddRule(rule);
                line = file.ReadLine();
            }
        }

        return rules;
    }

    public void CreateOrUpdateFileWithOneLine(Word word, string path, Encoding encoding)
    {
        using (StreamWriter file = new StreamWriter(path, true, encoding))
        {
            file.WriteLine(word.ToString());
        }
    }

    public void CreateOrOverwriteFile(IEnumerable<Word> words, string path, Encoding encoding)
    {
        StringBuilder lines = new StringBuilder();
        foreach (Word word in words)
            lines.Append($"{word}\n");

        using (StreamWriter file = new StreamWriter(path, false, encoding))
        {
            file.Write(lines);
        }
    }
}
