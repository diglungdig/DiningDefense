using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StoreMenu : MonoBehaviour {


    public GameObject[] buttons;


    private bool boolSet = false;

    public void menuTrigger()
    {
        boolSet = !boolSet;
        if(buttons.Length > 0)
        {
            foreach(GameObject e in buttons)
            {
                e.SetActive(boolSet);
            }
        }
    }
	
}
