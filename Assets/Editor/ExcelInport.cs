using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.UserModel;

public class ExcelInport : EditorWindow
{

    [MenuItem("Window/ExcelInport")]
    static void Open()
    {
        GetWindow<ExcelInport>();
    }

    bool toggleValue;


    void OnGUI()
    {
        EditorGUILayout.LabelField("ExcelInport");

        EditorGUI.BeginChangeCheck();

        //toggle をマウスでクリックして値を変更する
        toggleValue = EditorGUILayout.ToggleLeft("Toggle", toggleValue);

        if(GUILayout.Button("Button"))
        {
            Debug.Log("button clicked");
        }

        //toggleValue の値が変更されるたびに true になる
        if (EditorGUI.EndChangeCheck())
        {



            if (toggleValue)
            {
                Debug.Log("toggleValue が true になった瞬間呼び出される");
            }

        }
    }
}
