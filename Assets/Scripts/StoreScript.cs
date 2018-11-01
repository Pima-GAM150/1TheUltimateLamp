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

	public GameObject buttonOne;
	public GameObject buttonTwo;
	public GameObject buttonThree;

	public StoreScript buttonOneScript;
	public StoreScript buttonTwoScript;
	public StoreScript buttonThreeScript;

	void Start()
	{
		pollen = Manager.singleton.pollenBanked;
		availableGoldTextBox.GetComponent<Text>().text = "Pollen:    " + pollen;
	}
	void Update () {
		
	}

	public void ChangeButtonText () 
	{
		if (boughtMoth == false && pollen >= price)
		{
			boughtMoth = true;
			Manager.singleton.pollenBanked -= price;
			availableGoldTextBox.GetComponent<Text>().text = "Pollen:" + pollen;
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
			ChangeBooleans();
		}
	}
	public int pollen
    {
        get { return Manager.singleton.pollenBanked; }
        set { Manager.singleton.pollenBanked = value; }
    }
    public void ChangeBooleans()
    {
    	if (buttonOneScript.boughtMoth == true)
    	{
    		buttonOne.GetComponentInChildren<Text>().text = "Equip";
    		buttonOneScript.isBuyButton = false;
    	}
    	if (buttonTwoScript.boughtMoth == true)
    	{
    		buttonTwo.GetComponentInChildren<Text>().text = "Equip";
    		buttonTwoScript.isBuyButton = false;
    	}
    	if (buttonThreeScript.boughtMoth == true)
    	{
    		buttonThree.GetComponentInChildren<Text>().text = "Equip";
    		buttonThreeScript.isBuyButton = false;
    	}
    }
}
