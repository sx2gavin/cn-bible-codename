using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class WordsReader : MonoBehaviour
{
    [SerializeField] private string filePath;

    private List<string> lstWords = new List<string>();

    // Start is called before the first frame update
    public List<string> LoadWordsFromFile()
    {

        string path = Application.dataPath;

        string wordFilePath = path + "/../words.txt";

        lstWords.Clear();
        StreamReader streamReader = new StreamReader(wordFilePath);
        
        while (!streamReader.EndOfStream)
        {
            lstWords.Add(streamReader.ReadLine());
        }

        return lstWords;
    }


}
