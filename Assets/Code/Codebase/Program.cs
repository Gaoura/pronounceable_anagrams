using UnityEngine;
using System;
using System.Text;
using SimpleFileBrowser;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Diagnostics;

class Program : MonoBehaviour
{
    [SerializeField]
    [Label("Save path")]
    private StringReference save_path;

    [SerializeField]
    [Label("Load path")]
    private StringReference load_path;

    public void Start()
    {
        /*var stopwatch2 = Stopwatch.StartNew();
        GraphemeRuleSet rules = new GraphemeRuleSet();
        rules.AddRule(pool.GetLetters("abc"));
        rules.AddRule(pool.GetLetters("bcd"));
        rules.AddRule(pool.GetLetters("cda"));
        rules.AddRule(pool.GetLetters("dab"));
        rules.AddRule(pool.GetLetters("eab"));
        
        Word word = pool.GetLetters("abcde");
        var stopwatch = Stopwatch.StartNew();
        print(rules.RespectsRules(word));
        print(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        word = pool.GetLetters("abcda");
        print(rules.RespectsRules(word));
        print(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        word = pool.GetLetters("abc");
        print(rules.RespectsRules(word));
        print(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        word = pool.GetLetters("ab");
        print(rules.RespectsRules(word));
        print(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        word = pool.GetLetters("a");
        print(rules.RespectsRules(word));
        print(stopwatch.ElapsedMilliseconds);
        stopwatch.Restart();
        word = pool.GetLetters("f");
        print(rules.RespectsRules(word));
        print(stopwatch.ElapsedMilliseconds);*/


        /*Word word = pool.GetLetters("abb");

        
        List<Word> words = new List<Word>();
        foreach (Word w in word.UniquePermutations())
            words.Add(w);

        foreach (Word w in words)
            print(w);*/
            

    }

    public void SetSavePath()
    {
        FileBrowser.OnSuccess on_success = (string path) => { save_path.value = path; };
        FileBrowser.ShowSaveDialog(on_success, null, 
                                    false, System.IO.Path.GetDirectoryName(save_path.value), "Select File", "Select");
    }
    public void SetLoadPath()
    {
        FileBrowser.OnSuccess on_success = (string path) => { load_path.value = path; };
        FileBrowser.ShowSaveDialog(on_success, null, 
                                    false, System.IO.Path.GetDirectoryName(load_path.value), "Select File", "Select");
    }

    public void CreateAnagrams(InputField input_field)
    {
        string letters = input_field.text;
        LetterPool pool = new LetterPool();
        Word word = pool.GetLetters(letters.ToLower());
        FileManager file_manager = new FileManager();


        DateTime start = DateTime.Now;
        print(start);
        //Old.TrigramSet ts = Old.FileManager.CreateGraphemeSetFromFile<Old.TrigramSet, Old.Trigram>(load_path.value, Encoding.UTF8);
        GraphemeRuleSet rules = file_manager.CreateGraphemeSetFromFile(load_path.value, Encoding.UTF8);
        TimeSpan end = DateTime.Now - start;
        print(end.TotalSeconds);


        start = DateTime.Now;
        print(start);

        //foreach (Old.VariableLetterGroup s in new Old.VariableLetterGroup(letters).SortedAndAnalyzedUniquePermutations(ts))
        //    Old.FileManager.CreateOrUpdateFileWithOneLine(s, save_path.value, Encoding.UTF8);
        foreach (Word permutation in word.SortedAndAnalyzedUniquePermutations(rules))
            file_manager.CreateOrUpdateFileWithOneLine(permutation, save_path.value, Encoding.UTF8);

        end = DateTime.Now - start;
        print(end.TotalSeconds);
    }

}

