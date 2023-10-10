using System;
using UnityEngine;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;

    public string Details, State, LargeImage, LargeText, SmallImage, SmallText;

    private long startTime;
    bool discordRunning = false;

    void Start()
    {
        foreach (System.Diagnostics.Process v in System.Diagnostics.Process.GetProcesses())
        {
            // checks if current process is discord
            if (v.ToString().Contains("Discord"))
            {
                discordRunning = true;
                Debug.Log("Discord Found!");
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
                Details = Details,
                State = State,
                Assets =
                {
                    LargeImage = LargeImage,
                    LargeText = LargeText,
                    SmallImage = SmallImage,
                    SmallText = SmallText
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
                Details = Details,
                State = State,
                Assets =
                {
                    LargeImage = LargeImage,
                    LargeText = LargeText,
                    SmallImage = SmallImage,
                    SmallText = SmallText
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
        else
        {
            return;
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