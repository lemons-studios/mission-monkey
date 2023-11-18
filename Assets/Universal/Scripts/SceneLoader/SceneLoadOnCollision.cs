using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadOnCollision : MonoBehaviour
{
    public string sceneToLoad;

    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log("load scene");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
