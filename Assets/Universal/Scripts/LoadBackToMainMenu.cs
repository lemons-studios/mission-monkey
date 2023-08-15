using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadBackToMainMenu : MonoBehaviour
{
    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log("load scene");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
    }
}
