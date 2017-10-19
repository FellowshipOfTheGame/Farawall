using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
[RequireComponent (typeof (Animals))]
public class AnimalRotation : MonoBehaviour {

	private Rigidbody2D Rigid;
	private Animals animal;

	void Awake(){
		Rigid = GetComponent<Rigidbody2D> ();
		animal = GetComponent<Animals> ();
	}

	void FixedUpdate(){
		if (animal.isAlive) {
			Vector2 velocity = Rigid.velocity;
			transform.localScale = new Vector3 (Mathf.Abs (transform.localScale.x) * Mathf.Sign (velocity.x), transform.localScale.y, transform.localScale.z);
			float velocityAngle = Mathf.Atan2 (velocity.y, velocity.x) * Mathf.Rad2Deg;
			//print (velocityAngle);
			float angle = newAngle(velocityAngle);
			Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
			transform.rotation = Quaternion.Slerp (transform.rotation, q, 1f);
		}
	}

	private float newAngle(float actAngle){
		if ((actAngle >= 0f && actAngle < 22.5f) || (actAngle < 0f && actAngle > -22.5f))
			return 0f;
		if (actAngle >= 22.5f && actAngle < 90f)
			return 45f;
		if (actAngle >= 90f && actAngle < 157.5f)
			return -45f;
		if ((actAngle >= 157.5f && actAngle <= 180f) || (actAngle >= -180f && actAngle <= -157.5f))
			return 0f;
		if (actAngle > -157f && actAngle <= -90f)
			return 45f;
		else
			return -45f;
	}

}
