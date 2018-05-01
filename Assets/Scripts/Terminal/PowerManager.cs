using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerManager : MonoBehaviour {

    public static PowerManager instance;
    public PowerFont[] allFonts;
    public PowerButton button;
    void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
        
    }

	// Use this for initialization
	void Start () {
        Invoke("turnOnCircuit", 8 * Time.deltaTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void turnOnCircuit() {
        foreach (PowerFont f in allFonts)
            f.sendEnergy();
    }

    public void turnOffCircuit() {
        foreach (PowerFont f in allFonts)
            f.cutEnergy();
    }

    public void finish() {
        Debug.Log("FIM");
    }
}