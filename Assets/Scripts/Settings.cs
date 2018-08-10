using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Settings
{
    private static string path = "data4.json";
    private static string dayTime = "afternoon";
    private static string weather = "sunny";
    private static bool archiMode = false;

    public static string Path
    {
        get
        {
            return path;
        }
        set
        {
            path = value;
        }
    }

    public static string DayTime
    {
        get
        {
            return dayTime;
        }
        set
        {
            dayTime = value;
        }
    }


    public static string Weather
    {
        get
        {
            return weather;
        }
        set
        {
            weather = value;
        }
    }

    public static bool ArchiMode
    {
        get
        {
            return archiMode;
        }
        set
        {
            archiMode = value;
        }
    }

}
