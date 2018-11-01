using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

	public GameObject deathScreen;
	
	void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.gameObject.name == "Player")
    	{
    		deathScreen.SetActive(true);
    		Time.timeScale = 0;
    		//change pollen lost text to how much pollen lost
    	}
    }
}
