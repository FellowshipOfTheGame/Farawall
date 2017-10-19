using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animals))]
public class Bull : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animals animals;
	public float maxLife = 30f;
	public float touchingDamage = 50f;
	public float speed = 3f;
	Neith Player;
	bool positionSet = false;
	bool waiting = false;
	public float timeWaiting = 0.5f;
	float _time = 0f;
	Vector2 nextPos;

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
			if (!positionSet) {
				nextPos = Player.transform.position;
				Vector2 moveDirection = nextPos - (Vector2) transform.position;
				Vector2 moveVelocity = moveDirection.normalized * speed;
				Rigid.velocity = moveVelocity;
				positionSet = true;
			} else {
				if (Mathf.Abs(Mathf.Sqrt(Mathf.Pow(transform.position.x - nextPos.x, 2) + Mathf.Pow(transform.position.y - nextPos.y, 2))) <= .1f){
					if (!waiting) {
						_time = 0f;
						waiting = true;
						Rigid.velocity = Vector2.zero;
					} else {
						_time += Time.fixedDeltaTime;
						if (_time >= timeWaiting) {
							positionSet = false;
							waiting = false;
						}
					}
				}
			}
		} else {
			Rigid.velocity = Vector2.zero;
		}
	}

}
