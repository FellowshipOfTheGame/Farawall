using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerLine : MonoBehaviour {

    public bool on = false;
    public PowerLine[] connections;
    public List<PowerLine> fonts = new List<PowerLine>();
    protected PowerLine myLine;
    protected Image spr;
	// Use this for initialization
	void Awake () {
        myLine = this.GetComponent<PowerLine>();
        spr = this.GetComponent<Image>();
        spr.color = Color.gray;
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void turnOn(PowerLine font) {
        if (!fonts.Contains(font))
            fonts.Add(font);
        if (!on) {
            foreach (PowerLine aux in connections) {
                if (aux != null && aux != font)
                    aux.turnOn(myLine);
                
            }
            on = true;
            spr.color = Color.yellow;
        }
    }

    public void turnOff(PowerLine font) {
        if (fonts.Contains(font))
            fonts.Remove(font);
        
        if (on && fonts.Count == 0) {
            foreach(PowerLine aux in connections) {
                if (aux != null && aux != font)
                    aux.turnOff(myLine);
            }
            on = false; 
            spr.color = Color.gray;
            Debug.Log("desliga " + name);
        }
    }
}