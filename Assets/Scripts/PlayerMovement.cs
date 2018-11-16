using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public SpriteRenderer rend;

    public GameObject currentLocTxt;
    public float locFloat;
    public int locInt;
    public string locString;

    public GameObject HighestLocTxt;
    public string HLString;
    public int HLInt;

    public string currentMothString;
    public string oldMothString;



    void Start ()
    {
    	transform.position = new Vector3(PlayerPrefs.GetFloat("LampPosX"), PlayerPrefs.GetFloat("LampPosY"), 0f);
              
        currentMothString = PlayerPrefs.GetString("activeMoth", "Moth1");
        
        HLInt = PlayerPrefs.GetInt("highPoint");
        HLString = HLInt.ToString();
        HighestLocTxt.GetComponent<Text>().text = HLString;

        ChooseMoth();
    }

    void ChooseMoth()
    {
        rend.sprite = Manager.singleton.currentMoth.appearance;
    }

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
        
        locFloat = this.transform.position.y;
        locInt = Mathf.RoundToInt(locFloat);
        locString = locInt.ToString();
        currentLocTxt.GetComponent<Text>().text = locString;

        if(locInt > HLInt)
        {
            HLInt = locInt;
            PlayerPrefs.SetInt("highPoint", HLInt);
            HLString = HLInt.ToString();
            HighestLocTxt.GetComponent<Text>().text = HLString;
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
