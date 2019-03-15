using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class RiddlePuzzleNew : MonoBehaviour
{
    public static RiddlePuzzleNew Instance { get; private set; }
    [SerializeField] private GameObject panel;
    [SerializeField] private Text label;
    [SerializeField] private Button choice1;
    [SerializeField] private Button choice2;
    [SerializeField] private Button choice3;

    Action<int> buttonCallback;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        //when buttons are pressed, delegate to the respective functions
        choice1.onClick.AddListener(OnButton1Press);
        choice2.onClick.AddListener(OnButton2Press);
        choice3.onClick.AddListener(OnButton3Press);
    }

    public void ShowPrompt(string content, Action<int> callback = null)
    {
        label.text = content;
        this.buttonCallback = callback;
        panel.SetActive(true);
    }

    void OnButton1Press()
    {
        Debug.Log("1 Pressed");
        panel.SetActive(false);
        if (buttonCallback != null) buttonCallback(1);
    }

    void OnButton2Press()
    {
        Debug.Log("2 Pressed");
        panel.SetActive(false);
        if (buttonCallback != null) buttonCallback(2);
    }

    void OnButton3Press()
    {
        Debug.Log("3 Pressed");
        panel.SetActive(false);
        if (buttonCallback != null) buttonCallback(3);
    }
}
