﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public static Manager singleton;
	public int pollenBanked;
	public int pollenOnHand;
	public Vector3 lastLampPos;

    public Moth[] moths;

	void Awake () {
		if (singleton == null)
		{
			singleton = this;
			DontDestroyOnLoad( this.gameObject);
		}
		else
		{
			Destroy( this.gameObject);
		}
	}
    
    public void Save()
    {
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

        PlayerPrefs.SetString("mySave", json);
    }

    public void Load()
    {
        string json = PlayerPrefs.GetString("mySave", "");
        if (json == "") return;

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
}

public class SerializableStore
{
    public Vector3 saveSpawn;
    public int pollenBanked;
    public string[] buttonStates;
}