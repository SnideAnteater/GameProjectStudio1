using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDescriptUI : MonoBehaviour
{
    public static bool itemUIOpen = false;
    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("Fire 2"))
        {


            if (itemUIOpen)
            {
                Resume();

            }
            else
            {

                Pause();
            }
        }
    }

    void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        itemUIOpen = false;

    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        itemUIOpen = true;
    }
}
