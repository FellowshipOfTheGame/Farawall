using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animator))]
public class NeithController : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animator Anim;
	public float speed = 5f;

	void Awake(){
		Rigid = GetComponent<Rigidbody2D> ();
		Anim = GetComponent<Animator> ();
	}

	void FixedUpdate(){
		Move ();
		Rotation ();
		Animations ();
	}

	void Move(){
		Vector2 moveDirection = new Vector3 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 moveVelocity = moveDirection.normalized * speed;
		Rigid.velocity = moveVelocity;
	}

	void Rotation(){
		Vector3 pos = Input.mousePosition;
		pos = Camera.main.ScreenToWorldPoint(pos) - transform.position;
		float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp (transform.rotation, q, 1f);
	}

	void Animations(){
		Anim.SetBool ("Walking", Mathf.Abs (Rigid.velocity.magnitude) > 0.01f);
	}


}
