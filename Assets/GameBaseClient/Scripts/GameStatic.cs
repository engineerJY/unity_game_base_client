using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBase
{
    public class GameStatic : MonoBehaviour
    {

        public static int popUpOrder = 100;

        public static int popUpNum = 0;

        public static void CreatePopUp(string content)
        {
            PopUp popUp = Resources.Load<PopUp>("PopUp") as PopUp;

            PopUpContentBase t = Resources.Load<PopUpContentBase>(content) as PopUpContentBase;

            GameObject p = (GameObject)Instantiate(popUp.gameObject) as GameObject;

            popUp.SetOrder(popUpOrder++);

            GameObject c = (GameObject)Instantiate(t.gameObject) as GameObject;
            t.SetOrder(popUpOrder + 1);
            c.transform.parent = p.GetComponent<PopUp>().content;
        }
    }
}