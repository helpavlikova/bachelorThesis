using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public Transform example;
    public Material morningSkybox;
    public Material afternoonSkybox;
    public Material eveningSkybox;
    public Material nightSkybox;
    public Material cloudSkybox;
    GameObject buildings;
    DataReader data = new DataReader();
    string dayTime;
    string weather;


    //draws the scene
    void Start () {
        data.LoadGameData();

        setDayTime();
        setClouds();

        //a parent object for all of the buildings
        buildings = new GameObject("Buildings");

        for (int i = 0; i < data.GetSize(); i++) {
            Transform newObject = Instantiate(example, example.position, example.rotation);
            newObject.GetComponent<Building>().Set(data.GetModel(i));
            newObject.SetParent(buildings.transform);
        }

      /*  BoxCollider boxCollider = buildings.AddComponent<BoxCollider>();
        Rigidbody gameObjectsRigidBody = buildings.AddComponent<Rigidbody>(); // Add the rigidbody.
        gameObjectsRigidBody.velocity = Vector3.zero; */
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey("escape"))
            Application.Quit();
    }

    void setDayTime() {
        dayTime = Settings.DayTime;

        if (dayTime == "morning")
            RenderSettings.skybox = morningSkybox;
       else if (dayTime == "afternoon")
            RenderSettings.skybox = afternoonSkybox;
       else if (dayTime == "evening")
            RenderSettings.skybox = eveningSkybox;
       else if (dayTime == "night")
            RenderSettings.skybox = nightSkybox;

        DynamicGI.UpdateEnvironment();
    }

    void setClouds() {
        weather = Settings.Weather;

        if(weather == "cloudy" || weather == "snow" || weather == "rainy")
            RenderSettings.skybox = cloudSkybox;
    }

}
