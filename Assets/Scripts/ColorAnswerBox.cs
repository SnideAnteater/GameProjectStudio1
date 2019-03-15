using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorAnswerBox : ColourBox
{
    public override void Interact()//overrides the one in colourBox
    {
       
        controller.removeColor();
        controller.answerColorSetter();

    }
}
