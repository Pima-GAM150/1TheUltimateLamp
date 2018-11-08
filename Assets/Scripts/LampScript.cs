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
        pollenBankedText.GetComponent<Text>().text = "Pollen Banked:  " + PlayerPrefs.GetInt("pollenBanked");
        


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
            int pb = Manager.singleton.pollenBanked;
            PlayerPrefs.SetInt("pollenBanked", pb);
            Manager.singleton.pollenOnHand = 0;
            pollenOnHandText.GetComponent<Text>().text = "Pollen Held:  " + Manager.singleton.pollenOnHand;
            pollenBankedText.GetComponent<Text>().text = "Pollen Banked:  " + PlayerPrefs.GetInt("pollenBanked");
            PlayerPrefs.SetFloat("LampPosX", this.transform.position.x);
            PlayerPrefs.SetFloat("LampPosY", this.transform.position.y);
            locFloat = this.transform.position.y;
            locInt = Mathf.RoundToInt(locFloat);
            locString = locInt.ToString();
            lampLocTxt.GetComponent<Text>().text = locString;

        }
    }
}
