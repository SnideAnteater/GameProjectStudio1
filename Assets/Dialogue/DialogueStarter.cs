using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueStarter : MonoBehaviour
{

    public string[] dialogue = new string[1];
    int progress = 0;
    public bool showPuzzleAnswer = false;

    public void Interact()
    {
        if (!showPuzzleAnswer)
        {
            progress = 0;
            ShowDialogue();
        }
        else
        {
            progress = 0;
            dialogue[0] = GameManager.Instance.GetPuzzleAnswer();
            ShowDialogue();
        }
    }

    void ShowDialogue()
    {
        GenericPrompt.Instance.ShowPrompt(
              dialogue[progress],
              NextCallback

              );
    }

    void NextCallback(bool result)
    {
        if (result == true && progress < dialogue.Length - 1)
        {
            progress++;
            print(progress);

            ShowDialogue();
        }
        else
        {
            GenericPrompt.Instance.EndDialogue();
        }
    }
}
