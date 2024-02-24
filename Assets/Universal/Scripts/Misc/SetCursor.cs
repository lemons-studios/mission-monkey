using UnityEngine;
using UnityEngine.SceneManagement;

public class SetCursor : MonoBehaviour
{
    public Texture2D cursorTexture;

    private void Start()
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void Update() 
    {
        if(Time.timeScale != 0 && SceneManager.GetActiveScene().name != "MainMenu")
        {
            Cursor.visible = false;
        }
        else
        {
            Cursor.visible = true;
        }
    }
}

