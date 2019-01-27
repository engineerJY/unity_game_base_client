using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GameBase.Networking;
using GameBase.Data;

public class Test : MonoBehaviour {

    [SerializeField]
    private WebAPIManager WebAPIManager;

	// Use this for initialization
	void Start () {

        WebAPIManager.Init();

        //StartCoroutine(WebAPIManager.GetRequest("", SuccessCallBack, ()=> { }));
	}

    void SuccessCallBack(string result)
    {
        Debug.Log(result);
        //User user = WebAPIManager.JsonResult<User>(result);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
