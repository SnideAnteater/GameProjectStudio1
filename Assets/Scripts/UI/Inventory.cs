using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public GameObject[] inventory = new GameObject[5];
    public Button[] InventoryButtons = new Button[5];

    public void AddItem(GameObject item)
    {

        bool itemAdded = false;

        //find first open slot in inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                //Update UI
                InventoryButtons[i].image.overrideSprite = item.GetComponent<SpriteRenderer>().sprite;
                Debug.Log(item.name + "was added");
                itemAdded = true;
                //Do something with item
                item.SendMessage("DoInteraction");

                break;
            }
        }

        //inventory full
        if (!itemAdded)
        {
            Debug.Log("item not added,inventory full");
        }
        }


        public bool FindItem(GameObject item)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] == item)
                {
                    //found item
                    return true;
                }

            }

            return false;
        }

       /* public GameObject FindItemByType(string itemType)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] != null)
                {

                    if (inventory[i].GetComponent<InteractionObject>().itemType == itemType)
                    {

                        return inventory[i];
                    }
                }
            }
            //item of type not found
            return null;

        }

        //not created yet
        public void RemoveItem(GameObject item)
        {
            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] = item)
                {

                    inventory[i] = null;
                    Debug.Log(item.name + "was removed");
                    //Update UI
                    InventoryButtons[i].image.overrideSprite = null;

                    break;


                }
            }
        }*/

    }
