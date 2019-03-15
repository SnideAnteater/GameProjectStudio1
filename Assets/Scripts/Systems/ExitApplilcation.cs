using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitApplilcation : MonoBehaviour
{
    // Start is called before the first frame update
    public Button button;

    void Start()
    {
        button.onClick.AddListener(Exit);
    }
    void Exit()
    {
        Application.Quit();
    }
}
