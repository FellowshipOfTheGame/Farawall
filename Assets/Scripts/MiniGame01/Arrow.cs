using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
public class Arrow : MonoBehaviour {

	private Rigidbody2D Rigid;
	float speed = 20f;
	float damage;

	void Awake(){
		Rigid = GetComponent<Rigidbody2D> ();
	}

	void FixedUpdate(){
		Vector2 vel = (Vector2) transform.right * speed;
		Rigid.velocity = vel;
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Animal") {
			Animals a = col.gameObject.GetComponent<Animals> ();
			if (a.isAlive) {
				a.Hit (damage);
				if (tag != "UltraArrow") {
					Destroy (gameObject);
				}
			}
		}
		else if (col.gameObject.tag == "Limit") {
			Destroy (gameObject);
		}
	}

	public void SetSpeed(float newSpeed){
		speed = newSpeed;
	}

	public void SetDamage(float newDamage){
		damage = newDamage;
	}

}
