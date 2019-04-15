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
        if(Input.GetButtonDown("Fire1"))
        {

        }
        if(other.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Fire1"))
            {
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
            }

        }
    }
}
