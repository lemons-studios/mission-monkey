using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponsCore : MonoBehaviour
{
    private float BulletRange = Mathf.Infinity;

    public GameObject FirePoint;
    public float CooldownTime = 0.15f; // Default cooldown time for weapons, can be changed in the weapon classes
    public PlayerInput Input;
    public bool IsWeaponMelee;

    private void Awake()
    {
        Input = new PlayerInput();
        Input.OnFoot.Attack.started += Attack;
        Input.Enable();
    }

    public async void Attack(InputAction.CallbackContext context)
    {
        if(!IsWeaponMelee)
        {
            Debug.Log("Attacking With a gun!");

            if(context.phase == InputActionPhase.Performed)
            {
                Debug.Log("Still Attacking with a gun!");
                Invoke("Attack", CooldownTime);
            }
        }
        else
        {
            Debug.Log("Attacking with a melee weapon!");
        }
    }

    public IEnumerator Cooldown()
    {
        Debug.Log(gameObject.name + "Is Cooling Down");
        yield return new WaitForSeconds(CooldownTime);
        Debug.Log("cooldown for" + gameObject.name + "Has Completed");
        StopCoroutine(Cooldown());
    }
}
