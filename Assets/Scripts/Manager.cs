﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

	public static Manager singleton;
	public int pollenBanked;
	public int pollenOnHand;
	public Vector3 lastLampPos;
    public bool paused;
    public bool canPause;
    public Moth[] moths;
    public GameObject pollenOnHandText;
    public GameObject pollenOnHandDeathText;

    void Awake () {
		if (singleton == null)
		{
			singleton = this;
			DontDestroyOnLoad( this.gameObject);

            string saveData = PlayerPrefs.GetString("defaultSave", "");
            if (saveData == "") Save("defaultSave");
            Load(saveData);
		}
		else
		{
			Destroy( this.gameObject);
		}
	}
    public void Reset()
    {
        string saveData = PlayerPrefs.GetString("defaultSave", "");
        if (saveData == "") Save("defaultSave");
        Load(saveData);

    }
   

    public void Save( string saveName )
    {
        print("Saving game with name " + saveName);
        SerializableStore saveable = new SerializableStore
        {
            pollenBanked = this.pollenBanked,
            saveSpawn = lastLampPos,
            buttonStates = new string[moths.Length]
        };

        for (int index = 0; index < moths.Length; index++)
        {
            saveable.buttonStates[index] = moths[index].Save();
        }

        string json = JsonUtility.ToJson(saveable);

        PlayerPrefs.SetString(saveName, json);
    }

    public void Load( string saveName )
    {
        
        print("Loading game with name " + saveName);
        string json = PlayerPrefs.GetString(saveName, "");
        if (json == "") json = PlayerPrefs.GetString("defaultSave", "");

        SerializableStore saved = JsonUtility.FromJson<SerializableStore>(json);

        for (int index = 0; index < moths.Length; index++)
        {
            moths[index].Load(saved.buttonStates[index]);
        }

        pollenBanked = saved.pollenBanked;
        lastLampPos = saved.saveSpawn;
    }

    public Moth currentMoth
    {
        get
        {
            foreach( Moth moth in moths )
            {
                if (moth.state == Moth.StoreButtonState.CurrentlyEquipped) return moth;
            }

            return moths[0];
        }
    }

    public void ChangeText()
    {
        pollenOnHandText = GameObject.Find("PollenOnHandAmount");
        pollenOnHandText.GetComponent<Text>().text = "Pollen Held:  " + Manager.singleton.pollenOnHand;
    }
    public void ChangeDeathText()
    {
        pollenOnHandDeathText = GameObject.Find("Pollen Lost");
        pollenOnHandDeathText.GetComponent<Text>().text = "Pollen Lost:  " + Manager.singleton.pollenOnHand;
    }
}



public class SerializableStore
{
    public Vector3 saveSpawn;
    public int pollenBanked;
    public string[] buttonStates;
}