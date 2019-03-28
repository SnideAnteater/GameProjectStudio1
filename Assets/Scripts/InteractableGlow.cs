using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGlow : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    SpriteRenderer sprite;
    Color normal;
    Camera mainCam;
    public Color glow = new Color(255,200,0,255);
    // Start is called before the first frame update

    private Shader shaderGUItext;
    private Shader shaderSpritesDefault;
    void Start()
    {
        
        sprite = GetComponent<SpriteRenderer>();
        normal = sprite.color;
        mainCam = Camera.main;


       // shaderGUItext = Shader.Find("GUI/Text Shader");
       // shaderSpritesDefault = Shader.Find("Sprites/Default"); // or whatever sprite shader is being used
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void OnMouseEnter()
    {
 
        sprite.color = glow;
        //  Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        CursorManager.Instance.InspectCursor();
        //  sprite.material.shader = shaderGUItext;
        //   sprite.color = glow;
    }

    private void OnMouseExit()
    {
        sprite.color = normal;
        //  Cursor.SetCursor(null, Vector2.zero, cursorMode);

        CursorManager.Instance.DefaultCursor();
        //  sprite.material.shader = shaderSpritesDefault;
        //   sprite.color = Color.white;
    }
}
