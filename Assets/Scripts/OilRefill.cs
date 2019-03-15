using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilRefill : MonoBehaviour
{
    public OilBar Oil;
    public int refillAmount = 30;

    public void Interact()
    {
        GameManager.Instance.oil = GameManager.Instance.oil + 30;
        if(GameManager.Instance.oil>100)
        {
            GameManager.Instance.oil = 100;
        }
    }
}
