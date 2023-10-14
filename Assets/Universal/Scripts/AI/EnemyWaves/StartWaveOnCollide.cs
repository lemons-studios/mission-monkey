using UnityEngine;

public class StartWaveOnCollide : EnemyWaves
{
    public Animator Chapter1_2WaveClearAnimator;
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered");
        gameObject.GetComponent<Collider>().enabled = false;
        StartWaves();
    }
    protected override void OnFinalWaveComplete()
    {
        base.OnFinalWaveComplete();
        if(Chapter1_2WaveClearAnimator != null)
        {
            Chapter1_2WaveClearAnimator.SetBool("IsWaveCleared", true);
        }
    }
}