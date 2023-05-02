using System;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;

    public string sDetails, sState, sLargeImage, sLargeText, sSmallImage, sSmallText;

    private long startTime;

    bool discordRunning = false;

    void Start()
    {
        // loops through open processes
        for (int i = 0; i < System.Diagnostics.Process.GetProcesses().Length; i++)
        {
            // checks if current process is discord
            if (System.Diagnostics.Process.GetProcesses()[i].ToString() == "System.Diagnostics.Process (Discord)")
            {
                discordRunning = true;
                break;
            }
        }

        if (discordRunning)
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
            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res == Discord.Result.Ok)
                    Debug.Log("Discord status set!");
                else
                    Debug.LogError("Discord status failed!");
            });
        }
    }

    void Update()
    {
        if (discordRunning)
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

            discord.RunCallbacks();
        }
    }

    void OnApplicationQuit()
    {
        if (discordRunning)
        {
            var activityManager = discord.GetActivityManager();
            activityManager.ClearActivity((res) =>
            {
                if (res == Discord.Result.Ok)
                    Debug.Log("Discord status cleared!");
                else
                    Debug.LogError("Discord status clear failed!");
            });
            discord.Dispose();
        }
    }
}