using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBase
{
    public class PopUpContentBase : MonoBehaviour
    {
        [SerializeField]
        protected Canvas canvas;

        // Use this for initialization
        void Start()
        {

        }

        public void SetOrder(int order)
        {
            canvas.sortingOrder = order;
        }
    }
}