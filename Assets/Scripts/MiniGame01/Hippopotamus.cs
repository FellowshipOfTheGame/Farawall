using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animals))]
public class Hippopotamus : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animals animals;
	public float maxLife = 20f;
	public float touchingDamage = 10f;
	public float speed = 1f;
	Neith Player;

	void Awake(){
		Rigid = GetComponent<Rigidbody2D> ();
		animals = GetComponent<Animals> ();
		Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Neith> ();
	}

	void Start(){
		animals.SetProperties (maxLife, touchingDamage);
	}

	void FixedUpdate(){
		if (animals.isAlive) {
			Vector2 moveDirection = (Vector2)(Player.transform.position - transform.position);
			Vector2 moveVelocity = moveDirection.normalized * speed;
			Rigid.velocity = moveVelocity;
		} else {
			Rigid.velocity = Vector2.zero;
		}
	}

}
