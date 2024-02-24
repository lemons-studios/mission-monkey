using System.Collections;
using UnityEngine;
public class BulletLogic : MonoBehaviour
{
    private float destroyTime = 1.25f;

    private void Start()
    {
        StartCoroutine(WaitUntilDestroy());
    }
    private IEnumerator WaitUntilDestroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }
}

