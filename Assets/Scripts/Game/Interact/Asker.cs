using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asker : MonoBehaviour {

    bool isNew = true;
    public bool endPuzzle;
    public int id;

	// Use this for initialization
	void Start () {
	}

    public void talk() {
        activePuzzle();
    }

    public void activePuzzle() {
        if (isNew) {
			GameManager.instance.ActivePuzzle(id);
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>() as Key;
            k.door = GameManager.instance.activedPuzzles[id].startDoor;
            isNew = false;
        }
    }
}