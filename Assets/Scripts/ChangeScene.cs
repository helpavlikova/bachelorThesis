using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    public void loadMainScene() {
        SceneManager.LoadScene("mainScene");
    }

    public void setStreet()
    {
        Settings.Path = "data4.json";
        Debug.Log(Settings.Path);
    }

    public void setSquare()
    {
        Settings.Path = "data5.json";
        Debug.Log(Settings.Path);
    }

    public void setMorning()
    {
        Settings.DayTime = "morning";
        Debug.Log(Settings.DayTime);
    }

    public void setAfternoon()
    {
        Settings.DayTime = "afternoon";
        Debug.Log(Settings.DayTime);
    }

    public void setEvening()
    {
        Settings.DayTime = "evening";
        Debug.Log(Settings.DayTime);
    }

    public void setNight()
    {
        Settings.DayTime = "night";
        Debug.Log(Settings.DayTime);
    }

    public void setSnow()
    {
        Settings.Weather = "snow";
        Debug.Log(Settings.Weather);
    }

    public void setSun()
    {
        Settings.Weather = "sunny";
        Debug.Log(Settings.Weather);
    }

    public void setRain()
    {
        Settings.Weather = "rainy";
        Debug.Log(Settings.Weather);
    }
    public void setClouds()
    {
        Settings.Weather = "cloudy";
        Debug.Log(Settings.Weather);
    }
}
