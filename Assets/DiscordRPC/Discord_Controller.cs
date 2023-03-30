using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;


public class Discord_Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var CLIENT_ID = 1090862646993096745;
        var discord = new Discord.Discord(CLIENT_ID, (UInt64)Discord.CreateFlags.Default);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
