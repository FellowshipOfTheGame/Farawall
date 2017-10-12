using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButtonScript : MonoBehaviour {
	private Button b;

	// Use this for initialization
	void Start () {
		b = GetComponent<Button>();
		b.onClick.AddListener (() =>ChangeScene());
	}

	void ChangeScene(){
		SceneManager.LoadScene ("GameTest", LoadSceneMode.Single);
	}
}
