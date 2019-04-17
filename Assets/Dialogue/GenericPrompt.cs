using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GenericPrompt : MonoBehaviour
{
    public static GenericPrompt Instance { get; private set; }
    [SerializeField] private GameObject panel;
    [SerializeField] private Text label;
    [SerializeField] private Button nextButton;

    Action<bool> buttonCallback;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance != this) Destroy(gameObject);

        //when buttons are pressed, delegate to the respective functions
        nextButton.onClick.AddListener(OnNextButtonPress);
       // DontDestroyOnLoad(this.gameObject);
    }

    public void ShowPrompt(string content, Action<bool> callback = null)
    {
        label.text = content;
        this.buttonCallback = callback;
        panel.SetActive(true);
    }

    void OnNextButtonPress()
    {
        Debug.Log("Next Pressed");
        panel.SetActive(false);
        if (buttonCallback != null) buttonCallback(true);
    }

    public void EndDialogue()
    {
        panel.SetActive(false);
    }

  
    }
