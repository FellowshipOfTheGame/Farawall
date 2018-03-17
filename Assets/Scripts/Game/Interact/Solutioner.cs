using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solutioner : MonoBehaviour {
    public int puzzleId;
    public string answer;
    public static Solutioner chosen = null;
    public Color chosenColor;

    public void chooseThis() {
        if (chosen != null) {
            StatueControl statue = chosen.GetComponent<StatueControl>();
            chosen.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = statue.offColor;
            statue.message.SetActive(false);
        }
        this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = chosenColor;
        chosen = this.GetComponent<Solutioner>();
    }

    public void check() {
		Debug.Log(GameManager.activedPuzzles[puzzleId].checkAnswer(answer));
    }
}
