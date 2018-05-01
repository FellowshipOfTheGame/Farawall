using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMotionTrap : MonoBehaviour {
	public float limitAngle = 90;
	public float speed = 1;
	[HideInInspector]
	public GameObject blade;
	[HideInInspector]
	public Vector3 pivot;
	private bool near;
	private float currentAngle = 0;

	void Start (){
		pivot = Vector3.up;
		blade = transform.Find ("Blade").gameObject;
		near = false;
	}

	void Update () {
		if (near) {
			blade.transform.position += blade.transform.rotation * pivot;
			blade.transform.rotation = Quaternion.AngleAxis (currentAngle, Vector3.right);
			blade.transform.position -= blade.transform.rotation * pivot;
			if (currentAngle > limitAngle || currentAngle < -limitAngle) {
				speed *= -1;
			}
			currentAngle += speed;
		}
	}

	void OnTriggerEnter(Collider other){
		near = true;
	}

	void OnTriggerExit(Collider other){
		near = false;
	}
}
