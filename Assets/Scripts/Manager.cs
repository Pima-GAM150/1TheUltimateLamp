using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {

	public static Manager singleton;
	public int pollenBanked;
	public int pollenOnHand;
	public Vector3 lastLampPos;
	public GameObject newMoth;
	public GameObject oldMoth;
	public string activeMoth;


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
    public void Deactivate()
	{
		//gameOverUI.SetActive(false);
		//winScreen.SetActive(false);
		
	}
	
	
	
}
