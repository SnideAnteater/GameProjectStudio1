using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unlockStairs : MonoBehaviour
{
    public GameObject stairsUnlock;
    GameObject player;
    public int puzzlesBeforeUnlock;
    public string lockedMessage = "It's Locked.";

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    public void Interact()
    {
        if (GameManager.Instance.PuzzleSolvedCount() >= puzzlesBeforeUnlock)
        {
            stairsUnlock.SetActive(true);
            gameObject.SetActive(false);

        }
        else
            GenericPrompt.Instance.ShowPrompt(lockedMessage);
    }
}
