using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solutioner : MonoBehaviour {
    public int puzzleId;
    public string answer;
    public static Solutioner chosen = null;
    public Color chosenColor;
    public ItemPlace[] places;
    bool near = false;

    void Update() {
        if (near && places.Length > 0) {
            if (Input.GetKeyDown(KeyCode.RightArrow)) ItemPlace.selected.turnOff(1, false);

            if (Input.GetKeyDown(KeyCode.LeftArrow)) ItemPlace.selected.turnOff(-1, false);
        }
    }

    public void chooseThis() {
        near = true;
        if (chosen != null) {
            StatueControl statue = chosen.GetComponent<StatueControl>();
            chosen.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = statue.offColor;
            statue.message.SetActive(false);
        }
        this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = chosenColor;
        chosen = this.GetComponent<Solutioner>();

        if (places.Length > 0) {
            places[0].turnOn();
        }
    }

    public void send() {
        near = false;
        if (places.Length > 0) {
            answer = ItemPlace.globalAnswer;
            ItemPlace.selected.turnOff(0, true);
        }
    }

    public void check() {
		Debug.Log(GameManager.instance.activedPuzzles[puzzleId].checkAnswer(answer));
    }
}