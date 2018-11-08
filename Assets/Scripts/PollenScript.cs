using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollenScript : MonoBehaviour {

	public SpawnPollen spawnPollen;
    public GameObject pollenOnHandText;
    public GameObject pollenOnHandDeathText;
  	public GameObject pollenNoisePrefab;
	void Start()
	{
		spawnPollen = this.gameObject.GetComponentInParent<SpawnPollen>();
	}

    void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Player" )
		{
			Instantiate(pollenNoisePrefab);
			Manager.singleton.pollenOnHand += 1;
            pollenOnHandText.GetComponent<Text>().text = "Pollen Held:  " + Manager.singleton.pollenOnHand;
            pollenOnHandDeathText.GetComponent<Text>().text = "Pollen Lost:  " + Manager.singleton.pollenOnHand;
            ToggleActivation();
            
		}
	}

	void ToggleActivation()
	{
		
		spawnPollen.SpawnPollenBall();
		this.gameObject.SetActive(false);
	}
}
