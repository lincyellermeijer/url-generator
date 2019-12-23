using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using SmartDLL;
using System;

public class Explorer : MonoBehaviour
{
    public Text eText;
    public Button openExplorerButton;
    public Button generateURLButton;

    public SmartFileExplorer fileExplorer = new SmartFileExplorer();

    private bool showText = false;

    private int count = 0;
    private string line;
    List<string> productCodeList = new List<string>();

    void OnEnable()
    {
        openExplorerButton.onClick.AddListener(delegate { ShowExplorer(); });
        generateURLButton.onClick.AddListener(delegate { Generate(); });
    }

    // Update is called once per frame
    void Update()
    {
        if (fileExplorer.resultOK && showText)
        {
            ShowText(fileExplorer.fileName);
            showText = false;
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
        showText = true;
    }

    void Generate()
    {
        ReadText(fileExplorer.fileName);
        WriteEmptyLine(fileExplorer.fileName);

        for (int i = 0; i < productCodeList.Count; i++)
        {
            GenerateURL(fileExplorer.fileName, productCodeList[i]);
        }

        showText = true;
    }

    void ReadText(string path)
    {
        using (StreamReader reader = File.OpenText(path))
        {
            // read each line, ensuring not null (EOF)
            while ((line = reader.ReadLine()) != null)
            {
                if (line != string.Empty)
                {
                    // Here instead of replacing array with new content
                    // we add new words to already existing list of strings
                    productCodeList.AddRange(line.Split(' '));
                    count += 1;
                }
            }

        }
        // Count instead of Length because we're using List<T> now
        for (int i = 0; i < productCodeList.Count; i++)
        {
            Debug.Log("\n " + productCodeList[i]);
        }
    }


    void ShowText(string path)
    {
        eText.text = File.ReadAllText(path);
    }

    void GenerateURL(string path, string productCode)
    {
        //Write some text to the uploaded .txt file
        //StreamWriter writer = new StreamWriter(path, true);
        using (StreamWriter writer = File.AppendText(path))
        {
                writer.WriteLine("https://www.123inkt.nl/images/products/" + productCode[0] + "/" + productCode[1] + "/" + productCode + "/" + productCode + "_1_big.jpg");
                writer.Close();
        }
    }

    void WriteEmptyLine(string path)
    {
        using (StreamWriter writer = File.AppendText(path))
        {
            writer.WriteLine("\n");
            writer.Close();
        }
    }
}