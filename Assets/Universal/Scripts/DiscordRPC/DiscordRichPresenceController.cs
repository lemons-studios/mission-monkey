using System;
using UnityEngine;

public class DiscordRichPresenceController : MonoBehaviour
{
    Discord.Discord discord;
    private long ClientId = 1090862646993096745;
    private long StartTime;
    private string State = "Playing Mission: Monkey";
    public string LargeImage, SmallImage, Description, LargeImageText, SmallImageText;


    private void Start()
    {
        discord = new Discord.Discord(ClientId, (UInt64)Discord.CreateFlags.NoRequireDiscord);
    }

    private void Update()
    {
        StartTime = (int)DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
        if (discord != null)
        {
            Debug.Log("Discord RPC should be loaded!");

            var ActivityManager = discord.GetActivityManager();
            var Activity = new Discord.Activity
            {
                State = State,
                Details = Description,
                Timestamps =
                {
                    Start = StartTime
                },
                Assets =
                {
                    LargeImage = LargeImage,
                    SmallImage = SmallImage,
                    LargeText = LargeImageText,
                    SmallText = SmallImageText,
                }
            };

            ActivityManager.UpdateActivity(Activity, (result) =>
            {
                if (result == Discord.Result.Ok)
                {
                    Debug.Log("Connected to Discord!");
                }
                else
                {
                    Debug.Log("Failed to Connect to Discord! :(");
                }
            });
        }
    }
}
