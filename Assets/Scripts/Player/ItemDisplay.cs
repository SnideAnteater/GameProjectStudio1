using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemDisplay : MonoBehaviour
{
    public Items item;

    public Text nameText;
    public Text descText;

    public Image artwork;

    public Inventory inventory;


    // Start is called before the first frame update
    void Start()
    {
        nameText.text = item.name;
        descText.text = item.description;

        artwork.sprite = item.artwork;
        item.Print();
    }
    
}
