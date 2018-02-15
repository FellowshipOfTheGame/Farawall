using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inquisitor : MonoBehaviour {

    GameManager gm;
    bool waitAnswer = false;
    public PuzzleInfo puzzle;
    public string correctMsg, wrongMsg, emptyMsg;
    StatueControl myStatue;

    // Use this for initialization
    void Start() {
        gm = FindObjectOfType<GameManager>() as GameManager;
        myStatue = this.GetComponent<StatueControl>();
    }

    public void talk() {
        getAnswer();
    }

    public void getAnswer() {
        if (!waitAnswer) {
            for (int i = 0; i < puzzle.solutions.Length; i++)
                puzzle.solutions[i].locked = false;
            waitAnswer = true;
        } else {
            if (Solutioner.chosen == null) {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = emptyMsg;
            } else if (Solutioner.chosen.answer == puzzle.answer) {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = correctMsg;
            } else {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = wrongMsg;
            }
        }
    }

}
