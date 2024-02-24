using UnityEngine;

public class UnlockCursorOnSceneLoad : MonoBehaviour
{
    private void OnEnable()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
