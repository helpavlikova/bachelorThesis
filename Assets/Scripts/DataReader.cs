﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using Newtonsoft.Json;

/*A root clas encompassing the array of all models */
public class Root
{
    public Model[] models;
}

/*A class for the coordinate system*/
public class Coords {
    public float x;
    public float y;
    public float z;
}



/*A class containing all the fields from JSON. All information about the model is set here*/
[System.Serializable]
public class Model
{
    public string model_name;
    public int model_ID;
    public string info;
    public string file_link;
    public string file;
    public string weather;
    public string time;
    public string season;
    public string texture_link;
    public Coords position_coords;
    public Coords rotation_coords;
    public Coords scale_coords;
}

/*This class deals with reading JSON files, either from remote server via HTTP or from FS for the purpose of testing.*/
public class DataReader { 
   
    Root root;
    string filePath;
    string uri = "https://virtserver.swaggerhub.com/pavlihel9/VirtualGuide/1.0.4/models/42";
    string gameDataFileName = Settings.Path;


    /*This method gets around the security issues in which Mono does not want to accept any certificate, even if trusted.*/
    //via https://answers.unity.com/questions/792342/how-to-validate-ssl-certificates-when-using-httpwe.html
    public bool MyRemoteCertificateValidationCallback(System.Object sender, 
        X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        bool isOk = true;
        // If there are errors in the certificate chain,
        // look at each error to determine the cause.
        if (sslPolicyErrors != SslPolicyErrors.None)
        {
            for (int i = 0; i < chain.ChainStatus.Length; i++)
            {
                if (chain.ChainStatus[i].Status == X509ChainStatusFlags.RevocationStatusUnknown)
                {
                    continue;
                }
                chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
                chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
                chain.ChainPolicy.UrlRetrievalTimeout = new TimeSpan(0, 1, 0);
                chain.ChainPolicy.VerificationFlags = X509VerificationFlags.AllFlags;
                bool chainIsValid = chain.Build((X509Certificate2)certificate);
                if (!chainIsValid)
                {
                    isOk = false;
                    break;
                }
            }
        }
        return isOk;
    }

    /*A simple method to make the JSON file readable by our data structures.*/
    public string fixJson(string value)
    {
        value = "{\"models\": [" + value + "] }";
        return value;
    }

    /*Loads JSON file from File System.*/
    public string GetJSONfromFS()
    {
        filePath = Path.Combine(Application.streamingAssetsPath, gameDataFileName);
        //Debug.Log("filepath = " + filePath);

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string

            string dataAsJson = File.ReadAllText(filePath);
            return dataAsJson;
        }
        else
        {
            Debug.LogError("Cannot load game data!");
            return null;
        }
        
    }

    /*Loads JSON file from remote server via HTTP*/
    private string GetJSONfromAPI()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(String.Format(uri));

        //a special function to add a certificate (otherwise Mono won't allow any connections]
        ServicePointManager.ServerCertificateValidationCallback = MyRemoteCertificateValidationCallback;

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        StreamReader reader = new StreamReader(response.GetResponseStream());
        string jsonResponse = reader.ReadToEnd();
        Debug.Log("API response = " + jsonResponse);
        jsonResponse = fixJson(jsonResponse);
        Debug.Log("Fixed JSON = " + jsonResponse);
        return jsonResponse;
    }

    /*A function to load JSON file wither from FS or via API*/
    public void LoadGameData() {
        string jsonresponse;
        jsonresponse = GetJSONfromFS();

        root = JsonConvert.DeserializeObject<Root>(jsonresponse);       

    }

    /*Returns a particular model from the list*/
    public Model GetModel(int i) {
        return root.models[i];
    }

    /*Returns number of all models*/
    public int GetSize() {
        return root.models.Length;
    }

}
