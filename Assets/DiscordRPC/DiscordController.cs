using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;

    public string sDetails, sState, sLargeImage, sLargeText, sSmallImage, sSmallText;

    private long startTime;

    void Start()
    {
        discord = new Discord.Discord(1090862646993096745, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        startTime = DateTimeOffset.Now.ToUnixTimeSeconds();
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
            Timestamps =
            {
                Start = startTime
            }
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
        var activityManager = discord.GetActivityManager();
        var elapsedTime = DateTimeOffset.Now.ToUnixTimeSeconds() - startTime;
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
            Timestamps =
            {
                Start = startTime
            },
            Secrets =
            {
                Match = "matchId"
            }
        };
        activityManager.UpdateActivity(activity, (res) => {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord status set!");
            else
                Debug.LogError("Discord status failed!");
        });
        discord.RunCallbacks();
    }

    void OnApplicationQuit()
    {
        var activityManager = discord.GetActivityManager();
        activityManager.ClearActivity((res) => {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord status cleared!");
            else
                Debug.LogError("Discord status clear failed!");
        });
        discord.Dispose();
    }
}