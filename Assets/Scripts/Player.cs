using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void OnEnable()
    {
        GameManager.Instance.player = this.gameObject;
        GameManager.Instance.RepositionPlayer();
    }

    private void Start()
    {
        GameManager.Instance.player = this.gameObject;//for first scene when manager is created, awake is too fast 
    }


}
