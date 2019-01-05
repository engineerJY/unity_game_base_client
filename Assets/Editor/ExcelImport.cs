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

    [MenuItem("Tools/ExcelImport")]
    static void Open()
    {
        string path = Application.dataPath;
        path = path.Substring(0, path.Length - 6);

        Debug.Log(path);
        
        string[] files = Directory.GetFiles(string.Format("{0}/Excel", path), "*.xlsx", System.IO.SearchOption.TopDirectoryOnly);

        Debug.Log(files.Length);

        foreach(string str in files)
        {
            Debug.Log(str);
            ReadXLSX(str);
        }
    }

    static public void ReadBook(IWorkbook book)
    {
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

    static public void ReadXLS(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            Debug.Log("ReadXLS:" + path);

            ReadBook(new HSSFWorkbook(fs));
        }
    }

    static public void ReadXLSX(string path)
    {
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
        {
            Debug.Log("ReadXLSX:" + path);

            ReadBook(new XSSFWorkbook(fs));
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
