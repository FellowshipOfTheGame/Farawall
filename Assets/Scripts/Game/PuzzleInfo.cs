using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleInfo : MonoBehaviour {

    public int id;
    public string intro, answer;
    public StatueControl[] statues;
    public Door startDoor, endDoor;
    public List<string> infos;

	// Use this for initialization
	void Start () {
        infos = new List<string>();
	}

    public void AddInfo(string info) {
        infos.Add(info);
    }

    public bool isFull() {
        return infos.Count == statues.Length;
    }

    public bool checkAnswer(string answer) {
        return this.answer == answer;
    }
}