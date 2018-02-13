using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Asker : MonoBehaviour {

    GameManager gm;
    public int puzzleId;
    bool isNew = true;
    public bool endPuzzle;
    bool waitAnswer = false;
    public string correctMsg, wrongMsg, emptyMsg;
    public StatueControl[] solutions;
    StatueControl myStatue;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>() as GameManager;
        myStatue = this.GetComponent<StatueControl>();
	}

    public void talk() {
        if (!endPuzzle)
            activePuzzle();
        else
            getAnswer();
    }

    public void activePuzzle() {
        if (isNew) {
            gm.ActivePuzzle(puzzleId);
            Key k = this.GetComponent<DropItem>().Drop().GetComponent<Key>() as Key;
            k.door = gm.puzzles[puzzleId].startDoor;
            isNew = false;
        }
    }

    public void getAnswer() {
        if (!waitAnswer) {
            for (int i = 0; i < solutions.Length; i++)
                solutions[i].locked = false;
            waitAnswer = true;
        }else {
            if (Solutioner.chosen == null) {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = emptyMsg;
            }else if(Solutioner.chosen.answer == gm.puzzles[puzzleId].answer) {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = correctMsg;
            }else {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = wrongMsg;
            }
        }
    }

}