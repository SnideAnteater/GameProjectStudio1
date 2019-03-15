using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OilBar : MonoBehaviour
{
    public static float oil = 100f;
    public float burnRate = 100f;//affects how fast oil runs out
    float burnProgress = 0f;
    Vector3 originalScale;
    Vector3 currentScale;
    // Start is called before the first frame update
    public GameObject fillbar;
    public bool running = true;
    void Start()
    {


        //gets data from lanternSystem
         originalScale = fillbar.transform.lossyScale; //(uncomment if bar is not duplicate child of blank bar)
        print(originalScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            //print(burnProgress); //testing
            burnProgress = burnProgress + burnRate * Time.deltaTime;
            if (burnProgress >= 10)//reduces oil when counter reaches 10
            {
                burnProgress = 0f;
                GameManager.Instance.oil = GameManager.Instance.oil - 1;
                if (GameManager.Instance.oil < 0)
                {
                    SceneManager.LoadScene(0);
                }
            }
            currentScale= new Vector3(originalScale.x / 100 * oil, originalScale.y, 0f); //(uncomment if bar is not duplicate child of blank bar)
            //currentScale = new Vector3(oil / 100, 1, 0); //(comment if bar is not duplicate child of blank bar)
            if (currentScale.x >= 0)
            {
                fillbar.transform.localScale = currentScale;
            }
        }
       
        
    }
   /* public float GetOil()
    {
        return oil;
    }

    public void refillOil(int amount)
    {
        oil = oil + amount; //for oil refilling function

        if (oil >= 100)//oil cap (comment this out if we don't have an oil cap but I think the bar will break)
        {
            oil = 100;
        }
    }

    public void loseOil(int amount)
    {
        oil = oil - amount;
    }*/
}

