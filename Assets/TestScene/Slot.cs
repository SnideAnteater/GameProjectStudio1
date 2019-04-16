using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private Inventory_Update inventory;
    public int index;

    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory_Update>();
    }

    private void Update()
    {
        if (transform.childCount <= 0)
        {
            inventory.items[index] = 0;
        }
    }

    public void Cross()
    {
        foreach (Transform child in transform)
        {
            //child.GetComponent<Spawn>().SpawnItem();
            GameObject.Destroy(child.gameObject);
        }
    }
}