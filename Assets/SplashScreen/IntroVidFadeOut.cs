using System.Collections;
using UnityEngine;
using UnityEngine.Video;

public class IntroVidFadeOut : MonoBehaviour
{
    private VideoPlayer VideoPlayer;
    private bool VideofinishedFadingOut = false;
    public Animation CameraIntroAnimation;
    void Awake()
    {
        VideoPlayer = GetComponent<VideoPlayer>();
        VideoPlayer.loopPointReached += OnMovieFinished; // loopPointReached is the event for the end of the video
    }

    void OnMovieFinished(VideoPlayer player)
    {
        Debug.Log("Event for movie end called");
        player.Stop();
        player.enabled = false;
        CameraIntroAnimation.Play();
    }
}