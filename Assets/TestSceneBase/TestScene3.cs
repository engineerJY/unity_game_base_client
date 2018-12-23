using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBase
{
    public class TestScene3 : SceneBase
    {
        new void Awake()
        {
            base.Awake();
            Debug.Log("Awake 3");
        }

        new void OnEnable()
        {
            base.OnEnable();
            Debug.Log("OnEnable 3");
        }

        new void Start()
        {
            Debug.Log("Start 3");
        }

        public void a()
        {
            SceneManager.LoadScene("SceneTest2", LoadSceneMode.Single);
        }
    }
}