using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignSaveValuesOnLoad : SaveDataBase 
{
    public GameObject player;
    public PlayerHealth playerHealth;

    private void Awake() 
    {
        player.transform.position = base.GetPositionFromSaveData("playerPosition");
        player.GetComponent<PlayerHealth>().SetHealth(GetSaveDataInfoFromTag<int>("remainingHealth"));
    }
}
