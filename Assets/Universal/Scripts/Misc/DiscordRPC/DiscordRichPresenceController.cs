using System;
using UnityEngine;

public class DiscordRichPresenceController : MonoBehaviour
{
    Discord.Discord RichPresence;
    private long ClientId = 1090862646993096745;
    private long StartTime;
    private string Details = string.Empty;
    private string LargeImageText;
    public string LargeImage, SmallImage, State, SmallImageText;

    private void Start()
    {
        RichPresence = new Discord.Discord(ClientId, (UInt64)Discord.CreateFlags.NoRequireDiscord);
        StartTime = System.DateTimeOffset.Now.ToUnixTimeMilliseconds();
        SetStatus();
        LargeImageText = "Playing on Verssion " + Application.version;
    }

    private void Update()
    {
        try
        {
            RichPresence.RunCallbacks();
        }
        catch
        {
            gameObject.GetComponent<DiscordRichPresenceController>().enabled = false;
        }
    }
    private void LateUpdate()
    {
        SetStatus();
    }

    private void OnApplicationQuit()
    {
        RichPresence.Dispose();
    }

    private void SetStatus()
    {
        try
        {
            var ActivityManager = RichPresence.GetActivityManager();
            var Activity = new Discord.Activity
            {
                State = State,
                Details = Details,
                Assets =
            {
                LargeImage = LargeImage,
                SmallImage = SmallImage,
                LargeText = LargeImageText,
                SmallText = SmallImageText
            },
                Timestamps =
            {
                Start = StartTime
            }
            };
            ActivityManager.UpdateActivity(Activity, (res) =>
            {
                if (res == Discord.Result.Ok)
                {
                    // Debug.Log("Connected to Discord!");
                    return;
                }
                else Debug.LogWarning("Failed to connect to Discord!");
            });
        }
        catch
        {
            gameObject.GetComponent<DiscordRichPresenceController>().enabled = false;
        }
    }
}
