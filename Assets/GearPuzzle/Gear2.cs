using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gear2 : MonoBehaviour
{
    public Transform gear;
    public Transform gearAnswer;
    public GameObject AnswerGear;
    public float positionX, positionY;

    private Vector2 initialPosition;
    private Vector2 mousePosition;
    private float deltaX, deltaY;

    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        deltaX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x - transform.position.x;
        deltaY = Camera.main.ScreenToWorldPoint(Input.mousePosition).y - transform.position.y;
    }

    private void OnMouseDrag()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector2(mousePosition.x - deltaX, mousePosition.y - deltaY);
    }

    private void OnMouseUp()
    {
        if(Mathf.Abs(transform.position.x - gearAnswer.position.x ) <= positionX && 
            Mathf.Abs(transform.position.y - gearAnswer.position.y) <= positionY)
        {
            Destroy(this.gameObject);
            AnswerGear.SetActive(true);
        }
        else
        {
            transform.position = new Vector2(initialPosition.x, initialPosition.y);
        } 
    }
   
}
