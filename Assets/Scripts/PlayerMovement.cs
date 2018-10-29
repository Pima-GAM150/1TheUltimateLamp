using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float xInput;
	public float speed;
	public Rigidbody2D rbody;
	public float jumpPower;
	
	// Update is called once per frame
	void Update () {
		
		xInput = Input.GetAxis( "Horizontal" );
		if( Input.GetButtonDown( "Jump" ) ){
			Jump();
		}
	}

	void FixedUpdate() {
		rbody.velocity = new Vector2( xInput * speed, rbody.velocity.y );
	}

	void Jump() {
		rbody.AddForce( Vector2.up * jumpPower, ForceMode2D.Impulse );
	}
}
