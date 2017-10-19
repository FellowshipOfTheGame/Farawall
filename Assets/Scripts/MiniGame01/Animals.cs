using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (BoxCollider2D))]
public class Animals : MonoBehaviour {

	private BoxCollider2D col;
	float touchingDamage = 10f;
	float hp = 20f;
	public bool isAlive = true;

	void Awake(){
		col = GetComponent<BoxCollider2D> ();
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			Neith n = col.gameObject.GetComponent<Neith> ();
			n.Hurt (touchingDamage);
		}
	}

	public void SetProperties(float newHP, float newDamage){
		hp = newHP;
		touchingDamage = newDamage;
	}

	public void Hit(float hitDamage){
		hp -= hitDamage;
		if (hp <= 0f) {
			Die ();
		}
	}

	void Die(){
		col.isTrigger = true;
		isAlive = false;
		print (gameObject.name + " faliceu");
		//Destroy (gameObject);
	}

}
