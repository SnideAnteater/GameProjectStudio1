using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour {

    // call animator
    public Animator anim;
    private Movement movement;
    //Check the bool which item is equiped
    public bool NoItem = true;
    public bool HasItem = false;
    public bool FullSet = false;


    private void Start()
    {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
    }

    private void Update()
    {
        Movement();
        if(Input.GetKeyDown(KeyCode.K))
        {
            NoItem = false;
            HasItem = true;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            HasItem = false;
            FullSet = true;
        }
    }

    void Movement()
    {
        if(NoItem == true)
        {
            if(movement.isMove == true || movement.NotMove == false)
            {
                anim.SetBool("isWalkNoItem", true);
                anim.SetBool("isIdleNoItem", false);
            }
            else
            {
                anim.SetBool("isWalkNoItem", false);
                anim.SetBool("isIdleNoItem", true);
            }
        }
        else if(HasItem == true)
        {
            if (movement.isMove == true || movement.NotMove == false)
            {
                anim.SetBool("isWalkLamp", true);
                anim.SetBool("isIdleLamp", false);
            }
            else
            {
                anim.SetBool("isWalkLamp", false);
                anim.SetBool("isIdleLamp", true);
            }
        }
        else if(FullSet == true)
        {
            if (movement.isMove == true || movement.NotMove == false)
            {
                anim.SetBool("isWalkFull", true);
                anim.SetBool("isIdleFull", false);
            }
            else
            {
                anim.SetBool("isWalkFull", false);
                anim.SetBool("isIdleFull", true);
            }
        }
    }
}
