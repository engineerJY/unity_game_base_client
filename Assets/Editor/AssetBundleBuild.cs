using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using UnityEditor;

public class AssetBundleBuild : MonoBehaviour {

	[MenuItem("Tools/Build AssetBundle")]
	public static void Build () {
		var assetBundleDirectory = "./AssetBundleBuild";
		if (!Directory.Exists (assetBundleDirectory)) {
			Directory.CreateDirectory (assetBundleDirectory);
		}
		BuildPipeline.BuildAssetBundles (assetBundleDirectory,
			BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
		EditorUtility.DisplayDialog ("アセットバンドルビルド終了","アセットバンドルビルドが終わりました","OK");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
