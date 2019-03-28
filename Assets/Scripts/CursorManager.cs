using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public static CursorManager Instance;
    public Texture2D cursorDefault;
    public Texture2D inspect;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;
    // Start is called before the first frame update

    private void Awake()
    {
        if (Instance == null) Instance = this;//assign self as singleton if none exists
        else if (Instance != this) Destroy(this.gameObject);//if singleton exists, kill self

        DontDestroyOnLoad(this.gameObject);
    }
    void Start()
    {
        DefaultCursor();
    }


    public void InspectCursor()
    {
        Cursor.SetCursor(inspect, hotSpot, cursorMode);
    }

    public void DefaultCursor()
    {
        Cursor.SetCursor(cursorDefault, hotSpot, cursorMode);
    }
}
