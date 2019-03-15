using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RiddlePromptControl : MonoBehaviour
{
    public string riddle;
    public string choice1, choice2, choice3;
    public Text buttonText1;
    public Text buttonText2;
    public Text buttonText3;
    public enum choices :int {Choice1=1,Choice2,Choice3}
    public choices answer;
    public int oilLoss = 10;//punishment for wrong answer
    public void Interact()
    {
        buttonText1.text = choice1;
        buttonText2.text = choice2;
        buttonText3.text = choice3;
        ShowRiddle();
    }

    void ShowRiddle()
    {
        RiddlePuzzleNew.Instance.ShowPrompt(
              riddle,
             AnswerCallback
              );
    }

    void AnswerCallback(int choice)
    {
        if(choice == (int)answer)
        {
            print("WIN");//change this to victory stuff
        }
        else
        {
            GameManager.Instance.oil = GameManager.Instance.oil - oilLoss;
            print("WRONG ANSWER");
        }
    }
}
