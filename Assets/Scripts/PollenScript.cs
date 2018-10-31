using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollenScript : SpawnPollen {

	
	
	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.name == "Player" )
		{
			Manager.singleton.pollenOnHand += 1;
			ToggleActivation();
		}
	}

	void ToggleActivation()
	{
		
		SpawnPollenBall();
		this.gameObject.SetActive(false);
	}
}
