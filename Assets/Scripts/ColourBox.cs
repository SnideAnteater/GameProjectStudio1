using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourBox :MonoBehaviour
{
    Collider2D self_Collider;
    SpriteRenderer render;
    int dataColor;
    public ColourPuzzleController controller;
    Color currentColor;
    // Start is called before the first frame update
    public void initialize()
    {
        self_Collider = GetComponent<Collider2D>(); // sets the collider to the variable
        render = GetComponent<SpriteRenderer>();
        toggleBox(true);
    }

    // Update is called once per frame
   public virtual void  Interact()
    {
       
        if (!controller.answerFull())
        {
            toggleBox(false);//only triggers if there is space in the answer stack
            controller.colorSelect(dataColor);
        }
        
    }

    public void setDisplayColor(float red, float green, float blue)//sets colour
    {
        currentColor.r = red;
        currentColor.g = green;
        currentColor.b = blue;
        this.render.color = currentColor;
    }

    public void toggleBox(bool state)//toggles transparency and collider
    {
        self_Collider.enabled = state;
        if (state)
        {
            currentColor.a = 1;
            render.color = currentColor;
        }
        else
        {
            currentColor.a = 0;
            render.color = currentColor;
        }
    }

    public void setDataColor(int c)
    {
        dataColor = c;
    }

    public int getDataColor()
    {
        return (dataColor);
    }
}
