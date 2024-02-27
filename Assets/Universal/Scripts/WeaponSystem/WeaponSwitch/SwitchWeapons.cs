using UnityEngine;

public class SwitchWeapons : MonoBehaviour 
{
    public GameObject[] weapons;
    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = new PlayerInput();
        playerInput.OnFoot.SwitchWeapons.performed += ctx => SwitchToNextWeapon(ctx.ReadValue<Vector2>());
        playerInput.Enable();
    }    

    private void SwitchToNextWeapon(Vector2 scrollDelta)
    {
        int currentActiveWeapon = GetActiveWeapon();
        weapons[currentActiveWeapon].SetActive(false);
        int nextActiveWeapon = GetNextWeapon(Mathf.RoundToInt(scrollDelta.y), currentActiveWeapon);
        weapons[nextActiveWeapon].SetActive(true);
    }
    
    private int GetNextWeapon(int scrollDelta, int lastActiveWeapon)
    {
        int weaponToSetActive = 0;
        if (lastActiveWeapon + scrollDelta > weapons.Length)
        {
            weaponToSetActive = 0 + scrollDelta;
        }
        else if (lastActiveWeapon - scrollDelta < weapons.Length)
        {
            weaponToSetActive = weapons.Length - 1;
        }

        return weaponToSetActive;
    }

    private int GetActiveWeapon()
    {
        for (int i = 0; i < weapons.Length; i++)
        {
            if (weapons[i].activeSelf)
            {
                return i;
            }
        }

        return -1;  // This would default to the end of the array but I cannot think of a better way to handle errors rn it's 12am
    }
    
    private void OnDestroy() 
    {
        playerInput.Disable();    
    }
}