using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour {
    public GameObject menu;
    private bool active;

	// Use this for initialization
	void Start () {
        active = false;
        menu.SetActive(active);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M)){
            active = !active;
            menu.SetActive(active);
        }
	}
}
