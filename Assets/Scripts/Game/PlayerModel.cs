using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

    public Animator anime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DirAjust(float angle) {
        this.transform.parent.Rotate(Vector3.up, angle);
        if (Input.GetKey(KeyCode.RightArrow)) {
            this.GetComponent<Animator>().SetTrigger("TurnRight");
        } else if (Input.GetKey(KeyCode.DownArrow)) {
            this.GetComponent<Animator>().SetTrigger("TurnBack");
        } else if (Input.GetKey(KeyCode.LeftArrow)) {
            this.GetComponent<Animator>().SetTrigger("TurnLeft");
        } else {
            this.GetComponent<Animator>().SetTrigger("Stop");
            this.transform.parent.parent.GetComponent<PlayerControl>().isTurning = false;
        }
    }

    public void JustStop() {
        this.transform.parent.parent.GetComponent<PlayerControl>().isTurning = false;
    }
}
