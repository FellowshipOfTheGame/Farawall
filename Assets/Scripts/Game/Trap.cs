using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {
	public Transform startPosition;
	public Transform endPosition;
	public Transform spears;
	public float speed;
    public float delay;
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
            if (spears.position != endPosition.position)
                spears.position = Vector3.Lerp(spears.position, endPosition.position, delay);
            else
                active = false;
        }

        if (deactivate) {
            if (spears.position != startPosition.position)
                spears.position = Vector3.Lerp(spears.position, startPosition.position, delay/5);
            else
                deactivate = false;
        }
        /*
        if (active) {
			float coveredDistance = (Time.time - startTime) * speed;
			float currentPosition = coveredDistance / distance;
			
			if (spears.position == end) {
				if (deactivate && end == endPosition.position) {
					deactivate = false;
					active = false;
				}
				Vector3 aux;
				aux = end;
				end = start;
				start = aux;
				startTime = Time.time;
			}
		}*/
    }

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
            spears.position = startPosition.position;
            active = true;
            deactivate = false;
		}
	}

	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
            spears.position = endPosition.position;
            deactivate = true;
            active = false;
		}
	}
}
