using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class ExcelImport : EditorWindow
{
    static UnityEngine.Object baseMaster;

    [MenuItem("Tools/ExcelImport")]
    static void Open()
    {
        GetWindow<ExcelImport>();

        /*
        string path = Application.dataPath;
        path = path.Substring(0, path.Length - 6);

        Debug.Log(path);
        
        string[] files = Directory.GetFiles(string.Format("{0}Excel", path), "*.xlsx", System.IO.SearchOption.TopDirectoryOnly);

        Debug.Log(files.Length);

        

        foreach(string str in files)
        {
            Debug.Log(str);

            string fileName = Path.GetFileNameWithoutExtension(str);
            Debug.Log(fileName);

            string ext = Path.GetExtension(str);

            if(ext == ".xls")
            {
                ReadXLS(str, fileName);
            }

            if (ext == ".xlsx")
            {
                ReadXLSX(str, fileName);
            }

            
        }
        */
    }
    
    void OnGUI()
    {
        //QuestMaster t = target as QuestMaster;

        EditorGUILayout.BeginHorizontal();
        baseMaster = EditorGUILayout.ObjectField(baseMaster, typeof(UnityEngine.Object), true);
        //EditorGUILayout.ObjectField("Script", MonoScript.FromMonoBehaviour((MonoBehaviour)baseMaster), typeof(MonoScript), false);
        

        //EditorGUILayout.ObjectField("My Script", MonoScript.FromMonoBehaviour((MonoBehaviour)baseMaster), typeof(MonoScript), true);
        EditorGUILayout.EndHorizontal();

        

        if (GUILayout.Button("Button"))
        {
            if (baseMaster == null)
                ShowNotification(new GUIContent("No object selected for searching"));
            else
                Excute();
        }
    }

    static void Excute()
    {
        string path = Application.dataPath;
        path = path.Substring(0, path.Length - 6);

        Debug.Log(path);
        
        string[] files = Directory.GetFiles(string.Format("{0}Excel", path), "*.xlsx", System.IO.SearchOption.TopDirectoryOnly);

        Debug.Log(files.Length);

        

        foreach(string str in files)
        {
            Debug.Log(str);

            string fileName = Path.GetFileNameWithoutExtension(str);
            Debug.Log(fileName);

            string ext = Path.GetExtension(str);

            if(ext == ".xls")
            {
                ReadXLS(str, fileName);
            }

            if (ext == ".xlsx")
            {
                ReadXLSX(str, fileName);
            }

            
        }
    }

    static public void ReadBook(IWorkbook book, string fileName)
    {
        Type masterType = Type.GetType(fileName);
        var sobj = ScriptableObject.CreateInstance(masterType);
        AssetDatabase.CreateAsset(sobj, string.Format("Assets/Resources/AssetBundles/MasterData/{0}.asset", fileName));
        AssetDatabase.Refresh();
        

        //BaseMaster bm = (BaseMaster)baseMaster as BaseMaster;

        //bm.CreateInstans();

        int numberOfSheets = book.NumberOfSheets;

        Debug.Log("numberOfSheets:" + numberOfSheets );

        for (int sheetIndex = 0; sheetIndex < numberOfSheets; ++sheetIndex)
        {
            ISheet sheet = book.GetSheetAt(sheetIndex);

            int lastRowNum = sheet.LastRowNum;

            Debug.Log("SheetName:" + sheet.SheetName + "," + sheet.FirstRowNum + "," + lastRowNum);
            

            for (int rowIndex = sheet.FirstRowNum; rowIndex <= lastRowNum; ++rowIndex)
            {
                IRow row = sheet.GetRow(rowIndex);

                if (row == null)
                {
                    continue;
                }

                Debug.Log("Row" + rowIndex);

                int lastCellNum = row.LastCellNum;
                for (int cellIndex = row.FirstCellNum; cellIndex < lastCellNum; ++cellIndex)
                {
                    ICell cell = row.GetCell(cellIndex);

                    Debug.Log("Cell" + cellIndex + ":" + cell.CellType + "," + cell);
                }
            }
        }
    }

    static public void ReadXLS(string path, string fileName)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            Debug.Log("ReadXLS:" + path);

            ReadBook(new HSSFWorkbook(fs), fileName);
        }
    }

    static public void ReadXLSX(string path, string fileName)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            Debug.Log("ReadXLSX:" + path);

            ReadBook(new XSSFWorkbook(fs), fileName);
        }
    }

    /*
    static public void OnPostprocessAllAssets(
        string[] importedAssets,
        string[] deletedAssets,
        string[] movedAssets,
        string[] movedFromAssetPaths)
    {
        foreach (string importedAsset in importedAssets)
        {
            if (importedAsset.EndsWith(".xls"))
            {
                ReadXLS(importedAsset);
            }
            else if (importedAsset.EndsWith(".xlsx"))
            {
                ReadXLSX(importedAsset);
            }
        }
    }
    */
    
}
