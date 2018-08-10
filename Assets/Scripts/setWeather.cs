using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setWeather : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if(Settings.Weather != "snow")
            unsetSnow();
	}

    void unsetSnow()
    {
        GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = false;
    }
}
