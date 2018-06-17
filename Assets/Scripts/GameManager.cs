using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public bool sceneInGame;
	public static bool inGame;
	public static CameraControl mainCam;
    public Canvas canvas;
	public static PlayerControl player;
    public static TerminalAccess activedTerminal = null;
	public static InGameMenu menu;
	public static bool paused = false;
	public PuzzleInfo[] activedPuzzles;

    void Awake() {
        if (instance == null) {
            instance = this;
			inGame = sceneInGame;
        } else if (instance != this) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
		if (inGame) {
			startGame ();
            loadPuzzles();
		}
    }

    void loadPuzzles() {
        activedPuzzles = new PuzzleInfo[this.transform.GetChild(0).childCount];
        for (int i = 0; i < activedPuzzles.Length; i++)
            activedPuzzles[i] = this.transform.GetChild(0).GetChild(i).GetComponent<PuzzleInfo>();
    }
	
	// Update is called once per frame
	void Update () {
		if (inGame && Input.GetKeyDown(KeyCode.Escape))
            pausePlay();
	}

    public static void loadGameScene(string scene) {
		string previousScene = SceneManager.GetActiveScene ().name;
		Time.timeScale = 1.0f;
		if (scene == "Reload") {
			scene = previousScene;
		}
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
		if (previousScene == "Menu") {
			GameManager.instance.startGame ();
		} else if (scene == "Menu") {
			endGame ();
		}
        
    }

    public void startGame() {
        paused = false;
        inGame = true;
        //desabilitar todos os puzzles no inicio
        foreach (PuzzleInfo p in activedPuzzles)
            p.enabled = false;
    }

	static void endGame(){
		inGame = false;
		paused = false;
	}

	public static void pausePlay() {
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

    public void ActivePuzzle(int i) {
        if (i == 0)
            menu.transform.Find("DataTab").Find("Buttons").Find("PuzzleButton").gameObject.SetActive(true);
        Debug.Log("Puzzle " + i + " actived");
        activedPuzzles[i].enabled = true;
    }

    public static void ShowGameOver() {
		GameObject.Find ("Canvas").transform.Find ("GameOver").gameObject.SetActive(true);
		Time.timeScale = 0.0f;
    }
}