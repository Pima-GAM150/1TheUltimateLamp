using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject moth;
	public float offset;
	public float mothPosY;
	public float camPosY;
	public AudioSource audioSource;
	// Use this for initialization
	void Start () {
		
		audioSource.volume = 0.25f;
		mothPosY = moth.transform.position.y;
		if (mothPosY < 25.4f)
		{
			transform.position = new Vector3(10.1f, 25.5f, -60f);
		}
		else
		{
			transform.position = new Vector3(10.1f, mothPosY, -60f);
		}
		camPosY = transform.position.y;
		
		offset = camPosY - mothPosY;

	}
	void Update()
	{
        
        camPosY = transform.position.y;
		mothPosY = moth.transform.position.y;
	}
	// Update is called once per frame
	void LateUpdate () {
        if (mothPosY >= 25.5f)
        {
            camPosY = mothPosY;
            transform.position = new Vector3(10.1f, camPosY, -60f);
        }
    }
    public void DeathAudio()
    {
    	audioSource.volume = 0f;
    }
}
