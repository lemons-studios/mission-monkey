using UnityEngine;

public class DisableEnableMonkey : MonoBehaviour
{
    public GameObject Monkey, MonkeyInPod, EscapePod;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monkey"))
        {
            Monkey.SetActive(false);
            MonkeyInPod.SetActive(true);
            EscapePod.GetComponent<Animator>().SetBool("MonkeyInEscapePod", true);
        }
    }
}
