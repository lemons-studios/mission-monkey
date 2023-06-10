using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadOnCollision : MonoBehaviour
{
    // public int sceneNumber;

    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log("load scene");
        if (other.CompareTag("Player")) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        };
    }
}
