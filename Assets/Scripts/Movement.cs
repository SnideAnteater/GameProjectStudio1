using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Camera cam;
    public float playerSpeed = 4f;
    //private float currentSpeed;
   // public int floorRatio =5;
    Vector3 lastClick;
    float playerY;
    float playerX;



  
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        playerY = transform.position.y;
        playerX = transform.position.x;
        lastClick = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float step = playerSpeed * Time.deltaTime; // calculates the speed based on delta

            if (Input.GetButtonDown("Fire1"))
            {
                
                   
                    lastClick = cam.ScreenToWorldPoint(Input.mousePosition);
                    lastClick = new Vector3(lastClick.x, playerY, 0f);
                
            }
        
       
        

        transform.position = Vector3.MoveTowards(transform.position, lastClick, step);
        

    }

}
