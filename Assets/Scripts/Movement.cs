using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    Camera cam;
    public float playerSpeed = 4f;
    Vector3 lastClick;
    float playerY;
    float playerZ;
    float newPlayerX;
    float oldPlayerX;
    public bool isMove;
    public bool NotMove;
    SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        playerY = transform.position.y;
        playerZ = transform.position.z;
        newPlayerX = transform.position.x;
        oldPlayerX = transform.position.x;
        lastClick = transform.position;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    void Move()
    {
        float step = playerSpeed * Time.deltaTime; // calculates the speed based on delta

        if (Input.GetButtonDown("Fire1"))
        {
            lastClick = cam.ScreenToWorldPoint(Input.mousePosition);
            lastClick = new Vector3(lastClick.x, playerY, playerZ);
            newPlayerX = lastClick.x;
            if(newPlayerX > oldPlayerX)
            {
                isMove = true;
                NotMove = false;
                m_SpriteRenderer.flipX = false;
            }
            else if (newPlayerX < oldPlayerX)
            {
                isMove = true;
                NotMove = false;
                m_SpriteRenderer.flipX = true;
            }

        }
        transform.position = Vector3.MoveTowards(transform.position, lastClick, step);
        if (transform.position.x == newPlayerX)
        {
            NotMove = true;
            isMove = false;
        }
        oldPlayerX = lastClick.x;

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

}
