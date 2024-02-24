using UnityEngine;

public class SetCursor : MonoBehaviour
{
    public Texture2D cursorTexture;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }
    
    private void Update() 
    {
        if(Time.timeScale != 0)
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}

