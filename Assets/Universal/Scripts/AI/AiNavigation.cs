using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.AI;

public class AiNavigation : MonoBehaviour
{
    public Transform[] PatrolLocations;
    public Vector3 PlayerLocation;
    public LayerMask Player;
    public GameObject PlayerModel, AiModel;

    private void Awake()
    {
        
    }

    private void FixedUpdate()
    {
        Component[] AiComponents = GetComponents<Component>();  
        foreach (Component component in AiComponents)
        {
            if(component.GetType().ToString().Contains("Attack"))
            {
                Debug.Log("Attack Component Found!!");
            }
            else
            {
                return;
            }
        }
    }
}
