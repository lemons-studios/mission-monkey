using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Video;

public class ComputerFocus : Interactable
{
    public GameObject FakeMonitor;
    public GameObject monitor;
    //public Camera PlayerCam;
    public Vector3 MonitorCameraOffset;
    /* public AudioSource MonitorSound;
    public VideoPlayer CaptchaPlayer; */
    private bool EventFinishedDebug = false;

    protected override void Interact()
    {
        //transform.position = monitor.transform.position + MonitorCameraOffset;
        Destroy(FakeMonitor);
        //MonitorSound.Play();
        //CaptchaPlayer.Play();
        SpawnWave1.isEventReady = true;
    }
    public void Update()
    {
        if (/*CaptchaPlayer.time >= CaptchaPlayer.clip.length*/ EventFinishedDebug == true)
        {
            //isEventReady = true;
        }
    }
}
