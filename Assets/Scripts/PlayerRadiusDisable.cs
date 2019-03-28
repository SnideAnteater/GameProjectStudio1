using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRadiusDisable : MonoBehaviour
{
     Collider2D col;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.player != null && col != null)//player radius disable
        {
            if (Vector3.Distance(GameManager.Instance.player.transform.position, this.transform.position) <= distance)
            {
                col.enabled = true;

            }
            else
            {
                col.enabled = false;

            }
        }
    }
}
