using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPollen : MonoBehaviour {

	public float counter1;
	public bool canMakePollen1;

	void Start()
	{
		counter1 = 0;
		canMakePollen1 = false;
	}
	void Update () 
	{
		
		counter1 += Time.deltaTime;
		if (canMakePollen1 == true && counter1 >= 5f)	
		{
			
			if (transform.childCount > 0 )
			{
				transform.GetChild(0).gameObject.SetActive(true);
				canMakePollen1 = false;
				counter1 = 0f;
			}
		}

	}

	public void SpawnPollenBall()
	{
		counter1 = 0f;
		canMakePollen1 = true;
		
	}

}
