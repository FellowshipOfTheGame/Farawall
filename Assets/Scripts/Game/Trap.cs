using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
	public Transform startPosition;
	public Transform endPosition;
	public Transform spears;
	public float speed;
	private bool active = false;
	private bool deactivate = false;
	private float startTime;
	private float distance;
	private Vector3 start;
	private Vector3 end;

	void Start () {
		spears.position = startPosition.position;
		distance = Vector3.Distance (startPosition.position, endPosition.position);
	}

	void Update () {
		if (active) {
			float coveredDistance = (Time.time - startTime) * speed;
			float currentPosition = coveredDistance / distance;
			spears.position = Vector3.Lerp (start, end, currentPosition);
			if (spears.position == end) {
				if (deactivate && end == startPosition.position) {
					deactivate = false;
					active = false;
				}
				Vector3 aux;
				aux = end;
				end = start;
				start = aux;
				startTime = Time.time;
			}
		}
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			start = startPosition.position;
			end = endPosition.position;
			active = true;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			deactivate = true;
		}
	}
}
