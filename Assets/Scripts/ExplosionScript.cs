using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour {
	public float lifeTime;
	public float timeAlive;
	private Rigidbody2D rbody;

	
	// Update is called once per frame
	void Update () {
		timeAlive += Time.deltaTime;

		if (timeAlive > lifeTime){
			Destroy();
		}
	}
	void Destroy(){
		Destroy(this.gameObject);
	}
}
