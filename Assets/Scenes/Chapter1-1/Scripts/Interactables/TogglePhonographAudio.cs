using UnityEngine;

public class TogglePhonographAudio : Interactable
{
    private bool IsMusicPlaying = true;
    public AudioSource PhonographAudio;
    private Animator DiskSpin;

    private void Start()
    {
        promptMessage = "Turn the music off";
        DiskSpin = GetComponent<Animator>();
    }

    
    protected override void Interact()
    {
        base.Interact();
        SetAudio();
    }

    private void SetAudio()
    {
        switch (IsMusicPlaying)
        {
            case true:
                DiskSpin.SetBool("Playing", false);
                PhonographAudio.Pause();
                promptMessage = "Turn the music on";
                IsMusicPlaying = false;
                break;

            case false:
                DiskSpin.SetBool("Playing", true);
                PhonographAudio.Play();
                promptMessage = "Turn the music off";
                IsMusicPlaying = true;
                break;
        }
    }
}