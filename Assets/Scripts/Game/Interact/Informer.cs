﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informer : MonoBehaviour {

    GameManager gm;
    public int puzzleId;
    string info;
    public bool isNew = true;
	// Use this for initialization
	void Start () {
        gm = GameManager.instance;
        StatueData data = this.GetComponent<StatueControl>().data;
        info = data.name + ": " + data.normalMessage;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void sendMessage() {
        if (isNew) {
            gm.activedPuzzles[puzzleId].AddInfo(info);
            isNew = false;
        }
    }

    public void checkPuzzle() {
        if (gm.activedPuzzles[puzzleId].isFull()) {
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>() as Key;
            k.door = gm.activedPuzzles[puzzleId].endDoor;
        }
    }
}
