using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxClose : MonoBehaviour
{
    public Image image;
    Color col;

    private void Start()
    {       
        image = GetComponent<Image>();
        col = image.color;
    }

    public void toggleBox(bool state)//toggles transparency and collider
    {
        if (state)
        {
            col.a = 1;
            image.color = col;
        }
        else
        {
            col.a = 0;
            image.color = col;
        }
    }
}
