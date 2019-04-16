using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadiusDisable : MonoBehaviour
{
     //Collider2D col;
    public float distance =4;
    // Start is called before the first frame update
    private int original;
    void Start()
    {
        //col = GetComponent<Collider2D>();
        original = gameObject.layer;

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.player != null)//player radius disable
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.position, this.transform.position) <= distance)
            {
                //col.enabled = true;
                if(gameObject.layer !=original)
                {
                    gameObject.layer = original;
                }
               

            }
            else
            {
                //col.enabled = false;
                if(gameObject.layer!=8)
                {
                    gameObject.layer = 8;
                }
                

            }
        }
    }
}
