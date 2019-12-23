using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;
using UnityEditor;
using UnityEngine;

public class ReadWriteTXT
{

    public void WriteString(string path, string productCode)
    {
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("www.123inkt.nl/images/products/" + productCode +  "_1_big.jpg");
        writer.Close();

        //Re-import the file to update the reference in the editor
        //AssetDatabase.ImportAsset(path);
        TextAsset asset = Resources.Load("test") as TextAsset;

        //Print the text from the file
        Debug.Log(asset.text);
    }

    public void ReadString(string path)
    {
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}
