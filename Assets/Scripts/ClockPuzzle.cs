using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ClockPuzzle : MonoBehaviour
{

    public GameObject minHand;
    public GameObject hourHand;
    private GameObject activeHand;
    bool clicked = false;
    //Vector2 lastClick;
    bool minHandActive = true;
    public float rotationSensitivity = 10f;
    public Collider2D answer;
    Collider2D minHandCol;
    Collider2D hourHandCol;
    public Text buttonText;
    public Text win;
    public bool gearSolved = false;

    public bool minPosition = false;
    public bool hourPosition = false;

    [SerializeField] private Button changeHand;
    // Start is called before the first frame update
    void Start()
    {
        changeHand.onClick.AddListener(OnChangeHandPress);
        minHandCol= minHand.GetComponent(typeof(Collider2D)) as Collider2D;
        hourHandCol = hourHand.GetComponent(typeof(Collider2D)) as Collider2D;
        activeHand = minHand;
    }

    // Update is called once per frame
    void Update()
    {
        /*if(clicked)
        {
            float dist = lastClick.x - Input.mousePosition.x;

            activeHand.transform.Rotate(0, 0, dist*rotationSensitivity);

        }*/

       /* if(Input.GetMouseButton(0) && clicked == false) //sets last clicked llocation
        {
            //  clicked = true;
            // lastClick = Input.mousePosition;
            activeHand.transform.Rotate(0, 0, -rotationSensitivity);
        }
        if(Input.GetMouseButtonUp(0))
        {
          //  clicked = false;
        }*/

        if(clicked && gearSolved)
        {
            activeHand.transform.Rotate(0, 0, -rotationSensitivity);
        }
    }

    private void OnMouseDown()
    {
        
        clicked = true;
    }

    private void OnMouseUp()
    {
        clicked = false;
        if (minPosition && hourPosition)
        {
            victory();
        }
    }


    void OnChangeHandPress()
    {
        minHandActive = !minHandActive;
        if(minHandActive)
        {
            activeHand = minHand;
            buttonText.text = "Minute Hand";
        }
        else
        {
            activeHand = hourHand;
            buttonText.text = "Hour Hand";
        }
    }

    public void victory()
    {
        GameManager.Instance.ClockReward(); 
        GameManager.Instance.roomData[GameManager.Instance.currentRoomID].clockFinished = true;
        GameManager.Instance.ReturnFromPuzzle();
        win.text = "WIN";
    }

    public void BackButton()
    {
        GameManager.Instance.ReturnFromPuzzle();
    }

    public void Interact()
    {
        //black to prevent nulls
    }

}
