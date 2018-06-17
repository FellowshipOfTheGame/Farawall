using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Inquisitor : MonoBehaviour {

    bool waitAnswer = false;
	public string nextScene;
    public int id;
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
        if (!waitAnswer) { //first time talking to player
            for (int i = 0; i < GameManager.instance.activedPuzzles[id].solutions.Length; i++) {
                GameManager.instance.activedPuzzles[id].solutions[i].locked = false; //unlock all solution statues
                Solutioner s = GameManager.instance.activedPuzzles[id].solutions[i].GetComponent<Solutioner>();
                if (s.places.Length > 0) {
                    foreach (ItemPlace ip in s.places) ip.setOp(); //if have itens, set place options
                }
            }
            waitAnswer = true;
        } else {
            if (Solutioner.chosen == null) { //not have answer
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = emptyMsg;
            } else if (Solutioner.chosen.answer == GameManager.instance.activedPuzzles[id].answer) {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = correctMsg;
				GameManager.loadGameScene (nextScene);
            } else {
                myStatue.myBallon.transform.Find("Text").GetComponent<Text>().text = wrongMsg;
                Debug.Log(Solutioner.chosen.answer);
            }
        }
    }

}
