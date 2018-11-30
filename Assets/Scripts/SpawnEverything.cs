using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEverything : MonoBehaviour {

    public GameObject pollenPrefab;
    public GameObject rightLedgePrefab;
    public GameObject leftLedgePrefab;
    public GameObject beePrefab;
    public int pollenCounter;
    public int beeCounter;
    public int ledgeCounter;
    public float rndX;
    public float rndY;
    void Start()
    {
        pollenCounter = 0;
        beeCounter = 0;
        ledgeCounter = 0;

        for(int i = 0; i < 500; i++)
        {
            rndX = Random.Range(-43f, 43f);
            rndY = Random.Range(-43f, 14450f);
            GameObject newPollenPrefab = Instantiate(pollenPrefab, new Vector2(rndX, rndY), transform.rotation);

        }
            
    }
}
