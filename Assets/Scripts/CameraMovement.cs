using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject moth;
	public float offset;
	public float mothPosY;
	public float camPosY;

	// Use this for initialization
	void Start () {
		camPosY = transform.position.y;
		mothPosY = moth.transform.position.y;
		offset = camPosY - mothPosY;

	}
	void Update()
	{
		camPosY = transform.position.y;
		mothPosY = moth.transform.position.y;
	}
	// Update is called once per frame
	void LateUpdate () {
		camPosY = mothPosY + offset;
		transform.position = new Vector3(10.1f, camPosY, -60f);
	}
}
