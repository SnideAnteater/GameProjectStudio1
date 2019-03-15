using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourPuzzleController : MonoBehaviour
{
    public ColourBox[] colorBoxArray = new ColourBox[3];
    public ColorAnswerBox colorAnswerBox;
    public enum colors : int { Red = 0, Yellow, Blue, Orange, Violet, Green, White };
    public Text answerText;
    Stack<colors> answerBox = new Stack<colors>();
    public colors answer;
    //public bool random = false;
    public int oilLoss = 10;
    //public Door door;
    private int puzzleID;
    // Start is called before the first frame update
    void Start()
    {

        getID();

        for (int i = 0; i < 3; i++)
        {
            colorBoxArray[i].setDataColor(i);
        }
        initializeBox();
        colorAnswerBox.initialize();
        colorAnswerBox.setDataColor((int)colors.White); //starts off white
        answerColorSetter();
        answer = (colors)GameManager.Instance.colorPuzzleAnswer[puzzleID];
        /* if(random)
         {
         answer = (colors)Random.Range((int)colors.Orange, (int)colors.Green + 1);
         }*/
        answerText.text = "Answer: " + answer.ToString();

    }

    public bool answerFull()
    {
        if (answerBox.Count < 2)//check if there's already 2 colours inside answer count
        {

            return false;
        }
        else
        {

            return true;
        }

    }

    public void removeColor()
    {
        colors temp = answerBox.Pop();
        colorBoxArray[(int)temp].toggleBox(true);


    }

    public void colorSelect(int c) // adds selected color
    {
        answerBox.Push((colors)c);

        answerColorSetter();


        // if(answerFull()) 
        //   {
        //      checkVictory();
        // }
    }


    colors combineColor(Stack<colors> temp)//combines colours in answer box
    {
        Stack<colors> tempAnswerBox = new Stack<colors>(temp);
        int stackSize = tempAnswerBox.Count;
        colors[] color = new colors[stackSize];
        for (int i = 0; i < stackSize; i++)
        {
            color[i] = tempAnswerBox.Pop();

        }
        if (stackSize == 2)
        {

            switch (color[0])//combines the colours
            {

                case colors.Red:
                    switch (color[1])
                    {
                        case colors.Yellow:
                            return colors.Orange;
                        case colors.Blue:
                            return colors.Violet;
                        default:
                            return colors.White;

                    }

                case colors.Yellow:
                    switch (color[1])
                    {
                        case colors.Red:
                            return colors.Orange;
                        case colors.Blue:
                            return colors.Green;
                        default:
                            return colors.White;
                    }

                case colors.Blue:
                    switch (color[1])
                    {
                        case colors.Red:
                            return colors.Violet;
                        case colors.Yellow:
                            return colors.Green;
                        default:
                            return colors.White;
                    }

                default:
                    return colors.White;
            }
        }
        else if (stackSize == 1)//if only single color
        {
            return color[0];
        }
        else
        {
            return colors.White; //defaults if none applicable
        }

    }

    public void checkVictory()//checks for victory condition
    {
        if (answer == combineColor(answerBox))
        {
            //victory condition
            GameManager.Instance.AddPuzzleReward(); //TEMP FUNCTION THAT OSENT DO SHIT
            answerText.text = "YOU WIN";// insert victory stuff here
            GameManager.Instance.roomData[GameManager.Instance.currentRoomID].puzzleSolved = true;
            GameManager.Instance.ReturnFromPuzzle();
        }
        else
        {
            GameManager.Instance.loseOil(oilLoss);
        }
    }

    public void answerColorSetter()//sets the data colour then changes the display colour
    {

        colorAnswerBox.setDataColor((int)combineColor(answerBox));
        answerColorDisplay();
    }

    void answerColorDisplay() // changes display colour
    {
        switch ((colors)colorAnswerBox.getDataColor())
        {
            case colors.Red:
                colorAnswerBox.setDisplayColor(1, 0, 0);
                break;
            case colors.Yellow:
                colorAnswerBox.setDisplayColor(1, 1, 0);
                break;
            case colors.Blue:
                colorAnswerBox.setDisplayColor(0, 0, 1);
                break;
            case colors.Orange:
                colorAnswerBox.setDisplayColor(1, 0.5f, 0);
                break;
            case colors.Violet:
                colorAnswerBox.setDisplayColor(1, 0, 1);
                break;
            case colors.Green:
                colorAnswerBox.setDisplayColor(0, 1, 0);
                break;
            case colors.White:
                colorAnswerBox.setDisplayColor(1, 1, 1);
                break;
        }
    }

    void initializeBox()
    {

        for (int i = 0; i < 3; i++)
        {
            colorBoxArray[i].initialize();
            switch ((colors)colorBoxArray[i].getDataColor())
            {
                case colors.Red:
                    colorBoxArray[i].setDisplayColor(1, 0, 0);
                    break;
                case colors.Yellow:
                    colorBoxArray[i].setDisplayColor(1, 1, 0);
                    break;
                case colors.Blue:
                    colorBoxArray[i].setDisplayColor(0, 0, 1);
                    break;
            }
        }
    }

    void getID()
    {
        /*  if (!GameManager.Instance.roomData[GameManager.Instance.currentRoomID].puzzleAssigned)
          {
              puzzleID = GameManager.Instance.givePuzzleId("Color");//get id
          }
          else
          {
              puzzleID = GameManager.Instance.roomData[GameManager.Instance.currentRoomID].puzzleId;
          }*/
        puzzleID = GameManager.Instance.roomData[GameManager.Instance.currentRoomID].puzzleId;
    }

    public void BackButton()
    {
        GameManager.Instance.ReturnFromPuzzle();
    }

    public void ResetButton()
    {
        int count = answerBox.Count;
        for (int i = 0; i < count; i++)
        {
            removeColor();
            answerColorSetter();
        }

    }
}
