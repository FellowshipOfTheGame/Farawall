using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerLine : MonoBehaviour {


    [HideInInspector] public bool on = false, haveFont = false;
    public PowerLine[] connections = new PowerLine[8];
    protected List<Image> sprs = new List<Image>();
    protected Color onColor;

    // Use this for initialization
    void Awake() {
        for (int i = 0; i < transform.childCount; i++)
            sprs.Add(transform.GetChild(i).GetComponent<Image>());

        onColor = sprs[0].color;

        foreach (Image spr in sprs) { spr.color = Color.clear; }

    }

    public virtual void turnOn(PowerLine first) {
        if (first != this) {
            if (!on) {
                on = true;
                foreach (Image spr in sprs) spr.color = onColor;
                foreach (PowerLine p in connections) {
                    if (p != null && p.gameObject.activeInHierarchy)
                        p.turnOn(first);
                }
            }
        }
    }

    public virtual void turnOff(PowerLine first) {
        if (first != this) {
            if (on) {
                on = false;
                foreach (Image spr in sprs) spr.color = Color.clear;
                foreach (PowerLine p in connections) {
                    if (p != null && p.gameObject.activeInHierarchy)
                        p.turnOff(first);
                }
            }
        }
    }

    public int getReference(PowerLine s) {
        int i = 7;
        while (i >= 0 && connections[i] != s) i--;
        return i;
    }
}