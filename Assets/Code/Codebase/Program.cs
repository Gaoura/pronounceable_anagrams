using UnityEngine;
using System;
using System.Text;
using SimpleFileBrowser;
using UnityEngine.UI;

class Program : MonoBehaviour
{
    [SerializeField]
    [Label("Save path")]
    private StringReference save_path;

    [SerializeField]
    [Label("Load path")]
    private StringReference load_path;

    public void SetSavePath()
    {
        FileBrowser.ShowSaveDialog((string path) => { save_path.value = path; }, null, false, null, "Select File", "Select");
    }
    public void SetLoadPath()
    {
        FileBrowser.ShowSaveDialog((string path) => { load_path.value = path; }, null, false, null, "Select File", "Select");
    }

    public void CreateAnagrams(InputField input_field)
    {
        string letters = input_field.text;
        //TrigramSet ts = new TrigramSet();
        
        DateTime start = DateTime.Now;
        print(start);
        TrigramSet ts = FileManager.CreateGraphemeSetFromFile<TrigramSet, Trigram>(load_path.value, Encoding.UTF8);
        TimeSpan end = DateTime.Now - start;
        print(end.TotalSeconds);


        start = DateTime.Now;
        print(start);


        foreach (VariableLetterGroup s in new VariableLetterGroup(letters).SortedAndAnalyzedUniquePermutations(ts))
            //FileManager.CreateOrUpdateFileWithOneLine(s, @"C:\Users\Gaoura\Desktop\test_file_manager2.txt", Encoding.UTF8);
            FileManager.CreateOrUpdateFileWithOneLine(s, save_path.value, Encoding.UTF8);

        end = DateTime.Now - start;
        print(end.TotalSeconds);

        //Console.ReadKey(true);
    }

}

