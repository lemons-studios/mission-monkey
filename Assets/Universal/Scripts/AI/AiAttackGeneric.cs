using System.Threading.Tasks;
using UnityEngine;

public class AiAttackGeneric : MonoBehaviour
{
    public GameObject BulletProjectile, Player;
    public GameObject[] FirePoints;
    public float DamageToPlayerMin, DamageToPlayerMax, ProjectileSpeed;

    private void Start()
    {
        Player = AiFoV.Player;
    }

    async void FireBulletRays()
    {
        for (int i = 0; i < FirePoints.Length; i++)
        {
            Ray hitRay = new Ray(FirePoints[i].transform.position, transform.forward);
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
    protected virtual void AttackDetails()
    {
        // Empty since this will be filled out by the scripts inheriting this script
    }

    private void FixedUpdate()
    {
        if (Player == null)
        {
            Debug.LogError("Player Not Found! Script is either broken or someone forgot to assign the tag to the player lol");
        }
    }
}