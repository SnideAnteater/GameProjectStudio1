using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenUI : MonoBehaviour
{
    public GameObject Dropdown;
    public GameObject Oil;

    public void Open()
    {
        Dropdown.SetActive(true);
        Oil.SetActive(true);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Open();
        }
    }
}
