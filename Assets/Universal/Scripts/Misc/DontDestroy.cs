using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    // Stolen Directly from unity docs
    // Why does unity have to be like this i've been trying to figure this out for like 30 minutes now

    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
