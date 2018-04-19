using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerSwitch : PowerLine, IPointerClickHandler {
    public List<int> realLinks;
    public PowerLine[] allLinks;
    void Awake() {
        myLine = this.GetComponent<PowerLine>();
        spr = this.GetComponent<Image>();
        spr.color = Color.gray;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void rotateLeft() {
        //rotate links
        for (int i = 0; i < realLinks.Count; i++)
            realLinks[i] = (7 + realLinks[i]) % 8;
        
        //refresh reference
        for (int i = 0; i < 8; i++) {
            if (realLinks.Contains(i))
                connections[i] = allLinks[i];
            else
                connections[i] = null;
        }
        
        refresh();
    }

    public void rotateRight() {
        //rotate links
        for (int i = 0; i < realLinks.Count; i++)
            realLinks[i] = (realLinks[i] + 1) % 8;

        //refresh reference
        for (int i = 0; i < 8; i++) {
            if (realLinks.Contains(i))
                connections[i] = allLinks[i];
            else
                connections[i] = null;
        }

        refresh();
    }

    public void refresh() {
        fonts.Clear();
        on = false;
        spr.color = Color.gray;
        for (int i = 0; i < 8; i++) {
            if (allLinks[i] != null) {
                allLinks[i].turnOff(myLine);
                if (allLinks[i].on && realLinks.Contains(i)) {
                    on = true;
                    spr.color = Color.yellow;
                    fonts.Add(allLinks[i]);
                }
            }
        }

        foreach(int i in realLinks) {
            if(connections[i] != null) {
                if (on) {
                    if (!fonts.Contains(connections[i]))
                        connections[i].turnOn(myLine);
                } else
                    connections[i].turnOff(myLine);
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left)
            rotateLeft();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rotateRight();
    }
}