using System.Collections;
using UnityEngine;
public class BulletLogic : MonoBehaviour
{
    private float DestroyTime = 1.25f;
    public int ProjectileDamage;
    private Ray BulletRay;
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
