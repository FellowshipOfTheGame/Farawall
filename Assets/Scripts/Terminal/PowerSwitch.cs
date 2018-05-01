using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PowerSwitch : PowerLine, IPointerClickHandler {

    PowerLine[] allLinks = new PowerLine[8];
    public List<int> realLinks;
    int[] references = new int[8];

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 8; i++) {
            allLinks[i] = connections[i];
            if (allLinks[i] != null)
                references[i] = allLinks[i].getReference(this);
            else
                references[i] = -1;

            if (!realLinks.Contains(i)) {
                if (connections[i] != null)
                    connections[i].connections[references[i]] = null;

                connections[i] = null;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void rotateLeft() {
        //rotate links
        for (int i = 0; i < realLinks.Count; i++)
            realLinks[i] = (6 + realLinks[i]) % 8;
       
        this.transform.Rotate(Vector3.forward, 90.0f);
        refresh();
    }

    public void rotateRight() {
        //rotate links
        for (int i = 0; i < realLinks.Count; i++)
            realLinks[i] = (realLinks[i] + 2) % 8;

        this.transform.Rotate(Vector3.forward, -90.0f);
        refresh();
    }

    public void refresh() {
        PowerManager.instance.turnOffCircuit();
        connections = new PowerLine[8];
        for (int i = 0; i < 8; i++) {
            if (realLinks.Contains(i)) {
                connections[i] = allLinks[i];
                if (allLinks[i] != null)
                    allLinks[i].connections[references[i]] = this;
            } else {
                if (allLinks[i] != null)
                    allLinks[i].connections[references[i]] = null;
            }
        }
        PowerManager.instance.turnOnCircuit();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Left)
            rotateLeft();
        else if (eventData.button == PointerEventData.InputButton.Right)
            rotateRight();
    }
}