using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public bool sceneInGame;
	public static bool inGame;
	public static CameraControl mainCam;
	public static PlayerControl player;
	public static InGameMenu menu;
	public static bool paused = false;
	public static List<PuzzleInfo> activedPuzzles;


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

		}
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
			startGame ();
		} else if (scene == "Menu") {
			endGame ();
		}
        
    }

    static void startGame() {
        activedPuzzles = new List<PuzzleInfo>();
        paused = false;
        inGame = true;
    }

	static void endGame(){
		inGame = false;
		paused = false;
		activedPuzzles = null;
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

    public static void ActivePuzzle(PuzzleInfo p) {
        if (activedPuzzles.Count == 0)
            menu.transform.Find("DataTab").Find("Buttons").Find("PuzzleButton").gameObject.SetActive(true);

        p.id = activedPuzzles.Count;
        activedPuzzles.Add(p);
        for (int i = 0; i < p.statues.Length; i++)
            p.statues[i].GetComponent<Informer>().puzzleId = p.id;
        for (int i = 0; i < p.solutions.Length; i++)
            p.solutions[i].GetComponent<Solutioner>().puzzleId = p.id;
    }

    public static void ShowGameOver() {
		GameObject.Find ("Canvas").transform.Find ("GameOver").gameObject.SetActive(true);
		Time.timeScale = 0.0f;
    }
}
