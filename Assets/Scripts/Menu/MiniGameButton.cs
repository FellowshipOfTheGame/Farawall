using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameButton : MonoBehaviour {
	public int miniGameNumber;

	void Start () {
		GetComponent<Button> ().gameObject.SetActive (MiniGamesManager.IsLocked(miniGameNumber-1));
	}
}
