using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    private Inventory_Update inventory;
    public GameObject itemButton;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Update>();
    }

    void onTriggerEnter2D(Collider2D other)
    {
        /*if(other.CompareTag("Player"))
        {
            //if (Input.GetButtonDown("Fire1"))
            //{
                for (int i = 0; i < inventory.slots.Length; i++)
                {
                    if(inventory.isFull[i] == false)
                    {
                        //ITEM CAN BE ADDED TO INVENTORY
                        inventory.isFull[i] = true;
                        Instantiate(itemButton, inventory.slots[i].transform, false);
                        Destroy(gameObject);
                        break;
                    }
                }
            //}

        }*/

        if (other.CompareTag("Player"))
        {
            // spawn the sun button at the first available inventory slot ! 


            for (int i = 0; i < inventory.items.Length; i++)
            {
                if (inventory.items[i] == 0)
                { // check whether the slot is EMPTY
                    //Instantiate(effect, transform.position, Quaternion.identity);
                    inventory.items[i] = 1; // makes sure that the slot is now considered FULL
                    Instantiate(itemButton, inventory.slots[i].transform, false); // spawn the button so that the player can interact with it
                    Destroy(gameObject);
                    break;
                }
            }
        }
    }
}
