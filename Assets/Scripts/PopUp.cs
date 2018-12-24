using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace GameBase
{
    public class PopUp : MonoBehaviour
    {
        [SerializeField]
        Canvas canvas;

        [SerializeField]
        Animator animator;

        [SerializeField]
        public Transform content;

        // Use this for initialization
        void Start()
        {

        }

        public void SetOrder(int order)
        {
            canvas.sortingOrder = order;
        }

        public void Open()
        {
            //animator.SetTrigger("Close");
        }

        public void Close()
        {
            animator.SetTrigger("Close");
        }
    }
}

