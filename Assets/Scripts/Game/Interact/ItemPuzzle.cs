using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPuzzle : Interactable {

    public int id;
    public TextMesh namePlace;
    public ItemData info;
    Transform model3d = null;
    // Use this for initialization
    void Start () {
        if (info != null) {
            namePlace.text = info.title;
            if (info.art3d != null)
                model3d = Instantiate(info.art3d, this.transform.GetChild(0)).transform;
        }
        namePlace.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (model3d != null)
            model3d.Rotate(Vector3.up, 5 * Time.deltaTime);
	}

    public override void Interact() {
        GameManager.instance.activedPuzzles[id].AddItem(this);
        if (GameManager.instance.activedPuzzles[id].isFull() && GameManager.instance.activedPuzzles[id].isFull2()) {
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>() as Key;
            k.door = GameManager.instance.activedPuzzles[id].endDoor;
        }
        Close();
    }

    public override void Close() {
        this.gameObject.SetActive(false);
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