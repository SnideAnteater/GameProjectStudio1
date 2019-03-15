using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayerButtons : MonoBehaviour
{
    public GameObject canvas;
    //public Button right;
    public bool moveLeft, moveRight;
    public float speed = 4f;

    void OnEnable()
    {
        GameManager.Changed += SceneChangeReset;
    }


    void OnDisable()
    {
        GameManager.Changed -= SceneChangeReset;
    }



    private void Update()
    {
        if (GameManager.Instance.inPuzzle)
        {
            canvas.SetActive(false);

        }
        else
        {
            canvas.SetActive(true);
            // left.enabled = true;
            //right.enabled = true;
        }
        if (moveRight)
        {
            GameManager.Instance.player.transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if (moveLeft)
        {
            GameManager.Instance.player.transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveLeftRelease()
    {
        moveLeft = false;
    }
    public void MoveRight()
    {
        moveRight = true;
    }
    public void MoveRightRelease()
    {
        moveRight = false;
    }

    void SceneChangeReset()
    {
        moveLeft = false;
        moveRight = false;
    }
}
