using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerControl player;
    public GameObject menu;
    public GameObject gameOver;
    public bool paused = false;

    // Use this for initialization
    void Start () {
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ShowGameOver() {
        paused = true;
        gameOver.SetActive(true);
    }
}
