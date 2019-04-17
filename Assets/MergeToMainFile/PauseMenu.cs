using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingPanel;

    private void Start()
    {
        pausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        settingPanel.SetActive(false);
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        settingPanel.SetActive(false);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void ToSetting()
    {
        settingPanel.SetActive(true);
        pausePanel.SetActive(false);
    }
}
