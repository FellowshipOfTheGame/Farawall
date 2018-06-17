using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Informer : MonoBehaviour {

    public int id;
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
			GameManager.instance.activedPuzzles[id].AddInfo(info);
            isNew = false;
        }
    }

    public void checkPuzzle() {
		if (GameManager.instance.activedPuzzles[id].isFull() && GameManager.instance.activedPuzzles[id].isFull2()) {
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>() as Key;
			k.door = GameManager.instance.activedPuzzles[id].endDoor;
        }
    }
}
