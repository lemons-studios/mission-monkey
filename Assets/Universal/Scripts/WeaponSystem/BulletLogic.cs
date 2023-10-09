using System.Collections;
using UnityEngine;

public class BulletLogic : MonoBehaviour
{
    private float DestroyTime = 0.75f;
    public int ProjectileDamage;

    private void Start()
    {
        StartCoroutine(WaitUntilDestroy());
    }

    private IEnumerator WaitUntilDestroy()
    {
        yield return new WaitForSeconds(DestroyTime);
        Destroy(gameObject);
    }
}