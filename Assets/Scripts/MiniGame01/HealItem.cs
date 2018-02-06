using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealItem : MonoBehaviour {

	public int hp;

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Player") {
			//col.GetComponent<Neith> ().Heal (hp);
			Destroy (gameObject);
		}
	}

}
