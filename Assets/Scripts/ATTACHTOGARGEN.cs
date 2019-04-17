using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ATTACHTOGARGEN : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(GameManager.Instance !=null)
        GameManager.Instance.Restart();
    }


}
