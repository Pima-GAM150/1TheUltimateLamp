using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeMovement : MonoBehaviour {

	private bool dirRight = false;
    public float speed;
 	public GameObject deathScreen;



    void Update () {
        if (dirRight)
            transform.Translate (Vector2.right * speed * Time.deltaTime);
        else
            transform.Translate (-Vector2.right * speed * Time.deltaTime);
        
        if(transform.position.x >= 43.0f) {
            Flip();
            dirRight = false;
        }
        
        if(transform.position.x <= -43.0f) {
            Flip();
            dirRight = true;
        }
    }

    void Flip()
    {
    	Vector3 theScale = transform.localScale;
    	if (dirRight)
    		theScale.x = 5;
    	else
    		theScale.x = -5;
    	//theScale.x *= -1;
    	transform.localScale = theScale;
    }
    

    
}
