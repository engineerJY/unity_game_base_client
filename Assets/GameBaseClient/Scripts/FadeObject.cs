using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameBase
{
    public class FadeObject : MonoBehaviour
    {
        [SerializeField]
        Image fadePanel;

        void Start()
        {

        }

        public IEnumerator FadeIn()
        {
            fadePanel.color = new Color(0,0,0,1);

            float alpha = 1.0f;
            while(alpha >= 0.0f)
            {
                alpha -= 0.1f;
                fadePanel.color = new Color(0, 0, 0, alpha);
                yield return null;
            }

            yield return null;
        }

        public IEnumerator FadeOut()
        {
            fadePanel.color = new Color(0, 0, 0, 0);

            float alpha = 0.0f;
            while (alpha <= 1.0f)
            {
                alpha += 0.1f;
                fadePanel.color = new Color(0, 0, 0, alpha);
                yield return null;
            }

            yield return null;
        }
    }
}

