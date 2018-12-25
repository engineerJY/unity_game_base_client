using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class ExcelImport : EditorWindow
{

    [MenuItem("Window/ExcelImport")]
    static void Open()
    {
        GetWindow<ExcelImport>();

        Debug.Log(Application.dataPath);
        
        //DirectoryInfo dir = new DirectoryInfo(string.Format("{0}/Excel",Application.dataPath);
        //FileInfo[] info = dir.GetFiles("*");

        string[] files = Directory.GetFiles(string.Format("{0}/Excel", Application.dataPath), "*", System.IO.SearchOption.TopDirectoryOnly);

        Debug.Log(files.Length);

        foreach(string str in files)
        {
            Debug.Log(str);
        }
    }

    bool toggleValue;


    void OnGUI()
    {
        EditorGUILayout.LabelField("ExcelImport");

       
        if(GUILayout.Button("Button"))
        {
            Debug.Log("button clicked");
        }
        
    }
}
