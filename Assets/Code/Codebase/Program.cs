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
        FileBrowser.ShowSaveDialog((string path) => { save_path.value = path; }, 
                                    null, false, null, "Select File", "Select");
    }
    public void SetLoadPath()
    {
        FileBrowser.ShowSaveDialog((string path) => { load_path.value = path; }, 
                                    null, false, null, "Select File", "Select");
    }

    public void CreateAnagrams(InputField input_field)
    {
        string letters = input_field.text;
        
        DateTime start = DateTime.Now;
        print(start);
        Old.TrigramSet ts = Old.FileManager.CreateGraphemeSetFromFile<Old.TrigramSet, Old.Trigram>(load_path.value, Encoding.UTF8);
        TimeSpan end = DateTime.Now - start;
        print(end.TotalSeconds);


        start = DateTime.Now;
        print(start);


        foreach (Old.VariableLetterGroup s in new Old.VariableLetterGroup(letters).SortedAndAnalyzedUniquePermutations(ts))
            Old.FileManager.CreateOrUpdateFileWithOneLine(s, save_path.value, Encoding.UTF8);

        end = DateTime.Now - start;
        print(end.TotalSeconds);
    }

}

