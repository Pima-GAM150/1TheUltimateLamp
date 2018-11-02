using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float xInput;
	public float speed;
	public Rigidbody2D rbody;
	public float jumpPower;
    public float smoothSpeed;
	
	// Update is called once per frame
	void Update () {
		
		xInput = Input.GetAxis( "Horizontal" );
		if( Input.GetButtonDown( "Jump" ) ){
			Jump();
		}

        //change Vector3.forward to the current position - the previous
        transform.up = rbody.velocity;
	}

	void FixedUpdate() {
		rbody.velocity = Vector2.Lerp(rbody.velocity, new Vector2( xInput * speed, rbody.velocity.y ), smoothSpeed);
	}

	void Jump() {
		rbody.AddForce( Vector2.up * jumpPower, ForceMode2D.Impulse );
	}
}
