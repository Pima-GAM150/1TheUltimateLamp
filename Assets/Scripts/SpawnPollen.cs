using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPollen : MonoBehaviour {

	public float counter;
	public bool canMakePollen;

	void Start()
	{
	
	}
	void Update () 
	{
		
		counter += Time.deltaTime;
		if (canMakePollen == true && counter >= 5f)	
		{
			Debug.Log("I activated the if statement");
			if (transform.childCount > 0 )
			{
				transform.GetChild(0).gameObject.SetActive(true);
				canMakePollen = false;
				counter = 0f;
			}
		}

	}

	public void SpawnPollenBall()
	{
		counter = 0f;
		canMakePollen = true;
		Debug.Log("I activated the SpawnPollenBall method");
	}

}
