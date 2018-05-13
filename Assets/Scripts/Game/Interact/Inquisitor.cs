using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inquisitor : MonoBehaviour {

    bool waitAnswer = false;
	public string nextScene;
    public PuzzleInfo puzzle;
    public string correctMsg, wrongMsg, emptyMsg;
    StatueControl myStatue;

    // Use this for initialization
    void Start() {
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
				GameManager.loadGameScene (nextScene);
            } else {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = wrongMsg;
            }
        }
    }

}
