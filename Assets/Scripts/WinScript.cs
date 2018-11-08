using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour {

	public GameObject winScreen;
	public CameraMovement camMove;
	public GameObject winNoisePrefab;

	void OnTriggerEnter2D(Collider2D col)
    {
    	if (col.gameObject.tag == "Player")
    	{
    		winScreen.SetActive(true);
    		Time.timeScale = 0;
            Manager.singleton.pollenOnHand = 0;
    	    camMove.DeathAudio();
            Instantiate(winNoisePrefab);

    	}
    }
}
