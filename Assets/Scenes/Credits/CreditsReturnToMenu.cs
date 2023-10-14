using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsReturnToMenu : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }


    public void CreditsLoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
