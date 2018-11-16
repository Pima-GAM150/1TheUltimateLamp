using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreButton : MonoBehaviour {

    readonly string[] buttonText = new string[3] { "Buy", "Equip", "Currently Equipped" };

    public Text label;

    public int pollenCost;

    public Moth moth;

    private void Start()
    {
        Refresh();
    }

    public void Refresh()
    {
        label.text = buttonText[(int)moth.state];
        if(moth.state == Moth.StoreButtonState.Buy )
        {
            label.text += " (" + pollenCost + ")";
        }
    }
}

public class SerializableStoreButton
{
    public int state;
}