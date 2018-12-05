using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampScript : MonoBehaviour {

    public GameObject pollenOnHandText;
    public GameObject pollenOnHandDeathText;
    public GameObject pollenBankedText;
    public GameObject lampLocTxt;
    public float locFloat;
    public int locInt;
    public string locString;
    public GameObject depositNoisePrefab;
    // Use this for initialization
    void Start () {
		pollenBankedText = GameObject.Find("PollenBankedAmount");
        pollenOnHandText = GameObject.Find("PollenOnHandAmount");
        pollenOnHandText.GetComponent<Text>().text = "Pollen Held:  " + Manager.singleton.pollenOnHand;
        pollenBankedText.GetComponent<Text>().text = "Pollen Banked:  " + Manager.singleton.pollenBanked;
        Manager.singleton.Load("mySave");


	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Instantiate(depositNoisePrefab);
            Manager.singleton.pollenBanked += Manager.singleton.pollenOnHand;
            Manager.singleton.pollenOnHand = 0;
            pollenOnHandText.GetComponent<Text>().text = "Pollen Held:  " + Manager.singleton.pollenOnHand;
            pollenBankedText.GetComponent<Text>().text = "Pollen Banked:  " + Manager.singleton.pollenBanked;
            locFloat = this.transform.position.y;
            locInt = Mathf.RoundToInt(locFloat);
            locString = locInt.ToString();
            lampLocTxt.GetComponent<Text>().text = locString;
            Manager.singleton.lastLampPos = this.transform.position;
            Manager.singleton.Save( "mySave" );
        }
    }
}
