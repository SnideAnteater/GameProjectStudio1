using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DoorForInspect : MonoBehaviour
{
    public string levelName;
    GameObject player;

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
        print("CHANGE");
        // GameManager.Instance.prevRoomLocation = player.transform.position;
        GameManager.Instance.ChangeSceneInspect(levelName, player.transform.position);
    }


}
