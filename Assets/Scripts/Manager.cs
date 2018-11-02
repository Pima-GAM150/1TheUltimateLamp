using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public static Manager singleton;
	public int pollenBanked;
	public int pollenOnHand;



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
    
	
	
}
