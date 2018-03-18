using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour {
	public Transform startPosition;
	public Transform endPosition;
	public float speed;
	private float startTime;
	private float distance;

	void Start(){
		distance = Vector3.Distance (startPosition.position, endPosition.position);
		startTime = Time.time;
	}

	void Update(){
		if (this.transform == endPosition.transform) {
			Destroy (this);
			return;
		}
		float coveredDistance;
		float currentPosition;
		coveredDistance = (Time.time - startTime) * speed;
		currentPosition = coveredDistance / distance;
		this.transform.position = Vector3.Lerp (startPosition.position, endPosition.position,currentPosition);
	}

	void OnTiggerEnter(Collider other){
		Destroy (this.gameObject);
	}
}
