using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100f;
    public GameObject Player;
    private PlayerMotor Motor;
    // Start is called before the first frame update
    void Start()
    {
        Motor = Player.GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
