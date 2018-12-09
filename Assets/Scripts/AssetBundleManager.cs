using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class AssetBundleManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (Download(false));
	}
	
	public IEnumerator Download (bool isLoacal) {

		if (isLoacal) {

			//ローカルからのロード
			var ab = AssetBundle.LoadFromFile ("AssetBundleBuild/canvas");
			if (ab == null) {
				yield break;
			}

			var prefab = ab.LoadAsset<GameObject> ("Canvas");
			Instantiate (prefab);
		} else {
			//サーバーからのロード
			using (var wreq = UnityWebRequestAssetBundle.GetAssetBundle ("http://118.27.34.232/canvas")) {
				yield return wreq.SendWebRequest ();
				Debug.Log ("http response code:" + wreq.responseCode);
				if (wreq.isNetworkError || wreq.isHttpError) {
					Debug.LogError ("エラー" + wreq.error);
					yield break;
				}

				var ab = DownloadHandlerAssetBundle.GetContent (wreq);
				var prefab = ab.LoadAsset<GameObject> ("canvas");
				Instantiate (prefab);
			}
		}

		yield return null;
	}

	//ローカルからのロード


	//サーバーからのロード
}
