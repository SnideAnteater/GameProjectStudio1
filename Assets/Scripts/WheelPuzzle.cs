using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelPuzzle : MonoBehaviour
{
    public WheelPuzzleControler Controller;
    public WheelPuzzle linkedWheel;
    public float turnSpeed = 3;
    public int wheelSize = 9;
    public int wheelValue = 1;
    //public bool random = false;
    

    public void SetUp(int position) //randomizes the starting value and rotates them accordingly
    {
        /* if (random)
         {
             wheelValue = Random.Range(1, 10); //randomization
         }*/
        wheelValue = position;
        transform.Rotate(0, 0, (360 / wheelSize * (wheelValue - 1))); //sets initial position

    }

    void Interact() //called when interact touches them
    {
        RotateWheel(true, true);
        //  Controller.CheckVictory();
        Controller.Sum();
        
    }

    public int getWheelValue() //gets current number on wheel
    {
        return wheelValue;
    }

    public void RotateWheel(bool animation, bool linked) //rotates the wheel, animation makes it instant or slow, linked affects if the linked wheel turns
    {
        if(animation) //turns wheel slow enough for player to see
        {
            StartCoroutine("RotateAnimation");
            if (linked)
            {
                linkedWheel.RotateWheel(true, false);//rotates wheel on linked wheel
            }

        }
        else //instant turn wheel (for internal calculation eg. shuffling of wheels)
        {
            transform.Rotate(0, 0, (360 / wheelSize));
            if (linked)
            {
                linkedWheel.RotateWheel(false, false);//rotates wheel on linked wheel
            }
        }
        AddValue();
 
    }
    

    void AddValue()//makes sure numbers wrap around after hitting the max number
    {
        //changes the value on wheel
        if (wheelValue >= wheelSize)//wraps around max value
        {
            wheelValue = 1;
        }
        else
        {
            wheelValue++;
        }
    }


    //turns wheel visibly
    IEnumerator RotateAnimation()//plays the rotation animation
    {
        float rotationPerTick, amountRotated =0;
        int rotateAmount = 360 / wheelSize;
        bool EndLoop = false;

        while(!EndLoop)
        {
            rotationPerTick = rotateAmount * Time.deltaTime * turnSpeed;
            transform.Rotate(0, 0, rotationPerTick);
            amountRotated = amountRotated + rotationPerTick;
            if(amountRotated == rotateAmount)
            {
                EndLoop = true;
            }
            else if (amountRotated > rotateAmount)
            {
                transform.Rotate(0, 0, -(amountRotated-rotateAmount)); //rotates the wheel backwards to reach exact angle
                EndLoop = true;
            }
            yield return null;
        }
    }
}
