using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BtnScript : MonoBehaviour
{
    public enum Permission { Denied = 0, Granted = 1, ShouldAsk = 2 };

    private string path;
   private ReadWriteTXT handleText;

    // Start is called before the first frame update
    void Start()
    {
        handleText = new ReadWriteTXT();
    }

    public void UploadTxt()
    {
        //path = EditorUtility.OpenFilePanel("Overwrite with txt", "", "txt");
        GetTxt();
    }

    private void GetTxt()
    {
        Debug.Log("the following text was uploaded");
        handleText.ReadString(path);
    }

    public void SetTxt()
    {
        handleText.WriteString(path, "1/2/12345");
    }

    public void btnOne()
    {
        handleText.WriteString("Assets/Resources/test.txt", "test");
    }

    public void btnTwo()
    {
        handleText.ReadString("Assets/Resources/test.txt");
    }

    public void btnQuit()
    {
        Application.Quit();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
}
