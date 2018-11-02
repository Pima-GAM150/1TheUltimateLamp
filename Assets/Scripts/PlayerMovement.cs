using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	private float xInput;
	public float speed;
	public Rigidbody2D rbody;
	public float jumpPower;
    public float smoothSpeed;
    float dragTarget;
    public float dragChangeSpeed;
    public float maxDrag;
    public float minDrag;


	// Update is called once per frame
	void Update () {
        rbody.drag = Mathf.Lerp(rbody.drag, dragTarget, dragChangeSpeed);
        
		xInput = Input.GetAxis( "Horizontal" );
        if( xInput == 0f )
        {
            dragTarget = maxDrag;
        }
        if( Input.GetButton("Down"))
        {
            dragTarget = minDrag;
        }
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
