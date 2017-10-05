using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DirAjust(float angle) {
        this.transform.parent.Rotate(Vector3.up, angle);
        this.GetComponent<Animator>().SetTrigger("Stop");
        this.transform.parent.parent.GetComponent<PlayerControl>().isTurning = false;
    }
}
