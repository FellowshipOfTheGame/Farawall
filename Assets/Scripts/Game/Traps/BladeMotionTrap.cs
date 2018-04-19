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
		pivot = transform.Find ("Pivot").gameObject.transform.position;
		blade = transform.Find ("Blade").gameObject;
		near = false;
	}

	void Update () {
		if (near) {
			blade.transform.rotation = Quaternion.Euler (new Vector3 (currentAngle, 0, 0));
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
