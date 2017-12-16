using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : Interactable {
	public Door door;

	public override void Interact (){
		if(nearPlayer) door.Unlock ();
	}

	public override void Close(){
		Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Player")
		nearPlayer = true;
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player")
		nearPlayer = false;
	}
}
