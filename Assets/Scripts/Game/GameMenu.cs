using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenu: MonoBehaviour {
    public GameObject menu;
    private bool menuActive;


	// Use this for initialization
	void Start () {
        menuActive = false;
        menu.SetActive(menuActive);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			menuActive = !menuActive;
			menu.SetActive (menuActive);
			if (menuActive)
				Time.timeScale = 0.0f;
			else
				Time.timeScale = 1.0f;
		}
	}
}
