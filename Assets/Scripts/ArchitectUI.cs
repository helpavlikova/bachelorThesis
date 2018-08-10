using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class ArchitectUI : MonoBehaviour {
    public Canvas canvas;
    string pathObj;
    string pathTexture;
    string houseName;
    string info;
    public InputField ObjInputField;
    public InputField TextureInputField;
    public InputField NameInputField;
    public InputField InfoInputField;
    GameObject buildings;
    Transform buildingsTrans;



    // Update is called once per frame
    void Update () {
            canvas.GetComponent<Canvas>().enabled = Settings.ArchiMode;        
    }

    public void OpenExplorerObj()
    {
        //pathObj = EditorUtility.OpenFilePanel("Otevřít model", "", "obj");
        GetPath(pathObj, ObjInputField);
    }

    public void OpenExplorerTexture()
    {
       // pathTexture = EditorUtility.OpenFilePanel("Otevřít texturu", "", "jpg");
        GetPath(pathTexture, TextureInputField);
    }

    public void GetPath(string path, InputField iField)
    {
        if (path != null)
            iField.text = path;
    }


    public void GetName()
    {
        if (houseName != null)
            NameInputField.text = houseName;
    }

    public void GetInfo()
    {
        if (info != null)
            InfoInputField.text = info;
    }

    public void OKButtonListener() {
        Settings.ArchiMode = !Settings.ArchiMode;
        createNewBuilding();
    }


    private void createNewBuilding()
    {
        buildings = new GameObject("NewBuilding");
        Debug.Log(pathObj);
        
        /*
        GetComponent<MeshFilter>().mesh = FastObjImporter.Instance.ImportFile(pathObj);

        GetComponent<Transform>().position = new Vector3(0,0,0);
        GetComponent<Transform>().eulerAngles = new Vector3(0,0,0);
        GetComponent<Transform>().localScale = new Vector3(0,0,0);        */
    }
}
