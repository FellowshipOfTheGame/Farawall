using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPuzzle : Interactable {

    public int puzzleID, type;
    public TextMesh namePlace;
    public string title;
    public Sprite art;
    // Use this for initialization
    void Start () {
        namePlace.text = title;
        namePlace.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Interact() {
        GameManager.activedPuzzles[puzzleID].AddItem(this);
        Close();
    }

    public override void Close() {
        Destroy(this.gameObject);
    }

    public override void Near() {
        namePlace.gameObject.SetActive(true);
        nearPlayer = true;
    }

    public override void Away() {
        namePlace.gameObject.SetActive(false);
        nearPlayer = false;
    }
}
