using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoreScript : MonoBehaviour {

	//public GameObject buyButton;
	//public GameObject textBox;
	public bool boughtMoth = false;
	public bool isBuyButton = true;
	public int price = 0;
	public GameObject availableGoldTextBox;

	void Start()
	{
		pollen = Manager.singleton.pollenBanked;
	}
	void Update () {
		
	}

	public void ChangeButtonText () 
	{
		if (pollen >= price)
		{
			boughtMoth = true;
			Manager.singleton.pollenBanked -= price;
		}
		
		if ( isBuyButton == true && boughtMoth == true)
		{
			this.gameObject.GetComponentInChildren<Text>().text = "Equip";
			isBuyButton = false;

		}
		else if ( isBuyButton == false && boughtMoth == true)
		{
			this.gameObject.GetComponentInChildren<Text>().text = "Currently Equipped";
			//isBuyButton = true;
		}
	}
	public int pollen
    {
        get { return Manager.singleton.pollenBanked; }
        set { Manager.singleton.pollenBanked = value; }
    }
}
