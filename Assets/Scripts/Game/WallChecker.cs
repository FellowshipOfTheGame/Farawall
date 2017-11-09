using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallChecker : MonoBehaviour {
    PlayerControl player;

	// Use this for initialization
	void Start () {
        player = this.transform.parent.parent.parent.GetComponent<PlayerControl>();
	}

    void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall")
            player.nearWall = true;
    }

    void OnTriggerExit(Collider other) {
        if (other.tag == "Wall")
            player.nearWall = false;
    }
}
