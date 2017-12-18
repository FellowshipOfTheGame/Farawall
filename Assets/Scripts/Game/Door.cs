using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door: Interactable {
	public Transform startPosition;
	public Transform endPosition;
	public Transform door;
	public bool hasKey;
	public float speed;
	private float startTime;
	private float distance;
	private bool isOpen = false;
	private bool openDoor = false;
	private bool closeDoor = false;
	private bool inMovement = false;
	private bool unlocked;

	void Start () {
		distance = Vector3.Distance (startPosition.position, endPosition.position);
		unlocked = !hasKey;
	}

	void Update () {
		float coveredDistance;
		float currentPosition;
		if (openDoor) {
			coveredDistance = (Time.time - startTime) * speed;
			currentPosition = coveredDistance / distance;
			door.position = Vector3.Lerp (startPosition.position, endPosition.position, currentPosition);
			if (door.position == endPosition.position) {
				isOpen = true;
				openDoor = false;
				inMovement = false;
			}
		} else if (closeDoor) {
			coveredDistance = (Time.time - startTime) * speed;
			currentPosition = coveredDistance / distance;
			door.position = Vector3.Lerp (endPosition.position, startPosition.position, currentPosition);
			if (door.position == startPosition.position) {
				isOpen = false;
				closeDoor = false;
				inMovement = false;
			}
		}
	}

	public override void Interact (){
		Camera.main.GetComponent<CameraControl>().currStatue = this.transform;
		Camera.main.GetComponent<CameraControl>().state = "statue";
		if (!inMovement) {
			startTime = Time.time;
			if (isOpen)
				closeDoor = true;
			else if(!hasKey || unlocked)
				openDoor = true;
			inMovement = true;
		}
	}

	public override void Close (){
		Camera.main.GetComponent<CameraControl>().state = "player";
		Camera.main.GetComponent<CameraControl>().currStatue = null;
	}

	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			nearPlayer = true;
		}
	}

	void OnTriggerExit(Collider other){
		if(other.tag == "Player"){
			nearPlayer = false;
			if (isOpen) {
				startTime = Time.time;
				closeDoor = true;
				inMovement = true;
			}
		}
	}

	public void Unlock(){
		unlocked = true;
	}
}