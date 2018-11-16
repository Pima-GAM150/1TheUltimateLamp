using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnToGame : MonoBehaviour {

   
  
    public GameObject ps;

    
    public void Return()
    {
        Time.timeScale = 1;
        ps.SetActive(false);
        Manager.singleton.paused = false;
    }
}
