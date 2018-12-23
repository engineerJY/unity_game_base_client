using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBase
{
    public class TestScene2 : SceneBase
    {
        new void Awake()
        {
            base.Awake();
            Debug.Log("Awake 2");
        }

        new void OnEnable()
        {
            base.OnEnable();
            Debug.Log("OnEnable 2");
        }

        new void Start()
        {
            Debug.Log("Start 2");
        }

        public void a()
        {
            SceneManager.LoadScene("SceneTest1");
        }
    }
}