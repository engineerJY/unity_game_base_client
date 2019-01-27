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
        [SerializeField]
        FadeObject fadeObject;

        public void Awake()
        {
            Debug.Log("Awake base");
            
        }

        public void OnEnable()
        {
            Debug.Log("OnEnable base");
        }
        
        public IEnumerator Start()
        {
            Debug.Log("Start base");
            yield return StartCoroutine(fadeObject.FadeIn());
        }

        public void Update()
        {
            //Debug.Log("Update");
        }

        public void LateUpdate()
        {
            //Debug.Log("LateUpdate");
        }

        public IEnumerator ChangeScene(string scene)
        {
            yield return StartCoroutine(fadeObject.FadeOut());

            SceneManager.LoadScene(scene, LoadSceneMode.Single);

            yield return null;
        }
        

    }
}