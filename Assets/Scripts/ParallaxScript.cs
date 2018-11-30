using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScript : MonoBehaviour {

    public GameObject cam;
    public GameObject bg;
    public float newBGpos;

    public float bgPos;
    public float camPos;
    
    // Update is called once per frame
    void Update () {
        camPos = transform.position.y;
        bgPos = transform.position.y;

	}
    void LateUpdate()
    {
        bgPos = camPos * 0.9f;
    }
}
