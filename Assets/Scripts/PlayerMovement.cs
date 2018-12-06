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

    public GameObject pauseScreen;
    public SpriteRenderer rend;

    public GameObject currentLocTxt;
    public float locFloat;
    public int locInt;
    public string locString;

    public GameObject HighestLocTxt;
    public string HLString;
    public int HLInt;

    public string currentMoth;
    public string oldMothString;
    public Animator anim;

    public RuntimeAnimatorController Moth;
    public RuntimeAnimatorController Moth2;
    public RuntimeAnimatorController Moth3;
    public RuntimeAnimatorController Moth4;

    void Start ()
    {
        Manager.singleton.Load( "mySave" );
       
        anim = this.GetComponent<Animator>();
        HLInt = PlayerPrefs.GetInt("highPoint");
        HLString = HLInt.ToString();
        //HighestLocTxt.GetComponent<Text>().text = HLString;

        ChooseMoth();
        Manager.singleton.paused = false;
        Manager.singleton.canPause = true;
        this.transform.position = Manager.singleton.lastLampPos;
        //if (Manager.singleton.currentMoth.appearance.name == "Moth2") print("Moth2 is selected");
        currentMoth = Manager.singleton.currentMoth.appearance.name;
		if (currentMoth == "Moth") anim.runtimeAnimatorController = Moth;
		else if (currentMoth =="Moth2") anim.runtimeAnimatorController = Moth2;
		else if (currentMoth =="Moth3") anim.runtimeAnimatorController = Moth3;
		else if (currentMoth =="Moth4") anim.runtimeAnimatorController = Moth4;
		

    }

    void ChooseMoth()
    {
        rend.sprite = Manager.singleton.currentMoth.appearance;
    }

	// Update is called once per frame
	void Update () {
        rbody.drag = Mathf.Lerp(rbody.drag, dragTarget, dragChangeSpeed);
        
		xInput = Input.GetAxis( "Horizontal" );
        if( xInput == 0f && Manager.singleton.paused == false)
        {
            dragTarget = maxDrag;
        }
        if( Input.GetButton("Down") && Manager.singleton.paused == false)
        {
            dragTarget = minDrag;
        }
		if( Input.GetButtonDown( "Jump" ) && Manager.singleton.paused == false){
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
            //HLString = HLInt.ToString();
            HighestLocTxt.GetComponent<Text>().text = HLString;
        }

        if (Input.GetButtonDown("Cancel"))
        {
            if (Manager.singleton.paused == false && Manager.singleton.canPause == true)
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                Manager.singleton.paused = true;
            }
            else if (Manager.singleton.canPause == true)
            {
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                Manager.singleton.paused = false;
            }
        }
        



        //change Vector3.forward to the current position - the previous
        transform.up = rbody.velocity;


	}

	void FixedUpdate() {
		rbody.velocity = Vector2.Lerp(rbody.velocity, new Vector2( xInput * speed, rbody.velocity.y ), smoothSpeed);
	}

	void Jump() {
		rbody.AddForce( Vector2.up * jumpPower, ForceMode2D.Impulse );
		 anim.SetTrigger( "flap" );
	}
}
