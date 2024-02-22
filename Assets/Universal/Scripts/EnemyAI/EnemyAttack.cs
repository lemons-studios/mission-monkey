using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public GameObject attackPoint;
    public int damageAmount;
    public bool isAttackPrecise = true;
    public bool randomizeDamage;


    public void DirectHitAttack()
    {
        // Fire a raycast towards the player and check if it hits, then do the damage stuff if it hits
        if (isAttackPrecise)
        {
            RaycastHit hit;
            Ray ray = new Ray(attackPoint.transform.position, Vector3.forward);

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider.GetComponent<PlayerHealth>() != null)
                {
                    if(randomizeDamage) hit.collider.GetComponent<PlayerHealth>().DamagePlayerRandom(damageAmount, 0.5f, 2.0f);
                    else hit.collider.GetComponent<PlayerHealth>().DamagePlayer(damageAmount);
                }
            }
        }
        else
        {
            // TODO: Imprecise aiming of raycast
        }
    }

    public void AreaOfEffectAttack()
    {
        if(isAttackPrecise)
        {

        }
        else
        {
            // TODO (Again): Imprecise aiming of both the spherecast and the raycast used in this method
        }
    }
}
