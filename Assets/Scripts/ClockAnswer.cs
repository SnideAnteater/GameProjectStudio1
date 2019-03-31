using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockAnswer : MonoBehaviour
{
    public ClockPuzzle clock;
    bool hourHand;
    bool minHand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
       
        if(other.gameObject == clock.minHand)
        {
           clock.minPosition = true;
        }
        if(other.gameObject == clock.hourHand)
        {
            clock.hourPosition = true;
        }

        
    }
    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject == clock.minHand)
        {
            clock.minPosition = false;
        }
        if (other.gameObject == clock.hourHand)
        {
            clock.hourPosition = false;
        }
    }
   
}
