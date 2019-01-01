using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Build
{
    // ビルド実行でAndroidのapkを作成する例
    [UnityEditor.MenuItem("Tools/Build Project Android")]
    public static void BuildProjectAndroid()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.Android, BuildTarget.Android);

        //List<string> allScene = new List<string>();

       /*foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
        {
            if (scene.enabled)
            {
                allScene.Add(scene.path);
            }
        }*/

        string[] sceneList = {
           "./Assets/TestSceneBase/SceneTest1.unity",
           "./Assets/TestSceneBase/SceneTest2.unity",
           "./Assets/TestSceneBase/SceneTest3.unity"
       };

        PlayerSettings.applicationIdentifier = "com.yourcompany.newgame";
        PlayerSettings.statusBarHidden = true;
        var a = BuildPipeline.BuildPlayer(
            sceneList,
            "/Documentation/newgame.apk",
            BuildTarget.Android,
            BuildOptions.None
        );


    }

    // ビルド実行でAndroidのapkを作成する例
    [UnityEditor.MenuItem("Tools/Build Project iOS")]
    public static void BuildProjectiOS()
    {
        EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTargetGroup.iOS, BuildTarget.iOS);

        //List<string> allScene = new List<string>();

        /*foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes)
         {
             if (scene.enabled)
             {
                 allScene.Add(scene.path);
             }
         }*/

        string[] sceneList = {
           "./Assets/TestSceneBase/SceneTest1.unity",
           "./Assets/TestSceneBase/SceneTest2.unity",
           "./Assets/TestSceneBase/SceneTest3.unity"
       };

        PlayerSettings.applicationIdentifier = "com.yourcompany.newgame";
        PlayerSettings.statusBarHidden = true;
        var a = BuildPipeline.BuildPlayer(
            sceneList,
            "/Documentation/newgame",
            BuildTarget.iOS,
            BuildOptions.None
        );


    }
}
