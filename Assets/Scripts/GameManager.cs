using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager gm;
    public bool inGame;
    [Space (5)]
    public CameraControl mainCam;
    public Canvas canvas;
    public PlayerControl player;
    public InGameMenu menu;
    GameObject gameOver;
    public bool paused = false;
    public List<PuzzleInfo> activedPuzzles;
    // Use this for initialization
    void Start () {
        if (inGame)
            startGame();
        else
            gm = this.GetComponent<GameManager>();
    }
	
	// Update is called once per frame
	void Update () {
		if (inGame && Input.GetKeyDown(KeyCode.Return))
            pausePlay();
	}

    void startGame() {
        mainCam = FindObjectOfType<CameraControl>() as CameraControl;
        canvas = FindObjectOfType<Canvas>() as Canvas;
        menu = FindObjectOfType<InGameMenu>() as InGameMenu;
        menu.gameObject.SetActive(false);
        activedPuzzles = new List<PuzzleInfo>();
        paused = false;
        inGame = true;
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

    public void ActivePuzzle(PuzzleInfo p) {
        if (activedPuzzles.Count == 0)
            menu.transform.Find("DataTab").Find("Buttons").Find("PuzzleButton").gameObject.SetActive(true);

        p.id = activedPuzzles.Count;
        activedPuzzles.Add(p);
        for (int i = 0; i < p.statues.Length; i++)
            p.statues[i].GetComponent<Informer>().puzzleId = p.id;
        for (int i = 0; i < p.solutions.Length; i++)
            p.solutions[i].GetComponent<Solutioner>().puzzleId = p.id;
    }

    public void ShowGameOver() {
        paused = true;
        gameOver.SetActive(true);
    }
}
