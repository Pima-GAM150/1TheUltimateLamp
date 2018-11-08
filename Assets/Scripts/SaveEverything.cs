using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public static class SaveEverything {

	/*public static void SaveGame()
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream(Application.persistentDataPath + "/game.sav", FileMode.Create);

		StoreAndPlayerData data = new StoreAndPlayerData();

		bf.Serialize(stream, data);
		stream.Close();


	}

	public static void LoadGame()
	{
		if(File.Exists(Application.persistentDataPath + "/game.sav"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream stream = File.Open(Application.persistentDataPath + "/game.sav", FileMode.Open);
			StoreAndPlayerData data = new StoreAndPlayerData(stream) as StoreAndPlayerData;

			stream.Close();
			return data.stats;

		}
		else{
			Debug.LogError("File does not exist.");

		}
	}
}

[Serializable]
class StoreAndPlayerData
{
	public int[] saveInts;
	public string saveString;
	public Vector3 saveSpawn;

	public saveData()
	{
		
		saveInts[0] = PlayerPrefs.GetInt("Moth1");
		saveInts[1] = PlayerPrefs.GetInt("Moth2");
		saveInts[2] = PlayerPrefs.GetInt("Moth3");
		saveInts[3] = PlayerPrefs.GetInt("Moth4");
		saveInts[4] = Manager.singleton.pollenBanked;

		saveString = Manager.singleton.activeMoth;
		saveSpawn = Manager.singleton.lastLampPos;
	}*/


	/*public string Save()
	{
		SaveableData saveable = new SaveableData{
			saveInts[0] = PlayerPrefs.GetInt("Moth1"),
			saveInts[1] = PlayerPrefs.GetInt("Moth2"),
			saveInts[2] = PlayerPrefs.GetInt("Moth3"),
			saveInts[3] = PlayerPrefs.GetInt("Moth4"),
			saveInts[4] = Manager.singleton.pollenBanked,
			saveString = Manager.singleton.activeMoth,
			saveSpawn = Manager.singleton.lastLampPos
		};

		string saveData = JsonUtility.ToJson( saveable );

		return saveData;

	}
	public void Load( string saveData )
	{
		SaveableData saveable = JsonUtility.FromJson<SaveableData>( saveData );

		PlayerPrefs.GetInt("Moth1") = saveable.saveInts[0];
		PlayerPrefs.GetInt("Moth2") = saveable.saveInts[1];
		PlayerPrefs.GetInt("Moth3") = saveable.saveInts[2];
		PlayerPrefs.GetInt("Moth4") = saveable.saveInts[3];
		Manager.singleton.pollenBanked = saveable.saveInts[4];
		Manager.singleton.activeMoth = saveable.saveString;
		Manager.singleton.lastLampPos = saveable.saveSpawn;
	}*/

	
		


}

public class SaveableData{

	public int[] saveInts;
	public string saveString;
	public Vector3 saveSpawn;

}