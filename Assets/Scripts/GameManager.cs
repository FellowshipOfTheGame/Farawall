using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public CameraControl mainCam;
    public Canvas canvas;
    public PlayerControl player;
    public InGameMenu menu;
    public GameObject gameOver;
    public bool paused = false;
    public PuzzleInfo[] puzzles;
    public List<PuzzleInfo> activedPuzzles;
    // Use this for initialization
    void Start () {
        activedPuzzles = new List<PuzzleInfo>();
        Transform aux = transform.Find("Puzzles");
        puzzles = new PuzzleInfo[aux.childCount];
        for (int i = 0; i < aux.childCount; i++) {
            puzzles[i] = aux.GetChild(i).GetComponent<PuzzleInfo>();
        }
        paused = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
            pausePlay();
	}

    public void pausePlay() {
        if (paused) {
            menu.gameObject.SetActive(false);
            menu.Reset();
            Time.timeScale = 1.0f;
            paused = false;
        } else {
            menu.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            paused = true;
        }
    }

    public void ActivePuzzle(int id) {
        if (id < puzzles.Length && activedPuzzles.Count == 0)
            menu.transform.Find("DataTab").Find("Buttons").Find("PuzzleButton").gameObject.SetActive(true);
        activedPuzzles.Add(puzzles[id]);
        Debug.Log("active " + id);
    }

    public void ShowGameOver() {
        paused = true;
        gameOver.SetActive(true);
    }
}
