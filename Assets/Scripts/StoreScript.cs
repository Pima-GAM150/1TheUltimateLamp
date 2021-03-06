﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreScript : MonoBehaviour {

    public StoreButton[] storeButtons;
    public GameObject pBTxt;

    public void Start()
    {
        pBTxt.GetComponent<Text>().text = "Pollen:    " + Manager.singleton.pollenBanked;
    }

    public void ButtonPressed( StoreButton buttonThatWasPressed )
    {
        if (buttonThatWasPressed.moth.state == Moth.StoreButtonState.Buy)
        {
            if (Manager.singleton.pollenBanked > buttonThatWasPressed.pollenCost)
            {
                Manager.singleton.pollenBanked -= buttonThatWasPressed.pollenCost;
                buttonThatWasPressed.moth.state = Moth.StoreButtonState.Equip;
                pBTxt.GetComponent<Text>().text = "Pollen:    " + Manager.singleton.pollenBanked;
            }
        }
        else if (buttonThatWasPressed.moth.state == Moth.StoreButtonState.Equip)
        {
            foreach( StoreButton button in storeButtons )
            {
                if( button.moth.state == Moth.StoreButtonState.CurrentlyEquipped )
                {
                    button.moth.state = Moth.StoreButtonState.Equip;
                }
            }

            buttonThatWasPressed.moth.state = Moth.StoreButtonState.CurrentlyEquipped;
        }

        foreach( StoreButton button in storeButtons )
        {
            button.Refresh();
        }
    }
}