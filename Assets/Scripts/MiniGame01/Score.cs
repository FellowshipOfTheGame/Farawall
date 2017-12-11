using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	public Text ScoreText;
	public static int ScoreValue;

	void Start(){
		ScoreValue = 0;
	}

	void LateUpdate(){
		ScoreText.text = "" + ScoreValue;
	}

}
