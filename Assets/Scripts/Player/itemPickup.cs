using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    public GameObject player = null;
    public InteractionObject currentInterObjScript = null;

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Item"))
        {
            Debug.Log(other.name);
            player = other.gameObject;
            currentInterObjScript = player.GetComponent<InteractionObject>();
        }

    }

    void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Item"))
        {
            if (other.gameObject == player)
            {
                player = null;
            }
        }

    }
}
