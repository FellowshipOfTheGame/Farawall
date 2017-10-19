using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animals))]
public class Elephant : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animals animals;
	public float maxLife = 50f;
	public float touchingDamage = 20f;
	public float speed = .5f;

	void Awake(){
		Rigid = GetComponent<Rigidbody2D> ();
		animals = GetComponent<Animals> ();
	}

	void Start(){
		animals.SetProperties (maxLife, touchingDamage);
		int dirSignal = transform.position.x >= 0 ? -1 : 1;
		Rigid.velocity = (Vector2)transform.right * dirSignal * speed;
	}

	void FixedUpdate(){
		if (!animals.isAlive) {
			Rigid.velocity = Vector2.zero;
		}
	}
/*
	void OnTriggerExit2D(Collider2D col){
		if (col.gameObject.tag == "Limit") {
			Destroy (gameObject);
		}
	}
*/
}
