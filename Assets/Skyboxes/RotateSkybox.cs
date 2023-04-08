using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;
 
public class RotateSkybox : MonoBehaviour
{
 
    [SerializeField] Volume volume;
    HDRISky sky;
    public float RotateSpeed = 0.02f;
 
    private void Start()
    {
        volume.profile.TryGet(out sky);
    }
 
    private void FixedUpdate()
    {
        /// ROTATE HDRI SKYBOX
        sky.rotation.value = (sky.rotation.value + RotateSpeed) % 360;   
    }
}