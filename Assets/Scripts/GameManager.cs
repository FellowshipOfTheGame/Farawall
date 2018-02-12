using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public CameraControl mainCam;
    public Canvas canvas;
    public PlayerControl player;
    public GameObject menu;
    public GameObject gameOver;
    public bool paused = false;
    public PuzzleInfo[] puzzles;
    // Use this for initialization
    void Start () {
        Transform aux = transform.Find("Puzzles");
        puzzles = new PuzzleInfo[aux.childCount];
        for (int i = 0; i < aux.childCount; i++) {
            puzzles[i] = aux.GetChild(i).GetComponent<PuzzleInfo>();
            aux.GetChild(i).gameObject.SetActive(false);
        }
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
