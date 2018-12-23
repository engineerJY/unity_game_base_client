using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBase
{
    /// <summary>
    /// シーン共通の処理
    /// </summary>
    public class SceneBase : MonoBehaviour, ISceneBase 
    {
        public void Awake()
        {
            Debug.Log("Awake base");
        }

        public void OnEnable()
        {
            Debug.Log("OnEnable base");
        }
        
        public void Start()
        {
            Debug.Log("Start base");
        }

        public void Update()
        {
            //Debug.Log("Update");
        }

        public void LateUpdate()
        {
            //Debug.Log("LateUpdate");
        }
    }
}