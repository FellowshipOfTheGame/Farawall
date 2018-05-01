using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerFont : PowerLine {

    public List<PowerLine> links;

    void Start() {
        on = true;
        sprs[0].color = onColor;
    }

    public void sendEnergy() {
        foreach (PowerLine aux in links) {
            if (aux != null)
                aux.turnOn(this);
        }
    }

    public void cutEnergy() {
        foreach (PowerLine aux in links) {
            if (aux != null)
                aux.turnOff(this);
        }
    }
}
