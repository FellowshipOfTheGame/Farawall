using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance;
    public bool inGame;
    [HideInInspector] public CameraControl mainCam;
    [HideInInspector] public PlayerControl player;
    [HideInInspector] public InGameMenu menu;
    [HideInInspector] public bool paused = false;
    [HideInInspector] public List<PuzzleInfo> activedPuzzles;

    void Awake() {
        if (instance == null) {
            instance = this;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        if (inGame)
            startGame();
    }
	
	// Update is called once per frame
	void Update () {
		if (inGame && Input.GetKeyDown(KeyCode.Escape))
            pausePlay();
	}

    public void loadGameScene(string scene) {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
        startGame();
    }

    void startGame() {
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
        //gameOver.SetActive(true);
    }
}
