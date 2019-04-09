using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class doorTest : MonoBehaviour
{
    public int levelIndex;

    void Update()
    {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene(levelIndex);
            }
    }
}
