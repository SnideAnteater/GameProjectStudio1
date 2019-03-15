using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorForPuzzle : MonoBehaviour
{
    public int levelIndex;
    GameObject player;
    public enum puzzleType : int { ColorCombo = 0, WheelCombo };
    public puzzleType typeOfPuzzle;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");


        if (!GameManager.Instance.roomData[GameManager.Instance.currentRoomID].puzzleAssigned)
        {
            switch (typeOfPuzzle)
            {
                case puzzleType.ColorCombo:
                    GameManager.Instance.givePuzzleId("Color");//get id
                    break;
                case puzzleType.WheelCombo:
                    GameManager.Instance.givePuzzleId("Wheel");//get id
                    break;
            }


        }

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
        print("CHANGE");
        // GameManager.Instance.prevRoomLocation = player.transform.position;
        GameManager.Instance.ChangeSceneForPuzzle(levelIndex, player.transform.position);
    }


}
