using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerButton : PowerLine, IPointerClickHandler {

    public Sprite onSprite, offSprite;
    // Use this for initialization
    void Start () {
        sprs[0].sprite = offSprite;
        sprs[0].color = Color.white;
	}
	
	// Update is called once per frame
	void Update () {
        		
	}

    public override void turnOn(PowerLine first) {
        bool aux = true;
        foreach (PowerLine p in connections) {
            if (p != null)
                aux &= p.on;
        }

        if (aux) turnButtonOn();
    }

    public override void turnOff(PowerLine first) {
        sprs[0].sprite = offSprite;
        sprs[0].color = Color.white;
    }

    void turnButtonOn() {
        on = true;
        sprs[0].sprite = onSprite;
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (on) PowerManager.instance.finish();
    }
}
