using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LanternSystem : MonoBehaviour
{
    //public OilBar oil;

    public static float oil = 100f;
    public float burnRate = 100f;//affects how fast oil runs out
    float burnProgress = 0f;
    Vector3 minDarknessSize;
    public float maxDarknessSizeMultiplier = 3.6f;
    float currentLight;
    SpriteRenderer render;
    Color darknessLevel;
    public float maxBrightness = 70;
    public float minBrightness = 20;
    //public bool DataManagementMode = false;
    // Start is called before the first frame update
    void Start()
    {
        // oil = StartingOil;
        render = GetComponent<SpriteRenderer>();
        minDarknessSize = transform.lossyScale;
        darknessLevel = render.color;
    }

    // Update is called once per frame
    void Update()
    {
        burnProgress = burnProgress + burnRate * Time.deltaTime;
        if (burnProgress >= 10)//reduces oil when counter reaches 10
        {
            burnProgress = 0f;
            GameManager.Instance.oil = GameManager.Instance.oil - 1;
            if (GameManager.Instance.oil < 0)
            {
                GameManager.Instance.GameOver();
            }
        }

        currentLight = maxDarknessSizeMultiplier / 100 * GameManager.Instance.oil; //calculate the size of the darkness
        if (minDarknessSize.x * currentLight >= minDarknessSize.x)
        {
            transform.localScale = new Vector3(minDarknessSize.x * currentLight, minDarknessSize.y * currentLight, 0);//if oil is above 100% max darkness size
        }
        if (GameManager.Instance.oil <= maxBrightness && GameManager.Instance.oil >= minBrightness)
        {
            darknessLevel.a = 1 - (GameManager.Instance.oil / 100);
            render.color = darknessLevel;
        }
        else
        {
            if (GameManager.Instance.oil >= maxBrightness)
            {
                darknessLevel.a = 1 - (maxBrightness / 100);
                render.color = darknessLevel;
            }
            if (GameManager.Instance.oil <= minBrightness)
            {
                darknessLevel.a = 1 - (minBrightness / 100);
                render.color = darknessLevel;
            }
        }
    }

}



