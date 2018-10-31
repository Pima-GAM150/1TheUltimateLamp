using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public static Manager singleton;
	public int pollenBanked;
	public int pollenOnHand;
	public Vector3 posOfPollen;
	public float counter;
	public GameObject pollenBall;
	public bool canMakePollen = false;







	void Awake () {
		if (singleton == null)
		{
			singleton = this;
			DontDestroyOnLoad( this.gameObject);
		}
		else
		{
			Destroy( this.gameObject);
		}
	}
	void Start()
	{
		
	}
	
	// Update is called once per frame
	/*void Update () 
	{
		counter += Time.deltaTime;
		if (canMakePollen == true && counter >= 5)	
		{
			GameObject newPollenBall = Instantiate<GameObject>(pollenBall);
			newPollenBall.transform.position = posOfPollen;
			canMakePollen = false;
			counter = 0f;
		}

	}

	public void SpawnPollenBall()
	{
		counter = 0;
		canMakePollen = true;
	}*/
}
