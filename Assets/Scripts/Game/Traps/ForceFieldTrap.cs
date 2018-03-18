using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldTrap : MonoBehaviour {

	private GameObject forceField;
	public bool activated = true;

	void Start () {
		forceField = transform.Find ("ForceField").gameObject;
		forceField.SetActive (false);
	}

	void OnTriggerEnter(Collider other){
		if (activated)
			forceField.SetActive (true);
	}

	void OnTriggerExit(Collider other){
		if (activated)
			forceField.SetActive (false);
	}
}
