using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Solutioner : MonoBehaviour {
    public int puzzleId;
    public string answer;
    public static Solutioner chosen = null;
    public Color chosenColor;
    public GameObject genSelfMenu;
    SolutionMenu selfMenu;

    public void Start() {
        if (genSelfMenu != null) {
            selfMenu = Instantiate(genSelfMenu, this.transform).GetComponent<SolutionMenu>();
            answer = string.Empty;
            for (int i = 1; i <= selfMenu.obj.Length * GameManager.activedPuzzles[puzzleId].solutions.Length; i++)
                answer += "-";
        }
    }

    public void chooseThis() {
        if (selfMenu == null) {
            if (chosen != null) {
                StatueControl statue = chosen.GetComponent<StatueControl>();
                chosen.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = statue.offColor;
                statue.message.SetActive(false);
            }
            this.transform.Find("Model3D").Find("Shine").GetComponent<MeshRenderer>().material.color = chosenColor;
            chosen = this.GetComponent<Solutioner>();
        }else {
            selfMenu.gameObject.SetActive(true);
        }
    }

    public void send() {
        foreach (StatueControl s in GameManager.activedPuzzles[puzzleId].solutions) {
            s.GetComponent<Solutioner>().answer = answer.Substring(0, selfMenu.order * selfMenu.obj.Length) + 
                selfMenu.obj.ToString() + answer.Substring((selfMenu.order + 1) * selfMenu.obj.Length - 1);
        }
    }

    public void check() {
		Debug.Log(GameManager.activedPuzzles[puzzleId].checkAnswer(answer));
    }
}