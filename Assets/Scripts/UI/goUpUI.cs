using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goUpUI : MonoBehaviour
{
    public GameObject UIMenu;
    public GameObject UIButton;
   

    public void goUP()
    {
        UIMenu.SetActive(false);
        UIButton.SetActive(true);
        gameObject.SetActive(false);
        
    }
}
