using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informer : MonoBehaviour {

    public int puzzleId;
    string info;
    public bool isNew = true;
	// Use this for initialization
	void Start () {
        StatueData data = this.GetComponent<StatueControl>().data;
        info = data.name + ": " + data.normalMessage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void sendMessage() {
        if (isNew) {
			GameManager.activedPuzzles[puzzleId].AddInfo(info);
            isNew = false;
        }
    }

    public void checkPuzzle() {
		if (GameManager.activedPuzzles[puzzleId].isFull()) {
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>() as Key;
			k.door = GameManager.activedPuzzles[puzzleId].endDoor;
        }
    }
}
