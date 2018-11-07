using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {

	public string levelToLoad;

	public void LoadLevel() {
		SceneManager.LoadScene( levelToLoad );
		Time.timeScale = 1;
		//Manager.singleton.Deactivate();
	}

	public void StartTime()
	{
		Time.timeScale = 1;
		GameObject pauseCanvas = GameObject.Find("Pause Canvas");
		pauseCanvas.SetActive(false);
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

	}

}
