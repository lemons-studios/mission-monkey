using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;

    public string sDetails, sState, sLargeImage, sLargeText, sSmallImage, sSmallText;

    void Start()
    {
        discord = new Discord.Discord(1090862646993096745, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = sDetails,
            State = sState,
            Assets = 
            {
                LargeImage = sLargeImage,
                LargeText = sLargeText,
                SmallImage = sSmallImage,
                SmallText = sSmallText
            },
        };
        activityManager.UpdateActivity(activity, (res) => {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord status set!");
            else
                Debug.LogError("Discord status failed!");
        });
    }

    void Update()
    {
        discord.RunCallbacks();
    }
}