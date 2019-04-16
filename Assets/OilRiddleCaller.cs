using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilRiddleCaller : MonoBehaviour
{


    public void Interact()
    {
        OilRiddlePrompt.Instance.ShowRiddle();
    }
}
