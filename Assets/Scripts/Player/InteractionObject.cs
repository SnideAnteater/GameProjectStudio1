using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionObject : MonoBehaviour
{
    public GameObject player = null;
    public bool inventory; //if true this item can be stored in inventory
    public bool isPlayer = false;

    public void DoInteraction()
    {

        //picked up and put in inventory
        gameObject.SetActive(false);
        
    }

    private void OnMouseDown()
    {
        if(isPlayer == true)
        {
            player.SendMessage("ItemGetActivate");
        }
    }

 void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name + "in range of item");
            player = other.gameObject;
            isPlayer = true;
        }

    }

 void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            if (other.gameObject == player)
            {
                player = null;
                isPlayer = false;
                Debug.Log(other.name + " NOT in range of item");
            }
        }

    }


}