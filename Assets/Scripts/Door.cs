using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Door : MonoBehaviour
{
    public int levelIndex;
    GameObject player;
    public int puzzlesBeforeUnlock;
    public string lockedMessage = "It's Locked.";

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    /* void OnTriggerStay2D(Collider2D other)
     {
         if (other.CompareTag("Player"))
         {
             if(Input.GetButtonDown("Fire1"))
             {
                 SceneManager.LoadScene(levelIndex);
             }

         }
     }*/
    public void Interact()
    {
        if (GameManager.Instance.PuzzleSolvedCount() >= puzzlesBeforeUnlock)
        {
            print("CHANGE");
            // GameManager.Instance.prevRoomLocation = player.transform.position;
            GameManager.Instance.ChangeScene(levelIndex, player.transform.position);
        }
        else
            GenericPrompt.Instance.ShowPrompt(lockedMessage);
        
    }


}
