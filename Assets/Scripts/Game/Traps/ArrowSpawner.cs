using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowSpawner : Spawner {

	private GameObject arrow;
	private Transform target;
	public float speed;

	void Start(){
		arrow = transform.Find ("Arrow").gameObject;
		target = transform.Find ("Target").transform;
	}

	override public void Spawn(){
		Arrow temp = Instantiate (arrow,transform).GetComponent<Arrow> ();
		temp.startPosition = this.transform;
		temp.endPosition = target;
		temp.speed = speed;
		temp.gameObject.SetActive (true);
	}
}
