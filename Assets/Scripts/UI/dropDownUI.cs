using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class dropDownUI : MonoBehaviour
{
    public GameObject UIMenu;
    public GameObject UIButton;
    

    public void dropDown()
    {
        UIMenu.SetActive(true);
        UIButton.SetActive(true);
        gameObject.SetActive(false);
        
    }
}
