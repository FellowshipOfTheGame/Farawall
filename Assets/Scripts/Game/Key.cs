using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable {
    GameManager gm;
	public Door door;

    void Start() {
        gm = FindObjectOfType<GameManager>();
    }

    void Update() {
        this.transform.Find("Sprite").Rotate(0.0f, 30.0f * Time.deltaTime, 0.0f);
        if (nearPlayer)
            this.transform.Find("Sprite").Find("Eye").gameObject.SetActive(true);
        else
            this.transform.Find("Sprite").Find("Eye").gameObject.SetActive(false);
    }

	public override void Interact (){
        gm.player.addKey(door.code);
        Debug.Log("Got key " + door.code);
        Close();
	}

	public override void Close(){
        Destroy(this.gameObject);
    }

    public override void Near() {
        nearPlayer = true;      
	}

	public override void Away(){
        nearPlayer = false;
	}
}
