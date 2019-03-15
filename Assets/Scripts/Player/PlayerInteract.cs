using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{ 

public GameObject currentItem = null;
public InteractionObject currentInterObjScript = null;
public Inventory inventory;
public bool itemGet = false;

void Update()
{
        if (itemGet == true && currentItem)
        {
            ItemPickup();


        }
            /*if (Input.GetButtonDown("Fire1") && currentItem)
             {
                 //check if item can be stored in inventory
                 if (currentInterObjScript.inventory)
                 {
                     inventory.AddItem(currentItem);
                 }


             }*/

        }
void ItemGetActivate()
    {
        itemGet = true;
    }

void ItemPickup()
    {
        
            //check if item can be stored in inventory
            if (currentInterObjScript.inventory)
            {
                inventory.AddItem(currentItem);
            }

        itemGet = false;
        




    } 
void OnTriggerEnter2D(Collider2D other)
{

    if (other.CompareTag("Item"))
    {
        Debug.Log(other.name);
        currentItem = other.gameObject;
        currentInterObjScript = currentItem.GetComponent<InteractionObject>();
    }

}

void OnTriggerExit2D(Collider2D other)
{

    if (other.CompareTag("Item"))
    {
            if (other.gameObject == currentItem)
            {
                currentItem = null;
            }
    }

}
   

}