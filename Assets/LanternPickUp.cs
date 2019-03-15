using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanternPickUp : MonoBehaviour
{
    public playerAnim animation;
    public GameObject statueLantern;

    public void Interact()
    {
        Debug.Log("Hello");
        animation.NoItem = false;
        animation.HasItem = true;
        statueLantern.SetActive(false);

    }
}