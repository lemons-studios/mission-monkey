using UnityEngine;

public class VaultOntoObject
{
    private string vaultableTag = "Vaultable";


    public void Vault(float maxVaultRange, GameObject vaultRayStartPoint, Animator vaultAnimator = null)
    {
        var vaultRayTransform = vaultRayStartPoint.transform;
        RaycastHit hit;
        if(Physics.Raycast(vaultRayTransform.position, vaultRayTransform.forward, out hit, maxVaultRange))
        {
            if(hit.collider.CompareTag(vaultableTag))
            {
                Debug.Log("Hit vaultable");
                if(vaultAnimator != null)
                {

                }
            }
            else
            {
                Debug.Log("Raycast did not hit any vaultable objects");
            }
        }
    }
}
