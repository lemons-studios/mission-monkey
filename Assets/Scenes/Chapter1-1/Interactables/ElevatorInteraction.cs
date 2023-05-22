using UnityEngine;
using UnityEngine.Video;

public class ElevatorInteraction : Interactable
{
    public GameObject Elevator;
    public GameObject PausedPlayer;
    public VideoPlayer ElevatorClipPlayer;
    private bool ElevatorEventTriggered;

    protected override void Interact()
    {
        ElevatorEventTriggered = !ElevatorEventTriggered;
        Elevator.GetComponent<Animator>().SetBool("Triggered", ElevatorEventTriggered);
        playVideo();
    }

    private void playVideo()
    {
        if (!ElevatorClipPlayer.isPlaying)
        {
            // I can't find a way to make a video display on a material, so the gameobject in front of the video player is black before the video plays
            // Once the player triggers the interaction, the gameobject in front of the video player gets destroyed and the video player "Resumes" the playback of the video
            Destroy(PausedPlayer);
            ElevatorClipPlayer.Play();
        }
    }
}