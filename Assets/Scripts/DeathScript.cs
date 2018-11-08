using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour {

	public GameObject deathScreen;
	public CameraMovement camMove;
    public GameObject deathNoisePrefab;
	void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.gameObject.tag == "Player")
    	{
    		deathScreen.SetActive(true);
    		Time.timeScale = 0;
            Manager.singleton.pollenOnHand = 0;
    		//change pollen lost text to how much pollen lost
            camMove.DeathAudio();
            Instantiate(deathNoisePrefab);

    	}
    }
}
