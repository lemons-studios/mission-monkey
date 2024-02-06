using UnityEngine;

public class AssignSaveValuesOnLoad : SaveDataBase 
{
    private GameObject player;
    public PlayerHealth playerHealth;


    private void Awake() 
    {
        player = GameObject.FindGameObjectWithTag("Player");
        CharacterController playerController = player.GetComponent<CharacterController>();
        playerController.enabled = false;

        player.transform.position = base.GetPositionFromSaveData();
        player.GetComponent<PlayerHealth>().SetHealth(GetSaveDataInfoFromTag<int>("remainingHealth"));
        playerController.enabled = true;
    }
}
