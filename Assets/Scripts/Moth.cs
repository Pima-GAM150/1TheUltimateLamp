using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moth : MonoBehaviour {

    public enum StoreButtonState { Buy = 0, Equip = 1, CurrentlyEquipped = 2 }
    public StoreButtonState state;

    public Sprite appearance;

    public string Save()
    {
        print(name + " is savings its saved state to " + state);
        SerializableStoreButton saveable = new SerializableStoreButton
        {
            state = (int)state,
        };

        string json = JsonUtility.ToJson(saveable);
        return json;
    }

    public void Load(string json)
    {
        SerializableStoreButton saved = JsonUtility.FromJson<SerializableStoreButton>(json);
        print(name + " is setting its saved state to " + saved.state);
        state = (Moth.StoreButtonState)saved.state;
    }
}
