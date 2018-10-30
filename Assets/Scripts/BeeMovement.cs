using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {

	private bool dirRight = true;
    public float speed;
 
    void Update () {
        if (dirRight)
            transform.Translate (Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate (-Vector2.right * speed * Time.deltaTime);
        
        if(transform.position.x >= 43.0f) {
            Flip();
            dirRight = false;
        }
        
        if(transform.position.x <= -43) {
            Flip();
            dirRight = true;
        }
    }

    void Flip()
    {
    	Vector3 theScale = transform.localScale;
    	theScale.x *= -1;
    	transform.localScale = theScale;
    }
    void OnTriggerEnter()
    {
    	//death screen and stop time
    	
    }
}
