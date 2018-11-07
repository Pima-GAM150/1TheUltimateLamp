using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;



public static class SaveEverything {

	/*public static void SaveGame(Manager Manager)
	{
		BinaryFormatter bf = new BinaryFormatter();
		FileStream stream = new FileStream(Application.persistentDataPath + "/game.sav", FileMode.Create);

		StoreAndPlayerData data = new StoreAndPlayerData(Manager);

		bf.Serialize(stream, data);
		stream.Close();


	}

	public static void LoadGame()
	{
		if(File.Exists(Application.persistentDataPath + "/game.sav"))
		{
			BinaryFormatter bf = new BinaryFormatter(Application.persistentDataPath + "/game.sav", FileMode.Open);
			FileStream stream = File.Open(Ap);
		}
	}*/
}

/*[Serializable]
class StoreAndPlayerData
{
	public String currentMoth;

	public Moth (Manager Manager)
	{
		currentMoth = Manager.singleton.equippedMoth;
	}
		


}*/