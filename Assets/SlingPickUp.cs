using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingPickUp : MonoBehaviour
{
    public playerAnim animation;
    public GameObject UI;


    public void Interact()
    {
        Debug.Log("Hello");
        animation.FullSet = true;
        animation.HasItem = false;
        UI.SetActive(true);
        gameObject.SetActive(false);

    }
}
