using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Credit to https://sharpcoderblog.com/blog/unity-countdown-timer for script

/* Steps to Create
    1. Create UI -> text ... name 'Countdown'
    2. Change above transform to align top left, pivot to (0,1), Pos X and Y to 5, Width 300, and Height 60
    3. Change to BOLD, Font 34, Align left, WHITE
    4. Attach this script to 'Countdown' object
*/ 


public class CountdownTimer : MonoBehaviour
{
    public enum CountdownFormatting { DaysHoursMinutesSeconds, HoursMinutesSeconds, MinutesSeconds, Seconds };
    public CountdownFormatting countdownFormatting = CountdownFormatting.MinutesSeconds; //Controls the way the timer string will be formatted
    public bool showMilliseconds = true; //Whether to show milliseconds in countdown formatting
    public double countdownTime = 600; //Countdown time in seconds

    Text countdownText;
    double countdownInternal;
    bool countdownOver = false;

    // Start is called before the first frame update

    void Start()
    {
        countdownText = GetComponent<Text>();
        countdownInternal = countdownTime; //Initialize countdown
    }

    void FixedUpdate()
    {
        if (countdownInternal > 0)
        {
            countdownInternal -= Time.deltaTime;

            //Clamp the timer value so it never goes below 0
            if (countdownInternal < 0)
            {
                countdownInternal = 0;
            }

            countdownText.text = FormatTime(countdownInternal, countdownFormatting, showMilliseconds);
        }
        else
        {
            if (!countdownOver)
            {
                countdownOver = true;

                Debug.Log("Countdown has finished running...");

                //Your code here...
            }
        }
    }

    string FormatTime(double time, CountdownFormatting formatting, bool includeMilliseconds)
    {
        string timeText = "";

        int intTime = (int)time;
        int days = intTime / 86400;
        int hoursTotal = intTime / 3600;
        int hoursFormatted = hoursTotal % 24;
        int minutesTotal = intTime / 60;
        int minutesFormatted = minutesTotal % 60;
        int secondsTotal = intTime;
        int secondsFormatted = intTime % 60;
        int milliseconds = (int)(time * 100);
        milliseconds = milliseconds % 100;

        if (includeMilliseconds)
        {
            if (formatting == CountdownFormatting.DaysHoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}:{4:00}", days, hoursFormatted, minutesFormatted, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.HoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", hoursTotal, minutesFormatted, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.MinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}", minutesTotal, secondsFormatted, milliseconds);
            }
            else if (formatting == CountdownFormatting.Seconds)
            {
                timeText = string.Format("{0:00}:{1:00}", secondsTotal, milliseconds);
            }
        }
        else
        {
            if (formatting == CountdownFormatting.DaysHoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}:{3:00}", days, hoursFormatted, minutesFormatted, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.HoursMinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}:{2:00}", hoursTotal, minutesFormatted, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.MinutesSeconds)
            {
                timeText = string.Format("{0:00}:{1:00}", minutesTotal, secondsFormatted);
            }
            else if (formatting == CountdownFormatting.Seconds)
            {
                timeText = string.Format("{0:00}", secondsTotal);
            }
        }

        return timeText;
    }
}