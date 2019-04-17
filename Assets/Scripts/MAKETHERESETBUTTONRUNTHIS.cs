using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAKETHERESETBUTTONRUNTHIS : MonoBehaviour
{
public void ResetData()
    {
        GameManager.Instance.Restart();
    }


}
