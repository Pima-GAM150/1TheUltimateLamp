using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LampScript : MonoBehaviour {

    public GameObject pollenOnHandText;
    public GameObject pollenOnHandDeathText;
    public GameObject pollenBankedText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player")
        {
            Manager.singleton.pollenBanked += Manager.singleton.pollenOnHand;
            Manager.singleton.pollenOnHand = 0;
            pollenOnHandText.GetComponent<Text>().text = "Pollen Held:  " + Manager.singleton.pollenOnHand;
            pollenBankedText.GetComponent<Text>().text = "Pollen Banked:  " + Manager.singleton.pollenBanked;
            pollenOnHandDeathText.GetComponent<Text>().text = "Pollen Lost:  " + Manager.singleton.pollenOnHand;
        }
    }
}
