using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceFieldTrap : MonoBehaviour {

	public GameObject forceField;
	public bool activated = true;
    bool visible = false;
    public Material fireMat;

	void Start () {
		forceField.SetActive (false);
	}

    void Update() {
        if (activated && visible)
            fireMat.mainTextureOffset += Vector2.one * 0.1f * Time.deltaTime;
    }

	void OnTriggerEnter(Collider other){
        if (activated) {
            forceField.SetActive(true);
            visible = true;
        }
	}

	void OnTriggerExit(Collider other){
        if (activated) {
            forceField.SetActive(false);
            visible = false;
        }
	}
}
