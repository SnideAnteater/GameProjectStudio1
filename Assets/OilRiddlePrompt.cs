using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilRiddlePrompt : MonoBehaviour
{
    public const int RIDDLEAMT = 22;
    int random;
    public int oilReward = 25;
    public static OilRiddlePrompt Instance { get; private set; }
    private string riddle;
    //private string choice1, choice2, choice3;
    public Text buttonText1;
    public Text buttonText2;
    public Text buttonText3;
    //public enum choices : int { Choice1 = 1, Choice2, Choice3 }
    public int answer;
    public int oilLoss = 10;//punishment for wrong answer


    public string[] riddleData = new string[RIDDLEAMT];
    public string[] riddleChoice1Data = new string[RIDDLEAMT];
    public string[] riddleChoice2Data = new string[RIDDLEAMT];
    public string[] riddleChoice3Data = new string[RIDDLEAMT];
    public int[] riddleAnsData = new int[RIDDLEAMT];

    /*public struct riddles
    {
       
       public string riddle;
       public string choice1, choice2, choice3;
       public int ans;
    };

    public riddles[] riddleList = new riddles[RIDDLEAMT];*/

   
   


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        /*RIDDLE DATABASE
        for(int i=0; i<RIDDLEAMT; i++)
        {
            riddleList[i].riddle = riddleData[i];
            riddleList[i].choice1 = riddleChoice1Data[i];
            riddleList[i].choice1 = riddleChoice2Data[i];
            riddleList[i].choice1 = riddleChoice3Data[i];
            riddleList[i].ans = riddleAnsData[i];
        }
        */
    }


    public void ShowRiddle()
    {
        random = Random.Range(0, 22);
        riddle = riddleData[random];
        buttonText1.text = riddleChoice1Data[random];
        buttonText2.text = riddleChoice2Data[random];
        buttonText3.text = riddleChoice3Data[random];
        answer = riddleAnsData[random];

       OilRiddleManager.Instance.ShowPrompt(
              riddle,
             AnswerCallback
              );
    }

    void AnswerCallback(int choice)
    {
        if (choice == answer)
        {
            print("WIN");//change this to victory stuff
            GameManager.Instance.oil = GameManager.Instance.oil + oilReward;
            if(GameManager.Instance.oil > 100)
            {
                GameManager.Instance.oil = 100;
            }
        }
        else
        {
            GameManager.Instance.oil = GameManager.Instance.oil - oilLoss;
            print("WRONG ANSWER");
        }
    }

}
