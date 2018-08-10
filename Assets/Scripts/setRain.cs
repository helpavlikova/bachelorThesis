using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setRain : MonoBehaviour {
    
	void Start () {
        if(Settings.Weather != "rainy")
            unsetRain();
	}

    void unsetRain()
    {
        GetComponent<ParticleSystem>().Play();
        ParticleSystem.EmissionModule em = GetComponent<ParticleSystem>().emission;
        em.enabled = false;
    }
}
