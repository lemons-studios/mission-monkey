using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Camera playerCamera;
    private PlayerInput playerInput;

    // Is assigned to later in Update()
    private Vector2 mouseDelta;

    private float rotationSpeedX = 1.0f;
    private float rotationSpeedY = 1.0f;

    private float maxPitch = 80.0f;
    private float minPitch = -80.0f;

    private float currentPitch = 0.0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        playerInput = new PlayerInput();
        // Unless changed later, the camera is a child of the player model
        playerCamera = GetComponentInChildren<Camera>();
        playerInput.Enable();
    }

    private void Update()
    {
        // Thanks to Phind AI for doing the Quaternion stuff because I can't wrap my head around it yet

        // Reads information being fed through the Look action in PlayerInput and assigns it to mouseDelta 
        // OnFoot.Look() is a pass through value 
        // This works on any input device (i.e. Mouse, Controller, Fire TV Stick, etc)

        mouseDelta = playerInput.OnFoot.Look.ReadValue<Vector2>();

        float rotationX = mouseDelta.x * rotationSpeedX;
        float rotationY = -mouseDelta.y * rotationSpeedY;

        // Clamp the maximum Y rotation on the camera to minPitch (-80 degrees) and maxPitch (80 degrees)
        currentPitch = Mathf.Clamp(currentPitch + rotationY, minPitch, maxPitch);
        rotationY = currentPitch;

        // Do some math I really don't understand at the moment for the rotation to work
        playerCamera.transform.localRotation = Quaternion.Euler(rotationY, 0, 0);
        transform.Rotate(0, rotationX, 0);

        // Reset Z rotation
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }

    // The next two methods are for the main menu to work, not much else has to be said about it
    public void SetRotationSpeed(float newRotationSpeed)
    {
        rotationSpeedX = newRotationSpeed;
        rotationSpeedY = newRotationSpeed;
    }

    public void SetFieldOfView(int newFieldOfView)
    {
        playerCamera.fieldOfView = newFieldOfView;
    }
}
