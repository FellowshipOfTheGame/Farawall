using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asker : MonoBehaviour {

    bool isNew = true;
    public bool endPuzzle;
    PuzzleInfo puzzle;
    StatueControl myStatue;

	// Use this for initialization
	void Start () {
        myStatue = this.GetComponent<StatueControl>();
        puzzle = this.GetComponent<PuzzleInfo>();
	}

    public void talk() {
        activePuzzle();
    }

    public void activePuzzle() {
        if (isNew) {
			GameManager.ActivePuzzle(puzzle);
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>() as Key;
            k.door = puzzle.startDoor;
            isNew = false;
        }
    }
}