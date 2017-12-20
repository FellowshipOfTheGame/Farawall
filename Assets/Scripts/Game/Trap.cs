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

	void Start () {
		spears.position = startPosition.position;
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
