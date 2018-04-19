using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerFont : PowerLine {

	// Use this for initialization
	void Awake () {
        on = true;
        spr = this.GetComponent<Image>();
        spr.color = Color.yellow;
        myLine = this.GetComponent<PowerFont>();
    }

    void Start() {
        foreach (PowerLine aux in connections) {
            if (aux != null)
                aux.turnOn(myLine);
        }
    }
	
	// Update is called once per frame
	void Update () {

	}
}
