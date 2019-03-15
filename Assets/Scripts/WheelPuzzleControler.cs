using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WheelPuzzleControler : MonoBehaviour
{
    public static int numberOfWheels = 3;
    public WheelPuzzle[] Wheel = new WheelPuzzle[numberOfWheels];
    int currentSum = 0;
    public int answer = 0;
    public Text totalText, answerText;
    //public bool random=false;
    // public int prevScene;
    //  public Door door;
    public int oilLoss = 10;
    //public OilBar oil;
    private int puzzleID;
    // Start is called before the first frame update
    void Start()
    {
        getID();
        /*if (random)
        {
            answer = currentSum; //sets winning condition
            Shuffle();
        }*/
        answer = GameManager.Instance.wheelPuzzleAnswer[puzzleID, 0];
        SetUp();
        Sum();
        answerText.text = "TARGET VALUE : " + answer.ToString();//displays winning condition
        Shuffle();
    }

    //sets up the number wheels
    void SetUp()
    {
        for (int i = 0; i < numberOfWheels; i++)
        {
            Wheel[i].SetUp(GameManager.Instance.wheelPuzzleAnswer[puzzleID, i + 1]);
        }
    }

    void Shuffle() //randomly rotates wheels
    {
        for (int i = 0; i < numberOfWheels; i++)
        {
            for (int s = 0; s < Random.Range(1, 20); s++)
            {
                Wheel[i].RotateWheel(false, true);
            }
        }
        Sum();//to update currentSum
        while (TotalWin())//shuffles again if the current value is a victory
        {
            Shuffle();
            Sum();//to update CurrentSum
        }

    }

    public void Sum() // sums up the number on wheels
    {
        currentSum = 0;
        for (int i = 0; i < numberOfWheels; i++)
        {
            currentSum = currentSum + Wheel[i].getWheelValue();
        }
        totalText.text = "Total: " + currentSum.ToString();
    }

    public void CheckVictory()//causes victory and prints message
    {
        Sum();

        if (TotalWin())
        {
            GameManager.Instance.AddPuzzleReward();

            GameManager.Instance.roomData[GameManager.Instance.currentRoomID].puzzleSolved = true;
            GameManager.Instance.ReturnFromPuzzle();
            totalText.text = "YOU WIN"; //insert victory trigger here
        }
        else
        {
            GameManager.Instance.loseOil(oilLoss);
        }

    }

    bool TotalWin() // returns true if number if current number is same as answer, seperated for shuffling
    {
        if (currentSum == answer)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void getID()
    {
        /*if (!GameManager.Instance.roomData[GameManager.Instance.currentRoomID].puzzleAssigned)
        {
            puzzleID = GameManager.Instance.givePuzzleId("Wheel");//get id
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
}
