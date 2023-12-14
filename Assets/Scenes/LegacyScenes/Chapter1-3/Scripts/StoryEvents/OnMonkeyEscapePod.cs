using UnityEngine;

public class OnMonkeyEscapePod : MonoBehaviour
{
    public GameObject EscapePodParent;

    private void OnEnable()
    {
        EscapePodParent.GetComponent<Animator>().SetBool("MonkeyInEscapePod", true);
    }
}