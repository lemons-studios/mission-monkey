using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoadOnCollision : MonoBehaviour
{
    // public int sceneNumber;
    [Tooltip("Only assign if the speed of the player is under the default value before loading a scene")]
    public PlayerMotor motor;
    private int DefaultSpeed, DefaultSprintSpeed;

    private void Start()
    {
        
    }

    public void OnTriggerEnter(UnityEngine.Collider other)
    {
        Debug.Log("load scene");
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        if(motor != null)
        {
            motor.speed = default;
            motor.sprintSpeed = default;
        }
    }
}
