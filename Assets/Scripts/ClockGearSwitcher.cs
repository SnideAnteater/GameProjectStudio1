using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockGearSwitcher : MonoBehaviour
{
    public GameObject destination;
    public Canvas UI;
    public bool disableUI;

    void Interact()
    {
        Camera.main.transform.position = destination.transform.position;

        UI.enabled = !disableUI;
    }
}
