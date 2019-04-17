using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ATTACHTOEVERYROOM : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.currentRoomID = SceneManager.GetActiveScene().buildIndex;
    }


}
