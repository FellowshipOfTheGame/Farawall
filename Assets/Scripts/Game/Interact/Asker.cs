using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asker : MonoBehaviour {

    GameManager gm;
    bool isNew = true;
    public bool endPuzzle;
    PuzzleInfo puzzle;
    StatueControl myStatue;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>() as GameManager;
        myStatue = this.GetComponent<StatueControl>();
        puzzle = this.GetComponent<PuzzleInfo>();
	}

    public void talk() {
        activePuzzle();
    }

    public void activePuzzle() {
        if (isNew) {
            gm.ActivePuzzle(puzzle);
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>() as Key;
            k.door = puzzle.startDoor;
            isNew = false;
        }
    }
}