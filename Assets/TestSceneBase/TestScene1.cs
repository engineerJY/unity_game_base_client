using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameBase
{
    public class TestScene1 : SceneBase
    {
        new void Awake()
        {
            base.Awake();
            Debug.Log("Awake 1");
        }

        new void OnEnable()
        {
            base.OnEnable();
            Debug.Log("OnEnable 1");
        }

        new IEnumerator Start()
        {
            yield return StartCoroutine(base.Start());
            Debug.Log("Start 1");

            yield return null;
        }

        public void a()
        {
            
            StartCoroutine(ChangeScene("SceneTest2"));
        }

        public void b()
        {
            SceneManager.LoadScene("SceneTest3", LoadSceneMode.Additive);
        }

        IEnumerator LoadYourAsyncScene()
        {
            // The Application loads the Scene in the background as the current Scene runs.
            // This is particularly good for creating loading screens.
            // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
            // a sceneBuildIndex of 1 as shown in Build Settings.

            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SceneTest2", LoadSceneMode.Single);

            // Wait until the asynchronous scene fully loads
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }
}
