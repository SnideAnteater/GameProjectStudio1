using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Items")]

public class Items : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artwork;
    public string itemID;

    public void Print()
    {
        Debug.Log(name + ": " + description);

    }
}
