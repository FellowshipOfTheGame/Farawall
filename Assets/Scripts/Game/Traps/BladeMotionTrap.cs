using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeMotionTrap : MonoBehaviour {
	private bool rotated = false;
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
		if (this.transform.rotation.y != 0)
			rotated = true;
	}

	void Update () {
		if (near) {
			blade.transform.position += blade.transform.rotation * pivot;
			if (rotated){
				blade.transform.rotation = Quaternion.Euler(currentAngle,90,0);
			}else
				blade.transform.rotation = Quaternion.Euler (currentAngle,0,0);
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
