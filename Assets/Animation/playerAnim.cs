using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAnim : MonoBehaviour {

    // call animator
    public Animator anim;
    MovePlayerButtons playerMove;
    public GameObject button;
    //Check the bool which item is equiped
    public bool NoItem = true;
    public bool HasItem = false;
    public bool FullSet = false;

    private void Start()
    {
        playerMove = button.GetComponent<MovePlayerButtons>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        if(NoItem == true)
        {
            if(playerMove.moveLeft == true || playerMove.moveRight == true)
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
            if (playerMove.moveLeft == true || playerMove.moveRight == true)
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
            if (playerMove.moveLeft == true || playerMove.moveRight == true)
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
