using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SmartDLL;

public class Explorer : MonoBehaviour
{
    public Text eText;
    public Button openExplorerButton;
    public Button generateURLButton;

    public SmartFileExplorer fileExplorer = new SmartFileExplorer();

    private bool readText = false;

    void OnEnable()
    {
        openExplorerButton.onClick.AddListener(delegate { ShowExplorer(); });
        generateURLButton.onClick.AddListener(delegate { Generate(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (fileExplorer.resultOK && readText)
        {
            ReadText(fileExplorer.fileName);
            readText = false;
        }
    }

    void ShowExplorer()
    {
        string initialDir = @"C:\";
        bool restoreDir = true;
        string title = "Open a Text File";
        string defExt = "txt";
        string filter = "txt files (*.txt)|*.txt";

        fileExplorer.OpenExplorer(initialDir, restoreDir, title, defExt, filter);
        readText = true;
    }

    void Generate()
    {
        GenerateURL(fileExplorer.fileName, eText.text);
        readText = true;
        // productcode uitlezen en invullen
    }

    void ReadText(string path)
    {
        eText.text = File.ReadAllText(path);
    }

    void GenerateURL(string path, string productCode)
    {
        //Write some text to the uploaded .txt file
        //StreamWriter writer = new StreamWriter(path, true);
        using (StreamWriter writer = File.CreateText(path))
        {
            writer.WriteLine("https://www.123inkt.nl/images/products/" + productCode[0] + "/" + productCode[1] + "/" + productCode + "/" + productCode + "_1_big.jpg");
            writer.Close();
        }
    }
}