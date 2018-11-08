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
	public int boughtMothInt;
	public GameObject buttonOne;
	public GameObject buttonTwo;
	public GameObject buttonThree;

	public StoreScript buttonOneScript;
	public StoreScript buttonTwoScript;
	public StoreScript buttonThreeScript;
	public string thisMoth;
	public string saveName;
	public string currentActiveMoth;



	void Start()
	{
		boughtMothInt = PlayerPrefs.GetInt(saveName, boughtMothInt);
		if (boughtMothInt == 0)
		{
			boughtMoth = false;
		}
		else
		{
			boughtMoth = true;
			this.gameObject.GetComponentInChildren<Text>().text = "Equip";
			isBuyButton = false;
		}
		currentActiveMoth = PlayerPrefs.GetString("activeMoth");
		if (currentActiveMoth == thisMoth)
		{
			this.gameObject.GetComponentInChildren<Text>().text = "Currently Equipped";

		}

		
		availableGoldTextBox.GetComponent<Text>().text = "Pollen:    " + PlayerPrefs.GetInt("pollenBanked");
	}
	void Update () {
		
	}

	public void ChangeButtonText () 
	{
		if (boughtMoth == false && PlayerPrefs.GetInt("pollenBanked") >= price)
		{
			boughtMoth = true;
			boughtMothInt = 1;
			PlayerPrefs.SetInt(saveName, boughtMothInt);
			Manager.singleton.pollenBanked -= price;
			availableGoldTextBox.GetComponent<Text>().text = "Pollen:    " + PlayerPrefs.GetInt("pollenBanked");
		}
		
		if ( isBuyButton == true && boughtMoth == true)
		{
			this.gameObject.GetComponentInChildren<Text>().text = "Equip";
			isBuyButton = false;

		}
		else if ( isBuyButton == false && boughtMoth == true)
		{
			this.gameObject.GetComponentInChildren<Text>().text = "Currently Equipped";
			SetActiveMoth();
			ChangeBooleans();
		}
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
    public void SetActiveMoth()
    {
    	PlayerPrefs.SetString("activeMoth", thisMoth);
    }
}
