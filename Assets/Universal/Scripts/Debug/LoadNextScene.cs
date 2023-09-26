using UnityEngine.SceneManagement;

public class LoadNextScene : Interactable
{
    private int CurrentScene;
    private void Start()
    {
        CurrentScene = SceneManager.GetActiveScene().buildIndex;
    }

    protected override void Interact()
    {
        SceneManager.LoadScene(CurrentScene + 1);
    }
}
