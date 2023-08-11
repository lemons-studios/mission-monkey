using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

public class AiAttack : MonoBehaviour
{
    public GameObject BulletProjectile;
    private GameObject Player;
    public GameObject[] FirePoints;
    public float DamageToPlayerMin, DamageToPlayerMax, ProjectileSpeed;

    private void Start()
    {
        Player = GetComponent<AiNavAndFov>().Player;
        if (Player == null)
        {
            Debug.LogError("Player is not referenced on " + gameObject.name);
        }
        StartCoroutine(playerRangeCheck());
    }
    private IEnumerator playerRangeCheck()
    {
        while (true)
        {
            
        }
    }
    async void FireBulletRays()
    {
        foreach (GameObject i in FirePoints)
        {
            Ray hitRay = new Ray(i.transform.position, transform.forward);
            RaycastHit hit;
            float DistanceToPlayer = Vector3.Distance(BulletProjectile.transform.position, Player.transform.position);
            int DistanceFloored = Mathf.FloorToInt(DistanceToPlayer);

            if (Physics.Raycast(hitRay, out hit))
            {
                GameObject HitObject = hit.collider.gameObject;
                if (HitObject == Player)
                {
                    while (DistanceFloored != 0)
                    {
                        await Task.Yield();
                    }
                }
                else if (HitObject != Player)
                {
                    // Does Nothing For Now
                    return;
                }
            }
        }
    }
}